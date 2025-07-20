namespace eshift_management
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelSignIn = new MaterialSkin.Controls.MaterialLabel();
            this.materialButtonCustomer = new MaterialSkin.Controls.MaterialButton();
            this.materialButtonCompany = new MaterialSkin.Controls.MaterialButton();
            this.materialTextBoxEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.materialTextBoxPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.labelEmail = new MaterialSkin.Controls.MaterialLabel();
            this.labelPassword = new MaterialSkin.Controls.MaterialLabel();
            this.materialButtonSignIn = new MaterialSkin.Controls.MaterialButton();
            this.labelEmailError = new System.Windows.Forms.Label();
            this.labelPasswordError = new System.Windows.Forms.Label();
            this.labelUserTypeError = new System.Windows.Forms.Label();
            this.materialButtonRegister = new MaterialSkin.Controls.MaterialButton();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.linkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.panelOtp = new System.Windows.Forms.Panel();
            this.linkResendOtp = new System.Windows.Forms.LinkLabel();
            this.buttonVerify = new MaterialSkin.Controls.MaterialButton();
            this.textBoxOtp = new MaterialSkin.Controls.MaterialTextBox();
            this.labelOtpInfo = new MaterialSkin.Controls.MaterialLabel();
            this.otpCooldownTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelLogin.SuspendLayout();
            this.panelOtp.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::eshift_management.Properties.Resources.e_shift_logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(176, 40);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(100, 80);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelSignIn
            // 
            this.labelSignIn.AutoSize = true;
            this.labelSignIn.Depth = 0;
            this.labelSignIn.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelSignIn.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.labelSignIn.Location = new System.Drawing.Point(180, 135);
            this.labelSignIn.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelSignIn.Name = "labelSignIn";
            this.labelSignIn.Size = new System.Drawing.Size(73, 29);
            this.labelSignIn.TabIndex = 1;
            this.labelSignIn.Text = "Sign In";
            // 
            // materialButtonCustomer
            // 
            this.materialButtonCustomer.AutoSize = false;
            this.materialButtonCustomer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonCustomer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonCustomer.Depth = 0;
            this.materialButtonCustomer.HighEmphasis = true;
            this.materialButtonCustomer.Icon = null;
            this.materialButtonCustomer.Location = new System.Drawing.Point(115, 190);
            this.materialButtonCustomer.Margin = new System.Windows.Forms.Padding(0);
            this.materialButtonCustomer.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonCustomer.Name = "materialButtonCustomer";
            this.materialButtonCustomer.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonCustomer.Size = new System.Drawing.Size(110, 36);
            this.materialButtonCustomer.TabIndex = 2;
            this.materialButtonCustomer.Text = "Customer";
            this.materialButtonCustomer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonCustomer.UseAccentColor = false;
            this.materialButtonCustomer.UseVisualStyleBackColor = true;
            this.materialButtonCustomer.Click += new System.EventHandler(this.MaterialButtonCustomer_Click);
            // 
            // materialButtonCompany
            // 
            this.materialButtonCompany.AutoSize = false;
            this.materialButtonCompany.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonCompany.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonCompany.Depth = 0;
            this.materialButtonCompany.HighEmphasis = false;
            this.materialButtonCompany.Icon = null;
            this.materialButtonCompany.Location = new System.Drawing.Point(225, 190);
            this.materialButtonCompany.Margin = new System.Windows.Forms.Padding(0);
            this.materialButtonCompany.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonCompany.Name = "materialButtonCompany";
            this.materialButtonCompany.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonCompany.Size = new System.Drawing.Size(110, 36);
            this.materialButtonCompany.TabIndex = 3;
            this.materialButtonCompany.Text = "Company";
            this.materialButtonCompany.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.materialButtonCompany.UseAccentColor = false;
            this.materialButtonCompany.UseVisualStyleBackColor = true;
            this.materialButtonCompany.Click += new System.EventHandler(this.MaterialButtonCompany_Click);
            // 
            // materialTextBoxEmail
            // 
            this.materialTextBoxEmail.AnimateReadOnly = false;
            this.materialTextBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBoxEmail.Depth = 0;
            this.materialTextBoxEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBoxEmail.Hint = "Enter your email";
            this.materialTextBoxEmail.LeadingIcon = null;
            this.materialTextBoxEmail.Location = new System.Drawing.Point(115, 270);
            this.materialTextBoxEmail.MaxLength = 50;
            this.materialTextBoxEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBoxEmail.Multiline = false;
            this.materialTextBoxEmail.Name = "materialTextBoxEmail";
            this.materialTextBoxEmail.Size = new System.Drawing.Size(220, 50);
            this.materialTextBoxEmail.TabIndex = 4;
            this.materialTextBoxEmail.Text = "";
            this.materialTextBoxEmail.TrailingIcon = null;
            // 
            // materialTextBoxPassword
            // 
            this.materialTextBoxPassword.AnimateReadOnly = false;
            this.materialTextBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBoxPassword.Depth = 0;
            this.materialTextBoxPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBoxPassword.Hint = "Enter your password";
            this.materialTextBoxPassword.LeadingIcon = null;
            this.materialTextBoxPassword.Location = new System.Drawing.Point(115, 350);
            this.materialTextBoxPassword.MaxLength = 50;
            this.materialTextBoxPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBoxPassword.Multiline = false;
            this.materialTextBoxPassword.Name = "materialTextBoxPassword";
            this.materialTextBoxPassword.Password = true;
            this.materialTextBoxPassword.Size = new System.Drawing.Size(220, 50);
            this.materialTextBoxPassword.TabIndex = 5;
            this.materialTextBoxPassword.Text = "";
            this.materialTextBoxPassword.TrailingIcon = null;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Depth = 0;
            this.labelEmail.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelEmail.Location = new System.Drawing.Point(50, 285);
            this.labelEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(41, 19);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "Email";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Depth = 0;
            this.labelPassword.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelPassword.Location = new System.Drawing.Point(30, 365);
            this.labelPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(71, 19);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Password";
            // 
            // materialButtonSignIn
            // 
            this.materialButtonSignIn.AutoSize = false;
            this.materialButtonSignIn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonSignIn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonSignIn.Depth = 0;
            this.materialButtonSignIn.HighEmphasis = true;
            this.materialButtonSignIn.Icon = null;
            this.materialButtonSignIn.Location = new System.Drawing.Point(115, 440);
            this.materialButtonSignIn.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonSignIn.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonSignIn.Name = "materialButtonSignIn";
            this.materialButtonSignIn.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonSignIn.Size = new System.Drawing.Size(220, 40);
            this.materialButtonSignIn.TabIndex = 8;
            this.materialButtonSignIn.Text = "Sign In";
            this.materialButtonSignIn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButtonSignIn.UseAccentColor = false;
            this.materialButtonSignIn.UseVisualStyleBackColor = true;
            this.materialButtonSignIn.Click += new System.EventHandler(this.MaterialButtonSignIn_Click);
            // 
            // labelEmailError
            // 
            this.labelEmailError.AutoSize = true;
            this.labelEmailError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelEmailError.Location = new System.Drawing.Point(115, 323);
            this.labelEmailError.Name = "labelEmailError";
            this.labelEmailError.Size = new System.Drawing.Size(64, 15);
            this.labelEmailError.TabIndex = 10;
            this.labelEmailError.Text = "Email Error";
            // 
            // labelPasswordError
            // 
            this.labelPasswordError.AutoSize = true;
            this.labelPasswordError.Location = new System.Drawing.Point(115, 403);
            this.labelPasswordError.Name = "labelPasswordError";
            this.labelPasswordError.Size = new System.Drawing.Size(85, 15);
            this.labelPasswordError.TabIndex = 11;
            this.labelPasswordError.Text = "Password Error";
            // 
            // labelUserTypeError
            // 
            this.labelUserTypeError.AutoSize = true;
            this.labelUserTypeError.Location = new System.Drawing.Point(115, 229);
            this.labelUserTypeError.Name = "labelUserTypeError";
            this.labelUserTypeError.Size = new System.Drawing.Size(86, 15);
            this.labelUserTypeError.TabIndex = 12;
            this.labelUserTypeError.Text = "User Type Error";
            // 
            // materialButtonRegister
            // 
            this.materialButtonRegister.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButtonRegister.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButtonRegister.Depth = 0;
            this.materialButtonRegister.HighEmphasis = false;
            this.materialButtonRegister.Icon = null;
            this.materialButtonRegister.Location = new System.Drawing.Point(84, 522);
            this.materialButtonRegister.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButtonRegister.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButtonRegister.Name = "materialButtonRegister";
            this.materialButtonRegister.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButtonRegister.Size = new System.Drawing.Size(268, 36);
            this.materialButtonRegister.TabIndex = 13;
            this.materialButtonRegister.Text = "Don\'t have an account? Sign Up";
            this.materialButtonRegister.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.materialButtonRegister.UseAccentColor = false;
            this.materialButtonRegister.UseVisualStyleBackColor = true;
            this.materialButtonRegister.Click += new System.EventHandler(this.materialButtonRegister_Click);
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.linkForgotPassword);
            this.panelLogin.Controls.Add(this.labelSignIn);
            this.panelLogin.Controls.Add(this.materialButtonRegister);
            this.panelLogin.Controls.Add(this.pictureBoxLogo);
            this.panelLogin.Controls.Add(this.labelUserTypeError);
            this.panelLogin.Controls.Add(this.materialButtonCustomer);
            this.panelLogin.Controls.Add(this.labelPasswordError);
            this.panelLogin.Controls.Add(this.materialButtonCompany);
            this.panelLogin.Controls.Add(this.labelEmailError);
            this.panelLogin.Controls.Add(this.materialTextBoxEmail);
            this.panelLogin.Controls.Add(this.materialButtonSignIn);
            this.panelLogin.Controls.Add(this.materialTextBoxPassword);
            this.panelLogin.Controls.Add(this.labelPassword);
            this.panelLogin.Controls.Add(this.labelEmail);
            this.panelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogin.Location = new System.Drawing.Point(3, 24);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(446, 573);
            this.panelLogin.TabIndex = 14;
            // 
            // linkForgotPassword
            // 
            this.linkForgotPassword.AutoSize = true;
            this.linkForgotPassword.Location = new System.Drawing.Point(235, 485);
            this.linkForgotPassword.Name = "linkForgotPassword";
            this.linkForgotPassword.Size = new System.Drawing.Size(100, 15);
            this.linkForgotPassword.TabIndex = 14;
            this.linkForgotPassword.TabStop = true;
            this.linkForgotPassword.Text = "Forgot Password?";
            this.linkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkForgotPassword_LinkClicked);
            // 
            // panelOtp
            // 
            this.panelOtp.Controls.Add(this.linkResendOtp);
            this.panelOtp.Controls.Add(this.buttonVerify);
            this.panelOtp.Controls.Add(this.textBoxOtp);
            this.panelOtp.Controls.Add(this.labelOtpInfo);
            this.panelOtp.Location = new System.Drawing.Point(26, 126);
            this.panelOtp.Name = "panelOtp";
            this.panelOtp.Size = new System.Drawing.Size(400, 300);
            this.panelOtp.TabIndex = 15;
            this.panelOtp.Visible = false;
            // 
            // linkResendOtp
            // 
            this.linkResendOtp.AutoSize = true;
            this.linkResendOtp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkResendOtp.Location = new System.Drawing.Point(20, 180);
            this.linkResendOtp.Name = "linkResendOtp";
            this.linkResendOtp.Size = new System.Drawing.Size(81, 17);
            this.linkResendOtp.TabIndex = 3;
            this.linkResendOtp.TabStop = true;
            this.linkResendOtp.Text = "Resend OTP";
            this.linkResendOtp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkResendOtp_LinkClicked);
            // 
            // buttonVerify
            // 
            this.buttonVerify.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonVerify.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonVerify.Depth = 0;
            this.buttonVerify.Enabled = false;
            this.buttonVerify.HighEmphasis = true;
            this.buttonVerify.Icon = null;
            this.buttonVerify.Location = new System.Drawing.Point(310, 170);
            this.buttonVerify.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonVerify.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonVerify.Size = new System.Drawing.Size(70, 36);
            this.buttonVerify.TabIndex = 2;
            this.buttonVerify.Text = "Verify";
            this.buttonVerify.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonVerify.UseAccentColor = false;
            this.buttonVerify.UseVisualStyleBackColor = true;
            this.buttonVerify.Click += new System.EventHandler(this.buttonVerify_Click);
            // 
            // textBoxOtp
            // 
            this.textBoxOtp.AnimateReadOnly = false;
            this.textBoxOtp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxOtp.Depth = 0;
            this.textBoxOtp.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxOtp.LeadingIcon = null;
            this.textBoxOtp.Location = new System.Drawing.Point(20, 100);
            this.textBoxOtp.MaxLength = 6;
            this.textBoxOtp.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxOtp.Multiline = false;
            this.textBoxOtp.Name = "textBoxOtp";
            this.textBoxOtp.Size = new System.Drawing.Size(360, 50);
            this.textBoxOtp.TabIndex = 1;
            this.textBoxOtp.Text = "";
            this.textBoxOtp.TrailingIcon = null;
            this.textBoxOtp.TextChanged += new System.EventHandler(this.textBoxOtp_TextChanged);
            // 
            // labelOtpInfo
            // 
            this.labelOtpInfo.Depth = 0;
            this.labelOtpInfo.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelOtpInfo.Location = new System.Drawing.Point(20, 20);
            this.labelOtpInfo.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelOtpInfo.Name = "labelOtpInfo";
            this.labelOtpInfo.Size = new System.Drawing.Size(360, 60);
            this.labelOtpInfo.TabIndex = 0;
            this.labelOtpInfo.Text = "Your email is not verified. An OTP has been sent to your email. Please enter it " +
    "below.";
            // 
            // otpCooldownTimer
            // 
            this.otpCooldownTimer.Interval = 1000;
            this.otpCooldownTimer.Tick += new System.EventHandler(this.otpCooldownTimer_Tick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 600);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelOtp);
            this.FormStyle = FormStyles.ActionBar_None;
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(3, 24, 3, 3);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelOtp.ResumeLayout(false);
            this.panelOtp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private MaterialSkin.Controls.MaterialLabel labelSignIn;
        private MaterialSkin.Controls.MaterialButton materialButtonCustomer;
        private MaterialSkin.Controls.MaterialButton materialButtonCompany;
        private MaterialSkin.Controls.MaterialTextBox materialTextBoxEmail;
        private MaterialSkin.Controls.MaterialTextBox materialTextBoxPassword;
        private MaterialSkin.Controls.MaterialLabel labelEmail;
        private MaterialSkin.Controls.MaterialLabel labelPassword;
        private MaterialSkin.Controls.MaterialButton materialButtonSignIn;
        private System.Windows.Forms.Label labelEmailError;
        private System.Windows.Forms.Label labelPasswordError;
        private System.Windows.Forms.Label labelUserTypeError;
        private MaterialSkin.Controls.MaterialButton materialButtonRegister;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelOtp;
        private System.Windows.Forms.LinkLabel linkResendOtp;
        private MaterialSkin.Controls.MaterialButton buttonVerify;
        private MaterialSkin.Controls.MaterialTextBox textBoxOtp;
        private MaterialSkin.Controls.MaterialLabel labelOtpInfo;
        private System.Windows.Forms.Timer otpCooldownTimer;
        private System.Windows.Forms.LinkLabel linkForgotPassword;
    }
}
