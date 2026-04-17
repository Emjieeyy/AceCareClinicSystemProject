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

        // Pagination variables
        private int currentOffset = 0;
        private int totalRecords = 0;
        private const int PageSize = 10;

        // Cache for unified data
        private DataTable _unifiedDataCache = null;

        public UC_Reportscs()
        {
            InitializeComponent();

            // Setup date filter combobox (replaces date pickers)
            SetupDateFilterCombo();

            // Setup category filter dropdown
            SetupCategoryFilter();

            // Wire up filters
            cbDateFilter.SelectedIndexChanged += (s, e) => { currentOffset = 0; LoadData(); };
            cbDataViewFilter.SelectedIndexChanged += (s, e) => { currentOffset = 0; LoadReportTable(); };

            // Search text
            poisonTextBox1.TextChanged += (s, e) =>
            {
                if (poisonTextBox1.Text != "Search")
                {
                    currentOffset = 0;
                    LoadReportTable();
                }
            };

            poisonTextBox1.Click += (s, e) =>
            {
                if (poisonTextBox1.Text == "Search") poisonTextBox1.Text = "";
            };

            poisonTextBox1.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(poisonTextBox1.Text))
                {
                    poisonTextBox1.Text = "Search";
                }
            };

            // Wire up buttons
            hopeRoundButton2.Click += (s, e) => HandleExport();
            btnNext.Click += btnNext_Click;
            btnPrev.Click += btnPrev_Click;
            ReloadPix.Click += ReloadPix_Click;

            // Initial load - show ALL records by default
            cbDateFilter.SelectedIndex = 0; // "All Time"
            LoadData();

            poisonDataGridView1.RowTemplate.Height = 45;
            poisonDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupDateFilterCombo()
        {
            cbDateFilter.Items.Clear();
            cbDateFilter.Items.Add("All Time");           // Show everything
            cbDateFilter.Items.Add("Today");              // Today only
            cbDateFilter.Items.Add("Yesterday");          // Yesterday only
            cbDateFilter.Items.Add("Last 7 Days");        // Last week
            cbDateFilter.Items.Add("Last 30 Days");       // Last month
            cbDateFilter.Items.Add("This Month");         // Current month
            cbDateFilter.Items.Add("Last Month");         // Previous month
            cbDateFilter.Items.Add("This Year");          // Current year
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

        // Get date range based on selected filter
        private (DateTime from, DateTime to) GetDateRangeFromFilter()
        {
            DateTime today = DateTime.Today;
            DateTime fromDate = new DateTime(2000, 1, 1); // Default: all time
            DateTime toDate = DateTime.Today.AddYears(50);

            switch (cbDateFilter.SelectedItem?.ToString())
            {
                case "Today":
                    fromDate = today;
                    toDate = today.AddDays(1).AddTicks(-1);
                    break;
                case "Yesterday":
                    fromDate = today.AddDays(-1);
                    toDate = today.AddTicks(-1);
                    break;
                case "Last 7 Days":
                    fromDate = today.AddDays(-7);
                    toDate = today.AddDays(1).AddTicks(-1);
                    break;
                case "Last 30 Days":
                    fromDate = today.AddDays(-30);
                    toDate = today.AddDays(1).AddTicks(-1);
                    break;
                case "This Month":
                    fromDate = new DateTime(today.Year, today.Month, 1);
                    toDate = fromDate.AddMonths(1).AddTicks(-1);
                    break;
                case "Last Month":
                    fromDate = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
                    toDate = new DateTime(today.Year, today.Month, 1).AddTicks(-1);
                    break;
                case "This Year":
                    fromDate = new DateTime(today.Year, 1, 1);
                    toDate = new DateTime(today.Year + 1, 1, 1).AddTicks(-1);
                    break;
                case "All Time":
                default:
                    fromDate = new DateTime(1900, 1, 1);
                    toDate = DateTime.Today.AddYears(100);
                    break;
            }

            return (fromDate, toDate);
        }

        public void LoadData()
        {
            // Load stats from dashboard (these are totals)
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
        }

        // Get accurate counts directly from database
        private dynamic GetAccurateCounts()
        {
            var stats = new
            {
                TotalConsultations = 0,
                TotalPatients = 0,
                TotalInventory = 0,
                LowInventory = 0
            };

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM consultations", conn))
                    {
                        int consultCount = Convert.ToInt32(cmd.ExecuteScalar());

                        using (MySqlCommand cmd2 = new MySqlCommand("SELECT COUNT(*) FROM patients", conn))
                        {
                            int patientCount = Convert.ToInt32(cmd2.ExecuteScalar());

                            using (MySqlCommand cmd3 = new MySqlCommand(
                                "SELECT IFNULL(SUM(Quantity), 0) FROM inventory", conn))
                            {
                                int inventoryTotal = Convert.ToInt32(cmd3.ExecuteScalar());

                                using (MySqlCommand cmd4 = new MySqlCommand(
                                    "SELECT COUNT(*) FROM inventory WHERE Quantity < 10", conn))
                                {
                                    int lowCount = Convert.ToInt32(cmd4.ExecuteScalar());

                                    stats = new
                                    {
                                        TotalConsultations = consultCount,
                                        TotalPatients = patientCount,
                                        TotalInventory = inventoryTotal,
                                        LowInventory = lowCount
                                    };
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetAccurateCounts Error: " + ex.Message);
            }

            return stats;
        }

        private void LoadReportTable(string search = "")
        {
            try
            {
                string searchTerm = string.IsNullOrEmpty(search) ? poisonTextBox1.Text : search;
                if (searchTerm == "Search" || string.IsNullOrWhiteSpace(searchTerm))
                    searchTerm = "";

                string categoryFilter = cbDataViewFilter.SelectedItem?.ToString() ?? "All Records";

                // Get date range from combobox
                var (fromDate, toDate) = GetDateRangeFromFilter();

                // Build unified data from all sources
                DataTable unifiedData = BuildUnifiedData(fromDate, toDate, searchTerm, categoryFilter);

                totalRecords = unifiedData.Rows.Count;

                // DEBUG: Log counts
                int patientCount = unifiedData.AsEnumerable().Count(r => r["RecordCategory"].ToString() == "Patients");
                int inventoryCount = unifiedData.AsEnumerable().Count(r => r["RecordCategory"].ToString() == "Inventory");
                int consultCount = unifiedData.AsEnumerable().Count(r => r["RecordCategory"].ToString() == "Consultations");
                System.Diagnostics.Debug.WriteLine($"DEBUG - Patients: {patientCount}, Inventory: {inventoryCount}, Consultations: {consultCount}, Total: {totalRecords}");

                // Apply pagination
                DataTable paginatedDt = unifiedData.Clone();
                int startRow = currentOffset;
                int endRow = Math.Min(currentOffset + PageSize, unifiedData.Rows.Count);

                for (int i = startRow; i < endRow; i++)
                {
                    paginatedDt.ImportRow(unifiedData.Rows[i]);
                }

                // Clear and bind to grid
                poisonDataGridView1.Rows.Clear();

                if (paginatedDt.Rows.Count > 0)
                {
                    foreach (DataRow row in paginatedDt.Rows)
                    {
                        poisonDataGridView1.Rows.Add(
                            row["LastVisit"],
                            row["IDNumber"],
                            row["PatientName"],
                            row["PatientType"],
                            row["Description"] ?? "N/A",
                            row["QtyDosage"] ?? "N/A",
                            row["Personnel"] ?? "N/A"
                        );
                    }
                }

                UpdatePaginationButtons();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("LoadReportTable Error: " + ex.Message);
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable BuildUnifiedData(DateTime fromDate, DateTime toDate, string search, string categoryFilter)
        {
            DataTable unified = new DataTable();
            unified.Columns.Add("LastVisit", typeof(string));
            unified.Columns.Add("IDNumber", typeof(string));
            unified.Columns.Add("PatientName", typeof(string));
            unified.Columns.Add("PatientType", typeof(string));
            unified.Columns.Add("Description", typeof(string));
            unified.Columns.Add("QtyDosage", typeof(string));
            unified.Columns.Add("Personnel", typeof(string));
            unified.Columns.Add("RecordCategory", typeof(string));

            // === PATIENT RECORDS ===
            if (categoryFilter == "All Records" || categoryFilter == "Patients")
            {
                try
                {
                    DataTable patientData = GetAllPatients(search, fromDate, toDate);
                    if (patientData != null && patientData.Rows.Count > 0)
                    {
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
                            newRow["RecordCategory"] = "Patients";
                            unified.Rows.Add(newRow);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Patient load error: " + ex.Message);
                }
            }

            // === INVENTORY RECORDS ===
            if (categoryFilter == "All Records" || categoryFilter == "Inventory")
            {
                try
                {
                    DataTable inventoryData = GetInventoryForReport(search, fromDate, toDate);
                    if (inventoryData != null && inventoryData.Rows.Count > 0)
                    {
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
                            newRow["RecordCategory"] = "Inventory";
                            unified.Rows.Add(newRow);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Inventory load error: " + ex.Message);
                }
            }

            // === CONSULTATION RECORDS ===
            if (categoryFilter == "All Records" || categoryFilter == "Consultations")
            {
                try
                {
                    DataTable consultData = GetConsultationsForReport(search, fromDate, toDate);
                    if (consultData != null && consultData.Rows.Count > 0)
                    {
                        foreach (DataRow row in consultData.Rows)
                        {
                            DataRow newRow = unified.NewRow();
                            newRow["LastVisit"] = row["LastVisit"] ?? "N/A";
                            newRow["IDNumber"] = row["IDNumber"];
                            newRow["PatientName"] = row["PatientName"];
                            newRow["PatientType"] = "Consultation";
                            newRow["Description"] = row["Description"] ?? "Consultation";
                            newRow["QtyDosage"] = row["QtyDosage"] ?? "N/A";
                            newRow["Personnel"] = row["Personnel"] ?? "N/A";
                            newRow["RecordCategory"] = "Consultations";
                            unified.Rows.Add(newRow);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Consultation load error: " + ex.Message);
                }
            }

            // Sort by date descending
            if (unified.Rows.Count > 0)
            {
                DataView dv = unified.DefaultView;
                dv.Sort = "LastVisit DESC";
                unified = dv.ToTable();
            }

            // Cache for export
            _unifiedDataCache = unified;

            return unified;
        }

        // Get all patients - with optional date filtering
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

        // Get inventory items for report - with optional date filtering
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
                    {
                        query += " AND (ExpiryDate BETWEEN @from AND @to OR ExpiryDate IS NULL)";
                    }

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

        // Get consultations for report - FIXED: Use LEFT JOIN to include all consultations
        private DataTable GetConsultationsForReport(string search, DateTime fromDate, DateTime toDate)
        {
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    bool applyDateFilter = !(fromDate.Year == 1900 && toDate.Year > 2100);

                    string query = @"SELECT 
                        COALESCE(DATE_FORMAT(c.visit_date, '%d-%b-%y %H:%i'), 'N/A') AS LastVisit,
                        COALESCE(p.patient_number, CONCAT('PID-', c.patient_id)) AS IDNumber,
                        COALESCE(CONCAT(p.first_name, ' ', p.last_name), 'Unknown Patient') AS PatientName,
                        'Consultation' AS PatientType,
                        COALESCE(c.chief_complaint, 'No Complaint') AS Description,
                        CONCAT(COALESCE(c.medicine_quantity, '0'), ' (', COALESCE(c.dosage, 'N/A'), ')') AS QtyDosage,
                        COALESCE(c.clinic_incharge, 'N/A') AS Personnel
                        FROM consultations c
                        LEFT JOIN patients p ON c.patient_id = p.patient_id
                        WHERE ((p.first_name LIKE @s OR p.last_name LIKE @s OR p.patient_number LIKE @s OR c.chief_complaint LIKE @s OR @s = '')
                               OR (p.patient_id IS NULL AND @s = ''))";

                    if (applyDateFilter)
                    {
                        query += " AND c.visit_date BETWEEN @from AND @to";
                    }

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

                        System.Diagnostics.Debug.WriteLine($"GetConsultationsForReport returned {dt.Rows.Count} rows");
                        return dt;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetConsultationsForReport Error: " + ex.Message);
                return new DataTable();
            }
        }

        private void UpdatePaginationButtons()
        {
            btnPrev.Enabled = currentOffset > 0;
            btnNext.Enabled = (currentOffset + PageSize) < totalRecords;

            // Update button text to show page info
            if (totalRecords > 0)
            {
                int currentPage = (currentOffset / PageSize) + 1;
                int totalPages = (int)Math.Ceiling((double)totalRecords / PageSize);
                // If you have a label for page info, update it here
                // lblPageInfo.Text = $"Page {currentPage} of {totalPages} ({totalRecords} records)";
            }
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
            // Reset to show ALL records
            cbDateFilter.SelectedIndex = 0; // "All Time"
            poisonTextBox1.Text = "Search";
            currentOffset = 0;
            cbDataViewFilter.SelectedIndex = 0;
            _unifiedDataCache = null;
            LoadData();
        }

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
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFontSize(20)
                                    .SetFont(boldFont));

                                document.Add(new Paragraph("Unified Clinic Report")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFontSize(14)
                                    .SetFont(italicFont));

                                string dateRangeText = cbDateFilter.SelectedItem?.ToString() ?? "All Time";
                                document.Add(new Paragraph($"Period: {dateRangeText}")
                                    .SetTextAlignment(TextAlignment.CENTER)
                                    .SetFontSize(10));

                                document.Add(new Paragraph("\n"));

                                // Summary Section
                                document.Add(new Paragraph("Report Summary").SetFont(boldFont).SetFontSize(12));
                                document.Add(new Paragraph($"Category Filter: {cbDataViewFilter.SelectedItem?.ToString() ?? "All"}"));
                                document.Add(new Paragraph($"Search Filter: {(string.IsNullOrEmpty(poisonTextBox1.Text) || poisonTextBox1.Text == "Search" ? "None" : poisonTextBox1.Text)}"));
                                document.Add(new Paragraph($"Total Records: {totalRecords}"));
                                document.Add(new Paragraph($"Date Generated: {DateTime.Now:MMMM dd, yyyy HH:mm}"));

                                document.Add(new Paragraph("\n"));

                                // Table
                                document.Add(new Paragraph("Records Log").SetFont(boldFont).SetFontSize(12));

                                float[] columnWidths = { 15, 10, 15, 10, 20, 15, 15 };
                                Table table = new Table(UnitValue.CreatePercentArray(columnWidths)).UseAllAvailableWidth();

                                // Headers
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Last Visit").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("ID No.").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Name").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Category").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Description").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Qty / Dosage").SetFont(boldFont)));
                                table.AddHeaderCell(new Cell().Add(new Paragraph("Personnel").SetFont(boldFont)));

                                // Use cached data for export
                                if (_unifiedDataCache != null)
                                {
                                    foreach (DataRow row in _unifiedDataCache.Rows)
                                    {
                                        table.AddCell(new Paragraph(row["LastVisit"]?.ToString() ?? "N/A").SetFontSize(8));
                                        table.AddCell(new Paragraph(row["IDNumber"]?.ToString() ?? "N/A").SetFontSize(8));
                                        table.AddCell(new Paragraph(row["PatientName"]?.ToString() ?? "N/A").SetFontSize(8));
                                        table.AddCell(new Paragraph(row["PatientType"]?.ToString() ?? "N/A").SetFontSize(8));
                                        table.AddCell(new Paragraph(row["Description"]?.ToString() ?? "N/A").SetFontSize(8));
                                        table.AddCell(new Paragraph(row["QtyDosage"]?.ToString() ?? "N/A").SetFontSize(8));
                                        table.AddCell(new Paragraph(row["Personnel"]?.ToString() ?? "N/A").SetFontSize(8));
                                    }
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
            if (index == 0) // PDF
            {
                ExportToPdf();
            }
            else // CSV
            {
                ExportToCsv(index == 1 ? ".csv" : ".csv");
            }
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
                        string dateRangeText = cbDateFilter.SelectedItem?.ToString() ?? "All Time";
                        sb.AppendLine($"Period: {dateRangeText}");
                        sb.AppendLine($"Category: {cbDataViewFilter.SelectedItem?.ToString() ?? "All"}");
                        sb.AppendLine($"Generated: {DateTime.Now:MMMM dd, yyyy HH:mm}");
                        sb.AppendLine();

                        string[] columnNames = { "Last Visit", "ID No.", "Name", "Category", "Description", "Qty / Dosage", "Personnel" };
                        sb.AppendLine(string.Join(",", columnNames));

                        if (_unifiedDataCache != null)
                        {
                            foreach (DataRow row in _unifiedDataCache.Rows)
                            {
                                string[] cells = new string[7];
                                cells[0] = EscapeCsv(row["LastVisit"]?.ToString() ?? "N/A");
                                cells[1] = EscapeCsv(row["IDNumber"]?.ToString() ?? "N/A");
                                cells[2] = EscapeCsv(row["PatientName"]?.ToString() ?? "N/A");
                                cells[3] = EscapeCsv(row["PatientType"]?.ToString() ?? "N/A");
                                cells[4] = EscapeCsv(row["Description"]?.ToString() ?? "N/A");
                                cells[5] = EscapeCsv(row["QtyDosage"]?.ToString() ?? "N/A");
                                cells[6] = EscapeCsv(row["Personnel"]?.ToString() ?? "N/A");

                                sb.AppendLine(string.Join(",", cells));
                            }
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

            if (value.All(char.IsDigit) && value.Length > 5)
            {
                value = "=\"" + value + "\"";
            }
            else if (value.Contains(",") || value.Contains("\"") || value.Contains("\n") || value.Contains("\r"))
            {
                value = "\"" + value.Replace("\"", "\"\"") + "\"";
            }

            return value;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}