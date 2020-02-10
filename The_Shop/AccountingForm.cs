using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace The_Shop
{
    public partial class AccountingForm : Form
    {
        public AccountingForm()
        {
            InitializeComponent();
            try
            {
                RefreshList();
            }
            catch
            {
                MessageBox.Show("Can't connect to server...");
            }
            moneyLabel.Text = Account.profit.ToString() + "$";
            saledProductsLabel.Text = Account.saledProducts.ToString();
        }
        private void RefreshList()
        {
            ProductListBox.Items.Clear();
            MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
            mysql_query.CommandText = $"SELECT ID,Name,Quantity FROM Warehouse";
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            while (mysql_result.Read())
            {
                ProductListBox.Items.Add(mysql_result.GetString(0).ToString() + " " + " " + mysql_result.GetString(1).ToString() + " - " + mysql_result.GetString(2).ToString());
            }
            mysql_result.Close();
        }

        private void closeButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void minimizeButton_Click(object sender, System.EventArgs e)
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
