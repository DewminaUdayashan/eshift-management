using eshift_management.Models;
using eshift_management.Properties; // Required to access project resources
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO; // Required for MemoryStream
using System.Linq;

namespace eshift_management.Core.Utils
{
    /// <summary>
    /// A service dedicated to generating various PDF reports using the QuestPDF library.
    /// </summary>
    public class PdfReportGenerator
    {
        private static readonly string _primaryColor = "#0D47A1"; // A deep, professional blue

        // --- Reusable styling helpers for table cells ---

        /// <summary>
        /// Applies a standard style to a table header cell.
        /// </summary>
        /// <param name="container">The cell container to style.</param>
        /// <returns>A styled container.</returns>
        private IContainer StyleHeaderCell(IContainer container)
        {
            return container.Background(_primaryColor).PaddingVertical(5).PaddingHorizontal(10);
        }

        /// <summary>
        /// Applies a standard style to a table content cell, with alternating row colors.
        /// </summary>
        /// <param name="container">The cell container to style.</param>
        /// <param name="isEvenRow">Indicates if the row is even to apply alternating background color.</param>
        /// <returns>A styled container.</returns>
        private IContainer StyleContentCell(IContainer container, bool isEvenRow)
        {
            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5)
                            .Background(isEvenRow ? Colors.White : Colors.Grey.Lighten5);
        }

        /// <summary>
        /// Generates a PDF report listing all customers.
        /// </summary>
        /// <param name="customers">A collection of customer data.</param>
        /// <returns>A byte array representing the generated PDF file.</returns>
        public byte[] GenerateCustomerReport(IEnumerable<CustomerModel> customers)
        {
            var document = new ReportDocument("Customer Report", customers, (table) =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(50); // ID
                    columns.RelativeColumn(3);  // Name
                    columns.RelativeColumn(4);  // Email
                    columns.RelativeColumn(2);  // Phone
                });

