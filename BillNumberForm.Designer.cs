namespace 超好企業系統
{
    partial class BillNumberForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillNumberForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.order_save_btn = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.bill_number_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.money_textbox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.money_textbox);
            this.groupBox1.Controls.Add(this.cancel_btn);
            this.groupBox1.Controls.Add(this.order_save_btn);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.bill_number_textBox);
            this.groupBox1.Location = new System.Drawing.Point(66, 59);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 483);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancel_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cancel_btn.Location = new System.Drawing.Point(293, 342);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(116, 73);
            this.cancel_btn.TabIndex = 76;
            this.cancel_btn.Text = "取消";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // order_save_btn
            // 
            this.order_save_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.order_save_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.order_save_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.order_save_btn.Location = new System.Drawing.Point(145, 342);
            this.order_save_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.order_save_btn.Name = "order_save_btn";
            this.order_save_btn.Size = new System.Drawing.Size(116, 73);
            this.order_save_btn.TabIndex = 75;
            this.order_save_btn.Text = "確認";
            this.order_save_btn.UseVisualStyleBackColor = false;
            this.order_save_btn.Click += new System.EventHandler(this.order_save_btn_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label19.Location = new System.Drawing.Point(213, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(127, 36);
            this.label19.TabIndex = 74;
            this.label19.Text = "發票號碼";
            // 
            // bill_number_textBox
            // 
            this.bill_number_textBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.bill_number_textBox.Location = new System.Drawing.Point(100, 122);
            this.bill_number_textBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bill_number_textBox.Name = "bill_number_textBox";
            this.bill_number_textBox.Size = new System.Drawing.Size(360, 45);
            this.bill_number_textBox.TabIndex = 73;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(213, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 36);
            this.label1.TabIndex = 78;
            this.label1.Text = "稅金折讓";
            // 
            // money_textbox
            // 
            this.money_textbox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.money_textbox.Location = new System.Drawing.Point(168, 258);
            this.money_textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.money_textbox.Name = "money_textbox";
            this.money_textbox.Size = new System.Drawing.Size(217, 45);
            this.money_textbox.TabIndex = 77;
            // 
            // BillNumberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1196, 904);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BillNumberForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "請輸入發票號碼";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox bill_number_textBox;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.Button order_save_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox money_textbox;
    }
}