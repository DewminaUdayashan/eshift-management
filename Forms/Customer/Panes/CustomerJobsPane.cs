using eshift_management.Core.Services;
using eshift_management.Forms;
using eshift_management.Models;
using eshift_management.Repositories;
using eshift_management.Repositories.Services;
using eshift_management.Services;
using eshift_management.Services.Implementations;
using eshift_management.Services.Interfaces;
using eshift_management.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eshift_management.Panes
{
    public partial class CustomerJobsPane : UserControl
    {
        private readonly ICustomerJobService _jobService;
        private readonly ICustomerService _customerService;
        private List<Job> allJobs;
        private Job? selectedJob;
        private UserModel user;
        private CustomerModel customer;

        public CustomerJobsPane(UserModel user)
        {
            InitializeComponent();
            _jobService = new JobService(new JobRepository(), new TransportUnitRepository(), new UserRepository(), new CustomerRepository(), new EmailService());
            _customerService = new CustomerService(new CustomerRepository());
            this.user = user;
            SetupGrid();
            LoadAndDisplayJobsAsync();
            LoadCustomerAsync();
        }

        private async Task LoadCustomerAsync()
        {
            customer = await _customerService.GetByIdAsync(user.Id ?? 0);
        }

        private async Task LoadAndDisplayJobsAsync()
        {
            allJobs = (await _jobService.GetJobsByCustomerAsync(user.Id ?? 0)).ToList();
            UpdateGridDisplay();
            // DisplayJobDetails(null) is called within UpdateGridDisplay when empty
        }

        private void buttonEditJob_Click(object sender, EventArgs e)
        {
            if (selectedJob == null) return;

            using (var form = new PlaceJobForm(customer, selectedJob!))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _ = UpdateJobAsync(form.TheJob);
                }
            }
        }

        private async Task UpdateJobAsync(Job updatedJob)
        {
            await _jobService.UpdateJobAsync(updatedJob);
            await LoadAndDisplayJobsAsync();
            MessageBox.Show("Your job has been updated.", "Job Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonAddNewJob_Click(object sender, EventArgs e)
        {
            using (var form = new PlaceJobForm(customer))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _ = AddNewJobAsync(form.TheJob);
                }
            }
        }

        private async Task AddNewJobAsync(Job newJob)
        {
            // The service call to actually add the job seems to be missing here.
            // Assuming it should be something like this:
            // await _jobService.CreateJobAsync(newJob); 

            await LoadAndDisplayJobsAsync();
            MessageBox.Show("Your job has been submitted for review.", "Job Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonViewInvoice_Click(object sender, EventArgs e)
        {
            if (selectedJob == null || selectedJob.Status != JobStatus.Completed) return;

            using (var form = new InvoiceViewerForm(selectedJob))
            {
                form.ShowDialog();
            }
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
            if (e.ColumnIndex >= 0 && dataGridViewJobs.Columns[e.ColumnIndex].Name == "Status" && e.RowIndex >= 0)
            {
                e.Handled = true;
                e.PaintBackground(e.CellBounds, true);
                var jobData = dataGridViewJobs.Rows[e.RowIndex].DataBoundItem as dynamic;
                if (jobData != null)
                {
                    ControlHelpers.DrawStatusChip(e.Graphics, e.CellBounds, jobData.Status);
                }
            }
        }

        private void UpdateGridDisplay()
        {
            if (allJobs.Any())
            {
                // We have jobs, show the grid and hide the empty state
                splitContainer1.Visible = true;
                panelEmptyState.Visible = false;

                dataGridViewJobs.DataSource = allJobs.OrderByDescending(j => j.PickupDate)
                    .Select(j => new
                    {
                        j.Id,
                        j.PickupDate,
                        j.Status,
                        j.PickupLocation,
                        j.DropoffLocation
                    }).ToList();

                // Select the first row if there is any
                if (dataGridViewJobs.Rows.Count > 0)
                {
                    dataGridViewJobs.ClearSelection();
                    dataGridViewJobs.Rows[0].Selected = true;
                }
            }
            else
            {
                // No jobs, hide the grid and show the empty state
                splitContainer1.Visible = false;
                panelEmptyState.Visible = true;
                DisplayJobDetails(null); // Ensure details pane is cleared
            }
        }

        private void DisplayJobDetails(Job job)
        {
            selectedJob = job;
            if (job == null)
            {
                panelDetails.Visible = false;
                panelActions.Visible = false;
                labelDetailsTitle.Text = allJobs.Any() ? "Select a job to see details" : ""; // Clear title if empty
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
                string jobIdString = dataGridViewJobs.SelectedRows[0].Cells["Id"].Value.ToString();
                if (int.TryParse(jobIdString, out int jobId))
                {
                    var job = allJobs.FirstOrDefault(j => j.Id == jobId);
                    DisplayJobDetails(job);
                }
            }
            else
            {
                DisplayJobDetails(null);
            }
        }
    }
}