using eshift_management.Models;
using eshift_management.Repositories.Services;
using eshift_management.Services.Implementations;
using eshift_management.Services.Interfaces;

namespace eshift_management.Panes
{
    /// <summary>
    /// Displays and allows editing of a customer's profile.
    /// </summary>
    public partial class CustomerProfilePane : UserControl
    {
        private UserModel user;
        private CustomerModel? loggedInCustomer;
        private CustomerModel? originalCustomer;
        private readonly List<Label> errorLabels;
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerProfilePane"/> class.
        /// </summary>
        public CustomerProfilePane(UserModel user)
        {
            InitializeComponent();
            this.user = user;
            _customerService = new CustomerService(new CustomerRepository());

            errorLabels = new List<Label>
            {
                labelFirstNameError, labelLastNameError, labelEmailError,
                labelPhoneError, labelAddressError, labelCityError, labelPostalCodeError
            };

            InitializeErrorLabels();
            HookChangeEvents();
            LoadProfileDataAsync();
        }

        private void InitializeErrorLabels()
        {
            var errorFont = new Font("Roboto", 8, FontStyle.Regular, GraphicsUnit.Point);
            foreach (var label in errorLabels)
            {
                label.ForeColor = Color.Red;
                label.Font = errorFont;
                label.AutoSize = true;
                label.Visible = false;
            }
        }

        private void HookChangeEvents()
        {
            textBoxFirstName.TextChanged += (_, _) => CheckForChanges();
            textBoxLastName.TextChanged += (_, _) => CheckForChanges();
            textBoxPhone.TextChanged += (_, _) => CheckForChanges();
            textBoxAddress.TextChanged += (_, _) => CheckForChanges();
            textBoxCity.TextChanged += (_, _) => CheckForChanges();
            textBoxPostalCode.TextChanged += (_, _) => CheckForChanges();
        }

        private async void LoadProfileDataAsync()
        {
            loggedInCustomer = await _customerService.GetByIdAsync(user.Id ?? 0);
            if (loggedInCustomer == null)
            {
                MessageBox.Show("Customer data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            originalCustomer = new CustomerModel
            {
                FirstName = loggedInCustomer.FirstName,
                LastName = loggedInCustomer.LastName,
                Phone = loggedInCustomer.Phone,
                AddressLine = loggedInCustomer.AddressLine,
                City = loggedInCustomer.City,
                PostalCode = loggedInCustomer.PostalCode,
                Email = user.Email,
                UserId = loggedInCustomer.UserId
            };

            textBoxFirstName.Text = loggedInCustomer.FirstName;
            textBoxLastName.Text = loggedInCustomer.LastName;
            textBoxEmail.Text = user.Email;
            textBoxPhone.Text = loggedInCustomer.Phone;
            textBoxAddress.Text = loggedInCustomer.AddressLine;
            textBoxCity.Text = loggedInCustomer.City;
            textBoxPostalCode.Text = loggedInCustomer.PostalCode;

            textBoxEmail.Enabled = false;
            buttonSaveChanges.Enabled = false;
        }

        private void ClearErrorLabels()
        {
            foreach (var label in errorLabels)
                label.Visible = false;
        }

        private void CheckForChanges()
        {
            if (originalCustomer == null)
            {
                buttonSaveChanges.Enabled = false;
                return;
            }

            bool isChanged =
                textBoxFirstName.Text.Trim() != originalCustomer.FirstName ||
                textBoxLastName.Text.Trim() != originalCustomer.LastName ||
                textBoxPhone.Text.Trim() != originalCustomer.Phone ||
                textBoxAddress.Text.Trim() != originalCustomer.AddressLine ||
                textBoxCity.Text.Trim() != originalCustomer.City ||
                textBoxPostalCode.Text.Trim() != originalCustomer.PostalCode;

            buttonSaveChanges.Enabled = isChanged;
        }

        private async void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            ClearErrorLabels();

            var updatedCustomer = new CustomerModel
            {
                UserId = loggedInCustomer!.UserId,
                Email = user.Email,
                FirstName = textBoxFirstName.Text.Trim(),
                LastName = textBoxLastName.Text.Trim(),
                Phone = textBoxPhone.Text.Trim(),
                AddressLine = textBoxAddress.Text.Trim(),
                City = textBoxCity.Text.Trim(),
                PostalCode = textBoxPostalCode.Text.Trim()
            };

            var validator = new CustomerValidator();
            var validationResult = validator.Validate(updatedCustomer);

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

            try
            {
                await _customerService.UpdateAsync(updatedCustomer);

                loggedInCustomer = updatedCustomer;
                originalCustomer = new CustomerModel
                {
                    FirstName = updatedCustomer.FirstName,
                    LastName = updatedCustomer.LastName,
                    Phone = updatedCustomer.Phone,
                    AddressLine = updatedCustomer.AddressLine,
                    City = updatedCustomer.City,
                    PostalCode = updatedCustomer.PostalCode,
                    Email = updatedCustomer.Email,
                    UserId = updatedCustomer.UserId
                };

                buttonSaveChanges.Enabled = false;
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update profile.\n\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
