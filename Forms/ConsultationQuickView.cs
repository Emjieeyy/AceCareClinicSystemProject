using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AceCareClinicSystem.Forms
{
    public partial class ConsultationQuickView : Form
    {
        public int PatientId { get; private set; }
        public DialogResult ResultAction { get; private set; }

        public ConsultationQuickView(DataRow row)
        {
            InitializeComponent();

            // Form setup
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Populate labels from DataRow
            lblPatientName.Text = GetValue(row, "Patients Name");

            // Age and Sex separated
            lblAge.Text = GetValue(row, "Age", "?");
            lblSex.Text = GetValue(row, "Sex", "?");

            lblVisitType.Text = GetValue(row, "VisitType");
            lblComplaint.Text = GetValue(row, "Chief Complaint");
            lblVitals.Text = GetValue(row, "Vitals");
            lblDiagnosis.Text = GetValue(row, "Diagnosis");
            lblMedicine.Text = GetValue(row, "Medicine", "None");
            lblOutcome.Text = GetValue(row, "Outcome");
            lblHandledBy.Text = GetValue(row, "HandledBy");
            lblDate.Text = GetDateValue(row, "Time of Visit");

            PatientId = GetIntValue(row, "PatientId");
        }

        private string GetValue(DataRow row, string column, string defaultValue = "N/A")
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value
                ? row[column].ToString()
                : defaultValue;
        }

        private string GetDateValue(DataRow row, string column)
        {
            if (!row.Table.Columns.Contains(column) || row[column] == DBNull.Value)
                return "N/A";

            if (DateTime.TryParse(row[column].ToString(), out DateTime dt))
                return dt.ToString("MMM dd, yyyy hh:mm tt");

            return row[column].ToString();
        }

        private int GetIntValue(DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value
                ? Convert.ToInt32(row[column])
                : 0;
        }

        private void btnViewHistory_Click(object sender, EventArgs e)
        {
            ResultAction = DialogResult.OK;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ResultAction = DialogResult.Cancel;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}