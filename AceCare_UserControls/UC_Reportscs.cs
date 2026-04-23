using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AceCareClinicSystem.Controllers;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using System.IO;
using System.Linq;
using MySql.Data.MySqlClient;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_Reportscs : UserControl
    {
        private DashboardController dashboardController = new DashboardController();
        private PatientController patientController = new PatientController();
        private InventoryController inventoryController = new InventoryController();
        private ConsultationController consultationController = new ConsultationController();
        private DbConnection db = new DbConnection();

        // Pagination
        private int currentOffset = 0;
        private int totalRecords = 0;
        private const int PageSize = 10;
        private DataTable _unifiedDataCache = null;

        public UC_Reportscs()
        {
            InitializeComponent();

            SetupDateFilterCombo();
            SetupCategoryFilter();
            SetupGridColumns(); // ⭐ NEW: Setup columns with hidden extras

            cbDateFilter.SelectedIndexChanged += (s, e) => { currentOffset = 0; LoadData(); };
            cbDataViewFilter.SelectedIndexChanged += (s, e) => { currentOffset = 0; LoadReportTable(); };

            poisonTextBox1.TextChanged += (s, e) =>
            {
                if (poisonTextBox1.Text != "Search") { currentOffset = 0; LoadReportTable(); }
            };
            poisonTextBox1.Click += (s, e) => { if (poisonTextBox1.Text == "Search") poisonTextBox1.Text = ""; };
            poisonTextBox1.Leave += (s, e) => { if (string.IsNullOrWhiteSpace(poisonTextBox1.Text)) poisonTextBox1.Text = "Search"; };

            hopeRoundButton2.Click += (s, e) => HandleExport();
            btnNext.Click += btnNext_Click;
            btnPrev.Click += btnPrev_Click;
            ReloadPix.Click += ReloadPix_Click;

            // ⭐ DOUBLE-CLICK to open Patient History
            poisonDataGridView1.CellDoubleClick += poisonDataGridView1_CellDoubleClick;

            cbDateFilter.SelectedIndex = 0;
            LoadData();

            poisonDataGridView1.RowTemplate.Height = 45;
            poisonDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None; // ⭐ Changed from Fill
        }

        // ⭐ SETUP COLUMNS — visible + hidden
        private void SetupGridColumns()
        {
            poisonDataGridView1.Columns.Clear();
            poisonDataGridView1.AutoGenerateColumns = false;

            // === VISIBLE COLUMNS (default view) ===
            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "LastVisit", HeaderText = "Last Visit", Width = 100, DataPropertyName = "LastVisit" });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "IDNumber", HeaderText = "ID No.", Width = 80, DataPropertyName = "IDNumber" });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "PatientName", HeaderText = "Patients Name", Width = 120, DataPropertyName = "PatientName" });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "PatientType", HeaderText = "Category", Width = 90, DataPropertyName = "PatientType" });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Description", HeaderText = "Description", Width = 150, DataPropertyName = "Description" });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "QtyDosage", HeaderText = "Qty / Dosage", Width = 100, DataPropertyName = "QtyDosage" });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Personnel", HeaderText = "Personnel", Width = 120, DataPropertyName = "Personnel" });

            // === HIDDEN COLUMNS (for export + Patient History jump) ===
            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "PatientId", HeaderText = "PID", Width = 50, DataPropertyName = "PatientId", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "ConsultationId", HeaderText = "ConID", Width = 50, DataPropertyName = "ConsultationId", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "AgeSex", HeaderText = "Age/Sex", Width = 70, DataPropertyName = "AgeSex", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "VisitType", HeaderText = "Visit Type", Width = 90, DataPropertyName = "VisitType", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "ChiefComplaint", HeaderText = "Chief Complaint", Width = 130, DataPropertyName = "ChiefComplaint", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Vitals", HeaderText = "Vitals", Width = 125, DataPropertyName = "Vitals", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "VitalsRecorded", HeaderText = "Vitals Recorded", Width = 135, DataPropertyName = "VitalsRecorded", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Diagnosis", HeaderText = "Diagnosis", Width = 150, DataPropertyName = "Diagnosis", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Medicine", HeaderText = "Medicine", Width = 105, DataPropertyName = "Medicine", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Outcome", HeaderText = "Outcome", Width = 100, DataPropertyName = "Outcome", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Status", HeaderText = "Status", Width = 85, DataPropertyName = "Status", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "HandledBy", HeaderText = "Handled By", Width = 130, DataPropertyName = "HandledBy", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "Remarks", HeaderText = "Remarks", Width = 160, DataPropertyName = "Remarks", Visible = false });

            poisonDataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "RecordCategory", HeaderText = "Category", Width = 80, DataPropertyName = "RecordCategory", Visible = false });
        }

        private void SetupDateFilterCombo()
        {
            cbDateFilter.Items.Clear();
            cbDateFilter.Items.Add("All Time");
            cbDateFilter.Items.Add("Today");
            cbDateFilter.Items.Add("Yesterday");
            cbDateFilter.Items.Add("Last 7 Days");
            cbDateFilter.Items.Add("Last 30 Days");
            cbDateFilter.Items.Add("This Month");
            cbDateFilter.Items.Add("Last Month");
            cbDateFilter.Items.Add("This Year");
            cbDateFilter.SelectedIndex = 0;
        }

        private void SetupCategoryFilter()
        {
            cbDataViewFilter.Items.Clear();
            cbDataViewFilter.Items.Add("All Records");
            cbDataViewFilter.Items.Add("Patients");
            cbDataViewFilter.Items.Add("Inventory");
            cbDataViewFilter.Items.Add("Consultations");
            cbDataViewFilter.SelectedIndex = 0;
        }

        private (DateTime from, DateTime to) GetDateRangeFromFilter()
        {
            DateTime today = DateTime.Today;
            DateTime fromDate = new DateTime(2000, 1, 1);
            DateTime toDate = DateTime.Today.AddYears(50);

            switch (cbDateFilter.SelectedItem?.ToString())
            {
                case "Today": fromDate = today; toDate = today.AddDays(1).AddTicks(-1); break;
                case "Yesterday": fromDate = today.AddDays(-1); toDate = today.AddTicks(-1); break;
                case "Last 7 Days": fromDate = today.AddDays(-7); toDate = today.AddDays(1).AddTicks(-1); break;
                case "Last 30 Days": fromDate = today.AddDays(-30); toDate = today.AddDays(1).AddTicks(-1); break;
                case "This Month": fromDate = new DateTime(today.Year, today.Month, 1); toDate = fromDate.AddMonths(1).AddTicks(-1); break;
                case "Last Month": fromDate = new DateTime(today.Year, today.Month, 1).AddMonths(-1); toDate = new DateTime(today.Year, today.Month, 1).AddTicks(-1); break;
                case "This Year": fromDate = new DateTime(today.Year, 1, 1); toDate = new DateTime(today.Year + 1, 1, 1).AddTicks(-1); break;
                default: fromDate = new DateTime(1900, 1, 1); toDate = DateTime.Today.AddYears(100); break;
            }
            return (fromDate, toDate);
        }

        public void LoadData()
        {
            UpdateStatsCards();
            currentOffset = 0;
            LoadReportTable();
        }

        private void UpdateStatsCards()
        {
            var stats = GetAccurateCounts();
            label1.Text = stats.TotalConsultations.ToString();
            label3.Text = stats.TotalInventory.ToString();
            label5.Text = stats.LowInventory.ToString();
            label10.Text = stats.TotalPatients.ToString();
            UpdateStockCircle();
        }

        private dynamic GetAccurateCounts()
        {
            var stats = new { TotalConsultations = 0, TotalPatients = 0, TotalInventory = 0, LowInventory = 0 };
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    int consultCount = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM consultations", conn).ExecuteScalar());
                    int patientCount = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM patients", conn).ExecuteScalar());
                    int inventoryTotal = Convert.ToInt32(new MySqlCommand("SELECT IFNULL(SUM(Quantity), 0) FROM inventory", conn).ExecuteScalar());
                    int lowCount = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM inventory WHERE Quantity < 10", conn).ExecuteScalar());
                    stats = new { TotalConsultations = consultCount, TotalPatients = patientCount, TotalInventory = inventoryTotal, LowInventory = lowCount };
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine("GetAccurateCounts Error: " + ex.Message); }
            return stats;
        }

        private void LoadReportTable(string search = "")
        {
            try
            {
                string searchTerm = string.IsNullOrEmpty(search) ? poisonTextBox1.Text : search;
                if (searchTerm == "Search" || string.IsNullOrWhiteSpace(searchTerm)) searchTerm = "";

                string categoryFilter = cbDataViewFilter.SelectedItem?.ToString() ?? "All Records";
                var (fromDate, toDate) = GetDateRangeFromFilter();

                DataTable unifiedData = BuildUnifiedData(fromDate, toDate, searchTerm, categoryFilter);
                totalRecords = unifiedData.Rows.Count;

                DataTable paginatedDt = unifiedData.Clone();
                int startRow = currentOffset;
                int endRow = Math.Min(currentOffset + PageSize, unifiedData.Rows.Count);

                for (int i = startRow; i < endRow; i++)
                {
                    paginatedDt.ImportRow(unifiedData.Rows[i]);
                }

                // ⭐ BIND using DataSource so hidden columns work properly
                poisonDataGridView1.DataSource = null;
                poisonDataGridView1.DataSource = paginatedDt;

                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadReportTable Error: " + ex.Message);
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ⭐ BUILD UNIFIED DATA with ALL columns from Patient History
        private DataTable BuildUnifiedData(DateTime fromDate, DateTime toDate, string search, string categoryFilter)
        {
            DataTable unified = new DataTable();
            // Visible columns
            unified.Columns.Add("LastVisit", typeof(string));
            unified.Columns.Add("IDNumber", typeof(string));
            unified.Columns.Add("PatientName", typeof(string));
            unified.Columns.Add("PatientType", typeof(string));
            unified.Columns.Add("Description", typeof(string));
            unified.Columns.Add("QtyDosage", typeof(string));
            unified.Columns.Add("Personnel", typeof(string));
            // Hidden columns (Patient History data)
            unified.Columns.Add("PatientId", typeof(int));
            unified.Columns.Add("ConsultationId", typeof(int));
            unified.Columns.Add("AgeSex", typeof(string));
            unified.Columns.Add("VisitType", typeof(string));
            unified.Columns.Add("ChiefComplaint", typeof(string));
            unified.Columns.Add("Vitals", typeof(string));
            unified.Columns.Add("VitalsRecorded", typeof(string));
            unified.Columns.Add("Diagnosis", typeof(string));
            unified.Columns.Add("Medicine", typeof(string));
            unified.Columns.Add("Outcome", typeof(string));
            unified.Columns.Add("Status", typeof(string));
            unified.Columns.Add("HandledBy", typeof(string));
            unified.Columns.Add("Remarks", typeof(string));
            unified.Columns.Add("RecordCategory", typeof(string));

            // === PATIENT RECORDS ===
            if (categoryFilter == "All Records" || categoryFilter == "Patients")
            {
                try
                {
                    DataTable patientData = GetAllPatients(search, fromDate, toDate);
                    foreach (DataRow row in patientData.Rows)
                    {
                        DataRow newRow = unified.NewRow();
                        newRow["LastVisit"] = row["LastVisit"] ?? "N/A";
                        newRow["IDNumber"] = row["IDNumber"];
                        newRow["PatientName"] = row["PatientName"];
                        newRow["PatientType"] = row["PatientType"] ?? "Patient";
                        newRow["Description"] = row["Description"] ?? "Patient Record";
                        newRow["QtyDosage"] = row["QtyDosage"] ?? "N/A";
                        newRow["Personnel"] = row["Personnel"] ?? "N/A";
                        newRow["PatientId"] = row["PatientId"];
                        newRow["AgeSex"] = row["AgeSex"] ?? "N/A";
                        newRow["VisitType"] = "N/A";
                        newRow["ChiefComplaint"] = row["Description"] ?? "N/A";
                        newRow["Vitals"] = "N/A";
                        newRow["VitalsRecorded"] = row["LastVisit"] ?? "N/A";
                        newRow["Diagnosis"] = "Patient Record";
                        newRow["Medicine"] = "N/A";
                        newRow["Outcome"] = "N/A";
                        newRow["Status"] = "Active";
                        newRow["HandledBy"] = row["Personnel"] ?? "N/A";
                        newRow["Remarks"] = "N/A";
                        newRow["RecordCategory"] = "Patients";
                        unified.Rows.Add(newRow);
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Patient load error: " + ex.Message); }
            }

            // === INVENTORY RECORDS ===
            if (categoryFilter == "All Records" || categoryFilter == "Inventory")
            {
                try
                {
                    DataTable inventoryData = GetInventoryForReport(search, fromDate, toDate);
                    foreach (DataRow row in inventoryData.Rows)
                    {
                        DataRow newRow = unified.NewRow();
                        newRow["LastVisit"] = row["LastVisit"] ?? "N/A";
                        newRow["IDNumber"] = row["IDNumber"];
                        newRow["PatientName"] = row["PatientName"];
                        newRow["PatientType"] = "Inventory";
                        newRow["Description"] = row["Description"] ?? "Inventory Item";
                        newRow["QtyDosage"] = row["QtyDosage"] ?? "N/A";
                        newRow["Personnel"] = row["Personnel"] ?? "System";
                        newRow["PatientId"] = 0;
                        newRow["AgeSex"] = "N/A";
                        newRow["VisitType"] = "N/A";
                        newRow["ChiefComplaint"] = "N/A";
                        newRow["Vitals"] = "N/A";
                        newRow["VitalsRecorded"] = row["LastVisit"] ?? "N/A";
                        newRow["Diagnosis"] = "Inventory";
                        newRow["Medicine"] = row["PatientName"];
                        newRow["Outcome"] = "N/A";
                        newRow["Status"] = row["QtyDosage"].ToString().Contains("0") ? "Out of Stock" : "Available";
                        newRow["HandledBy"] = "System";
                        newRow["Remarks"] = "N/A";
                        newRow["RecordCategory"] = "Inventory";
                        unified.Rows.Add(newRow);
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Inventory load error: " + ex.Message); }
            }

            // === CONSULTATION RECORDS (FULL Patient History data) ===
            if (categoryFilter == "All Records" || categoryFilter == "Consultations")
            {
                try
                {
                    DataTable consultData = GetConsultationsFullData(search, fromDate, toDate);
                    foreach (DataRow row in consultData.Rows)
                    {
                        DataRow newRow = unified.NewRow();
                        newRow["LastVisit"] = row["visit_date"] ?? "N/A";
                        newRow["IDNumber"] = row["patient_number"] ?? ("PID-" + row["patient_id"]);
                        newRow["PatientName"] = row["patient_name"] ?? "Unknown";
                        newRow["PatientType"] = row["category"] ?? "Patient";
                        newRow["Description"] = row["chief_complaint"] ?? "N/A";
                        newRow["QtyDosage"] = (row["medicine_quantity"] ?? "0") + " (" + (row["dosage"] ?? "N/A") + ")";
                        newRow["Personnel"] = row["clinic_incharge"] ?? "N/A";
                        newRow["PatientId"] = row["patient_id"];
                        newRow["ConsultationId"] = row["consultation_id"];
                        newRow["AgeSex"] = (row["age"] ?? "?") + "/" + (row["sex"] ?? "?");
                        newRow["VisitType"] = row["visit_type"] ?? "N/A";
                        newRow["ChiefComplaint"] = row["chief_complaint"] ?? "N/A";
                        newRow["Vitals"] = "T:" + (row["temperature"] ?? "-") + " BP:" + (row["blood_pressure"] ?? "-") + " PR:" + (row["pulse_rate"] ?? "-");
                        newRow["VitalsRecorded"] = row["visit_date"] ?? "N/A";
                        newRow["Diagnosis"] = row["physical_findings"] ?? "N/A";
                        newRow["Medicine"] = row["medicine_name"] ?? "None";
                        newRow["Outcome"] = row["outcome"] ?? "Pending";
                        newRow["Status"] = row["outcome"]?.ToString().Contains("Refer") == true ? "Referred" : (row["outcome"]?.ToString().Contains("Home") == true ? "Completed" : "Pending");
                        newRow["HandledBy"] = row["handled_by"] ?? "N/A";
                        newRow["Remarks"] = row["remarks_instructions"] ?? "";
                        newRow["RecordCategory"] = "Consultations";
                        unified.Rows.Add(newRow);
                    }
                }
                catch (Exception ex) { System.Diagnostics.Debug.WriteLine("Consultation load error: " + ex.Message); }
            }

            // Sort by date descending
            if (unified.Rows.Count > 0)
            {
                DataView dv = unified.DefaultView;
                dv.Sort = "LastVisit DESC";
                unified = dv.ToTable();
            }

            _unifiedDataCache = unified;
            return unified;
        }

        // ⭐ NEW: Get full consultation data with ALL Patient History fields
        private DataTable GetConsultationsFullData(string search, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    bool applyDateFilter = !(fromDate.Year == 1900 && toDate.Year > 2100);

                    string query = @"SELECT 
                        c.id AS consultation_id,
                        c.patient_id,
                        DATE_FORMAT(c.visit_date, '%d-%b-%y %H:%i') AS visit_date,
                        COALESCE(p.patient_number, CONCAT('PID-', c.patient_id)) AS patient_number,
                        COALESCE(CONCAT(p.first_name, ' ', p.last_name), 'Unknown Patient') AS patient_name,
                        p.category,
                        COALESCE(c.age, '?') AS age,
                        COALESCE(c.sex, '?') AS sex,
                        COALESCE(c.visit_type, 'N/A') AS visit_type,
                        COALESCE(c.chief_complaint, 'N/A') AS chief_complaint,
                        COALESCE(c.temperature, '-') AS temperature,
                        COALESCE(c.blood_pressure, '-') AS blood_pressure,
                        COALESCE(c.pulse_rate, '-') AS pulse_rate,
                        COALESCE(c.respiratory_rate, '-') AS respiratory_rate,
                        COALESCE(c.oxygen_saturation, '-') AS oxygen_saturation,
                        COALESCE(c.physical_findings, 'N/A') AS physical_findings,
                        COALESCE(c.medicine_name, 'None') AS medicine_name,
                        COALESCE(c.medicine_quantity, '0') AS medicine_quantity,
                        COALESCE(c.dosage, 'N/A') AS dosage,
                        COALESCE(c.outcome, 'Pending') AS outcome,
                        COALESCE(c.remarks_instructions, '') AS remarks_instructions,
                        COALESCE(c.clinic_incharge, 'N/A') AS clinic_incharge,
                        COALESCE(u.full_name, c.clinic_incharge, 'N/A') AS handled_by
                        FROM consultations c
                        LEFT JOIN patients p ON c.patient_id = p.patient_id
                        LEFT JOIN users u ON c.handled_by_user_id = u.user_id
                        WHERE ((p.first_name LIKE @s OR p.last_name LIKE @s OR p.patient_number LIKE @s OR c.chief_complaint LIKE @s OR @s = '')
                               OR (p.patient_id IS NULL AND @s = ''))";

                    if (applyDateFilter)
                        query += " AND c.visit_date BETWEEN @from AND @to";

                    query += " ORDER BY c.visit_date DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@s", "%" + search + "%");
                        if (applyDateFilter)
                        {
                            cmd.Parameters.AddWithValue("@from", fromDate);
                            cmd.Parameters.AddWithValue("@to", toDate);
                        }
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetConsultationsFullData Error: " + ex.Message);
                return new DataTable();
            }
        }

        // Get patients (updated to include PatientId)
        private DataTable GetAllPatients(string search, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    bool applyDateFilter = !(fromDate.Year == 1900 && toDate.Year > 2100);

                    string query = @"SELECT 
                        COALESCE(
                            DATE_FORMAT((SELECT MAX(c.visit_date) FROM consultations c WHERE c.patient_id = p.patient_id), '%d-%b-%y'),
                            DATE_FORMAT(p.created_at, '%d-%b-%y'),
                            'N/A'
                        ) AS LastVisit,
                        p.patient_number AS IDNumber,
                        CONCAT(p.first_name, ' ', p.last_name) AS PatientName,
                        p.category AS PatientType,
                        p.patient_id AS PatientId,
                        CONCAT(COALESCE(p.age, '?'), '/', COALESCE(p.sex, '?')) AS AgeSex,
                        COALESCE(
                            (SELECT c.chief_complaint FROM consultations c WHERE c.patient_id = p.patient_id ORDER BY c.visit_date DESC LIMIT 1),
                            'New Patient'
                        ) AS Description,
                        COALESCE(
                            (SELECT CONCAT(c.medicine_quantity, ' (', c.dosage, ')') FROM consultations c WHERE c.patient_id = p.patient_id ORDER BY c.visit_date DESC LIMIT 1),
                            'N/A'
                        ) AS QtyDosage,
                        COALESCE(
                            (SELECT c.clinic_incharge FROM consultations c WHERE c.patient_id = p.patient_id ORDER BY c.visit_date DESC LIMIT 1),
                            'N/A'
                        ) AS Personnel
                        FROM patients p
                        WHERE (p.first_name LIKE @s OR p.last_name LIKE @s OR p.patient_number LIKE @s OR @s = '')";

                    if (applyDateFilter)
                    {
                        query += @" AND (
                            p.created_at BETWEEN @from AND @to 
                            OR EXISTS (
                                SELECT 1 FROM consultations c 
                                WHERE c.patient_id = p.patient_id 
                                AND c.visit_date BETWEEN @from AND @to
                            )
                        )";
                    }
                    query += " ORDER BY p.created_at DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@s", "%" + search + "%");
                        if (applyDateFilter)
                        {
                            cmd.Parameters.AddWithValue("@from", fromDate);
                            cmd.Parameters.AddWithValue("@to", toDate);
                        }
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetAllPatients Error: " + ex.Message);
                return new DataTable();
            }
        }

        private DataTable GetInventoryForReport(string search, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    bool applyDateFilter = !(fromDate.Year == 1900 && toDate.Year > 2100);

                    string query = @"SELECT 
                        COALESCE(DATE_FORMAT(ExpiryDate, '%d-%b-%y'), 'N/A') AS LastVisit,
                        CONCAT('ITEM-', ItemID) AS IDNumber,
                        Name AS PatientName,
                        Category AS PatientType,
                        CONCAT('Stock: ', Quantity, ' units (Weekly: ', WeeklyUsage, ')') AS Description,
                        CONCAT(Quantity, ' units') AS QtyDosage,
                        'Inventory System' AS Personnel
                        FROM inventory 
                        WHERE (Name LIKE @s OR @s = '')";

                    if (applyDateFilter)
                        query += " AND (ExpiryDate BETWEEN @from AND @to OR ExpiryDate IS NULL)";

                    query += " ORDER BY ExpiryDate DESC";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@s", "%" + search + "%");
                        if (applyDateFilter)
                        {
                            cmd.Parameters.AddWithValue("@from", fromDate);
                            cmd.Parameters.AddWithValue("@to", toDate);
                        }
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetInventoryForReport Error: " + ex.Message);
                return new DataTable();
            }
        }

        // ⭐ DOUBLE-CLICK: Jump to Patient History
        private void poisonDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Get PatientId from hidden column
            var patientIdCell = poisonDataGridView1.Rows[e.RowIndex].Cells["PatientId"].Value;
            if (patientIdCell == null || patientIdCell == DBNull.Value) return;

            int patientId = Convert.ToInt32(patientIdCell);
            if (patientId <= 0) return;

            // Open Patient History with this patient
            UC_PatientHistory patientHistory = new UC_PatientHistory(patientId);
            patientHistory.Dock = DockStyle.Fill;

            // Add to parent panel and bring to front
            this.Parent.Controls.Add(patientHistory);
            patientHistory.BringToFront();
        }

        private void UpdatePaginationButtons()
        {
            btnPrev.Enabled = currentOffset > 0;
            btnNext.Enabled = (currentOffset + PageSize) < totalRecords;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if ((currentOffset + PageSize) < totalRecords)
            {
                currentOffset += PageSize;
                LoadReportTable();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentOffset >= PageSize)
            {
                currentOffset -= PageSize;
                LoadReportTable();
            }
        }

        private void ReloadPix_Click(object sender, EventArgs e)
        {
            cbDateFilter.SelectedIndex = 0;
            poisonTextBox1.Text = "Search";
            currentOffset = 0;
            cbDataViewFilter.SelectedIndex = 0;
            _unifiedDataCache = null;
            LoadData();
        }

        // ⭐ EXPORT PDF with ALL columns (including hidden)
        private void ExportToPdf()
        {
            try
            {
                if (_unifiedDataCache == null || _unifiedDataCache.Rows.Count == 0)
                {
                    MessageBox.Show("No data available to export.", "Export Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                    sfd.FileName = $"AceCare_Report_{DateTime.Now:yyyyMMdd_HHmm}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (PdfWriter writer = new PdfWriter(sfd.FileName))
                        {
                            using (PdfDocument pdf = new PdfDocument(writer))
                            {
                                pdf.SetDefaultPageSize(iText.Kernel.Geom.PageSize.A4.Rotate());
                                Document document = new Document(pdf);

                                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                                PdfFont italicFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_OBLIQUE);

                                // Header
                                document.Add(new Paragraph("AceCare Clinic Management System")
                                    .SetTextAlignment(TextAlignment.CENTER).SetFontSize(20).SetFont(boldFont));
                                document.Add(new Paragraph("Unified Clinic Report")
                                    .SetTextAlignment(TextAlignment.CENTER).SetFontSize(14).SetFont(italicFont));
                                document.Add(new Paragraph($"Period: {cbDateFilter.SelectedItem?.ToString() ?? "All Time"}")
                                    .SetTextAlignment(TextAlignment.CENTER).SetFontSize(10));
                                document.Add(new Paragraph("\n"));

                                // Summary
                                document.Add(new Paragraph("Report Summary").SetFont(boldFont).SetFontSize(12));
                                document.Add(new Paragraph($"Category Filter: {cbDataViewFilter.SelectedItem?.ToString() ?? "All"}"));
                                document.Add(new Paragraph($"Total Records: {totalRecords}"));
                                document.Add(new Paragraph($"Date Generated: {DateTime.Now:MMMM dd, yyyy HH:mm}"));
                                document.Add(new Paragraph("\n"));

                                // ⭐ FULL TABLE with ALL columns
                                document.Add(new Paragraph("Complete Records Log").SetFont(boldFont).SetFontSize(12));

                                float[] columnWidths = { 10, 8, 10, 8, 10, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 };
                                Table table = new Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();

                                // ALL headers
                                string[] headers = { "Last Visit", "ID No.", "Name", "Category", "Age/Sex", "Visit Type",
                                    "Chief Complaint", "Vitals", "Vitals Recorded", "Diagnosis", "Medicine",
                                    "Qty/Dosage", "Outcome", "Status", "Handled By", "Remarks" };

                                foreach (string header in headers)
                                {
                                    table.AddHeaderCell(new Cell().Add(new Paragraph(header).SetFont(boldFont).SetFontSize(7)));
                                }

                                foreach (DataRow row in _unifiedDataCache.Rows)
                                {
                                    table.AddCell(new Paragraph(row["LastVisit"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["IDNumber"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["PatientName"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["PatientType"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["AgeSex"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["VisitType"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["ChiefComplaint"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["Vitals"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["VitalsRecorded"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["Diagnosis"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["Medicine"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["QtyDosage"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["Outcome"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["Status"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["HandledBy"]?.ToString() ?? "N/A").SetFontSize(6));
                                    table.AddCell(new Paragraph(row["Remarks"]?.ToString() ?? "N/A").SetFontSize(6));
                                }

                                document.Add(table);
                                document.Close();
                            }
                        }
                        MessageBox.Show("Report exported successfully!", "Export PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating PDF: " + ex.ToString(), "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HandleExport()
        {
            int index = poisonComboBox1.SelectedIndex;
            if (index == 0) ExportToPdf();
            else ExportToCsv(index == 1 ? ".csv" : ".csv");
        }

        private void ExportToCsv(string extension)
        {
            try
            {
                if (_unifiedDataCache == null || _unifiedDataCache.Rows.Count == 0)
                {
                    MessageBox.Show("No data available to export.", "Export Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
                    sfd.FileName = $"AceCare_Report_{DateTime.Now:yyyyMMdd_HHmm}{extension}";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("AceCare Clinic Management System - Unified Report");
                        sb.AppendLine($"Period: {cbDateFilter.SelectedItem?.ToString() ?? "All Time"}");
                        sb.AppendLine($"Generated: {DateTime.Now:MMMM dd, yyyy HH:mm}");
                        sb.AppendLine();

                        // ⭐ ALL columns in CSV
                        string[] columnNames = { "Last Visit", "ID No.", "Name", "Category", "Age/Sex", "Visit Type",
                            "Chief Complaint", "Vitals", "Vitals Recorded", "Diagnosis", "Medicine",
                            "Qty / Dosage", "Outcome", "Status", "Handled By", "Remarks" };
                        sb.AppendLine(string.Join(",", columnNames));

                        foreach (DataRow row in _unifiedDataCache.Rows)
                        {
                            string[] cells = new string[16];
                            cells[0] = EscapeCsv(row["LastVisit"]?.ToString() ?? "N/A");
                            cells[1] = EscapeCsv(row["IDNumber"]?.ToString() ?? "N/A");
                            cells[2] = EscapeCsv(row["PatientName"]?.ToString() ?? "N/A");
                            cells[3] = EscapeCsv(row["PatientType"]?.ToString() ?? "N/A");
                            cells[4] = EscapeCsv(row["AgeSex"]?.ToString() ?? "N/A");
                            cells[5] = EscapeCsv(row["VisitType"]?.ToString() ?? "N/A");
                            cells[6] = EscapeCsv(row["ChiefComplaint"]?.ToString() ?? "N/A");
                            cells[7] = EscapeCsv(row["Vitals"]?.ToString() ?? "N/A");
                            cells[8] = EscapeCsv(row["VitalsRecorded"]?.ToString() ?? "N/A");
                            cells[9] = EscapeCsv(row["Diagnosis"]?.ToString() ?? "N/A");
                            cells[10] = EscapeCsv(row["Medicine"]?.ToString() ?? "N/A");
                            cells[11] = EscapeCsv(row["QtyDosage"]?.ToString() ?? "N/A");
                            cells[12] = EscapeCsv(row["Outcome"]?.ToString() ?? "N/A");
                            cells[13] = EscapeCsv(row["Status"]?.ToString() ?? "N/A");
                            cells[14] = EscapeCsv(row["HandledBy"]?.ToString() ?? "N/A");
                            cells[15] = EscapeCsv(row["Remarks"]?.ToString() ?? "N/A");
                            sb.AppendLine(string.Join(",", cells));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Report exported successfully!", "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating CSV: " + ex.ToString(), "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value)) return "\"\"";
            if (value.All(char.IsDigit) && value.Length > 5) value = "=\"" + value + "\"";
            else if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
                value = "\"" + value.Replace("\"", "\"\"") + "\"";
            return value;
        }

        private void panel5_Paint(object sender, PaintEventArgs e) { }

        private void UpdateStockCircle()
        {
            try
            {
                int capacityPercent = dashboardController.GetStockFillPercentage();
                medicineCircle.Percentage = capacityPercent;
                if (capacityPercent < 50) medicineCircle.FilledColor = System.Drawing.Color.Green;
                else if (capacityPercent < 80) medicineCircle.FilledColor = System.Drawing.Color.Orange;
                else medicineCircle.FilledColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("UpdateStockCircle Error: " + ex.Message);
                medicineCircle.Percentage = 0;
                medicineCircle.FilledColor = System.Drawing.Color.Gray;
            }
        }
    }
}