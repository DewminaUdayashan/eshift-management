namespace eshift_management
{
    partial class CustomerDashboard
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonLogout = new System.Windows.Forms.Button(); // New Logout Button
            this.buttonProfile = new System.Windows.Forms.Button();
            this.buttonMyJobs = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.buttonLogout); // Add button to panel
            this.panelMenu.Controls.Add(this.buttonProfile);
            this.panelMenu.Controls.Add(this.buttonMyJobs);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 64);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 656);
            this.panelMenu.TabIndex = 1;
            // 
            // buttonLogout
            // 
            this.buttonLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonLogout.FlatAppearance.BorderSize = 0;
            this.buttonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonLogout.Location = new System.Drawing.Point(0, 596);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonLogout.Size = new System.Drawing.Size(220, 60);
            this.buttonLogout.TabIndex = 4; // Next tab index
            this.buttonLogout.Text = "  Logout";
            this.buttonLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonProfile
            // 
            this.buttonProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonProfile.FlatAppearance.BorderSize = 0;
            this.buttonProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonProfile.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonProfile.Location = new System.Drawing.Point(0, 140);
            this.buttonProfile.Name = "buttonProfile";
            this.buttonProfile.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonProfile.Size = new System.Drawing.Size(220, 60);
            this.buttonProfile.TabIndex = 3;
            this.buttonProfile.Text = "  My Profile";
            this.buttonProfile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonProfile.UseVisualStyleBackColor = true;
            this.buttonProfile.Click += new System.EventHandler(this.buttonProfile_Click);
            // 
            // buttonMyJobs
            // 
            this.buttonMyJobs.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonMyJobs.FlatAppearance.BorderSize = 0;
            this.buttonMyJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMyJobs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonMyJobs.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonMyJobs.Location = new System.Drawing.Point(0, 80);
            this.buttonMyJobs.Name = "buttonMyJobs";
            this.buttonMyJobs.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.buttonMyJobs.Size = new System.Drawing.Size(220, 60);
            this.buttonMyJobs.TabIndex = 1;
            this.buttonMyJobs.Text = "  My Jobs";
            this.buttonMyJobs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMyJobs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonMyJobs.UseVisualStyleBackColor = true;
            this.buttonMyJobs.Click += new System.EventHandler(this.buttonMyJobs_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBoxLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Image = global::eshift_management.Properties.Resources.e_shift_logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(60, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(100, 55);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(220, 64);
            this.panelMain.Margin = new System.Windows.Forms.Padding(0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(904, 656);
            this.panelMain.TabIndex = 2;
            // 
            // CustomerDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 720);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(960, 600);
            this.Name = "CustomerDashboard";
            this.Padding = new System.Windows.Forms.Padding(0, 64, 0, 0);
            this.Text = "E-Shift Customer Portal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button buttonMyJobs;
        private System.Windows.Forms.Button buttonProfile;
        private System.Windows.Forms.Button buttonLogout; 
    }
}
