using eshift_management.Models;
using MaterialSkin.Controls;
using System;
using System.IO;
using System.Windows.Forms;

namespace eshift_management.Forms
{
    public partial class InvoiceViewerForm : MaterialForm
    {
        private readonly Job job;

        public InvoiceViewerForm(Job jobToDisplay)
        {
            InitializeComponent();
            this.job = jobToDisplay;

            // Set the form title and generate the invoice HTML
            this.Text = $"Invoice for Job #{job.Id}";
            webBrowserInvoice.DocumentText = GenerateInvoiceHtml();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "HTML File (*.html)|*.html",
                Title = "Save Invoice",
                FileName = $"Invoice-{job.Id}.html"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, webBrowserInvoice.DocumentText);
                    MessageBox.Show("Invoice saved successfully as an HTML file.\n\nYou can open this file in any web browser and use its 'Print' function to save it as a PDF.", "Invoice Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save invoice. Error: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private string GenerateInvoiceHtml()
        {
            string customerAddress = $"{job.Customer.AddressLine}<br/>{job.Customer.City}, {job.Customer.PostalCode}";
            string serviceDescription = $"Shifting from {job.PickupLocation} to {job.DropoffLocation}";

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
                    .invoice-box table tr.top table td.title {{ font-size: 45px; line-height: 45px; color: #333; }}
                    .invoice-box table tr.information table td {{ padding-bottom: 40px; }}
                    .invoice-box table tr.heading td {{ background: #eee; border-bottom: 1px solid #ddd; font-weight: bold; }}
                    .invoice-box table tr.details td {{ padding-bottom: 20px; }}
                    .invoice-box table tr.item td {{ border-bottom: 1px solid #eee; }}
                    .invoice-box table tr.item.last td {{ border-bottom: none; }}
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
                                            Invoice #: {job.Id}<br />
                                            Generated: {DateTime.Now:MMMM d, yyyy}<br />
                                            Due: {job.PickupDate.AddDays(30):MMMM d, yyyy}
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
                                            E-Shift, Inc.<br />
                                            123 Main Street<br />
                                            Panadura, Sri Lanka
                                        </td>
                                        <td class='text-right'>
                                            <b>{job.Customer.FullName}</b><br />
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
                            <td class='text-right'>{job.TotalCost:N2} LKR</td>
                        </tr>
                        <tr class='total'>
                            <td></td>
                            <td>Total: {job.TotalCost:N2} LKR</td>
                        </tr>
                    </table>
                </div>
            </body>
            </html>";
        }
    }
}