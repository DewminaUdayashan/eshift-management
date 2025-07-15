using eshift_management.Core.Services;
using eshift_management.Forms;
using eshift_management.Models;
using eshift_management.Repositories;
using eshift_management.Services;
using eshift_management.UI;

namespace eshift_management.Panes
{
    public partial class JobsPane : UserControl
    {
        private readonly IAdminJobService _jobService;
        private readonly ITransportUnitService _unitService;
        private Job _selectedJob;

        public JobsPane()
        {
            InitializeComponent();

            // In a real app with DI, these would be injected.
            var jobRepo = new JobRepository();
            var unitRepo = new TransportUnitRepository();
            var truckRepo = new TruckRepository(); // Needed by Unit Repo
            var empRepo = new EmployeeRepository(); // Needed by Unit Repo

            _unitService = new TransportUnitService(unitRepo, truckRepo, empRepo);
            _jobService = new JobService(jobRepo, unitRepo);

            SetupGrid();
            PopulateFilter();
            DisplayJobDetails(null); // Show placeholder initially
            _ = LoadJobsAsync(); // Load initial data
        }

        private async Task LoadJobsAsync()
        {
            try
            {
                var filter = new Dictionary<string, object>();

                // Status Filter
                if (comboBoxStatusFilter.SelectedItem.ToString() != "All")
                {
                    filter.Add("Status", comboBoxStatusFilter.SelectedItem.ToString());
                }

                // You can add SearchTerm and Date filters here later if needed.

                var jobs = await _jobService.GetAllJobsAsync(filter, orderBy: "PickupDate", isAscending: true);

                dataGridViewJobs.DataSource = jobs.Select(j => new
                {
                    j.Id,
                    CustomerName = j.Customer.FullName,
                    j.PickupDate,
                    j.Status
                }).ToList();

                // After reloading, clear the selection and details pane
                DisplayJobDetails(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load jobs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Setup and Display Logic
        private void SetupGrid()
        {
            dataGridViewJobs.CellPainting += dataGridViewJobs_CellPainting;
            dataGridViewJobs.AutoGenerateColumns = false;
            dataGridViewJobs.Columns.Clear();
            AddGridColumn("Id", "Job ID");
            AddGridColumn("CustomerName", "Customer");
            AddGridColumn("PickupDate", "Pickup Date");
            AddGridColumn("Status", "Status");
        }

        private void AddGridColumn(string dataPropertyName, string headerText)
        {
            var column = new DataGridViewTextBoxColumn { DataPropertyName = dataPropertyName, Name = dataPropertyName, HeaderText = headerText, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            dataGridViewJobs.Columns.Add(column);
        }

        private void PopulateFilter()
        {
            var statuses = new List<string> { "All" };
            statuses.AddRange(Enum.GetNames(typeof(JobStatus)));
            comboBoxStatusFilter.DataSource = statuses;
            comboBoxStatusFilter.SelectedIndex = 0;
        }

        private void DisplayJobDetails(Job job)
        {
            _selectedJob = job;
            if (job == null)
            {
                panelDetails.Visible = false;
                panelActions.Visible = false;
                panelPlaceholder.Visible = true;
                return;
            }

            panelDetails.Visible = true;
            panelActions.Visible = true;
            panelPlaceholder.Visible = false;

            labelCustomerName.Text = job.Customer.FullName;
            labelPickup.Text = $"{job.PickupLocation} on {job.PickupDate:D}";
            labelDropoff.Text = job.DropoffLocation;
            labelLoadSize.Text = job.LoadSize;
            textBoxDescription.Text = job.Description;
            labelAssignedUnitValue.Text = job.AssignedUnit != null ? $"{job.AssignedUnit.UnitName} ({job.AssignedUnit.Id})" : "N/A";
            UpdateActionButtons(job.Status);
        }

        private void UpdateActionButtons(JobStatus status)
        {
            panelActions.Controls.OfType<Control>().ToList().ForEach(c => c.Visible = false);
            switch (status)
            {
                case JobStatus.Pending:
                    buttonAccept.Visible = true;
                    buttonReject.Visible = true;
                    break;
                case JobStatus.Approved:
                    buttonAssignOrChangeUnit.Text = "Assign Unit";
                    buttonAssignOrChangeUnit.Visible = true;
                    buttonCancel.Visible = true;
                    break;
                case JobStatus.Scheduled:
                    buttonAssignOrChangeUnit.Text = "Change Unit";
                    buttonAssignOrChangeUnit.Visible = true;
                    buttonDispatch.Visible = true;
                    buttonCancel.Visible = true;
                    break;
                case JobStatus.OnGoing:
                    buttonComplete.Visible = true;
                    break;
            }
        }
        #endregion

        #region Event Handlers
        private async void dataGridViewJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewJobs.SelectedRows.Count > 0)
            {
                try
                {
                    int jobId = (int)dataGridViewJobs.SelectedRows[0].Cells["Id"].Value;
                    var job = await _jobService.GetJobByIdAsync(jobId);
                    DisplayJobDetails(job);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching job details: {ex.Message}", "Error");
                    DisplayJobDetails(null);
                }
            }
            else
            {
                DisplayJobDetails(null);
            }
        }

        private async void comboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadJobsAsync();
        }

        private async void buttonAccept_Click(object sender, EventArgs e)
        {
            using (var form = new AcceptJobForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await _jobService.ApproveJobAsync(_selectedJob.Id, form.TotalCost, form.EstimatedHours);
                    await LoadJobsAsync();
                    MessageBox.Show("Job has been approved.");
                }
            }
        }

        private async void buttonReject_Click(object sender, EventArgs e)
        {
            using (var form = new RejectJobForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await _jobService.RejectJobAsync(_selectedJob.Id, form.RejectionReason);
                    await LoadJobsAsync();
                    MessageBox.Show("Job has been rejected.");
                }
            }
        }

        private async void buttonAssignOrChangeUnit_Click(object sender, EventArgs e)
        {
            var availableUnits = (await _unitService.GetTransportUnitsByStatusAsync(ResourceStatus.Available)).ToList();
            if (_selectedJob.AssignedUnit != null)
            {
                availableUnits.Add(_selectedJob.AssignedUnit);
            }

            using (var form = new AssignUnitForm(availableUnits))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    await _jobService.AssignTransportUnitAsync(_selectedJob.Id, form.SelectedUnit.Id);
                    await LoadJobsAsync();
                    MessageBox.Show($"Unit '{form.SelectedUnit.UnitName}' has been assigned.");
                }
            }
        }

        private async void buttonDispatch_Click(object sender, EventArgs e)
        {
            await _jobService.DispatchJobAsync(_selectedJob.Id);
            await LoadJobsAsync();
            MessageBox.Show("Job has been dispatched and is now On-Going.");
        }

        private async void buttonComplete_Click(object sender, EventArgs e)
        {
            await _jobService.CompleteJobAsync(_selectedJob.Id);
            await LoadJobsAsync();
            MessageBox.Show("Job has been marked as Completed.");
        }

        private async void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this job?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                await _jobService.CancelJobAsync(_selectedJob.Id);
                await LoadJobsAsync();
                MessageBox.Show("Job has been canceled.");
            }
        }

        private void dataGridViewJobs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewJobs.Columns["Status"].Index && e.RowIndex >= 0 && e.Value != null)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                if (Enum.TryParse(e.Value.ToString(), out JobStatus status))
                {
                    ControlHelpers.DrawStatusChip(e.Graphics, e.CellBounds, status);
                }
            }
        }
        #endregion
    }
}
