namespace 超好企業系統
{
    partial class AnnouncementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnnouncementForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.close_btn = new System.Windows.Forms.Button();
            this.remove_btn = new System.Windows.Forms.Button();
            this.OK_btn = new System.Windows.Forms.Button();
            this.new_btn = new System.Windows.Forms.Button();
            this.title_textBox = new System.Windows.Forms.TextBox();
            this.announcement_listview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.content_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.close_btn);
            this.groupBox1.Controls.Add(this.remove_btn);
            this.groupBox1.Controls.Add(this.OK_btn);
            this.groupBox1.Controls.Add(this.new_btn);
            this.groupBox1.Controls.Add(this.title_textBox);
            this.groupBox1.Controls.Add(this.announcement_listview);
            this.groupBox1.Controls.Add(this.content_textBox);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1336, 776);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
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
            this.remove_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.Size = new System.Drawing.Size(138, 54);
            this.remove_btn.TabIndex = 74;
            this.remove_btn.Text = "移除";
            this.remove_btn.UseVisualStyleBackColor = false;
            this.remove_btn.Click += new System.EventHandler(this.remove_btn_Click);
            // 
            // OK_btn
            // 
            this.OK_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OK_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OK_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OK_btn.Location = new System.Drawing.Point(952, 664);
            this.OK_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(189, 54);
            this.OK_btn.TabIndex = 73;
            this.OK_btn.Text = "使用此公告";
            this.OK_btn.UseVisualStyleBackColor = false;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // new_btn
            // 
            this.new_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.new_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.new_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.new_btn.Location = new System.Drawing.Point(662, 664);
            this.new_btn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(138, 54);
            this.new_btn.TabIndex = 72;
            this.new_btn.Text = "新增";
            this.new_btn.UseVisualStyleBackColor = false;
            this.new_btn.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // title_textBox
            // 
            this.title_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.title_textBox.Location = new System.Drawing.Point(662, 62);
            this.title_textBox.Name = "title_textBox";
            this.title_textBox.Size = new System.Drawing.Size(602, 45);
            this.title_textBox.TabIndex = 0;
            // 
            // announcement_listview
            // 
            this.announcement_listview.BackColor = System.Drawing.Color.Silver;
            this.announcement_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.announcement_listview.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.announcement_listview.FullRowSelect = true;
            this.announcement_listview.GridLines = true;
            this.announcement_listview.HideSelection = false;
            this.announcement_listview.Location = new System.Drawing.Point(51, 62);
            this.announcement_listview.Margin = new System.Windows.Forms.Padding(0);
            this.announcement_listview.Name = "announcement_listview";
            this.announcement_listview.Size = new System.Drawing.Size(566, 656);
            this.announcement_listview.TabIndex = 70;
            this.announcement_listview.UseCompatibleStateImageBehavior = false;
            this.announcement_listview.View = System.Windows.Forms.View.Details;
            this.announcement_listview.Click += new System.EventHandler(this.announcement_listview_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "編號";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "日期";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "標題";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "使用";
            // 
            // content_textBox
            // 
            this.content_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.content_textBox.Location = new System.Drawing.Point(662, 136);
            this.content_textBox.Multiline = true;
            this.content_textBox.Name = "content_textBox";
            this.content_textBox.Size = new System.Drawing.Size(602, 500);
            this.content_textBox.TabIndex = 1;
            // 
            // AnnouncementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1546, 914);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnnouncementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公告設定";
            this.Resize += new System.EventHandler(this.AnnouncementForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox content_textBox;
        private System.Windows.Forms.TextBox title_textBox;
        private System.Windows.Forms.ListView announcement_listview;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.Button new_btn;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button remove_btn;
        private System.Windows.Forms.Button close_btn;
    }
}