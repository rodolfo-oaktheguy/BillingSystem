using System;
using System.Drawing;
using System.Windows.Forms;
using BillingSystem.Utils;

namespace BillingSystem
{
    public class SplashScreen : Form
    {
        private readonly System.Windows.Forms.Timer splashTimer;

        public SplashScreen()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(500, 300);
            BackColor = AppTheme.Primary;

            var lblAppName = new Label
            {
                Name = "lblAppName",
                Text = "BILLING SYSTEM",
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 65),
                Size = new Size(460, 50)
            };

            var lblTagline = new Label
            {
                Name = "lblTagline",
                Text = "Electric Billing Management System",
                Font = new Font("Segoe UI", 11, FontStyle.Regular),
                ForeColor = Color.FromArgb(0xBD, 0xD7, 0xEE),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 125),
                Size = new Size(460, 30)
            };

            var lblLoading = new Label
            {
                Name = "lblLoading",
                Text = "Loading...",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.FromArgb(0xBD, 0xD7, 0xEE),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(20, 205),
                Size = new Size(460, 24)
            };

            Controls.Add(lblAppName);
            Controls.Add(lblTagline);
            Controls.Add(lblLoading);

            splashTimer = new System.Windows.Forms.Timer { Interval = 2500 };
            splashTimer.Tick += splashTimer_Tick;
            Load += SplashScreen_Load;
            FormClosed += (_, __) => splashTimer.Dispose();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            BackColor = AppTheme.Primary;
            splashTimer.Start();
        }

        private void splashTimer_Tick(object sender, EventArgs e)
        {
            splashTimer.Stop();
            Hide();

            var loginForm = new LoginForm();
            loginForm.FormClosed += (_, __) => Close();
            loginForm.Show();
        }
    }
}
