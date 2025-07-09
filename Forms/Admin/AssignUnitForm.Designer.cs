namespace eshift_management.Forms
{
    partial class AssignUnitForm
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
            this.comboBoxUnits = new MaterialSkin.Controls.MaterialComboBox();
            this.buttonAssign = new MaterialSkin.Controls.MaterialButton();
            this.buttonCancel = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // comboBoxUnits
            // 
            this.comboBoxUnits.AutoResize = false;
            this.comboBoxUnits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxUnits.Depth = 0;
            this.comboBoxUnits.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxUnits.DropDownHeight = 174;
            this.comboBoxUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUnits.DropDownWidth = 121;
            this.comboBoxUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxUnits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxUnits.FormattingEnabled = true;
            this.comboBoxUnits.Hint = "Select an Available Unit";
            this.comboBoxUnits.IntegralHeight = false;
            this.comboBoxUnits.ItemHeight = 43;
            this.comboBoxUnits.Location = new System.Drawing.Point(25, 85);
            this.comboBoxUnits.MaxDropDownItems = 4;
            this.comboBoxUnits.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxUnits.Name = "comboBoxUnits";
            this.comboBoxUnits.Size = new System.Drawing.Size(350, 49);
            this.comboBoxUnits.StartIndex = 0;
            this.comboBoxUnits.TabIndex = 0;
            // 
            // buttonAssign
            // 
            this.buttonAssign.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAssign.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonAssign.Depth = 0;
            this.buttonAssign.HighEmphasis = true;
            this.buttonAssign.Icon = null;
            this.buttonAssign.Location = new System.Drawing.Point(220, 155);
            this.buttonAssign.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAssign.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAssign.Name = "buttonAssign";
            this.buttonAssign.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonAssign.Size = new System.Drawing.Size(73, 36);
            this.buttonAssign.TabIndex = 2;
            this.buttonAssign.Text = "Assign";
            this.buttonAssign.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonAssign.UseAccentColor = false;
            this.buttonAssign.UseVisualStyleBackColor = true;
            this.buttonAssign.Click += new System.EventHandler(this.buttonAssign_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonCancel.Depth = 0;
            this.buttonCancel.HighEmphasis = false;
            this.buttonCancel.Icon = null;
            this.buttonCancel.Location = new System.Drawing.Point(300, 155);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonCancel.Size = new System.Drawing.Size(77, 36);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.buttonCancel.UseAccentColor = false;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // AssignUnitForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 215);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAssign);
            this.Controls.Add(this.comboBoxUnits);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignUnitForm";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assign Transport Unit";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private MaterialSkin.Controls.MaterialComboBox comboBoxUnits;
        private MaterialSkin.Controls.MaterialButton buttonAssign;
        private MaterialSkin.Controls.MaterialButton buttonCancel;
    }
}