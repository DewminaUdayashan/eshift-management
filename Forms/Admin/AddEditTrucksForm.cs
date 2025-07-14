using eshift_management.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management
{
    public partial class AddEditTruckForm : MaterialForm
    {
        private readonly Truck currentTruck;
        private readonly bool isEditMode;

        public Truck TheTruck { get; private set; }

        public AddEditTruckForm(Truck truckToEdit = null)
        {
            InitializeComponent();

            currentTruck = truckToEdit;
            isEditMode = (currentTruck != null);

            InitializeErrorLabels();
            SetupForm();
        }

        private void InitializeErrorLabels()
        {
            labelModelError.ForeColor = Color.Red;
            labelModelError.Font = new Font("Roboto", 8);
            labelModelError.Visible = false;

            labelLicensePlateError.ForeColor = Color.Red;
            labelLicensePlateError.Font = new Font("Roboto", 8);
            labelLicensePlateError.Visible = false;
        }

        private void ClearErrorLabels()
        {
            labelModelError.Visible = false;
            labelLicensePlateError.Visible = false;
        }

        private void SetupForm()
        {
            if (isEditMode)
            {
                this.Text = "Edit Truck";
                textBoxModel.Text = currentTruck.Model;
                textBoxLicensePlate.Text = currentTruck.LicensePlate;
            }
            else
            {
                this.Text = "Add New Truck";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ClearErrorLabels();

            var truck = new Truck
            {
                Id = isEditMode ? currentTruck.Id : 0,
                Model = textBoxModel.Text.Trim(),
                LicensePlate = textBoxLicensePlate.Text.Trim(),
                // Set status automatically: new trucks are 'Available', edited trucks keep their existing status.
                Status = isEditMode ? currentTruck.Status : ResourceStatus.Available
            };

            var validator = new TruckValidator();
            var validationResult = validator.Validate(truck);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    switch (error.PropertyName)
                    {
                        case nameof(Truck.Model):
                            labelModelError.Text = error.ErrorMessage;
                            labelModelError.Visible = true;
                            break;
                        case nameof(Truck.LicensePlate):
                            labelLicensePlateError.Text = error.ErrorMessage;
                            labelLicensePlateError.Visible = true;
                            break;
                    }
                }
                return;
            }

            TheTruck = truck;
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