using eshift_management.Models;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eshift_management.Panes
{
    public partial class ReportsPane : UserControl
    {
        private enum ReportType { None, Customers, Resources, OngoingJobs, Revenue }
        private ReportType selectedReportType = ReportType.None;
        private MaterialCard selectedCard = null;

        // Master lists for all dummy data
        private List<CustomerModel> _customers;
        private List<Truck> _trucks;
        private List<Employee> _employees;
        private List<TransportUnit> _units;
        private List<Job> _jobs;


        public ReportsPane()
        {
            InitializeComponent();
            CreateFullDummyDataset(); // Create a complete set of data on load
            webBrowserPreview.DocumentText = GetPlaceholderHtml();
        }

        /// <summary>
        /// Creates a complete set of dummy data for all reports.
        /// </summary>
        private void CreateFullDummyDataset()
        {
            // Customers
            _customers = new List<CustomerModel>
            {
                new CustomerModel { Id = 1,UserId=0, FirstName = "John", LastName = "Smith", Email = "john.smith@example.com", Phone = "555-0101", AddressLine = "123 Maple St", City = "Springfield", PostalCode = "12345" },
                new CustomerModel { Id = 2,UserId=0, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", Phone = "555-0102", AddressLine = "456 Oak Ave", City = "Shelbyville", PostalCode = "54321" }
            };

            // Trucks
            _trucks = new List<Truck>
            {
                new Truck { Id = "TRK-01", Model = "Isuzu Elf", LicensePlate = "CBA-1234", Status = ResourceStatus.Available },
                new Truck { Id = "TRK-02", Model = "Mitsubishi Canter", LicensePlate = "CAB-5678", Status = ResourceStatus.Assigned }
            };

            // Employees
            _employees = new List<Employee>
            {
                new Employee { Id = "EMP-01", FirstName = "Kamal", LastName = "Perera", Position = EmployeePosition.Driver, Status = ResourceStatus.Assigned, ContactNumber = "071-111", LicenseNumber = "B123456" },
                new Employee { Id = "EMP-02", FirstName = "Nimal", LastName = "Silva", Position = EmployeePosition.Driver, Status = ResourceStatus.Available, ContactNumber = "077-222", LicenseNumber = "B789012" },
                new Employee { Id = "EMP-03", FirstName = "Sunil", LastName = "Fernando", Position = EmployeePosition.Assistant, Status = ResourceStatus.Assigned, ContactNumber = "071-333", LicenseNumber = "N/A" },
                new Employee { Id = "EMP-04", FirstName = "Jagath", LastName = "Zoysa", Position = EmployeePosition.Assistant, Status = ResourceStatus.Available, ContactNumber = "077-444", LicenseNumber = "N/A" }
            };

            // Transport Units
            _units = new List<TransportUnit>
            {
                new TransportUnit { Id = "UNIT-01", UnitName = "Team Alpha", Truck = _trucks[1], Driver = _employees[0], Assistant = _employees[2], Status = ResourceStatus.Assigned, AssignedJobId = "JOB-003" }
            };

            // Jobs
            _jobs = new List<Job>
            {
                 new Job { Id = "JOB-003", Status = JobStatus.Scheduled, PickupDate = DateTime.Now.AddDays(2), Customer = _customers[1], AssignedUnit = _units[0], PickupLocation = "Negombo", DropoffLocation = "Trincomalee", LoadSize="Small", Description="Desc", RejectionReason="", TotalCost=40000, EstimatedHours=8 },
                 new Job { Id = "JOB-004", Status = JobStatus.OnGoing, PickupDate = DateTime.Now, Customer = _customers[0], AssignedUnit = _units[0], PickupLocation = "Matara", DropoffLocation = "Batticaloa", LoadSize="Medium", Description="Desc", RejectionReason="", TotalCost=60000, EstimatedHours=10 },
                 new Job { Id = "JOB-005", Status = JobStatus.Completed, PickupDate = DateTime.Now.AddDays(-10), TotalCost = 35000, EstimatedHours = 7, Customer = _customers[0], AssignedUnit = _units[0], PickupLocation = "Kalutara", DropoffLocation = "Anuradhapura", LoadSize="Small", Description="Desc", RejectionReason=""}
            };
        }

        private void card_Click(object sender, EventArgs e)
        {
            var clickedCard = (sender is Label ? (MaterialCard)((Label)sender).Parent : (MaterialCard)sender);
            if (selectedCard != null) selectedCard.Depth = 0;
            selectedCard = clickedCard;
            selectedCard.Depth = 1;
            if (selectedCard == cardCustomers) selectedReportType = ReportType.Customers;
            else if (selectedCard == cardResources) selectedReportType = ReportType.Resources;
            else if (selectedCard == cardOngoingJobs) selectedReportType = ReportType.OngoingJobs;
            else if (selectedCard == cardRevenue) selectedReportType = ReportType.Revenue;
            GenerateReportPreview();
            buttonGenerate.Enabled = true;
        }

        private void GenerateReportPreview()
        {
            string htmlContent = GetPlaceholderHtml("Generating report...");
            switch (selectedReportType)
            {
                case ReportType.Customers:
                    htmlContent = GenerateCustomerReportHtml();
                    break;
                case ReportType.Resources:
                    htmlContent = GenerateResourceReportHtml();
                    break;
                case ReportType.OngoingJobs:
                    htmlContent = GenerateOngoingJobsReportHtml();
                    break;
                case ReportType.Revenue:
                    htmlContent = GenerateRevenueReportHtml();
                    break;
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

        private string GenerateCustomerReportHtml()
        {
            var sb = new StringBuilder();
            sb.Append("<tr><th>ID</th><th>Name</th><th>Email</th><th>Phone</th></tr>");
            foreach (var customer in _customers)
            {
                sb.Append($"<tr><td>{customer.Id}</td><td>{customer.FullName}</td><td>{customer.Email}</td><td>{customer.Phone}</td></tr>");
            }
            return GetHtmlTemplate("Customer Report", sb.ToString());
        }

        private string GenerateResourceReportHtml()
        {
            var sb = new StringBuilder();
            sb.Append("<tr><th>ID</th><th>Type</th><th>Identifier</th><th>Status</th></tr>");
            foreach (var truck in _trucks)
            {
                sb.Append($"<tr><td>{truck.Id}</td><td>Truck</td><td>{truck.Model} ({truck.LicensePlate})</td><td>{truck.Status}</td></tr>");
            }
            foreach (var emp in _employees)
            {
                sb.Append($"<tr><td>{emp.Id}</td><td>{emp.Position}</td><td>{emp.FullName}</td><td>{emp.Status}</td></tr>");
            }
            return GetHtmlTemplate("All Resources Report", sb.ToString());
        }

        private string GenerateOngoingJobsReportHtml()
        {
            var sb = new StringBuilder();
            sb.Append("<tr><th>Job ID</th><th>Customer</th><th>Pickup Date</th><th>Assigned Unit</th></tr>");
            var onGoingJobs = _jobs.Where(j => j.Status == JobStatus.Scheduled || j.Status == JobStatus.OnGoing);
            foreach (var job in onGoingJobs)
            {
                sb.Append($"<tr><td>{job.Id}</td><td>{job.Customer.FullName}</td><td>{job.PickupDate:yyyy-MM-dd}</td><td>{job.AssignedUnit?.UnitName ?? "N/A"}</td></tr>");
            }
            return GetHtmlTemplate("On-going Jobs Report", sb.ToString());
        }

        private string GenerateRevenueReportHtml()
        {
            var sb = new StringBuilder();
            sb.Append("<tr><th>Job ID</th><th>Completion Date</th><th>Customer</th><th>Billed Amount (LKR)</th></tr>");
            var completedJobs = _jobs.Where(j => j.Status == JobStatus.Completed);
            decimal totalRevenue = 0;
            foreach (var job in completedJobs)
            {
                sb.Append($"<tr><td>{job.Id}</td><td>{job.PickupDate.AddHours(job.EstimatedHours):yyyy-MM-dd}</td><td>{job.Customer.FullName}</td><td style='text-align:right;'>{job.TotalCost:N2}</td></tr>");
                totalRevenue += job.TotalCost;
            }
            sb.Append($"<tr class='total-row'><td></td><td></td><td style='text-align:right;font-weight:bold;'>Total Revenue</td><td style='text-align:right;font-weight:bold;'>{totalRevenue:N2}</td></tr>");
            return GetHtmlTemplate("Revenue Report", sb.ToString());
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
                        .total-row {{ background-color: #e0e0e0; }}
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