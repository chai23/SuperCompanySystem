namespace 超好企業系統
{
    partial class ReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            this.not_collect_money_btn = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.report_day_btn = new System.Windows.Forms.Button();
            this.report_month_btn = new System.Windows.Forms.Button();
            this.prepaid_report_btn = new System.Windows.Forms.Button();
            this.report_detil_day_btn = new System.Windows.Forms.Button();
            this.driver_comboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.driver_quantity_month_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // not_collect_money_btn
            // 
            this.not_collect_money_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.not_collect_money_btn.Location = new System.Drawing.Point(701, 29);
            this.not_collect_money_btn.Name = "not_collect_money_btn";
            this.not_collect_money_btn.Size = new System.Drawing.Size(145, 44);
            this.not_collect_money_btn.TabIndex = 1;
            this.not_collect_money_btn.Text = "未收款項報表";
            this.not_collect_money_btn.UseVisualStyleBackColor = true;
            this.not_collect_money_btn.Click += new System.EventHandler(this.not_collect_money_btn_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 98;
            this.reportViewer1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "進銷存系統V2.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 150);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(880, 710);
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dateTimePicker.Location = new System.Drawing.Point(17, 35);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(166, 32);
            this.dateTimePicker.TabIndex = 3;
            // 
            // report_day_btn
            // 
            this.report_day_btn.Enabled = false;
            this.report_day_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.report_day_btn.Location = new System.Drawing.Point(197, 29);
            this.report_day_btn.Name = "report_day_btn";
            this.report_day_btn.Size = new System.Drawing.Size(162, 44);
            this.report_day_btn.TabIndex = 4;
            this.report_day_btn.Text = "每日結帳報表";
            this.report_day_btn.UseVisualStyleBackColor = true;
            this.report_day_btn.Click += new System.EventHandler(this.report_day_btn_Click);
            // 
            // report_month_btn
            // 
            this.report_month_btn.Enabled = false;
            this.report_month_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.report_month_btn.Location = new System.Drawing.Point(370, 29);
            this.report_month_btn.Name = "report_month_btn";
            this.report_month_btn.Size = new System.Drawing.Size(162, 44);
            this.report_month_btn.TabIndex = 5;
            this.report_month_btn.Text = "每月結帳報表";
            this.report_month_btn.UseVisualStyleBackColor = true;
            this.report_month_btn.Click += new System.EventHandler(this.report_month_btn_Click);
            // 
            // prepaid_report_btn
            // 
            this.prepaid_report_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.prepaid_report_btn.Location = new System.Drawing.Point(544, 29);
            this.prepaid_report_btn.Name = "prepaid_report_btn";
            this.prepaid_report_btn.Size = new System.Drawing.Size(145, 44);
            this.prepaid_report_btn.TabIndex = 6;
            this.prepaid_report_btn.Text = "預付統計報表";
            this.prepaid_report_btn.UseVisualStyleBackColor = true;
            this.prepaid_report_btn.Click += new System.EventHandler(this.prepaid_report_btn_Click);
            // 
            // report_detil_day_btn
            // 
            this.report_detil_day_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.report_detil_day_btn.Location = new System.Drawing.Point(197, 83);
            this.report_detil_day_btn.Name = "report_detil_day_btn";
            this.report_detil_day_btn.Size = new System.Drawing.Size(162, 44);
            this.report_detil_day_btn.TabIndex = 7;
            this.report_detil_day_btn.Text = "訂單銷單報表";
            this.report_detil_day_btn.UseVisualStyleBackColor = true;
            this.report_detil_day_btn.Click += new System.EventHandler(this.report_detil_day_btn_Click);
            // 
            // driver_comboBox
            // 
            this.driver_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.driver_comboBox.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.driver_comboBox.FormattingEnabled = true;
            this.driver_comboBox.Location = new System.Drawing.Point(67, 90);
            this.driver_comboBox.Name = "driver_comboBox";
            this.driver_comboBox.Size = new System.Drawing.Size(116, 32);
            this.driver_comboBox.TabIndex = 64;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(14, 93);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 24);
            this.label8.TabIndex = 63;
            this.label8.Text = "司機";
            // 
            // driver_quantity_month_btn
            // 
            this.driver_quantity_month_btn.Font = new System.Drawing.Font("微軟正黑體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.driver_quantity_month_btn.Location = new System.Drawing.Point(370, 83);
            this.driver_quantity_month_btn.Name = "driver_quantity_month_btn";
            this.driver_quantity_month_btn.Size = new System.Drawing.Size(162, 44);
            this.driver_quantity_month_btn.TabIndex = 65;
            this.driver_quantity_month_btn.Text = "桶數計算(月)";
            this.driver_quantity_month_btn.UseVisualStyleBackColor = true;
            this.driver_quantity_month_btn.Click += new System.EventHandler(this.driver_quantity_month_btn_Click);
            // 
            // ReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(860, 817);
            this.Controls.Add(this.driver_quantity_month_btn);
            this.Controls.Add(this.driver_comboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.report_detil_day_btn);
            this.Controls.Add(this.prepaid_report_btn);
            this.Controls.Add(this.report_month_btn);
            this.Controls.Add(this.report_day_btn);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.not_collect_money_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "統計報表";
            this.Load += new System.EventHandler(this.ReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button not_collect_money_btn;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button report_day_btn;
        private System.Windows.Forms.Button report_month_btn;
        private System.Windows.Forms.Button prepaid_report_btn;
        private System.Windows.Forms.Button report_detil_day_btn;
        private System.Windows.Forms.ComboBox driver_comboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button driver_quantity_month_btn;
    }
}