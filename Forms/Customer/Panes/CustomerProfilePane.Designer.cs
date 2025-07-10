namespace eshift_management.Panes
{
    partial class CustomerProfilePane
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

        #region Component Designer generated code
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPostalCodeError = new System.Windows.Forms.Label();
            this.labelCityError = new System.Windows.Forms.Label();
            this.labelAddressError = new System.Windows.Forms.Label();
            this.labelPhoneError = new System.Windows.Forms.Label();
            this.labelEmailError = new System.Windows.Forms.Label();
            this.labelLastNameError = new System.Windows.Forms.Label();
            this.labelFirstNameError = new System.Windows.Forms.Label();
            this.buttonSaveChanges = new MaterialSkin.Controls.MaterialButton();
            this.textBoxPostalCode = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxCity = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxAddress = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxPhone = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxEmail = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxLastName = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxFirstName = new MaterialSkin.Controls.MaterialTextBox();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(189, 45);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "My Profile";
            // 
            // labelPostalCodeError
            // 
            this.labelPostalCodeError.AutoSize = true;
            this.labelPostalCodeError.Location = new System.Drawing.Point(266, 438);
            this.labelPostalCodeError.Name = "labelPostalCodeError";
            this.labelPostalCodeError.Size = new System.Drawing.Size(10, 15);
            this.labelPostalCodeError.TabIndex = 32;
            this.labelPostalCodeError.Text = " ";
            // 
            // labelCityError
            // 
            this.labelCityError.AutoSize = true;
            this.labelCityError.Location = new System.Drawing.Point(26, 438);
            this.labelCityError.Name = "labelCityError";
            this.labelCityError.Size = new System.Drawing.Size(10, 15);
            this.labelCityError.TabIndex = 31;
            this.labelCityError.Text = " ";
            // 
            // labelAddressError
            // 
            this.labelAddressError.AutoSize = true;
            this.labelAddressError.Location = new System.Drawing.Point(26, 363);
            this.labelAddressError.Name = "labelAddressError";
            this.labelAddressError.Size = new System.Drawing.Size(10, 15);
            this.labelAddressError.TabIndex = 30;
            this.labelAddressError.Text = " ";
            // 
            // labelPhoneError
            // 
            this.labelPhoneError.AutoSize = true;
            this.labelPhoneError.Location = new System.Drawing.Point(26, 288);
            this.labelPhoneError.Name = "labelPhoneError";
            this.labelPhoneError.Size = new System.Drawing.Size(10, 15);
            this.labelPhoneError.TabIndex = 29;
            this.labelPhoneError.Text = " ";
            // 
            // labelEmailError
            // 
            this.labelEmailError.AutoSize = true;
            this.labelEmailError.Location = new System.Drawing.Point(26, 213);
            this.labelEmailError.Name = "labelEmailError";
            this.labelEmailError.Size = new System.Drawing.Size(10, 15);
            this.labelEmailError.TabIndex = 28;
            this.labelEmailError.Text = " ";
            // 
            // labelLastNameError
            // 
            this.labelLastNameError.AutoSize = true;
            this.labelLastNameError.Location = new System.Drawing.Point(266, 138);
            this.labelLastNameError.Name = "labelLastNameError";
            this.labelLastNameError.Size = new System.Drawing.Size(10, 15);
            this.labelLastNameError.TabIndex = 27;
            this.labelLastNameError.Text = " ";
            // 
            // labelFirstNameError
            // 
            this.labelFirstNameError.AutoSize = true;
            this.labelFirstNameError.Location = new System.Drawing.Point(26, 138);
            this.labelFirstNameError.Name = "labelFirstNameError";
            this.labelFirstNameError.Size = new System.Drawing.Size(10, 15);
            this.labelFirstNameError.TabIndex = 26;
            this.labelFirstNameError.Text = " ";
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSaveChanges.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSaveChanges.Depth = 0;
            this.buttonSaveChanges.HighEmphasis = true;
            this.buttonSaveChanges.Icon = null;
            this.buttonSaveChanges.Location = new System.Drawing.Point(355, 470);
            this.buttonSaveChanges.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSaveChanges.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonSaveChanges.Size = new System.Drawing.Size(130, 36);
            this.buttonSaveChanges.TabIndex = 24;
            this.buttonSaveChanges.Text = "Save Changes";
            this.buttonSaveChanges.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonSaveChanges.UseAccentColor = false;
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // textBoxPostalCode
            // 
            this.textBoxPostalCode.AnimateReadOnly = false;
            this.textBoxPostalCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPostalCode.Depth = 0;
            this.textBoxPostalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxPostalCode.Hint = "Postal Code";
            this.textBoxPostalCode.LeadingIcon = null;
            this.textBoxPostalCode.Location = new System.Drawing.Point(265, 385);
            this.textBoxPostalCode.MaxLength = 50;
            this.textBoxPostalCode.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxPostalCode.Multiline = false;
            this.textBoxPostalCode.Name = "textBoxPostalCode";
            this.textBoxPostalCode.Size = new System.Drawing.Size(220, 50);
            this.textBoxPostalCode.TabIndex = 23;
            this.textBoxPostalCode.Text = "";
            this.textBoxPostalCode.TrailingIcon = null;
            // 
            // textBoxCity
            // 
            this.textBoxCity.AnimateReadOnly = false;
            this.textBoxCity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCity.Depth = 0;
            this.textBoxCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxCity.Hint = "City";
            this.textBoxCity.LeadingIcon = null;
            this.textBoxCity.Location = new System.Drawing.Point(25, 385);
            this.textBoxCity.MaxLength = 50;
            this.textBoxCity.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxCity.Multiline = false;
            this.textBoxCity.Name = "textBoxCity";
            this.textBoxCity.Size = new System.Drawing.Size(220, 50);
            this.textBoxCity.TabIndex = 22;
            this.textBoxCity.Text = "";
            this.textBoxCity.TrailingIcon = null;
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.AnimateReadOnly = false;
            this.textBoxAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxAddress.Depth = 0;
            this.textBoxAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxAddress.Hint = "Address Line";
            this.textBoxAddress.LeadingIcon = null;
            this.textBoxAddress.Location = new System.Drawing.Point(25, 310);
            this.textBoxAddress.MaxLength = 50;
            this.textBoxAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxAddress.Multiline = false;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(460, 50);
            this.textBoxAddress.TabIndex = 21;
            this.textBoxAddress.Text = "";
            this.textBoxAddress.TrailingIcon = null;
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.AnimateReadOnly = false;
            this.textBoxPhone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPhone.Depth = 0;
            this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxPhone.Hint = "Phone Number";
            this.textBoxPhone.LeadingIcon = null;
            this.textBoxPhone.Location = new System.Drawing.Point(25, 235);
            this.textBoxPhone.MaxLength = 50;
            this.textBoxPhone.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxPhone.Multiline = false;
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(460, 50);
            this.textBoxPhone.TabIndex = 20;
            this.textBoxPhone.Text = "";
            this.textBoxPhone.TrailingIcon = null;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.AnimateReadOnly = false;
            this.textBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxEmail.Depth = 0;
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxEmail.Hint = "Email Address";
            this.textBoxEmail.LeadingIcon = null;
            this.textBoxEmail.Location = new System.Drawing.Point(25, 160);
            this.textBoxEmail.MaxLength = 50;
            this.textBoxEmail.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxEmail.Multiline = false;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(460, 50);
            this.textBoxEmail.TabIndex = 19;
            this.textBoxEmail.Text = "";
            this.textBoxEmail.TrailingIcon = null;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.AnimateReadOnly = false;
            this.textBoxLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLastName.Depth = 0;
            this.textBoxLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxLastName.Hint = "Last Name";
            this.textBoxLastName.LeadingIcon = null;
            this.textBoxLastName.Location = new System.Drawing.Point(265, 85);
            this.textBoxLastName.MaxLength = 50;
            this.textBoxLastName.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxLastName.Multiline = false;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(220, 50);
            this.textBoxLastName.TabIndex = 18;
            this.textBoxLastName.Text = "";
            this.textBoxLastName.TrailingIcon = null;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.AnimateReadOnly = false;
            this.textBoxFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFirstName.Depth = 0;
            this.textBoxFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxFirstName.Hint = "First Name";
            this.textBoxFirstName.LeadingIcon = null;
            this.textBoxFirstName.Location = new System.Drawing.Point(25, 85);
            this.textBoxFirstName.MaxLength = 50;
            this.textBoxFirstName.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxFirstName.Multiline = false;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(220, 50);
            this.textBoxFirstName.TabIndex = 17;
            this.textBoxFirstName.Text = "";
            this.textBoxFirstName.TrailingIcon = null;
            // 
            // CustomerProfilePane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.labelPostalCodeError);
            this.Controls.Add(this.labelCityError);
            this.Controls.Add(this.labelAddressError);
            this.Controls.Add(this.labelPhoneError);
            this.Controls.Add(this.labelEmailError);
            this.Controls.Add(this.labelLastNameError);
            this.Controls.Add(this.labelFirstNameError);
            this.Controls.Add(this.buttonSaveChanges);
            this.Controls.Add(this.textBoxPostalCode);
            this.Controls.Add(this.textBoxCity);
            this.Controls.Add(this.textBoxAddress);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.labelTitle);
            this.Name = "CustomerProfilePane";
            this.Size = new System.Drawing.Size(898, 653);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPostalCodeError;
        private System.Windows.Forms.Label labelCityError;
        private System.Windows.Forms.Label labelAddressError;
        private System.Windows.Forms.Label labelPhoneError;
        private System.Windows.Forms.Label labelEmailError;
        private System.Windows.Forms.Label labelLastNameError;
        private System.Windows.Forms.Label labelFirstNameError;
        private MaterialSkin.Controls.MaterialButton buttonSaveChanges;
        private MaterialSkin.Controls.MaterialTextBox textBoxPostalCode;
        private MaterialSkin.Controls.MaterialTextBox textBoxCity;
        private MaterialSkin.Controls.MaterialTextBox textBoxAddress;
        private MaterialSkin.Controls.MaterialTextBox textBoxPhone;
        private MaterialSkin.Controls.MaterialTextBox textBoxEmail;
        private MaterialSkin.Controls.MaterialTextBox textBoxLastName;
        private MaterialSkin.Controls.MaterialTextBox textBoxFirstName;
    }
}