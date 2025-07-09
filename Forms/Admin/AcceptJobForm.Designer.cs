namespace eshift_management.Forms
{
    partial class AcceptJobForm
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
            this.textBoxCost = new MaterialSkin.Controls.MaterialTextBox();
            this.textBoxHours = new MaterialSkin.Controls.MaterialTextBox();
            this.buttonSave = new MaterialSkin.Controls.MaterialButton();
            this.buttonCancel = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // textBoxCost
            // 
            this.textBoxCost.AnimateReadOnly = false;
            this.textBoxCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCost.Depth = 0;
            this.textBoxCost.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxCost.Hint = "Total Cost (LKR)";
            this.textBoxCost.LeadingIcon = null;
            this.textBoxCost.Location = new System.Drawing.Point(25, 85);
            this.textBoxCost.MaxLength = 50;
            this.textBoxCost.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxCost.Multiline = false;
            this.textBoxCost.Name = "textBoxCost";
            this.textBoxCost.Size = new System.Drawing.Size(350, 50);
            this.textBoxCost.TabIndex = 0;
            this.textBoxCost.Text = "";
            this.textBoxCost.TrailingIcon = null;
            // 
            // textBoxHours
            // 
            this.textBoxHours.AnimateReadOnly = false;
            this.textBoxHours.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxHours.Depth = 0;
            this.textBoxHours.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxHours.Hint = "Estimated Hours";
            this.textBoxHours.LeadingIcon = null;
            this.textBoxHours.Location = new System.Drawing.Point(25, 150);
            this.textBoxHours.MaxLength = 50;
            this.textBoxHours.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxHours.Multiline = false;
            this.textBoxHours.Name = "textBoxHours";
            this.textBoxHours.Size = new System.Drawing.Size(350, 50);
            this.textBoxHours.TabIndex = 1;
            this.textBoxHours.Text = "";
            this.textBoxHours.TrailingIcon = null;
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSave.Depth = 0;
            this.buttonSave.HighEmphasis = true;
            this.buttonSave.Icon = null;
            this.buttonSave.Location = new System.Drawing.Point(220, 220);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonSave.Size = new System.Drawing.Size(73, 36);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Accept";
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
            this.buttonCancel.Location = new System.Drawing.Point(300, 220);
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
            // AcceptJobForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxHours);
            this.Controls.Add(this.textBoxCost);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AcceptJobForm";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Accept Job";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private MaterialSkin.Controls.MaterialTextBox textBoxCost;
        private MaterialSkin.Controls.MaterialTextBox textBoxHours;
        private MaterialSkin.Controls.MaterialButton buttonSave;
        private MaterialSkin.Controls.MaterialButton buttonCancel;
    }
}