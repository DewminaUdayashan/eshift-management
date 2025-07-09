using eshift_management.Models;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management
{
    public partial class AddEditUnitForm : MaterialForm
    {
        private readonly TransportUnit currentUnit;
        private readonly bool isEditMode;

        public TransportUnit TheUnit { get; private set; }

        public AddEditUnitForm(List<Truck> trucks, List<Employee> drivers, List<Employee> assistants, TransportUnit unitToEdit = null)
        {
            InitializeComponent();

            currentUnit = unitToEdit;
            isEditMode = (currentUnit != null);

            PopulateComboBoxes(trucks, drivers, assistants);
            SetupForm();
        }

        private void PopulateComboBoxes(List<Truck> trucks, List<Employee> drivers, List<Employee> assistants)
        {
            comboBoxTruck.DataSource = trucks;
            comboBoxTruck.DisplayMember = "LicensePlate";

            comboBoxDriver.DataSource = drivers;
            comboBoxDriver.DisplayMember = "FullName";

            comboBoxAssistant.DataSource = assistants;
            comboBoxAssistant.DisplayMember = "FullName";
        }

        private void SetupForm()
        {
            if (isEditMode)
            {
                this.Text = "Edit Transport Unit";
                textBoxUnitName.Text = currentUnit.UnitName;
                comboBoxTruck.SelectedItem = currentUnit.Truck;
                comboBoxDriver.SelectedItem = currentUnit.Driver;
                comboBoxAssistant.SelectedItem = currentUnit.Assistant;
            }
            else
            {
                this.Text = "Create Transport Unit";
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var unit = new TransportUnit
            {
                Id = isEditMode ? currentUnit.Id : $"UNIT-{DateTime.Now.Ticks}",
                UnitName = textBoxUnitName.Text.Trim(),
                Truck = comboBoxTruck.SelectedItem as Truck,
                Driver = comboBoxDriver.SelectedItem as Employee,
                Assistant = comboBoxAssistant.SelectedItem as Employee,
                Status = isEditMode ? currentUnit.Status : ResourceStatus.Available,
                AssignedJobId = isEditMode ? currentUnit.AssignedJobId : string.Empty
            };

            var validator = new UnitValidator();
            var validationResult = validator.Validate(unit);

            if (!validationResult.IsValid)
            {
                var allErrors = string.Join("\n", validationResult.Errors.Select(err => err.ErrorMessage));
                MessageBox.Show(allErrors, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TheUnit = unit;
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