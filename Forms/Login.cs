using eshift_management.Models;
using FluentValidation;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Reflection;

namespace eshift_management
{
    public partial class Login : MaterialForm
    {
        private readonly LoginValidator _validator;
        private UserType _selectedUserType = UserType.None;

        public Login()
        {
            InitializeComponent();
            _validator = new LoginValidator();

            // Disable the maximize button and resizing
            this.MaximizeBox = false;

            // Initialize MaterialSkin
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);

            // Set font types for labels
            labelSignIn.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            labelEmail.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;
            labelPassword.FontType = MaterialSkin.MaterialSkinManager.fontType.Body1;

            // Initialize Error Labels
            InitializeErrorLabels();

            // Initialize user type buttons
            InitializeUserTypeButtons();
        }

        private void InitializeErrorLabels()
        {
            // Set the ForeColor for standard Labels. This will not be overridden.
            labelEmailError.ForeColor = Color.Red;
            labelPasswordError.ForeColor = Color.Red;
            labelUserTypeError.ForeColor = Color.Red;

            // Set a consistent font for errors
            var errorFont = new Font("Roboto", 8, FontStyle.Regular, GraphicsUnit.Point);
            labelEmailError.Font = errorFont;
            labelPasswordError.Font = errorFont;
            labelUserTypeError.Font = errorFont;

            // Hide all error labels initially
            ClearErrorStyling();
        }

        private void InitializeUserTypeButtons()
        {
            // Set initial state - neither selected
            SelectUserType(UserType.None);
        }

        private void MaterialButtonCustomer_Click(object sender, EventArgs e)
        {
            SelectUserType(UserType.Customer);
        }

        private void MaterialButtonCompany_Click(object sender, EventArgs e)
        {
            SelectUserType(UserType.Company);
        }

        private void SelectUserType(UserType userType)
        {
            _selectedUserType = userType;

            // Reset both buttons to outlined
            materialButtonCustomer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            materialButtonCompany.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            materialButtonCustomer.HighEmphasis = false;
            materialButtonCompany.HighEmphasis = false;

            // Set selected button style to contained
            if (userType == UserType.Customer)
            {
                materialButtonCustomer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
                materialButtonCustomer.HighEmphasis = true;
            }
            else if (userType == UserType.Company)
            {
                materialButtonCompany.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
                materialButtonCompany.HighEmphasis = true;
            }

            // If a user type is selected, hide the user type error
            labelUserTypeError.Visible = false;

            // Refresh the buttons to apply style changes
            materialButtonCustomer.Refresh();
            materialButtonCompany.Refresh();
        }

        private void MaterialButtonSignIn_Click(object sender, EventArgs e)
        {
            // Clear any previous error styling
            ClearErrorStyling();

            // Create login model
            var loginModel = new LoginModel
            {
                Email = materialTextBoxEmail.Text.Trim(),
                Password = materialTextBoxPassword.Text,
                UserType = _selectedUserType
            };

            // Validate the model
            var validationResult = _validator.Validate(loginModel);

            if (!validationResult.IsValid)
            {
                // Show validation errors below the respective fields
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

            // If validation passes, proceed with login
            PerformLogin(loginModel);
        }

        private void PerformLogin(LoginModel loginModel)
        {
            try
            {
                // TODO: Implement actual login logic here
                var userTypeText = loginModel.UserType == UserType.Customer ? "Customer" : "Company";
                MessageBox.Show($"Login successful!\nUser Type: {userTypeText}\nEmail: {loginModel.Email}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
               var dashboard = new AdminDashboard();
                dashboard.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearErrorStyling()
        {
            // Hide error labels and clear their text
            labelEmailError.Visible = false;
            labelPasswordError.Visible = false;
            labelUserTypeError.Visible = false;
        }

        private void materialButtonRegister_Click(object sender, EventArgs e)
        {
            // TODO: Navigate to registration form
            MessageBox.Show("Registration form will be implemented here.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Add Enter key support for login
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