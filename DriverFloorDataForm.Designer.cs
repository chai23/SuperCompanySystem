namespace 超好企業系統
{
    partial class DriverFloorDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverFloorDataForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.search_btn = new System.Windows.Forms.Button();
            this.B1_product_quantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.four_product_quantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.driver_floor_listview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.two_product_quantity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.three_product_quantity = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.driver_floor_day_dtp = new System.Windows.Forms.DateTimePicker();
            this.morningorafter_comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.driver_comboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.search_btn);
            this.groupBox1.Controls.Add(this.B1_product_quantity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.four_product_quantity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.driver_floor_listview);
            this.groupBox1.Controls.Add(this.two_product_quantity);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.three_product_quantity);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.driver_floor_day_dtp);
            this.groupBox1.Controls.Add(this.morningorafter_comboBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.driver_comboBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cancel_btn);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(820, 601);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(627, 105);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 24);
            this.label6.TabIndex = 90;
            this.label6.Text = "當日各樓層總數";
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.search_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.search_btn.Location = new System.Drawing.Point(681, 36);
            this.search_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(94, 30);
            this.search_btn.TabIndex = 89;
            this.search_btn.Text = "查詢";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // B1_product_quantity
            // 
            this.B1_product_quantity.Enabled = false;
            this.B1_product_quantity.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.B1_product_quantity.Location = new System.Drawing.Point(664, 265);
            this.B1_product_quantity.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.B1_product_quantity.Name = "B1_product_quantity";
            this.B1_product_quantity.Size = new System.Drawing.Size(115, 32);
            this.B1_product_quantity.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(611, 267);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 24);
            this.label3.TabIndex = 87;
            this.label3.Text = "B1";
            // 
            // four_product_quantity
            // 
            this.four_product_quantity.Enabled = false;
            this.four_product_quantity.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.four_product_quantity.Location = new System.Drawing.Point(664, 147);
            this.four_product_quantity.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.four_product_quantity.Name = "four_product_quantity";
            this.four_product_quantity.Size = new System.Drawing.Size(115, 32);
            this.four_product_quantity.TabIndex = 86;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(611, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 24);
            this.label4.TabIndex = 85;
            this.label4.Text = "四樓";
            // 
            // driver_floor_listview
            // 
            this.driver_floor_listview.BackColor = System.Drawing.Color.Silver;
            this.driver_floor_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.driver_floor_listview.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.driver_floor_listview.FullRowSelect = true;
            this.driver_floor_listview.GridLines = true;
            this.driver_floor_listview.HideSelection = false;
            this.driver_floor_listview.Location = new System.Drawing.Point(41, 90);
            this.driver_floor_listview.Margin = new System.Windows.Forms.Padding(0);
            this.driver_floor_listview.Name = "driver_floor_listview";
            this.driver_floor_listview.Size = new System.Drawing.Size(546, 477);
            this.driver_floor_listview.TabIndex = 84;
            this.driver_floor_listview.UseCompatibleStateImageBehavior = false;
            this.driver_floor_listview.View = System.Windows.Forms.View.Details;
            this.driver_floor_listview.DoubleClick += new System.EventHandler(this.driver_floor_listview_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "訂單編號";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "客戶編號";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "班別";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "二樓";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "三樓";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "四樓";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "B1";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "driver_floor_id";
            this.columnHeader8.Width = 0;
            // 
            // two_product_quantity
            // 
            this.two_product_quantity.Enabled = false;
            this.two_product_quantity.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.two_product_quantity.Location = new System.Drawing.Point(664, 225);
            this.two_product_quantity.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.two_product_quantity.Name = "two_product_quantity";
            this.two_product_quantity.Size = new System.Drawing.Size(115, 32);
            this.two_product_quantity.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(611, 227);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 24);
            this.label5.TabIndex = 82;
            this.label5.Text = "二樓";
            // 
            // three_product_quantity
            // 
            this.three_product_quantity.Enabled = false;
            this.three_product_quantity.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.three_product_quantity.Location = new System.Drawing.Point(664, 186);
            this.three_product_quantity.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.three_product_quantity.Name = "three_product_quantity";
            this.three_product_quantity.Size = new System.Drawing.Size(115, 32);
            this.three_product_quantity.TabIndex = 79;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.Location = new System.Drawing.Point(611, 188);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 24);
            this.label11.TabIndex = 78;
            this.label11.Text = "三樓";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(55, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 77;
            this.label1.Text = "日期";
            // 
            // driver_floor_day_dtp
            // 
            this.driver_floor_day_dtp.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.driver_floor_day_dtp.Location = new System.Drawing.Point(106, 36);
            this.driver_floor_day_dtp.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.driver_floor_day_dtp.Name = "driver_floor_day_dtp";
            this.driver_floor_day_dtp.Size = new System.Drawing.Size(181, 32);
            this.driver_floor_day_dtp.TabIndex = 76;
            // 
            // morningorafter_comboBox
            // 
            this.morningorafter_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.morningorafter_comboBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.morningorafter_comboBox.FormattingEnabled = true;
            this.morningorafter_comboBox.Items.AddRange(new object[] {
            "上午",
            "下午"});
            this.morningorafter_comboBox.Location = new System.Drawing.Point(541, 36);
            this.morningorafter_comboBox.Name = "morningorafter_comboBox";
            this.morningorafter_comboBox.Size = new System.Drawing.Size(116, 32);
            this.morningorafter_comboBox.TabIndex = 75;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(489, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 24);
            this.label2.TabIndex = 74;
            this.label2.Text = "班別";
            // 
            // driver_comboBox
            // 
            this.driver_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driver_comboBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.driver_comboBox.FormattingEnabled = true;
            this.driver_comboBox.Location = new System.Drawing.Point(355, 36);
            this.driver_comboBox.Name = "driver_comboBox";
            this.driver_comboBox.Size = new System.Drawing.Size(116, 32);
            this.driver_comboBox.TabIndex = 73;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(303, 39);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 24);
            this.label8.TabIndex = 72;
            this.label8.Text = "司機";
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancel_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cancel_btn.Location = new System.Drawing.Point(698, 511);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(77, 55);
            this.cancel_btn.TabIndex = 61;
            this.cancel_btn.Text = "離開";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // DriverFloorDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1008, 653);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DriverFloorDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "司機搬運樓層紀錄表";
            this.Resize += new System.EventHandler(this.DriverFloorDataForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox B1_product_quantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox four_product_quantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView driver_floor_listview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox two_product_quantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox three_product_quantity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker driver_floor_day_dtp;
        private System.Windows.Forms.ComboBox morningorafter_comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox driver_comboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}