using eshift_management.Forms;
using eshift_management.Models;
using eshift_management.UI;

namespace eshift_management.Panes
{
    public partial class JobsPane : UserControl
    {
        private List<Job> allJobs;
        private List<TransportUnit> allUnits;
        private Job selectedJob;

        public JobsPane()
        {
            InitializeComponent();
            SetupGrid();
            LoadDummyData();
            PopulateFilter();
            // Show placeholder initially
            DisplayJobDetails(null);
        }

        private void SetupGrid()
        {
            // Subscribe to the CellPainting event for custom drawing
            dataGridViewJobs.CellPainting += dataGridViewJobs_CellPainting;

            dataGridViewJobs.AutoGenerateColumns = false;
            dataGridViewJobs.Columns.Clear();
            AddGridColumn("Id", "Job ID");
            AddGridColumn("CustomerName", "Customer");
            AddGridColumn("PickupDate", "Pickup Date");
            AddGridColumn("Status", "Status"); // The column whose cells we will custom paint
        }
        private void AddGridColumn(string dataPropertyName, string headerText)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                Name = dataPropertyName,
                HeaderText = headerText,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridViewJobs.Columns.Add(column);
        }


        private void dataGridViewJobs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Check if we are in the "Status" column and not in the header row
            if (e.ColumnIndex == dataGridViewJobs.Columns["Status"].Index && e.RowIndex >= 0)
            {
                // Prevent the default paint
                e.Handled = true;

                // Paint the cell background
                e.PaintBackground(e.CellBounds, true);

                // Get the Job object for the current row
                var jobId = dataGridViewJobs.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                var job = allJobs.FirstOrDefault(j => j.Id == jobId);

                if (job != null)
                {
                    // Call our reusable helper to draw the chip
                    ControlHelpers.DrawStatusChip(e.Graphics, e.CellBounds, job.Status);
                }
            }
        }


        private void LoadDummyData()
        {
            var cust1 = new CustomerModel { Id = 1, UserId = 0, FirstName = "John", LastName = "Smith", Email = "j.s@mail.com", Phone = "111", AddressLine = "1", City = "1", PostalCode = "1" };
            var cust2 = new CustomerModel { Id = 2, UserId = 0, FirstName = "Jane", LastName = "Doe", Email = "j.d@mail.com", Phone = "222", AddressLine = "2", City = "2", PostalCode = "2" };
            var cust3 = new CustomerModel { Id = 3, UserId = 0, FirstName = "Peter", LastName = "Jones", Email = "p.j@mail.com", Phone = "333", AddressLine = "3", City = "3", PostalCode = "3" };
            var cust4 = new CustomerModel { Id = 4, UserId = 0, FirstName = "Mary", LastName = "Johnson", Email = "m.j@mail.com", Phone = "444", AddressLine = "4", City = "4", PostalCode = "4" };

            var truck1 = new Truck { Id = "TRK-01", Model = "Isuzu Elf", LicensePlate = "CBA-1234", Status = ResourceStatus.Available };
            var truck2 = new Truck { Id = "TRK-02", Model = "Mitsubishi Canter", LicensePlate = "CAB-5678", Status = ResourceStatus.Assigned };
            var driver1 = new Employee { Id = "EMP-01", FirstName = "Kamal", LastName = "Perera", Position = EmployeePosition.Driver, ContactNumber = "071-1112222", LicenseNumber = "B123456", Status = ResourceStatus.Assigned };
            var driver2 = new Employee { Id = "EMP-02", FirstName = "Nimal", LastName = "Silva", Position = EmployeePosition.Driver, ContactNumber = "077-2223333", LicenseNumber = "B789012", Status = ResourceStatus.Available };
            var assistant1 = new Employee { Id = "EMP-03", FirstName = "Sunil", LastName = "Fernando", Position = EmployeePosition.Assistant, ContactNumber = "077-1234567", LicenseNumber = "N/A", Status = ResourceStatus.Assigned };
            var assistant2 = new Employee { Id = "EMP-04", FirstName = "Jagath", LastName = "Zoysa", Position = EmployeePosition.Assistant, ContactNumber = "071-7654321", LicenseNumber = "N/A", Status = ResourceStatus.Available };

            var assignedUnit = new TransportUnit { Id = "UNIT-01", UnitName = "Team Alpha", Truck = truck2, Driver = driver1, Assistant = assistant1, Status = ResourceStatus.Assigned, AssignedJobId = "JOB-003" };
            var availableUnit = new TransportUnit { Id = "UNIT-02", UnitName = "Team Bravo", Truck = truck1, Driver = driver2, Assistant = assistant2, Status = ResourceStatus.Available, AssignedJobId = "" };

            allUnits = new List<TransportUnit> { assignedUnit, availableUnit };

            allJobs = new List<Job>
            {
                 new Job { Id = "JOB-001", Customer = cust1, PickupLocation = "Colombo", DropoffLocation = "Kandy", PickupDate = DateTime.Now.AddDays(5), LoadSize = "Medium (3-4 rooms)", Description = "Handle with care, many fragile items.", Status = JobStatus.Pending, AssignedUnit = null, TotalCost=0, EstimatedHours=0, RejectionReason="" },
                 new Job { Id = "JOB-002", Customer = cust2, PickupLocation = "Galle", DropoffLocation = "Jaffna", PickupDate = DateTime.Now.AddDays(10), LoadSize = "Large (5+ rooms)", Description = "Requires piano transport.", Status = JobStatus.Approved, TotalCost = 75000, EstimatedHours = 12, AssignedUnit=null, RejectionReason=""},
                 new Job { Id = "JOB-003", Customer = cust3, PickupLocation = "Negombo", DropoffLocation = "Trincomalee", PickupDate = DateTime.Now.AddDays(2), LoadSize = "Small (1-2 rooms)", Description = "Studio apartment move.", Status = JobStatus.Scheduled, AssignedUnit = assignedUnit, TotalCost = 40000, EstimatedHours = 8, RejectionReason=""},
                 new Job { Id = "JOB-004", Customer = cust4, PickupLocation = "Matara", DropoffLocation = "Batticaloa", PickupDate = DateTime.Now, LoadSize = "Medium (3-4 rooms)", Description = "", Status = JobStatus.OnGoing, AssignedUnit = assignedUnit, TotalCost = 60000, EstimatedHours = 10, RejectionReason=""},
                 new Job { Id = "JOB-005", Customer = cust1, PickupLocation = "Kalutara", DropoffLocation = "Anuradhapura", PickupDate = DateTime.Now.AddDays(-10), LoadSize = "Small (1-2 rooms)", Description = "Completed job.", Status = JobStatus.Completed, AssignedUnit = assignedUnit, TotalCost = 35000, EstimatedHours = 7, RejectionReason=""},
                 new Job { Id = "JOB-006", Customer = cust2, PickupLocation = "Ratnapura", DropoffLocation = "Galle", PickupDate = DateTime.Now.AddDays(8), LoadSize = "Large (5+ rooms)", Description = "Canceled by admin.", Status = JobStatus.Canceled, TotalCost = 0, EstimatedHours = 0, AssignedUnit=null, RejectionReason=""},
            };
        }

        private void PopulateFilter()
        {
            var statuses = new List<string> { "All" };
            statuses.AddRange(Enum.GetNames(typeof(JobStatus)));
            comboBoxStatusFilter.DataSource = statuses;
            comboBoxStatusFilter.SelectedIndex = 0;
        }

        private void UpdateGridDisplay()
        {
            if (allJobs == null || comboBoxStatusFilter.SelectedItem == null) return;
            IEnumerable<Job> filteredJobs = allJobs;
            if (comboBoxStatusFilter.SelectedItem.ToString() != "All")
            {
                var selectedStatus = (JobStatus)Enum.Parse(typeof(JobStatus), comboBoxStatusFilter.SelectedItem.ToString());
                filteredJobs = filteredJobs.Where(j => j.Status == selectedStatus);
            }
            filteredJobs = filteredJobs.OrderBy(j => j.PickupDate);
            dataGridViewJobs.DataSource = filteredJobs.Select(j => new
            {
                j.Id,
                CustomerName = j.Customer.FullName,
                j.PickupDate,
                j.Status
            }).ToList();
        }

        private void DisplayJobDetails(Job job)
        {
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
            selectedJob = job;
            labelCustomerName.Text = job.Customer.FullName;
            labelPickup.Text = $"{job.PickupLocation} on {job.PickupDate:D}";
            labelDropoff.Text = job.DropoffLocation;
            labelLoadSize.Text = job.LoadSize;
            textBoxDescription.Text = job.Description;
            labelAssignedUnitValue.Text = job.AssignedUnit != null ? $"{job.AssignedUnit.UnitName} ({job.AssignedUnit.Truck.LicensePlate})" : "N/A";
            UpdateActionButtons(job.Status);
        }

        private void UpdateActionButtons(JobStatus status)
        {
            foreach (var button in panelActions.Controls.OfType<MaterialSkin.Controls.MaterialButton>())
            {
                button.Visible = false;
            }
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

        private void dataGridViewJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewJobs.SelectedRows.Count > 0)
            {
                var jobId = dataGridViewJobs.SelectedRows[0].Cells["Id"].Value.ToString();
                var job = allJobs.FirstOrDefault(j => j.Id == jobId);
                DisplayJobDetails(job);
            }
            else
            {
                DisplayJobDetails(null);
            }
        }

        private void comboBoxStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGridDisplay();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            using (var form = new AcceptJobForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    selectedJob.Status = JobStatus.Approved;
                    selectedJob.TotalCost = form.TotalCost;
                    selectedJob.EstimatedHours = form.EstimatedHours;
                    UpdateGridDisplay();
                    DisplayJobDetails(selectedJob);
                    MessageBox.Show("Job has been approved.");
                }
            }
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            using (var form = new RejectJobForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    selectedJob.Status = JobStatus.Rejected;
                    selectedJob.RejectionReason = form.RejectionReason;
                    UpdateGridDisplay();
                    DisplayJobDetails(selectedJob);
                    MessageBox.Show("Job has been rejected.");
                }
            }
        }

        private void buttonAssignOrChangeUnit_Click(object sender, EventArgs e)
        {
            var availableUnits = allUnits.Where(u => u.Status == ResourceStatus.Available).ToList();
            if (selectedJob.AssignedUnit != null)
            {
                availableUnits.Add(selectedJob.AssignedUnit);
            }
            using (var form = new AssignUnitForm(availableUnits))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (selectedJob.AssignedUnit != null)
                    {
                        selectedJob.AssignedUnit.Status = ResourceStatus.Available;
                    }
                    selectedJob.Status = JobStatus.Scheduled;
                    selectedJob.AssignedUnit = form.SelectedUnit;
                    selectedJob.AssignedUnit.Status = ResourceStatus.Assigned;
                    UpdateGridDisplay();
                    DisplayJobDetails(selectedJob);
                    MessageBox.Show($"Unit '{form.SelectedUnit.UnitName}' has been assigned.");
                }
            }
        }

        private void buttonDispatch_Click(object sender, EventArgs e)
        {
            selectedJob.Status = JobStatus.OnGoing;
            UpdateGridDisplay();
            DisplayJobDetails(selectedJob);
            MessageBox.Show("Job has been dispatched and is now On-Going.");
        }

        private void buttonComplete_Click(object sender, EventArgs e)
        {
            selectedJob.Status = JobStatus.Completed;
            selectedJob.AssignedUnit.Status = ResourceStatus.Available;
            UpdateGridDisplay();
            DisplayJobDetails(selectedJob);
            MessageBox.Show("Job has been marked as Completed.");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this job?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                selectedJob.Status = JobStatus.Canceled;
                if (selectedJob.AssignedUnit != null)
                {
                    selectedJob.AssignedUnit.Status = ResourceStatus.Available;
                }
                UpdateGridDisplay();
                DisplayJobDetails(selectedJob);
                MessageBox.Show("Job has been canceled.");
            }
        }
    }
}