using eshift_management.Models;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management
{
    public partial class AddEditCustomerForm : MaterialForm
    {
        private readonly CustomerModel currentCustomer;
        private readonly bool isEditMode;
        private readonly List<Label> errorLabels;
        private static readonly Random random = new Random();

        public CustomerModel TheCustomer { get; private set; }

        public AddEditCustomerForm(CustomerModel customerToEdit = null)
        {
            InitializeComponent();

            // Register the form with the theme manager to be styled.
            // DO NOT set the theme or color scheme here, as it will reset the entire application's theme.
            var materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);

            currentCustomer = customerToEdit;
            isEditMode = (currentCustomer != null);

            // Group error labels for easy processing
            errorLabels = new List<Label>
            {
                labelFirstNameError, labelLastNameError, labelEmailError,
                labelPhoneError, labelAddressError, labelCityError, labelPostalCodeError
            };

            InitializeErrorLabels();
            SetupForm();
        }

        /// <summary>
        /// Sets the initial style (color, font) for all error labels.
        /// </summary>
        private void InitializeErrorLabels()
        {
            var errorFont = new Font("Roboto", 8, FontStyle.Regular, GraphicsUnit.Point);
            foreach (var label in errorLabels)
            {
                label.ForeColor = Color.Red;
                label.Font = errorFont;
                label.Visible = false; // Hide all labels initially
            }
        }

        /// <summary>
        /// Hides all error labels.
        /// </summary>
        private void ClearErrorLabels()
        {
            foreach (var label in errorLabels)
            {
                label.Visible = false;
            }
        }

        /// <summary>
        /// Configures the form for either "Add" or "Edit" mode.
        /// </summary>
        private void SetupForm()
        {
            if (isEditMode)
            {
                this.Text = "Edit Customer";

                textBoxFirstName.Text = currentCustomer.FirstName;
                textBoxLastName.Text = currentCustomer.LastName;
                textBoxEmail.Text = currentCustomer.Email;
                textBoxPhone.Text = currentCustomer.Phone;
                textBoxAddress.Text = currentCustomer.AddressLine;
                textBoxCity.Text = currentCustomer.City;
                textBoxPostalCode.Text = currentCustomer.PostalCode;

                textBoxEmail.Enabled = false;
            }
            else
            {
                this.Text = "Add New Customer";
            }
        }

        /// <summary>
        /// Handles the Save button click event.
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            ClearErrorLabels();

            var customer = new CustomerModel
            {
                Id = isEditMode ? currentCustomer.Id : null,
                UserId = isEditMode ? currentCustomer.UserId : 0,
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                AddressLine = textBoxAddress.Text.Trim(),
                City = textBoxCity.Text.Trim(),
                PostalCode = textBoxPostalCode.Text.Trim(),
            };

            var validator = new CustomerValidator();
            var validationResult = validator.Validate(customer);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    switch (error.PropertyName)
                    {
                        case nameof(CustomerModel.FirstName):
                            labelFirstNameError.Text = error.ErrorMessage;
                            labelFirstNameError.Visible = true;
                            break;
                        case nameof(CustomerModel.LastName):
                            labelLastNameError.Text = error.ErrorMessage;
                            labelLastNameError.Visible = true;
                            break;
                        case nameof(CustomerModel.Email):
                            labelEmailError.Text = error.ErrorMessage;
                            labelEmailError.Visible = true;
                            break;
                        case nameof(CustomerModel.Phone):
                            labelPhoneError.Text = error.ErrorMessage;
                            labelPhoneError.Visible = true;
                            break;
                        case nameof(CustomerModel.AddressLine):
                            labelAddressError.Text = error.ErrorMessage;
                            labelAddressError.Visible = true;
                            break;
                        case nameof(CustomerModel.City):
                            labelCityError.Text = error.ErrorMessage;
                            labelCityError.Visible = true;
                            break;
                        case nameof(CustomerModel.PostalCode):
                            labelPostalCodeError.Text = error.ErrorMessage;
                            labelPostalCodeError.Visible = true;
                            break;
                    }
                }
                return;
            }

            TheCustomer = customer;
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