using System.Drawing;
using System.Windows.Forms;

namespace AceCareClinicSystem.Services
{
    public static class DataGridViewStyle
    {
        public static void ApplyModernDesign(DataGridView dgv)
        {
           
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToResizeRows = false;
            dgv.EnableHeadersVisualStyles = false;

            
            dgv.ColumnHeadersHeight = 45;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 40, 84);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 9, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

           
            dgv.RowTemplate.Height = 40;
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 45);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 242, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(15, 40, 84);

           
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(230, 230, 230);
        }
    }
}