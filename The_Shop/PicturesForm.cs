using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Shop
{
    public partial class PicturesForm : Form
    {
        public PicturesForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void Jermuk_Click(object sender, EventArgs e)
        {
            Product.picture = "Jermuk.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void CocaCola_Click(object sender, EventArgs e)
        {
            Product.picture = "CocaCola.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Fanta_Click(object sender, EventArgs e)
        {
            Product.picture = "Fanta.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Sprite_Click(object sender, EventArgs e)
        {
            Product.picture = "Sprite.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Natural_Click(object sender, EventArgs e)
        {
            Product.picture = "Natural.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Apple_Click(object sender, EventArgs e)
        {
            Product.picture = "Apple.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Pear_Click(object sender, EventArgs e)
        {
            Product.picture = "Pear.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Banan_Click(object sender, EventArgs e)
        {
            Product.picture = "Banan.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Ananas_Click(object sender, EventArgs e)
        {
            Product.picture = "Ananas.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Orange_Click(object sender, EventArgs e)
        {
            Product.picture = "Orange.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Candy1_Click(object sender, EventArgs e)
        {
            Product.picture = "Candy1.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Candy2_Click(object sender, EventArgs e)
        {
            Product.picture = "Candy2.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Candy3_Click(object sender, EventArgs e)
        {
            Product.picture = "Candy3.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Candy4_Click(object sender, EventArgs e)
        {
            Product.picture = "Candy4.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }

        private void Candy5_Click(object sender, EventArgs e)
        {
            Product.picture = "Candy5.png";
            okButton.Enabled = true;
            MessageBox.Show("Picture selected");
        }
    }
}
