namespace eshift_management
{
    partial class AddEditTruckForm
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
            this.textBoxModel = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxLicensePlate = new MaterialSkin.Controls.MaterialTextBox();
            this.buttonSave = new MaterialSkin.Controls.MaterialButton();
            this.buttonCancel = new MaterialSkin.Controls.MaterialButton();
            this.labelModelError = new System.Windows.Forms.Label();
            this.labelLicensePlateError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxModel
            // 
            this.textBoxModel.AnimateReadOnly = false;
            this.textBoxModel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxModel.Depth = 0;
            this.textBoxModel.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxModel.Hint = "Truck Model (e.g., Isuzu Elf)";
            this.textBoxModel.LeadingIcon = null;
            this.textBoxModel.Location = new System.Drawing.Point(25, 85);
            this.textBoxModel.MaxLength = 50;
            this.textBoxModel.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxModel.Multiline = false;
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(460, 50);
            this.textBoxModel.TabIndex = 0;
            this.textBoxModel.Text = "";
            this.textBoxModel.TrailingIcon = null;
            // 
            // textBoxLicensePlate
            // 
            this.textBoxLicensePlate.AnimateReadOnly = false;
            this.textBoxLicensePlate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLicensePlate.Depth = 0;
            this.textBoxLicensePlate.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxLicensePlate.Hint = "License Plate";
            this.textBoxLicensePlate.LeadingIcon = null;
            this.textBoxLicensePlate.Location = new System.Drawing.Point(25, 160);
            this.textBoxLicensePlate.MaxLength = 50;
            this.textBoxLicensePlate.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxLicensePlate.Multiline = false;
            this.textBoxLicensePlate.Name = "textBoxLicensePlate";
            this.textBoxLicensePlate.Size = new System.Drawing.Size(460, 50);
            this.textBoxLicensePlate.TabIndex = 1;
            this.textBoxLicensePlate.Text = "";
            this.textBoxLicensePlate.TrailingIcon = null;
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSave.Depth = 0;
            this.buttonSave.HighEmphasis = true;
            this.buttonSave.Icon = null;
            this.buttonSave.Location = new System.Drawing.Point(340, 245);
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
            this.buttonCancel.Location = new System.Drawing.Point(405, 245);
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
            // labelModelError
            // 
            this.labelModelError.AutoSize = true;
            this.labelModelError.Location = new System.Drawing.Point(26, 138);
            this.labelModelError.Name = "labelModelError";
            this.labelModelError.Size = new System.Drawing.Size(10, 15);
            this.labelModelError.TabIndex = 10;
            this.labelModelError.Text = " ";
            // 
            // labelLicensePlateError
            // 
            this.labelLicensePlateError.AutoSize = true;
            this.labelLicensePlateError.Location = new System.Drawing.Point(26, 213);
            this.labelLicensePlateError.Name = "labelLicensePlateError";
            this.labelLicensePlateError.Size = new System.Drawing.Size(10, 15);
            this.labelLicensePlateError.TabIndex = 11;
            this.labelLicensePlateError.Text = " ";
            // 
            // AddEditTruckForm
            // 
            this.ClientSize = new System.Drawing.Size(510, 300);
            this.Controls.Add(this.labelLicensePlateError);
            this.Controls.Add(this.labelModelError);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxLicensePlate);
            this.Controls.Add(this.textBoxModel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditTruckForm";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Truck";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private MaterialSkin.Controls.MaterialTextBox textBoxModel;
        private MaterialSkin.Controls.MaterialTextBox textBoxLicensePlate;
        private MaterialSkin.Controls.MaterialButton buttonSave;
        private MaterialSkin.Controls.MaterialButton buttonCancel;
        private System.Windows.Forms.Label labelModelError;
        private System.Windows.Forms.Label labelLicensePlateError;
    }
}