using eshift_management.Core.Services;
using eshift_management.Models;
using eshift_management.Repositories.Services;
using eshift_management.Services.Implementations;
using eshift_management.Services.Interfaces;
using MaterialSkin.Controls;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management.Forms
{
    /// <summary>
    /// Represents the registration form that handles user input,
    /// validation, and email OTP verification for creating a new account.
    /// </summary>
    public partial class RegistrationForm : MaterialForm
    {
        private int cooldownSeconds;
        private List<Label> errorLabels;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private UserModel _registeredUser; // Store the user returned from registration


        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationForm"/> class.
        /// </summary>
        public RegistrationForm()
        {
            InitializeComponent();
            InitializeErrorLabels();
            pictureBoxLogo.Image = Properties.Resources.e_shift_logo;
            _userService = new UserService(new UserRepository());
            _customerService = new CustomerService(new CustomerRepository());
            _authService = new AuthService(_userService, _customerService, new EmailService());
        }

        /// <summary>
        /// Initializes and formats all error label controls.
        /// </summary>
        private void InitializeErrorLabels()
        {
            errorLabels = new List<Label>
            {
                labelFirstNameError, labelLastNameError, labelEmailError, labelPhoneError,
                labelAddressError, labelCityError, labelPostalCodeError, labelPasswordError, labelConfirmPasswordError
            };

            var errorFont = new Font("Roboto", 8);
            foreach (var label in errorLabels)
            {
                if (label != null)
                {
                    label.ForeColor = Color.Red;
                    label.Font = errorFont;
                    label.Visible = false;
                }
            }
        }

        /// <summary>
        /// Clears all error messages from the error label controls.
        /// </summary>
        private void ClearErrorLabels()
        {
            foreach (var label in errorLabels)
            {
                if (label != null) label.Visible = false;
            }
        }

        /// <summary>
        /// Handles the click event for the "Next" button.
        /// Validates input and proceeds to OTP tab if valid.
        /// </summary>
        private async void buttonNext_Click(object sender, EventArgs e)
        {
            buttonNext.Enabled = false;
            var originalText = buttonNext.Text;
            buttonNext.Text = "Registering...";

            try
            {
                ClearErrorLabels();

                var model = new RegistrationModel
                {
                    FirstName = textBoxFirstName.Text,
                    LastName = textBoxLastName.Text,
                    Email = textBoxEmail.Text,
                    Phone = textBoxPhone.Text,
                    AddressLine = textBoxAddress.Text,
                    City = textBoxCity.Text,
                    PostalCode = textBoxPostalCode.Text,
                    Password = textBoxPassword.Text,
                    ConfirmPassword = textBoxConfirmPassword.Text
                };

                var validator = new RegistrationValidator();
                var validationResult = validator.Validate(model);

                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        switch (error.PropertyName)
                        {
                            case nameof(model.FirstName): labelFirstNameError.Text = error.ErrorMessage; labelFirstNameError.Visible = true; break;
                            case nameof(model.LastName): labelLastNameError.Text = error.ErrorMessage; labelLastNameError.Visible = true; break;
                            case nameof(model.Email): labelEmailError.Text = error.ErrorMessage; labelEmailError.Visible = true; break;
                            case nameof(model.Phone): labelPhoneError.Text = error.ErrorMessage; labelPhoneError.Visible = true; break;
                            case nameof(model.AddressLine): labelAddressError.Text = error.ErrorMessage; labelAddressError.Visible = true; break;
                            case nameof(model.City): labelCityError.Text = error.ErrorMessage; labelCityError.Visible = true; break;
                            case nameof(model.PostalCode): labelPostalCodeError.Text = error.ErrorMessage; labelPostalCodeError.Visible = true; break;
                            case nameof(model.Password): labelPasswordError.Text = error.ErrorMessage; labelPasswordError.Visible = true; break;
                            case nameof(model.ConfirmPassword): labelConfirmPasswordError.Text = error.ErrorMessage; labelConfirmPasswordError.Visible = true; break;
                        }
                    }
                    return;
                }

                var customer = new CustomerModel
                {
                    FirstName = textBoxFirstName.Text,
                    LastName = textBoxLastName.Text,
                    Email = textBoxEmail.Text,
                    Phone = textBoxPhone.Text,
                    AddressLine = textBoxAddress.Text,
                    City = textBoxCity.Text,
                    PostalCode = textBoxPostalCode.Text
                };

                var user = new UserModel
                {
                    Email = textBoxEmail.Text,
                    UserType = "Customer",
                    IsEmailVerified = false,
                    PasswordHash = textBoxPassword.Text // Will be hashed in service
                };

                var (isSuccess, errorMessage, registeredUser) = await _authService.RegisterAsync(user, customer);
                if (!isSuccess)
                {
                    MessageBox.Show(errorMessage ?? "Registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _registeredUser = registeredUser!;
                MessageBox.Show("An OTP has been sent to your email.", "OTP Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartOtpCooldown();
                tabControl.SelectedIndex = 1;
            }
            finally
            {
                buttonNext.Enabled = true;
                buttonNext.Text = originalText;
            }
        }


        /// <summary>
        /// Handles the OTP verification logic.
        /// If OTP matches, transitions to the dashboard.
        /// </summary>
        private void buttonVerify_Click(object sender, EventArgs e)
        {
            if (textBoxOtp.Text == _registeredUser.temporaryOTP)
            {
                _registeredUser.IsEmailVerified = true; // Mark user as verified
                _userService.UpdateAsync(_registeredUser);
                MessageBox.Show("Registration successful! You will now be taken to your dashboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Hide();
                new CustomerDashboard().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid OTP. Please try again.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Navigates back to the login form without completing registration.
        /// </summary>
        private void buttonBackToLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Enables the "Verify" button only when the OTP field is not empty.
        /// </summary>
        private void textBoxOtp_TextChanged(object sender, EventArgs e)
        {
            buttonVerify.Enabled = !string.IsNullOrWhiteSpace(textBoxOtp.Text);
        }

        /// <summary>
        /// Simulates resending the OTP and restarts the cooldown timer.
        /// </summary>
        private void linkResendOtp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("A new OTP has been sent.", "OTP Resent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StartOtpCooldown();
        }

        /// <summary>
        /// Starts the cooldown timer preventing OTP resend for a set duration.
        /// </summary>
        private void StartOtpCooldown()
        {
            cooldownSeconds = 30;
            linkResendOtp.Enabled = false;
            otpCooldownTimer.Start();
        }

        /// <summary>
        /// Handles cooldown timer ticks and updates UI.
        /// </summary>
        private void otpCooldownTimer_Tick(object sender, EventArgs e)
        {
            cooldownSeconds--;
            linkResendOtp.Text = $"Resend OTP in ({cooldownSeconds})";
            if (cooldownSeconds <= 0)
            {
                otpCooldownTimer.Stop();
                linkResendOtp.Text = "Resend OTP";
                linkResendOtp.Enabled = true;
            }
        }

        /// <summary>
        /// Handles form closing event by stopping the OTP timer.
        /// </summary>
        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            otpCooldownTimer.Stop();
        }
    }
}
