using eshift_management.Core.Services;
using eshift_management.Core.Utils;
using eshift_management.Models;
using eshift_management.Repositories;
using eshift_management.Repositories.Services;
using eshift_management.Services;
using MaterialSkin.Controls;
using System.Text;

namespace eshift_management.Panes
{
    public partial class ReportsPane : UserControl
    {
        private enum ReportType { None, Customers, Resources, OngoingJobs, Revenue }
        private ReportType _selectedReportType = ReportType.None;
        private MaterialCard _selectedCard = null;

        // Services for data fetching and PDF generation
        private readonly IReportService _reportService;
        private readonly PdfReportGenerator _pdfGenerator;

        // To hold the data for the selected report
        private object _currentReportData = null;

        public ReportsPane()
        {
            InitializeComponent();

            // Instantiate services
            var customerRepo = new CustomerRepository();
            var truckRepo = new TruckRepository();
            var employeeRepo = new EmployeeRepository();
            var jobRepo = new JobRepository();
            _reportService = new ReportService(customerRepo, truckRepo, employeeRepo, jobRepo);
            _pdfGenerator = new PdfReportGenerator();

            // Initialize UI state
            webBrowserPreview.DocumentText = GetPlaceholderHtml("Select a report type to begin.");
            buttonGenerate.Enabled = false;
        }

        private async void card_Click(object sender, EventArgs e)
        {
            var clickedCard = (sender is Label ? (MaterialCard)((Label)sender).Parent : (MaterialCard)sender);
            if (_selectedCard != null) _selectedCard.Depth = 0;
            _selectedCard = clickedCard;
            _selectedCard.Depth = 1;

            if (_selectedCard == cardCustomers) _selectedReportType = ReportType.Customers;
            else if (_selectedCard == cardResources) _selectedReportType = ReportType.Resources;
            else if (_selectedCard == cardOngoingJobs) _selectedReportType = ReportType.OngoingJobs;
            else if (_selectedCard == cardRevenue) _selectedReportType = ReportType.Revenue;

            await FetchAndPreviewData();
        }

