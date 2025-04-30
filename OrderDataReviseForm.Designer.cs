namespace 超好企業系統
{
    partial class OrderDataReviseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDataReviseForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.order_save_btn = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.bill_number_textBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.total_textBox = new System.Windows.Forms.TextBox();
            this.tex_textBox = new System.Windows.Forms.TextBox();
            this.order_dataGridView = new System.Windows.Forms.DataGridView();
            this.product_index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.peoduct_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.product_quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.give_free = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.give_nofree = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.collect_money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_bill_form = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliver_day_label = new System.Windows.Forms.Label();
            this.deliver_day_dtp = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.order_id_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customer_address_textbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.customer_telephone_textbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.customer_name_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.customer_invoice_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.customer_id_textBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.order_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancel_btn);
            this.groupBox1.Controls.Add(this.order_save_btn);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.bill_number_textBox);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.total_textBox);
            this.groupBox1.Controls.Add(this.tex_textBox);
            this.groupBox1.Controls.Add(this.order_dataGridView);
            this.groupBox1.Controls.Add(this.deliver_day_label);
            this.groupBox1.Controls.Add(this.deliver_day_dtp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.order_id_textbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.customer_address_textbox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.customer_telephone_textbox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.customer_name_textbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.customer_invoice_textbox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.customer_id_textBox);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(1161, 515);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancel_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cancel_btn.Location = new System.Drawing.Point(1067, 441);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(77, 55);
            this.cancel_btn.TabIndex = 80;
            this.cancel_btn.Text = "取消";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // order_save_btn
            // 
            this.order_save_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.order_save_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.order_save_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order_save_btn.Location = new System.Drawing.Point(969, 441);
            this.order_save_btn.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.order_save_btn.Name = "order_save_btn";
            this.order_save_btn.Size = new System.Drawing.Size(77, 55);
            this.order_save_btn.TabIndex = 79;
            this.order_save_btn.Text = "確認";
            this.order_save_btn.UseVisualStyleBackColor = false;
            this.order_save_btn.Click += new System.EventHandler(this.order_save_btn_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.Location = new System.Drawing.Point(513, 389);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(86, 24);
            this.label19.TabIndex = 78;
            this.label19.Text = "發票號碼";
            // 
            // bill_number_textBox
            // 
            this.bill_number_textBox.Enabled = false;
            this.bill_number_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bill_number_textBox.Location = new System.Drawing.Point(604, 384);
            this.bill_number_textBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.bill_number_textBox.Name = "bill_number_textBox";
            this.bill_number_textBox.Size = new System.Drawing.Size(181, 32);
            this.bill_number_textBox.TabIndex = 77;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(788, 389);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(48, 24);
            this.label15.TabIndex = 76;
            this.label15.Text = "稅額";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.Location = new System.Drawing.Point(919, 389);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 24);
            this.label14.TabIndex = 75;
            this.label14.Text = "總金額";
            // 
            // total_textBox
            // 
            this.total_textBox.Enabled = false;
            this.total_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.total_textBox.Location = new System.Drawing.Point(989, 384);
            this.total_textBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.total_textBox.Name = "total_textBox";
            this.total_textBox.Size = new System.Drawing.Size(161, 32);
            this.total_textBox.TabIndex = 74;
            // 
            // tex_textBox
            // 
            this.tex_textBox.Enabled = false;
            this.tex_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tex_textBox.Location = new System.Drawing.Point(837, 384);
            this.tex_textBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.tex_textBox.Name = "tex_textBox";
            this.tex_textBox.Size = new System.Drawing.Size(77, 32);
            this.tex_textBox.TabIndex = 73;
            // 
            // order_dataGridView
            // 
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
            this.product_index,
            this.product_name,
            this.product_unit,
            this.peoduct_quantity,
            this.product_quantity,
            this.give_free,
            this.give_nofree,
            this.collect_money,
            this.customer_bill_form,
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
            this.order_dataGridView.Location = new System.Drawing.Point(0, 176);
            this.order_dataGridView.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
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
            this.order_dataGridView.Size = new System.Drawing.Size(1161, 185);
            this.order_dataGridView.TabIndex = 72;
            this.order_dataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.order_dataGridView_CellValueChanged);
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
            this.peoduct_quantity.Width = 70;
            // 
            // product_quantity
            // 
            this.product_quantity.HeaderText = "數量";
            this.product_quantity.MinimumWidth = 8;
            this.product_quantity.Name = "product_quantity";
            this.product_quantity.Width = 70;
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
            // collect_money
            // 
            this.collect_money.HeaderText = "扣單別";
            this.collect_money.MinimumWidth = 8;
            this.collect_money.Name = "collect_money";
            this.collect_money.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // customer_bill_form
            // 
            this.customer_bill_form.HeaderText = "發票";
            this.customer_bill_form.Items.AddRange(new object[] {
            "不開",
            "三聯未稅",
            "二聯含稅",
            "三聯含稅"});
            this.customer_bill_form.Name = "customer_bill_form";
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
            // deliver_day_label
            // 
            this.deliver_day_label.AutoSize = true;
            this.deliver_day_label.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.deliver_day_label.Location = new System.Drawing.Point(880, 122);
            this.deliver_day_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.deliver_day_label.Name = "deliver_day_label";
            this.deliver_day_label.Size = new System.Drawing.Size(86, 24);
            this.deliver_day_label.TabIndex = 71;
            this.deliver_day_label.Text = "送貨日期";
            // 
            // deliver_day_dtp
            // 
            this.deliver_day_dtp.Enabled = false;
            this.deliver_day_dtp.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.deliver_day_dtp.Location = new System.Drawing.Point(969, 119);
            this.deliver_day_dtp.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.deliver_day_dtp.Name = "deliver_day_dtp";
            this.deliver_day_dtp.Size = new System.Drawing.Size(181, 32);
            this.deliver_day_dtp.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(585, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 24);
            this.label2.TabIndex = 38;
            this.label2.Text = "貨號";
            // 
            // order_id_textbox
            // 
            this.order_id_textbox.Enabled = false;
            this.order_id_textbox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order_id_textbox.Location = new System.Drawing.Point(637, 119);
            this.order_id_textbox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.order_id_textbox.Name = "order_id_textbox";
            this.order_id_textbox.Size = new System.Drawing.Size(194, 32);
            this.order_id_textbox.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(21, 123);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 36;
            this.label1.Text = "客戶地址";
            // 
            // customer_address_textbox
            // 
            this.customer_address_textbox.Enabled = false;
            this.customer_address_textbox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_address_textbox.Location = new System.Drawing.Point(110, 120);
            this.customer_address_textbox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.customer_address_textbox.Name = "customer_address_textbox";
            this.customer_address_textbox.Size = new System.Drawing.Size(373, 32);
            this.customer_address_textbox.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(585, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 24);
            this.label5.TabIndex = 34;
            this.label5.Text = "電話";
            // 
            // customer_telephone_textbox
            // 
            this.customer_telephone_textbox.Enabled = false;
            this.customer_telephone_textbox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_telephone_textbox.Location = new System.Drawing.Point(637, 78);
            this.customer_telephone_textbox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.customer_telephone_textbox.Name = "customer_telephone_textbox";
            this.customer_telephone_textbox.Size = new System.Drawing.Size(194, 32);
            this.customer_telephone_textbox.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(21, 81);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 24);
            this.label6.TabIndex = 32;
            this.label6.Text = "客戶名稱";
            // 
            // customer_name_textbox
            // 
            this.customer_name_textbox.Enabled = false;
            this.customer_name_textbox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_name_textbox.Location = new System.Drawing.Point(110, 78);
            this.customer_name_textbox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.customer_name_textbox.Name = "customer_name_textbox";
            this.customer_name_textbox.Size = new System.Drawing.Size(215, 32);
            this.customer_name_textbox.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(547, 35);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 24);
            this.label4.TabIndex = 30;
            this.label4.Text = "統一編號";
            // 
            // customer_invoice_textbox
            // 
            this.customer_invoice_textbox.Enabled = false;
            this.customer_invoice_textbox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_invoice_textbox.Location = new System.Drawing.Point(637, 33);
            this.customer_invoice_textbox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.customer_invoice_textbox.Name = "customer_invoice_textbox";
            this.customer_invoice_textbox.Size = new System.Drawing.Size(194, 32);
            this.customer_invoice_textbox.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(21, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 24);
            this.label3.TabIndex = 28;
            this.label3.Text = "客戶編號";
            // 
            // customer_id_textBox
            // 
            this.customer_id_textBox.Enabled = false;
            this.customer_id_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_id_textBox.Location = new System.Drawing.Point(110, 33);
            this.customer_id_textBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.customer_id_textBox.Name = "customer_id_textBox";
            this.customer_id_textBox.Size = new System.Drawing.Size(215, 32);
            this.customer_id_textBox.TabIndex = 27;
            // 
            // OrderDataReviseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1183, 626);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "OrderDataReviseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "訂單資料修改";
            this.Resize += new System.EventHandler(this.OrderDataReviseForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.order_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox customer_telephone_textbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox customer_name_textbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox customer_invoice_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customer_id_textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox order_id_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox customer_address_textbox;
        private System.Windows.Forms.Label deliver_day_label;
        private System.Windows.Forms.DateTimePicker deliver_day_dtp;
        private System.Windows.Forms.DataGridView order_dataGridView;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox bill_number_textBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox total_textBox;
        private System.Windows.Forms.TextBox tex_textBox;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button order_save_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_index;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn peoduct_quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_quantity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn give_free;
        private System.Windows.Forms.DataGridViewCheckBoxColumn give_nofree;
        private System.Windows.Forms.DataGridViewTextBoxColumn collect_money;
        private System.Windows.Forms.DataGridViewComboBoxColumn customer_bill_form;
        private System.Windows.Forms.DataGridViewTextBoxColumn tex;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
    }
}