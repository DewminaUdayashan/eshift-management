using eshift_management.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management
{
    public partial class CustomersPane : UserControl
    {
        private List<CustomerModel> allCustomers;
        private bool isSortAscending = true;

        public CustomersPane()
        {
            InitializeComponent();
            SetupDataGridView();
            // ** FIX: Setup sorting controls BEFORE loading data to prevent null reference **
            SetupSorting();
            LoadDummyData();
        }

        /// <summary>
        /// Sets up the visual style and columns for the DataGridView.
        /// </summary>
        private void SetupDataGridView()
        {
            dataGridViewCustomers.AutoGenerateColumns = false;
            dataGridViewCustomers.Columns.Clear();

            AddGridColumn("Id", "Customer ID", 100);
            AddGridColumn("FullName", "Full Name", 150);
            AddGridColumn("Email", "Email Address", 200);
            AddGridColumn("Phone", "Phone", 120);
            AddGridColumn("OngoingJobs", "Ongoing Jobs", 80);

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
            dataGridViewCustomers.Columns.Add(editButtonColumn);
        }

        /// <summary>
        /// Populates the sorting dropdown menu.
        /// </summary>
        private void SetupSorting()
        {
            comboBoxSortBy.Items.Add("Customer ID");
            comboBoxSortBy.Items.Add("Full Name");
            comboBoxSortBy.Items.Add("Ongoing Jobs");
            comboBoxSortBy.SelectedIndex = 0;
        }

        private void AddGridColumn(string dataPropertyName, string headerText, int width)
        {
            var column = new DataGridViewTextBoxColumn
            {
                DataPropertyName = dataPropertyName,
                Name = dataPropertyName,
                HeaderText = headerText,
                Width = width,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };
            dataGridViewCustomers.Columns.Add(column);
        }

        private void LoadDummyData()
        {
            allCustomers = new List<CustomerModel>
            {
                new CustomerModel { Id = 0, UserId=0, FirstName = "John", LastName = "Smith", Email = "john.smith@example.com", Phone = "555-0101", AddressLine = "123 Maple St", City="Springfield", PostalCode="12345", OngoingJobs = 2 },
                new CustomerModel { Id = 1, UserId=0,FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com", Phone = "555-0102", AddressLine = "456 Oak Ave", City="Shelbyville", PostalCode="23456", OngoingJobs = 0 },
                new CustomerModel { Id = 2, UserId=0,FirstName = "Peter", LastName = "Jones", Email = "peter.jones@example.com", Phone = "555-0103", AddressLine = "789 Pine Ln", City="Capital City", PostalCode="34567", OngoingJobs = 1 },
                new CustomerModel { Id = 3, UserId=0,FirstName = "Mary", LastName = "Johnson", Email = "mary.j@example.com", Phone = "555-0104", AddressLine = "101 Elm Ct", City="Ogdenville", PostalCode="45678", OngoingJobs = 0 },
                new CustomerModel { Id = 4, UserId=0,FirstName = "David", LastName = "Williams", Email = "d.williams@example.com", Phone = "555-0105", AddressLine = "212 Birch Rd", City="North Haverbrook", PostalCode="56789", OngoingJobs = 3 }
            };

            UpdateGridDisplay();
        }

        /// <summary>
        /// Central method to filter, sort, and display data in the grid.
        /// </summary>
        private void UpdateGridDisplay()
        {
            if (allCustomers == null) return;

            IEnumerable<CustomerModel> processedData = allCustomers;

            // 1. Filter based on search text
            string searchText = textBoxSearch.Text.ToLower().Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                processedData = processedData.Where(c =>
                    c.FullName.ToLower().Contains(searchText) ||
                    c.Email.ToLower().Contains(searchText)
                ).ToList();
            }

            // 2. Sort the filtered data
            string sortBy = comboBoxSortBy.SelectedItem.ToString();
            switch (sortBy)
            {
                case "Full Name":
                    processedData = isSortAscending ? processedData.OrderBy(c => c.FullName) : processedData.OrderByDescending(c => c.FullName);
                    break;
                case "Ongoing Jobs":
                    processedData = isSortAscending ? processedData.OrderBy(c => c.OngoingJobs) : processedData.OrderByDescending(c => c.OngoingJobs);
                    break;
                default: // "Customer ID"
                    processedData = isSortAscending ? processedData.OrderBy(c => c.Id) : processedData.OrderByDescending(c => c.Id);
                    break;
            }

            // 3. Display the final processed data by setting the DataSource
            dataGridViewCustomers.DataSource = processedData.ToList();
        }

        private void buttonAddNew_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditCustomerForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    allCustomers.Add(form.TheCustomer);
                    UpdateGridDisplay();
                    MessageBox.Show("Customer successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewCustomers.Columns[e.ColumnIndex].Name != "Edit")
                return;

            string customerId = dataGridViewCustomers.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            var customerToEdit = allCustomers.FirstOrDefault(c => c.Id.ToString() == customerId);

            if (customerToEdit != null)
            {
                using (var form = new AddEditCustomerForm(customerToEdit))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int index = allCustomers.FindIndex(c => c.Id.ToString() == customerId);
                        if (index != -1)
                        {
                            allCustomers[index] = form.TheCustomer;
                        }
                        UpdateGridDisplay();
                        MessageBox.Show("Customer successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// Handles changes to any sorting or filtering control.
        /// </summary>
        private void Sort_Changed(object sender, EventArgs e)
        {
            UpdateGridDisplay();
        }

        /// <summary>
        /// Toggles the sort order and refreshes the grid.
        /// </summary>
        private void buttonSortOrder_Click(object sender, EventArgs e)
        {
            isSortAscending = !isSortAscending;
            buttonSortOrder.Text = isSortAscending ? "ASC" : "DESC";
            UpdateGridDisplay();
        }
    }
}