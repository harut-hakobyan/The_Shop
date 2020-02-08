using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
                RefreshList();
            }
            else
                MessageBox.Show("Select item to delete");
        }

        private void button3_Click(object sender, EventArgs e)
        {
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
