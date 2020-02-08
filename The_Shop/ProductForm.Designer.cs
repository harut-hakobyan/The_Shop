namespace The_Shop
{
    partial class ProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QuantityBox = new System.Windows.Forms.NumericUpDown();
            this.addButton = new System.Windows.Forms.Button();
            this.ProductListBox = new System.Windows.Forms.ListBox();
            this.PriceBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QuantityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceBox)).BeginInit();
            this.SuspendLayout();
            // 
            // QuantityBox
            // 
            this.QuantityBox.Location = new System.Drawing.Point(78, 240);
            this.QuantityBox.Name = "QuantityBox";
            this.QuantityBox.Size = new System.Drawing.Size(39, 20);
            this.QuantityBox.TabIndex = 2;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(120, 237);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(60, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // ProductListBox
            // 
            this.ProductListBox.BackColor = System.Drawing.Color.Silver;
            this.ProductListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProductListBox.FormattingEnabled = true;
            this.ProductListBox.ItemHeight = 20;
            this.ProductListBox.Location = new System.Drawing.Point(12, 12);
            this.ProductListBox.Name = "ProductListBox";
            this.ProductListBox.Size = new System.Drawing.Size(168, 222);
            this.ProductListBox.TabIndex = 4;
            this.ProductListBox.SelectedIndexChanged += new System.EventHandler(this.ProductListBox_SelectedIndexChanged);
            // 
            // PriceBox
            // 
            this.PriceBox.Location = new System.Drawing.Point(12, 240);
            this.PriceBox.Name = "PriceBox";
            this.PriceBox.Size = new System.Drawing.Size(45, 20);
            this.PriceBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(57, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "$";
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 273);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PriceBox);
            this.Controls.Add(this.ProductListBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.QuantityBox);
            this.Name = "ProductForm";
            this.Text = "ProductForm";
            ((System.ComponentModel.ISupportInitialize)(this.QuantityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriceBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown QuantityBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox ProductListBox;
        private System.Windows.Forms.NumericUpDown PriceBox;
        private System.Windows.Forms.Label label1;
    }
}