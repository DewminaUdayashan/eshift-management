using eshift_management.Core.Services;
using eshift_management.Models;
using eshift_management.Repositories;
using eshift_management.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eshift_management.Panes
{
    public partial class TrucksPane : UserControl
    {
        private readonly ITruckService _truckService;
        private bool isSortAscending = true;

        public TrucksPane()
        {
            InitializeComponent();

            // In a real application with Dependency Injection, this would be injected.
            _truckService = new TruckService(new TruckRepository());

            SetupDataGridView();
            SetupSorting();

            // Asynchronously load the initial truck data.
            _ = LoadTrucksAsync();
        }

        private async Task LoadTrucksAsync()
        {
            try
            {
                // Construct the filter dictionary from UI controls.
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
                    "Model" => "Model",
                    "Status" => "Status",
                    _ => "Id" // Default to "Truck ID"
                };

                var trucks = await _truckService.GetAllTrucksAsync(filter, orderByProperty, isSortAscending);
                dataGridViewTrucks.DataSource = trucks.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load trucks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            dataGridViewTrucks.AutoGenerateColumns = false;
            dataGridViewTrucks.Columns.Clear();
            AddGridColumn("Id", "Truck ID");
            AddGridColumn("Model", "Model");
            AddGridColumn("LicensePlate", "License Plate");
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
            dataGridViewTrucks.Columns.Add(editButtonColumn);
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
            dataGridViewTrucks.Columns.Add(column);
        }

        private void SetupSorting()
        {
            comboBoxSortBy.Items.Add("Truck ID");
            comboBoxSortBy.Items.Add("Model");
            comboBoxSortBy.Items.Add("Status");
            comboBoxSortBy.SelectedIndex = 0;
        }

        private async void buttonAddNew_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditTruckForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await _truckService.CreateTruckAsync(form.TheTruck);
                        await LoadTrucksAsync(); // Refresh data from the database
                        MessageBox.Show("Truck successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to add truck: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void dataGridViewTrucks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewTrucks.Columns[e.ColumnIndex].Name != "Edit")
                return;

            if (dataGridViewTrucks.Rows[e.RowIndex].DataBoundItem is Truck truckToEdit)
            {
                using (var form = new AddEditTruckForm(truckToEdit))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            await _truckService.UpdateTruckAsync(form.TheTruck);
                            await LoadTrucksAsync(); // Refresh data
                            MessageBox.Show("Truck successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to update truck: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private async void Sort_Changed(object sender, EventArgs e)
        {
            await LoadTrucksAsync();
        }

        private async void buttonSortOrder_Click(object sender, EventArgs e)
        {
            isSortAscending = !isSortAscending;
            buttonSortOrder.Text = isSortAscending ? "ASC" : "DESC";
            await LoadTrucksAsync();
        }
    }
}