        private async Task FetchAndPreviewData()
        {
            webBrowserPreview.DocumentText = GetPlaceholderHtml("Fetching data...");
            _currentReportData = null;
            buttonGenerate.Enabled = false;
            string htmlContent = "";

            try
            {
                switch (_selectedReportType)
                {
                    case ReportType.Customers:
                        var customers = (await _reportService.GetCustomerReportDataAsync()).ToList();
                        if (customers.Any())
                        {
                            _currentReportData = customers;
                            htmlContent = GenerateCustomerHtmlPreview(customers);
                        }
                        break;
                    case ReportType.Resources:
                        var resources = await _reportService.GetResourceReportDataAsync();
                        if (resources.Trucks.Any() || resources.Employees.Any())
                        {
                            _currentReportData = resources;
                            htmlContent = GenerateResourceHtmlPreview(resources.Trucks, resources.Employees);
                        }
                        break;
                    case ReportType.OngoingJobs:
                        var ongoingJobs = (await _reportService.GetOngoingJobsReportDataAsync()).ToList();
                        if (ongoingJobs.Any())
                        {
                            _currentReportData = ongoingJobs;
                            htmlContent = GenerateOngoingJobsHtmlPreview(ongoingJobs);
                        }
                        break;
                    case ReportType.Revenue:
                        var revenueJobs = (await _reportService.GetRevenueReportDataAsync()).ToList();
                        if (revenueJobs.Any())
                        {
                            _currentReportData = revenueJobs;
                            htmlContent = GenerateRevenueHtmlPreview(revenueJobs);
                        }
                        break;
                }

                if (_currentReportData != null)
                {
                    buttonGenerate.Enabled = true;
                    webBrowserPreview.DocumentText = htmlContent;
                }
                else
                {
                    webBrowserPreview.DocumentText = GetPlaceholderHtml("No data available for the selected report.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to fetch report data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                webBrowserPreview.DocumentText = GetPlaceholderHtml("Error fetching data.");
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (_currentReportData == null) return;

            byte[] pdfBytes = null;
            try
            {
                switch (_selectedReportType)
                {
                    case ReportType.Customers:
                        pdfBytes = _pdfGenerator.GenerateCustomerReport((List<CustomerModel>)_currentReportData);
                        break;
                    case ReportType.Resources:
                        var res = ((IEnumerable<Truck> Trucks, IEnumerable<Employee> Employees))_currentReportData;
                        pdfBytes = _pdfGenerator.GenerateResourceReport(res.Trucks, res.Employees);
                        break;
                    case ReportType.OngoingJobs:
                        pdfBytes = _pdfGenerator.GenerateOngoingJobsReport((List<Job>)_currentReportData);
                        break;
                    case ReportType.Revenue:
                        pdfBytes = _pdfGenerator.GenerateRevenueReport((List<Job>)_currentReportData);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate PDF: {ex.Message}\n\nThis can sometimes be caused by project build settings (e.g., x86 vs x64). Please check your project configuration.", "PDF Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pdfBytes == null) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF File (*.pdf)|*.pdf",
                Title = "Save Report",
                FileName = $"{_selectedReportType}_Report_{DateTime.Now:yyyy-MM-dd}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(saveFileDialog.FileName, pdfBytes);
                    MessageBox.Show("Report saved successfully as a PDF.", "Report Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save report. Error: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region HTML Preview Generation

        private string GenerateCustomerHtmlPreview(IEnumerable<CustomerModel> customers)
        {
            var sb = new StringBuilder();
            sb.Append("<tr><th>ID</th><th>Name</th><th>Email</th><th>Phone</th></tr>");
            foreach (var customer in customers.Take(20)) // Limit preview to 20 rows
            {
                sb.Append($"<tr><td>{customer.UserId}</td><td>{customer.FullName}</td><td>{customer.Email}</td><td>{customer.Phone}</td></tr>");
            }
            return GetHtmlTemplate("Customer Report Preview", sb.ToString());
        }

        private string GenerateResourceHtmlPreview(IEnumerable<Truck> trucks, IEnumerable<Employee> employees)
        {
            var sb = new StringBuilder();
            sb.Append("<tr><th>ID</th><th>Type</th><th>Identifier</th><th>Status</th></tr>");
            foreach (var truck in trucks.Take(10))
            {
                sb.Append($"<tr><td>{truck.Id}</td><td>Truck</td><td>{truck.Model} ({truck.LicensePlate})</td><td>{truck.Status}</td></tr>");
            }
            foreach (var emp in employees.Take(10))
            {
                sb.Append($"<tr><td>{emp.Id}</td><td>{emp.Position}</td><td>{emp.FullName}</td><td>{emp.Status}</td></tr>");
            }
            return GetHtmlTemplate("All Resources Report Preview", sb.ToString());
        }

        private string GenerateOngoingJobsHtmlPreview(IEnumerable<Job> jobs)
        {
            var sb = new StringBuilder();
            sb.Append("<tr><th>Job ID</th><th>Customer</th><th>Pickup Date</th><th>Assigned Unit</th></tr>");
            foreach (var job in jobs.Take(20))
            {
                sb.Append($"<tr><td>{job.Id}</td><td>{job.Customer.FullName}</td><td>{job.PickupDate:yyyy-MM-dd}</td><td>{job.AssignedUnit?.UnitName ?? "N/A"}</td></tr>");
            }
            return GetHtmlTemplate("On-going Jobs Report Preview", sb.ToString());
        }

        private string GenerateRevenueHtmlPreview(IEnumerable<Job> jobs)
        {
            var sb = new StringBuilder();
            sb.Append("<tr><th>Job ID</th><th>Completion Date</th><th>Customer</th><th>Billed Amount (LKR)</th></tr>");
            decimal totalRevenue = 0;
            foreach (var job in jobs) // Show all completed jobs in revenue preview
            {
                sb.Append($"<tr><td>{job.Id}</td><td>{job.PickupDate.AddHours(job.EstimatedHours):yyyy-MM-dd}</td><td>{job.Customer.FullName}</td><td style='text-align:right;'>{job.TotalCost:N2}</td></tr>");
                totalRevenue += job.TotalCost;
            }
            sb.Append($"<tr class='total-row'><td></td><td></td><td style='text-align:right;font-weight:bold;'>Total Revenue</td><td style='text-align:right;font-weight:bold;'>{totalRevenue:N2}</td></tr>");
            return GetHtmlTemplate("Revenue Report Preview", sb.ToString());
        }

        private string GetHtmlTemplate(string title, string tableRows)
        {
            return $@"
                <!DOCTYPE html><html><head><title>{title}</title><style>
                body {{ font-family: 'Segoe UI', sans-serif; margin: 20px; }}
                table {{ width: 100%; border-collapse: collapse; }}
                th, td {{ border: 1px solid #dddddd; text-align: left; padding: 8px; }}
                tr:nth-child(even) {{ background-color: #f2f2f2; }}
                th {{ background-color: #0D47A1; color: white; }}
                h2 {{ color: #333; }}
                .total-row {{ background-color: #e0e0e0; font-weight: bold; }}
                </style></head><body><h2>{title}</h2><table>{tableRows}</table></body></html>";
        }

        private string GetPlaceholderHtml(string message)
        {
            return $@"
                <!DOCTYPE html><html><head><style>
                body {{ font-family: 'Segoe UI', sans-serif; display:flex; justify-content:center; align-items:center; height:100vh; color:#888; text-align:center; font-size: 1.1em; }}
                </style></head><body><div>{message}</div></body></html>";
        }
        #endregion
    }
}
