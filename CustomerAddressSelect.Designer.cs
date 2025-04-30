namespace 超好企業系統
{
    partial class CustomerAddressSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerAddressSelect));
            this.customer_address_listview = new 超好企業系統.DoubleBufferListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // customer_address_listview
            // 
            this.customer_address_listview.BackColor = System.Drawing.Color.SeaShell;
            this.customer_address_listview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6});
            this.customer_address_listview.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.customer_address_listview.ForeColor = System.Drawing.SystemColors.WindowText;
            this.customer_address_listview.FullRowSelect = true;
            this.customer_address_listview.GridLines = true;
            this.customer_address_listview.HideSelection = false;
            this.customer_address_listview.Location = new System.Drawing.Point(0, 0);
            this.customer_address_listview.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.customer_address_listview.Name = "customer_address_listview";
            this.customer_address_listview.Size = new System.Drawing.Size(404, 272);
            this.customer_address_listview.TabIndex = 57;
            this.customer_address_listview.UseCompatibleStateImageBehavior = false;
            this.customer_address_listview.View = System.Windows.Forms.View.Details;
            this.customer_address_listview.DoubleClick += new System.EventHandler(this.customer_address_listview_DoubleClick);
            this.customer_address_listview.KeyDown += new System.Windows.Forms.KeyEventHandler(this.customer_address_listview_KeyDown);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "地址";
            this.columnHeader6.Width = 400;
            // 
            // CustomerAddressSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(999, 443);
            this.Controls.Add(this.customer_address_listview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerAddressSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "選擇地址";
            this.Resize += new System.EventHandler(this.CustomerAddressSelect_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferListView customer_address_listview;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}