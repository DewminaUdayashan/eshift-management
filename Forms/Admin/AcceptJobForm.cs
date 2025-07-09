using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace eshift_management.Forms
{
    public partial class AcceptJobForm : MaterialForm
    {
        public decimal TotalCost { get; private set; }
        public int EstimatedHours { get; private set; }

        public AcceptJobForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBoxCost.Text, out decimal cost) || cost <= 0)
            {
                MessageBox.Show("Please enter a valid total cost.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(textBoxHours.Text, out int hours) || hours <= 0)
            {
                MessageBox.Show("Please enter a valid number for estimated hours.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TotalCost = cost;
            EstimatedHours = hours;
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