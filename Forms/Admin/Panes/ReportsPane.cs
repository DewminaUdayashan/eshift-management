using eshift_management.Core.Services;
using eshift_management.Models;
using eshift_management.Repositories;
using eshift_management.Repositories.Services;
using eshift_management.Services;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eshift_management.Panes
{
    public partial class ReportsPane : UserControl
    {
        private enum ReportType { None, Customers, Resources, OngoingJobs, Revenue }
        private ReportType selectedReportType = ReportType.None;
        private MaterialCard selectedCard = null;

        // Service to fetch report data
        private readonly IReportService _reportService;

        public ReportsPane()
        {
            InitializeComponent();

            // In a real app with DI, these would be injected.
            var customerRepo = new CustomerRepository();
            var truckRepo = new TruckRepository();
            var employeeRepo = new EmployeeRepository();
            var jobRepo = new JobRepository();
            _reportService = new ReportService(customerRepo, truckRepo, employeeRepo, jobRepo);

            webBrowserPreview.DocumentText = GetPlaceholderHtml();
        }

        private async void card_Click(object sender, EventArgs e)
        {
            var clickedCard = (sender is Label ? (MaterialCard)((Label)sender).Parent : (MaterialCard)sender);
            if (selectedCard != null) selectedCard.Depth = 0;
            selectedCard = clickedCard;
            selectedCard.Depth = 1;

            if (selectedCard == cardCustomers) selectedReportType = ReportType.Customers;
            else if (selectedCard == cardResources) selectedReportType = ReportType.Resources;
            else if (selectedCard == cardOngoingJobs) selectedReportType = ReportType.OngoingJobs;
            else if (selectedCard == cardRevenue) selectedReportType = ReportType.Revenue;

            await GenerateReportPreview(); // Make the call asynchronous
            buttonGenerate.Enabled = true;
        }

        private async Task GenerateReportPreview()
        {
            // Show a loading message while fetching data
            webBrowserPreview.DocumentText = GetPlaceholderHtml("Generating report...");
            string htmlContent = "";

            try
            {
                switch (selectedReportType)
                {
                    case ReportType.Customers:
                        htmlContent = await GenerateCustomerReportHtml();
                        break;
                    case ReportType.Resources:
                        htmlContent = await GenerateResourceReportHtml();
                        break;
                    case ReportType.OngoingJobs:
                        htmlContent = await GenerateOngoingJobsReportHtml();
                        break;
                    case ReportType.Revenue:
                        htmlContent = await GenerateRevenueReportHtml();
                        break;
                    default:
                        htmlContent = GetPlaceholderHtml();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate report data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                htmlContent = GetPlaceholderHtml("Error generating report.");
            }

            webBrowserPreview.DocumentText = htmlContent;
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (selectedReportType == ReportType.None) return;
            string htmlContent = webBrowserPreview.DocumentText;
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "HTML File (*.html)|*.html",
                Title = "Save Report",
                FileName = $"{selectedReportType}_Report_{DateTime.Now:yyyy-MM-dd}.html"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, htmlContent);
                    MessageBox.Show("Report saved successfully as an HTML file.\nYou can open this file in any web browser and use the 'Print' function to save it as a PDF.", "Report Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save report. Error: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region HTML Generation Methods

        private async Task<string> GenerateCustomerReportHtml()
        {
            var customers = await _reportService.GetCustomerReportDataAsync();
            var sb = new StringBuilder();
            sb.Append("<tr><th>ID</th><th>Name</th><th>Email</th><th>Phone</th></tr>");
            foreach (var customer in customers)
            {
                sb.Append($"<tr><td>{customer.UserId}</td><td>{customer.FullName}</td><td>{customer.Email}</td><td>{customer.Phone}</td></tr>");
            }
            return GetHtmlTemplate("Customer Report", sb.ToString());
        }

        private async Task<string> GenerateResourceReportHtml()
        {
            var (trucks, employees) = await _reportService.GetResourceReportDataAsync();
            var sb = new StringBuilder();
            sb.Append("<tr><th>ID</th><th>Type</th><th>Identifier</th><th>Status</th></tr>");
            foreach (var truck in trucks)
            {
                sb.Append($"<tr><td>{truck.Id}</td><td>Truck</td><td>{truck.Model} ({truck.LicensePlate})</td><td>{truck.Status}</td></tr>");
            }
            foreach (var emp in employees)
            {
                sb.Append($"<tr><td>{emp.Id}</td><td>{emp.Position}</td><td>{emp.FullName}</td><td>{emp.Status}</td></tr>");
            }
            return GetHtmlTemplate("All Resources Report", sb.ToString());
        }

        private async Task<string> GenerateOngoingJobsReportHtml()
        {
            var onGoingJobs = await _reportService.GetOngoingJobsReportDataAsync();
            var sb = new StringBuilder();
            sb.Append("<tr><th>Job ID</th><th>Customer</th><th>Pickup Date</th><th>Assigned Unit</th></tr>");
            foreach (var job in onGoingJobs)
            {
                sb.Append($"<tr><td>{job.Id}</td><td>{job.Customer.FullName}</td><td>{job.PickupDate:yyyy-MM-dd}</td><td>{job.AssignedUnit?.UnitName ?? "N/A"}</td></tr>");
            }
            return GetHtmlTemplate("On-going & Scheduled Jobs Report", sb.ToString());
        }

        private async Task<string> GenerateRevenueReportHtml()
        {
            var completedJobs = await _reportService.GetRevenueReportDataAsync();
            var sb = new StringBuilder();
            sb.Append("<tr><th>Job ID</th><th>Completion Date</th><th>Customer</th><th>Billed Amount (LKR)</th></tr>");
            decimal totalRevenue = 0;
            foreach (var job in completedJobs)
            {
                sb.Append($"<tr><td>{job.Id}</td><td>{job.PickupDate.AddHours(job.EstimatedHours):yyyy-MM-dd}</td><td>{job.Customer.FullName}</td><td style='text-align:right;'>{job.TotalCost:N2}</td></tr>");
                totalRevenue += job.TotalCost;
            }
            sb.Append($"<tr class='total-row'><td></td><td></td><td style='text-align:right;font-weight:bold;'>Total Revenue</td><td style='text-align:right;font-weight:bold;'>{totalRevenue:N2}</td></tr>");
            return GetHtmlTemplate("Revenue Report (Completed Jobs)", sb.ToString());
        }

        private string GetHtmlTemplate(string title, string tableRows)
        {
            return $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <title>{title}</title>
                    <style>
                        body {{ font-family: 'Segoe UI', sans-serif; }}
                        table {{ width: 100%; border-collapse: collapse; }}
                        th, td {{ border: 1px solid #dddddd; text-align: left; padding: 8px; }}
                        tr:nth-child(even) {{ background-color: #f2f2f2; }}
                        th {{ background-color: #0D47A1; color: white; }}
                        h1 {{ color: #333; }}
                        .total-row {{ background-color: #e0e0e0; font-weight: bold; }}
                    </style>
                </head>
                <body>
                    <h1>{title}</h1>
                    <p>Generated on: {DateTime.Now:F}</p>
                    <table>
                        {tableRows}
                    </table>
                </body>
                </html>";
        }

        private string GetPlaceholderHtml(string message = "Select a report type to generate a preview.")
        {
            return $@"
                <!DOCTYPE html><html><head><style>
                body {{ font-family: 'Segoe UI', sans-serif; display:flex; justify-content:center; align-items:center; height:100vh; color:#888; text-align:center; }}
                </style></head><body><div>{message}</div></body></html>";
        }

        #endregion
    }
}
