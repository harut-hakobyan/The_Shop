using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace The_Shop
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void SignButton_Click(object sender, EventArgs e)
        {
            var ff = new AuthForm();
            ff.Show();
            this.Hide();
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            var ff = new RegistrationForm();
            ff.Show();
            this.Hide();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process toKill = Process.GetCurrentProcess();
                toKill.Kill();
            }
            catch
            {
                this.Close();
            }
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int tmpX, tmpY;
        bool mousedown;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            mousedown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                this.Left = this.Left + (Cursor.Position.X - tmpX);
                this.Top = this.Top + (Cursor.Position.Y - tmpY);

                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

       
    }
}
