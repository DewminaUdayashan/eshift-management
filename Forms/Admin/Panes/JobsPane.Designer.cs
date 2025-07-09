namespace eshift_management.Panes
{
    partial class JobsPane
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelTitle = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewJobs = new System.Windows.Forms.DataGridView();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.comboBoxStatusFilter = new MaterialSkin.Controls.MaterialComboBox();
            this.panelPlaceholder = new System.Windows.Forms.Panel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.labelAssignedUnit = new MaterialSkin.Controls.MaterialLabel();
            this.labelAssignedUnitValue = new MaterialSkin.Controls.MaterialLabel();
            this.textBoxDescription = new MaterialSkin.Controls.MaterialMultiLineTextBox();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.labelLoadSize = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.labelDropoff = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.labelPickup = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.labelCustomerName = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.panelActions = new System.Windows.Forms.Panel();
            this.buttonReject = new MaterialSkin.Controls.MaterialButton();
            this.buttonAccept = new MaterialSkin.Controls.MaterialButton();
            this.buttonAssignOrChangeUnit = new MaterialSkin.Controls.MaterialButton();
            this.buttonDispatch = new MaterialSkin.Controls.MaterialButton();
            this.buttonComplete = new MaterialSkin.Controls.MaterialButton();
            this.buttonCancel = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.panelPlaceholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelDetails.SuspendLayout();
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
            this.labelTitle.Size = new System.Drawing.Size(298, 45);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Job Management";
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
            this.splitContainer1.Panel1.Controls.Add(this.panelFilters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelDetails);
            this.splitContainer1.Panel2.Controls.Add(this.panelActions);
            this.splitContainer1.Panel2.Controls.Add(this.panelPlaceholder);
            this.splitContainer1.Size = new System.Drawing.Size(840, 550);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 4;
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewJobs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewJobs.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewJobs.EnableHeadersVisualStyles = false;
            this.dataGridViewJobs.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewJobs.Location = new System.Drawing.Point(0, 55);
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
            this.dataGridViewJobs.Size = new System.Drawing.Size(350, 495);
            this.dataGridViewJobs.TabIndex = 0;
            this.dataGridViewJobs.SelectionChanged += new System.EventHandler(this.dataGridViewJobs_SelectionChanged);
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.comboBoxStatusFilter);
            this.panelFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilters.Location = new System.Drawing.Point(0, 0);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(350, 55);
            this.panelFilters.TabIndex = 1;
            // 
            // comboBoxStatusFilter
            // 
            this.comboBoxStatusFilter.AutoResize = false;
            this.comboBoxStatusFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxStatusFilter.Depth = 0;
            this.comboBoxStatusFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxStatusFilter.DropDownHeight = 174;
            this.comboBoxStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStatusFilter.DropDownWidth = 121;
            this.comboBoxStatusFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxStatusFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxStatusFilter.FormattingEnabled = true;
            this.comboBoxStatusFilter.Hint = "Filter by Status";
            this.comboBoxStatusFilter.IntegralHeight = false;
            this.comboBoxStatusFilter.ItemHeight = 43;
            this.comboBoxStatusFilter.Location = new System.Drawing.Point(3, 4);
            this.comboBoxStatusFilter.MaxDropDownItems = 4;
            this.comboBoxStatusFilter.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxStatusFilter.Name = "comboBoxStatusFilter";
            this.comboBoxStatusFilter.Size = new System.Drawing.Size(200, 49);
            this.comboBoxStatusFilter.StartIndex = 0;
            this.comboBoxStatusFilter.TabIndex = 0;
            this.comboBoxStatusFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatusFilter_SelectedIndexChanged);
            // 
            // panelPlaceholder
            // 
            this.panelPlaceholder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelPlaceholder.Controls.Add(this.materialLabel2);
            this.panelPlaceholder.Controls.Add(this.pictureBox1);
            this.panelPlaceholder.Location = new System.Drawing.Point(135, 195);
            this.panelPlaceholder.Name = "panelPlaceholder";
            this.panelPlaceholder.Size = new System.Drawing.Size(220, 150);
            this.panelPlaceholder.TabIndex = 3;
            // 
            // materialLabel2
            // 
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(0, 90);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(220, 60);
            this.materialLabel2.TabIndex = 1;
            this.materialLabel2.Text = "Select a job from the list to view its details and available actions.";
            this.materialLabel2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            //this.pictureBox1.Image = global::eshift_management.Properties.Resources.select_item;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelDetails
            // 
            this.panelDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetails.Controls.Add(this.labelAssignedUnit);
            this.panelDetails.Controls.Add(this.labelAssignedUnitValue);
            this.panelDetails.Controls.Add(this.textBoxDescription);
            this.panelDetails.Controls.Add(this.materialLabel8);
            this.panelDetails.Controls.Add(this.labelLoadSize);
            this.panelDetails.Controls.Add(this.materialLabel7);
            this.panelDetails.Controls.Add(this.labelDropoff);
            this.panelDetails.Controls.Add(this.materialLabel5);
            this.panelDetails.Controls.Add(this.labelPickup);
            this.panelDetails.Controls.Add(this.materialLabel3);
            this.panelDetails.Controls.Add(this.labelCustomerName);
            this.panelDetails.Controls.Add(this.materialLabel1);
            this.panelDetails.Location = new System.Drawing.Point(10, 11);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(463, 478);
            this.panelDetails.TabIndex = 0;
            // 
            // labelAssignedUnit
            // 
            this.labelAssignedUnit.AutoSize = true;
            this.labelAssignedUnit.Depth = 0;
            this.labelAssignedUnit.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.labelAssignedUnit.Location = new System.Drawing.Point(6, 200);
            this.labelAssignedUnit.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelAssignedUnit.Name = "labelAssignedUnit";
            this.labelAssignedUnit.Size = new System.Drawing.Size(102, 19);
            this.labelAssignedUnit.TabIndex = 11;
            this.labelAssignedUnit.Text = "Assigned Unit:";
            // 
            // labelAssignedUnitValue
            // 
            this.labelAssignedUnitValue.AutoSize = true;
            this.labelAssignedUnitValue.Depth = 0;
            this.labelAssignedUnitValue.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelAssignedUnitValue.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.labelAssignedUnitValue.Location = new System.Drawing.Point(130, 200);
            this.labelAssignedUnitValue.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelAssignedUnitValue.Name = "labelAssignedUnitValue";
            this.labelAssignedUnitValue.Size = new System.Drawing.Size(1, 0);
            this.labelAssignedUnitValue.TabIndex = 10;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDescription.Depth = 0;
            this.textBoxDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textBoxDescription.Location = new System.Drawing.Point(6, 260);
            this.textBoxDescription.MouseState = MaterialSkin.MouseState.HOVER;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.Size = new System.Drawing.Size(450, 209);
            this.textBoxDescription.TabIndex = 9;
            this.textBoxDescription.Text = "";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel8.Location = new System.Drawing.Point(6, 235);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(81, 19);
            this.materialLabel8.TabIndex = 8;
            this.materialLabel8.Text = "Description";
            // 
            // labelLoadSize
            // 
            this.labelLoadSize.AutoSize = true;
            this.labelLoadSize.Depth = 0;
            this.labelLoadSize.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelLoadSize.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.labelLoadSize.Location = new System.Drawing.Point(130, 160);
            this.labelLoadSize.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelLoadSize.Name = "labelLoadSize";
            this.labelLoadSize.Size = new System.Drawing.Size(1, 0);
            this.labelLoadSize.TabIndex = 7;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel7.Location = new System.Drawing.Point(6, 160);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(71, 19);
            this.materialLabel7.TabIndex = 6;
            this.materialLabel7.Text = "Load Size:";
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
            this.labelDropoff.TabIndex = 5;
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
            this.materialLabel5.TabIndex = 4;
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
            this.labelPickup.TabIndex = 3;
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
            this.materialLabel3.TabIndex = 2;
            this.materialLabel3.Text = "Pickup:";
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Depth = 0;
            this.labelCustomerName.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.labelCustomerName.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            this.labelCustomerName.Location = new System.Drawing.Point(130, 40);
            this.labelCustomerName.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(1, 0);
            this.labelCustomerName.TabIndex = 1;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(6, 40);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(72, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Customer:";
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.buttonReject);
            this.panelActions.Controls.Add(this.buttonAccept);
            this.panelActions.Controls.Add(this.buttonAssignOrChangeUnit);
            this.panelActions.Controls.Add(this.buttonDispatch);
            this.panelActions.Controls.Add(this.buttonComplete);
            this.panelActions.Controls.Add(this.buttonCancel);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 495);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(486, 55);
            this.panelActions.TabIndex = 2;
            // 
            // buttonReject
            // 
            this.buttonReject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReject.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonReject.Depth = 0;
            this.buttonReject.HighEmphasis = false;
            this.buttonReject.Icon = null;
            this.buttonReject.Location = new System.Drawing.Point(92, 10);
            this.buttonReject.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonReject.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonReject.Name = "buttonReject";
            this.buttonReject.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonReject.Size = new System.Drawing.Size(70, 36);
            this.buttonReject.TabIndex = 1;
            this.buttonReject.Text = "Reject";
            this.buttonReject.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.buttonReject.UseAccentColor = false;
            this.buttonReject.UseVisualStyleBackColor = true;
            this.buttonReject.Click += new System.EventHandler(this.buttonReject_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAccept.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonAccept.Depth = 0;
            this.buttonAccept.HighEmphasis = true;
            this.buttonAccept.Icon = null;
            this.buttonAccept.Location = new System.Drawing.Point(10, 10);
            this.buttonAccept.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAccept.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonAccept.Size = new System.Drawing.Size(73, 36);
            this.buttonAccept.TabIndex = 0;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonAccept.UseAccentColor = false;
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // buttonAssignOrChangeUnit
            // 
            this.buttonAssignOrChangeUnit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAssignOrChangeUnit.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonAssignOrChangeUnit.Depth = 0;
            this.buttonAssignOrChangeUnit.HighEmphasis = true;
            this.buttonAssignOrChangeUnit.Icon = null;
            this.buttonAssignOrChangeUnit.Location = new System.Drawing.Point(10, 10);
            this.buttonAssignOrChangeUnit.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAssignOrChangeUnit.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAssignOrChangeUnit.Name = "buttonAssignOrChangeUnit";
            this.buttonAssignOrChangeUnit.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonAssignOrChangeUnit.Size = new System.Drawing.Size(107, 36);
            this.buttonAssignOrChangeUnit.TabIndex = 2;
            this.buttonAssignOrChangeUnit.Text = "Assign Unit";
            this.buttonAssignOrChangeUnit.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonAssignOrChangeUnit.UseAccentColor = false;
            this.buttonAssignOrChangeUnit.UseVisualStyleBackColor = true;
            this.buttonAssignOrChangeUnit.Click += new System.EventHandler(this.buttonAssignOrChangeUnit_Click);
            // 
            // buttonDispatch
            // 
            this.buttonDispatch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDispatch.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonDispatch.Depth = 0;
            this.buttonDispatch.HighEmphasis = true;
            this.buttonDispatch.Icon = null;
            this.buttonDispatch.Location = new System.Drawing.Point(170, 10);
            this.buttonDispatch.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonDispatch.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonDispatch.Name = "buttonDispatch";
            this.buttonDispatch.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonDispatch.Size = new System.Drawing.Size(89, 36);
            this.buttonDispatch.TabIndex = 3;
            this.buttonDispatch.Text = "Dispatch";
            this.buttonDispatch.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonDispatch.UseAccentColor = false;
            this.buttonDispatch.UseVisualStyleBackColor = true;
            this.buttonDispatch.Click += new System.EventHandler(this.buttonDispatch_Click);
            // 
            // buttonComplete
            // 
            this.buttonComplete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonComplete.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonComplete.Depth = 0;
            this.buttonComplete.HighEmphasis = true;
            this.buttonComplete.Icon = null;
            this.buttonComplete.Location = new System.Drawing.Point(10, 10);
            this.buttonComplete.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonComplete.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonComplete.Name = "buttonComplete";
            this.buttonComplete.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonComplete.Size = new System.Drawing.Size(128, 36);
            this.buttonComplete.TabIndex = 4;
            this.buttonComplete.Text = "Complete Job";
            this.buttonComplete.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonComplete.UseAccentColor = false;
            this.buttonComplete.UseVisualStyleBackColor = true;
            this.buttonComplete.Click += new System.EventHandler(this.buttonComplete_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonCancel.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonCancel.Depth = 0;
            this.buttonCancel.HighEmphasis = false;
            this.buttonCancel.Icon = null;
            this.buttonCancel.Location = new System.Drawing.Point(374, 10);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonCancel.Size = new System.Drawing.Size(108, 36);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel Job";
            this.buttonCancel.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.buttonCancel.UseAccentColor = true;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // JobsPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.labelTitle);
            this.Name = "JobsPane";
            this.Size = new System.Drawing.Size(898, 653);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJobs)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelPlaceholder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.panelActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewJobs;
        private System.Windows.Forms.Panel panelFilters;
        private MaterialSkin.Controls.MaterialComboBox comboBoxStatusFilter;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Panel panelActions;
        private MaterialSkin.Controls.MaterialButton buttonAccept;
        private MaterialSkin.Controls.MaterialButton buttonReject;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel labelCustomerName;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel labelPickup;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel labelDropoff;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel labelLoadSize;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialMultiLineTextBox textBoxDescription;
        private MaterialSkin.Controls.MaterialButton buttonAssignOrChangeUnit;
        private MaterialSkin.Controls.MaterialButton buttonDispatch;
        private MaterialSkin.Controls.MaterialButton buttonComplete;
        private MaterialSkin.Controls.MaterialButton buttonCancel;
        private MaterialSkin.Controls.MaterialLabel labelAssignedUnit;
        private MaterialSkin.Controls.MaterialLabel labelAssignedUnitValue;
        private System.Windows.Forms.Panel panelPlaceholder;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}