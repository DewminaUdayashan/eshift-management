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
            webBrowserInvoice = new WebBrowser();
            buttonSave = new MaterialSkin.Controls.MaterialButton();
            SuspendLayout();
            // 
            // webBrowserInvoice
            // 
            webBrowserInvoice.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webBrowserInvoice.Location = new Point(6, 70);
            webBrowserInvoice.MinimumSize = new Size(20, 20);
            webBrowserInvoice.Name = "webBrowserInvoice";
            webBrowserInvoice.Size = new Size(788, 430);
            webBrowserInvoice.TabIndex = 0;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            buttonSave.Depth = 0;
            buttonSave.HighEmphasis = true;
            buttonSave.Icon = null;
            buttonSave.Location = new Point(618, 510);
            buttonSave.Margin = new Padding(4, 6, 4, 6);
            buttonSave.MouseState = MaterialSkin.MouseState.HOVER;
            buttonSave.Name = "buttonSave";
            buttonSave.NoAccentTextColor = Color.Empty;
            buttonSave.Size = new Size(169, 36);
            buttonSave.TabIndex = 1;
            buttonSave.Text = "Download";
            buttonSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            buttonSave.UseAccentColor = false;
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // InvoiceViewerForm
            // 
            ClientSize = new Size(800, 560);
            Controls.Add(buttonSave);
            Controls.Add(webBrowserInvoice);
            Name = "InvoiceViewerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Invoice Viewer";
            ResumeLayout(false);
            PerformLayout();

        }
        #endregion

        private System.Windows.Forms.WebBrowser webBrowserInvoice;
        private MaterialSkin.Controls.MaterialButton buttonSave;
    }
}