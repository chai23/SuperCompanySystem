namespace 超好企業系統
{
    partial class PermissionsSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PermissionsSettingForm));
            this.personnel_listview = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.close_btn = new System.Windows.Forms.Button();
            this.remove_btn = new System.Windows.Forms.Button();
            this.OK_btn = new System.Windows.Forms.Button();
            this.new_btn = new System.Windows.Forms.Button();
            this.level_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.account_number_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // personnel_listview
            // 
            this.personnel_listview.BackColor = System.Drawing.Color.Silver;
            this.personnel_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.personnel_listview.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.personnel_listview.FullRowSelect = true;
            this.personnel_listview.GridLines = true;
            this.personnel_listview.HideSelection = false;
            this.personnel_listview.Location = new System.Drawing.Point(25, 32);
            this.personnel_listview.Margin = new System.Windows.Forms.Padding(0);
            this.personnel_listview.Name = "personnel_listview";
            this.personnel_listview.Size = new System.Drawing.Size(445, 439);
            this.personnel_listview.TabIndex = 71;
            this.personnel_listview.UseCompatibleStateImageBehavior = false;
            this.personnel_listview.View = System.Windows.Forms.View.Details;
            this.personnel_listview.DoubleClick += new System.EventHandler(this.personnel_listview_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "編號";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名稱";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "帳號";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "密碼";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "權限";
            this.columnHeader5.Width = 80;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.close_btn);
            this.groupBox1.Controls.Add(this.remove_btn);
            this.groupBox1.Controls.Add(this.OK_btn);
            this.groupBox1.Controls.Add(this.new_btn);
            this.groupBox1.Controls.Add(this.level_comboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.password_textBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.account_number_textBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.name_textBox);
            this.groupBox1.Controls.Add(this.personnel_listview);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(892, 500);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.close_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.close_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.close_btn.Location = new System.Drawing.Point(781, 425);
            this.close_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(77, 36);
            this.close_btn.TabIndex = 85;
            this.close_btn.Text = "離開";
            this.close_btn.UseVisualStyleBackColor = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // remove_btn
            // 
            this.remove_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.remove_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.remove_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.remove_btn.Location = new System.Drawing.Point(591, 425);
            this.remove_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.remove_btn.Name = "remove_btn";
            this.remove_btn.Size = new System.Drawing.Size(92, 36);
            this.remove_btn.TabIndex = 84;
            this.remove_btn.Text = "移除";
            this.remove_btn.UseVisualStyleBackColor = false;
            this.remove_btn.Click += new System.EventHandler(this.remove_btn_Click);
            // 
            // OK_btn
            // 
            this.OK_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OK_btn.Enabled = false;
            this.OK_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OK_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OK_btn.Location = new System.Drawing.Point(686, 425);
            this.OK_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(92, 36);
            this.OK_btn.TabIndex = 83;
            this.OK_btn.Text = "儲存";
            this.OK_btn.UseVisualStyleBackColor = false;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // new_btn
            // 
            this.new_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.new_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.new_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.new_btn.Location = new System.Drawing.Point(497, 425);
            this.new_btn.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(92, 36);
            this.new_btn.TabIndex = 82;
            this.new_btn.Text = "新增";
            this.new_btn.UseVisualStyleBackColor = false;
            this.new_btn.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // level_comboBox
            // 
            this.level_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.level_comboBox.Enabled = false;
            this.level_comboBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.level_comboBox.FormattingEnabled = true;
            this.level_comboBox.Items.AddRange(new object[] {
            "老闆",
            "員工",
            "新人"});
            this.level_comboBox.Location = new System.Drawing.Point(630, 264);
            this.level_comboBox.Name = "level_comboBox";
            this.level_comboBox.Size = new System.Drawing.Size(139, 32);
            this.level_comboBox.TabIndex = 81;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(579, 267);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 24);
            this.label4.TabIndex = 80;
            this.label4.Text = "權限";
            // 
            // password_textBox
            // 
            this.password_textBox.Enabled = false;
            this.password_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.password_textBox.Location = new System.Drawing.Point(630, 217);
            this.password_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(139, 32);
            this.password_textBox.TabIndex = 79;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(579, 219);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 24);
            this.label3.TabIndex = 78;
            this.label3.Text = "密碼";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(579, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 24);
            this.label2.TabIndex = 76;
            this.label2.Text = "帳號";
            // 
            // account_number_textBox
            // 
            this.account_number_textBox.Enabled = false;
            this.account_number_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.account_number_textBox.Location = new System.Drawing.Point(630, 169);
            this.account_number_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.account_number_textBox.Name = "account_number_textBox";
            this.account_number_textBox.Size = new System.Drawing.Size(139, 32);
            this.account_number_textBox.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(579, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 24);
            this.label1.TabIndex = 74;
            this.label1.Text = "名稱";
            // 
            // name_textBox
            // 
            this.name_textBox.Enabled = false;
            this.name_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.name_textBox.Location = new System.Drawing.Point(630, 119);
            this.name_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(139, 32);
            this.name_textBox.TabIndex = 73;
            // 
            // PermissionsSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1114, 535);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PermissionsSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "權限設置";
            this.Resize += new System.EventHandler(this.PermissionsSettingForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView personnel_listview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox name_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox account_number_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.ComboBox level_comboBox;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Button remove_btn;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.Button new_btn;
    }
}