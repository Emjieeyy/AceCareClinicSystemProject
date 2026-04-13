using System.Data;
using System.Windows.Forms;

namespace AceCareClinicSystem.Services
{
    public static class BindingHelper
    {
        // This method handles the logic of attaching the DB data to the Grid
        public static void BindToGrid(DataGridView dgv, DataTable dt)
        {
            // We check if the Grid is already using a BindingSource
            BindingSource bs = dgv.DataSource as BindingSource;

            if (bs == null)
            {
                // First time: Setup the 'Middleman' (BindingSource)
                bs = new BindingSource();
                bs.DataSource = dt;
                dgv.DataSource = bs;
            }
            else
            {
                // Already setup: Just swap the old data for the new MySQL data
                bs.DataSource = dt;
            }

            // Tell the Grid to redraw itself with the new rows
            dgv.Refresh();
        }
    }
}