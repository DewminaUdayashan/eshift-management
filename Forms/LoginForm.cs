using eshift_management.Core.Services;
using eshift_management.Forms;
using eshift_management.Models;
using eshift_management.Repositories.Services;
using eshift_management.Services.Implementations;
using eshift_management.Services.Interfaces;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management
{
    public partial class LoginForm : MaterialForm
    {
        private readonly LoginValidator _validator;
        private UserType _selectedUserType = UserType.None;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;

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
            SelectUserType(UserType.None);
        }

        private void SelectUserType(UserType userType)
        {
            _selectedUserType = userType;
            materialButtonCustomer.Type = (userType == UserType.Customer) ? MaterialButton.MaterialButtonType.Contained : MaterialButton.MaterialButtonType.Outlined;
            materialButtonCompany.Type = (userType == UserType.Admin) ? MaterialButton.MaterialButtonType.Contained : MaterialButton.MaterialButtonType.Outlined;
            labelUserTypeError.Visible = false;
        }

        private void MaterialButtonCustomer_Click(object sender, EventArgs e) => SelectUserType(UserType.Customer);
        private void MaterialButtonCompany_Click(object sender, EventArgs e) => SelectUserType(UserType.Admin);

        private async void MaterialButtonSignIn_Click(object sender, EventArgs e)
        {
            materialButtonSignIn.Enabled = false;
            var originalText = materialButtonSignIn.Text;
            materialButtonSignIn.Text = "Sgining in...";
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
                var (isSuccess, errorMessage, user) = await _authService.LoginAsync(materialTextBoxEmail.Text, materialTextBoxPassword.Text);
                if (!isSuccess)
                {
                    MessageBox.Show(errorMessage ?? "Registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(user == null)
                {
                    MessageBox.Show("Account not found. Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (loginModel.UserType != user.UserType)
                {
                    MessageBox.Show($"You are trying to log in as a {loginModel.UserType}, but your account has no permission to access ${loginModel.UserType} content.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    new CustomerDashboard().ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // Hide the login form while the registration form is open
            this.Hide();
            using (var registerForm = new RegistrationForm())
            {
                var result = registerForm.ShowDialog();

                // If registration was successful, the registration form handles navigation
                // and this login form will just close.
                if (result == DialogResult.OK)
                {
                    this.Close();
                }
                else
                {
                    // If the user canceled registration, show the login form again.
                    this.Show();
                }
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                MaterialButtonSignIn_Click(materialButtonSignIn, EventArgs.Empty);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}