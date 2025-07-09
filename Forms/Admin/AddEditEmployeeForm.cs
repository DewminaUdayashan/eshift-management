using eshift_management.Models;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management
{
    public partial class AddEditEmployeeForm : MaterialForm
    {
        private readonly Employee currentEmployee;
        private readonly bool isEditMode;
        private readonly List<Label> errorLabels;

        public Employee TheEmployee { get; private set; }

        public AddEditEmployeeForm(Employee employeeToEdit = null)
        {
            InitializeComponent();

            currentEmployee = employeeToEdit;
            isEditMode = (currentEmployee != null);

            errorLabels = new List<Label>
            {
                labelFirstNameError, labelLastNameError, labelContactError, labelLicenseError
            };

            InitializeErrorLabels();
            SetupForm();
        }

        private void InitializeErrorLabels()
        {
            var errorFont = new Font("Roboto", 8);
            foreach (var label in errorLabels)
            {
                label.ForeColor = Color.Red;
                label.Font = errorFont;
                label.Visible = false;
            }
        }

        private void ClearErrorLabels()
        {
            foreach (var label in errorLabels)
            {
                label.Visible = false;
            }
        }

        private void SetupForm()
        {
            comboBoxPosition.DataSource = Enum.GetValues(typeof(EmployeePosition));

            if (isEditMode)
            {
                this.Text = "Edit Employee";
                textBoxFirstName.Text = currentEmployee.FirstName;
                textBoxLastName.Text = currentEmployee.LastName;
                comboBoxPosition.SelectedItem = currentEmployee.Position;
                textBoxContact.Text = currentEmployee.ContactNumber;
                textBoxLicense.Text = currentEmployee.LicenseNumber;
            }
            else
            {
                this.Text = "Add New Employee";
            }

            // Set the initial state of the license field
            UpdateLicenseFieldState();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            ClearErrorLabels();

            var employee = new Employee
            {
                Id = isEditMode ? currentEmployee.Id : $"EMP-{DateTime.Now.Ticks}",
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Position = (EmployeePosition)comboBoxPosition.SelectedItem,
                ContactNumber = textBoxContact.Text.Trim(),
                LicenseNumber = (EmployeePosition)comboBoxPosition.SelectedItem == EmployeePosition.Driver ? textBoxLicense.Text.Trim() : "N/A",
                Status = isEditMode ? currentEmployee.Status : ResourceStatus.Available
            };

            var validator = new EmployeeValidator();
            var validationResult = validator.Validate(employee);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    switch (error.PropertyName)
                    {
                        case nameof(Employee.FirstName):
                            labelFirstNameError.Text = error.ErrorMessage;
                            labelFirstNameError.Visible = true;
                            break;
                        case nameof(Employee.LastName):
                            labelLastNameError.Text = error.ErrorMessage;
                            labelLastNameError.Visible = true;
                            break;
                        case nameof(Employee.ContactNumber):
                            labelContactError.Text = error.ErrorMessage;
                            labelContactError.Visible = true;
                            break;
                        case nameof(Employee.LicenseNumber):
                            labelLicenseError.Text = error.ErrorMessage;
                            labelLicenseError.Visible = true;
                            break;
                    }
                }
                return;
            }

            TheEmployee = employee;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void comboBoxPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLicenseFieldState();
        }

        /// <summary>
        /// Updates the state of the License Number field based on the selected position.
        /// </summary>
        private void UpdateLicenseFieldState()
        {
            bool isDriver = (EmployeePosition)comboBoxPosition.SelectedItem == EmployeePosition.Driver;

            // Enable the field for Drivers, disable it for Assistants
            textBoxLicense.Enabled = isDriver;

            // If the employee is not a driver, clear the license field.
            if (!isDriver)
            {
                textBoxLicense.Clear();
            }

            // Always hide the error when changing state
            labelLicenseError.Visible = false;
        }
    }
}