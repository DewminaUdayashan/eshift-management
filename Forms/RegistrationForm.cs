using eshift_management.Models;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management.Forms
{
    public partial class RegistrationForm : MaterialForm
    {
        private const string TestOtp = "123456";
        private int cooldownSeconds;
        private List<Label> errorLabels;

        public RegistrationForm()
        {
            InitializeComponent();
            InitializeErrorLabels();
            pictureBoxLogo.Image = Properties.Resources.e_shift_logo;
        }

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

        private void ClearErrorLabels()
        {
            foreach (var label in errorLabels)
            {
                if (label != null) label.Visible = false;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            ClearErrorLabels();
            var model = new RegistrationModel
            {
                Id = Guid.NewGuid().ToString(),
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

            // In a real app, send OTP to email here
            MessageBox.Show("An OTP has been sent to your email.", "OTP Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StartOtpCooldown();
            tabControl.SelectedIndex = 1;
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            if (textBoxOtp.Text == TestOtp)
            {
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

        private void buttonBackToLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBoxOtp_TextChanged(object sender, EventArgs e)
        {
            buttonVerify.Enabled = !string.IsNullOrWhiteSpace(textBoxOtp.Text);
        }

        private void linkResendOtp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("A new OTP has been sent.", "OTP Resent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StartOtpCooldown();
        }

        private void StartOtpCooldown()
        {
            cooldownSeconds = 30;
            linkResendOtp.Enabled = false;
            otpCooldownTimer.Start();
        }

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

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure the timer is stopped when the form closes to prevent issues
            otpCooldownTimer.Stop();
        }
    }
}