namespace eshift_management
{
    partial class DashboardPane
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanelCards = new System.Windows.Forms.FlowLayoutPanel();
            this.panelCardJobs = new System.Windows.Forms.Panel();
            this.labelJobsValue = new System.Windows.Forms.Label();
            this.labelJobsTitle = new System.Windows.Forms.Label();
            this.panelCardTrucks = new System.Windows.Forms.Panel();
            this.labelTrucksValue = new System.Windows.Forms.Label();
            this.labelTrucksTitle = new System.Windows.Forms.Label();
            this.panelCardCustomers = new System.Windows.Forms.Panel();
            this.labelCustomersValue = new System.Windows.Forms.Label();
            this.labelCustomersTitle = new System.Windows.Forms.Label();
            this.panelCardPending = new System.Windows.Forms.Panel();
            this.labelPendingValue = new System.Windows.Forms.Label();
            this.labelPendingTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanelCards.SuspendLayout();
            this.panelCardJobs.SuspendLayout();
            this.panelCardTrucks.SuspendLayout();
            this.panelCardCustomers.SuspendLayout();
            this.panelCardPending.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(195, 45);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Dashboard";
            // 
            // flowLayoutPanelCards
            // 
            this.flowLayoutPanelCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelCards.Controls.Add(this.panelCardJobs);
            this.flowLayoutPanelCards.Controls.Add(this.panelCardTrucks);
            this.flowLayoutPanelCards.Controls.Add(this.panelCardCustomers);
            this.flowLayoutPanelCards.Controls.Add(this.panelCardPending);
            this.flowLayoutPanelCards.Location = new System.Drawing.Point(28, 85);
            this.flowLayoutPanelCards.Name = "flowLayoutPanelCards";
            this.flowLayoutPanelCards.Size = new System.Drawing.Size(840, 540);
            this.flowLayoutPanelCards.TabIndex = 1;
            // 
            // panelCardJobs
            // 
            this.panelCardJobs.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelCardJobs.Controls.Add(this.labelJobsValue);
            this.panelCardJobs.Controls.Add(this.labelJobsTitle);
            this.panelCardJobs.Location = new System.Drawing.Point(10, 10);
            this.panelCardJobs.Margin = new System.Windows.Forms.Padding(10);
            this.panelCardJobs.Name = "panelCardJobs";
            this.panelCardJobs.Size = new System.Drawing.Size(250, 130);
            this.panelCardJobs.TabIndex = 0;
            // 
            // labelJobsValue
            // 
            this.labelJobsValue.AutoSize = true;
            this.labelJobsValue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelJobsValue.ForeColor = System.Drawing.Color.White;
            this.labelJobsValue.Location = new System.Drawing.Point(18, 55);
            this.labelJobsValue.Name = "labelJobsValue";
            this.labelJobsValue.Size = new System.Drawing.Size(66, 51);
            this.labelJobsValue.TabIndex = 1;
            this.labelJobsValue.Text = "12";
            // 
            // labelJobsTitle
            // 
            this.labelJobsTitle.AutoSize = true;
            this.labelJobsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelJobsTitle.ForeColor = System.Drawing.Color.White;
            this.labelJobsTitle.Location = new System.Drawing.Point(20, 20);
            this.labelJobsTitle.Name = "labelJobsTitle";
            this.labelJobsTitle.Size = new System.Drawing.Size(113, 21);
            this.labelJobsTitle.TabIndex = 0;
            this.labelJobsTitle.Text = "Ongoing Jobs";
            // 
            // panelCardTrucks
            // 
            this.panelCardTrucks.BackColor = System.Drawing.Color.SeaGreen;
            this.panelCardTrucks.Controls.Add(this.labelTrucksValue);
            this.panelCardTrucks.Controls.Add(this.labelTrucksTitle);
            this.panelCardTrucks.Location = new System.Drawing.Point(280, 10);
            this.panelCardTrucks.Margin = new System.Windows.Forms.Padding(10);
            this.panelCardTrucks.Name = "panelCardTrucks";
            this.panelCardTrucks.Size = new System.Drawing.Size(250, 130);
            this.panelCardTrucks.TabIndex = 1;
            // 
            // labelTrucksValue
            // 
            this.labelTrucksValue.AutoSize = true;
            this.labelTrucksValue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTrucksValue.ForeColor = System.Drawing.Color.White;
            this.labelTrucksValue.Location = new System.Drawing.Point(18, 55);
            this.labelTrucksValue.Name = "labelTrucksValue";
            this.labelTrucksValue.Size = new System.Drawing.Size(44, 51);
            this.labelTrucksValue.TabIndex = 1;
            this.labelTrucksValue.Text = "8";
            // 
            // labelTrucksTitle
            // 
            this.labelTrucksTitle.AutoSize = true;
            this.labelTrucksTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTrucksTitle.ForeColor = System.Drawing.Color.White;
            this.labelTrucksTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTrucksTitle.Name = "labelTrucksTitle";
            this.labelTrucksTitle.Size = new System.Drawing.Size(126, 21);
            this.labelTrucksTitle.TabIndex = 0;
            this.labelTrucksTitle.Text = "Available Trucks";
            // 
            // panelCardCustomers
            // 
            this.panelCardCustomers.BackColor = System.Drawing.Color.DarkOrange;
            this.panelCardCustomers.Controls.Add(this.labelCustomersValue);
            this.panelCardCustomers.Controls.Add(this.labelCustomersTitle);
            this.panelCardCustomers.Location = new System.Drawing.Point(550, 10);
            this.panelCardCustomers.Margin = new System.Windows.Forms.Padding(10);
            this.panelCardCustomers.Name = "panelCardCustomers";
            this.panelCardCustomers.Size = new System.Drawing.Size(250, 130);
            this.panelCardCustomers.TabIndex = 2;
            // 
            // labelCustomersValue
            // 
            this.labelCustomersValue.AutoSize = true;
            this.labelCustomersValue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCustomersValue.ForeColor = System.Drawing.Color.White;
            this.labelCustomersValue.Location = new System.Drawing.Point(18, 55);
            this.labelCustomersValue.Name = "labelCustomersValue";
            this.labelCustomersValue.Size = new System.Drawing.Size(88, 51);
            this.labelCustomersValue.TabIndex = 1;
            this.labelCustomersValue.Text = "124";
            // 
            // labelCustomersTitle
            // 
            this.labelCustomersTitle.AutoSize = true;
            this.labelCustomersTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCustomersTitle.ForeColor = System.Drawing.Color.White;
            this.labelCustomersTitle.Location = new System.Drawing.Point(20, 20);
            this.labelCustomersTitle.Name = "labelCustomersTitle";
            this.labelCustomersTitle.Size = new System.Drawing.Size(139, 21);
            this.labelCustomersTitle.TabIndex = 0;
            this.labelCustomersTitle.Text = "Active Customers";
            // 
            // panelCardPending
            // 
            this.panelCardPending.BackColor = System.Drawing.Color.IndianRed;
            this.panelCardPending.Controls.Add(this.labelPendingValue);
            this.panelCardPending.Controls.Add(this.labelPendingTitle);
            this.panelCardPending.Location = new System.Drawing.Point(10, 160);
            this.panelCardPending.Margin = new System.Windows.Forms.Padding(10);
            this.panelCardPending.Name = "panelCardPending";
            this.panelCardPending.Size = new System.Drawing.Size(250, 130);
            this.panelCardPending.TabIndex = 3;
            // 
            // labelPendingValue
            // 
            this.labelPendingValue.AutoSize = true;
            this.labelPendingValue.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPendingValue.ForeColor = System.Drawing.Color.White;
            this.labelPendingValue.Location = new System.Drawing.Point(18, 55);
            this.labelPendingValue.Name = "labelPendingValue";
            this.labelPendingValue.Size = new System.Drawing.Size(44, 51);
            this.labelPendingValue.TabIndex = 1;
            this.labelPendingValue.Text = "5";
            // 
            // labelPendingTitle
            // 
            this.labelPendingTitle.AutoSize = true;
            this.labelPendingTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPendingTitle.ForeColor = System.Drawing.Color.White;
            this.labelPendingTitle.Location = new System.Drawing.Point(20, 20);
            this.labelPendingTitle.Name = "labelPendingTitle";
            this.labelPendingTitle.Size = new System.Drawing.Size(109, 21);
            this.labelPendingTitle.TabIndex = 0;
            this.labelPendingTitle.Text = "Pending Jobs";
            // 
            // DashboardPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.flowLayoutPanelCards);
            this.Controls.Add(this.labelTitle);
            this.Name = "DashboardPane";
            this.Size = new System.Drawing.Size(898, 653);
            this.flowLayoutPanelCards.ResumeLayout(false);
            this.panelCardJobs.ResumeLayout(false);
            this.panelCardJobs.PerformLayout();
            this.panelCardTrucks.ResumeLayout(false);
            this.panelCardTrucks.PerformLayout();
            this.panelCardCustomers.ResumeLayout(false);
            this.panelCardCustomers.PerformLayout();
            this.panelCardPending.ResumeLayout(false);
            this.panelCardPending.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCards;
        private System.Windows.Forms.Panel panelCardJobs;
        private System.Windows.Forms.Label labelJobsValue;
        private System.Windows.Forms.Label labelJobsTitle;
        private System.Windows.Forms.Panel panelCardTrucks;
        private System.Windows.Forms.Label labelTrucksValue;
        private System.Windows.Forms.Label labelTrucksTitle;
        private System.Windows.Forms.Panel panelCardCustomers;
        private System.Windows.Forms.Label labelCustomersValue;
        private System.Windows.Forms.Label labelCustomersTitle;
        private System.Windows.Forms.Panel panelCardPending;
        private System.Windows.Forms.Label labelPendingValue;
        private System.Windows.Forms.Label labelPendingTitle;
    }
}