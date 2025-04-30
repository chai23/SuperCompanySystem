namespace 超好企業系統
{
    partial class ProductSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductSearchForm));
            this.customer_product_btn = new System.Windows.Forms.Button();
            this.all_product_btn = new System.Windows.Forms.Button();
            this.alldata_listview = new 超好企業系統.DoubleBufferListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.close_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // customer_product_btn
            // 
            this.customer_product_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.customer_product_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.customer_product_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_product_btn.Location = new System.Drawing.Point(11, 21);
            this.customer_product_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.customer_product_btn.Name = "customer_product_btn";
            this.customer_product_btn.Size = new System.Drawing.Size(92, 35);
            this.customer_product_btn.TabIndex = 67;
            this.customer_product_btn.Text = "歷史紀錄";
            this.customer_product_btn.UseVisualStyleBackColor = false;
            this.customer_product_btn.Click += new System.EventHandler(this.customer_product_btn_Click);
            // 
            // all_product_btn
            // 
            this.all_product_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.all_product_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.all_product_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.all_product_btn.Location = new System.Drawing.Point(119, 21);
            this.all_product_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.all_product_btn.Name = "all_product_btn";
            this.all_product_btn.Size = new System.Drawing.Size(92, 35);
            this.all_product_btn.TabIndex = 68;
            this.all_product_btn.Text = "全部商品";
            this.all_product_btn.UseVisualStyleBackColor = false;
            this.all_product_btn.Click += new System.EventHandler(this.all_product_btn_Click);
            // 
            // alldata_listview
            // 
            this.alldata_listview.BackColor = System.Drawing.Color.Silver;
            this.alldata_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.alldata_listview.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.alldata_listview.FullRowSelect = true;
            this.alldata_listview.GridLines = true;
            this.alldata_listview.HideSelection = false;
            this.alldata_listview.Location = new System.Drawing.Point(0, 73);
            this.alldata_listview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.alldata_listview.Name = "alldata_listview";
            this.alldata_listview.Size = new System.Drawing.Size(611, 467);
            this.alldata_listview.TabIndex = 22;
            this.alldata_listview.UseCompatibleStateImageBehavior = false;
            this.alldata_listview.View = System.Windows.Forms.View.Details;
            this.alldata_listview.DoubleClick += new System.EventHandler(this.alldata_listview_DoubleClick);
            this.alldata_listview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.alldata_listview_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "商品編號";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "商品名稱";
            this.columnHeader2.Width = 320;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "商品價格";
            this.columnHeader3.Width = 100;
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.close_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.close_btn.Location = new System.Drawing.Point(554, 26);
            this.close_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(30, 26);
            this.close_btn.TabIndex = 69;
            this.close_btn.Text = "X";
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // ProductSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(609, 539);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.all_product_btn);
            this.Controls.Add(this.customer_product_btn);
            this.Controls.Add(this.alldata_listview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ProductSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.ProductSearchForm_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferListView alldata_listview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button customer_product_btn;
        private System.Windows.Forms.Button all_product_btn;
        private System.Windows.Forms.Button close_btn;
    }
}