namespace 超好企業系統
{
    partial class OrderDataDetilForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDataDetilForm));
            this.cancel_btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.not_finish_money_textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.finish_money_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.order_id_textBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.customer_name_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.customer_id_textBox = new System.Windows.Forms.TextBox();
            this.order_dataGridView = new System.Windows.Forms.DataGridView();
            this.collect_OK_check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.product_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peoduct_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.collect_money = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bill_form = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.give_free = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.give_nofree = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.order_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancel_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cancel_btn.Location = new System.Drawing.Point(1599, 143);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(116, 74);
            this.cancel_btn.TabIndex = 106;
            this.cancel_btn.Text = "離開";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(477, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 36);
            this.label5.TabIndex = 105;
            this.label5.Text = "未收款金額";
            // 
            // not_finish_money_textBox
            // 
            this.not_finish_money_textBox.Enabled = false;
            this.not_finish_money_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.not_finish_money_textBox.Location = new System.Drawing.Point(638, 108);
            this.not_finish_money_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.not_finish_money_textBox.Name = "not_finish_money_textBox";
            this.not_finish_money_textBox.Size = new System.Drawing.Size(190, 45);
            this.not_finish_money_textBox.TabIndex = 104;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(477, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 36);
            this.label4.TabIndex = 103;
            this.label4.Text = "已收款金額";
            // 
            // finish_money_textbox
            // 
            this.finish_money_textbox.Enabled = false;
            this.finish_money_textbox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.finish_money_textbox.Location = new System.Drawing.Point(638, 37);
            this.finish_money_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.finish_money_textbox.Name = "finish_money_textbox";
            this.finish_money_textbox.Size = new System.Drawing.Size(190, 45);
            this.finish_money_textbox.TabIndex = 102;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(27, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 36);
            this.label1.TabIndex = 99;
            this.label1.Text = "訂單編號";
            // 
            // order_id_textBox
            // 
            this.order_id_textBox.Enabled = false;
            this.order_id_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order_id_textBox.Location = new System.Drawing.Point(163, 176);
            this.order_id_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.order_id_textBox.Name = "order_id_textBox";
            this.order_id_textBox.Size = new System.Drawing.Size(265, 45);
            this.order_id_textBox.TabIndex = 98;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(27, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 36);
            this.label6.TabIndex = 97;
            this.label6.Text = "客戶名稱";
            // 
            // customer_name_textbox
            // 
            this.customer_name_textbox.Enabled = false;
            this.customer_name_textbox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_name_textbox.Location = new System.Drawing.Point(163, 105);
            this.customer_name_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customer_name_textbox.Name = "customer_name_textbox";
            this.customer_name_textbox.Size = new System.Drawing.Size(265, 45);
            this.customer_name_textbox.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(27, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 36);
            this.label3.TabIndex = 95;
            this.label3.Text = "客戶編號";
            // 
            // customer_id_textBox
            // 
            this.customer_id_textBox.Enabled = false;
            this.customer_id_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_id_textBox.Location = new System.Drawing.Point(163, 37);
            this.customer_id_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customer_id_textBox.Name = "customer_id_textBox";
            this.customer_id_textBox.Size = new System.Drawing.Size(265, 45);
            this.customer_id_textBox.TabIndex = 94;
            // 
            // order_dataGridView
            // 
            this.order_dataGridView.AllowUserToAddRows = false;
            this.order_dataGridView.AllowUserToDeleteRows = false;
            this.order_dataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.order_dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.order_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.order_dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.collect_OK_check,
            this.product_index,
            this.product_name,
            this.product_unit,
            this.peoduct_quantity,
            this.product_quantity,
            this.collect_money,
            this.bill_form,
            this.give_free,
            this.give_nofree,
            this.tex,
            this.subtotal,
            this.remark});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.order_dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.order_dataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.order_dataGridView.Location = new System.Drawing.Point(0, 263);
            this.order_dataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.order_dataGridView.Name = "order_dataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.order_dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.order_dataGridView.RowHeadersWidth = 30;
            this.order_dataGridView.RowTemplate.Height = 31;
            this.order_dataGridView.Size = new System.Drawing.Size(1756, 326);
            this.order_dataGridView.TabIndex = 92;
            // 
            // collect_OK_check
            // 
            this.collect_OK_check.HeaderText = "收款";
            this.collect_OK_check.MinimumWidth = 8;
            this.collect_OK_check.Name = "collect_OK_check";
            this.collect_OK_check.ReadOnly = true;
            this.collect_OK_check.Width = 60;
            // 
            // product_index
            // 
            this.product_index.HeaderText = "序";
            this.product_index.MinimumWidth = 8;
            this.product_index.Name = "product_index";
            this.product_index.ReadOnly = true;
            this.product_index.Width = 30;
            // 
            // product_name
            // 
            this.product_name.HeaderText = "商品編號";
            this.product_name.MinimumWidth = 8;
            this.product_name.Name = "product_name";
            this.product_name.ReadOnly = true;
            this.product_name.Width = 125;
            // 
            // product_unit
            // 
            this.product_unit.HeaderText = "商品名稱";
            this.product_unit.MinimumWidth = 8;
            this.product_unit.Name = "product_unit";
            this.product_unit.ReadOnly = true;
            this.product_unit.Width = 200;
            // 
            // peoduct_quantity
            // 
            this.peoduct_quantity.HeaderText = "單價";
            this.peoduct_quantity.MinimumWidth = 8;
            this.peoduct_quantity.Name = "peoduct_quantity";
            this.peoduct_quantity.ReadOnly = true;
            this.peoduct_quantity.Width = 70;
            // 
            // product_quantity
            // 
            this.product_quantity.HeaderText = "數量";
            this.product_quantity.MinimumWidth = 8;
            this.product_quantity.Name = "product_quantity";
            this.product_quantity.ReadOnly = true;
            this.product_quantity.Width = 70;
            // 
            // collect_money
            // 
            this.collect_money.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.collect_money.HeaderText = "扣單別";
            this.collect_money.Items.AddRange(new object[] {
            "現金",
            "預收",
            "月結"});
            this.collect_money.MinimumWidth = 8;
            this.collect_money.Name = "collect_money";
            this.collect_money.ReadOnly = true;
            this.collect_money.Width = 80;
            // 
            // bill_form
            // 
            this.bill_form.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.bill_form.HeaderText = "發票";
            this.bill_form.Items.AddRange(new object[] {
            "不開",
            "三聯未稅",
            "二聯含稅",
            "三聯含稅"});
            this.bill_form.MinimumWidth = 8;
            this.bill_form.Name = "bill_form";
            this.bill_form.ReadOnly = true;
            this.bill_form.Width = 150;
            // 
            // give_free
            // 
            this.give_free.HeaderText = "補送";
            this.give_free.MinimumWidth = 8;
            this.give_free.Name = "give_free";
            this.give_free.ReadOnly = true;
            this.give_free.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.give_free.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.give_free.Width = 70;
            // 
            // give_nofree
            // 
            this.give_nofree.HeaderText = "抵扣";
            this.give_nofree.MinimumWidth = 8;
            this.give_nofree.Name = "give_nofree";
            this.give_nofree.ReadOnly = true;
            this.give_nofree.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.give_nofree.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.give_nofree.Width = 70;
            // 
            // tex
            // 
            this.tex.HeaderText = "稅額";
            this.tex.MinimumWidth = 8;
            this.tex.Name = "tex";
            this.tex.ReadOnly = true;
            this.tex.Width = 70;
            // 
            // subtotal
            // 
            this.subtotal.HeaderText = "小計";
            this.subtotal.MinimumWidth = 8;
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            this.subtotal.Width = 80;
            // 
            // remark
            // 
            this.remark.HeaderText = "備註";
            this.remark.MinimumWidth = 8;
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.Width = 350;
            // 
            // OrderDataDetilForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1949, 847);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.not_finish_money_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.finish_money_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.order_id_textBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.customer_name_textbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.customer_id_textBox);
            this.Controls.Add(this.order_dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderDataDetilForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "訂單銷單詳細狀態";
            this.Resize += new System.EventHandler(this.OrderDataDetilForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.order_dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox not_finish_money_textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox finish_money_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox order_id_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox customer_name_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customer_id_textBox;
        private System.Windows.Forms.DataGridView order_dataGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn collect_OK_check;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_index;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn peoduct_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_quantity;
        private System.Windows.Forms.DataGridViewComboBoxColumn collect_money;
        private System.Windows.Forms.DataGridViewComboBoxColumn bill_form;
        private System.Windows.Forms.DataGridViewCheckBoxColumn give_free;
        private System.Windows.Forms.DataGridViewCheckBoxColumn give_nofree;
        private System.Windows.Forms.DataGridViewTextBoxColumn tex;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
    }
}