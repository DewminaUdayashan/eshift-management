using eshift_management.Core.Services;
using eshift_management.Models;
using eshift_management.Repositories;
using eshift_management.Services;

namespace eshift_management.Panes
{
    public partial class EmployeesPane : UserControl
    {
        private readonly IEmployeeService _employeeService;
        private bool isSortAscending = true;

        public EmployeesPane()
        {
            InitializeComponent();

            _employeeService = new EmployeeService(new EmployeeRepository());

            SetupDataGridView();
            SetupSorting();

            // Load initial data when the pane is created.
            _ = LoadEmployeesAsync();
        }

        private async Task LoadEmployeesAsync()
        {
            try
            {
                // Construct the filter dictionary based on UI controls.
                var filter = new Dictionary<string, object>();
                string? searchTerm = textBoxSearch.Text.Trim();
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    filter.Add("SearchTerm", searchTerm);
                }

                // Map the UI sort option to the property name for the service.
                string sortBy = comboBoxSortBy.SelectedItem.ToString();
                string orderByProperty = sortBy switch
                {
                    "Name" => "Name",
                    "Position" => "Position",
                    _ => "Id" // Default to "Employee ID"
                };

                var employees = await _employeeService.GetAllEmployeesAsync(filter, orderByProperty, isSortAscending);
                dataGridViewEmployees.DataSource = employees.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load employees: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewEmployees.AutoGenerateColumns = false;
            dataGridViewEmployees.Columns.Clear();
            AddGridColumn("Id", "Employee ID");
            AddGridColumn("FullName", "Full Name");
            AddGridColumn("Position", "Position");
            AddGridColumn("ContactNumber", "Contact No.");
            AddGridColumn("LicenseNumber", "License No.");
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
            dataGridViewEmployees.Columns.Add(editButtonColumn);
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
            dataGridViewEmployees.Columns.Add(column);
        }

        private void SetupSorting()
        {
            comboBoxSortBy.Items.Add("Employee ID");
            comboBoxSortBy.Items.Add("Name");
            comboBoxSortBy.Items.Add("Position");
            comboBoxSortBy.SelectedIndex = 0;
        }

        private async void buttonAddNew_Click(object sender, EventArgs e)
        {
            // The 'using' statement ensures the form is disposed of correctly.
            using (var form = new AddEditEmployeeForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Call the service to create the new employee.
                        await _employeeService.CreateEmployeeAsync(form.TheEmployee);

                        // Refresh the grid to show the new data.
                        await LoadEmployeesAsync();

                        MessageBox.Show("Employee successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to add employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void dataGridViewEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewEmployees.Columns[e.ColumnIndex].Name != "Edit")
                return;

            if (dataGridViewEmployees.Rows[e.RowIndex].DataBoundItem is Employee employeeToEdit)
            {
                using (var form = new AddEditEmployeeForm(employeeToEdit))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            await _employeeService.UpdateEmployeeAsync(form.TheEmployee);
                            await LoadEmployeesAsync(); // Refresh data
                            MessageBox.Show("Employee successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to update employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This method handles events from sorting and searching controls to refresh the data grid.
        /// </summary>
        private async void Sort_Changed(object sender, EventArgs e)
        {
            // A debounce timer would be ideal here to prevent excessive queries, especially for the search box.
            await LoadEmployeesAsync();
        }

        private async void buttonSortOrder_Click(object sender, EventArgs e)
        {
            isSortAscending = !isSortAscending;
            buttonSortOrder.Text = isSortAscending ? "ASC" : "DESC";
            await LoadEmployeesAsync();
        }
    }
}
