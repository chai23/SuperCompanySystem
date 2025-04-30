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
    public partial class RecyeleQuantityForm : Form
    {
        public RecyeleQuantityForm(string customer_id, string customer_bill_form, string collect_money, string customer_bucket)
        {
            InitializeComponent();
            this.customer_id = customer_id;
            this.customer_bill_form = customer_bill_form;
            this.collect_money = collect_money;
            this.customer_bucket = customer_bucket;
        }

        private string customer_id;
        private string customer_bill_form;
        private string collect_money;
        private string customer_bucket;
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
        private string newOrderID(string order_day)
        {
            string selectQuery = "SELECT order_id FROM `order` " +
                $"WHERE order_id_day = '{order_day}' " +
                "ORDER BY order_id DESC LIMIT 0 , 1";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count == 0)
            {
                return order_day.Replace("-", "") + "0001";
            }
            var order_id = datatable.Rows[0][0].ToString();
            if (order_id.Substring(0, 8) == order_day.Replace("-", ""))
            {
                return (long.Parse(order_id) + 1).ToString();
            }
            else
            {
                return order_day.Replace("-", "") + "0001";
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(recyele_quantity_textBox.Text))
            {
                MessageBox.Show("請輸入數量", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string recyele_quantity = recyele_quantity_textBox.Text;
            string order_day = dateTimePicker.Value.ToString("yyyy-MM-dd");
            string order_id = newOrderID(order_day);
            string new_bucket = (int.Parse(customer_bucket) - int.Parse(recyele_quantity)).ToString();

            string insertQuery =
                "INSERT INTO `order` VALUES " +
                $"('{order_id}'," +
                $"'{order_day}'," +
                $"'1'," +
                $"'300'," +
                $"'收空桶'," +
                $"'0'," +
                $"'{recyele_quantity}'," +
                $"'False', " +
                $"'False', " +
                $"'0', " +
                $"'0'," +
                $"''," +
                $"'{customer_id}'," +
                $"'{customer_bill_form}'," +
                $"'000'," +
                $"'True'," +
                $"'{recyele_quantity}'," +
                $"'{collect_money}'," +
                $"'True'," +
                $"'True'," +
                $"'True'," +
                $"''," +
                $"'{order_day}'," +
                $"'{MainForm.Maker}')";

            ConnectDatabase("新增", insertQuery).ToString();

            string insertQuery1 =
                        "INSERT INTO `report_day` VALUES " +
                        $"('{order_id}', " +//order_id
                        $"'{order_day}', " +//order_day
                        $"'自載', " +//driver_id
                        $"'收空桶', " +//product_name
                        $"'0', " +//product_price
                        $"'{recyele_quantity}', " +//product_quantity
                        $"'0', " +//subtotal
                        $"'{"True"}', " +//collect_OK
                        $"'{collect_money}', " +//remark
                        $"'{customer_id}', " +//customer_id
                        $"'{recyele_quantity}', " +//recyele_quantity
                        $"'{collect_money}', " +//collect_money
                        $"'1', " +//product_index
                        $"'上午')";//morningorafternoon

            ConnectDatabase("新增", insertQuery1).ToString();

            string reviseQuery1 =
                "UPDATE `customer` SET " +
                $"customer_bucket = '{new_bucket}' " +
                $"WHERE customer_id = '{customer_id}'";

            ConnectDatabase("修改", reviseQuery1);

            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
