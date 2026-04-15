using AceCareClinicSystem.Controllers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AceCareClinicSystem.Services;
using AceCareClinicSystem.Controllers;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_MedicineInventory : UserControl
    {
        private InventoryController _controller = new InventoryController();
        private string _originalName = ""; // Required to find the correct record in MySQL when the name changes

        public UC_MedicineInventory()
        {
            InitializeComponent();
            dgvMedicineRecords.AutoGenerateColumns = true;
            dgvSuppliesRecords.AutoGenerateColumns = true;
            // Apply Modern Design
            DataGridViewStyle.ApplyModernDesign(dgvMedicineRecords);
            DataGridViewStyle.ApplyModernDesign(dgvSuppliesRecords);
            dgvMedicineRecords.DataError += dgv_DataError;
            dgvSuppliesRecords.DataError += dgv_DataError;
            RefreshDashboard();
        }
        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // This stops the dialog popup
            e.ThrowException = false;
        }
        private void RefreshDashboard()
        {
            try
            {
                // 1. Medicine Grid
                DataTable medData = _controller.GetRecords("Medicine", txtSearchInventory.Text);
                BindingHelper.BindToGrid(dgvMedicineRecords, medData);

                // --- CALL THE METHOD HERE ---
                DataGridViewStyle.FormatHeaders(dgvMedicineRecords);

                // 2. Supplies Grid
                DataTable supData = _controller.GetRecords("Supply", txtSearchInventory.Text);
                BindingHelper.BindToGrid(dgvSuppliesRecords, supData);

                // --- CALL THE METHOD HERE ---
                DataGridViewStyle.FormatHeaders(dgvSuppliesRecords);

                // 3. Update the Dashboard stats
                var stats = _controller.GetDashboardStats();
                lblCountTotalMedicine.Text = stats.med;
                lblCountTotalSupplies.Text = stats.sup;
                lblCountLowStock.Text = stats.low;
                lblCountExpiring.Text = stats.exp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message);
            }
        }



        private void btnSearch_Click(object sender, EventArgs e) => RefreshDashboard();

        private void btnAddMedicine_Click(object sender, EventArgs e)
        {
            AddInventoryItem("Medicine");
        }

        private void btnAddSupply_Click(object sender, EventArgs e)
        {
            AddInventoryItem("Supply");
        }
        private void AddInventoryItem(string category)
        {
            string name = Interaction.InputBox($"Enter {category} Name:", "New Record");
            if (string.IsNullOrWhiteSpace(name)) return;

            string qtyStr = Interaction.InputBox("Quantity:", "New Record", "0");
            if (!int.TryParse(qtyStr, out int qty)) return;

            string expiryStr = Interaction.InputBox("Expiry (yyyy-MM-dd):", "New Record", DateTime.Now.ToString("yyyy-MM-dd"));
            if (!DateTime.TryParse(expiryStr, out DateTime expiry)) return;

            if (_controller.AddItem(name, qty, category, expiry))
            {
                MessageBox.Show($"{category} added successfully!");
                RefreshDashboard(); // This forces the grid to reload from DB
            }
            else
            {
                MessageBox.Show("Failed to add item. Check database connection or field constraints.");
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            // 1. Identify the active grid
            bool isMedicine = dgvMedicineRecords.Visible;
            DataGridView activeGrid = isMedicine ? dgvMedicineRecords : dgvSuppliesRecords;

            if (activeGrid.SelectedRows.Count > 0)
            {
                try
                {
                    var row = activeGrid.SelectedRows[0];
                    string oldName, currentQty, currentUsage, currentExpiry;

                    // 2. Map names based on which grid is active
                    if (isMedicine)
                    {
                        oldName = row.Cells["MedicineName"].Value?.ToString() ?? "";
                        currentQty = row.Cells["InStock"].Value?.ToString() ?? "0";
                        currentUsage = row.Cells["UsedWk"].Value?.ToString() ?? "0";
                        currentExpiry = row.Cells["Expiry"].Value?.ToString() ?? "";
                    }
                    else
                    {
                        oldName = row.Cells["colSupName"].Value?.ToString() ?? "";
                        currentQty = row.Cells["colSupQty"].Value?.ToString() ?? "0";
                        currentUsage = row.Cells["colSupUsage"].Value?.ToString() ?? "0";
                        currentExpiry = row.Cells["colSupExpiry"].Value?.ToString() ?? "";
                    }

                    // 3. Prompt for updates
                    string newName = Interaction.InputBox("Edit Item Name:", "AceCare Editor", oldName);
                    if (string.IsNullOrWhiteSpace(newName)) return;

                    string newQtyStr = Interaction.InputBox("Update Quantity:", "AceCare Editor", currentQty);
                    if (!int.TryParse(newQtyStr, out int qty)) return;

                    string newUsageStr = Interaction.InputBox("Update Weekly Usage:", "AceCare Editor", currentUsage);
                    if (!double.TryParse(newUsageStr, out double usage)) return;

                    string newExpiryStr = Interaction.InputBox("Update Expiry (MM-DD-YYYY):", "AceCare Editor", currentExpiry);
                    if (!DateTime.TryParse(newExpiryStr, out DateTime expiryDate)) return;

                    // 4. Update Database
                    if (_controller.UpdateFullItem(oldName, newName, qty, usage, expiryDate))
                    {
                        MessageBox.Show("Item successfully updated!");
                        RefreshDashboard();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error mapping columns: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a full row (click the arrow on the left).");
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridView activeGrid = dgvMedicineRecords.Visible ? dgvMedicineRecords : dgvSuppliesRecords;

            if (activeGrid.SelectedRows.Count > 0)
            {
                // 1. Get the name safely
                string itemName = activeGrid.SelectedRows[0].Cells[0].Value?.ToString();

                if (string.IsNullOrEmpty(itemName)) return;

                if (MessageBox.Show($"Delete {itemName}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // 2. Perform the delete
                    if (_controller.DeleteItem(itemName))
                    {
                        // 3. IMPORTANT: Clear selection BEFORE refreshing to avoid "ghost row" errors
                        activeGrid.ClearSelection();

                        RefreshDashboard();
                        MessageBox.Show("Item deleted successfully.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.");
            }
        }

        private void UC_MedicineInventory_Load(object sender, EventArgs e)
        {
            RefreshDashboard();
        }
    }
}