                table.Header(header =>
                {
                    header.Cell().Element(StyleHeaderCell).Text("ID").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).Text("Name").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).Text("Email").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).Text("Phone").FontColor(Colors.White).SemiBold();
                });

                uint index = 0;
                foreach (var customer in customers)
                {
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(customer.UserId);
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(customer.FullName);
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(customer.Email);
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(customer.Phone);
                    index++;
                }
            });
            return document.GeneratePdf();
        }

        /// <summary>
        /// Generates a PDF report listing all company resources (trucks and employees).
        /// </summary>
        /// <param name="trucks">A collection of truck data.</param>
        /// <param name="employees">A collection of employee data.</param>
        /// <returns>A byte array representing the generated PDF file.</returns>
        public byte[] GenerateResourceReport(IEnumerable<Truck> trucks, IEnumerable<Employee> employees)
        {
            var document = new ReportDocument("All Resources Report", trucks.Cast<object>().Concat(employees), (table) =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(50); // ID
                    columns.RelativeColumn(2);  // Type
                    columns.RelativeColumn(4);  // Identifier
                    columns.RelativeColumn(2);  // Status
                });

                table.Header(header =>
                {
                    header.Cell().Element(StyleHeaderCell).Text("ID").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).Text("Type").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).Text("Identifier").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).Text("Status").FontColor(Colors.White).SemiBold();
                });

                uint index = 0;
                foreach (var truck in trucks)
                {
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(truck.Id);
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text("Truck");
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text($"{truck.Model} ({truck.LicensePlate})");
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(truck.Status.ToString());
                    index++;
                }
                foreach (var emp in employees)
                {
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(emp.Id);
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(emp.Position.ToString());
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(emp.FullName);
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(emp.Status.ToString());
                    index++;
                }
            });
            return document.GeneratePdf();
        }

        /// <summary>
        /// Generates a PDF report listing all scheduled and on-going jobs.
        /// </summary>
        /// <param name="jobs">A collection of job data.</param>
        /// <returns>A byte array representing the generated PDF file.</returns>
        public byte[] GenerateOngoingJobsReport(IEnumerable<Job> jobs)
        {
            var document = new ReportDocument("On-going & Scheduled Jobs Report", jobs, (table) =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(60);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(3);
                });

                table.Header(header =>
                {
                    header.Cell().Element(StyleHeaderCell).Text("Job ID").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).Text("Customer").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).Text("Pickup Date").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).Text("Assigned Unit").FontColor(Colors.White).SemiBold();
                });

                uint index = 0;
                foreach (var job in jobs)
                {
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(job.Id);
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(job.Customer.FullName);
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(job.PickupDate.ToString("yyyy-MM-dd"));
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(job.AssignedUnit?.UnitName ?? "N/A");
                    index++;
                }
            });
            return document.GeneratePdf();
        }

        /// <summary>
        /// Generates a PDF report summarizing revenue from all completed jobs.
        /// </summary>
        /// <param name="jobs">A collection of completed job data.</param>
        /// <returns>A byte array representing the generated PDF file.</returns>
        public byte[] GenerateRevenueReport(IEnumerable<Job> jobs)
        {
            var document = new ReportDocument("Revenue Report (Completed Jobs)", jobs, (table) =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(60);
                    columns.RelativeColumn(2);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn(2);
                });

                table.Header(header =>
                {
                    header.Cell().Element(StyleHeaderCell).Text("Job ID").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).Text("Completion Date").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).Text("Customer").FontColor(Colors.White).SemiBold();
                    header.Cell().Element(StyleHeaderCell).AlignRight().Text("Billed Amount (LKR)").FontColor(Colors.White).SemiBold();
                });

                uint index = 0;
                decimal totalRevenue = 0;
                foreach (var job in jobs)
                {
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(job.Id);
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(job.PickupDate.AddHours(job.EstimatedHours).ToString("yyyy-MM-dd"));
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).Text(job.Customer.FullName);
                    table.Cell().Element(c => StyleContentCell(c, index % 2 == 0)).AlignRight().Text($"{job.TotalCost:N2}");
                    totalRevenue += job.TotalCost;
                    index++;
                }

                table.Cell().ColumnSpan(3).Background(Colors.Grey.Lighten3).Padding(5).AlignRight().Text("Total Revenue").Bold();
                table.Cell().Background(Colors.Grey.Lighten3).Padding(5).AlignRight().Text($"{totalRevenue:N2}").Bold();
            });
            return document.GeneratePdf();
        }

        public byte[] GenerateInvoicePdf(Job job)
        {
            var document = new InvoiceDocument(job);
            return document.GeneratePdf();
        }
    }

    /// <summary>
    /// A professionally designed, reusable document structure for all reports.
    /// </summary>
    public class ReportDocument : IDocument
    {
        private readonly string _title;
        private readonly Action<TableDescriptor> _tableContent;
        private readonly bool _hasData;
        private static readonly string _primaryColor = "#0D47A1";

        /// <summary>
        /// Initializes a new instance of the <see cref="ReportDocument"/> class.
        /// </summary>
        /// <param name="title">The title of the report.</param>
        /// <param name="data">The collection of data to be displayed. Used to check if data exists.</param>
        /// <param name="tableContent">An action that defines the structure and content of the report's main table.</param>
        public ReportDocument(string title, IEnumerable<object> data, Action<TableDescriptor> tableContent)
        {
            _title = title;
            _tableContent = tableContent;
            _hasData = data.Any();
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(40);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Calibri));
                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
            });
        }

        /// <summary>
        /// Composes the header section of the report, including logo and company details.
        /// </summary>
        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                // --- Logo ---
                var logoData = GetLogoFromResources();
                if (logoData.Length > 0)
                {
                    row.ConstantItem(64).Image(logoData);
                }

                row.RelativeItem().PaddingLeft(10).Column(column =>
                {
                    column.Item().Text("E-Shift Movers").FontSize(16).Bold().FontColor(_primaryColor);
                    column.Item().Text("No. 123, Galle Road, Panadura, Sri Lanka");
                    column.Item().Text("contact@eshift.lk | +94 11 2 345 678");
                });

                row.RelativeItem().AlignRight().Column(column =>
                {
                    column.Item().AlignRight().Text(_title).FontSize(14).SemiBold();
                    column.Item().AlignRight().Text($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}");
                });
            });
        }

        /// <summary>
        /// Composes the main content area of the report, primarily the data table.
        /// </summary>
        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(25).Column(column =>
            {
                column.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                column.Item().PaddingVertical(10);
                if (!_hasData)
                {
                    column.Item().AlignCenter().Text("No data available for this report.").FontSize(14).SemiBold();
                    return;
                }
                column.Item().Table(table =>
                {
                    _tableContent(table);
                });
            });
        }

        /// <summary>
        /// Composes the footer section of the report, including page numbers.
        /// </summary>
        void ComposeFooter(IContainer container)
        {
            container.AlignCenter().Row(row =>
            {
                row.RelativeItem().Text(text =>
                {
                    text.Span("Page ");
                    text.CurrentPageNumber();
                    text.Span(" of ");
                    text.TotalPages();
                });
                row.RelativeItem().AlignRight().Text("E-Shift Movers - Your Trusted Partner");
            });
        }

        /// <summary>
        /// Retrieves the logo image from the project's resources and converts it to a byte array.
        /// </summary>
        /// <returns>A byte array representing the logo image.</returns>
        private byte[] GetLogoFromResources()
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    var logoImage = Resources.e_shift_logo;
                    logoImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            catch (Exception)
            {
                // If the logo resource is missing, return an empty array to prevent a crash.
                return Array.Empty<byte>();
            }
        }
    }

    /// <summary>
    /// A professionally designed document structure for a single job invoice.
    /// </summary>
    public class InvoiceDocument : IDocument
    {
        private readonly Job _job;
        private static readonly string _primaryColor = "#0D47A1";

        public InvoiceDocument(Job job)
        {
            _job = job;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(50);
                page.DefaultTextStyle(x => x.FontSize(10).FontFamily(Fonts.Calibri));

                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().Element(ComposeFooter);
            });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                var logoData = GetLogoFromResources();
                if (logoData.Length > 0) row.ConstantItem(80).Image(logoData);

                row.RelativeItem().PaddingLeft(10).Column(column =>
                {
                    column.Item().Text("E-Shift Movers").FontSize(20).Bold().FontColor(_primaryColor);
                    column.Item().Text("No. 123, Galle Road, Panadura, Sri Lanka");
                    column.Item().Text("contact@eshift.lk | +94 11 2 345 678");
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                // --- Invoice Title and Details ---
                column.Item().Row(row =>
                {
                    row.RelativeItem().Column(col =>
                    {
                        col.Item().Text("Invoice").FontSize(28).SemiBold();
                        col.Item().Text($"Invoice #: {_job.Id}");
                        col.Item().Text($"Issued: {DateTime.Now:yyyy-MM-dd}");
                        col.Item().Text($"Due: {_job.PickupDate.AddDays(14):yyyy-MM-dd}");
                    });

                    row.ConstantItem(180).Column(col =>
                    {
                        col.Item().Text("Bill To").SemiBold();
                        col.Item().Text(_job.Customer.FullName);
                        col.Item().Text(_job.Customer.AddressLine);
                        col.Item().Text($"{_job.Customer.City}, {_job.Customer.PostalCode}");
                        col.Item().Text(_job.Customer.Email);
                    });
                });

                column.Item().PaddingVertical(20);

                // --- Invoice Table ---
                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn(4); // Description
                        columns.RelativeColumn(1); // Quantity
                        columns.RelativeColumn(2); // Unit Price
                        columns.RelativeColumn(2); // Total
                    });

                    // Header
                    table.Header(header =>
                    {
                        header.Cell().Background(_primaryColor).Padding(5).Text("Service Description").FontColor(Colors.White);
                        header.Cell().Background(_primaryColor).Padding(5).AlignCenter().Text("Quantity").FontColor(Colors.White);
                        header.Cell().Background(_primaryColor).Padding(5).AlignRight().Text("Unit Price").FontColor(Colors.White);
                        header.Cell().Background(_primaryColor).Padding(5).AlignRight().Text("Total").FontColor(Colors.White);
                    });

                    // Content
                    table.Cell().Padding(5).Text($"Shifting Service: {_job.PickupLocation} to {_job.DropoffLocation}");
                    table.Cell().Padding(5).AlignCenter().Text("1");
                    table.Cell().Padding(5).AlignRight().Text($"{_job.TotalCost:N2} LKR");
                    table.Cell().Padding(5).AlignRight().Text($"{_job.TotalCost:N2} LKR");

                    // Total
                    table.Cell().ColumnSpan(3).AlignRight().PaddingTop(20).Text("Total Amount Due").Bold();
                    table.Cell().AlignRight().PaddingTop(20).Text($"{_job.TotalCost:N2} LKR").Bold();
                });

                // --- Thank You Note ---
                column.Item().PaddingTop(40).Text("Thank you for your business!").SemiBold();
            });
        }

        void ComposeFooter(IContainer container)
        {
            container.AlignCenter().Text("E-Shift Movers - Your Trusted Partner");
        }

        private byte[] GetLogoFromResources()
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    var logoImage = Resources.e_shift_logo;
                    logoImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            catch { return Array.Empty<byte>(); }
        }
    }
}
