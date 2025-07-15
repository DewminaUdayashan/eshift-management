using eshift_management.Core.Services;
using eshift_management.Models;
using eshift_management.Repositories;
using eshift_management.Services;
using FluentValidation.Results;
using MaterialSkin.Controls;

namespace eshift_management.Forms
{
    public partial class PlaceJobForm : MaterialForm
    {
        private readonly CustomerModel currentCustomer;
        private readonly Job currentJob;
        private readonly bool isEditMode;
        private readonly ICustomerJobService jobService;

        public Job TheJob { get; private set; }

        public PlaceJobForm(CustomerModel user, Job jobToEdit = null)
        {
            InitializeComponent();

            this.currentCustomer = user;
            this.currentJob = jobToEdit;
            this.jobService = new JobService(new JobRepository(), new TransportUnitRepository());
            this.isEditMode = (currentJob != null);

            SetupForm();
        }

        private void SetupForm()
        {
            comboBoxLoadSize.DataSource = new string[] { "Small (1-2 rooms)", "Medium (3-4 rooms)", "Large (5+ rooms)" };

            if (isEditMode)
            {
                this.Text = "Edit Your Job";
                buttonSubmit.Text = "Update Job";

                textBoxPickupAddress.Text = currentJob.PickupLocation;
                textBoxDropoffAddress.Text = currentJob.DropoffLocation;
                dateTimePickerPickup.Value = currentJob.PickupDate;
                comboBoxLoadSize.SelectedItem = currentJob.LoadSize;
                textBoxDescription.Text = currentJob.Description;
            }
            else
            {
                this.Text = "Place a New Job";
            }
        }

        private void checkBoxUseProfileAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUseProfileAddress.Checked)
            {
                textBoxPickupAddress.Text = $"{currentCustomer.AddressLine}, {currentCustomer.City}";
                textBoxPickupAddress.ReadOnly = true;
            }
            else
            {
                textBoxPickupAddress.Text = "";
                textBoxPickupAddress.ReadOnly = false;
            }
        }

        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
            var job = new Job
            {
                Id = isEditMode ? currentJob.Id : 0,
                Customer = currentCustomer,
                PickupLocation = textBoxPickupAddress.Text.Trim(),
                DropoffLocation = textBoxDropoffAddress.Text.Trim(),
                PickupDate = dateTimePickerPickup.Value,
                LoadSize = comboBoxLoadSize.SelectedItem.ToString(),
                Description = textBoxDescription.Text.Trim(),
                Status = JobStatus.Pending
            };

            var validator = new JobValidator();
            ValidationResult validationResult = validator.Validate(job);

            if (!validationResult.IsValid)
            {
                var allErrors = string.Join("\n", validationResult.Errors.Select(err => err.ErrorMessage));
                MessageBox.Show(allErrors, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (isEditMode)
                {
                    await jobService.UpdateJobAsync(job);
                }
                else
                {
                    job.Id = await jobService.CreateJobAsync(job);
                }

                TheJob = job;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the job: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}