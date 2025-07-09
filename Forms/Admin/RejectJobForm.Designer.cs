namespace eshift_management.Forms
{
    partial class RejectJobForm
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
            this.textBoxReason = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.buttonReject = new MaterialSkin.Controls.MaterialButton();
            this.buttonCancel = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // textBoxReason
            // 
            this.textBoxReason.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxReason.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxReason.Depth = 0;
            this.textBoxReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxReason.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBoxReason.Hint = "Reason for Rejection";
            this.textBoxReason.Location = new System.Drawing.Point(25, 85);
            this.textBoxReason.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxReason.Name = "textBoxReason";
            this.textBoxReason.Size = new System.Drawing.Size(350, 100);
            this.textBoxReason.TabIndex = 0;
            this.textBoxReason.Text = "";
            // 
            // buttonReject
            // 
            this.buttonReject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReject.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonReject.Depth = 0;
            this.buttonReject.HighEmphasis = true;
            this.buttonReject.Icon = null;
            this.buttonReject.Location = new System.Drawing.Point(210, 200);
            this.buttonReject.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonReject.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonReject.Size = new System.Drawing.Size(70, 36);
            this.buttonReject.TabIndex = 2;
            this.buttonReject.Text = "Reject";
            this.buttonReject.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonReject.UseAccentColor = true;
            this.buttonReject.UseVisualStyleBackColor = true;
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonCancel.Depth = 0;
            this.buttonCancel.HighEmphasis = false;
            this.buttonCancel.Icon = null;
            this.buttonCancel.Location = new System.Drawing.Point(288, 200);
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
            // RejectJobForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 260);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonReject);
            this.Controls.Add(this.textBoxReason);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RejectJobForm";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reject Job";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private MaterialSkin.Controls.MaterialMultiLineTextBox textBoxReason;
        private MaterialSkin.Controls.MaterialButton buttonReject;
        private MaterialSkin.Controls.MaterialButton buttonCancel;
    }
}