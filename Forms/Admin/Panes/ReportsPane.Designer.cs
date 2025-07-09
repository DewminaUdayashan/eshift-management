namespace eshift_management.Panes
{
    partial class ReportsPane
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
            this.panelOptions = new System.Windows.Forms.Panel();
            this.cardRevenue = new MaterialSkin.Controls.MaterialCard();
            this.label6 = new System.Windows.Forms.Label();
            this.cardOngoingJobs = new MaterialSkin.Controls.MaterialCard();
            this.label5 = new System.Windows.Forms.Label();
            this.cardResources = new MaterialSkin.Controls.MaterialCard();
            this.label4 = new System.Windows.Forms.Label();
            this.cardCustomers = new MaterialSkin.Controls.MaterialCard();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.webBrowserPreview = new System.Windows.Forms.WebBrowser();
            this.panelActions = new System.Windows.Forms.Panel();
            this.buttonGenerate = new MaterialSkin.Controls.MaterialButton();
            this.panelOptions.SuspendLayout();
            this.cardRevenue.SuspendLayout();
            this.cardOngoingJobs.SuspendLayout();
            this.cardResources.SuspendLayout();
            this.cardCustomers.SuspendLayout();
            this.panelPreview.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(325, 45);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Generate Reports";
            // 
            // panelOptions
            // 
            this.panelOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOptions.Controls.Add(this.cardRevenue);
            this.panelOptions.Controls.Add(this.cardOngoingJobs);
            this.panelOptions.Controls.Add(this.cardResources);
            this.panelOptions.Controls.Add(this.cardCustomers);
            this.panelOptions.Location = new System.Drawing.Point(28, 80);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(840, 120);
            this.panelOptions.TabIndex = 5;
            // 
            // cardRevenue
            // 
            this.cardRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardRevenue.Controls.Add(this.label6);
            this.cardRevenue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardRevenue.Depth = 0;
            this.cardRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardRevenue.Location = new System.Drawing.Point(630, 10);
            this.cardRevenue.Margin = new System.Windows.Forms.Padding(10);
            this.cardRevenue.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardRevenue.Name = "cardRevenue";
            this.cardRevenue.Padding = new System.Windows.Forms.Padding(14);
            this.cardRevenue.Size = new System.Drawing.Size(200, 100);
            this.cardRevenue.TabIndex = 3;
            this.cardRevenue.Click += new System.EventHandler(this.card_Click);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(14, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(172, 72);
            this.label6.TabIndex = 0;
            this.label6.Text = "Revenue Report";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Click += new System.EventHandler(this.card_Click);
            // 
            // cardOngoingJobs
            // 
            this.cardOngoingJobs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardOngoingJobs.Controls.Add(this.label5);
            this.cardOngoingJobs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardOngoingJobs.Depth = 0;
            this.cardOngoingJobs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardOngoingJobs.Location = new System.Drawing.Point(420, 10);
            this.cardOngoingJobs.Margin = new System.Windows.Forms.Padding(10);
            this.cardOngoingJobs.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardOngoingJobs.Name = "cardOngoingJobs";
            this.cardOngoingJobs.Padding = new System.Windows.Forms.Padding(14);
            this.cardOngoingJobs.Size = new System.Drawing.Size(200, 100);
            this.cardOngoingJobs.TabIndex = 2;
            this.cardOngoingJobs.Click += new System.EventHandler(this.card_Click);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(14, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 72);
            this.label5.TabIndex = 0;
            this.label5.Text = "On-going Jobs Report";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.card_Click);
            // 
            // cardResources
            // 
            this.cardResources.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardResources.Controls.Add(this.label4);
            this.cardResources.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardResources.Depth = 0;
            this.cardResources.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardResources.Location = new System.Drawing.Point(210, 10);
            this.cardResources.Margin = new System.Windows.Forms.Padding(10);
            this.cardResources.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardResources.Name = "cardResources";
            this.cardResources.Padding = new System.Windows.Forms.Padding(14);
            this.cardResources.Size = new System.Drawing.Size(200, 100);
            this.cardResources.TabIndex = 1;
            this.cardResources.Click += new System.EventHandler(this.card_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(14, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 72);
            this.label4.TabIndex = 0;
            this.label4.Text = "Resource Report";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.card_Click);
            // 
            // cardCustomers
            // 
            this.cardCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardCustomers.Controls.Add(this.label3);
            this.cardCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardCustomers.Depth = 0;
            this.cardCustomers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardCustomers.Location = new System.Drawing.Point(0, 10);
            this.cardCustomers.Margin = new System.Windows.Forms.Padding(10);
            this.cardCustomers.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardCustomers.Name = "cardCustomers";
            this.cardCustomers.Padding = new System.Windows.Forms.Padding(14);
            this.cardCustomers.Size = new System.Drawing.Size(200, 100);
            this.cardCustomers.TabIndex = 0;
            this.cardCustomers.Click += new System.EventHandler(this.card_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(14, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 72);
            this.label3.TabIndex = 0;
            this.label3.Text = "Customer Report";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.card_Click);
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPreview.Controls.Add(this.webBrowserPreview);
            this.panelPreview.Location = new System.Drawing.Point(28, 215);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(840, 350);
            this.panelPreview.TabIndex = 6;
            // 
            // webBrowserPreview
            // 
            this.webBrowserPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserPreview.Location = new System.Drawing.Point(0, 0);
            this.webBrowserPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPreview.Name = "webBrowserPreview";
            this.webBrowserPreview.Size = new System.Drawing.Size(838, 348);
            this.webBrowserPreview.TabIndex = 0;
            // 
            // panelActions
            // 
            this.panelActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelActions.Controls.Add(this.buttonGenerate);
            this.panelActions.Location = new System.Drawing.Point(28, 575);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(840, 55);
            this.panelActions.TabIndex = 7;
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonGenerate.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonGenerate.Depth = 0;
            this.buttonGenerate.Enabled = false;
            this.buttonGenerate.HighEmphasis = true;
            this.buttonGenerate.Icon = null;
            this.buttonGenerate.Location = new System.Drawing.Point(610, 9);
            this.buttonGenerate.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonGenerate.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonGenerate.Size = new System.Drawing.Size(206, 36);
            this.buttonGenerate.TabIndex = 0;
            this.buttonGenerate.Text = "Generate && Download";
            this.buttonGenerate.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonGenerate.UseAccentColor = false;
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // ReportsPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.labelTitle);
            this.Name = "ReportsPane";
            this.Size = new System.Drawing.Size(898, 653);
            this.panelOptions.ResumeLayout(false);
            this.cardRevenue.ResumeLayout(false);
            this.cardOngoingJobs.ResumeLayout(false);
            this.cardResources.ResumeLayout(false);
            this.cardCustomers.ResumeLayout(false);
            this.panelPreview.ResumeLayout(false);
            this.panelActions.ResumeLayout(false);
            this.panelActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelOptions;
        private MaterialSkin.Controls.MaterialCard cardCustomers;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialCard cardRevenue;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialCard cardOngoingJobs;
        private System.Windows.Forms.Label label5;
        private MaterialSkin.Controls.MaterialCard cardResources;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.WebBrowser webBrowserPreview;
        private System.Windows.Forms.Panel panelActions;
        private MaterialSkin.Controls.MaterialButton buttonGenerate;
    }
}