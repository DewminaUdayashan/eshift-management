using eshift_management.Forms;
using eshift_management.Models;
using MaterialSkin;
using MaterialSkin.Controls;
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
            materialButtonCompany.Type = (userType == UserType.Company) ? MaterialButton.MaterialButtonType.Contained : MaterialButton.MaterialButtonType.Outlined;
            labelUserTypeError.Visible = false;
        }

        private void MaterialButtonCustomer_Click(object sender, EventArgs e) => SelectUserType(UserType.Customer);
        private void MaterialButtonCompany_Click(object sender, EventArgs e) => SelectUserType(UserType.Company);

        private void MaterialButtonSignIn_Click(object sender, EventArgs e)
        {
            ClearErrorStyling();
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
            PerformLogin(loginModel);
        }

        private void PerformLogin(LoginModel loginModel)
        {
            try
            {
                if (loginModel.UserType == UserType.Company)
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