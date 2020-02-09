using System;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Shop
{
    public partial class BasketForm : Form
    {
        public BasketForm()
        {
            InitializeComponent();
            RefreshList();
        }
        private void RefreshList()
        {
            moneyLabel.Text = Account.money.ToString() + "$";
            basketListBox.Items.Clear();
            amountLabel.Text = Basket.amount.ToString() + "$";
            int count = 0;
            foreach (var item in Basket.items)
            {
                basketListBox.Items.Add(item);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (basketListBox.SelectedIndex != -1)
            {
                string tmp = basketListBox.SelectedItem.ToString();
                string tmp2 = Regex.Replace(tmp, "\\D+", "");

                int tmpInt = int.Parse(tmp2);
                Basket.amount -= tmpInt;
                Basket.items.RemoveAt(basketListBox.SelectedIndex);
                Basket.count--;
                RefreshList();
            }
            else
                MessageBox.Show("Select item to delete");
        }
        private void buyButton_Click(object sender, EventArgs e)
        {
            if (basketListBox.Items.Count != 0)
            {
                Account.saledProducts += basketListBox.Items.Count;
                basketListBox.Items.Clear();
                Account.money -= Basket.amount;
                moneyLabel.Text = Account.money.ToString() + "$";
                Basket.items.Clear();
                MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
                mysql_query.CommandText = $"UPDATE Persons SET Money = '{Account.money}' WHERE ID = '{Account.id}'";
                MySqlDataReader mysql_result;
                mysql_result = mysql_query.ExecuteReader();
                mysql_result.Close();
                Basket.count = 0;
                int globalAmount = Account.profit + Basket.amount;
                MySqlCommand mysql_query2 = DbConnector.conn.CreateCommand();
                mysql_query2.CommandText = $"UPDATE Profit SET Value = '{globalAmount}' WHERE ID = '1';UPDATE Profit SET Value = '{Account.saledProducts}' WHERE ID = '2'";
                MySqlDataReader mysql_result2;
                mysql_result2 = mysql_query2.ExecuteReader();
                mysql_result2.Close();
                Basket.amount = 0;
                amountLabel.Text = "0";
                Account.profit = globalAmount;
                MessageBox.Show("Product's buyed");
            }
            else
                MessageBox.Show("Basket is empty");
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
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
