namespace 超好企業系統
{
    partial class AllOrderSearchForm
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
            this.close_btn = new System.Windows.Forms.Button();
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.order_search_btn = new System.Windows.Forms.Button();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.order_listview = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.close_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.close_btn.Location = new System.Drawing.Point(1243, 17);
            this.close_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(85, 40);
            this.close_btn.TabIndex = 74;
            this.close_btn.Text = "離開";
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "區域";
            this.columnHeader16.Width = 100;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "派單";
            this.columnHeader15.Width = 80;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "司機";
            this.columnHeader14.Width = 80;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "收款";
            this.columnHeader13.Width = 80;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "銷單";
            this.columnHeader12.Width = 80;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "金額";
            this.columnHeader11.Width = 70;
            // 
            // order_search_btn
            // 
            this.order_search_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.order_search_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.order_search_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order_search_btn.Location = new System.Drawing.Point(22, 17);
            this.order_search_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.order_search_btn.Name = "order_search_btn";
            this.order_search_btn.Size = new System.Drawing.Size(85, 40);
            this.order_search_btn.TabIndex = 71;
            this.order_search_btn.Text = "查詢";
            this.order_search_btn.UseVisualStyleBackColor = false;
            this.order_search_btn.Click += new System.EventHandler(this.order_search_btn_Click);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "收瓶";
            this.columnHeader10.Width = 50;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "稅額";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "發票";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "補送";
            this.columnHeader6.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "搭贈";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "扣單別";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "客戶名稱";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "送貨日期";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "訂單編號";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "送瓶";
            this.columnHeader9.Width = 50;
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
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.order_listview.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order_listview.FullRowSelect = true;
            this.order_listview.GridLines = true;
            this.order_listview.HideSelection = false;
            this.order_listview.Location = new System.Drawing.Point(0, 68);
            this.order_listview.Margin = new System.Windows.Forms.Padding(0);
            this.order_listview.Name = "order_listview";
            this.order_listview.Size = new System.Drawing.Size(1351, 641);
            this.order_listview.TabIndex = 70;
            this.order_listview.UseCompatibleStateImageBehavior = false;
            this.order_listview.View = System.Windows.Forms.View.Details;
            this.order_listview.DoubleClick += new System.EventHandler(this.order_listview_DoubleClick);
            // 
            // AllOrderSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1280, 701);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.order_search_btn);
            this.Controls.Add(this.order_listview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AllOrderSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "訂單查詢";
            this.Resize += new System.EventHandler(this.AllOrderSearchForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button order_search_btn;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ListView order_listview;
    }
}