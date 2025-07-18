using eshift_management.Models;
using eshift_management.Repositories.Services;
using eshift_management.Services.Implementations;
using eshift_management.Services.Interfaces;

namespace eshift_management
{
    public partial class CustomersPane : UserControl
    {
        private readonly ICustomerService _customerService;
        private bool isSortAscending = true;

        public CustomersPane()
        {
            InitializeComponent();
            buttonAddNew.Visible = false;

            var customerRepo = new CustomerRepository();
            _customerService = new CustomerService(customerRepo);

            SetupDataGridView();
            // ** FIX: Setup sorting controls BEFORE loading data to prevent null reference **
            SetupSorting();

            _ = LoadCustomersAsync(); // Load data asynchronously from the service
        }

        /// <summary>
        /// Sets up the visual style and columns for the DataGridView.
        /// </summary>
        private void SetupDataGridView()
        {
            dataGridViewCustomers.AutoGenerateColumns = false;
            dataGridViewCustomers.Columns.Clear();

            AddGridColumn("UserID", "Customer ID", 100);
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
        /// Fetches, filters, and sorts customer data from the service and updates the grid.
        /// </summary>
        private async Task LoadCustomersAsync()
        {
            try
            {
                var filter = new Dictionary<string, object>();
                string? searchTerm = textBoxSearch.Text.Trim();
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    filter.Add("SearchTerm", searchTerm);
                }

                string sortBy = comboBoxSortBy.SelectedItem.ToString();
                string orderByProperty = sortBy switch
                {
                    "First Name" => "FirstName",
                    "Ongoing Jobs" => "OngoingJobs",
                    _ => "UserId" // Default to "Customer ID"
                };

                var customers = await _customerService.GetAllAsync(filter, orderByProperty, isSortAscending);
                dataGridViewCustomers.DataSource = customers.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Populates the sorting dropdown menu.
        /// </summary>
        private void SetupSorting()
        {
            comboBoxSortBy.Items.Add("Customer ID");
            comboBoxSortBy.Items.Add("First Name");
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

        /// <summary>
        /// Handles the click event for the 'Add New' button, opening the Add/Edit form.
        /// </summary>
        private async void buttonAddNew_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditCustomerForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await _customerService.AddAsync(form.TheCustomer);
                        await LoadCustomersAsync(); // Refresh grid from database
                        MessageBox.Show("Customer successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to add customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Handles cell content clicks, specifically for the 'Edit' button in the grid.
        /// </summary>
        private async void dataGridViewCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewCustomers.Columns[e.ColumnIndex].Name != "Edit")
                return;

            if (dataGridViewCustomers.Rows[e.RowIndex].DataBoundItem is CustomerModel customerToEdit)
            {
                using (var form = new AddEditCustomerForm(customerToEdit))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            await _customerService.UpdateAsync(form.TheCustomer);
                            await LoadCustomersAsync(); // Refresh grid from database
                            MessageBox.Show("Customer successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to update customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles changes to any sorting or filtering control.
        /// </summary>
        private async void Sort_Changed(object sender, EventArgs e)
        {
            await LoadCustomersAsync();
        }

        /// <summary>
        /// Toggles the sort order and refreshes the grid.
        /// </summary>
        private async void buttonSortOrder_Click(object sender, EventArgs e)
        {
            isSortAscending = !isSortAscending;
            buttonSortOrder.Text = isSortAscending ? "ASC" : "DESC";
            await LoadCustomersAsync();
        }
    }
}