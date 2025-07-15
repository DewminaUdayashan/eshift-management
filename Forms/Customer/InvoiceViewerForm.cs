using eshift_management.Core.Utils;
using eshift_management.Models;
using MaterialSkin.Controls;

namespace eshift_management.Forms
{
    public partial class InvoiceViewerForm : MaterialForm
    {
        private readonly Job _job;
        private readonly PdfReportGenerator _pdfGenerator;

        public InvoiceViewerForm(Job jobToDisplay)
        {
            InitializeComponent();
            _job = jobToDisplay;
            _pdfGenerator = new PdfReportGenerator();

            // Set the form title and generate a styled HTML preview
            this.Text = $"Invoice for Job #{_job.Id}";
            webBrowserInvoice.DocumentText = GenerateInvoiceHtmlPreview();
        }

        /// <summary>
        /// Handles the click event for the save button. Generates and saves the invoice as a PDF.
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            byte[] pdfBytes;
            try
            {
                // Generate the PDF using the dedicated service
                pdfBytes = _pdfGenerator.GenerateInvoicePdf(_job);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to generate PDF: {ex.Message}", "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF File (*.pdf)|*.pdf",
                Title = "Save Invoice",
                FileName = $"Invoice-{_job.Id}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(saveFileDialog.FileName, pdfBytes);
                    MessageBox.Show("Invoice saved successfully as a PDF.", "Invoice Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save invoice. Error: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Generates a styled HTML preview of the invoice that mimics the PDF design.
        /// </summary>
        private string GenerateInvoiceHtmlPreview()
        {
            string customerAddress = $"{_job.Customer.AddressLine}<br/>{_job.Customer.City}, {_job.Customer.PostalCode}";
            string serviceDescription = $"Shifting from {_job.PickupLocation} to {_job.DropoffLocation}";

            return $@"
            <!DOCTYPE html>
            <html>
            <head>
                <style>
                    body {{ font-family: 'Segoe UI', sans-serif; color: #333; }}
                    .invoice-box {{ max-width: 800px; margin: auto; padding: 30px; border: 1px solid #eee; box-shadow: 0 0 10px rgba(0, 0, 0, 0.15); font-size: 16px; line-height: 24px; }}
                    .invoice-box table {{ width: 100%; line-height: inherit; text-align: left; border-collapse: collapse; }}
                    .invoice-box table td {{ padding: 5px; vertical-align: top; }}
                    .invoice-box table tr.top table td {{ padding-bottom: 20px; }}
                    .invoice-box table tr.top table td.title {{ font-size: 45px; line-height: 45px; color: #0D47A1; font-weight: bold; }}
                    .invoice-box table tr.information table td {{ padding-bottom: 40px; }}
                    .invoice-box table tr.heading td {{ background: #eee; border-bottom: 1px solid #ddd; font-weight: bold; }}
                    .invoice-box table tr.item td {{ border-bottom: 1px solid #eee; }}
                    .invoice-box table tr.total td:nth-child(2) {{ border-top: 2px solid #eee; font-weight: bold; text-align: right;}}
                    .text-right {{ text-align: right; }}
                </style>
            </head>
            <body>
                <div class='invoice-box'>
                    <table>
                        <tr class='top'>
                            <td colspan='2'>
                                <table>
                                    <tr>
                                        <td class='title'>E-Shift</td>
                                        <td class='text-right'>
                                            <b>Invoice #: {_job.Id}</b><br />
                                            Generated: {DateTime.Now:MMMM d, yyyy}<br />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class='information'>
                            <td colspan='2'>
                                <table>
                                    <tr>
                                        <td>
                                            <b>E-Shift Movers</b><br />
                                            123 Main Street<br />
                                            Panadura, Sri Lanka
                                        </td>
                                        <td class='text-right'>
                                            <b>Bill To:</b><br />
                                            {_job.Customer.FullName}<br />
                                            {customerAddress}
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr class='heading'>
                            <td>Description</td>
                            <td class='text-right'>Price</td>
                        </tr>
                        <tr class='item'>
                            <td>{serviceDescription}</td>
                            <td class='text-right'>{_job.TotalCost:N2} LKR</td>
                        </tr>
                        <tr class='total'>
                            <td></td>
                            <td>Total: {_job.TotalCost:N2} LKR</td>
                        </tr>
                    </table>
                </div>
            </body>
            </html>";
        }
    }
}
