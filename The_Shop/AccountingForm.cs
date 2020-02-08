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
                DbConnector.conn.Open();
            }
            catch
            {
            }
            try
            {
                RefreshList();
            }
            catch
            {
                MessageBox.Show("Can't connect to server...");
            }
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
    }
}
