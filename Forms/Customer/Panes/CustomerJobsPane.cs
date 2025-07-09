using eshift_management.Models;
using eshift_management.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management.Panes
{
    public partial class CustomerJobsPane : UserControl
    {
        private List<Job> allJobs;
        private Job selectedJob;

        public CustomerJobsPane()
        {
            InitializeComponent();
            LoadDummyData();
            SetupGrid();
            UpdateGridDisplay();
            DisplayJobDetails(null);
        }

        private void SetupGrid()
        {
            dataGridViewJobs.CellPainting += dataGridViewJobs_CellPainting;
            dataGridViewJobs.AutoGenerateColumns = false;
            dataGridViewJobs.Columns.Clear();
            AddGridColumn("Id", "Job ID");
            AddGridColumn("PickupDate", "Pickup Date");
            AddGridColumn("Status", "Status");
            AddGridColumn("PickupLocation", "From");
            AddGridColumn("DropoffLocation", "To");
        }

        // ... (rest of the methods are unchanged from the previous version) ...

        private void buttonAddNewJob_Click(object sender, EventArgs e)
        {
            // This is the new home for the Place New Job logic
            MessageBox.Show("The form to place a new job will be implemented here.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Unchanged Methods
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
            if (e.ColumnIndex == dataGridViewJobs.Columns["Status"].Index && e.RowIndex >= 0)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                // The 'dynamic' keyword is used here for simplicity with anonymous types
                var jobData = dataGridViewJobs.Rows[e.RowIndex].DataBoundItem as dynamic;
                if (jobData != null)
                {
                    ControlHelpers.DrawStatusChip(e.Graphics, e.CellBounds, jobData.Status);
                }
            }
        }

        private void LoadDummyData()
        {
            var loggedInCustomer = new CustomerModel
            {
                Id = "CUST-001",
                FirstName = "John",
                LastName = "Smith",
                Email = "john.s@example.com",
                Phone = "077-1234567",
                AddressLine = "123 Galle Rd",
                City = "Panadura",
                PostalCode = "12500"
            };

            allJobs = new List<Job>
            {
                new Job { Id = "JOB-001", Customer = loggedInCustomer, PickupLocation = "Colombo", DropoffLocation = "Kandy", PickupDate = DateTime.Now.AddDays(5), Status = JobStatus.Pending, LoadSize = "Medium (3-4 rooms)", Description = "Handle with care, many fragile items.", TotalCost = 0, EstimatedHours = 0, RejectionReason = "", AssignedUnit = null },
                new Job { Id = "JOB-005", Customer = loggedInCustomer, PickupLocation = "Kalutara", DropoffLocation = "Anuradhapura", PickupDate = DateTime.Now.AddDays(-10), Status = JobStatus.Completed, TotalCost = 35000, LoadSize = "Small (1-2 rooms)", Description = "Everything went smoothly.", EstimatedHours = 7, RejectionReason = "", AssignedUnit = null },
                new Job { Id = "JOB-007", Customer = loggedInCustomer, PickupLocation = "Gampaha", DropoffLocation = "Matara", PickupDate = DateTime.Now.AddDays(20), Status = JobStatus.Approved, LoadSize = "Large (5+ rooms)", Description = "Awaiting unit assignment.", TotalCost = 95000, EstimatedHours = 14, RejectionReason = "", AssignedUnit = null },
            };
        }

        private void UpdateGridDisplay()
        {
            dataGridViewJobs.DataSource = allJobs.OrderByDescending(j => j.PickupDate)
                .Select(j => new
                {
                    j.Id,
                    j.PickupDate,
                    j.Status,
                    j.PickupLocation,
                    j.DropoffLocation
                }).ToList();
        }

        private void DisplayJobDetails(Job job)
        {
            selectedJob = job;
            if (job == null)
            {
                panelDetails.Visible = false;
                panelActions.Visible = false;
                return;
            }
            panelDetails.Visible = true;
            panelActions.Visible = true;
            labelDetailsTitle.Text = $"Details for Job #{job.Id}";
            labelStatus.Text = job.Status.ToString();
            labelPickup.Text = $"{job.PickupLocation} on {job.PickupDate:D}";
            labelDropoff.Text = job.DropoffLocation;
            UpdateActionButtons(job.Status);
        }

        private void UpdateActionButtons(JobStatus status)
        {
            buttonEditJob.Visible = (status == JobStatus.Pending);
            buttonViewInvoice.Visible = (status == JobStatus.Completed);
        }

        private void dataGridViewJobs_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewJobs.SelectedRows.Count > 0)
            {
                string jobId = dataGridViewJobs.SelectedRows[0].Cells["Id"].Value.ToString();
                var job = allJobs.FirstOrDefault(j => j.Id == jobId);
                DisplayJobDetails(job);
            }
            else
            {
                DisplayJobDetails(null);
            }
        }

        private void buttonEditJob_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Editing for Job #{selectedJob.Id} will be implemented here.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonViewInvoice_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Invoice for Job #{selectedJob.Id} will be shown here.", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}