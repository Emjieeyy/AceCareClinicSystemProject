using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AceCareClinicSystem.Forms
{
    public partial class AceCareLanding : Form
    {
        private Image[] sliderImages;
        private int currentIndex = 0;
        private System.Windows.Forms.Timer sliderTimer;

        public AceCareLanding()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // 1. Initialize images from Resources
            sliderImages = new Image[] {
                Properties.Resources.Blue_Modern_Business_Marketing_Banner_Landscape,
                Properties.Resources._1,
                Properties.Resources._2,
                Properties.Resources._3,
                Properties.Resources._4,
                Properties.Resources._5
            };

            // 2. Setup the initial display with ZOOM
            if (sliderImages.Length > 0)
            {
                ImageSlider.BackgroundImage = sliderImages[currentIndex];
                ImageSlider.BackgroundImageLayout = ImageLayout.Zoom; // KEPT AS ZOOM
            }

            // 3. Setup the Auto-timer
            sliderTimer = new System.Windows.Forms.Timer();
            sliderTimer.Interval = 5000;
            sliderTimer.Tick += (s, e) => { MoveToNextSlide(); };
            sliderTimer.Start();

            // 4. Existing Scroll Logic
            SetupCustomScroll();
        }

        private void SetupCustomScroll()
        {
            mainPanel.AutoScroll = false;
            this.PerformLayout();
            int totalContentHeight = ImageSlider.Height + CardsPanel.Height + FooterPanel.Height;
            poisonScrollBar.Minimum = 0;
            int scrollMax = totalContentHeight - mainPanel.Height;
            poisonScrollBar.Maximum = (scrollMax > 0) ? scrollMax : 0;

            poisonScrollBar.Scroll += (s, e) =>
            {
                mainPanel.AutoScrollPosition = new Point(0, e.NewValue);
                poisonScrollBar.Value = e.NewValue;
            };

            mainPanel.MouseWheel += (s, e) =>
            {
                int scrollStep = 50;
                int newValue = (e.Delta > 0) ? poisonScrollBar.Value - scrollStep : poisonScrollBar.Value + scrollStep;
                if (newValue < poisonScrollBar.Minimum) newValue = poisonScrollBar.Minimum;
                if (newValue > poisonScrollBar.Maximum) newValue = poisonScrollBar.Maximum;
                poisonScrollBar.Value = newValue;
                mainPanel.AutoScrollPosition = new Point(0, newValue);
            };
        }

        private void MoveToNextSlide()
        {
            if (sliderImages != null && sliderImages.Length > 0)
            {
                currentIndex = (currentIndex + 1) % sliderImages.Length;
                ImageSlider.BackgroundImage = sliderImages[currentIndex];
                ImageSlider.BackgroundImageLayout = ImageLayout.Zoom; // ENSURE ZOOM REMAINS
            }
        }

        private void MoveToPrevSlide()
        {
            if (sliderImages != null && sliderImages.Length > 0)
            {
                currentIndex = (currentIndex - 1 + sliderImages.Length) % sliderImages.Length;
                ImageSlider.BackgroundImage = sliderImages[currentIndex];
                ImageSlider.BackgroundImageLayout = ImageLayout.Zoom; // ENSURE ZOOM REMAINS
            }
        }

        // --- BUTTON CLICKS ---
        private void NavRight_Click(object sender, EventArgs e)
        {
            MoveToNextSlide();
            sliderTimer.Stop();
            sliderTimer.Start();
        }

        private void NavLeft_Click(object sender, EventArgs e)
        {
            MoveToPrevSlide();
            sliderTimer.Stop();
            sliderTimer.Start();
        }

        private void LandingLoginBtn_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide(); // hides the landing page
        }
    }
}