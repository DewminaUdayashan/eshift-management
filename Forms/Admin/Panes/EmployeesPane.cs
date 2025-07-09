using eshift_management.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management.Panes
{
    public partial class EmployeesPane : UserControl
    {
        private List<Employee> allEmployees;
        private bool isSortAscending = true;

        public EmployeesPane()
        {
            InitializeComponent();
            SetupDataGridView();
            SetupSorting();
            LoadDummyData();
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

        private void LoadDummyData()
        {
            allEmployees = new List<Employee>
            {
                new Employee { Id = "EMP-01", FirstName = "Kamal", LastName = "Perera", Position = EmployeePosition.Driver, ContactNumber="071-1112222", LicenseNumber = "B123456", Status = ResourceStatus.Assigned },
                new Employee { Id = "EMP-02", FirstName = "Nimal", LastName = "Silva", Position = EmployeePosition.Driver, ContactNumber="077-2223333", LicenseNumber = "B789012", Status = ResourceStatus.Available },
                new Employee { Id = "EMP-03", FirstName = "Sunil", LastName = "Fernando", Position = EmployeePosition.Assistant, ContactNumber = "077-1234567", LicenseNumber = "N/A", Status = ResourceStatus.Assigned },
                new Employee { Id = "EMP-04", FirstName = "Jagath", LastName = "Zoysa", Position = EmployeePosition.Assistant, ContactNumber = "071-7654321", LicenseNumber = "N/A", Status = ResourceStatus.Available }
            };
            UpdateGridDisplay();
        }

        private void UpdateGridDisplay()
        {
            if (allEmployees == null) return;
            IEnumerable<Employee> processedData = allEmployees;
            string searchText = textBoxSearch.Text.ToLower().Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                processedData = processedData.Where(e =>
                    e.Id.ToLower().Contains(searchText) ||
                    e.FullName.ToLower().Contains(searchText) ||
                    e.ContactNumber.Contains(searchText)
                ).ToList();
            }
            string sortBy = comboBoxSortBy.SelectedItem.ToString();
            switch (sortBy)
            {
                case "Name":
                    processedData = isSortAscending ? processedData.OrderBy(e => e.FullName) : processedData.OrderByDescending(e => e.FullName);
                    break;
                case "Position":
                    processedData = isSortAscending ? processedData.OrderBy(e => e.Position) : processedData.OrderByDescending(e => e.Position);
                    break;
                default:
                    processedData = isSortAscending ? processedData.OrderBy(e => e.Id) : processedData.OrderByDescending(e => e.Id);
                    break;
            }
            dataGridViewEmployees.DataSource = processedData.ToList();
        }

        private void Sort_Changed(object sender, EventArgs e)
        {
            UpdateGridDisplay();
        }

        private void buttonSortOrder_Click(object sender, EventArgs e)
        {
            isSortAscending = !isSortAscending;
            buttonSortOrder.Text = isSortAscending ? "ASC" : "DESC";
            UpdateGridDisplay();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditEmployeeForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    allEmployees.Add(form.TheEmployee);
                    UpdateGridDisplay();
                    MessageBox.Show("Employee successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewEmployees.Columns[e.ColumnIndex].Name != "Edit")
                return;

            string employeeId = dataGridViewEmployees.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            var employeeToEdit = allEmployees.FirstOrDefault(emp => emp.Id == employeeId);

            if (employeeToEdit != null)
            {
                using (var form = new AddEditEmployeeForm(employeeToEdit))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int index = allEmployees.FindIndex(emp => emp.Id == employeeId);
                        if (index != -1)
                        {
                            allEmployees[index] = form.TheEmployee;
                        }
                        UpdateGridDisplay();
                        MessageBox.Show("Employee successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}