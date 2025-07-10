using eshift_management.Models;
using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management.Forms
{
    public partial class PlaceJobForm : MaterialForm
    {
        private readonly CustomerModel currentCustomer;
        private readonly Job currentJob;
        private readonly bool isEditMode;

        public Job TheJob { get; private set; }

        public PlaceJobForm(CustomerModel customer, Job jobToEdit = null)
        {
            InitializeComponent();

            currentCustomer = customer;
            currentJob = jobToEdit;
            isEditMode = (currentJob != null);

            SetupForm();
        }

        private void SetupForm()
        {
            // Populate load size options
            comboBoxLoadSize.DataSource = new string[] { "Small (1-2 rooms)", "Medium (3-4 rooms)", "Large (5+ rooms)" };

            if (isEditMode)
            {
                this.Text = "Edit Your Job";
                buttonSubmit.Text = "Update Job";

                // Populate fields from existing job
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
                // Populate and disable pickup address field
                textBoxPickupAddress.Text = $"{currentCustomer.AddressLine}, {currentCustomer.City}";
                textBoxPickupAddress.ReadOnly = true;
            }
            else
            {
                // Clear and enable for manual input
                textBoxPickupAddress.Text = "";
                textBoxPickupAddress.ReadOnly = false;
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var job = new Job
            {
                Id = isEditMode ? currentJob.Id : $"JOB-{DateTime.Now.Ticks}",
                Customer = currentCustomer,
                PickupLocation = textBoxPickupAddress.Text.Trim(),
                DropoffLocation = textBoxDropoffAddress.Text.Trim(),
                PickupDate = dateTimePickerPickup.Value,
                LoadSize = comboBoxLoadSize.SelectedItem.ToString(),
                Description = textBoxDescription.Text.Trim(),
                Status = JobStatus.Pending // New/edited jobs are always pending
            };

            var validator = new JobValidator();
            var validationResult = validator.Validate(job);

            if (!validationResult.IsValid)
            {
                var allErrors = string.Join("\n", validationResult.Errors.Select(err => err.ErrorMessage));
                MessageBox.Show(allErrors, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TheJob = job;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}