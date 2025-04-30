namespace 超好企業系統
{
    partial class CustomerMemoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerMemoForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customer_name_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.close_btn = new System.Windows.Forms.Button();
            this.remove_btn = new System.Windows.Forms.Button();
            this.memo_finish_OK_btn = new System.Windows.Forms.Button();
            this.new_btn = new System.Windows.Forms.Button();
            this.customer_id_textBox = new System.Windows.Forms.TextBox();
            this.memo_listview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memo_content_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.customer_name_textBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.close_btn);
            this.groupBox1.Controls.Add(this.remove_btn);
            this.groupBox1.Controls.Add(this.memo_finish_OK_btn);
            this.groupBox1.Controls.Add(this.new_btn);
            this.groupBox1.Controls.Add(this.customer_id_textBox);
            this.groupBox1.Controls.Add(this.memo_listview);
            this.groupBox1.Controls.Add(this.memo_content_textBox);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1336, 776);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(909, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 36);
            this.label1.TabIndex = 78;
            this.label1.Text = "名稱";
            // 
            // customer_name_textBox
            // 
            this.customer_name_textBox.Enabled = false;
            this.customer_name_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_name_textBox.Location = new System.Drawing.Point(986, 62);
            this.customer_name_textBox.Name = "customer_name_textBox";
            this.customer_name_textBox.Size = new System.Drawing.Size(278, 45);
            this.customer_name_textBox.TabIndex = 77;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(664, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 36);
            this.label8.TabIndex = 76;
            this.label8.Text = "客戶";
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.close_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.close_btn.Location = new System.Drawing.Point(1148, 664);
            this.close_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(116, 54);
            this.close_btn.TabIndex = 75;
            this.close_btn.Text = "離開";
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // remove_btn
            // 
            this.remove_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.remove_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.remove_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.remove_btn.Location = new System.Drawing.Point(807, 664);
            this.remove_btn.Margin = new System.Windows.Forms.Padding(2);
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.Size = new System.Drawing.Size(138, 54);
            this.remove_btn.TabIndex = 74;
            this.remove_btn.Text = "移除";
            this.remove_btn.UseVisualStyleBackColor = false;
            this.remove_btn.Click += new System.EventHandler(this.remove_btn_Click);
            // 
            // memo_finish_OK_btn
            // 
            this.memo_finish_OK_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.memo_finish_OK_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.memo_finish_OK_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.memo_finish_OK_btn.Location = new System.Drawing.Point(952, 664);
            this.memo_finish_OK_btn.Margin = new System.Windows.Forms.Padding(2);
            this.memo_finish_OK_btn.Name = "memo_finish_OK_btn";
            this.memo_finish_OK_btn.Size = new System.Drawing.Size(189, 54);
            this.memo_finish_OK_btn.TabIndex = 73;
            this.memo_finish_OK_btn.Text = "標示完成";
            this.memo_finish_OK_btn.UseVisualStyleBackColor = false;
            this.memo_finish_OK_btn.Click += new System.EventHandler(this.memo_finish_OK_btn_Click);
            // 
            // new_btn
            // 
            this.new_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.new_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.new_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.new_btn.Location = new System.Drawing.Point(662, 664);
            this.new_btn.Margin = new System.Windows.Forms.Padding(2);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(138, 54);
            this.new_btn.TabIndex = 72;
            this.new_btn.Text = "新增";
            this.new_btn.UseVisualStyleBackColor = false;
            this.new_btn.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // customer_id_textBox
            // 
            this.customer_id_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_id_textBox.Location = new System.Drawing.Point(741, 62);
            this.customer_id_textBox.Name = "customer_id_textBox";
            this.customer_id_textBox.Size = new System.Drawing.Size(162, 45);
            this.customer_id_textBox.TabIndex = 0;
            this.customer_id_textBox.TextChanged += new System.EventHandler(this.customer_id_textBox_TextChanged);
            // 
            // memo_listview
            // 
            this.memo_listview.BackColor = System.Drawing.Color.Silver;
            this.memo_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.memo_listview.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.memo_listview.FullRowSelect = true;
            this.memo_listview.GridLines = true;
            this.memo_listview.HideSelection = false;
            this.memo_listview.Location = new System.Drawing.Point(51, 62);
            this.memo_listview.Margin = new System.Windows.Forms.Padding(0);
            this.memo_listview.Name = "memo_listview";
            this.memo_listview.Size = new System.Drawing.Size(566, 656);
            this.memo_listview.TabIndex = 70;
            this.memo_listview.UseCompatibleStateImageBehavior = false;
            this.memo_listview.View = System.Windows.Forms.View.Details;
            this.memo_listview.DoubleClick += new System.EventHandler(this.memo_listview_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "編號";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "日期";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "內容";
            this.columnHeader3.Width = 330;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "完成";
            // 
            // memo_content_textBox
            // 
            this.memo_content_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.memo_content_textBox.Location = new System.Drawing.Point(662, 136);
            this.memo_content_textBox.Multiline = true;
            this.memo_content_textBox.Name = "memo_content_textBox";
            this.memo_content_textBox.Size = new System.Drawing.Size(602, 500);
            this.memo_content_textBox.TabIndex = 1;
            // 
            // CustomerMemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1656, 1072);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerMemoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客戶備忘錄";
            this.Resize += new System.EventHandler(this.CustomerMemoForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Button remove_btn;
        private System.Windows.Forms.Button memo_finish_OK_btn;
        private System.Windows.Forms.Button new_btn;
        private System.Windows.Forms.TextBox customer_id_textBox;
        private System.Windows.Forms.ListView memo_listview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox memo_content_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customer_name_textBox;
        private System.Windows.Forms.Label label8;
    }
}