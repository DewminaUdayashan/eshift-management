using eshift_management.Core.Services;
using eshift_management.Forms;
using eshift_management.Models;
using eshift_management.Repositories.Services;
using eshift_management.Services.Implementations;
using eshift_management.Services.Interfaces;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eshift_management
{
    public partial class LoginForm : MaterialForm
    {
        private readonly LoginValidator _validator;
        private UserType _selectedUserType = UserType.Customer;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private UserModel _userPendingVerification;
        private int _cooldownSeconds;

        public LoginForm()
        {
            InitializeComponent();
            _validator = new LoginValidator();
            this.MaximizeBox = false;

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.Blue400, TextShade.WHITE);

            labelSignIn.FontType = MaterialSkinManager.fontType.H5;
            labelEmail.FontType = MaterialSkinManager.fontType.Body1;
            labelPassword.FontType = MaterialSkinManager.fontType.Body1;

            _userService = new UserService(new UserRepository());
            _customerService = new CustomerService(new CustomerRepository());
            _authService = new AuthService(_userService, _customerService, new EmailService());

            InitializeErrorLabels();
            InitializeUserTypeButtons();
        }

        private void InitializeErrorLabels()
        {
            labelEmailError.ForeColor = Color.Red;
            labelPasswordError.ForeColor = Color.Red;
            labelUserTypeError.ForeColor = Color.Red;
            var errorFont = new Font("Roboto", 8, FontStyle.Regular, GraphicsUnit.Point);
            labelEmailError.Font = errorFont;
            labelPasswordError.Font = errorFont;
            labelUserTypeError.Font = errorFont;
            ClearErrorStyling();
        }

        private void InitializeUserTypeButtons()
        {
            UpdateButtonStyles();
        }

        private void MaterialButtonCustomer_Click(object sender, EventArgs e)
        {
            _selectedUserType = UserType.Customer;
            UpdateButtonStyles();
        }

        private void MaterialButtonCompany_Click(object sender, EventArgs e)
        {
            _selectedUserType = UserType.Admin;
            UpdateButtonStyles();
        }

        /// <summary>
        /// Updates the visual style of the user type selection buttons.
        /// The selected button will be 'Contained' (filled), and the other 'Outlined'.
        /// </summary>
        private void UpdateButtonStyles()
        {
            if (_selectedUserType == UserType.Customer)
            {
                materialButtonCustomer.Type = MaterialButton.MaterialButtonType.Contained;
                materialButtonCustomer.HighEmphasis = true;
                materialButtonCompany.Type = MaterialButton.MaterialButtonType.Outlined;
                materialButtonCompany.HighEmphasis = false;
            }
            else
            {
                materialButtonCustomer.Type = MaterialButton.MaterialButtonType.Outlined;
                materialButtonCustomer.HighEmphasis = false;
                materialButtonCompany.Type = MaterialButton.MaterialButtonType.Contained;
                materialButtonCompany.HighEmphasis = true;
            }
        }

        private async void MaterialButtonSignIn_Click(object sender, EventArgs e)
        {
            materialButtonSignIn.Enabled = false;
            var originalText = materialButtonSignIn.Text;
            materialButtonSignIn.Text = "Signing in...";
            ClearErrorStyling();

            try
            {
                var loginModel = new LoginModel
                {
                    Email = materialTextBoxEmail.Text.Trim(),
                    Password = materialTextBoxPassword.Text,
                    UserType = _selectedUserType
                };
                var validationResult = _validator.Validate(loginModel);
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        switch (error.PropertyName)
                        {
                            case nameof(LoginModel.Email):
                                labelEmailError.Text = error.ErrorMessage;
                                labelEmailError.Visible = true;
                                break;
                            case nameof(LoginModel.Password):
                                labelPasswordError.Text = error.ErrorMessage;
                                labelPasswordError.Visible = true;
                                break;
                            case nameof(LoginModel.UserType):
                                labelUserTypeError.Text = error.ErrorMessage;
                                labelUserTypeError.Visible = true;
                                break;
                        }
                    }
                    return;
                }

                var (isSuccess, errorMessage, user) = await _authService.LoginAsync(loginModel.Email, loginModel.Password);

                if (!isSuccess || user == null)
                {
                    MessageBox.Show(errorMessage ?? "Account not found or invalid credentials.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!user.IsEmailVerified)
                {
                    _userPendingVerification = user;
                    ShowOtpVerificationView();
                    return;
                }

                if (loginModel.UserType != user.UserType)
                {
                    MessageBox.Show($"You are trying to log in as a {loginModel.UserType}, but this is a {user.UserType} account.", "Permission Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                PerformLogin(loginModel, user);
            }
            finally
            {
                materialButtonSignIn.Enabled = true;
                materialButtonSignIn.Text = originalText;
            }
        }

        private void PerformLogin(LoginModel loginModel, UserModel user)
        {
            try
            {
                if (loginModel.UserType == UserType.Admin)
                {
                    this.Hide();
                    new AdminDashboard().ShowDialog();
                    this.Close();
                }
                else if (loginModel.UserType == UserType.Customer)
                {
                    this.Hide();
                    new CustomerDashboard(user).ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Switches the view from login controls to OTP verification controls.
        /// </summary>
        private void ShowOtpVerificationView()
        {
            panelLogin.Visible = false;
            panelOtp.Visible = true;
            StartOtpCooldown();
        }

        /// <summary>
        /// Handles the click event for the OTP verification button.
        /// </summary>
        private async void buttonVerify_Click(object sender, EventArgs e)
        {
            if (_userPendingVerification == null) return;

            if (textBoxOtp.Text == _userPendingVerification.temporaryOTP)
            {
                _userPendingVerification.IsEmailVerified = true;
                await _userService.UpdateAsync(_userPendingVerification);
                MessageBox.Show("Email verified successfully! Logging you in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PerformLogin(new LoginModel { UserType = _userPendingVerification.UserType }, _userPendingVerification);
            }
            else
            {
                MessageBox.Show("Invalid OTP. Please try again.", "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Enables the Verify button when the OTP text box is not empty.
        /// </summary>
        private void textBoxOtp_TextChanged(object sender, EventArgs e)
        {
            buttonVerify.Enabled = !string.IsNullOrWhiteSpace(textBoxOtp.Text);
        }

        private void linkResendOtp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("A new OTP has been sent to your email.", "OTP Resent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            StartOtpCooldown();
        }

        private void StartOtpCooldown()
        {
            _cooldownSeconds = 30;
            linkResendOtp.Enabled = false;
            otpCooldownTimer.Start();
        }

        private void otpCooldownTimer_Tick(object sender, EventArgs e)
        {
            _cooldownSeconds--;
            linkResendOtp.Text = $"Resend OTP in ({_cooldownSeconds})";
            if (_cooldownSeconds <= 0)
            {
                otpCooldownTimer.Stop();
                linkResendOtp.Text = "Resend OTP";
                linkResendOtp.Enabled = true;
            }
        }

        private void ClearErrorStyling()
        {
            labelEmailError.Visible = false;
            labelPasswordError.Visible = false;
            labelUserTypeError.Visible = false;
        }

        private void materialButtonRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (var registerForm = new RegistrationForm())
            {
                var result = registerForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    this.Show();
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (panelLogin.Visible)
                {
                    MaterialButtonSignIn_Click(materialButtonSignIn, EventArgs.Empty);
                    return true;
                }
                if (panelOtp.Visible && buttonVerify.Enabled)
                {
                    buttonVerify_Click(buttonVerify, EventArgs.Empty);
                    return true;
                }
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}