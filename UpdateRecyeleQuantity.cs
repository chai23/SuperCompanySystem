using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 超好企業系統
{
    public partial class UpdateRecyeleQuantity : Form
    {
        public UpdateRecyeleQuantity()
        {
            InitializeComponent();
        }
        public UpdateRecyeleQuantity(string old_quantity, string customer_id, string order_id, string bucket)
        {
            InitializeComponent();
            this.Old_quantity = old_quantity;
            this.Customer_id = customer_id;
            this.Order_id = order_id;
            this.Bucket = bucket;
            old_quantity_textbox.Text = old_quantity;

        }
        private string Old_quantity { get; set; }
        private string Customer_id { get; set; }
        private string Order_id { get; set; }
        private string Bucket { get; set; }

        private object ConnectDatabase(string mether, string query)
        {
            // 設定你的MySQL連接字串
            //string connectionString = "Server=125.228.16.160;Database=database;User ID=user;Password=chaaii23;";
            // 建立MySqlDatabase物件
            MySqlHelper mySqlDb = new MySqlHelper();

            switch (mether)
            {
                case "新增":
                    string rowsInserted = mySqlDb.InsertData(query);
                    return rowsInserted;
                case "查詢":
                    DataTable resultTable = mySqlDb.ReadData(query);
                    return resultTable;
                case "修改":
                    string rowsRevised = mySqlDb.ReviseData(query);
                    return rowsRevised;
                case "刪除":
                    string rowsRemoved = mySqlDb.RemoveData(query);
                    return rowsRemoved;
            }
            return null;
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            int old_quantity = int.Parse(Old_quantity);
            int new_quantity = int.Parse(new_quantity_textBox.Text);
            int num = old_quantity - new_quantity;
            string bucket = (int.Parse(Bucket) + num).ToString();

            string reviseQuery =
                "UPDATE `order` SET " +
                $"recyele_quantity = '{new_quantity.ToString()}' " +
                $"WHERE order_id = '{Order_id}'";
            ConnectDatabase("修改", reviseQuery);

            string reviseQuery1 =
                "UPDATE `customer` SET " +
                $"customer_bucket = '{bucket}' " +
                $"WHERE customer_id = '{Customer_id}'";
            ConnectDatabase("修改", reviseQuery1);

            string reviseQuery2 =
                "UPDATE `report_day` SET " +
                $"recyele_quantity = '{new_quantity.ToString()}' " +
                $"WHERE order_id = '{Order_id}'";
            ConnectDatabase("修改", reviseQuery2);

            this.Close();

        }

        private void colse_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
