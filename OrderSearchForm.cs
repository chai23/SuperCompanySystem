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
    public partial class OrderSearchForm : Form
    {
        public OrderSearchForm()
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

        private string getCustomerName(string customer_id)
        {
            string selectQuery = "SELECT customer_name FROM `customer` " +
                    $"WHERE customer_id = '{customer_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            return datatable.Rows[0][0].ToString();
        }

        private bool getIsJoinReserve(string product_id)
        {
            string selectQuery = "SELECT is_join_reserve FROM product " +
                $"WHERE product_id = '{product_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count > 0)
            {
                return Convert.ToBoolean(datatable.Rows[0][0]);
            }
            else
            {
                return false;
            }
        }

        private string getDriverNameOrID(string nameOrid, string value)
        {
            if (value == "") { return ""; }
            if (nameOrid == "name")
            {
                string selectQuery = "SELECT driver_id FROM driver " +
                $"WHERE driver_name = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else if (nameOrid == "id")
            {
                string selectQuery = "SELECT driver_name FROM driver " +
                $"WHERE driver_id = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }

        private string getAreaNameOrID(string nameOrid, string value)
        {
            if (value == "無") { return "無"; }
            if (nameOrid == "name")
            {
                string selectQuery = "SELECT area_id FROM area " +
                $"WHERE area_name = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else if (nameOrid == "id")
            {
                string selectQuery = "SELECT area_name FROM area " +
                $"WHERE area_id = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }

        private string getAreaID(string customer_id)
        {
            string selectQuery = "SELECT area_id FROM `customer` " +
                    $"WHERE customer_id = '{customer_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            return datatable.Rows[0][0].ToString();
        }

        private void updateOrderListview()
        {
            order_listview.Items.Clear();
            var order_day = search_day_dtp.Value.ToString("yyyy-MM-dd");
            string selectQuery2 = "SELECT o.*, c.customer_name, p.is_join_reserve, d.driver_name, a.area_name FROM `order` as o " +
                "JOIN `customer` as c on o.customer_id = c.customer_id "+
                "JOIN `product` as p on o.product_id = p.product_id " +
                "LEFT JOIN `driver` as d on o.driver_id = d.driver_id " +
                "LEFT JOIN `area` as a on c.area_id = a.area_id " +
                $"WHERE o.order_day = '{order_day}' " +
                "ORDER BY o.order_id ASC, o.product_index ASC";
            DataTable datatable2 = ConnectDatabase("查詢", selectQuery2) as DataTable;


            int totalQuantity = 0;
            double totalTex = 0;
            double totalPrice = 0;

            foreach (DataRow order in datatable2.Rows)
            {
                if (order_listview.Items.Count == 0) { }
                else
                {
                    if (order_listview.Items[order_listview.Items.Count - 1].Text != order[0].ToString())
                    {
                        totalQuantity = 0;
                        totalTex = 0;
                        totalPrice = 0;
                    }
                }

                ListViewItem item = new ListViewItem(order[0].ToString());//訂單編號
                item.SubItems.Add(order[1].ToString().Split(' ')[0]);//訂單日期

                item.SubItems.Add(order[24].ToString());//客戶名稱
                item.SubItems.Add(order[17].ToString());//扣單別

                if (order[7].ToString() == "False")
                {
                    item.SubItems.Add("無");//搭贈
                }
                else if (order[7].ToString() == "True")
                {
                    item.SubItems.Add("有");//搭贈
                }

                if (order[8].ToString() == "False")
                {
                    item.SubItems.Add("無");//補送
                }
                else if (order[8].ToString() == "True")
                {
                    item.SubItems.Add("有");//補送
                }

                item.SubItems.Add(order[13].ToString());//發票

                totalTex = totalTex + int.Parse(order[9].ToString());
                item.SubItems.Add(totalTex.ToString());//稅額*

                if (Convert.ToBoolean(order[25].ToString()) & int.Parse(order[3].ToString()) < 201)
                {
                    if (order[17].ToString() == "預收")
                    {
                        if (order[7].ToString() == "False" & order[8].ToString() == "True")
                        {//預收送出
                            totalQuantity = totalQuantity + int.Parse(order[6].ToString());
                        }
                        else if (order[7].ToString() == "True" & order[8].ToString() == "True")
                        {//水破補水
                            totalQuantity = totalQuantity + int.Parse(order[6].ToString());
                        }
                        else if (order[7].ToString() == "False" & order[8].ToString() == "False")
                        {//儲值請款

                        }
                        else if (order[7].ToString() == "True" & order[8].ToString() == "False")
                        {//儲值贈送

                        }
                    }
                    else
                    {
                        totalQuantity = totalQuantity + int.Parse(order[6].ToString());
                    }
                }
                item.SubItems.Add(totalQuantity.ToString());//送瓶*

                item.SubItems.Add(order[16].ToString());//收瓶

                totalPrice = totalPrice + int.Parse(order[10].ToString());
                item.SubItems.Add(totalPrice.ToString());//金額*

                if (order[15].ToString() == "False")
                {
                    item.SubItems.Add("");//銷單
                }
                else if (order[15].ToString() == "True")
                {
                    item.SubItems.Add("✔");//銷單
                }

                if (order[18].ToString() == "False")
                {
                    item.SubItems.Add("");//收款
                }
                else if (order[18].ToString() == "True")
                {
                    item.SubItems.Add("✔");//收款
                }

                item.SubItems.Add(order[26].ToString());//司機

                if (order[19].ToString() == "False")
                {
                    item.SubItems.Add("");//派單
                }
                else if (order[19].ToString() == "True")
                {
                    item.SubItems.Add("✔");//派單
                }

                item.SubItems.Add(order[27].ToString());//區域

                var index = order_listview.Items.Count;
                if (index == 0)
                {
                    item.SubItems[7].Text = totalTex.ToString();
                    item.SubItems[10].Text = totalPrice.ToString();
                    order_listview.Items.Add(item);
                }
                else
                {
                    if (order_listview.Items[index - 1].Text == order[0].ToString())
                    {
                        order_listview.Items[index - 1].Remove();

                        item.SubItems[7].Text = totalTex.ToString();
                        item.SubItems[10].Text = totalPrice.ToString();
                        order_listview.Items.Add(item);
                    }
                    else
                    {
                        item.SubItems[7].Text = totalTex.ToString();
                        item.SubItems[10].Text = totalPrice.ToString();
                        order_listview.Items.Add(item);
                    }
                }
            }

            order_listview.Sorting = SortOrder.Ascending;
            order_listview.ListViewItemSorter = new ListViewItemComparer(1, order_listview.Sorting);
            order_listview.Sort();
        }
        private void updateOrderListview(string order_id)
        {
            order_listview.Items.Clear();
            string selectQuery2 = "SELECT * FROM `order` " +
                $"WHERE order_id = '{order_id}' " +
                "ORDER BY order_id ASC, product_index ASC";
            DataTable datatable2 = ConnectDatabase("查詢", selectQuery2) as DataTable;


            int totalQuantity = 0;
            double totalTex = 0;
            double totalPrice = 0;

            foreach (DataRow order in datatable2.Rows)
            {
                if (order_listview.Items.Count == 0) { }
                else
                {
                    if (order_listview.Items[order_listview.Items.Count - 1].Text != order[0].ToString())
                    {
                        totalQuantity = 0;
                        totalTex = 0;
                        totalPrice = 0;
                    }
                }

                ListViewItem item = new ListViewItem(order[0].ToString());//訂單編號
                item.SubItems.Add(order[1].ToString().Split(' ')[0]);//訂單日期

                item.SubItems.Add(getCustomerName(order[12].ToString()));//客戶名稱
                item.SubItems.Add(order[17].ToString());//扣單別

                if (order[7].ToString() == "False")
                {
                    item.SubItems.Add("無");//搭贈
                }
                else if (order[7].ToString() == "True")
                {
                    item.SubItems.Add("有");//搭贈
                }

                if (order[8].ToString() == "False")
                {
                    item.SubItems.Add("無");//補送
                }
                else if (order[8].ToString() == "True")
                {
                    item.SubItems.Add("有");//補送
                }

                item.SubItems.Add(order[13].ToString());//發票

                totalTex = totalTex + int.Parse(order[9].ToString());
                item.SubItems.Add(totalTex.ToString());//稅額*

                if (getIsJoinReserve(order[3].ToString()) & int.Parse(order[3].ToString()) < 201)
                {
                    if (order[17].ToString() == "預收")
                    {
                        if (order[7].ToString() == "False" & order[8].ToString() == "True")
                        {//預收送出
                            totalQuantity = totalQuantity + int.Parse(order[6].ToString());
                        }
                        else if (order[7].ToString() == "True" & order[8].ToString() == "True")
                        {//水破補水
                            totalQuantity = totalQuantity + int.Parse(order[6].ToString());
                        }
                        else if (order[7].ToString() == "False" & order[8].ToString() == "False")
                        {//儲值請款

                        }
                        else if (order[7].ToString() == "True" & order[8].ToString() == "False")
                        {//儲值贈送

                        }
                    }
                    else
                    {
                        totalQuantity = totalQuantity + int.Parse(order[6].ToString());
                    }
                }
                item.SubItems.Add(totalQuantity.ToString());//送瓶*

                item.SubItems.Add(order[16].ToString());//收瓶

                totalPrice = totalPrice + int.Parse(order[10].ToString());
                item.SubItems.Add(totalPrice.ToString());//金額*

                if (order[15].ToString() == "False")
                {
                    item.SubItems.Add("");//銷單
                }
                else if (order[15].ToString() == "True")
                {
                    item.SubItems.Add("✔");//銷單
                }

                if (order[18].ToString() == "False")
                {
                    item.SubItems.Add("");//收款
                }
                else if (order[18].ToString() == "True")
                {
                    item.SubItems.Add("✔");//收款
                }

                item.SubItems.Add(getDriverNameOrID("id", order[14].ToString()));//司機

                if (order[19].ToString() == "False")
                {
                    item.SubItems.Add("");//派單
                }
                else if (order[19].ToString() == "True")
                {
                    item.SubItems.Add("✔");//派單
                }

                item.SubItems.Add(getAreaNameOrID("id", getAreaID(order[12].ToString())));//區域

                var index = order_listview.Items.Count;
                if (index == 0)
                {
                    item.SubItems[7].Text = totalTex.ToString();
                    item.SubItems[10].Text = totalPrice.ToString();
                    order_listview.Items.Add(item);
                }
                else
                {
                    if (order_listview.Items[index - 1].Text == order[0].ToString())
                    {
                        order_listview.Items[index - 1].Remove();

                        item.SubItems[7].Text = totalTex.ToString();
                        item.SubItems[10].Text = totalPrice.ToString();
                        order_listview.Items.Add(item);
                    }
                    else
                    {
                        item.SubItems[7].Text = totalTex.ToString();
                        item.SubItems[10].Text = totalPrice.ToString();
                        order_listview.Items.Add(item);
                    }
                }
            }

            order_listview.Sorting = SortOrder.Ascending;
            order_listview.ListViewItemSorter = new ListViewItemComparer(1, order_listview.Sorting);
            order_listview.Sort();
        }

        private void order_search_btn_Click(object sender, EventArgs e)
        {
            updateOrderListview();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void order_listview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string order_id = order_listview.SelectedItems[0].SubItems[0].Text;
            OrderDataReviseForm mainForm = new OrderDataReviseForm(order_id, "orderSearch");
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
        }

        private void order_id_search_btn_Click(object sender, EventArgs e)
        {
            if (order_id_textbox.Text == "") { return; }
            updateOrderListview(order_id_textbox.Text);
        }

        private void OrderSearchForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = order_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                order_listview.Columns[0].Width = (int)(totalWidth * 0.0888); // 第一欄占 30%
                order_listview.Columns[1].Width = (int)(totalWidth * 0.0740); // 第二欄占 30%
                order_listview.Columns[2].Width = (int)(totalWidth * 0.1480); // 第三欄占 40%
                order_listview.Columns[3].Width = (int)(totalWidth * 0.0444); // 第一欄占 30%
                order_listview.Columns[4].Width = (int)(totalWidth * 0.0370); // 第二欄占 30%
                order_listview.Columns[5].Width = (int)(totalWidth * 0.0370); // 第三欄占 40%
                order_listview.Columns[6].Width = (int)(totalWidth * 0.0444); // 第一欄占 30%
                order_listview.Columns[7].Width = (int)(totalWidth * 0.0444); // 第二欄占 30%
                order_listview.Columns[8].Width = (int)(totalWidth * 0.0370); // 第三欄占 40%
                order_listview.Columns[9].Width = (int)(totalWidth * 0.0370); // 第一欄占 30%
                order_listview.Columns[10].Width = (int)(totalWidth * 0.0518); // 第二欄占 30%
                order_listview.Columns[11].Width = (int)(totalWidth * 0.0592); // 第三欄占 40%
                order_listview.Columns[12].Width = (int)(totalWidth * 0.0592); // 第一欄占 30%
                order_listview.Columns[13].Width = (int)(totalWidth * 0.0592); // 第一欄占 30%
                order_listview.Columns[14].Width = (int)(totalWidth * 0.0592); // 第二欄占 30%
                order_listview.Columns[15].Width = (int)(totalWidth * 0.0740); // 第三欄占 40%
            }
        }
    }
}
