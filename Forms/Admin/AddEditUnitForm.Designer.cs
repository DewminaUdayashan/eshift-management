namespace eshift_management
{
    partial class AddEditUnitForm
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
            this.textBoxUnitName = new MaterialSkin.Controls.MaterialTextBox();
            this.comboBoxTruck = new MaterialSkin.Controls.MaterialComboBox();
            this.comboBoxDriver = new MaterialSkin.Controls.MaterialComboBox();
            this.comboBoxAssistant = new MaterialSkin.Controls.MaterialComboBox();
            this.buttonSave = new MaterialSkin.Controls.MaterialButton();
            this.buttonCancel = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // textBoxUnitName
            // 
            this.textBoxUnitName.AnimateReadOnly = false;
            this.textBoxUnitName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUnitName.Depth = 0;
            this.textBoxUnitName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxUnitName.Hint = "Unit Name (e.g., Team Alpha)";
            this.textBoxUnitName.LeadingIcon = null;
            this.textBoxUnitName.Location = new System.Drawing.Point(25, 85);
            this.textBoxUnitName.MaxLength = 50;
            this.textBoxUnitName.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxUnitName.Multiline = false;
            this.textBoxUnitName.Name = "textBoxUnitName";
            this.textBoxUnitName.Size = new System.Drawing.Size(460, 50);
            this.textBoxUnitName.TabIndex = 0;
            this.textBoxUnitName.Text = "";
            this.textBoxUnitName.TrailingIcon = null;
            // 
            // comboBoxTruck
            // 
            this.comboBoxTruck.AutoResize = false;
            this.comboBoxTruck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxTruck.Depth = 0;
            this.comboBoxTruck.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxTruck.DropDownHeight = 174;
            this.comboBoxTruck.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTruck.DropDownWidth = 121;
            this.comboBoxTruck.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxTruck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxTruck.FormattingEnabled = true;
            this.comboBoxTruck.Hint = "Select a Truck";
            this.comboBoxTruck.IntegralHeight = false;
            this.comboBoxTruck.ItemHeight = 43;
            this.comboBoxTruck.Location = new System.Drawing.Point(25, 160);
            this.comboBoxTruck.MaxDropDownItems = 4;
            this.comboBoxTruck.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxTruck.Name = "comboBoxTruck";
            this.comboBoxTruck.Size = new System.Drawing.Size(460, 49);
            this.comboBoxTruck.StartIndex = 0;
            this.comboBoxTruck.TabIndex = 1;
            // 
            // comboBoxDriver
            // 
            this.comboBoxDriver.AutoResize = false;
            this.comboBoxDriver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxDriver.Depth = 0;
            this.comboBoxDriver.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxDriver.DropDownHeight = 174;
            this.comboBoxDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDriver.DropDownWidth = 121;
            this.comboBoxDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxDriver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxDriver.FormattingEnabled = true;
            this.comboBoxDriver.Hint = "Select a Driver";
            this.comboBoxDriver.IntegralHeight = false;
            this.comboBoxDriver.ItemHeight = 43;
            this.comboBoxDriver.Location = new System.Drawing.Point(25, 235);
            this.comboBoxDriver.MaxDropDownItems = 4;
            this.comboBoxDriver.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxDriver.Name = "comboBoxDriver";
            this.comboBoxDriver.Size = new System.Drawing.Size(460, 49);
            this.comboBoxDriver.StartIndex = 0;
            this.comboBoxDriver.TabIndex = 2;
            // 
            // comboBoxAssistant
            // 
            this.comboBoxAssistant.AutoResize = false;
            this.comboBoxAssistant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxAssistant.Depth = 0;
            this.comboBoxAssistant.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxAssistant.DropDownHeight = 174;
            this.comboBoxAssistant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAssistant.DropDownWidth = 121;
            this.comboBoxAssistant.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxAssistant.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxAssistant.FormattingEnabled = true;
            this.comboBoxAssistant.Hint = "Select an Assistant";
            this.comboBoxAssistant.IntegralHeight = false;
            this.comboBoxAssistant.ItemHeight = 43;
            this.comboBoxAssistant.Location = new System.Drawing.Point(25, 310);
            this.comboBoxAssistant.MaxDropDownItems = 4;
            this.comboBoxAssistant.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxAssistant.Name = "comboBoxAssistant";
            this.comboBoxAssistant.Size = new System.Drawing.Size(460, 49);
            this.comboBoxAssistant.StartIndex = 0;
            this.comboBoxAssistant.TabIndex = 3;
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSave.Depth = 0;
            this.buttonSave.HighEmphasis = true;
            this.buttonSave.Icon = null;
            this.buttonSave.Location = new System.Drawing.Point(340, 385);
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
            this.buttonCancel.Location = new System.Drawing.Point(405, 385);
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
            // AddEditUnitForm
            // 
            this.ClientSize = new System.Drawing.Size(510, 450);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxAssistant);
            this.Controls.Add(this.comboBoxDriver);
            this.Controls.Add(this.comboBoxTruck);
            this.Controls.Add(this.textBoxUnitName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditUnitForm";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Transport Unit";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private MaterialSkin.Controls.MaterialTextBox textBoxUnitName;
        private MaterialSkin.Controls.MaterialComboBox comboBoxTruck;
        private MaterialSkin.Controls.MaterialComboBox comboBoxDriver;
        private MaterialSkin.Controls.MaterialComboBox comboBoxAssistant;
        private MaterialSkin.Controls.MaterialButton buttonSave;
        private MaterialSkin.Controls.MaterialButton buttonCancel;
    }
}