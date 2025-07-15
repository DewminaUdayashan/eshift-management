using eshift_management.Core.Services;
using eshift_management.Repositories;
using eshift_management.Repositories.Services;
using eshift_management.Services;

namespace eshift_management
{
    public partial class DashboardPane : UserControl
    {
        private readonly IDashboardService _dashboardService;
        private DataGridView dgvUpcomingJobs;

        public DashboardPane()
        {
            InitializeComponent();

            // Instantiate services
            var jobRepo = new JobRepository();
            var truckRepo = new TruckRepository();
            var customerRepo = new CustomerRepository();
            _dashboardService = new DashboardService(jobRepo, truckRepo, customerRepo);

            SetupUpcomingJobsGrid();

            // Load all dashboard data asynchronously
            _ = LoadDashboardDataAsync();
        }

        private async Task LoadDashboardDataAsync()
        {
            try
            {
                // Fetch stats and upcoming jobs in parallel
                var statsTask = _dashboardService.GetDashboardStatsAsync();
                var upcomingJobsTask = _dashboardService.GetUpcomingJobsAsync();

                await Task.WhenAll(statsTask, upcomingJobsTask);

                var stats = statsTask.Result;
                var upcomingJobs = upcomingJobsTask.Result;

                // Update summary cards
                labelJobsValue.Text = stats.OngoingJobs.ToString();
                labelTrucksValue.Text = stats.AvailableTrucks.ToString();
                labelCustomersValue.Text = stats.ActiveCustomers.ToString();
                labelPendingValue.Text = stats.PendingJobs.ToString();

                // Populate the upcoming jobs grid
                dgvUpcomingJobs.DataSource = upcomingJobs.Select(j => new
                {
                    j.Id,
                    CustomerName = j.Customer.FullName,
                    j.PickupDate,
                    Unit = j.AssignedUnit?.UnitName ?? "N/A"
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load dashboard data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupUpcomingJobsGrid()
        {
            var panelUpcoming = new Panel
            {
                Location = new Point(28, 310), // Position below the existing cards
                Size = new Size(840, 320),    // Fill the remaining space
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };
            this.Controls.Add(panelUpcoming);

            // Title label for Upcoming Jobs panel
            var labelUpcomingTitle = new Label
            {
                Text = "Upcoming Scheduled Jobs",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(0, 0),
                AutoSize = true
            };
            panelUpcoming.Controls.Add(labelUpcomingTitle);

            // Initialize the DataGridView for upcoming jobs
            dgvUpcomingJobs = new DataGridView
            {
                Location = new Point(0, 40),
                Size = new Size(840, 280),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom,
                AutoGenerateColumns = false,
                BackgroundColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                EnableHeadersVisualStyles = false,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true
            };

            // Style the headers
            dgvUpcomingJobs.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvUpcomingJobs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            dgvUpcomingJobs.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvUpcomingJobs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Style the rows
            dgvUpcomingJobs.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvUpcomingJobs.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgvUpcomingJobs.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvUpcomingJobs.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 224, 224);
            dgvUpcomingJobs.DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dgvUpcomingJobs.RowTemplate.Height = 40;

            // Define columns for the DataGridView
            dgvUpcomingJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Job ID", DataPropertyName = "Id", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvUpcomingJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "CustomerName", HeaderText = "Customer", DataPropertyName = "CustomerName", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvUpcomingJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "PickupDate", HeaderText = "Pickup Date", DataPropertyName = "PickupDate", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvUpcomingJobs.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unit", HeaderText = "Assigned Unit", DataPropertyName = "Unit", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });

            panelUpcoming.Controls.Add(dgvUpcomingJobs);
        }
    }
}
