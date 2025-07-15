using eshift_management.Models;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eshift_management.Services
{
    /// <summary>
    /// A service dedicated to generating various PDF reports using the QuestPDF library.
    /// </summary>
    public class PdfReportGenerator
    {
        public byte[] GenerateCustomerReport(IEnumerable<CustomerModel> customers)
        {
            var document = new ReportDocument("Customer Report", customers, (table) =>
            {
                table.Header(header =>
                {
                    header.Cell().Text("ID");
                    header.Cell().Text("Name");
                    header.Cell().Text("Email");
                    header.Cell().Text("Phone");
                });

                foreach (var customer in customers)
                {
                    table.Cell().Text(customer.UserId);
                    table.Cell().Text(customer.FullName);
                    table.Cell().Text(customer.Email);
                    table.Cell().Text(customer.Phone);
                }
            });
            return document.GeneratePdf();
        }

        public byte[] GenerateResourceReport(IEnumerable<Truck> trucks, IEnumerable<Employee> employees)
        {
            var document = new ReportDocument("All Resources Report", trucks.Cast<object>().Concat(employees), (table) =>
            {
                table.Header(header =>
                {
                    header.Cell().Text("ID");
                    header.Cell().Text("Type");
                    header.Cell().Text("Identifier");
                    header.Cell().Text("Status");
                });

                foreach (var truck in trucks)
                {
                    table.Cell().Text(truck.Id);
                    table.Cell().Text("Truck");
                    table.Cell().Text($"{truck.Model} ({truck.LicensePlate})");
                    table.Cell().Text(truck.Status.ToString());
                }
                foreach (var emp in employees)
                {
                    table.Cell().Text(emp.Id);
                    table.Cell().Text(emp.Position.ToString());
                    table.Cell().Text(emp.FullName);
                    table.Cell().Text(emp.Status.ToString());
                }
            });
            return document.GeneratePdf();
        }

        public byte[] GenerateOngoingJobsReport(IEnumerable<Job> jobs)
        {
            var document = new ReportDocument("On-going & Scheduled Jobs Report", jobs, (table) =>
            {
                table.Header(header =>
                {
                    header.Cell().Text("Job ID");
                    header.Cell().Text("Customer");
                    header.Cell().Text("Pickup Date");
                    header.Cell().Text("Assigned Unit");
                });
                foreach (var job in jobs)
                {
                    table.Cell().Text(job.Id);
                    table.Cell().Text(job.Customer.FullName);
                    table.Cell().Text(job.PickupDate.ToString("yyyy-MM-dd"));
                    table.Cell().Text(job.AssignedUnit?.UnitName ?? "N/A");
                }
            });
            return document.GeneratePdf();
        }

        public byte[] GenerateRevenueReport(IEnumerable<Job> jobs)
        {
            var document = new ReportDocument("Revenue Report (Completed Jobs)", jobs, (table) =>
            {
                table.Header(header =>
                {
                    header.Cell().Text("Job ID");
                    header.Cell().Text("Completion Date");
                    header.Cell().Text("Customer");
                    header.Cell().AlignRight().Text("Billed Amount (LKR)");
                });

                decimal totalRevenue = 0;
                foreach (var job in jobs)
                {
                    table.Cell().Text(job.Id);
                    table.Cell().Text(job.PickupDate.AddHours(job.EstimatedHours).ToString("yyyy-MM-dd"));
                    table.Cell().Text(job.Customer.FullName);
                    table.Cell().AlignRight().Text($"{job.TotalCost:N2}");
                    totalRevenue += job.TotalCost;
                }

                table.Cell().ColumnSpan(3).AlignRight().PaddingTop(10).Text("Total Revenue").Bold();
                table.Cell().AlignRight().PaddingTop(10).Text($"{totalRevenue:N2}").Bold();
            });
            return document.GeneratePdf();
        }
    }

    /// <summary>
    /// A generic document structure for creating reports with QuestPDF.
    /// </summary>
    public class ReportDocument : IDocument
    {
        private readonly string _title;
        private readonly Action<TableDescriptor> _tableContent;
        private readonly bool _hasData;

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
                page.Margin(50);
                page.Header().Element(ComposeHeader);
                page.Content().Element(ComposeContent);
                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Page ");
                    x.CurrentPageNumber();
                });
            });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text(_title).FontSize(20).SemiBold();
                    column.Item().Text($"Generated on: {DateTime.Now:F}");
                });
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                if (!_hasData)
                {
                    column.Item().Text("No data available for this report.").FontSize(14);
                    return;
                }

                column.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        // All current reports use 4 columns of equal relative width.
                        // This can be parameterized later if reports with different column counts are needed.
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    _tableContent(table);
                });
            });
        }
    }
}
