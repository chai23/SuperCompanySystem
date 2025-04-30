namespace 超好企業系統
{
    partial class OrderAssignAreaSelecterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderAssignAreaSelecterForm));
            this.area_checkedListBox = new System.Windows.Forms.CheckedListBox();
            this.OK_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // area_checkedListBox
            // 
            this.area_checkedListBox.CheckOnClick = true;
            this.area_checkedListBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.area_checkedListBox.FormattingEnabled = true;
            this.area_checkedListBox.Location = new System.Drawing.Point(9, 97);
            this.area_checkedListBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.area_checkedListBox.Name = "area_checkedListBox";
            this.area_checkedListBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.area_checkedListBox.Size = new System.Drawing.Size(304, 409);
            this.area_checkedListBox.TabIndex = 0;
            // 
            // OK_btn
            // 
            this.OK_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OK_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.OK_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OK_btn.Location = new System.Drawing.Point(56, 33);
            this.OK_btn.Margin = new System.Windows.Forms.Padding(1);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(87, 49);
            this.OK_btn.TabIndex = 64;
            this.OK_btn.Text = "確認";
            this.OK_btn.UseVisualStyleBackColor = false;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cancel_btn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancel_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cancel_btn.Location = new System.Drawing.Point(173, 33);
            this.cancel_btn.Margin = new System.Windows.Forms.Padding(1);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(87, 49);
            this.cancel_btn.TabIndex = 65;
            this.cancel_btn.Text = "離開";
            this.cancel_btn.UseVisualStyleBackColor = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cancel_btn);
            this.groupBox1.Controls.Add(this.OK_btn);
            this.groupBox1.Controls.Add(this.area_checkedListBox);
            this.groupBox1.Location = new System.Drawing.Point(-1, -1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.groupBox1.Size = new System.Drawing.Size(323, 532);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // OrderAssignAreaSelecterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(803, 592);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "OrderAssignAreaSelecterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "送貨區域多選";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox area_checkedListBox;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}