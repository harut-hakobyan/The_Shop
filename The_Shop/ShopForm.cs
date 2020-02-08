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
            for (int i = 1; i < 16; i++)
            {
                changeProducts(i, Item1Label, Item1Price, item1_1);
            }
            //Item1Label.Text = productsArray[1][1];
            //Item1Price.Text = productsArray[1][2];
            //item1_1.BackgroundImage = Image.FromFile(@"Products\" + productsArray[1][2]) ;
            //    changeProducts(1,Item1Label,Item1Price,item1_1);
            //    changeProducts(2,Item2Label,Item2Price,item1_2);
            //    changeProducts(3, Item3Label, Item3Price, item1_3);
            //    changeProducts(4, Item4Label, Item4Price, item1_4);
            //changeProducts(5, Item5Label, Item5Price, item1_5);
            //changeProducts(6, Item6Label, Item6Price, item2_1);
            //changeProducts(7, Item7Label, Item7Price, item2_2);
            //changeProducts(8, Item8Label, Item8Price, item2_3);
            //changeProducts(9, Item9Label, Item9Price, item2_4);
            //changeProducts(10, Item10Label, Item10Price, item2_5);
            //changeProducts(11, Item11Label, Item11Price, item3_1);
            //changeProducts(12, Item12Label, Item12Price, item3_2);
            //changeProducts(13, Item13Label, Item13Price, item3_3);
            //changeProducts(14, Item14Label, Item14Price, item3_4);
            //changeProducts(15, Item15Label, Item15Price, item3_5);
            //DbConnector.conn.Close();
            //}
            //catch
            //{

            //}
            if (Account.level == "Admin")
            {
                AdmPanelButton.Visible = true;
            }
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




        private void drinkPictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                item1_1.Left = item1_1.Left + (Cursor.Position.X - tmpX);
                item1_1.Top = item1_1.Top + (Cursor.Position.Y - tmpY);

                tmpX = Cursor.Position.X;
                tmpY = Cursor.Position.Y;
            }
        }

        Point point;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string item;
        }

        private void drinkPictureBox1_Click(object sender, EventArgs e)
        {
            //while (drinkPictureBox1.Left < BasketPictureBox.Left)
            //{
            //    drinkPictureBox1.Left += 50;
            //    this.Refresh();
            //}
        }

        private void Drink1_MouseDown(object sender, MouseEventArgs e)
        {
            point = e.Location;
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            mousedown = true;
        }

        private void Drink1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown)
            {
                //Drink1.Left = Drink1.Left + (Cursor.Position.X - tmpX);
                //Drink1.Top = Drink1.Top + (Cursor.Position.Y - tmpY);

                //tmpX = Cursor.Position.X;
                //tmpY = Cursor.Position.Y;
                item1_1.Left += e.X - point.X;
                item1_1.Top += e.Y - point.Y;
            }
        }

        private void Drink1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

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
                item1_1.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);

            }
        }
        private void AddProductSql(int id)
        {
            MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
            mysql_query.CommandText = $"UPDATE Products SET Name = '{Product.name}',Quantity = '{Product.quantity}',Price = '{Product.price}',Picture = '{Product.picture}' WHERE ID = '{id}'";
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            MessageBox.Show("Product changed");
            mysql_result.Close();
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
                item1_2.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);

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
                item1_3.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);

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
                item1_4.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);

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
                item1_5.BackgroundImage = Image.FromFile(@"Products\" + Product.picture);

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
        }
        private string[][] productsArray = new string[16][];
        int counter = 1;
        private void changeProducts(int id,Label label1,Label label2,Panel panel1)
        {
            try
            {
                DbConnector.conn.Open();
            }
            catch
            {

            }
            MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
            mysql_query.CommandText = $"SELECT ID,Name,Price,Quantity,Picture FROM Products WHERE Id = '{id}'";
            MySqlDataReader mysql_result;
            mysql_result = mysql_query.ExecuteReader();
            while (mysql_result.Read())
            {
                productsArray[counter][1] = mysql_result.GetString(1).ToString();
                productsArray[counter][2] = mysql_result.GetString(2).ToString();
                

                //label1.Text = mysql_result.GetString(1).ToString();
                //label2.Text = mysql_result.GetString(2).ToString();
                if (mysql_result.GetString(4).ToString() != "null")
                {
                    productsArray[counter][3] = mysql_result.GetString(4).ToString(); ;
                }
            }
            mysql_result.Close();
        }

        private void item1_2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            tmpX = Cursor.Position.X;
            tmpY = Cursor.Position.Y;
            mousedown = true;
        }
    }
}
