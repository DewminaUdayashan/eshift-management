using eshift_management.Models;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace eshift_management.Forms
{
    public partial class AssignUnitForm : MaterialForm
    {
        public TransportUnit SelectedUnit { get; private set; }

        public AssignUnitForm(List<TransportUnit> availableUnits)
        {
            InitializeComponent();

            if (availableUnits == null || availableUnits.Count == 0)
            {
                MessageBox.Show("There are no available units to assign.", "No Units Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Close the form if there's nothing to select
                this.Load += (s, e) => Close();
                return;
            }

            comboBoxUnits.DataSource = availableUnits;
            comboBoxUnits.DisplayMember = "UnitName";
        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            if (comboBoxUnits.SelectedItem == null)
            {
                MessageBox.Show("Please select a unit to assign.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SelectedUnit = comboBoxUnits.SelectedItem as TransportUnit;
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