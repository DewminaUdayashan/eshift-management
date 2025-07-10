namespace eshift_management.Forms
{
    partial class InvoiceViewerForm
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
            this.webBrowserInvoice = new System.Windows.Forms.WebBrowser();
            this.buttonSave = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // webBrowserInvoice
            // 
            this.webBrowserInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserInvoice.Location = new System.Drawing.Point(6, 70);
            this.webBrowserInvoice.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserInvoice.Name = "webBrowserInvoice";
            this.webBrowserInvoice.Size = new System.Drawing.Size(788, 430);
            this.webBrowserInvoice.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.buttonSave.Depth = 0;
            this.buttonSave.HighEmphasis = true;
            this.buttonSave.Icon = null;
            this.buttonSave.Location = new System.Drawing.Point(613, 510);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.buttonSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.buttonSave.Size = new System.Drawing.Size(174, 36);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Download as HTML";
            this.buttonSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.buttonSave.UseAccentColor = false;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // InvoiceViewerForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.webBrowserInvoice);
            this.Name = "InvoiceViewerForm";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Invoice Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.WebBrowser webBrowserInvoice;
        private MaterialSkin.Controls.MaterialButton buttonSave;
    }
}