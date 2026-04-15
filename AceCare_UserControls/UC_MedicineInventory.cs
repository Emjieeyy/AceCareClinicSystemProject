using AceCareClinicSystem.Controllers;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AceCareClinicSystem.Services;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_MedicineInventory : UserControl
    {
        private InventoryController _controller = new InventoryController();
        private string _originalName = "";

        // ========== PAGINATION VARIABLES ==========
        private int _medicinePage = 1;
        private int _suppliesPage = 1;
        private int _totalMedicinePages = 1;
        private int _totalSuppliesPages = 1;
        private const int ITEMS_PER_PAGE = 10;

        public UC_MedicineInventory()
        {
            InitializeComponent();
            dgvMedicineRecords.AutoGenerateColumns = true;
            dgvSuppliesRecords.AutoGenerateColumns = true;
            DataGridViewStyle.ApplyModernDesign(dgvMedicineRecords);
            DataGridViewStyle.ApplyModernDesign(dgvSuppliesRecords);
            dgvMedicineRecords.DataError += dgv_DataError;
            dgvSuppliesRecords.DataError += dgv_DataError;
            RefreshDashboard();
        }

        private void dgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        // ========== REFRESH DASHBOARD WITH PAGINATION ==========
        private void RefreshDashboard()
        {
            try
            {
                string searchText = txtSearchInventory.Text.Trim();

                // 1. Medicine Grid (with pagination)
                DataTable medData = _controller.GetRecordsPaginated("Medicine", searchText, _medicinePage, ITEMS_PER_PAGE);
                BindingHelper.BindToGrid(dgvMedicineRecords, medData);
                DataGridViewStyle.FormatHeaders(dgvMedicineRecords);
                _totalMedicinePages = _controller.GetTotalPages("Medicine", searchText, ITEMS_PER_PAGE);

                // 2. Supplies Grid (with pagination)
                DataTable supData = _controller.GetRecordsPaginated("Supply", searchText, _suppliesPage, ITEMS_PER_PAGE);
                BindingHelper.BindToGrid(dgvSuppliesRecords, supData);
                DataGridViewStyle.FormatHeaders(dgvSuppliesRecords);
                _totalSuppliesPages = _controller.GetTotalPages("Supply", searchText, ITEMS_PER_PAGE);

                // 3. Update Pagination Display for both tabs
                UpdateMedicinePaginationDisplay();
                UpdateSuppliesPaginationDisplay();

                // 4. Update Dashboard stats
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

        // ========== UPDATE MEDICINE PAGINATION UI ==========
        private void UpdateMedicinePaginationDisplay()
        {
            // Medicine tab buttons
            btnPrev.Enabled = _medicinePage > 1;
            btnNext.Enabled = _medicinePage < _totalMedicinePages;
        }

        // ========== UPDATE SUPPLIES PAGINATION UI ==========
        private void UpdateSuppliesPaginationDisplay()
        {
            // Supplies tab buttons
            btnPrevSuppliesRecord.Enabled = _suppliesPage > 1;
            btnNextSuppliesRecord.Enabled = _suppliesPage < _totalSuppliesPages;
        }

        // ========== MEDICINE TAB BUTTONS ==========

        // 🔄 RELOAD BUTTON (Medicine)
        private void ReloadPix_Click(object sender, EventArgs e)
        {
            txtSearchInventory.Text = "";
            _medicinePage = 1;
            RefreshDashboard();
        }

        // << PREVIOUS BUTTON (Medicine)
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_medicinePage > 1)
            {
                _medicinePage--;
                RefreshDashboard();
            }
        }

        // >> NEXT BUTTON (Medicine)
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_medicinePage < _totalMedicinePages)
            {
                _medicinePage++;
                RefreshDashboard();
            }
        }

        // ========== SUPPLIES TAB BUTTONS ==========

        // 🔄 RELOAD BUTTON (Supplies)
        private void ReloadPixSuppliesRecord_Click(object sender, EventArgs e)
        {
            txtSearchInventory.Text = "";
            _suppliesPage = 1;
            RefreshDashboard();
        }

        // << PREVIOUS BUTTON (Supplies)
        private void btnPrevSuppliesRecord_Click(object sender, EventArgs e)
        {
            if (_suppliesPage > 1)
            {
                _suppliesPage--;
                RefreshDashboard();
            }
        }

        // >> NEXT BUTTON (Supplies)
        private void btnNextSuppliesRecord_Click(object sender, EventArgs e)
        {
            if (_suppliesPage < _totalSuppliesPages)
            {
                _suppliesPage++;
                RefreshDashboard();
            }
        }

        // ========== SEARCH BUTTON ==========
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _medicinePage = 1;
            _suppliesPage = 1;
            RefreshDashboard();
        }

        // ========== ADD METHODS ==========
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
                RefreshDashboard();
            }
            else
            {
                MessageBox.Show("Failed to add item. Check database connection or field constraints.");
            }
        }

        // ========== EDIT METHOD ==========
        private void btnEditItem_Click(object sender, EventArgs e)
        {
            bool isMedicine = dgvMedicineRecords.Visible;
            DataGridView activeGrid = isMedicine ? dgvMedicineRecords : dgvSuppliesRecords;

            if (activeGrid.SelectedRows.Count > 0)
            {
                try
                {
                    var row = activeGrid.SelectedRows[0];
                    string oldName, currentQty, currentUsage, currentExpiry;

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

                    string newName = Interaction.InputBox("Edit Item Name:", "AceCare Editor", oldName);
                    if (string.IsNullOrWhiteSpace(newName)) return;

                    string newQtyStr = Interaction.InputBox("Update Quantity:", "AceCare Editor", currentQty);
                    if (!int.TryParse(newQtyStr, out int qty)) return;

                    string newUsageStr = Interaction.InputBox("Update Weekly Usage:", "AceCare Editor", currentUsage);
                    if (!double.TryParse(newUsageStr, out double usage)) return;

                    string newExpiryStr = Interaction.InputBox("Update Expiry (MM-DD-YYYY):", "AceCare Editor", currentExpiry);
                    if (!DateTime.TryParse(newExpiryStr, out DateTime expiryDate)) return;

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

        // ========== DELETE METHOD ==========
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridView activeGrid = dgvMedicineRecords.Visible ? dgvMedicineRecords : dgvSuppliesRecords;

            if (activeGrid.SelectedRows.Count > 0)
            {
                string itemName = activeGrid.SelectedRows[0].Cells[0].Value?.ToString();

                if (string.IsNullOrEmpty(itemName)) return;

                if (MessageBox.Show($"Delete {itemName}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (_controller.DeleteItem(itemName))
                    {
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