using eshift_management.Core.Services;
using eshift_management.Models;
using eshift_management.Repositories;
using eshift_management.Services;

namespace eshift_management.Panes
{
    public partial class TransportUnitsPane : UserControl
    {
        private readonly ITransportUnitService _unitService;
        private readonly ITruckService _truckService;
        private readonly IEmployeeService _employeeService;

        public TransportUnitsPane()
        {
            InitializeComponent();
            SetupDataGridView();

            var unitRepo = new TransportUnitRepository();
            var truckRepo = new TruckRepository();
            var employeeRepo = new EmployeeRepository();

            _unitService = new TransportUnitService(unitRepo, truckRepo, employeeRepo);
            _truckService = new TruckService(truckRepo);
            _employeeService = new EmployeeService(employeeRepo);

            // Load initial data asynchronously.
            _ = LoadUnitsAsync();
        }

        private async Task LoadUnitsAsync()
        {
            try
            {
                var units = await _unitService.GetAllTransportUnitsAsync();
                UpdateGridDisplay(units.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load transport units: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewUnits.AutoGenerateColumns = false;
            dataGridViewUnits.Columns.Clear();
            AddGridColumn("Id", "Unit ID");
            AddGridColumn("UnitName", "Unit Name");
            // These columns will be populated manually, so DataPropertyName is not needed.
            AddGridColumn("TruckInfo", "Truck");
            AddGridColumn("DriverInfo", "Driver");
            AddGridColumn("AssistantInfo", "Assistant");
            AddGridColumn("Status", "Status");
            // Add action buttons
            var editButton = new DataGridViewButtonColumn { Name = "Edit", Text = "Edit", UseColumnTextForButtonValue = true, HeaderText = "Actions", FlatStyle = FlatStyle.Flat, Width = 80, AutoSizeMode = DataGridViewAutoSizeColumnMode.None };
            editButton.DefaultCellStyle.BackColor = Color.FromArgb(0, 123, 255);
            editButton.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewUnits.Columns.Add(editButton);
            var deleteButton = new DataGridViewButtonColumn { Name = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, HeaderText = "", FlatStyle = FlatStyle.Flat, Width = 80, AutoSizeMode = DataGridViewAutoSizeColumnMode.None };
            deleteButton.DefaultCellStyle.BackColor = Color.IndianRed;
            deleteButton.DefaultCellStyle.ForeColor = Color.White;
            dataGridViewUnits.Columns.Add(deleteButton);
        }

        private void AddGridColumn(string name, string headerText)
        {
            var column = new DataGridViewTextBoxColumn { Name = name, HeaderText = headerText, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            dataGridViewUnits.Columns.Add(column);
        }

        private void UpdateGridDisplay(List<TransportUnit> units)
        {
            dataGridViewUnits.Rows.Clear();
            foreach (var unit in units)
            {
                int rowIndex = dataGridViewUnits.Rows.Add(
                    unit.Id,
                    unit.UnitName,
                    $"{unit.Truck.Model} ({unit.Truck.LicensePlate})",
                    unit.Driver.FullName,
                    unit.Assistant.FullName,
                    unit.Status
                );
                dataGridViewUnits.Rows[rowIndex].Tag = unit;
            }
        }

        private async void buttonAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                // Fetch all available resources from the database.
                var availableTrucks = (await _truckService.GetTrucksByStatusAsync(ResourceStatus.Available)).ToList();
                var availableDrivers = (await _employeeService.GetEmployeesByPositionAsync(EmployeePosition.Driver)).Where(d => d.Status == ResourceStatus.Available).ToList();
                var availableAssistants = (await _employeeService.GetEmployeesByPositionAsync(EmployeePosition.Assistant)).Where(a => a.Status == ResourceStatus.Available).ToList();

                using (var form = new AddEditUnitForm(availableTrucks, availableDrivers, availableAssistants))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        await _unitService.CreateTransportUnitAsync(form.TheUnit);
                        await LoadUnitsAsync(); // Refresh grid
                        MessageBox.Show("Transport unit successfully created.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error preparing to add unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewUnits_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            bool isActionColumn = dataGridViewUnits.Columns[e.ColumnIndex].Name == "Edit" || dataGridViewUnits.Columns[e.ColumnIndex].Name == "Delete";
            if (!isActionColumn) return;

            var unit = dataGridViewUnits.Rows[e.RowIndex].Tag as TransportUnit;
            if (unit != null && unit.Status == ResourceStatus.Assigned)
            {
                var buttonCell = (DataGridViewButtonCell)dataGridViewUnits.Rows[e.RowIndex].Cells[e.ColumnIndex];
                buttonCell.FlatStyle = FlatStyle.Popup;
                buttonCell.Style.BackColor = Color.LightGray;
                buttonCell.Style.ForeColor = Color.DarkGray;
                dataGridViewUnits.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            }
        }

        private async void dataGridViewUnits_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var unit = dataGridViewUnits.Rows[e.RowIndex].Tag as TransportUnit;
            if (unit == null || unit.Status == ResourceStatus.Assigned) return;

            // Handle Edit
            if (dataGridViewUnits.Columns[e.ColumnIndex].Name == "Edit")
            {
                try
                {
                    var trucks = (await _truckService.GetTrucksByStatusAsync(ResourceStatus.Available)).ToList();
                    trucks.Add(unit.Truck); // Add the current truck back to the list
                    var drivers = (await _employeeService.GetEmployeesByStatusAsync(ResourceStatus.Available)).Where(d => d.Position == EmployeePosition.Driver).ToList();
                    drivers.Add(unit.Driver);
                    var assistants = (await _employeeService.GetEmployeesByStatusAsync(ResourceStatus.Available)).Where(a => a.Position == EmployeePosition.Assistant).ToList();
                    assistants.Add(unit.Assistant);

                    using (var form = new AddEditUnitForm(trucks, drivers, assistants, unit))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            await _unitService.UpdateTransportUnitAsync(form.TheUnit);
                            await LoadUnitsAsync();
                            MessageBox.Show("Unit updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error preparing to edit unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Handle Delete
            else if (dataGridViewUnits.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show($"Are you sure you want to delete '{unit.UnitName}'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        await _unitService.DeleteTransportUnitAsync(unit.Id);
                        await LoadUnitsAsync();
                        MessageBox.Show("Unit deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete unit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
