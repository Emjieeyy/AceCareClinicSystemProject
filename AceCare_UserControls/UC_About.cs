using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AceCareClinicSystem.AceCare_UserControls
{
    public partial class UC_About : UserControl
    {
        // Array to hold your designed slides from Resources
        private Image[] sliderImages;
        private int currentIndex = 0;

        public UC_About()
        {
            InitializeComponent();

            // 1. Initialize the images from your Resources
            // Replace the names below with your actual Resource names if different
            sliderImages = new Image[] {
                Properties.Resources.ace1,   // The first photo
                Properties.Resources.Slide4,
                Properties.Resources.Slide1,
                Properties.Resources.Slide2,
                Properties.Resources.Slide3
            };

            // 2. Set the initial image on your ImageHolderPanel
            if (sliderImages.Length > 0)
            {
                UpdateSliderDisplay();
            }
        }

        private void UpdateSliderDisplay()
        {
            // Assuming your panel is named ImageHolderPanel as seen in your outline
            ImageHolderPanel.BackgroundImage = sliderImages[currentIndex];
            ImageHolderPanel.BackgroundImageLayout = ImageLayout.Zoom;
        }

        // Manual Navigation: Next Button
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (sliderImages != null && sliderImages.Length > 0)
            {
                // Increment index and wrap around to the start (0) if at the end
                currentIndex = (currentIndex + 1) % sliderImages.Length;
                UpdateSliderDisplay();
            }
        }

        // Manual Navigation: Previous Button
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (sliderImages != null && sliderImages.Length > 0)
            {
                // Decrement index and wrap to the last image if at the start
                currentIndex = (currentIndex - 1 + sliderImages.Length) % sliderImages.Length;
                UpdateSliderDisplay();
            }
        }

        // Empty event handlers you can remove or ignore
        private void label3_Click(object sender, EventArgs e) { }
        private void hopeButton1_Click(object sender, EventArgs e) { }
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
    }
}