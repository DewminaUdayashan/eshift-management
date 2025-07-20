using eshift_management.Models;
using eshift_management.Services.Interfaces;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace eshift_management.Forms
{
    public partial class ForgotPasswordForm : MaterialForm
    {
        private readonly IAuthService _authService;
        private UserModel _userPendingReset;

        public ForgotPasswordForm(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
            // Set initial view
            panelEnterEmail.Visible = true;
            panelVerifyOtp.Visible = false;
            panelResetPassword.Visible = false;
        }

        private async void buttonContinue_Click(object sender, EventArgs e)
        {
            var email = materialTextBoxEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email address.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (isSuccess, errorMessage, user) = await _authService.RequestPasswordResetAsync(email);

            if (isSuccess)
            {
                _userPendingReset = user;
                panelEnterEmail.Visible = false;
                panelVerifyOtp.Visible = true;
            }
            else
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonVerifyOtp_Click(object sender, EventArgs e)
        {
            if (_userPendingReset == null) return;

            if (textBoxOtp.Text == _userPendingReset.temporaryOTP)
            {
                panelVerifyOtp.Visible = false;
                panelResetPassword.Visible = true;
            }
            else
            {
                MessageBox.Show("The OTP you entered is incorrect. Please try again.", "Invalid OTP", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void buttonResetPassword_Click(object sender, EventArgs e)
        {
            var newPassword = materialTextBoxNewPassword.Text;
            var confirmPassword = materialTextBoxConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("The passwords do not match. Please try again.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var (isSuccess, errorMessage) = await _authService.UpdatePasswordAsync(_userPendingReset.Id ?? 0, newPassword);

            if (isSuccess)
            {
                MessageBox.Show("Your password has been successfully reset. You can now log in with your new password.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(errorMessage ?? "An unexpected error occurred. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBackToLogin_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
