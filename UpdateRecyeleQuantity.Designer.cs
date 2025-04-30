namespace 超好企業系統
{
    partial class UpdateRecyeleQuantity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateRecyeleQuantity));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.old_quantity_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.new_quantity_textBox = new System.Windows.Forms.TextBox();
            this.colse_btn = new System.Windows.Forms.Button();
            this.OK_btn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colse_btn);
            this.groupBox1.Controls.Add(this.OK_btn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.new_quantity_textBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.old_quantity_textbox);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 512);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(174, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 37);
            this.label6.TabIndex = 99;
            this.label6.Text = "原本回收數量";
            // 
            // old_quantity_textbox
            // 
            this.old_quantity_textbox.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.old_quantity_textbox.Location = new System.Drawing.Point(371, 139);
            this.old_quantity_textbox.Name = "old_quantity_textbox";
            this.old_quantity_textbox.Size = new System.Drawing.Size(198, 45);
            this.old_quantity_textbox.TabIndex = 98;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(174, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 37);
            this.label1.TabIndex = 101;
            this.label1.Text = "修改回收數量";
            // 
            // new_quantity_textBox
            // 
            this.new_quantity_textBox.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.new_quantity_textBox.Location = new System.Drawing.Point(371, 218);
            this.new_quantity_textBox.Name = "new_quantity_textBox";
            this.new_quantity_textBox.Size = new System.Drawing.Size(198, 45);
            this.new_quantity_textBox.TabIndex = 100;
            // 
            // colse_btn
            // 
            this.colse_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.colse_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.colse_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colse_btn.Location = new System.Drawing.Point(385, 345);
            this.colse_btn.Margin = new System.Windows.Forms.Padding(2);
            this.colse_btn.Name = "colse_btn";
            this.colse_btn.Size = new System.Drawing.Size(110, 70);
            this.colse_btn.TabIndex = 103;
            this.colse_btn.Text = "取消";
            this.colse_btn.UseVisualStyleBackColor = false;
            this.colse_btn.Click += new System.EventHandler(this.colse_btn_Click);
            // 
            // OK_btn
            // 
            this.OK_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OK_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OK_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OK_btn.Location = new System.Drawing.Point(255, 345);
            this.OK_btn.Margin = new System.Windows.Forms.Padding(2);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(110, 70);
            this.OK_btn.TabIndex = 102;
            this.OK_btn.Text = "確認";
            this.OK_btn.UseVisualStyleBackColor = false;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // UpdateRecyeleQuantity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1168, 940);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateRecyeleQuantity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改回收空桶數量";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox new_quantity_textBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox old_quantity_textbox;
        private System.Windows.Forms.Button colse_btn;
        private System.Windows.Forms.Button OK_btn;
    }
}