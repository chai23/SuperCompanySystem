namespace 超好企業系統
{
    partial class CollectMoneyHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollectMoneyHistoryForm));
            this.label1 = new System.Windows.Forms.Label();
            this.day2_dtp = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.day1_dtp = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.customer_name_textBox = new System.Windows.Forms.TextBox();
            this.search_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.customer_id_textBox = new System.Windows.Forms.TextBox();
            this.order_listview = new 超好企業系統.DoubleBufferListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(295, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 24);
            this.label1.TabIndex = 87;
            this.label1.Text = "~";
            // 
            // day2_dtp
            // 
            this.day2_dtp.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.day2_dtp.Location = new System.Drawing.Point(322, 17);
            this.day2_dtp.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.day2_dtp.Name = "day2_dtp";
            this.day2_dtp.Size = new System.Drawing.Size(181, 32);
            this.day2_dtp.TabIndex = 86;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(20, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 89;
            this.label2.Text = "日期範圍";
            // 
            // day1_dtp
            // 
            this.day1_dtp.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.day1_dtp.Location = new System.Drawing.Point(110, 17);
            this.day1_dtp.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.day1_dtp.Name = "day1_dtp";
            this.day1_dtp.Size = new System.Drawing.Size(181, 32);
            this.day1_dtp.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(20, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 24);
            this.label3.TabIndex = 91;
            this.label3.Text = "客戶編號";
            // 
            // customer_name_textBox
            // 
            this.customer_name_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_name_textBox.Location = new System.Drawing.Point(219, 62);
            this.customer_name_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customer_name_textBox.Name = "customer_name_textBox";
            this.customer_name_textBox.ReadOnly = true;
            this.customer_name_textBox.Size = new System.Drawing.Size(284, 32);
            this.customer_name_textBox.TabIndex = 90;
            // 
            // search_btn
            // 
            this.search_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.search_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.search_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.search_btn.Location = new System.Drawing.Point(604, 38);
            this.search_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.search_btn.Name = "search_btn";
            this.search_btn.Size = new System.Drawing.Size(61, 51);
            this.search_btn.TabIndex = 94;
            this.search_btn.Text = "查詢";
            this.search_btn.UseVisualStyleBackColor = false;
            this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.close_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.close_btn.Location = new System.Drawing.Point(680, 38);
            this.close_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(61, 51);
            this.close_btn.TabIndex = 95;
            this.close_btn.Text = "離開";
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // customer_id_textBox
            // 
            this.customer_id_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_id_textBox.Location = new System.Drawing.Point(110, 62);
            this.customer_id_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customer_id_textBox.Name = "customer_id_textBox";
            this.customer_id_textBox.Size = new System.Drawing.Size(105, 32);
            this.customer_id_textBox.TabIndex = 96;
            this.customer_id_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customer_id_textBox_KeyDown);
            // 
            // order_listview
            // 
            this.order_listview.BackColor = System.Drawing.Color.Silver;
            this.order_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.order_listview.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order_listview.FullRowSelect = true;
            this.order_listview.GridLines = true;
            this.order_listview.HideSelection = false;
            this.order_listview.Location = new System.Drawing.Point(0, 108);
            this.order_listview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.order_listview.Name = "order_listview";
            this.order_listview.Size = new System.Drawing.Size(771, 635);
            this.order_listview.TabIndex = 93;
            this.order_listview.UseCompatibleStateImageBehavior = false;
            this.order_listview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "收款日期";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "扣單別";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "訂單編號";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "序";
            this.columnHeader4.Width = 40;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "商品名稱";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "收款金額";
            this.columnHeader6.Width = 100;
            // 
            // CollectMoneyHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1239, 705);
            this.Controls.Add(this.customer_id_textBox);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.search_btn);
            this.Controls.Add(this.order_listview);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.customer_name_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.day1_dtp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.day2_dtp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CollectMoneyHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收款紀錄";
            this.Resize += new System.EventHandler(this.CollectMoneyHistoryForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker day2_dtp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker day1_dtp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customer_name_textBox;
        private DoubleBufferListView order_listview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.TextBox customer_id_textBox;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}