using eshift_management.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management.Panes
{
    public partial class TransportUnitsPane : UserControl
    {
        private List<TransportUnit> allUnits;
        private List<Truck> allTrucks;
        private List<Employee> allEmployees;

        public TransportUnitsPane()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadDummyData();
        }

        private void SetupDataGridView()
        {
            dataGridViewUnits.AutoGenerateColumns = false;
            dataGridViewUnits.Columns.Clear();

            AddGridColumn("Id", "Unit ID");
            AddGridColumn("UnitName", "Unit Name");
            AddGridColumn("TruckInfo", "Truck");
            AddGridColumn("DriverInfo", "Driver");
            AddGridColumn("AssistantInfo", "Assistant");
            AddGridColumn("Status", "Status");

            var editButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                HeaderText = "Actions",
                FlatStyle = FlatStyle.Flat,
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            editButtonColumn.DefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            editButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewUnits.Columns.Add(editButtonColumn);

            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Width = 80,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };
            deleteButtonColumn.DefaultCellStyle.BackColor = Color.IndianRed;
            deleteButtonColumn.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewUnits.Columns.Add(deleteButtonColumn);
        }

        private void AddGridColumn(string dataPropertyName, string headerText)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                Name = dataPropertyName,
                HeaderText = headerText,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridViewUnits.Columns.Add(column);
        }

        private void LoadDummyData()
        {
            // In a real app, this data would come from a database
            allTrucks = new List<Truck>
            {
                new Truck { Id = "TRK-01", Model = "Isuzu Elf", LicensePlate = "CBA-1234", Status = ResourceStatus.Available },
                new Truck { Id = "TRK-02", Model = "Mitsubishi Canter", LicensePlate = "CAB-5678", Status = ResourceStatus.Assigned },
                new Truck { Id = "TRK-03", Model = "Fuso Fighter", LicensePlate = "CAA-9101", Status = ResourceStatus.Available }
            };
            allEmployees = new List<Employee>
            {
                new Employee { Id = "EMP-01", FirstName = "Kamal", LastName = "Perera", Position = EmployeePosition.Driver, ContactNumber="071-1112222", LicenseNumber = "B123456", Status = ResourceStatus.Assigned },
                new Employee { Id = "EMP-02", FirstName = "Nimal", LastName = "Silva", Position = EmployeePosition.Driver, ContactNumber="077-2223333", LicenseNumber = "B789012", Status = ResourceStatus.Available },
                new Employee { Id = "EMP-03", FirstName = "Sunil", LastName = "Fernando", Position = EmployeePosition.Assistant, ContactNumber = "077-1234567", LicenseNumber = "N/A", Status = ResourceStatus.Assigned },
                new Employee { Id = "EMP-04", FirstName = "Jagath", LastName = "Zoysa", Position = EmployeePosition.Assistant, ContactNumber = "071-7654321", LicenseNumber = "N/A", Status = ResourceStatus.Available }
            };

            allUnits = new List<TransportUnit>
            {
                new TransportUnit { Id = "UNIT-01", UnitName = "Team Alpha", Truck = allTrucks[1], Driver = allEmployees[0], Assistant = allEmployees[2], Status = ResourceStatus.Assigned, AssignedJobId = "JOB-101" },
                new TransportUnit { Id = "UNIT-02", UnitName = "Team Bravo", Truck = allTrucks[0], Driver = allEmployees[1], Assistant = allEmployees[3], Status = ResourceStatus.Available, AssignedJobId = "" }
            };

            UpdateGridDisplay();
        }

        private void UpdateGridDisplay()
        {
            // This method now dynamically creates row data for better object access
            dataGridViewUnits.Rows.Clear();
            foreach (var unit in allUnits)
            {
                int rowIndex = dataGridViewUnits.Rows.Add(
                    unit.Id,
                    unit.UnitName,
                    $"{unit.Truck.Model} ({unit.Truck.LicensePlate})",
                    unit.Driver.FullName,
                    unit.Assistant.FullName,
                    unit.Status
                );
                // Store the actual unit object in the row's tag for easy access
                dataGridViewUnits.Rows[rowIndex].Tag = unit;
            }
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            // Get all available resources
            var trucks = allTrucks.Where(t => t.Status == ResourceStatus.Available).ToList();
            var drivers = allEmployees.Where(emp => emp.Position == EmployeePosition.Driver && emp.Status == ResourceStatus.Available).ToList();
            var assistants = allEmployees.Where(emp => emp.Position == EmployeePosition.Assistant && emp.Status == ResourceStatus.Available).ToList();

            using (var form = new AddEditUnitForm(trucks, drivers, assistants))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var newUnit = form.TheUnit;

                    // Mark resources as assigned
                    newUnit.Truck.Status = ResourceStatus.Assigned;
                    newUnit.Driver.Status = ResourceStatus.Assigned;
                    newUnit.Assistant.Status = ResourceStatus.Assigned;

                    allUnits.Add(newUnit);
                    UpdateGridDisplay();
                    MessageBox.Show("Transport unit successfully created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewUnits_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // This event fires just before a cell is painted
            if (e.RowIndex < 0) return;

            // Check if we are in a button column
            bool isButtonColumn = dataGridViewUnits.Columns[e.ColumnIndex].Name == "Edit" || dataGridViewUnits.Columns[e.ColumnIndex].Name == "Delete";
            if (!isButtonColumn) return;

            // Get the unit for the current row
            var unit = dataGridViewUnits.Rows[e.RowIndex].Tag as TransportUnit;
            if (unit != null && unit.Status == ResourceStatus.Assigned)
            {
                // If the unit is assigned, "disable" the button by changing its style
                var buttonCell = (DataGridViewButtonCell)dataGridViewUnits.Rows[e.RowIndex].Cells[e.ColumnIndex];
                buttonCell.FlatStyle = FlatStyle.Popup;
                buttonCell.Style.BackColor = Color.LightGray;
                buttonCell.Style.ForeColor = Color.DarkGray;
                dataGridViewUnits.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            }
        }

        private void dataGridViewUnits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var unit = dataGridViewUnits.Rows[e.RowIndex].Tag as TransportUnit;
            if (unit == null || unit.Status == ResourceStatus.Assigned)
            {
                // If the unit is assigned, do not allow any action
                return;
            }

            // Handle Edit
            if (dataGridViewUnits.Columns[e.ColumnIndex].Name == "Edit")
            {
                // Get lists of available resources, BUT also include the resources from the unit we are editing
                var trucks = allTrucks.Where(t => t.Status == ResourceStatus.Available || t.Id == unit.Truck.Id).ToList();
                var drivers = allEmployees.Where(emp => (emp.Position == EmployeePosition.Driver && emp.Status == ResourceStatus.Available) || emp.Id == unit.Driver.Id).ToList();
                var assistants = allEmployees.Where(emp => (emp.Position == EmployeePosition.Assistant && emp.Status == ResourceStatus.Available) || emp.Id == unit.Assistant.Id).ToList();

                using (var form = new AddEditUnitForm(trucks, drivers, assistants, unit))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        // In a real app, update the database. For now, update our in-memory list.
                        int index = allUnits.FindIndex(u => u.Id == unit.Id);
                        if (index != -1)
                        {
                            allUnits[index] = form.TheUnit;
                        }
                        UpdateGridDisplay();
                        MessageBox.Show("Unit updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            // Handle Delete
            else if (dataGridViewUnits.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show($"Are you sure you want to delete '{unit.UnitName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Mark resources as available again
                    unit.Truck.Status = ResourceStatus.Available;
                    unit.Driver.Status = ResourceStatus.Available;
                    unit.Assistant.Status = ResourceStatus.Available;

                    allUnits.Remove(unit);
                    UpdateGridDisplay();
                    MessageBox.Show("Unit deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}