using System;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace The_Shop
{
    public partial class ShopForm : Form
    {
        public ShopForm()
        {
            InitializeComponent();
            //try
            //{
            shopProductRefresh();
            
            if (Account.level == "Admin")
            {
                AdmPanelButton.Visible = true;
            }
        }
        private void shopProductRefresh()
        {
            List<Label> labelList = new List<Label>();
            Panel[] panelArray = new Panel[6];
            List<Panel> panelList = new List<Panel>();
            foreach (var item in Pictures1Panel.Controls)
            {
                panelList.Add((Panel)item);
            }
            panelList.Reverse();
            for (int i = 0; i < 5; i++)
            {
                if (changeProducts()[i].picture != "null")
                    panelList[i].BackgroundImage = Image.FromFile(@"Products\" + changeProducts()[i].picture);
                else
                    panelList[i].BackgroundImage = null;
            }
            panelList.Clear();
            foreach (var item in Pictures2Panel.Controls)
            {
                panelList.Add((Panel)item);
            }
            //panelList.Reverse();
            for (int i = 0; i < 5; i++)
            {
                panelList[i].BackgroundImage = Image.FromFile(@"Products\" + changeProducts()[i+5].picture);
            }
            panelList.Clear();
            foreach (var item in Pictures3Panel.Controls)
            {
                panelList.Add((Panel)item);
            }
            //panelList.Reverse();
            for (int i = 0; i < 5; i++)
            {
                panelList[i].BackgroundImage = Image.FromFile(@"Products\" + changeProducts()[i + 10].picture);
            }
            panelList.Clear();
            foreach (var item in Items1Panel.Controls)
            {
                labelList.Add((Label)item);
            }
            
            labelList.Reverse();
            for (int i = 0; i < 5; i++)
            {
                labelList[i + 5].Text = changeProducts()[i].name;
                labelList[i].Text = changeProducts()[i].price + "$";
            }
            labelList.Clear();
            foreach (var item in Items2Panel.Controls)
            {
                labelList.Add((Label)item);
            }
            labelList.Reverse();
            for (int i = 0; i < 5; i++)
            {
                labelList[i + 5].Text = changeProducts()[i + 5].name;
                labelList[i].Text = changeProducts()[i + 5].price + "$";
            }
            labelList.Clear();
            foreach (var item in Items3Panel.Controls)
            {
                labelList.Add((Label)item);
            }
            labelList.Reverse();
            for (int i = 0; i < 5; i++)
            {
                labelList[i + 5].Text = changeProducts()[i + 10].name;
                labelList[i].Text = changeProducts()[i + 10].price + "$";
            }
            labelList.Clear();
        }
        int tmpX, tmpY;
        bool mousedown;

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            var formm = new WelcomeForm();
            formm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        Point point;

        private void AdmPanelButton_Click(object sender, EventArgs e)
        {
            var admPanel = new AdmPanelForm();
            admPanel.Show();
        }

        private void AccountingButton_Click(object sender, EventArgs e)
        {
            var accountingForm = new AccountingForm();
            accountingForm.Show();
        }

        private void Item1Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(1);
                Item1Price.Text = Product.price.ToString() + "$";
                Item1Label.Text = Product.name;
                item1.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(1);
            }
        }
        private void AddProductSql(int id)
        {
            MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
            mysql_query.CommandText = $"UPDATE Products SET Name = '{Product.name}',Quantity = '{Product.quantity}',Price = '{Product.price}',Picture = '{Product.picture}' WHERE ID = '{id}'";
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            MessageBox.Show("Product added");
            mysql_result.Close();
        }
        private void DeleteProduct(int id)
        {
            MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
            mysql_query.CommandText = $"UPDATE Products SET Name = '',Quantity = '0',Price = '000',Picture = 'null' WHERE ID = '{id}'";
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            MessageBox.Show("Product deleted");
            mysql_result.Close();
            shopProductRefresh();
        }

        private void Item2Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(2);
                Item2Price.Text = Product.price.ToString() + "$";
                Item2Label.Text = Product.name;
                item2.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(2);
            }
        }

        private void Item3Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(3);
                Item3Price.Text = Product.price.ToString() + "$";
                Item3Label.Text = Product.name;
                item3.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(3);
            }
        }

        private void Item4Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(4);
                Item4Price.Text = Product.price.ToString() + "$";
                Item4Label.Text = Product.name;
                item4.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(4);
            }
        }

        private void Item5Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(5);
                Item5Price.Text = Product.price.ToString() + "$";
                Item5Label.Text = Product.name;
                item5.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(1);
            }
        }

        private void Item6Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(6);
                Item6Price.Text = Product.price.ToString() + "$";
                Item6Label.Text = Product.name;
                item2_1.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(6);
            }
        }

        private void Item7Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(7);
                Item7Price.Text = Product.price.ToString() + "$";
                Item7Label.Text = Product.name;
                item2_2.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(7);
            }
        }

        private void Item8Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(8);
                Item8Price.Text = Product.price.ToString() + "$";
                Item8Label.Text = Product.name;
                item2_3.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(8);
            }
        }

        private void Item9Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(9);
                Item9Price.Text = Product.price.ToString() + "$";
                Item9Label.Text = Product.name;
                item2_4.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(9);
            }
        }

        private void Item10Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(10);
                Item10Price.Text = Product.price.ToString() + "$";
                Item10Label.Text = Product.name;
                item2_5.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(10);
            }
        }

        private void Item11Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(11);
                Item11Price.Text = Product.price.ToString() + "$";
                Item11Label.Text = Product.name;
                item3_1.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(11);
            }
        }

        private void Item12Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(12);
                Item12Price.Text = Product.price.ToString() + "$";
                Item12Label.Text = Product.name;
                item3_2.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(12);
            }
        }

        private void Item13Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(13);
                Item13Price.Text = Product.price.ToString() + "$";
                Item13Label.Text = Product.name;
                item3_3.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(13);
            }
        }

        private void Item14Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(14);
                Item14Price.Text = Product.price.ToString() + "$";
                Item14Label.Text = Product.name;
                item3_4.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(14);
            }
        }

        private void Item15Button_Click(object sender, EventArgs e)
        {
            var productForm = new ProductForm();
            productForm.ShowDialog();
            if (productForm.DialogResult == DialogResult.OK)
            {
                AddProductSql(15);
                Item15Price.Text = Product.price.ToString() + "$";
                Item15Label.Text = Product.name;
                item3_5.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);
            }
            else if (productForm.DialogResult == DialogResult.Abort)
            {
                DeleteProduct(15);
            }
        }
        private string[][] productsArray = new string[16][];
        int counter = 1;
        private List<ShopProduct> changeProducts()
        {
            List<ShopProduct> shopProductList = new List<ShopProduct>();
            try
            {
                DbConnector.conn.Open();
            }
            catch
            {

            }
            MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
            mysql_query.CommandText = $"SELECT ID,Name,Price,Quantity,Picture FROM Products";
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            while (mysql_result.Read())
            {
                ShopProduct shopProd = new ShopProduct()
                {
                    name = mysql_result.GetString(1).ToString(),
                    price = mysql_result.GetString(2).ToString(),
                    quantity = mysql_result.GetString(3).ToString(),
                    picture = mysql_result.GetString(4).ToString()
                };
                shopProductList.Add(shopProd);
            }
            mysql_result.Close();
            return shopProductList;
        }
        private void labelValue(Panel panel1)
        {
            List<Label> labelList = new List<Label>();
            labelList.Add(Item1Label);
            foreach (var item in panel1.Controls)
            {
                labelList.Add((Label)item);
            }
            Items1Panel.Controls.GetType();
        }

        private void item1_Click(object sender, EventArgs e)
        {
                //if (Item1Label.Text != item)
                //{
            Basket.items.Add(Item1Label.Text + " " + Item1Price.Text);
            string tmp = Item1Price.Text;
            string tmp2 = tmp.Substring(0, tmp.Length - 1);
            Basket.amount += int.Parse(tmp2);
                    
                //}
            
            //Basket.quantity
        }

        private void BasketPictureBox_Click(object sender, EventArgs e)
        {
            var basketForm = new BasketForm();
            basketForm.Show();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            mousedown = true;
        }
    }
}
