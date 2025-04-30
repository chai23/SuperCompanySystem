namespace 超好企業系統
{
    partial class OldOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OldOrderForm));
            this.order_listview = new 超好企業系統.DoubleBufferListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // order_listview
            // 
            this.order_listview.BackColor = System.Drawing.Color.Silver;
            this.order_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader3,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader5,
            this.columnHeader15,
            this.columnHeader4});
            this.order_listview.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order_listview.FullRowSelect = true;
            this.order_listview.GridLines = true;
            this.order_listview.HideSelection = false;
            this.order_listview.Location = new System.Drawing.Point(0, 0);
            this.order_listview.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.order_listview.Name = "order_listview";
            this.order_listview.Size = new System.Drawing.Size(1173, 538);
            this.order_listview.TabIndex = 57;
            this.order_listview.UseCompatibleStateImageBehavior = false;
            this.order_listview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "訂單編號";
            this.columnHeader1.Width = 130;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "訂單日期";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "序";
            this.columnHeader8.Width = 30;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "商品編號";
            this.columnHeader9.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "商品名稱";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "金額";
            this.columnHeader10.Width = 50;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "數量";
            this.columnHeader11.Width = 50;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "稅金";
            this.columnHeader12.Width = 50;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "小計";
            this.columnHeader13.Width = 70;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "備註";
            this.columnHeader14.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "客戶編號";
            this.columnHeader5.Width = 90;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "發票";
            this.columnHeader15.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "扣單別";
            this.columnHeader4.Width = 80;
            // 
            // OldOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1249, 548);
            this.Controls.Add(this.order_listview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OldOrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "舊系統資料";
            this.Resize += new System.EventHandler(this.OldOrderForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferListView order_listview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}