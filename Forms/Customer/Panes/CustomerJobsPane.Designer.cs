namespace eshift_management.Panes
{
    partial class CustomerJobsPane
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewJobs = new System.Windows.Forms.DataGridView();
            this.labelDetailsTitle = new MaterialSkin.Controls.MaterialLabel();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.labelStatus = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.labelDropoff = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.labelPickup = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.panelActions = new System.Windows.Forms.Panel();
            this.buttonEditJob = new MaterialSkin.Controls.MaterialButton();
            this.buttonViewInvoice = new MaterialSkin.Controls.MaterialButton();
            this.buttonAddNewJob = new MaterialSkin.Controls.MaterialButton();
            this.panelEmptyState = new System.Windows.Forms.Panel();
            this.pictureBoxEmptyState = new System.Windows.Forms.PictureBox();
            this.labelEmptyState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).BeginInit();
            this.panelDetails.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.panelEmptyState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmptyState)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(154, 45);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "My Jobs";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(28, 80);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewJobs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelDetailsTitle);
            this.splitContainer1.Panel2.Controls.Add(this.panelDetails);
            this.splitContainer1.Panel2.Controls.Add(this.panelActions);
            this.splitContainer1.Size = new System.Drawing.Size(840, 550);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 5;
            // 
            // dataGridViewJobs
            // 
            this.dataGridViewJobs.AllowUserToAddRows = false;
            this.dataGridViewJobs.AllowUserToDeleteRows = false;
            this.dataGridViewJobs.AllowUserToResizeRows = false;
            this.dataGridViewJobs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewJobs.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewJobs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewJobs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewJobs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewJobs.EnableHeadersVisualStyles = false;
            this.dataGridViewJobs.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewJobs.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewJobs.MultiSelect = false;
            this.dataGridViewJobs.Name = "dataGridViewJobs";
            this.dataGridViewJobs.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewJobs.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewJobs.RowHeadersVisible = false;
            this.dataGridViewJobs.RowTemplate.Height = 40;
            this.dataGridViewJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewJobs.Size = new System.Drawing.Size(380, 550);
            this.dataGridViewJobs.TabIndex = 1;
            this.dataGridViewJobs.SelectionChanged += new System.EventHandler(this.dataGridViewJobs_SelectionChanged);
            // 
            // labelDetailsTitle
            // 
            this.labelDetailsTitle.Depth = 0;
            this.labelDetailsTitle.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelDetailsTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.labelDetailsTitle.Location = new System.Drawing.Point(13, 11);
            this.labelDetailsTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelDetailsTitle.Name = "labelDetailsTitle";
            this.labelDetailsTitle.Size = new System.Drawing.Size(420, 29);
            this.labelDetailsTitle.TabIndex = 2;
            this.labelDetailsTitle.Text = "Select a job to see details";
            // 
            // panelDetails
            // 
            this.panelDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetails.Controls.Add(this.labelStatus);
            this.panelDetails.Controls.Add(this.materialLabel2);
            this.panelDetails.Controls.Add(this.labelDropoff);
            this.panelDetails.Controls.Add(this.materialLabel5);
            this.panelDetails.Controls.Add(this.labelPickup);
            this.panelDetails.Controls.Add(this.materialLabel3);
            this.panelDetails.Location = new System.Drawing.Point(10, 55);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(433, 434);
            this.panelDetails.TabIndex = 3;
            this.panelDetails.Visible = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Depth = 0;
            this.labelStatus.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelStatus.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.labelStatus.Location = new System.Drawing.Point(130, 40);
            this.labelStatus.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(1, 0);
            this.labelStatus.TabIndex = 5;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(6, 40);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(50, 19);
            this.materialLabel2.TabIndex = 4;
            this.materialLabel2.Text = "Status:";
            // 
            // labelDropoff
            // 
            this.labelDropoff.AutoSize = true;
            this.labelDropoff.Depth = 0;
            this.labelDropoff.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelDropoff.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.labelDropoff.Location = new System.Drawing.Point(130, 120);
            this.labelDropoff.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelDropoff.Name = "labelDropoff";
            this.labelDropoff.Size = new System.Drawing.Size(1, 0);
            this.labelDropoff.TabIndex = 3;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel5.Location = new System.Drawing.Point(6, 120);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(58, 19);
            this.materialLabel5.TabIndex = 2;
            this.materialLabel5.Text = "Dropoff:";
            // 
            // labelPickup
            // 
            this.labelPickup.AutoSize = true;
            this.labelPickup.Depth = 0;
            this.labelPickup.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelPickup.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.labelPickup.Location = new System.Drawing.Point(130, 80);
            this.labelPickup.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelPickup.Name = "labelPickup";
            this.labelPickup.Size = new System.Drawing.Size(1, 0);
            this.labelPickup.TabIndex = 1;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel3.Location = new System.Drawing.Point(6, 80);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(51, 19);
            this.materialLabel3.TabIndex = 0;
            this.materialLabel3.Text = "Pickup:";
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.buttonEditJob);
            this.panelActions.Controls.Add(this.buttonViewInvoice);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 495);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(456, 55);
            this.panelActions.TabIndex = 4;
            this.panelActions.Visible = false;
            // 
            // buttonEditJob
            // 
            this.buttonEditJob.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonEditJob.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonEditJob.Depth = 0;
            this.buttonEditJob.HighEmphasis = true;
            this.buttonEditJob.Icon = null;
            this.buttonEditJob.Location = new System.Drawing.Point(10, 10);
            this.buttonEditJob.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonEditJob.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonEditJob.Name = "buttonEditJob";
            this.buttonEditJob.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonEditJob.Size = new System.Drawing.Size(81, 36);
            this.buttonEditJob.TabIndex = 0;
            this.buttonEditJob.Text = "Edit Job";
            this.buttonEditJob.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonEditJob.UseAccentColor = false;
            this.buttonEditJob.UseVisualStyleBackColor = true;
            this.buttonEditJob.Click += new System.EventHandler(this.buttonEditJob_Click);
            // 
            // buttonViewInvoice
            // 
            this.buttonViewInvoice.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonViewInvoice.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonViewInvoice.Depth = 0;
            this.buttonViewInvoice.HighEmphasis = true;
            this.buttonViewInvoice.Icon = null;
            this.buttonViewInvoice.Location = new System.Drawing.Point(10, 10);
            this.buttonViewInvoice.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonViewInvoice.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonViewInvoice.Name = "buttonViewInvoice";
            this.buttonViewInvoice.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonViewInvoice.Size = new System.Drawing.Size(117, 36);
            this.buttonViewInvoice.TabIndex = 1;
            this.buttonViewInvoice.Text = "View Invoice";
            this.buttonViewInvoice.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonViewInvoice.UseAccentColor = false;
            this.buttonViewInvoice.UseVisualStyleBackColor = true;
            this.buttonViewInvoice.Click += new System.EventHandler(this.buttonViewInvoice_Click);
            // 
            // buttonAddNewJob
            // 
            this.buttonAddNewJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddNewJob.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddNewJob.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonAddNewJob.Depth = 0;
            this.buttonAddNewJob.HighEmphasis = true;
            this.buttonAddNewJob.Icon = null;
            this.buttonAddNewJob.Location = new System.Drawing.Point(731, 28);
            this.buttonAddNewJob.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAddNewJob.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddNewJob.Name = "buttonAddNewJob";
            this.buttonAddNewJob.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonAddNewJob.Size = new System.Drawing.Size(137, 36);
            this.buttonAddNewJob.TabIndex = 5;
            this.buttonAddNewJob.Text = "Place New Job";
            this.buttonAddNewJob.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonAddNewJob.UseAccentColor = false;
            this.buttonAddNewJob.UseVisualStyleBackColor = true;
            this.buttonAddNewJob.Click += new System.EventHandler(this.buttonAddNewJob_Click);
            // 
            // panelEmptyState
            // 
            this.panelEmptyState.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelEmptyState.Controls.Add(this.labelEmptyState);
            this.panelEmptyState.Controls.Add(this.pictureBoxEmptyState);
            this.panelEmptyState.Location = new System.Drawing.Point(285, 250);
            this.panelEmptyState.Name = "panelEmptyState";
            this.panelEmptyState.Size = new System.Drawing.Size(326, 200);
            this.panelEmptyState.TabIndex = 6;
            this.panelEmptyState.Visible = false;
            // 
            // pictureBoxEmptyState
            // 
            this.pictureBoxEmptyState.Image = global::eshift_management.Properties.Resources.empty_box;
            this.pictureBoxEmptyState.Location = new System.Drawing.Point(99, 15);
            this.pictureBoxEmptyState.Name = "pictureBoxEmptyState";
            this.pictureBoxEmptyState.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxEmptyState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEmptyState.TabIndex = 0;
            this.pictureBoxEmptyState.TabStop = false;
            // 
            // labelEmptyState
            // 
            this.labelEmptyState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelEmptyState.ForeColor = System.Drawing.Color.Gray;
            this.labelEmptyState.Location = new System.Drawing.Point(3, 155);
            this.labelEmptyState.Name = "labelEmptyState";
            this.labelEmptyState.Size = new System.Drawing.Size(320, 45);
            this.labelEmptyState.TabIndex = 1;
            this.labelEmptyState.Text = "You haven\'t placed any jobs yet. Get started by clicking \'Place New Job\'!";
            this.labelEmptyState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomerJobsPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.buttonAddNewJob);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panelEmptyState);
            this.Name = "CustomerJobsPane";
            this.Size = new System.Drawing.Size(898, 653);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.panelActions.PerformLayout();
            this.panelEmptyState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmptyState)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewJobs;
        private MaterialSkin.Controls.MaterialLabel labelDetailsTitle;
        private System.Windows.Forms.Panel panelDetails;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel labelPickup;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel labelDropoff;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel labelStatus;
        private System.Windows.Forms.Panel panelActions;
        private MaterialSkin.Controls.MaterialButton buttonEditJob;
        private MaterialSkin.Controls.MaterialButton buttonViewInvoice;
        private MaterialSkin.Controls.MaterialButton buttonAddNewJob;
        private System.Windows.Forms.Panel panelEmptyState;
        private System.Windows.Forms.PictureBox pictureBoxEmptyState;
        private System.Windows.Forms.Label labelEmptyState;
    }
}