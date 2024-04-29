namespace Mikee_sFoodSys.UserControls
{
    partial class ucorders
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.orderGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.export_button = new System.Windows.Forms.Button();
            this.insertButton = new System.Windows.Forms.Button();
            this.quantity_box = new System.Windows.Forms.TextBox();
            this.product_idbox = new System.Windows.Forms.TextBox();
            this.customer_idbox = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.order_idtext = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // orderGrid
            // 
            this.orderGrid.AllowUserToAddRows = false;
            this.orderGrid.AllowUserToDeleteRows = false;
            this.orderGrid.AllowUserToResizeColumns = false;
            this.orderGrid.AllowUserToResizeRows = false;
            this.orderGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderGrid.Location = new System.Drawing.Point(32, 56);
            this.orderGrid.Name = "orderGrid";
            this.orderGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.orderGrid.Size = new System.Drawing.Size(747, 292);
            this.orderGrid.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(30, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 30);
            this.label4.TabIndex = 10;
            this.label4.Text = "Order Table";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Customer ID";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 410);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(272, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 48;
            this.label7.Text = "Product ID";
            // 
            // export_button
            // 
            this.export_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.export_button.Location = new System.Drawing.Point(695, 359);
            this.export_button.Name = "export_button";
            this.export_button.Size = new System.Drawing.Size(84, 23);
            this.export_button.TabIndex = 57;
            this.export_button.Text = "Export";
            this.export_button.UseVisualStyleBackColor = true;
            this.export_button.Click += new System.EventHandler(this.export_button_Click);
            // 
            // insertButton
            // 
            this.insertButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.insertButton.Location = new System.Drawing.Point(614, 358);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(75, 23);
            this.insertButton.TabIndex = 51;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // quantity_box
            // 
            this.quantity_box.Location = new System.Drawing.Point(118, 410);
            this.quantity_box.Name = "quantity_box";
            this.quantity_box.Size = new System.Drawing.Size(126, 20);
            this.quantity_box.TabIndex = 54;
            // 
            // product_idbox
            // 
            this.product_idbox.Location = new System.Drawing.Point(343, 365);
            this.product_idbox.Name = "product_idbox";
            this.product_idbox.Size = new System.Drawing.Size(126, 20);
            this.product_idbox.TabIndex = 55;
            // 
            // customer_idbox
            // 
            this.customer_idbox.Location = new System.Drawing.Point(118, 366);
            this.customer_idbox.Name = "customer_idbox";
            this.customer_idbox.Size = new System.Drawing.Size(126, 20);
            this.customer_idbox.TabIndex = 50;
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(695, 27);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(84, 23);
            this.search_button.TabIndex = 44;
            this.search_button.Text = "Search by ID";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // order_idtext
            // 
            this.order_idtext.Location = new System.Drawing.Point(563, 29);
            this.order_idtext.Name = "order_idtext";
            this.order_idtext.Size = new System.Drawing.Size(126, 20);
            this.order_idtext.TabIndex = 58;
            this.order_idtext.TextChanged += new System.EventHandler(this.order_idbutton_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(477, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 59;
            this.label1.Text = "Order ID";
            // 
            // ucorders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.order_idtext);
            this.Controls.Add(this.export_button);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.product_idbox);
            this.Controls.Add(this.quantity_box);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.customer_idbox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.orderGrid);
            this.Name = "ucorders";
            this.Size = new System.Drawing.Size(810, 455);
            ((System.ComponentModel.ISupportInitialize)(this.orderGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView orderGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button export_button;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.TextBox quantity_box;
        private System.Windows.Forms.TextBox product_idbox;
        private System.Windows.Forms.TextBox customer_idbox;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox order_idtext;
        private System.Windows.Forms.Label label1;
    }
}
