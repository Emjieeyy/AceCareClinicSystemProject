using System;
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

            // Setup slider images
            sliderImages = new Image[] {
                Properties.Resources.Blue_Modern_Business_Marketing_Banner_Landscape,
                Properties.Resources._1,
                Properties.Resources._2,
                Properties.Resources._3,
                Properties.Resources._4,
                Properties.Resources._5,
                Properties.Resources.MaamPic
            };

            if (sliderImages.Length > 0)
            {
                ImageSlider.BackgroundImage = sliderImages[currentIndex];
                ImageSlider.BackgroundImageLayout = ImageLayout.Zoom;
            }

            // Setup slider timer
            sliderTimer = new System.Windows.Forms.Timer();
            sliderTimer.Interval = 5000;
            sliderTimer.Tick += (s, e) => { MoveToNextSlide(); };
            sliderTimer.Start();

            // Setup scrolling - just enable AutoScroll, that's it!
            mainPanel.AutoScroll = true;
        }

        private void MoveToNextSlide()
        {
            if (sliderImages != null && sliderImages.Length > 0)
            {
                currentIndex = (currentIndex + 1) % sliderImages.Length;
                ImageSlider.BackgroundImage = sliderImages[currentIndex];
                ImageSlider.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        private void MoveToPrevSlide()
        {
            if (sliderImages != null && sliderImages.Length > 0)
            {
                currentIndex = (currentIndex - 1 + sliderImages.Length) % sliderImages.Length;
                ImageSlider.BackgroundImage = sliderImages[currentIndex];
                ImageSlider.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

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
            this.Hide();
        }

        private void lblFeatures_Click(object sender, EventArgs e)
        {
            // Scroll to CardsPanel
            mainPanel.AutoScrollPosition = new Point(0, CardsPanel.Top);
        }

        private void lblGoal_Click(object sender, EventArgs e)
        {
            // Scroll to FooterPanel
            mainPanel.AutoScrollPosition = new Point(0, FooterPanel.Top);
        }
    }
}