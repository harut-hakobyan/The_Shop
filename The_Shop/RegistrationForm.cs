using System;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace The_Shop
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }
        private void RegButton_Click_1(object sender, EventArgs e)
        {
            if (Correct())
            {
                string query = $"INSERT INTO Persons (Name,Surname,Email,Password) VALUES ('{nameBox.Text}','{surnameBox.Text}','{emailBox.Text}','{passwordBox.Text}')";
                MySqlScript script = new MySqlScript(DbConnector.conn, query);
                int count = script.Execute();
                MessageBox.Show("Account has been Registered!");
                DbConnector.conn.Close();
                var auth = new AuthForm();
                auth.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Fill out all of the required fields correctly");
            }
        }
        private bool Correct()
        {
            if (nameBox.Text.Length > 4 || emailBox.Text.Length > 9 || passwordBox.Text.Length>6 || surnameBox.Text.Length>2)
                return true;
            else
                return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var formm = new WelcomeForm();
            formm.Show();
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        int tmpX, tmpY;
        bool mousedown;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            mousedown = true;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                this.Left = this.Left + (Cursor.Position.X - tmpX);
                this.Top = this.Top + (Cursor.Position.Y - tmpY);

                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }
    }
}
