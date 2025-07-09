using eshift_management.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace eshift_management.Panes
{
    public partial class TrucksPane : UserControl
    {
        private List<Truck> allTrucks;
        private bool isSortAscending = true;

        public TrucksPane()
        {
            InitializeComponent();
            SetupDataGridView();
            SetupSorting();
            LoadDummyData();
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

        private void LoadDummyData()
        {
            allTrucks = new List<Truck>
            {
                new Truck { Id = "TRK-01", Model = "Isuzu Elf", LicensePlate = "CBA-1234", Status = ResourceStatus.Available },
                new Truck { Id = "TRK-02", Model = "Mitsubishi Canter", LicensePlate = "CAB-5678", Status = ResourceStatus.Assigned },
                new Truck { Id = "TRK-03", Model = "Fuso Fighter", LicensePlate = "CAA-9101", Status = ResourceStatus.Available },
                new Truck { Id = "TRK-04", Model = "Isuzu Elf", LicensePlate = "CBC-5555", Status = ResourceStatus.Available },
            };
            UpdateGridDisplay();
        }

        private void UpdateGridDisplay()
        {
            if (allTrucks == null) return;
            IEnumerable<Truck> processedData = allTrucks;
            string searchText = textBoxSearch.Text.ToLower().Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                processedData = processedData.Where(t =>
                    t.Id.ToLower().Contains(searchText) ||
                    t.Model.ToLower().Contains(searchText) ||
                    t.LicensePlate.ToLower().Contains(searchText)
                ).ToList();
            }
            string sortBy = comboBoxSortBy.SelectedItem.ToString();
            switch (sortBy)
            {
                case "Model":
                    processedData = isSortAscending ? processedData.OrderBy(t => t.Model) : processedData.OrderByDescending(t => t.Model);
                    break;
                case "Status":
                    processedData = isSortAscending ? processedData.OrderBy(t => t.Status) : processedData.OrderByDescending(t => t.Status);
                    break;
                default:
                    processedData = isSortAscending ? processedData.OrderBy(t => t.Id) : processedData.OrderByDescending(t => t.Id);
                    break;
            }
            dataGridViewTrucks.DataSource = processedData.ToList();
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
            using (var form = new AddEditTruckForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    allTrucks.Add(form.TheTruck);
                    UpdateGridDisplay();
                    MessageBox.Show("Truck successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewTrucks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridViewTrucks.Columns[e.ColumnIndex].Name != "Edit")
                return;

            string truckId = dataGridViewTrucks.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            var truckToEdit = allTrucks.FirstOrDefault(t => t.Id == truckId);

            if (truckToEdit != null)
            {
                using (var form = new AddEditTruckForm(truckToEdit))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int index = allTrucks.FindIndex(t => t.Id == truckId);
                        if (index != -1)
                        {
                            allTrucks[index] = form.TheTruck;
                        }
                        UpdateGridDisplay();
                        MessageBox.Show("Truck successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}