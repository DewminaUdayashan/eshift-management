namespace eshift_management.Panes
{
    partial class TrucksPane
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
            this.dataGridViewTrucks = new System.Windows.Forms.DataGridView();
            this.panelActions = new System.Windows.Forms.Panel();
            this.buttonSortOrder = new MaterialSkin.Controls.MaterialButton();
            this.comboBoxSortBy = new MaterialSkin.Controls.MaterialComboBox();
            this.buttonAddNew = new MaterialSkin.Controls.MaterialButton();
            this.textBoxSearch = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrucks)).BeginInit();
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
            this.labelTitle.Size = new System.Drawing.Size(303, 45);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Truck Management";
            // 
            // dataGridViewTrucks
            // 
            this.dataGridViewTrucks.AllowUserToAddRows = false;
            this.dataGridViewTrucks.AllowUserToDeleteRows = false;
            this.dataGridViewTrucks.AllowUserToResizeRows = false;
            this.dataGridViewTrucks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTrucks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTrucks.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewTrucks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewTrucks.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTrucks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTrucks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTrucks.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTrucks.EnableHeadersVisualStyles = false;
            this.dataGridViewTrucks.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewTrucks.Location = new System.Drawing.Point(28, 150);
            this.dataGridViewTrucks.Name = "dataGridViewTrucks";
            this.dataGridViewTrucks.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTrucks.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTrucks.RowHeadersVisible = false;
            this.dataGridViewTrucks.RowTemplate.Height = 40;
            this.dataGridViewTrucks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTrucks.Size = new System.Drawing.Size(840, 480);
            this.dataGridViewTrucks.TabIndex = 2;
            this.dataGridViewTrucks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTrucks_CellContentClick);
            // 
            // panelActions
            // 
            this.panelActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelActions.Controls.Add(this.buttonSortOrder);
            this.panelActions.Controls.Add(this.comboBoxSortBy);
            this.panelActions.Controls.Add(this.buttonAddNew);
            this.panelActions.Controls.Add(this.textBoxSearch);
            this.panelActions.Location = new System.Drawing.Point(28, 80);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(840, 55);
            this.panelActions.TabIndex = 3;
            // 
            // buttonSortOrder
            // 
            this.buttonSortOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSortOrder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSortOrder.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSortOrder.Depth = 0;
            this.buttonSortOrder.HighEmphasis = false;
            this.buttonSortOrder.Icon = null;
            this.buttonSortOrder.Location = new System.Drawing.Point(600, 10);
            this.buttonSortOrder.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSortOrder.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSortOrder.Name = "buttonSortOrder";
            this.buttonSortOrder.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonSortOrder.Size = new System.Drawing.Size(54, 36);
            this.buttonSortOrder.TabIndex = 3;
            this.buttonSortOrder.Text = "ASC";
            this.buttonSortOrder.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.buttonSortOrder.UseAccentColor = false;
            this.buttonSortOrder.UseVisualStyleBackColor = true;
            this.buttonSortOrder.Click += new System.EventHandler(this.buttonSortOrder_Click);
            // 
            // comboBoxSortBy
            // 
            this.comboBoxSortBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSortBy.AutoResize = false;
            this.comboBoxSortBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.comboBoxSortBy.Depth = 0;
            this.comboBoxSortBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxSortBy.DropDownHeight = 174;
            this.comboBoxSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSortBy.DropDownWidth = 121;
            this.comboBoxSortBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboBoxSortBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBoxSortBy.FormattingEnabled = true;
            this.comboBoxSortBy.Hint = "Sort By";
            this.comboBoxSortBy.IntegralHeight = false;
            this.comboBoxSortBy.ItemHeight = 43;
            this.comboBoxSortBy.Location = new System.Drawing.Point(405, 4);
            this.comboBoxSortBy.MaxDropDownItems = 4;
            this.comboBoxSortBy.MouseState = MaterialSkin.MouseState.OUT;
            this.comboBoxSortBy.Name = "comboBoxSortBy";
            this.comboBoxSortBy.Size = new System.Drawing.Size(185, 49);
            this.comboBoxSortBy.StartIndex = 0;
            this.comboBoxSortBy.TabIndex = 2;
            this.comboBoxSortBy.SelectedIndexChanged += new System.EventHandler(this.Sort_Changed);
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddNew.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonAddNew.Depth = 0;
            this.buttonAddNew.HighEmphasis = true;
            this.buttonAddNew.Icon = null;
            this.buttonAddNew.Location = new System.Drawing.Point(694, 10);
            this.buttonAddNew.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAddNew.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonAddNew.Size = new System.Drawing.Size(124, 36);
            this.buttonAddNew.TabIndex = 1;
            this.buttonAddNew.Text = "Add New Truck";
            this.buttonAddNew.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonAddNew.UseAccentColor = false;
            this.buttonAddNew.UseVisualStyleBackColor = true;
            this.buttonAddNew.Click += new System.EventHandler(this.buttonAddNew_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.AnimateReadOnly = false;
            this.textBoxSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSearch.Depth = 0;
            this.textBoxSearch.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxSearch.Hint = "Search Trucks...";
            this.textBoxSearch.LeadingIcon = null;
            this.textBoxSearch.Location = new System.Drawing.Point(3, 3);
            this.textBoxSearch.MaxLength = 50;
            this.textBoxSearch.MouseState = MaterialSkin.MouseState.OUT;
            this.textBoxSearch.Multiline = false;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(300, 50);
            this.textBoxSearch.TabIndex = 0;
            this.textBoxSearch.Text = "";
            this.textBoxSearch.TrailingIcon = null;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.Sort_Changed);
            // 
            // TrucksPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.dataGridViewTrucks);
            this.Controls.Add(this.labelTitle);
            this.Name = "TrucksPane";
            this.Size = new System.Drawing.Size(898, 653);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrucks)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.panelActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataGridView dataGridViewTrucks;
        private System.Windows.Forms.Panel panelActions;
        private MaterialSkin.Controls.MaterialButton buttonAddNew;
        private MaterialSkin.Controls.MaterialTextBox textBoxSearch;
        private MaterialSkin.Controls.MaterialButton buttonSortOrder;
        private MaterialSkin.Controls.MaterialComboBox comboBoxSortBy;
    }
}