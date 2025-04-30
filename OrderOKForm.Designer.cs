namespace 超好企業系統
{
    partial class OrderOKForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderOKForm));
            this.driver_comboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.order_search_btn = new System.Windows.Forms.Button();
            this.driver_order_listview = new System.Windows.Forms.ListView();
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader23 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader28 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader29 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.order_OK_btn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.close_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.deliver_day_dtp = new System.Windows.Forms.DateTimePicker();
            this.morningorafter_comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.driver_floor_btn = new System.Windows.Forms.Button();
            this.morningorafter_comboBox_report = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.driver_total_quantity_label = new System.Windows.Forms.Label();
            this.driver_total_money_label = new System.Windows.Forms.Label();
            this.driver_total_recyele_quantity_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // driver_comboBox
            // 
            this.driver_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driver_comboBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.driver_comboBox.FormattingEnabled = true;
            this.driver_comboBox.Location = new System.Drawing.Point(172, 106);
            this.driver_comboBox.Margin = new System.Windows.Forms.Padding(4);
            this.driver_comboBox.Name = "driver_comboBox";
            this.driver_comboBox.Size = new System.Drawing.Size(172, 44);
            this.driver_comboBox.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(94, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 36);
            this.label8.TabIndex = 61;
            this.label8.Text = "司機";
            // 
            // order_search_btn
            // 
            this.order_search_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.order_search_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.order_search_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order_search_btn.Location = new System.Drawing.Point(361, 106);
            this.order_search_btn.Margin = new System.Windows.Forms.Padding(2);
            this.order_search_btn.Name = "order_search_btn";
            this.order_search_btn.Size = new System.Drawing.Size(107, 104);
            this.order_search_btn.TabIndex = 63;
            this.order_search_btn.Text = "查詢";
            this.order_search_btn.UseVisualStyleBackColor = false;
            this.order_search_btn.Click += new System.EventHandler(this.order_search_btn_Click);
            // 
            // driver_order_listview
            // 
            this.driver_order_listview.BackColor = System.Drawing.Color.Silver;
            this.driver_order_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22,
            this.columnHeader18,
            this.columnHeader23,
            this.columnHeader28,
            this.columnHeader29,
            this.columnHeader4,
            this.columnHeader1});
            this.driver_order_listview.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.driver_order_listview.FullRowSelect = true;
            this.driver_order_listview.GridLines = true;
            this.driver_order_listview.HideSelection = false;
            this.driver_order_listview.Location = new System.Drawing.Point(0, 257);
            this.driver_order_listview.Margin = new System.Windows.Forms.Padding(0);
            this.driver_order_listview.Name = "driver_order_listview";
            this.driver_order_listview.Size = new System.Drawing.Size(2024, 787);
            this.driver_order_listview.TabIndex = 65;
            this.driver_order_listview.UseCompatibleStateImageBehavior = false;
            this.driver_order_listview.View = System.Windows.Forms.View.Details;
            this.driver_order_listview.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.driver_order_listview_MouseDoubleClick);
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "訂單編號";
            this.columnHeader16.Width = 120;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "客戶編號";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "客戶名稱";
            this.columnHeader19.Width = 150;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "送瓶";
            this.columnHeader20.Width = 70;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "回收";
            this.columnHeader21.Width = 70;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "收款金額";
            this.columnHeader22.Width = 80;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "司機送達";
            this.columnHeader18.Width = 80;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "司機";
            this.columnHeader23.Width = 80;
            // 
            // columnHeader28
            // 
            this.columnHeader28.Text = "送貨日期";
            this.columnHeader28.Width = 150;
            // 
            // columnHeader29
            // 
            this.columnHeader29.Text = "班別";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "訂單備註";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "應收金額";
            this.columnHeader1.Width = 80;
            // 
            // order_OK_btn
            // 
            this.order_OK_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.order_OK_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.order_OK_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order_OK_btn.Location = new System.Drawing.Point(1134, 103);
            this.order_OK_btn.Margin = new System.Windows.Forms.Padding(2);
            this.order_OK_btn.Name = "order_OK_btn";
            this.order_OK_btn.Size = new System.Drawing.Size(126, 106);
            this.order_OK_btn.TabIndex = 66;
            this.order_OK_btn.Text = "銷單";
            this.order_OK_btn.UseVisualStyleBackColor = false;
            this.order_OK_btn.Click += new System.EventHandler(this.order_OK_btn_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.close_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.close_btn.Location = new System.Drawing.Point(1865, 82);
            this.close_btn.Margin = new System.Windows.Forms.Padding(2);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(110, 90);
            this.close_btn.TabIndex = 67;
            this.close_btn.Text = "離開";
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(39, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 36);
            this.label1.TabIndex = 69;
            this.label1.Text = "送貨日期";
            // 
            // deliver_day_dtp
            // 
            this.deliver_day_dtp.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.deliver_day_dtp.Location = new System.Drawing.Point(172, 44);
            this.deliver_day_dtp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deliver_day_dtp.Name = "deliver_day_dtp";
            this.deliver_day_dtp.Size = new System.Drawing.Size(296, 45);
            this.deliver_day_dtp.TabIndex = 68;
            // 
            // morningorafter_comboBox
            // 
            this.morningorafter_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.morningorafter_comboBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.morningorafter_comboBox.FormattingEnabled = true;
            this.morningorafter_comboBox.Items.AddRange(new object[] {
            "整天",
            "上午",
            "下午"});
            this.morningorafter_comboBox.Location = new System.Drawing.Point(172, 166);
            this.morningorafter_comboBox.Margin = new System.Windows.Forms.Padding(4);
            this.morningorafter_comboBox.Name = "morningorafter_comboBox";
            this.morningorafter_comboBox.Size = new System.Drawing.Size(172, 44);
            this.morningorafter_comboBox.TabIndex = 71;
            this.morningorafter_comboBox.SelectedIndexChanged += new System.EventHandler(this.morningorafter_comboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(903, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 36);
            this.label2.TabIndex = 70;
            this.label2.Text = "送達班別";
            // 
            // driver_floor_btn
            // 
            this.driver_floor_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.driver_floor_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.driver_floor_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.driver_floor_btn.Location = new System.Drawing.Point(909, 103);
            this.driver_floor_btn.Margin = new System.Windows.Forms.Padding(2);
            this.driver_floor_btn.Name = "driver_floor_btn";
            this.driver_floor_btn.Size = new System.Drawing.Size(221, 106);
            this.driver_floor_btn.TabIndex = 73;
            this.driver_floor_btn.Text = "搬運樓層登記";
            this.driver_floor_btn.UseVisualStyleBackColor = false;
            this.driver_floor_btn.Click += new System.EventHandler(this.driver_floor_btn_Click);
            // 
            // morningorafter_comboBox_report
            // 
            this.morningorafter_comboBox_report.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.morningorafter_comboBox_report.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.morningorafter_comboBox_report.FormattingEnabled = true;
            this.morningorafter_comboBox_report.Items.AddRange(new object[] {
            "上午",
            "下午"});
            this.morningorafter_comboBox_report.Location = new System.Drawing.Point(1037, 46);
            this.morningorafter_comboBox_report.Margin = new System.Windows.Forms.Padding(4);
            this.morningorafter_comboBox_report.Name = "morningorafter_comboBox_report";
            this.morningorafter_comboBox_report.Size = new System.Drawing.Size(223, 44);
            this.morningorafter_comboBox_report.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(38, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 36);
            this.label3.TabIndex = 75;
            this.label3.Text = "派單班別";
            // 
            // driver_total_quantity_label
            // 
            this.driver_total_quantity_label.AutoSize = true;
            this.driver_total_quantity_label.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.driver_total_quantity_label.Location = new System.Drawing.Point(558, 54);
            this.driver_total_quantity_label.Name = "driver_total_quantity_label";
            this.driver_total_quantity_label.Size = new System.Drawing.Size(239, 36);
            this.driver_total_quantity_label.TabIndex = 76;
            this.driver_total_quantity_label.Text = "司機送水總桶數：";
            // 
            // driver_total_money_label
            // 
            this.driver_total_money_label.AutoSize = true;
            this.driver_total_money_label.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.driver_total_money_label.Location = new System.Drawing.Point(558, 172);
            this.driver_total_money_label.Name = "driver_total_money_label";
            this.driver_total_money_label.Size = new System.Drawing.Size(239, 36);
            this.driver_total_money_label.TabIndex = 77;
            this.driver_total_money_label.Text = "司機收款總金額：";
            // 
            // driver_total_recyele_quantity_label
            // 
            this.driver_total_recyele_quantity_label.AutoSize = true;
            this.driver_total_recyele_quantity_label.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.driver_total_recyele_quantity_label.Location = new System.Drawing.Point(558, 114);
            this.driver_total_recyele_quantity_label.Name = "driver_total_recyele_quantity_label";
            this.driver_total_recyele_quantity_label.Size = new System.Drawing.Size(239, 36);
            this.driver_total_recyele_quantity_label.TabIndex = 78;
            this.driver_total_recyele_quantity_label.Text = "司機回收總桶數：";
            // 
            // OrderOKForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(2054, 1185);
            this.Controls.Add(this.driver_total_recyele_quantity_label);
            this.Controls.Add(this.driver_total_money_label);
            this.Controls.Add(this.driver_total_quantity_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.morningorafter_comboBox_report);
            this.Controls.Add(this.driver_floor_btn);
            this.Controls.Add(this.morningorafter_comboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deliver_day_dtp);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.order_OK_btn);
            this.Controls.Add(this.driver_order_listview);
            this.Controls.Add(this.order_search_btn);
            this.Controls.Add(this.driver_comboBox);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OrderOKForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "銷單結帳";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrderOKForm_FormClosed);
            this.Resize += new System.EventHandler(this.OrderOKForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox driver_comboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button order_search_btn;
        private System.Windows.Forms.ListView driver_order_listview;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.Button order_OK_btn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker deliver_day_dtp;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader23;
        private System.Windows.Forms.ColumnHeader columnHeader28;
        private System.Windows.Forms.ColumnHeader columnHeader29;
        private System.Windows.Forms.ComboBox morningorafter_comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button driver_floor_btn;
        private System.Windows.Forms.ComboBox morningorafter_comboBox_report;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label driver_total_quantity_label;
        private System.Windows.Forms.Label driver_total_money_label;
        private System.Windows.Forms.Label driver_total_recyele_quantity_label;
    }
}