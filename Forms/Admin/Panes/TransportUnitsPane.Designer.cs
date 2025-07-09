namespace eshift_management.Panes
{
    partial class TransportUnitsPane
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
            this.dataGridViewUnits = new System.Windows.Forms.DataGridView();
            this.panelActions = new System.Windows.Forms.Panel();
            this.buttonAddNew = new MaterialSkin.Controls.MaterialButton();
            this.textBoxSearch = new MaterialSkin.Controls.MaterialTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUnits)).BeginInit();
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
            this.labelTitle.Size = new System.Drawing.Size(425, 45);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Transport Unit Management";
            // 
            // dataGridViewUnits
            // 
            this.dataGridViewUnits.AllowUserToAddRows = false;
            this.dataGridViewUnits.AllowUserToDeleteRows = false;
            this.dataGridViewUnits.AllowUserToResizeRows = false;
            this.dataGridViewUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUnits.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewUnits.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewUnits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUnits.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUnits.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUnits.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUnits.EnableHeadersVisualStyles = false;
            this.dataGridViewUnits.GridColor = System.Drawing.Color.Gainsboro;
            this.dataGridViewUnits.Location = new System.Drawing.Point(28, 150);
            this.dataGridViewUnits.Name = "dataGridViewUnits";
            this.dataGridViewUnits.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUnits.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewUnits.RowHeadersVisible = false;
            this.dataGridViewUnits.RowTemplate.Height = 40;
            this.dataGridViewUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUnits.Size = new System.Drawing.Size(840, 480);
            this.dataGridViewUnits.TabIndex = 2;
            this.dataGridViewUnits.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUnits_CellContentClick);
            // 
            // panelActions
            // 
            this.panelActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelActions.Controls.Add(this.buttonAddNew);
            this.panelActions.Controls.Add(this.textBoxSearch);
            this.panelActions.Location = new System.Drawing.Point(28, 80);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(840, 55);
            this.panelActions.TabIndex = 3;
            // 
            // buttonAddNew
            // 
            this.buttonAddNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonAddNew.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonAddNew.Depth = 0;
            this.buttonAddNew.HighEmphasis = true;
            this.buttonAddNew.Icon = null;
            this.buttonAddNew.Location = new System.Drawing.Point(690, 10);
            this.buttonAddNew.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonAddNew.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonAddNew.Name = "buttonAddNew";
            this.buttonAddNew.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonAddNew.Size = new System.Drawing.Size(126, 36);
            this.buttonAddNew.TabIndex = 1;
            this.buttonAddNew.Text = "Add New Unit";
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
            this.textBoxSearch.Hint = "Search Units...";
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
            // 
            // TransportUnitsPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panelActions);
            this.Controls.Add(this.dataGridViewUnits);
            this.Controls.Add(this.labelTitle);
            this.Name = "TransportUnitsPane";
            this.Size = new System.Drawing.Size(898, 653);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUnits)).EndInit();
            this.panelActions.ResumeLayout(false);
            this.panelActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataGridView dataGridViewUnits;
        private System.Windows.Forms.Panel panelActions;
        private MaterialSkin.Controls.MaterialButton buttonAddNew;
        private MaterialSkin.Controls.MaterialTextBox textBoxSearch;
    }
}