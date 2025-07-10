namespace eshift_management.Forms
{
    partial class PlaceJobForm
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
            this.buttonSubmit = new MaterialSkin.Controls.MaterialButton();
            this.buttonCancel = new MaterialSkin.Controls.MaterialButton();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.textBoxPickupAddress = new MaterialSkin.Controls.MaterialTextBox();
            this.checkBoxUseProfileAddress = new MaterialSkin.Controls.MaterialCheckbox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard2 = new MaterialSkin.Controls.MaterialCard();
            this.textBoxDropoffAddress = new MaterialSkin.Controls.MaterialTextBox();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialCard3 = new MaterialSkin.Controls.MaterialCard();
            this.dateTimePickerPickup = new System.Windows.Forms.DateTimePicker();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.comboBoxLoadSize = new MaterialSkin.Controls.MaterialComboBox();
            this.textBoxDescription = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialCard1.SuspendLayout();
            this.materialCard2.SuspendLayout();
            this.materialCard3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSubmit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSubmit.Depth = 0;
            this.buttonSubmit.HighEmphasis = true;
            this.buttonSubmit.Icon = null;
            this.buttonSubmit.Location = new System.Drawing.Point(540, 495);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSubmit.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonSubmit.Size = new System.Drawing.Size(102, 36);
            this.buttonSubmit.TabIndex = 9;
            this.buttonSubmit.Text = "Submit Job";
            this.buttonSubmit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonSubmit.UseAccentColor = false;
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonCancel.Depth = 0;
            this.buttonCancel.HighEmphasis = false;
            this.buttonCancel.Icon = null;
            this.buttonCancel.Location = new System.Drawing.Point(650, 495);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonCancel.Size = new System.Drawing.Size(77, 36);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.buttonCancel.UseAccentColor = false;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Controls.Add(this.textBoxPickupAddress);
            this.materialCard1.Controls.Add(this.checkBoxUseProfileAddress);
            this.materialCard1.Controls.Add(this.materialLabel1);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(25, 85);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(340, 150);
            this.materialCard1.TabIndex = 11;
            // 
            // textBoxPickupAddress
            // 
            this.textBoxPickupAddress.AnimateReadOnly = false;
            this.textBoxPickupAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPickupAddress.Depth = 0;
            this.textBoxPickupAddress.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxPickupAddress.Hint = "Pickup Address";
            this.textBoxPickupAddress.LeadingIcon = null;
            this.textBoxPickupAddress.Location = new System.Drawing.Point(17, 80);
            this.textBoxPickupAddress.MaxLength = 100;
            this.textBoxPickupAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxPickupAddress.Multiline = false;
            this.textBoxPickupAddress.Name = "textBoxPickupAddress";
            this.textBoxPickupAddress.Size = new System.Drawing.Size(306, 50);
            this.textBoxPickupAddress.TabIndex = 2;
            this.textBoxPickupAddress.Text = "";
            this.textBoxPickupAddress.TrailingIcon = null;
            // 
            // checkBoxUseProfileAddress
            // 
            this.checkBoxUseProfileAddress.AutoSize = true;
            this.checkBoxUseProfileAddress.Depth = 0;
            this.checkBoxUseProfileAddress.Location = new System.Drawing.Point(14, 40);
            this.checkBoxUseProfileAddress.Margin = new System.Windows.Forms.Padding(0);
            this.checkBoxUseProfileAddress.MouseLocation = new System.Drawing.Point(-1, -1);
            this.checkBoxUseProfileAddress.MouseState = MaterialSkin.MouseState.HOVER;
            this.checkBoxUseProfileAddress.Name = "checkBoxUseProfileAddress";
            this.checkBoxUseProfileAddress.ReadOnly = false;
            this.checkBoxUseProfileAddress.Ripple = true;
            this.checkBoxUseProfileAddress.Size = new System.Drawing.Size(201, 37);
            this.checkBoxUseProfileAddress.TabIndex = 1;
            this.checkBoxUseProfileAddress.Text = "Use my profile address";
            this.checkBoxUseProfileAddress.UseVisualStyleBackColor = true;
            this.checkBoxUseProfileAddress.CheckedChanged += new System.EventHandler(this.checkBoxUseProfileAddress_CheckedChanged);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(17, 14);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(115, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Pickup Location";
            // 
            // materialCard2
            // 
            this.materialCard2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard2.Controls.Add(this.textBoxDropoffAddress);
            this.materialCard2.Controls.Add(this.materialLabel2);
            this.materialCard2.Depth = 0;
            this.materialCard2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard2.Location = new System.Drawing.Point(389, 85);
            this.materialCard2.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard2.Name = "materialCard2";
            this.materialCard2.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard2.Size = new System.Drawing.Size(340, 150);
            this.materialCard2.TabIndex = 12;
            // 
            // textBoxDropoffAddress
            // 
            this.textBoxDropoffAddress.AnimateReadOnly = false;
            this.textBoxDropoffAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDropoffAddress.Depth = 0;
            this.textBoxDropoffAddress.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxDropoffAddress.Hint = "Drop-off Address";
            this.textBoxDropoffAddress.LeadingIcon = null;
            this.textBoxDropoffAddress.Location = new System.Drawing.Point(17, 80);
            this.textBoxDropoffAddress.MaxLength = 100;
            this.textBoxDropoffAddress.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxDropoffAddress.Multiline = false;
            this.textBoxDropoffAddress.Name = "textBoxDropoffAddress";
            this.textBoxDropoffAddress.Size = new System.Drawing.Size(306, 50);
            this.textBoxDropoffAddress.TabIndex = 2;
            this.textBoxDropoffAddress.Text = "";
            this.textBoxDropoffAddress.TrailingIcon = null;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(17, 14);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(126, 19);
            this.materialLabel2.TabIndex = 0;
            this.materialLabel2.Text = "Drop-off Location";
            // 
            // materialCard3
            // 
            this.materialCard3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard3.Controls.Add(this.dateTimePickerPickup);
            this.materialCard3.Controls.Add(this.materialLabel3);
            this.materialCard3.Controls.Add(this.comboBoxLoadSize);
            this.materialCard3.Controls.Add(this.textBoxDescription);
            this.materialCard3.Depth = 0;
            this.materialCard3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard3.Location = new System.Drawing.Point(25, 255);
            this.materialCard3.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard3.Name = "materialCard3";
            this.materialCard3.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard3.Size = new System.Drawing.Size(704, 220);
            this.materialCard3.TabIndex = 13;
            // 
            // dateTimePickerPickup
            // 
            this.dateTimePickerPickup.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.dateTimePickerPickup.Location = new System.Drawing.Point(17, 40);
            this.dateTimePickerPickup.Name = "dateTimePickerPickup";
            this.dateTimePickerPickup.Size = new System.Drawing.Size(280, 29);
            this.dateTimePickerPickup.TabIndex = 3;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(17, 14);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(155, 19);
            this.materialLabel3.TabIndex = 0;
            this.materialLabel3.Text = "Preferred Pickup Date";
            // 
            // comboBoxLoadSize
            // 
            this.comboBoxLoadSize.AutoResize = false;
            this.comboBoxLoadSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxLoadSize.Depth = 0;
            this.comboBoxLoadSize.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxLoadSize.DropDownHeight = 174;
            this.comboBoxLoadSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLoadSize.DropDownWidth = 121;
            this.comboBoxLoadSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxLoadSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxLoadSize.FormattingEnabled = true;
            this.comboBoxLoadSize.Hint = "Estimate Load Size";
            this.comboBoxLoadSize.IntegralHeight = false;
            this.comboBoxLoadSize.ItemHeight = 43;
            this.comboBoxLoadSize.Location = new System.Drawing.Point(320, 30);
            this.comboBoxLoadSize.MaxDropDownItems = 4;
            this.comboBoxLoadSize.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxLoadSize.Name = "comboBoxLoadSize";
            this.comboBoxLoadSize.Size = new System.Drawing.Size(360, 49);
            this.comboBoxLoadSize.StartIndex = 0;
            this.comboBoxLoadSize.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescription.Depth = 0;
            this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBoxDescription.Hint = "Description (optional)";
            this.textBoxDescription.Location = new System.Drawing.Point(17, 95);
            this.textBoxDescription.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(663, 108);
            this.textBoxDescription.TabIndex = 5;
            this.textBoxDescription.Text = "";
            // 
            // PlaceJobForm
            // 
            this.ClientSize = new System.Drawing.Size(754, 553);
            this.Controls.Add(this.materialCard3);
            this.Controls.Add(this.materialCard2);
            this.Controls.Add(this.materialCard1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlaceJobForm";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Place a New Job";
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            this.materialCard2.ResumeLayout(false);
            this.materialCard2.PerformLayout();
            this.materialCard3.ResumeLayout(false);
            this.materialCard3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private MaterialSkin.Controls.MaterialButton buttonSubmit;
        private MaterialSkin.Controls.MaterialButton buttonCancel;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialTextBox textBoxPickupAddress;
        private MaterialSkin.Controls.MaterialCheckbox checkBoxUseProfileAddress;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialCard materialCard2;
        private MaterialSkin.Controls.MaterialTextBox textBoxDropoffAddress;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialCard materialCard3;
        private System.Windows.Forms.DateTimePicker dateTimePickerPickup;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialComboBox comboBoxLoadSize;
        private MaterialSkin.Controls.MaterialMultiLineTextBox textBoxDescription;
    }
}