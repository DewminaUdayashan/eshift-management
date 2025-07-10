namespace eshift_management.Forms
{
    partial class RegistrationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabSelector = new MaterialSkin.Controls.MaterialTabSelector();
            this.tabControl = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPageDetails = new System.Windows.Forms.TabPage();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.labelConfirmPasswordError = new System.Windows.Forms.Label();
            this.labelPasswordError = new System.Windows.Forms.Label();
            this.labelPostalCodeError = new System.Windows.Forms.Label();
            this.labelCityError = new System.Windows.Forms.Label();
            this.labelAddressError = new System.Windows.Forms.Label();
            this.labelPhoneError = new System.Windows.Forms.Label();
            this.labelEmailError = new System.Windows.Forms.Label();
            this.labelLastNameError = new System.Windows.Forms.Label();
            this.labelFirstNameError = new System.Windows.Forms.Label();
            this.buttonNext = new MaterialSkin.Controls.MaterialButton();
            this.textBoxConfirmPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxPassword = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxPostalCode = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxCity = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxAddress = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxPhone = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxLastName = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxFirstName = new MaterialSkin.Controls.MaterialTextBox();
            this.tabPageOtp = new System.Windows.Forms.TabPage();
            this.linkResendOtp = new System.Windows.Forms.LinkLabel();
            this.buttonVerify = new MaterialSkin.Controls.MaterialButton();
            this.textBoxOtp = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.buttonBackToLogin = new MaterialSkin.Controls.MaterialButton();
            this.otpCooldownTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.tabPageDetails.SuspendLayout();
            this.panelDetails.SuspendLayout();
            this.tabPageOtp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabSelector
            // 
            this.tabSelector.BaseTabControl = this.tabControl;
            this.tabSelector.CharacterCasing = MaterialSkin.Controls.MaterialTabSelector.CustomCharacterCasing.Normal;
            this.tabSelector.Depth = 0;
            this.tabSelector.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tabSelector.Location = new System.Drawing.Point(0, 64);
            this.tabSelector.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabSelector.Name = "tabSelector";
            this.tabSelector.Size = new System.Drawing.Size(550, 48);
            this.tabSelector.TabIndex = 0;
            this.tabSelector.Text = "materialTabSelector1";
            this.tabSelector.Visible = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageDetails);
            this.tabControl.Controls.Add(this.tabPageOtp);
            this.tabControl.Depth = 0;
            this.tabControl.Location = new System.Drawing.Point(25, 140);
            this.tabControl.MouseState = MaterialSkin.MouseState.HOVER;
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(500, 580);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageDetails
            // 
            this.tabPageDetails.BackColor = System.Drawing.Color.White;
            this.tabPageDetails.Controls.Add(this.panelDetails);
            this.tabPageDetails.Location = new System.Drawing.Point(4, 24);
            this.tabPageDetails.Name = "tabPageDetails";
            this.tabPageDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetails.Size = new System.Drawing.Size(492, 552);
            this.tabPageDetails.TabIndex = 0;
            this.tabPageDetails.Text = "Details";
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.labelConfirmPasswordError);
            this.panelDetails.Controls.Add(this.labelPasswordError);
            this.panelDetails.Controls.Add(this.labelPostalCodeError);
            this.panelDetails.Controls.Add(this.labelCityError);
            this.panelDetails.Controls.Add(this.labelAddressError);
            this.panelDetails.Controls.Add(this.labelPhoneError);
            this.panelDetails.Controls.Add(this.labelEmailError);
            this.panelDetails.Controls.Add(this.labelLastNameError);
            this.panelDetails.Controls.Add(this.labelFirstNameError);
            this.panelDetails.Controls.Add(this.buttonNext);
            this.panelDetails.Controls.Add(this.textBoxConfirmPassword);
            this.panelDetails.Controls.Add(this.textBoxPassword);
            this.panelDetails.Controls.Add(this.textBoxPostalCode);
            this.panelDetails.Controls.Add(this.textBoxCity);
            this.panelDetails.Controls.Add(this.textBoxAddress);
            this.panelDetails.Controls.Add(this.textBoxPhone);
            this.panelDetails.Controls.Add(this.textBoxEmail);
            this.panelDetails.Controls.Add(this.textBoxLastName);
            this.panelDetails.Controls.Add(this.textBoxFirstName);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetails.Location = new System.Drawing.Point(3, 3);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(486, 546);
            this.panelDetails.TabIndex = 0;
            // 
            // labelConfirmPasswordError
            // 
            this.labelConfirmPasswordError.AutoSize = true;
            this.labelConfirmPasswordError.Location = new System.Drawing.Point(19, 484);
            this.labelConfirmPasswordError.Name = "labelConfirmPasswordError";
            this.labelConfirmPasswordError.Size = new System.Drawing.Size(10, 15);
            this.labelConfirmPasswordError.TabIndex = 19;
            this.labelConfirmPasswordError.Text = " ";
            // 
            // labelPasswordError
            // 
            this.labelPasswordError.AutoSize = true;
            this.labelPasswordError.Location = new System.Drawing.Point(19, 419);
            this.labelPasswordError.Name = "labelPasswordError";
            this.labelPasswordError.Size = new System.Drawing.Size(10, 15);
            this.labelPasswordError.TabIndex = 18;
            this.labelPasswordError.Text = " ";
            // 
            // labelPostalCodeError
            // 
            this.labelPostalCodeError.AutoSize = true;
            this.labelPostalCodeError.Location = new System.Drawing.Point(284, 354);
            this.labelPostalCodeError.Name = "labelPostalCodeError";
            this.labelPostalCodeError.Size = new System.Drawing.Size(10, 15);
            this.labelPostalCodeError.TabIndex = 17;
            this.labelPostalCodeError.Text = " ";
            // 
            // labelCityError
            // 
            this.labelCityError.AutoSize = true;
            this.labelCityError.Location = new System.Drawing.Point(19, 354);
            this.labelCityError.Name = "labelCityError";
            this.labelCityError.Size = new System.Drawing.Size(10, 15);
            this.labelCityError.TabIndex = 16;
            this.labelCityError.Text = " ";
            // 
            // labelAddressError
            // 
            this.labelAddressError.AutoSize = true;
            this.labelAddressError.Location = new System.Drawing.Point(19, 289);
            this.labelAddressError.Name = "labelAddressError";
            this.labelAddressError.Size = new System.Drawing.Size(10, 15);
            this.labelAddressError.TabIndex = 15;
            this.labelAddressError.Text = " ";
            // 
            // labelPhoneError
            // 
            this.labelPhoneError.AutoSize = true;
            this.labelPhoneError.Location = new System.Drawing.Point(19, 224);
            this.labelPhoneError.Name = "labelPhoneError";
            this.labelPhoneError.Size = new System.Drawing.Size(10, 15);
            this.labelPhoneError.TabIndex = 14;
            this.labelPhoneError.Text = " ";
            // 
            // labelEmailError
            // 
            this.labelEmailError.AutoSize = true;
            this.labelEmailError.Location = new System.Drawing.Point(19, 159);
            this.labelEmailError.Name = "labelEmailError";
            this.labelEmailError.Size = new System.Drawing.Size(10, 15);
            this.labelEmailError.TabIndex = 13;
            this.labelEmailError.Text = " ";
            // 
            // labelLastNameError
            // 
            this.labelLastNameError.AutoSize = true;
            this.labelLastNameError.Location = new System.Drawing.Point(284, 69);
            this.labelLastNameError.Name = "labelLastNameError";
            this.labelLastNameError.Size = new System.Drawing.Size(10, 15);
            this.labelLastNameError.TabIndex = 12;
            this.labelLastNameError.Text = " ";
            // 
            // labelFirstNameError
            // 
            this.labelFirstNameError.AutoSize = true;
            this.labelFirstNameError.Location = new System.Drawing.Point(19, 69);
            this.labelFirstNameError.Name = "labelFirstNameError";
            this.labelFirstNameError.Size = new System.Drawing.Size(10, 15);
            this.labelFirstNameError.TabIndex = 11;
            this.labelFirstNameError.Text = " ";
            // 
            // buttonNext
            // 
            this.buttonNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonNext.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonNext.Depth = 0;
            this.buttonNext.HighEmphasis = true;
            this.buttonNext.Icon = null;
            this.buttonNext.Location = new System.Drawing.Point(404, 501);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonNext.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonNext.Size = new System.Drawing.Size(60, 36);
            this.buttonNext.TabIndex = 9;
            this.buttonNext.Text = "Next";
            this.buttonNext.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonNext.UseAccentColor = false;
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.AnimateReadOnly = false;
            this.textBoxConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxConfirmPassword.Depth = 0;
            this.textBoxConfirmPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxConfirmPassword.Hint = "Confirm Password";
            this.textBoxConfirmPassword.LeadingIcon = null;
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(19, 431);
            this.textBoxConfirmPassword.MaxLength = 50;
            this.textBoxConfirmPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxConfirmPassword.Multiline = false;
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Password = true;
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(445, 50);
            this.textBoxConfirmPassword.TabIndex = 8;
            this.textBoxConfirmPassword.Text = "";
            this.textBoxConfirmPassword.TrailingIcon = null;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.AnimateReadOnly = false;
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Depth = 0;
            this.textBoxPassword.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxPassword.Hint = "Password";
            this.textBoxPassword.LeadingIcon = null;
            this.textBoxPassword.Location = new System.Drawing.Point(19, 366);
            this.textBoxPassword.MaxLength = 50;
            this.textBoxPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxPassword.Multiline = false;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Password = true;
            this.textBoxPassword.Size = new System.Drawing.Size(445, 50);
            this.textBoxPassword.TabIndex = 7;
            this.textBoxPassword.Text = "";
            this.textBoxPassword.TrailingIcon = null;
            // 
            // textBoxPostalCode
            // 
            this.textBoxPostalCode.AnimateReadOnly = false;
            this.textBoxPostalCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPostalCode.Depth = 0;
            this.textBoxPostalCode.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxPostalCode.Hint = "Postal Code";
            this.textBoxPostalCode.LeadingIcon = null;
            this.textBoxPostalCode.Location = new System.Drawing.Point(284, 301);
            this.textBoxPostalCode.MaxLength = 50;
            this.textBoxPostalCode.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxPostalCode.Multiline = false;
            this.textBoxPostalCode.Name = "textBoxPostalCode";
            this.textBoxPostalCode.Size = new System.Drawing.Size(180, 50);
            this.textBoxPostalCode.TabIndex = 6;
            this.textBoxPostalCode.Text = "";
            this.textBoxPostalCode.TrailingIcon = null;
            // 
            // textBoxCity
            // 
            this.textBoxCity.AnimateReadOnly = false;
            this.textBoxCity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCity.Depth = 0;
            this.textBoxCity.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxCity.Hint = "City";
            this.textBoxCity.LeadingIcon = null;
            this.textBoxCity.Location = new System.Drawing.Point(19, 301);
            this.textBoxCity.MaxLength = 50;
            this.textBoxCity.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxCity.Multiline = false;
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(240, 50);
            this.textBoxCity.TabIndex = 5;
            this.textBoxCity.Text = "";
            this.textBoxCity.TrailingIcon = null;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.AnimateReadOnly = false;
            this.textBoxAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAddress.Depth = 0;
            this.textBoxAddress.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxAddress.Hint = "Address Line";
            this.textBoxAddress.LeadingIcon = null;
            this.textBoxAddress.Location = new System.Drawing.Point(19, 236);
            this.textBoxAddress.MaxLength = 50;
            this.textBoxAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxAddress.Multiline = false;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(445, 50);
            this.textBoxAddress.TabIndex = 4;
            this.textBoxAddress.Text = "";
            this.textBoxAddress.TrailingIcon = null;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.AnimateReadOnly = false;
            this.textBoxPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPhone.Depth = 0;
            this.textBoxPhone.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxPhone.Hint = "Phone Number";
            this.textBoxPhone.LeadingIcon = null;
            this.textBoxPhone.Location = new System.Drawing.Point(19, 171);
            this.textBoxPhone.MaxLength = 50;
            this.textBoxPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxPhone.Multiline = false;
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(445, 50);
            this.textBoxPhone.TabIndex = 3;
            this.textBoxPhone.Text = "";
            this.textBoxPhone.TrailingIcon = null;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.AnimateReadOnly = false;
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEmail.Depth = 0;
            this.textBoxEmail.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxEmail.Hint = "Email Address";
            this.textBoxEmail.LeadingIcon = null;
            this.textBoxEmail.Location = new System.Drawing.Point(19, 106);
            this.textBoxEmail.MaxLength = 50;
            this.textBoxEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxEmail.Multiline = false;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(445, 50);
            this.textBoxEmail.TabIndex = 2;
            this.textBoxEmail.Text = "";
            this.textBoxEmail.TrailingIcon = null;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.AnimateReadOnly = false;
            this.textBoxLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLastName.Depth = 0;
            this.textBoxLastName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxLastName.Hint = "Last Name";
            this.textBoxLastName.LeadingIcon = null;
            this.textBoxLastName.Location = new System.Drawing.Point(284, 16);
            this.textBoxLastName.MaxLength = 50;
            this.textBoxLastName.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxLastName.Multiline = false;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(180, 50);
            this.textBoxLastName.TabIndex = 1;
            this.textBoxLastName.Text = "";
            this.textBoxLastName.TrailingIcon = null;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.AnimateReadOnly = false;
            this.textBoxFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFirstName.Depth = 0;
            this.textBoxFirstName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxFirstName.Hint = "First Name";
            this.textBoxFirstName.LeadingIcon = null;
            this.textBoxFirstName.Location = new System.Drawing.Point(19, 16);
            this.textBoxFirstName.MaxLength = 50;
            this.textBoxFirstName.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxFirstName.Multiline = false;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(240, 50);
            this.textBoxFirstName.TabIndex = 0;
            this.textBoxFirstName.Text = "";
            this.textBoxFirstName.TrailingIcon = null;
            // 
            // tabPageOtp
            // 
            this.tabPageOtp.BackColor = System.Drawing.Color.White;
            this.tabPageOtp.Controls.Add(this.linkResendOtp);
            this.tabPageOtp.Controls.Add(this.buttonVerify);
            this.tabPageOtp.Controls.Add(this.textBoxOtp);
            this.tabPageOtp.Controls.Add(this.materialLabel1);
            this.tabPageOtp.Location = new System.Drawing.Point(4, 24);
            this.tabPageOtp.Name = "tabPageOtp";
            this.tabPageOtp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOtp.Size = new System.Drawing.Size(492, 552);
            this.tabPageOtp.TabIndex = 1;
            this.tabPageOtp.Text = "OTP";
            // 
            // linkResendOtp
            // 
            this.linkResendOtp.AutoSize = true;
            this.linkResendOtp.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkResendOtp.Location = new System.Drawing.Point(25, 230);
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
            this.buttonVerify.Location = new System.Drawing.Point(390, 220);
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
            this.textBoxOtp.Location = new System.Drawing.Point(25, 150);
            this.textBoxOtp.MaxLength = 6;
            this.textBoxOtp.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxOtp.Multiline = false;
            this.textBoxOtp.Name = "textBoxOtp";
            this.textBoxOtp.Size = new System.Drawing.Size(435, 50);
            this.textBoxOtp.TabIndex = 1;
            this.textBoxOtp.Text = "";
            this.textBoxOtp.TrailingIcon = null;
            this.textBoxOtp.TextChanged += new System.EventHandler(this.textBoxOtp_TextChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(25, 30);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(435, 60);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "An OTP has been sent to your email address for verification. Please enter it below to complete your registration.";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBoxLogo.BackColor = System.Drawing.Color.White;
            this.pictureBoxLogo.Location = new System.Drawing.Point(225, 80);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 2;
            this.pictureBoxLogo.TabStop = false;
            // 
            // buttonBackToLogin
            // 
            this.buttonBackToLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonBackToLogin.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonBackToLogin.Depth = 0;
            this.buttonBackToLogin.HighEmphasis = false;
            this.buttonBackToLogin.Icon = null;
            this.buttonBackToLogin.Location = new System.Drawing.Point(215, 725);
            this.buttonBackToLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonBackToLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonBackToLogin.Name = "buttonBackToLogin";
            this.buttonBackToLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonBackToLogin.Size = new System.Drawing.Size(120, 36);
            this.buttonBackToLogin.TabIndex = 3;
            this.buttonBackToLogin.Text = "Back to Login";
            this.buttonBackToLogin.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.buttonBackToLogin.UseAccentColor = false;
            this.buttonBackToLogin.UseVisualStyleBackColor = true;
            this.buttonBackToLogin.Click += new System.EventHandler(this.buttonBackToLogin_Click);
            // 
            // otpCooldownTimer
            // 
            this.otpCooldownTimer.Interval = 1000;
            this.otpCooldownTimer.Tick += new System.EventHandler(this.otpCooldownTimer_Tick);
            // 
            // RegistrationForm
            // 
            this.ClientSize = new System.Drawing.Size(550, 770);
            this.Controls.Add(this.buttonBackToLogin);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tabSelector);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrationForm";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create a New Account";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegistrationForm_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPageDetails.ResumeLayout(false);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.tabPageOtp.ResumeLayout(false);
            this.tabPageOtp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private MaterialSkin.Controls.MaterialTabSelector tabSelector;
        private MaterialSkin.Controls.MaterialTabControl tabControl;
        private System.Windows.Forms.TabPage tabPageDetails;
        private System.Windows.Forms.TabPage tabPageOtp;
        private MaterialSkin.Controls.MaterialTextBox textBoxFirstName;
        private MaterialSkin.Controls.MaterialTextBox textBoxLastName;
        private MaterialSkin.Controls.MaterialTextBox textBoxEmail;
        private MaterialSkin.Controls.MaterialTextBox textBoxPhone;
        private MaterialSkin.Controls.MaterialTextBox textBoxAddress;
        private MaterialSkin.Controls.MaterialTextBox textBoxCity;
        private MaterialSkin.Controls.MaterialTextBox textBoxPostalCode;
        private MaterialSkin.Controls.MaterialTextBox textBoxPassword;
        private MaterialSkin.Controls.MaterialTextBox textBoxConfirmPassword;
        private MaterialSkin.Controls.MaterialButton buttonNext;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox textBoxOtp;
        private MaterialSkin.Controls.MaterialButton buttonVerify;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private MaterialSkin.Controls.MaterialButton buttonBackToLogin;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label labelFirstNameError;
        private System.Windows.Forms.Label labelConfirmPasswordError;
        private System.Windows.Forms.Label labelPasswordError;
        private System.Windows.Forms.Label labelPostalCodeError;
        private System.Windows.Forms.Label labelCityError;
        private System.Windows.Forms.Label labelAddressError;
        private System.Windows.Forms.Label labelPhoneError;
        private System.Windows.Forms.Label labelEmailError;
        private System.Windows.Forms.Label labelLastNameError;
        private System.Windows.Forms.LinkLabel linkResendOtp;
        private System.Windows.Forms.Timer otpCooldownTimer;
    }
}