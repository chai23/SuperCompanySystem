namespace 超好企業系統
{
    partial class CustomerSearchForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerSearchForm));
            this.search_comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.search_textBox = new System.Windows.Forms.TextBox();
            this.alldata_listview = new 超好企業系統.DoubleBufferListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.close_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // search_comboBox
            // 
            this.search_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.search_comboBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.search_comboBox.FormattingEnabled = true;
            this.search_comboBox.Items.AddRange(new object[] {
            "全部搜尋",
            "客戶編號",
            "客戶名稱",
            "客戶地址",
            "客戶電話",
            "統一編號"});
            this.search_comboBox.Location = new System.Drawing.Point(82, 48);
            this.search_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.search_comboBox.Name = "search_comboBox";
            this.search_comboBox.Size = new System.Drawing.Size(108, 32);
            this.search_comboBox.TabIndex = 20;
            this.search_comboBox.SelectedIndexChanged += new System.EventHandler(this.search_comboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(31, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "客戶";
            // 
            // search_textBox
            // 
            this.search_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.search_textBox.Location = new System.Drawing.Point(192, 48);
            this.search_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.search_textBox.Name = "search_textBox";
            this.search_textBox.Size = new System.Drawing.Size(151, 32);
            this.search_textBox.TabIndex = 18;
            this.search_textBox.TextChanged += new System.EventHandler(this.search_textBox_TextChanged);
            this.search_textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_textBox_KeyDown);
            // 
            // alldata_listview
            // 
            this.alldata_listview.BackColor = System.Drawing.Color.Silver;
            this.alldata_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.alldata_listview.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.alldata_listview.FullRowSelect = true;
            this.alldata_listview.GridLines = true;
            this.alldata_listview.HideSelection = false;
            this.alldata_listview.Location = new System.Drawing.Point(0, 133);
            this.alldata_listview.Margin = new System.Windows.Forms.Padding(2);
            this.alldata_listview.Name = "alldata_listview";
            this.alldata_listview.Size = new System.Drawing.Size(1200, 635);
            this.alldata_listview.TabIndex = 21;
            this.alldata_listview.UseCompatibleStateImageBehavior = false;
            this.alldata_listview.View = System.Windows.Forms.View.Details;
            this.alldata_listview.DoubleClick += new System.EventHandler(this.alldata_listview_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "客戶編號";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "客戶名稱";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "客戶地址";
            this.columnHeader3.Width = 320;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "聯絡人";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "手機";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "電話";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "發票";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "統一編號";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "發票地址";
            this.columnHeader9.Width = 320;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "扣單別";
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "未收回桶數";
            this.columnHeader11.Width = 100;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "預收剩餘桶數";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "主要送貨區域";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "次要送貨區域";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "公司";
            this.columnHeader15.Width = 80;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "備註";
            this.columnHeader16.Width = 200;
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.close_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.close_btn.Location = new System.Drawing.Point(1079, 36);
            this.close_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(77, 55);
            this.close_btn.TabIndex = 56;
            this.close_btn.Text = "離開";
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // CustomerSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1269, 705);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.alldata_listview);
            this.Controls.Add(this.search_comboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.search_textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CustomerSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客戶資料查詢";
            this.Resize += new System.EventHandler(this.CustomerSearchForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox search_comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox search_textBox;
        private DoubleBufferListView alldata_listview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.Button close_btn;
    }
}