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
    public partial class CollectMoneyHistoryForm : Form
    {
        public CollectMoneyHistoryForm()
        {
            InitializeComponent();
        }
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

        private void updateOrderListview()
        {
            if (customer_id_textBox.Text == "") { return; }
            if (DateTime.Compare(day1_dtp.Value, day2_dtp.Value) == 1 & day1_dtp.Value.ToString("yyyy-MM-dd") != day2_dtp.Value.ToString("yyyy-MM-dd")) { MessageBox.Show("日期範圍錯誤"); }
            string order_day_1 = day1_dtp.Value.ToString("yyyy-MM-dd");
            string order_day_2 = day2_dtp.Value.ToString("yyyy-MM-dd");
            string selectQuery = "SELECT order_id, collect_money, product_index, product_name, subtotal, collect_OK  FROM `order` " +
                $"WHERE customer_id = '{customer_id_textBox.Text}' and order_OK = 'True' and order_day >= '{order_day_1}' and order_day <= '{order_day_2}'" +
                "ORDER BY order_id DESC , product_index ASC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            string[,] orders = new string[datatable.Rows.Count, 6];
            int index = 0;
            foreach (DataRow order in datatable.Rows)
            {
                string order_id = order[0].ToString();
                string collect_money = order[1].ToString();
                string product_index = order[2].ToString();
                string product_name = order[3].ToString();
                string subtotal = order[4].ToString();
                string collect_OK = order[5].ToString();

                if (collect_OK == "False")
                {
                    orders[index, 0] = "";
                    orders[index, 1] = collect_money;
                    orders[index, 2] = order_id;
                    orders[index, 3] = product_index;
                    orders[index, 4] = product_name;
                    orders[index, 5] = subtotal;
                }
                else
                {
                    string selectQuery1 = $"SELECT IF(a.collect_OK = 'False', (SELECT r.order_day FROM `report_day` as r WHERE r.remark = '{order_id}' and r.collect_OK = 'True'), order_day) as order_day FROM `report_day` as a " +
                        $"WHERE a.order_id = '{order_id}' and a.product_index = '{product_index}' ";
                    DataTable datatable1 = ConnectDatabase("查詢", selectQuery1) as DataTable;
                    if (datatable1.Rows.Count == 0 || datatable1.Rows[0][0].ToString() == "")
                    {
                        string selectQuery2 = "SELECT remittance_day FROM `remittance_list` " +
                            $"WHERE order_id = '{order_id}'";
                        DataTable datatable2 = ConnectDatabase("查詢", selectQuery2) as DataTable;
                        if (datatable2 == null || datatable2.Rows.Count == 0)
                        {

                        }
                        else
                        {
                            orders[index, 0] = datatable2.Rows[0][0].ToString();
                            orders[index, 1] = collect_money;
                            orders[index, 2] = order_id;
                            orders[index, 3] = product_index;
                            orders[index, 4] = product_name;
                            orders[index, 5] = subtotal;
                        }
                    }
                    else
                    {
                        orders[index, 0] = datatable1.Rows[0][0].ToString();
                        orders[index, 1] = collect_money;
                        orders[index, 2] = order_id;
                        orders[index, 3] = product_index;
                        orders[index, 4] = product_name;
                        orders[index, 5] = subtotal;
                    }
                }
                index++;
            }
            order_listview.Items.Clear();
            for (int i = 0; i < orders.GetLength(0); i++) 
            {
                ListViewItem item = new ListViewItem(orders[i, 0].ToString() == "" ? "" : DateTime.Parse(orders[i, 0].ToString()).ToString("yyyy-MM-dd"));//收款日期
                item.SubItems.Add(orders[i, 1].ToString());//扣單別
                item.SubItems.Add(orders[i, 2].ToString());//訂單編號
                item.SubItems.Add(orders[i, 3].ToString());//序
                item.SubItems.Add(orders[i, 4].ToString());//商品名稱
                item.SubItems.Add(orders[i, 5].ToString());//應收金額

                order_listview.Items.Add(item);
            };
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            customer_name_textBox.Text = "";
            string selectQuery = "SELECT customer_name  FROM `customer` " +
                $"WHERE customer_id = '{customer_id_textBox.Text}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null || datatable.Rows.Count == 0)
            {

            }
            else
            {
                customer_name_textBox.Text = datatable.Rows[0][0].ToString();
                updateOrderListview();
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customer_id_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                customer_name_textBox.Text = "";
                string selectQuery = "SELECT customer_name  FROM `customer` " +
                    $"WHERE customer_id = '{customer_id_textBox.Text}' ";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                if (datatable == null || datatable.Rows.Count == 0)
                {

                }
                else
                {
                    customer_name_textBox.Text = datatable.Rows[0][0].ToString();
                    updateOrderListview();
                }
            }
        }

        private void CollectMoneyHistoryForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = order_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                order_listview.Columns[0].Width = (int)(totalWidth * 0.1556); // 第一欄占 30%
                order_listview.Columns[1].Width = (int)(totalWidth * 0.1037); // 第二欄占 30%
                order_listview.Columns[2].Width = (int)(totalWidth * 0.1945); // 第三欄占 40%
                order_listview.Columns[3].Width = (int)(totalWidth * 0.0518); // 第一欄占 30%
                order_listview.Columns[4].Width = (int)(totalWidth * 0.2594); // 第三欄占 40%
                order_listview.Columns[5].Width = (int)(totalWidth * 0.1297); // 第一欄占 30%
            }
        }
    }
}
