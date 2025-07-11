using eshift_management.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management.Panes
{
    public partial class CustomerProfilePane : UserControl
    {
        // In a real app, this would be the actual logged-in user
        private CustomerModel loggedInCustomer;
        private readonly List<Label> errorLabels;

        public CustomerProfilePane()
        {
            InitializeComponent();

            errorLabels = new List<Label>
            {
                labelFirstNameError, labelLastNameError, labelEmailError,
                labelPhoneError, labelAddressError, labelCityError, labelPostalCodeError
            };

            InitializeErrorLabels();
            LoadProfileData();
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

        private void LoadProfileData()
        {
            // This data would be fetched from your database based on the logged-in user's ID
            loggedInCustomer = new CustomerModel
            {
                UserId = 0,
                FirstName = "John",
                LastName = "Smith",
                Email = "john.s@example.com",
                Phone = "077-1234567",
                AddressLine = "123 Galle Rd",
                City = "Panadura",
                PostalCode = "12500"
            };

            // Populate the form fields
            textBoxFirstName.Text = loggedInCustomer.FirstName;
            textBoxLastName.Text = loggedInCustomer.LastName;
            textBoxEmail.Text = loggedInCustomer.Email;
            textBoxPhone.Text = loggedInCustomer.Phone;
            textBoxAddress.Text = loggedInCustomer.AddressLine;
            textBoxCity.Text = loggedInCustomer.City;
            textBoxPostalCode.Text = loggedInCustomer.PostalCode;

            // Make the email field read-only as it should not be changed
            textBoxEmail.Enabled = false;
        }

        private void ClearErrorLabels()
        {
            foreach (var label in errorLabels)
            {
                label.Visible = false;
            }
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            ClearErrorLabels();

            // Create a temporary model for validation
            var updatedCustomer = new CustomerModel
            {
                Id = loggedInCustomer.Id,
                UserId = 0,
                Email = loggedInCustomer.Email, // Email doesn't change
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                AddressLine = textBoxAddress.Text.Trim(),
                City = textBoxCity.Text.Trim(),
                PostalCode = textBoxPostalCode.Text.Trim(),
            };

            var validator = new CustomerValidator();
            var validationResult = validator.Validate(updatedCustomer);

            if (!validationResult.IsValid)
            {
                // Show errors inline
                foreach (var error in validationResult.Errors)
                {
                    switch (error.PropertyName)
                    {
                        case nameof(CustomerModel.FirstName):
                            labelFirstNameError.Text = error.ErrorMessage;
                            labelFirstNameError.Visible = true;
                            break;
                        // Add cases for other fields...
                        case nameof(CustomerModel.LastName):
                            labelLastNameError.Text = error.ErrorMessage;
                            labelLastNameError.Visible = true;
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

            // If validation succeeds, update the main customer object
            // In a real app, you would save this to the database here
            loggedInCustomer.FirstName = updatedCustomer.FirstName;
            loggedInCustomer.LastName = updatedCustomer.LastName;
            loggedInCustomer.Phone = updatedCustomer.Phone;
            loggedInCustomer.AddressLine = updatedCustomer.AddressLine;
            loggedInCustomer.City = updatedCustomer.City;
            loggedInCustomer.PostalCode = updatedCustomer.PostalCode;

            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}