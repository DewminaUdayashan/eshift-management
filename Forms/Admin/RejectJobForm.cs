using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace eshift_management.Forms
{
    public partial class RejectJobForm : MaterialForm
    {
        public string RejectionReason { get; private set; }

        public RejectJobForm()
        {
            InitializeComponent();
        }

        private void buttonReject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxReason.Text))
            {
                MessageBox.Show("A reason for rejection is required.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            RejectionReason = textBoxReason.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}