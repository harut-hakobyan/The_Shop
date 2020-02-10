using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace The_Shop
{
    public partial class AdmPanelForm : Form
    {
        static string[] workersArray = new string[50];
        public AdmPanelForm()
        {
            InitializeComponent();
            try
            {
                RefreshList("Workers");
                RefreshList("Warehouse");
            }
            catch
            {
                MessageBox.Show("Can't connect to server...");
            }
            
        }
        private void RefreshList(string name)
        {
            if (name == "Workers")
            {
                WorkersListBox.Items.Clear();
                MySqlCommand mysql_query2 = DbConnector.conn.CreateCommand();
                mysql_query2.CommandText = $"SELECT ID,Name,Surname,Salary FROM Persons WHERE Level = 'Worker'";
                MySqlDataReader mysql_result2;
                mysql_result2 = mysql_query2.ExecuteReader();
                while (mysql_result2.Read())
                {
                    WorkersListBox.Items.Add(mysql_result2.GetString(0).ToString() + " " + mysql_result2.GetString(1).ToString() + " " + mysql_result2.GetString(2).ToString() + " " + mysql_result2.GetString(3).ToString() + "$");
                }
                mysql_result2.Close();
            }
            else if (name == "Warehouse")
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
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddWorkerButton_Click(object sender, EventArgs e)
        {
            if (Correct())
            {
                string query = $"INSERT INTO Persons (Name,Surname,Email,Password,Salary,Level,Money) VALUES ('{nameBox.Text}','{surnameBox.Text}','{emailBox.Text}','{passwordBox.Text}','{salaryBox.Text}','Worker','2000')";
                MySqlScript script = new MySqlScript(DbConnector.conn, query);
                int count = script.Execute();
                MessageBox.Show("Worker has been Registered!");
                RefreshList("Workers");
            }
            else
            {
                MessageBox.Show("Fill out all of the required fields correctly");
            }
        }
        private bool Correct()
        {
            if (nameBox.Text.Length > 4 && emailBox.Text.Length > 9 && passwordBox.Text.Length > 6 && surnameBox.Text.Length > 2 && salaryBox.Text.Length > 3)
                return true;
            else
                return false;
        }

        private void DeleteWorkerButton_Click(object sender, EventArgs e)
        {
            if (WorkersListBox.SelectedIndex != -1)
            {
                try
                {
                    string textString = WorkersListBox.SelectedItem.ToString();
                    string idText = textString.Substring(0, 2);
                    int id = int.Parse(idText);
                    string query = $"DELETE FROM Persons WHERE ID = '{id}'";
                    MySqlScript script = new MySqlScript(DbConnector.conn, query);
                    int count = script.Execute();
                    MessageBox.Show("Worker has been deleted");
                    RefreshList("Workers");
                }
                catch
                {
                    MessageBox.Show("Can't connect to server, please try again");
                }
            }
            else
                MessageBox.Show("Select worker to delete");
        }

        private void ChousePictureButton_Click(object sender, EventArgs e)
        {
            var pictureForm = new PicturesForm();
            pictureForm.ShowDialog();
            if (pictureForm.DialogResult == DialogResult.OK)
            {
                fileLocationBox.Text = Product.picture;
            }
        }

        private void AddProductButton_Click(object sender, EventArgs e)
        {
            if (ProductNameBox.Text != "" && ProductQuantityBox.Text != "" && int.Parse(ProductQuantityBox.Text) > 0 && fileLocationBox.Text!="")
            {
                string query = $"INSERT INTO Warehouse (Name,Quantity,Picture) VALUES ('{ProductNameBox.Text}','{ProductQuantityBox.Text}','{fileLocationBox.Text}')";
                MySqlScript script = new MySqlScript(DbConnector.conn, query);
                int count = script.Execute();
                MessageBox.Show("Product added");
                ProductNameBox.Text = "";
                ProductQuantityBox.Text = "";
                fileLocationBox.Text = "";
                RefreshList("Warehouse");
            }
            else
                MessageBox.Show("Please fill all the fields");
        }
        static int idProd;
        static string nameProd;
        static string quantityProd;
        private void ProductListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editNameBox.Enabled = true;
            editQuantityBox.Enabled = true;
            string textString = ProductListBox.SelectedItem.ToString();
            string idText = textString.Substring(0, 2);
            int id = int.Parse(idText);
            idProd = id;
            if (editRadio.Checked)
            {
                editIdLabel.Text = id.ToString();
                MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
                mysql_query.CommandText = $"SELECT Name,Quantity FROM Warehouse WHERE ID = '{id}'";
                MySqlDataReader mysql_result;
                mysql_result = mysql_query.ExecuteReader();
                while (mysql_result.Read())
                {
                    editNameBox.Text = mysql_result.GetString(0).ToString();
                    editQuantityBox.Text = mysql_result.GetString(1).ToString();
                }
                nameProd = editNameBox.Text;
                quantityProd = editQuantityBox.Text;
                mysql_result.Close();
            }
            if (deleteRadio.Checked)
            {
                deleteIdLabel.Text = id.ToString();
                MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
                mysql_query.CommandText = $"SELECT Name FROM Warehouse WHERE ID = '{id}'";
                MySqlDataReader mysql_result;
                mysql_result = mysql_query.ExecuteReader();
                while (mysql_result.Read())
                {
                    deleteNameBox.Text = mysql_result.GetString(0).ToString();
                }
                mysql_result.Close();
            }

        }
        private void editRadio_CheckedChanged(object sender, EventArgs e)
        {
            editPanel.Visible = true;
            addPanel.Visible = false;
            deletePanel.Visible = false;
            boxLock("Edit");
        }
        private void addRadio_CheckedChanged(object sender, EventArgs e)
        {
            editPanel.Visible = false;
            addPanel.Visible = true;
            deletePanel.Visible = false;
        }

        private void deleteRadio_CheckedChanged(object sender, EventArgs e)
        {
            editPanel.Visible = false;
            addPanel.Visible = false;
            deletePanel.Visible = true;
            boxLock("Delete");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (editNameBox.Text != "")
            {
                if (editNameBox.Text != nameProd || editQuantityBox.Text != quantityProd && int.Parse(editQuantityBox.Text) >0)
                {
                    MySqlCommand mysql_query = DbConnector.conn.CreateCommand();
                    mysql_query.CommandText = $"UPDATE Warehouse SET Name = '{editNameBox.Text}',Quantity = '{editQuantityBox.Text}' WHERE ID = '{idProd}'";
                    MySqlDataReader mysql_result;
                    mysql_result = mysql_query.ExecuteReader();
                    MessageBox.Show("Product changed");
                    mysql_result.Close();
                    RefreshList("Warehouse");
                    boxLock("Edit");
                }
                else
                    MessageBox.Show("Please change name or quantity of product");
            }
            else
                MessageBox.Show("Select product to edit");
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (deleteNameBox.Text != "")
            {
                int id = int.Parse(deleteIdLabel.Text);
                string query = $"DELETE FROM Warehouse WHERE ID = '{id}'";
                MySqlScript script = new MySqlScript(DbConnector.conn, query);
                int count = script.Execute();
                MessageBox.Show("Product has been deleted");
                RefreshList("Warehouse");
                boxLock("Delete");
            }
            else
                MessageBox.Show("Select product to delete");
        }
        private void boxLock(string name)
        {
            if (name == "Edit")
            {
                editNameBox.Text = "";
                editQuantityBox.Text = "";
                editNameBox.Enabled = false;
                editQuantityBox.Enabled = false;
            }
            if (name == "Delete")
            {
                deleteNameBox.Text = "";
                deleteNameBox.Enabled = false;
            }
            
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }
    }
}
