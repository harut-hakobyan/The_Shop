using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace The_Shop
{
    public partial class ProductForm : Form
    {
        public ProductForm()
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
            int prodId =0;
            ProductListBox.Items.Clear();
            MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
            mysql_query.CommandText = $"SELECT ID,Name,Quantity FROM Warehouse";
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            while (mysql_result.Read())
            {
                int tmpInt = int.Parse(mysql_result.GetString(2).ToString());
                if (tmpInt != 0)
                {
                    ProductListBox.Items.Add(mysql_result.GetString(0).ToString() + " " + " " + mysql_result.GetString(1).ToString() + " - " + " " + mysql_result.GetString(2).ToString());
                }
                else
                    prodId = int.Parse(mysql_result.GetString(0).ToString());
            }
            mysql_result.Close();
            if (prodId != 0)
            {
                string query = $"DELETE FROM Warehouse WHERE ID = '{prodId}'";
                MySqlScript script = new MySqlScript(DbConnector.conn, query);
                int count = script.Execute();
            }
        }
        int idProd;
        int countProd;
        private void ProductListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string textString = ProductListBox.SelectedItem.ToString();
            string idText = textString.Substring(0, 2);
            idProd = int.Parse(idText);

            MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
            mysql_query.CommandText = $"SELECT Quantity FROM Warehouse WHERE ID = '{idProd}'";
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            while (mysql_result.Read())
            {
                countProd = int.Parse(mysql_result.GetString(0).ToString());
            }
            Product.price = (double)PriceBox.Value;
            Product.quantity = (int)QuantityBox.Value;
            mysql_result.Close();

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (ProductListBox.SelectedIndex != -1)
            {
                if (PriceBox.Value >= 1 && PriceBox.Value < 100)
                {
                    MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
                    mysql_query.CommandText = $"SELECT ID,Name,Quantity,Picture FROM Warehouse WHERE ID = '{idProd}'";
                    MySqlDataReader mysql_result;
                    mysql_result = mysql_query.ExecuteReader();
                    while (mysql_result.Read())
                    {
                        Product.name = mysql_result.GetString(1).ToString();
                        Product.picture = mysql_result.GetString(3).ToString();
                    }
                    mysql_result.Close();
                    if (countProd >= QuantityBox.Value)
                    {
                        Product.price = (double)PriceBox.Value;
                        // Product.quantity =
                        if (Product.nameTmp == Product.name)
                        {

                            Product.quantity = (int)QuantityBox.Value + Product.quantityTmp;
                        }
                        else
                        {
                            int quantityTmp = 0;
                            Product.quantity = (int)QuantityBox.Value;
                            ////////////////////////////Select//////////////
                            MySqlCommand mysql_query3 = DbConnector.conn.CreateCommand();
                            mysql_query3.CommandText = $"SELECT Quantity FROM Warehouse WHERE Name = '{Product.nameTmp}'";
                            MySqlDataReader mysql_result3;
                            mysql_result3 = mysql_query3.ExecuteReader();
                            while (mysql_result3.Read())
                            {
                                quantityTmp = int.Parse(mysql_result3.GetString(0).ToString());
                            }
                            mysql_result3.Close();
                            /////////////////////////////////////////////////
                            MySqlCommand mysql_query4 = DbConnector.conn.CreateCommand();
                            mysql_query4.CommandText = $"UPDATE Warehouse SET QUantity = '{quantityTmp+Product.quantityTmp}' WHERE Name = '{Product.nameTmp}'";
                            MySqlDataReader mysql_result4;
                            mysql_result4 = mysql_query4.ExecuteReader();
                            mysql_result4.Close();
                        }
                        MySqlCommand mysql_query2 = DbConnector.conn.CreateCommand();
                        mysql_query2.CommandText = $"UPDATE Warehouse SET QUantity = '{countProd - QuantityBox.Value}' WHERE ID = '{idProd}'";
                        MySqlDataReader mysql_result2;
                        mysql_result2 = mysql_query2.ExecuteReader();
                        mysql_result2.Close();
                        DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("There are not so many products in stock");
                }
                else
                    MessageBox.Show("Price must be greater than 0 and smaller than 100");
                
            }
            else
                MessageBox.Show("Select product to add");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
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
