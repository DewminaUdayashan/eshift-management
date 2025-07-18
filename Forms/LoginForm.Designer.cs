namespace eshift_management
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxLogo = new PictureBox();
            labelSignIn = new MaterialSkin.Controls.MaterialLabel();
            materialButtonCustomer = new MaterialSkin.Controls.MaterialButton();
            materialButtonCompany = new MaterialSkin.Controls.MaterialButton();
            materialTextBoxEmail = new MaterialSkin.Controls.MaterialTextBox();
            materialTextBoxPassword = new MaterialSkin.Controls.MaterialTextBox();
            labelEmail = new MaterialSkin.Controls.MaterialLabel();
            labelPassword = new MaterialSkin.Controls.MaterialLabel();
            materialButtonSignIn = new MaterialSkin.Controls.MaterialButton();
            labelEmailError = new Label();
            labelPasswordError = new Label();
            labelUserTypeError = new Label();
            materialButtonRegister = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = Properties.Resources.e_shift_logo;
            pictureBoxLogo.Location = new Point(176, 40);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(100, 80);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // labelSignIn
            // 
            labelSignIn.AutoSize = true;
            labelSignIn.Depth = 0;
            labelSignIn.Font = new Font("Roboto", 24F, FontStyle.Bold, GraphicsUnit.Pixel);
            labelSignIn.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            labelSignIn.Location = new Point(180, 135);
            labelSignIn.MouseState = MaterialSkin.MouseState.HOVER;
            labelSignIn.Name = "labelSignIn";
            labelSignIn.Size = new Size(73, 29);
            labelSignIn.TabIndex = 1;
            labelSignIn.Text = "Sign In";
            // 
            // materialButtonCustomer
            // 
            materialButtonCustomer.AutoSize = false;
            materialButtonCustomer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButtonCustomer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButtonCustomer.Depth = 0;
            materialButtonCustomer.HighEmphasis = true; // Selected by default
            materialButtonCustomer.Icon = null;
            materialButtonCustomer.Location = new Point(115, 190);
            materialButtonCustomer.Margin = new Padding(0);
            materialButtonCustomer.MouseState = MaterialSkin.MouseState.HOVER;
            materialButtonCustomer.Name = "materialButtonCustomer";
            materialButtonCustomer.NoAccentTextColor = Color.Empty;
            materialButtonCustomer.Size = new Size(110, 36);
            materialButtonCustomer.TabIndex = 2;
            materialButtonCustomer.Text = "Customer";
            materialButtonCustomer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained; // Selected by default
            materialButtonCustomer.UseAccentColor = false;
            materialButtonCustomer.UseVisualStyleBackColor = true;
            materialButtonCustomer.Click += MaterialButtonCustomer_Click;
            // 
            // materialButtonCompany
            // 
            materialButtonCompany.AutoSize = false;
            materialButtonCompany.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButtonCompany.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButtonCompany.Depth = 0;
            materialButtonCompany.HighEmphasis = false; // Not selected by default
            materialButtonCompany.Icon = null;
            materialButtonCompany.Location = new Point(225, 190);
            materialButtonCompany.Margin = new Padding(0);
            materialButtonCompany.MouseState = MaterialSkin.MouseState.HOVER;
            materialButtonCompany.Name = "materialButtonCompany";
            materialButtonCompany.NoAccentTextColor = Color.Empty;
            materialButtonCompany.Size = new Size(110, 36);
            materialButtonCompany.TabIndex = 3;
            materialButtonCompany.Text = "Company";
            materialButtonCompany.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined; // Not selected by default
            materialButtonCompany.UseAccentColor = false;
            materialButtonCompany.UseVisualStyleBackColor = true;
            materialButtonCompany.Click += MaterialButtonCompany_Click;
            // 
            // materialTextBoxEmail
            // 
            materialTextBoxEmail.AnimateReadOnly = false;
            materialTextBoxEmail.BorderStyle = BorderStyle.None;
            materialTextBoxEmail.Depth = 0;
            materialTextBoxEmail.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBoxEmail.Hint = "Enter your email";
            materialTextBoxEmail.LeadingIcon = null;
            materialTextBoxEmail.Location = new Point(115, 270);
            materialTextBoxEmail.MaxLength = 50;
            materialTextBoxEmail.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBoxEmail.Multiline = false;
            materialTextBoxEmail.Name = "materialTextBoxEmail";
            materialTextBoxEmail.Size = new Size(220, 50);
            materialTextBoxEmail.TabIndex = 4;
            materialTextBoxEmail.Text = "";
            materialTextBoxEmail.TrailingIcon = null;
            // 
            // materialTextBoxPassword
            // 
            materialTextBoxPassword.AnimateReadOnly = false;
            materialTextBoxPassword.BorderStyle = BorderStyle.None;
            materialTextBoxPassword.Depth = 0;
            materialTextBoxPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialTextBoxPassword.Hint = "Enter your password";
            materialTextBoxPassword.LeadingIcon = null;
            materialTextBoxPassword.Location = new Point(115, 350);
            materialTextBoxPassword.MaxLength = 50;
            materialTextBoxPassword.MouseState = MaterialSkin.MouseState.OUT;
            materialTextBoxPassword.Multiline = false;
            materialTextBoxPassword.Name = "materialTextBoxPassword";
            materialTextBoxPassword.Password = true;
            materialTextBoxPassword.Size = new Size(220, 50);
            materialTextBoxPassword.TabIndex = 5;
            materialTextBoxPassword.Text = "";
            materialTextBoxPassword.TrailingIcon = null;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Depth = 0;
            labelEmail.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelEmail.Location = new Point(50, 285);
            labelEmail.MouseState = MaterialSkin.MouseState.HOVER;
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(41, 19);
            labelEmail.TabIndex = 6;
            labelEmail.Text = "Email";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Depth = 0;
            labelPassword.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            labelPassword.Location = new Point(30, 365);
            labelPassword.MouseState = MaterialSkin.MouseState.HOVER;
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(71, 19);
            labelPassword.TabIndex = 7;
            labelPassword.Text = "Password";
            // 
            // materialButtonSignIn
            // 
            materialButtonSignIn.AutoSize = false;
            materialButtonSignIn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButtonSignIn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButtonSignIn.Depth = 0;
            materialButtonSignIn.HighEmphasis = true;
            materialButtonSignIn.Icon = null;
            materialButtonSignIn.Location = new Point(115, 440);
            materialButtonSignIn.Margin = new Padding(4, 6, 4, 6);
            materialButtonSignIn.MouseState = MaterialSkin.MouseState.HOVER;
            materialButtonSignIn.Name = "materialButtonSignIn";
            materialButtonSignIn.NoAccentTextColor = Color.Empty;
            materialButtonSignIn.Size = new Size(220, 40);
            materialButtonSignIn.TabIndex = 8;
            materialButtonSignIn.Text = "Sign In";
            materialButtonSignIn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButtonSignIn.UseAccentColor = false;
            materialButtonSignIn.UseVisualStyleBackColor = true;
            materialButtonSignIn.Click += MaterialButtonSignIn_Click;
            // 
            // labelEmailError
            // 
            labelEmailError.AutoSize = true;
            labelEmailError.Font = new Font("Segoe UI", 9F);
            labelEmailError.Location = new Point(115, 323);
            labelEmailError.Name = "labelEmailError";
            labelEmailError.Size = new Size(64, 15);
            labelEmailError.TabIndex = 10;
            labelEmailError.Text = "Email Error";
            // 
            // labelPasswordError
            // 
            labelPasswordError.AutoSize = true;
            labelPasswordError.Location = new Point(115, 403);
            labelPasswordError.Name = "labelPasswordError";
            labelPasswordError.Size = new Size(85, 15);
            labelPasswordError.TabIndex = 11;
            labelPasswordError.Text = "Password Error";
            // 
            // labelUserTypeError
            // 
            labelUserTypeError.AutoSize = true;
            labelUserTypeError.Location = new Point(115, 229);
            labelUserTypeError.Name = "labelUserTypeError";
            labelUserTypeError.Size = new Size(86, 15);
            labelUserTypeError.TabIndex = 12;
            labelUserTypeError.Text = "User Type Error";
            // 
            // materialButtonRegister
            // 
            materialButtonRegister.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButtonRegister.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButtonRegister.Depth = 0;
            materialButtonRegister.HighEmphasis = false;
            materialButtonRegister.Icon = null;
            materialButtonRegister.Location = new Point(84, 492);
            materialButtonRegister.Margin = new Padding(4, 6, 4, 6);
            materialButtonRegister.MouseState = MaterialSkin.MouseState.HOVER;
            materialButtonRegister.Name = "materialButtonRegister";
            materialButtonRegister.NoAccentTextColor = Color.Empty;
            materialButtonRegister.Size = new Size(268, 36);
            materialButtonRegister.TabIndex = 13;
            materialButtonRegister.Text = "Don't have an account? Sign Up";
            materialButtonRegister.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            materialButtonRegister.UseAccentColor = false;
            materialButtonRegister.UseVisualStyleBackColor = true;
            materialButtonRegister.Click += materialButtonRegister_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 560);
            Controls.Add(materialButtonRegister);
            Controls.Add(labelUserTypeError);
            Controls.Add(labelPasswordError);
            Controls.Add(labelEmailError);
            Controls.Add(materialButtonSignIn);
            Controls.Add(labelPassword);
            Controls.Add(labelEmail);
            Controls.Add(materialTextBoxPassword);
            Controls.Add(materialTextBoxEmail);
            Controls.Add(materialButtonCompany);
            Controls.Add(materialButtonCustomer);
            Controls.Add(labelSignIn);
            Controls.Add(pictureBoxLogo);
            FormStyle = FormStyles.ActionBar_None;
            Name = "Login";
            Padding = new Padding(3, 24, 3, 3);
            RightToLeft = RightToLeft.No;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxLogo;
        private MaterialSkin.Controls.MaterialLabel labelSignIn;
        private MaterialSkin.Controls.MaterialButton materialButtonCustomer;
        private MaterialSkin.Controls.MaterialButton materialButtonCompany;
        private MaterialSkin.Controls.MaterialTextBox materialTextBoxEmail;
        private MaterialSkin.Controls.MaterialTextBox materialTextBoxPassword;
        private MaterialSkin.Controls.MaterialLabel labelEmail;
        private MaterialSkin.Controls.MaterialLabel labelPassword;
        private MaterialSkin.Controls.MaterialButton materialButtonSignIn;
        private Label labelEmailError;
        private Label labelPasswordError;
        private Label labelUserTypeError;
        private MaterialSkin.Controls.MaterialButton materialButtonRegister;
    }
}
