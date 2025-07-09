namespace eshift_management
{
    partial class AddEditEmployeeForm
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
            this.textBoxFirstName = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxLastName = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxContact = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxLicense = new MaterialSkin.Controls.MaterialTextBox();
            this.comboBoxPosition = new MaterialSkin.Controls.MaterialComboBox();
            this.buttonSave = new MaterialSkin.Controls.MaterialButton();
            this.buttonCancel = new MaterialSkin.Controls.MaterialButton();
            this.labelFirstNameError = new System.Windows.Forms.Label();
            this.labelLastNameError = new System.Windows.Forms.Label();
            this.labelContactError = new System.Windows.Forms.Label();
            this.labelLicenseError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.AnimateReadOnly = false;
            this.textBoxFirstName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxFirstName.Depth = 0;
            this.textBoxFirstName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxFirstName.Hint = "First Name";
            this.textBoxFirstName.LeadingIcon = null;
            this.textBoxFirstName.Location = new System.Drawing.Point(25, 85);
            this.textBoxFirstName.MaxLength = 50;
            this.textBoxFirstName.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxFirstName.Multiline = false;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(220, 50);
            this.textBoxFirstName.TabIndex = 0;
            this.textBoxFirstName.Text = "";
            this.textBoxFirstName.TrailingIcon = null;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.AnimateReadOnly = false;
            this.textBoxLastName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLastName.Depth = 0;
            this.textBoxLastName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxLastName.Hint = "Last Name";
            this.textBoxLastName.LeadingIcon = null;
            this.textBoxLastName.Location = new System.Drawing.Point(265, 85);
            this.textBoxLastName.MaxLength = 50;
            this.textBoxLastName.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxLastName.Multiline = false;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(220, 50);
            this.textBoxLastName.TabIndex = 1;
            this.textBoxLastName.Text = "";
            this.textBoxLastName.TrailingIcon = null;
            // 
            // textBoxContact
            // 
            this.textBoxContact.AnimateReadOnly = false;
            this.textBoxContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxContact.Depth = 0;
            this.textBoxContact.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxContact.Hint = "Contact Number";
            this.textBoxContact.LeadingIcon = null;
            this.textBoxContact.Location = new System.Drawing.Point(25, 235);
            this.textBoxContact.MaxLength = 50;
            this.textBoxContact.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxContact.Multiline = false;
            this.textBoxContact.Name = "textBoxContact";
            this.textBoxContact.Size = new System.Drawing.Size(460, 50);
            this.textBoxContact.TabIndex = 3;
            this.textBoxContact.Text = "";
            this.textBoxContact.TrailingIcon = null;
            // 
            // textBoxLicense
            // 
            this.textBoxLicense.AnimateReadOnly = false;
            this.textBoxLicense.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLicense.Depth = 0;
            this.textBoxLicense.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxLicense.Hint = "License Number";
            this.textBoxLicense.LeadingIcon = null;
            this.textBoxLicense.Location = new System.Drawing.Point(25, 310);
            this.textBoxLicense.MaxLength = 50;
            this.textBoxLicense.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxLicense.Multiline = false;
            this.textBoxLicense.Name = "textBoxLicense";
            this.textBoxLicense.Size = new System.Drawing.Size(460, 50);
            this.textBoxLicense.TabIndex = 4;
            this.textBoxLicense.Text = "";
            this.textBoxLicense.TrailingIcon = null;
            // 
            // comboBoxPosition
            // 
            this.comboBoxPosition.AutoResize = false;
            this.comboBoxPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxPosition.Depth = 0;
            this.comboBoxPosition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxPosition.DropDownHeight = 174;
            this.comboBoxPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPosition.DropDownWidth = 121;
            this.comboBoxPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.Hint = "Position";
            this.comboBoxPosition.IntegralHeight = false;
            this.comboBoxPosition.ItemHeight = 43;
            this.comboBoxPosition.Location = new System.Drawing.Point(25, 160);
            this.comboBoxPosition.MaxDropDownItems = 4;
            this.comboBoxPosition.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(460, 49);
            this.comboBoxPosition.StartIndex = 0;
            this.comboBoxPosition.TabIndex = 2;
            this.comboBoxPosition.SelectedIndexChanged += new System.EventHandler(this.comboBoxPosition_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSave.Depth = 0;
            this.buttonSave.HighEmphasis = true;
            this.buttonSave.Icon = null;
            this.buttonSave.Location = new System.Drawing.Point(340, 390);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonSave.Size = new System.Drawing.Size(58, 36);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonSave.UseAccentColor = false;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonCancel.Depth = 0;
            this.buttonCancel.HighEmphasis = false;
            this.buttonCancel.Icon = null;
            this.buttonCancel.Location = new System.Drawing.Point(405, 390);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonCancel.Size = new System.Drawing.Size(77, 36);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.buttonCancel.UseAccentColor = false;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelFirstNameError
            // 
            this.labelFirstNameError.AutoSize = true;
            this.labelFirstNameError.Location = new System.Drawing.Point(26, 138);
            this.labelFirstNameError.Name = "labelFirstNameError";
            this.labelFirstNameError.Size = new System.Drawing.Size(10, 15);
            this.labelFirstNameError.TabIndex = 10;
            this.labelFirstNameError.Text = " ";
            // 
            // labelLastNameError
            // 
            this.labelLastNameError.AutoSize = true;
            this.labelLastNameError.Location = new System.Drawing.Point(266, 138);
            this.labelLastNameError.Name = "labelLastNameError";
            this.labelLastNameError.Size = new System.Drawing.Size(10, 15);
            this.labelLastNameError.TabIndex = 11;
            this.labelLastNameError.Text = " ";
            // 
            // labelContactError
            // 
            this.labelContactError.AutoSize = true;
            this.labelContactError.Location = new System.Drawing.Point(26, 288);
            this.labelContactError.Name = "labelContactError";
            this.labelContactError.Size = new System.Drawing.Size(10, 15);
            this.labelContactError.TabIndex = 13;
            this.labelContactError.Text = " ";
            // 
            // labelLicenseError
            // 
            this.labelLicenseError.AutoSize = true;
            this.labelLicenseError.Location = new System.Drawing.Point(26, 363);
            this.labelLicenseError.Name = "labelLicenseError";
            this.labelLicenseError.Size = new System.Drawing.Size(10, 15);
            this.labelLicenseError.TabIndex = 14;
            this.labelLicenseError.Text = " ";
            // 
            // AddEditEmployeeForm
            // 
            this.ClientSize = new System.Drawing.Size(510, 450);
            this.Controls.Add(this.labelLicenseError);
            this.Controls.Add(this.labelContactError);
            this.Controls.Add(this.labelLastNameError);
            this.Controls.Add(this.labelFirstNameError);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxPosition);
            this.Controls.Add(this.textBoxLicense);
            this.Controls.Add(this.textBoxContact);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditEmployeeForm";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Employee";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private MaterialSkin.Controls.MaterialTextBox textBoxFirstName;
        private MaterialSkin.Controls.MaterialTextBox textBoxLastName;
        private MaterialSkin.Controls.MaterialTextBox textBoxContact;
        private MaterialSkin.Controls.MaterialTextBox textBoxLicense;
        private MaterialSkin.Controls.MaterialComboBox comboBoxPosition;
        private MaterialSkin.Controls.MaterialButton buttonSave;
        private MaterialSkin.Controls.MaterialButton buttonCancel;
        private System.Windows.Forms.Label labelFirstNameError;
        private System.Windows.Forms.Label labelLastNameError;
        private System.Windows.Forms.Label labelContactError;
        private System.Windows.Forms.Label labelLicenseError;
    }
}