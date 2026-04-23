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
        private bool _isEditMode = false;
        private bool _isAddingNew = false;
        private int _medicinePage = 1;
        private int _suppliesPage = 1;
        private int _totalMedicinePages = 1;
        private int _totalSuppliesPages = 1;
        private const int ITEMS_PER_PAGE = 10;

        private DataTable _medicineTable;
        private DataTable _suppliesTable;
        public UC_MedicineInventory()
        {

            InitializeComponent();

            SetupGrid(dgvMedicineRecords);
            SetupGrid(dgvSuppliesRecords);
        }

        private void SetupGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AutoGenerateColumns = true;
            grid.AllowUserToAddRows = false;
            DataGridViewStyle.ApplyModernDesign(grid);
            grid.DataError += (s, e) => { e.ThrowException = false; e.Cancel = true; };
            grid.CellEndEdit += Grid_CellEndEdit;
            grid.RowValidated += Grid_RowValidated;
        }

        private void Grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_isAddingNew) return;
            DataGridView grid = sender as DataGridView;
            SaveSingleRow(grid, e.RowIndex);
        }

        private void Grid_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView grid = sender as DataGridView;
            int lastIndex = grid.Rows.Count - 1;
            if (!_isAddingNew || e.RowIndex != lastIndex) return;
            if (SaveNewRow(grid))
            {
                _isAddingNew = false;
                this.BeginInvoke(new Action(() => RefreshDashboard()));
            }
        }

        // FIXED: Removed nested try-catch, added proper closing brace
        private void RefreshDashboard()
        {
            try
            {
                string search = txtSearchInventory.Text.Trim();

                // DEBUG: Check what values we're getting
                var stats = _controller.GetDashboardStats();
                System.Diagnostics.Debug.WriteLine($"MEDICINE QTY: {stats.med}");
                System.Diagnostics.Debug.WriteLine($"SUPPLY QTY: {stats.sup}");

                _medicineTable = _controller.GetRecordsPaginated("Medicine", search, _medicinePage, ITEMS_PER_PAGE);
                _totalMedicinePages = _controller.GetTotalPages("Medicine", search, ITEMS_PER_PAGE);

                dgvMedicineRecords.DataSource = null;
                dgvMedicineRecords.DataSource = _medicineTable;
                HideIdColumn(dgvMedicineRecords);

                _suppliesTable = _controller.GetRecordsPaginated("Supply", search, _suppliesPage, ITEMS_PER_PAGE);
                _totalSuppliesPages = _controller.GetTotalPages("Supply", search, ITEMS_PER_PAGE);

                dgvSuppliesRecords.DataSource = null;
                dgvSuppliesRecords.DataSource = _suppliesTable;
                HideIdColumn(dgvSuppliesRecords);

                UpdateMedicinePaginationDisplay();
                UpdateSuppliesPaginationDisplay();

                lblCountTotalMedicine.Text = stats.med;
                lblCountTotalSupplies.Text = stats.sup;
                lblCountLowStock.Text = stats.low;
                lblCountExpiring.Text = stats.exp;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing dashboard: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void HideIdColumn(DataGridView dgv)
        {
            if (dgv.Columns["ItemID"] != null)
                dgv.Columns["ItemID"].Visible = false;
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
            _suppliesPage = 1;
            _isAddingNew = false;
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
        private void btnAddMedicine_Click(object sender, EventArgs e) => AddNewRow(dgvMedicineRecords, _medicineTable);


        private void btnAddSupply_Click(object sender, EventArgs e) => AddNewRow(dgvSuppliesRecords, _suppliesTable);


        private void AddNewRow(DataGridView grid, DataTable table)
        {
            if (table == null) { MessageBox.Show("Please wait for data to load."); return; }
            if (_isAddingNew) { FocusLastCell(grid); return; }

            DataRow row = table.NewRow();
            row["ItemID"] = 0;
            row["Name"] = "";
            row["BatchNumber"] = "";
            row["Quantity"] = 0;
            row["WeeklyUsage"] = 0;
            row["ExpiryDate"] = DateTime.Now.AddYears(1);
            table.Rows.Add(row);

            _isAddingNew = true;
            grid.ReadOnly = false;
            if (grid.Columns["ItemID"] != null) grid.Columns["ItemID"].ReadOnly = true;

            FocusLastCell(grid);
        }

        private void FocusLastCell(DataGridView grid)
        {
            if (grid.Rows.Count == 0) return;
            int lastIndex = grid.Rows.Count - 1;
            grid.ClearSelection();
            grid.Rows[lastIndex].Selected = true;

            foreach (DataGridViewColumn col in grid.Columns)
            {
                if (col.Visible && col.DataPropertyName != "ItemID")
                {
                    grid.CurrentCell = grid.Rows[lastIndex].Cells[col.Index];
                    grid.BeginEdit(true);
                    return;
                }
            }
        }

        private bool SaveNewRow(DataGridView grid)
        {
            if (!(grid.DataSource is DataTable table) || table.Rows.Count == 0) return false;
            int lastIndex = table.Rows.Count - 1;
            DataRow row = table.Rows[lastIndex];
            if (row.RowState != DataRowState.Added) return false;

            try
            {
                string name = row["Name"]?.ToString() ?? "";
                string batch = row["BatchNumber"]?.ToString() ?? "";
                if (string.IsNullOrWhiteSpace(name)) { MessageBox.Show("Name cannot be empty.", "Validation Error"); return false; }

                int qty = Convert.ToInt32(row["Quantity"] ?? 0);
                DateTime expiry = Convert.ToDateTime(row["ExpiryDate"] ?? DateTime.Now);
                string category = grid == dgvMedicineRecords ? "Medicine" : "Supply";

                if (_controller.AddItem(name, batch, qty, category, expiry))
                {
                    row.AcceptChanges();
                    return true;
                }
                MessageBox.Show("Failed to save to database.", "Error");
                return false;
            }
            catch (Exception ex) { MessageBox.Show("Error saving: " + ex.Message, "Error"); return false; }
        }

        private void SaveSingleRow(DataGridView grid, int rowIndex)
        {
            if (!(grid.DataSource is DataTable table) || rowIndex < 0 || rowIndex >= table.Rows.Count) return;
            DataRow row = table.Rows[rowIndex];
            if (row.RowState != DataRowState.Modified || row["ItemID"] == DBNull.Value) return;

            try
            {
                int id = Convert.ToInt32(row["ItemID"]);
                if (id == 0) return;
                string name = row["Name"]?.ToString() ?? "";
                string batch = row["BatchNumber"]?.ToString() ?? "";
                int qty = Convert.ToInt32(row["Quantity"] ?? 0);
                double usage = Convert.ToDouble(row["WeeklyUsage"] ?? 0);
                DateTime expiry = Convert.ToDateTime(row["ExpiryDate"] ?? DateTime.Now);

                if (_controller.UpdateFullItem(id, name, batch, qty, usage, expiry)) row.AcceptChanges();
            }
            catch (Exception ex) { Console.WriteLine($"Auto-save error: {ex.Message}"); }
        }

        // ========== DELETE METHOD ==========
        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            DataGridView activeGrid = dgvMedicineRecords.Visible ? dgvMedicineRecords : dgvSuppliesRecords;

            if (activeGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            int id = Convert.ToInt32(activeGrid.SelectedRows[0].Cells["ItemID"].Value);

            if (id == 0)
            {
                DataRowView drv = activeGrid.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {
                    drv.Row.Delete();
                    MessageBox.Show("Unsaved row removed.");
                    _isAddingNew = false;
                    activeGrid.ReadOnly = true;
                }
                return;
            }

            if (MessageBox.Show("Delete this item permanently?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (_controller.DeleteItem(id))
                {
                    MessageBox.Show("Item deleted successfully!");
                    RefreshDashboard();
                }
                else
                {
                    MessageBox.Show("Failed to delete item.");
                }
            }
        }

        private void UC_MedicineInventory_Load(object sender, EventArgs e)
        {
            RefreshDashboard();
        }

        // ========== EDIT ==========
        private void btnEditItem_Click(object sender, EventArgs e)
        {
            DataGridView activeGrid = dgvMedicineRecords.Visible ? dgvMedicineRecords : dgvSuppliesRecords;
            DataTable activeTable = dgvMedicineRecords.Visible ? _medicineTable : _suppliesTable;

            if (!_isEditMode)
            {
                if (activeTable == null || activeTable.Rows.Count == 0)
                {
                    MessageBox.Show("No data to edit.");
                    return;
                }

                _isEditMode = true;
                btnEditItem.Text = "Save Changes";
                btnEditItem.BackColor = Color.LightGreen;

                activeGrid.ReadOnly = false;
                if (activeGrid.Columns["ItemID"] != null)
                    activeGrid.Columns["ItemID"].ReadOnly = true;

                activeGrid.Focus();
            }
            else
            {
                try
                {
                    bool saved = SaveGridChanges(activeGrid, activeTable);

                    _isEditMode = false;
                    btnEditItem.Text = "Edit";
                    btnEditItem.BackColor = SystemColors.Control;
                    activeGrid.ReadOnly = true;

                    if (saved)
                    {
                        MessageBox.Show("Successfully updated records!", "AceCare",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _isAddingNew = false;
                        RefreshDashboard();
                    }
                    else
                    {
                        MessageBox.Show("No changes were saved. Did you edit any rows?", "AceCare Notice",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving changes: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    _isEditMode = false;
                    btnEditItem.Text = "Edit";
                    btnEditItem.BackColor = SystemColors.Control;
                    activeGrid.ReadOnly = true;
                }
            }
        }

        private bool SaveGridChanges(DataGridView grid, DataTable table)
        {
            if (grid.CurrentCell != null && grid.IsCurrentCellInEditMode)
            {
                grid.EndEdit();
            }

            grid.CurrentCell = null;

            if (grid.BindingContext[table] != null)
            {
                grid.BindingContext[table].EndCurrentEdit();
            }

            if (table == null) return false;

            int updateCount = 0;
            int insertCount = 0;

            foreach (DataRow row in table.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                    continue;

                if (row.RowState == DataRowState.Added)
                {
                    try
                    {
                        string name = row["Name"].ToString();
                        string batch = row["BatchNumber"]?.ToString() ?? "";
                        if (string.IsNullOrWhiteSpace(name))
                        {
                            MessageBox.Show("Name cannot be empty.");
                            continue;
                        }

                        int qty = Convert.ToInt32(row["Quantity"]);
                        DateTime expiry = (row["ExpiryDate"] == DBNull.Value) ?
                            DateTime.Now : Convert.ToDateTime(row["ExpiryDate"]);

                        string category = (grid == dgvMedicineRecords) ? "Medicine" : "Supply";

                        if (_controller.AddItem(name, batch, qty, category, expiry))
                        {
                            insertCount++;
                            row.AcceptChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error inserting row: {ex.Message}");
                    }
                }
                else if (row.RowState == DataRowState.Modified)
                {
                    if (row["ItemID"] == DBNull.Value)
                        continue;

                    try
                    {
                        int id = Convert.ToInt32(row["ItemID"]);
                        if (id == 0) continue;

                        string name = row["Name"].ToString();
                        string batch = row["BatchNumber"]?.ToString() ?? "";
                        int qty = Convert.ToInt32(row["Quantity"]);
                        double usage = (row["WeeklyUsage"] == DBNull.Value) ?
                            0 : Convert.ToDouble(row["WeeklyUsage"]);
                        DateTime expiry = (row["ExpiryDate"] == DBNull.Value) ?
                            DateTime.Now : Convert.ToDateTime(row["ExpiryDate"]);

                        if (_controller.UpdateFullItem(id, name, batch, qty, usage, expiry))
                        {
                            updateCount++;
                            row.AcceptChanges();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error updating row {row["ItemID"]}: {ex.Message}");
                    }
                }
            }

            return (updateCount + insertCount) > 0;
        }
    }
}

