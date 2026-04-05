using System;
using System.Drawing;
using System.Windows.Forms;

namespace AceCareClinicSystem.Services
{
    public static class WizardMethods
    {
        public static void ShowStep(int stepNumber, Panel container, PictureBox[] icons, Panel[] lines)
        {
            foreach (Control ctrl in container.Controls)
            {
                if (ctrl is Panel && ctrl.Name.StartsWith("Step"))
                    ctrl.Visible = false;
            }

            Control targetPanel = container.Controls[$"Step{stepNumber}"];
            if (targetPanel != null)
            {
                targetPanel.Visible = true;
                targetPanel.BringToFront();
                targetPanel.Dock = DockStyle.Fill;
            }

            if (icons != null)
            {
                for (int i = 0; i < icons.Length; i++)
                {
                    
                    icons[i].BackColor = Color.Transparent;
                    icons[i].SizeMode = PictureBoxSizeMode.Zoom;

                    int currentIdx = i + 1;
                   
                    if (currentIdx < stepNumber) icons[i].Image = Properties.Resources.green;
                    else if (currentIdx == stepNumber) icons[i].Image = Properties.Resources.blue;
                    else icons[i].Image = Properties.Resources.gray;
                }
            }

            if (lines != null)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i + 2 <= stepNumber) lines[i].BackColor = Color.FromArgb(76, 175, 80);
                    else lines[i].BackColor = Color.Silver;
                }
            }
        }

      
        public static void SetStepActive(int stepNumber, PictureBox[] icons)
        {
            if (icons != null && stepNumber <= icons.Length)
            {
                
                icons[stepNumber - 1].Image = Properties.Resources.blue;
                icons[stepNumber - 1].Refresh();
            }
        }
    }
}