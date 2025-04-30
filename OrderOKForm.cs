using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 超好企業系統
{
    public partial class OrderOKForm : Form
    {
        public OrderOKForm()
        {
            InitializeComponent();
            getDriverDataToCombobox();
            morningorafter_comboBox.SelectedIndex = 0;
            morningorafter_comboBox_report.SelectedIndex = 0;
            timer1.Start();
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
        private void getDriverDataToCombobox()
        {
            driver_comboBox.Items.Clear();
            string selectQuery = "SELECT driver_name FROM driver";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            foreach (DataRow item in datatable.Rows)
            {
                driver_comboBox.Items.Add(item[0]);
            }
        }
        private string getDriverNameOrID(string nameOrid, string value)
        {
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
        private bool getIsJoinBucket(string product_id)
        {
            string selectQuery = "SELECT is_join_bucket FROM product " +
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
        private bool getIsJoinRemain(string product_id)
        {
            string selectQuery = "SELECT is_join_remain FROM product " +
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
        private string getMoneyOverShortID()
        {
            string selectQuery = "SELECT money_over_short_id FROM `money_over_short` " +
                 "ORDER BY money_over_short_id DESC limit 1";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable == null || datatable.Rows.Count == 0)
            {
                return "00001";
            }
            else
            {
                return (int.Parse(datatable.Rows[0][0].ToString()) + 1).ToString().PadLeft(5, '0');
            }
        }
        private void checkIsHaveOverShort(string order_id, string deliver_day)
        {
            string selectQuery = "SELECT o.product_name, o.customer_id, c.customer_name, o.product_price FROM `order` as o " +
                "JOIN `customer` as c on o.customer_id = c.customer_id " +
                $"WHERE o.order_id = '{order_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            foreach (DataRow item in datatable.Rows)
            {
                if (item[0].ToString() == "短溢收")
                {
                    string money = item[3].ToString();
                    string insertQuery =
                        "INSERT INTO `money_over_short` VALUES " +
                        $"('{getMoneyOverShortID()}', " + //money_over_short_id
                        $"'{item[1].ToString()}', " + //customer_id
                        $"'{item[2].ToString()}', " + //customer_name
                        $"'{money}', " + //money
                        $"'{order_id}', " + //order_id
                        $"'{deliver_day}', " + //order_OK_day
                        $"'{MainForm.Maker}')"; //maker

                    ConnectDatabase("新增", insertQuery).ToString();

                    string insertQuery1 =
                        "INSERT INTO `report_day` VALUES " +
                        $"('{order_id}', " +//order_id
                        $"'{deliver_day}', " +//order_day
                        $"'{driver_comboBox.Text}', " +//driver_id
                        $"'{"短溢收"}', " +//product_name
                        $"'{money}', " +//product_price
                        $"'{"1"}', " +//product_quantity
                        $"'{money}', " +//subtotal
                        $"'{"True"}', " +//collect_OK
                        $"'{"短溢收"}', " +//remark
                        $"'{item[1].ToString()}', " +//customer_id
                        $"'{"0"}', " +//recyele_quantity
                        $"'{"現金"}', " +//collect_money
                        $"'{datatable.Rows.Count}', " +//product_index
                        $"'{morningorafter_comboBox_report.Text}')";//morningorafternoon

                    ConnectDatabase("新增", insertQuery1).ToString();

                    string removeQuery =
                        "DELETE FROM `order` WHERE " +
                        $"order_id = '{order_id}' AND product_id = '000' AND product_name = '短溢收'";
                    ConnectDatabase("刪除", removeQuery);
                }
            }

        }
        private void putOrderToReportOrder(string order_id)
        {
            string selectQuery = "SELECT order_id, order_day, driver_id, product_name, product_price,  product_quantity, subtotal, collect_OK, collect_money, give_nofree, recyele_quantity, customer_id, product_index, give_free FROM `order` " +
                $"WHERE order_id = '{order_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            foreach (DataRow order in datatable.Rows)
            {
                var remark = "現金";

                if (order[3].ToString() == "上期未收款項") { remark = "前帳"; }
                else if (order[8].ToString() == "預收")
                { 
                    if(order[9].ToString() == "False" && order[13].ToString() == "False")
                    {
                        remark = "預收";
                    }
                    else if (order[9].ToString() == "True" && order[13].ToString() == "False")
                    {
                        remark = "抵扣";
                    }
                    else if (order[9].ToString() == "False" && order[13].ToString() == "True")
                    {
                        remark = "預收";
                    }
                    else if (order[9].ToString() == "True" && order[13].ToString() == "True")
                    {
                        remark = "補送";
                    }
                }
                else if (order[8].ToString() == "月結") { remark = "月結"; }
                else if (order[3].ToString() == "短溢收") { remark = "短溢收"; }

                string insertQuery =
                    "INSERT INTO `report_day` VALUES " +
                    $"('{order[0].ToString()}'," +//order_id
                    $"'{order[1].ToString().Split(' ')[0]}'," +//order_day
                    $"'{getDriverNameOrID("id", order[2].ToString())}'," +//driver_id
                    $"'{order[3].ToString()}'," +//product_name
                    $"'{order[4].ToString()}'," +//product_price
                    $"'{order[5].ToString()}'," +//product_quantity
                    $"'{order[6].ToString()}'," +//subtotal
                    $"'{order[7].ToString()}'," +//collect_OK
                    $"'{remark}'," +//remark
                    $"'{order[11].ToString()}'," +//customer_id
                    $"'{order[10].ToString()}'," +//recyele_quantity
                    $"'{order[8].ToString()}'," +//collect_money
                    $"'{order[12].ToString()}'," +//product_index
                    $"'{morningorafter_comboBox_report.Text}')";//morningorafternoon

                ConnectDatabase("新增", insertQuery);
            }
        }
        private void updateSameIDRemain(string customer_id, string remain)
        {
            string customer_id_mark = customer_id.Contains('-') ? customer_id.Split('-')[0] : customer_id;

            string reviseQuery =
                "UPDATE customer SET " +
                $"customer_remain = '{remain}' " +
                $"WHERE customer_id_mark = '{customer_id_mark}'";
            ConnectDatabase("修改", reviseQuery);
        }
        private List<string> getCollectFalseOrserID(string order_id)
        {
            string selectQuery = "SELECT remark FROM `order` " +
                $"WHERE order_id = '{order_id}' " +
                "AND product_id = '000' AND collect_OK = 'True'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            List<string> list = new List<string>();
            foreach (DataRow row in datatable.Rows)
            {
                list.Add(row[0].ToString()); 
            }
            return list;
        }
        private string getIsMonthOrder(string order_id)
        {
            string selectQuery = "SELECT product_id FROM `order` " +
                $"WHERE order_id = '{order_id}' " +
                "GROUP BY product_id";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            string answer = "False";
            foreach (DataRow item in datatable.Rows)
            {
                if (item[0].ToString() == "0000")
                {
                    answer = "True";
                }
            }
            return answer;
        }
        private string getRemark(string order_id)
        {
            string selectQuery = "SELECT remark FROM `order` " +
                $"WHERE order_id = '{order_id}' " +
                "AND product_index = '1'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            return datatable.Rows[0][0].ToString();
        }
        private string getTotalMoney(string order_id)
        {
            string selectQuery = "SELECT subtotal FROM `order` " +
                $"WHERE order_id = '{order_id}' AND collect_money <> '月結'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            Double totalMoney = 0;
            foreach (DataRow item in datatable.Rows)
            {
                totalMoney += int.Parse(item[0].ToString());
            }
            return totalMoney.ToString();
        }
        private int getReserve(string product_id)
        {
            string selectQuery = "SELECT product_reserve FROM `product` " +
                $"WHERE product_id = '{product_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            return int.Parse(datatable.Rows[0][0].ToString());
        }
        private string calculateCustomerBucket(string customer_id, int quantity ,int recyele_quantity)
        {
            string selectQuery = "SELECT customer_bucket FROM `customer` " +
                $"WHERE customer_id = '{customer_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            var customer_bucket = datatable.Rows[0][0].ToString() ;
            var newBucket = int.Parse(customer_bucket) +quantity - recyele_quantity;
            return newBucket.ToString();
        }
        private string calculateCustomerRemain(string customer_id, int quantity)
        {
            string selectQuery = "SELECT customer_remain FROM `customer` " +
                $"WHERE customer_id = '{customer_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            var customer_remain = datatable.Rows[0][0].ToString();
            var newRemain = int.Parse(customer_remain) + quantity;
            return newRemain.ToString();
        }
        private string resviceBucket(string costomer, string quantity)
        {
            string reviseQuery =
                "UPDATE customer SET " +
                $"customer_bucket = '{quantity}' " +
                $"WHERE customer_id = '{costomer}'";
            var resultRevise = ConnectDatabase("修改", reviseQuery);
            return resultRevise.ToString();
        }
        private void updateReserve(string order_id)
        {
            //更新商品庫存
            string selectQuery = "SELECT product_quantity, collect_money, product_id, give_nofree, give_free FROM `order` " +
                $"WHERE order_id = '{order_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            foreach (DataRow order in datatable.Rows)
            {
                if (getIsJoinReserve(order[2].ToString()) == true)
                {
                    if (order[1].ToString() == "預收")
                    {
                        if (order[3].ToString() == "True" & order[4].ToString() == "False")
                        {//預收送水
                            var newReserve = (getReserve(order[2].ToString()) - int.Parse(order[0].ToString())).ToString();
                            string reviseQuery =
                                "UPDATE `product` SET " +
                                $"product_reserve = '{newReserve}' " +
                                $"WHERE product_id = '{order[2].ToString()}'";
                            ConnectDatabase("修改", reviseQuery);
                        }
                        else if (order[3].ToString() == "False" & order[4].ToString() == "True")
                        {//儲值贈送

                        }
                        else if (order[3].ToString() == "False" & order[4].ToString() == "False")
                        {//預收儲值

                        }
                        else if (order[3].ToString() == "True" & order[4].ToString() == "True")
                        {//破水補送
                            var newReserve = (getReserve(order[2].ToString()) - int.Parse(order[0].ToString())).ToString();
                            string reviseQuery =
                                "UPDATE `product` SET " +
                                $"product_reserve = '{newReserve}' " +
                                $"WHERE product_id = '{order[2].ToString()}'";
                            ConnectDatabase("修改", reviseQuery);
                        }
                    }
                    else
                    {
                        var newReserve = (getReserve(order[2].ToString()) - int.Parse(order[0].ToString())).ToString();
                        string reviseQuery =
                            "UPDATE `product` SET " +
                            $"product_reserve = '{newReserve}' " +
                            $"WHERE product_id = '{order[2].ToString()}'";
                        ConnectDatabase("修改", reviseQuery);
                    }
                }
            }

        }
        private void updateDriverTotalQuantityAndMoneyLable()
        {
            if (driver_order_listview.Items.Count == 0)
            {
                driver_total_quantity_label.Text = "司機送水總桶數：0";
                driver_total_recyele_quantity_label.Text = "司機回收總桶數：0";
                driver_total_money_label.Text = "司機收款總金額：0";
                return;
            }
            int totalQuantity = 0;
            int totalRecyeleQuantity = 0;
            double totalMoney = 0;

            foreach (ListViewItem item in driver_order_listview.Items)
            {
                totalQuantity += int.Parse(item.SubItems[3].Text);
                totalRecyeleQuantity += int.Parse(item.SubItems[4].Text);
                totalMoney += double.Parse(item.SubItems[5].Text);
            }
            driver_total_quantity_label.Text = "司機送水總桶數：" + totalQuantity.ToString();
            driver_total_recyele_quantity_label.Text = "司機回收總桶數：" + totalRecyeleQuantity.ToString();
            driver_total_money_label.Text = "司機收款總金額：" + totalMoney.ToString();
        }
        private void updateDriverOrderListview()
        {
            if (driver_comboBox.Text == "") { return; }

            driver_order_listview.Items.Clear();

            string selectQuery2 = "SELECT d.*, s.customer_id, s.subtotal FROM `driver_order` as d " +
                "JOIN (select distinct order_id, customer_id, sum(if(collect_money <> '月結', subtotal, 0)) as subtotal from `order` group by order_id, customer_id) as s on s.order_id = d.order_id " +
                $"WHERE d.driver_id = '{getDriverNameOrID("name", driver_comboBox.Text)}' " +
                $"AND d.deliver_day = '{deliver_day_dtp.Value.ToString("yyyy-MM-dd")}' " +
                $"AND d.morningorafternoon = '{morningorafter_comboBox.Text}'";
            DataTable datatable2 = ConnectDatabase("查詢", selectQuery2) as DataTable;

            foreach (DataRow order in datatable2.Rows)
            {
                ListViewItem item = new ListViewItem(order[1].ToString());//訂單編號

                item.SubItems.Add(order[10].ToString());//客戶編號
                item.SubItems.Add(order[3].ToString());//客戶名稱
                item.SubItems.Add(order[2].ToString());//客戶送瓶
                item.SubItems.Add(order[4].ToString());//回收桶數

                item.SubItems.Add(order[5].ToString());//金額

                if (order[6].ToString() == "False")
                {
                    item.SubItems.Add("");//銷單
                }
                else if (order[6].ToString() == "True")
                {
                    item.SubItems.Add("✔");//銷單
                }
                item.SubItems.Add(driver_comboBox.Text);//司機
                item.SubItems.Add(DateTime.Parse(order[7].ToString().Split(' ')[0]).ToString("yyyy-MM-dd"));//送貨日期
                item.SubItems.Add(order[8].ToString());//班別
                item.SubItems.Add(order[9].ToString());//訂單備註
                item.SubItems.Add(order[11].ToString());
                driver_order_listview.Items.Add(item);
            }

            updateDriverTotalQuantityAndMoneyLable();

            driver_order_listview.Sorting = SortOrder.Ascending;
            driver_order_listview.ListViewItemSorter = new ListViewItemComparer(0, driver_order_listview.Sorting);
            driver_order_listview.Sort();
        }
        private void order_search_btn_Click(object sender, EventArgs e)
        {
            updateDriverOrderListview();
        }
        private void order_OK_btn_Click(object sender, EventArgs e)
        {
            if (driver_order_listview.SelectedItems.Count == 0) { return; }


            var order_id = driver_order_listview.SelectedItems[0].SubItems[0].Text;
            var customer_id = driver_order_listview.SelectedItems[0].SubItems[1].Text;
            var deliver_day = driver_order_listview.SelectedItems[0].SubItems[8].Text;
            var pay_money = driver_order_listview.SelectedItems[0].SubItems[5].Text;
            var recyele_quantity = driver_order_listview.SelectedItems[0].SubItems[4].Text;
            var newRemark = driver_order_listview.SelectedItems[0].SubItems[10].Text;
            var oldRemark = getRemark(order_id);

            var total_money = getTotalMoney(order_id);
            var remain = 0;
            var bucket = 0;

            if (driver_order_listview.SelectedItems[0].SubItems[6].Text == "")
            {
                //司機未送達
                string removeQuery =
                    "DELETE FROM `driver_order` WHERE " +
                    $"order_id = '{order_id}'";
                ConnectDatabase("刪除", removeQuery);

                string reviseQuery =
                    "UPDATE `order` SET " +
                    "driver_id = '', " +
                    "order_day = order_id_day, " +
                    "assign_OK = 'False' " +
                    $"WHERE order_id = '{order_id}'";
                ConnectDatabase("修改", reviseQuery);

                MessageBox.Show("此訂單未完成！");
                updateDriverOrderListview();
                return;
            }

            string selectQuery = "SELECT product_quantity, give_nofree, product_id, collect_money, give_free FROM `order` " +
                $"WHERE order_id = '{order_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            foreach (DataRow item in datatable.Rows)
            {
                if (item[3].ToString() == "預收")
                {
                    if (int.Parse(item[2].ToString()) < 201)
                    {
                        if (item[1].ToString() == "False" & item[4].ToString() == "False" & getIsJoinRemain(item[2].ToString()) == true)
                        { //預收儲值
                            remain = remain + int.Parse(item[0].ToString());
                        }
                        else if (item[1].ToString() == "True" & item[4].ToString() == "False" & getIsJoinRemain(item[2].ToString()) == true)
                        { //預收送出
                            
                            remain = remain - int.Parse(item[0].ToString());
                           
                            if (getIsJoinBucket(item[2].ToString()) == true & int.Parse(item[2].ToString()) < 201)
                            {
                                bucket = bucket + int.Parse(item[0].ToString());
                            }
                        }
                        else if (item[1].ToString() == "False" & item[4].ToString() == "True" & getIsJoinRemain(item[2].ToString()) == true)
                        { //儲值贈送
                            remain = remain + int.Parse(item[0].ToString());
                        }
                        else if (item[1].ToString() == "True" & item[4].ToString() == "True" & getIsJoinRemain(item[2].ToString()) == true)
                        {//破水補送
                            if (getIsJoinBucket(item[2].ToString()) == true & int.Parse(item[2].ToString()) < 201)
                            {
                                bucket = bucket + int.Parse(item[0].ToString());
                            }
                        }
                    }
                }
                else
                {
                    if (getIsJoinBucket(item[2].ToString()) == true & int.Parse(item[2].ToString()) < 201)
                    {
                        //更新未回收桶數
                        bucket = bucket + int.Parse(item[0].ToString());
                    }
                }
            }

            var newRemain = calculateCustomerRemain(customer_id, remain); ;
            var newBucket = calculateCustomerBucket(customer_id, bucket, int.Parse(recyele_quantity));

            if (total_money == "0")
            {
                if(pay_money == "0")
                {
                    //訂單是0元，且有完成訂單!(order_OK = true/collect_OK = true)
                    string reviseQuery =
                        "UPDATE `order` SET " +
                        "order_OK = 'True', " +
                        "collect_OK = 'True', " +
                        $"order_day = '{deliver_day}', " +
                        $"recyele_quantity = '{recyele_quantity}' " +
                        $"WHERE order_id = '{order_id}' AND collect_money <> '月結'";
                    ConnectDatabase("修改", reviseQuery);

                    string reviseQuery3 =
                        "UPDATE `order` SET " +
                        "order_OK = 'True', " +
                        "collect_OK = 'False', " +
                        $"order_day = '{deliver_day}', " +
                        $"recyele_quantity = '{recyele_quantity}' " +
                        $"WHERE order_id = '{order_id}' AND collect_money = '月結'";
                    ConnectDatabase("修改", reviseQuery3);

                    if (getCollectFalseOrserID(order_id).Count > 0)//把未收款的訂單改成已收款
                    {
                        foreach (string id in getCollectFalseOrserID(order_id))
                        {
                            string reviseQuery1 =
                                "UPDATE `order` SET " +
                                "collect_OK = 'True' " +
                                $"WHERE order_id = '{id}' AND collect_money <> '月結'";
                            ConnectDatabase("修改", reviseQuery1);

                            if (getIsMonthOrder(id) == "True")
                            {
                                string reviseQuery2 =
                                    "UPDATE `order` SET " +
                                    $"driver_id = '{getDriverNameOrID("name", driver_comboBox.Text)}', " +
                                    "collect_OK = 'True', " +
                                    "order_OK = 'True', " +
                                    "assign_OK = 'True' " +
                                    $"WHERE order_id = '{id}' AND collect_money <> '月結'";
                                ConnectDatabase("修改", reviseQuery2);
                            }
                        }
                    }

                    //檢查備註是否更新
                    if (oldRemark != newRemark)
                    {
                        DialogResult anser = MessageBox.Show("此訂單備註已被更新！是否同意更新備註? 更新內容：" + newRemark, "注意", MessageBoxButtons.YesNoCancel);

                        switch (anser)
                        {
                            case DialogResult.Yes:

                                string reviseQuery2 =
                                    "UPDATE `order` SET " +
                                    $"remark = '{newRemark}' " +
                                    $"WHERE order_id = '{order_id}' " +
                                    "AND product_index = '1'";
                                ConnectDatabase("修改", reviseQuery2);

                                break;
                            case DialogResult.No:
                                UpdateRemarkForm mainForm = new UpdateRemarkForm(order_id);
                                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                mainForm.ShowDialog();
                                break;
                            case DialogResult.Cancel:

                                break;
                            default:
                                break;
                        }
                    }

                    resviceBucket(customer_id, newBucket);//更新客戶未回收桶數
                    updateSameIDRemain(customer_id, newRemain);//更新客戶預收桶數
                    updateReserve(order_id);//更新商品庫存

                    putOrderToReportOrder(order_id);

                    string removeQuery =
                        "DELETE FROM `driver_order` WHERE " +
                        $"order_id = '{order_id}'";
                    ConnectDatabase("刪除", removeQuery);

                    string removeQuery1 =
                        "DELETE FROM `order` WHERE " +
                        $"order_id = '{order_id}' " +
                        "AND product_id = '000'";
                    ConnectDatabase("刪除", removeQuery1);

                    //檢查是否有收回維修的飲水機
                    foreach (DataRow order in datatable.Rows)
                    {
                        if (order[2].ToString() == "304" | order[2].ToString() == "305" | order[2].ToString() == "306" | order[2].ToString() == "307")
                        {
                            if (MessageBox.Show($"請確認此訂單是否有【收回】{order[0].ToString()}台維修飲水機", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                for (int i = 1; i <= int.Parse(order[0].ToString()); i++)
                                {
                                    UpdateWaterdispenserForm mainForm = new UpdateWaterdispenserForm(customer_id, "OrderOK");
                                    mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                    mainForm.ShowDialog();
                                }
                            }
                            else
                            {

                            }
                        }
                        else if (order[2].ToString() == "303")
                        {
                            if (MessageBox.Show("請確認此訂單是否有【送回】維修飲水機", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                WaterdispenserForm mainForm = new WaterdispenserForm();
                                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                mainForm.ShowDialog();
                            }
                            else
                            {

                            }
                        }
                    }

                    MessageBox.Show("此筆帳單銷單成功！");
                    updateDriverOrderListview();
                }
                else
                {
                    MessageBox.Show("收款金額與應收金額不符合！不可銷單！");
                }
            }
            else
            {
                if(pay_money == total_money)
                {
                    //完成訂單!(order_OK = true/collect_OK = true)

                    string reviseQuery =
                        "UPDATE `order` SET " +
                        "order_OK = 'True', " +
                        "collect_OK = 'True', " +
                        $"order_day = '{deliver_day}', " +
                        $"recyele_quantity = '{recyele_quantity}' " +
                        $"WHERE order_id = '{order_id}' AND collect_money <> '月結'";
                    ConnectDatabase("修改", reviseQuery);

                    string reviseQuery3 =
                        "UPDATE `order` SET " +
                        "order_OK = 'True', " +
                        "collect_OK = 'False', " +
                        $"order_day = '{deliver_day}', " +
                        $"recyele_quantity = '{recyele_quantity}' " +
                        $"WHERE order_id = '{order_id}' AND collect_money = '月結'";
                    ConnectDatabase("修改", reviseQuery3);

                    if (getCollectFalseOrserID(order_id).Count > 0)//把未收款的訂單改成已收款
                    {
                        foreach (string id in getCollectFalseOrserID(order_id))
                        {
                            string reviseQuery1 =
                                "UPDATE `order` SET " +
                                "collect_OK = 'True' " +
                                $"WHERE order_id = '{id}' AND collect_money <> '月結'";
                            ConnectDatabase("修改", reviseQuery1);

                            if (getIsMonthOrder(id) == "True")
                            {
                                string reviseQuery2 =
                                    "UPDATE `order` SET " +
                                    $"driver_id = '{getDriverNameOrID("name", driver_comboBox.Text)}', " +
                                    "collect_OK = 'True', " +
                                    "order_OK = 'True', " +
                                    "assign_OK = 'True' " +
                                    $"WHERE order_id = '{id}' AND collect_money <> '月結'";
                                ConnectDatabase("修改", reviseQuery2);
                            }
                        }
                    }

                    //檢查備註是否更新
                    if (oldRemark != newRemark)
                    {
                        DialogResult anser = MessageBox.Show("此訂單備註已被更新！是否同意更新備註? 更新內容：" + newRemark, "注意", MessageBoxButtons.YesNoCancel);

                        switch (anser)
                        {
                            case DialogResult.Yes:

                                string reviseQuery2 =
                                    "UPDATE `order` SET " +
                                    $"remark = '{newRemark}' " +
                                    $"WHERE order_id = '{order_id}' " +
                                    "AND product_index = '1'";
                                ConnectDatabase("修改", reviseQuery2);

                                break;
                            case DialogResult.No:
                                UpdateRemarkForm mainForm = new UpdateRemarkForm(order_id);
                                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                mainForm.ShowDialog();
                                break;
                            case DialogResult.Cancel:

                                break;
                            default:
                                break;
                        }
                    }

                    resviceBucket(customer_id, newBucket);//更新客戶未回收桶數
                    updateSameIDRemain(customer_id, newRemain);
                    updateReserve(order_id);//更新商品庫存

                    //檢查訂單是否有短溢收，如果有就記錄之後刪除
                    checkIsHaveOverShort(order_id, deliver_day);

                    putOrderToReportOrder(order_id);

                    string removeQuery =
                        "DELETE FROM `driver_order` WHERE " +
                        $"order_id = '{order_id}'";
                    ConnectDatabase("刪除", removeQuery);

                    string removeQuery1 =
                        "DELETE FROM `order` WHERE " +
                        $"order_id = '{order_id}' " +
                        "AND product_id = '000'";
                    ConnectDatabase("刪除", removeQuery1);

                    //檢查是否有收回維修的飲水機
                    foreach (DataRow order in datatable.Rows)
                    {
                        if (order[2].ToString() == "304" | order[2].ToString() == "305" | order[2].ToString() == "306" | order[2].ToString() == "307")
                        {
                            if (MessageBox.Show($"請確認此訂單是否有【收回】{order[0].ToString()}台維修飲水機", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                for (int i = 1; i <= int.Parse(order[0].ToString()); i++)
                                {
                                    UpdateWaterdispenserForm mainForm = new UpdateWaterdispenserForm(customer_id, "OrderOK");
                                    mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                    mainForm.ShowDialog();
                                }
                            }
                            else
                            {

                            }
                        }
                        else if (order[2].ToString() == "303")
                        {
                            if (MessageBox.Show("請確認此訂單是否有【送回】維修飲水機", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                WaterdispenserForm mainForm = new WaterdispenserForm();
                                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                mainForm.ShowDialog();
                            }
                            else
                            {

                            }
                        }
                    }

                    MessageBox.Show("此筆帳單銷單成功！");
                    updateDriverOrderListview();
                }
                else if(pay_money == "0")
                {
                    //收錢是0元，且有完成訂單!(order_OK = true/collect_OK = false)

                    MessageBox.Show("此筆帳單尚未收款！");

                    string reviseQuery =
                        "UPDATE `order` SET " +
                        "order_OK = 'True', " +
                        "collect_OK = 'False', " +
                        $"order_day = '{deliver_day}', " +
                        $"recyele_quantity = '{recyele_quantity}' " +
                        $"WHERE order_id = '{order_id}'";
                    ConnectDatabase("修改", reviseQuery);

                    string reviseQuery3 =
                        "UPDATE `order` SET " +
                        "order_OK = 'True', " +
                        "collect_OK = 'True', " +
                        $"order_day = '{deliver_day}', " +
                        $"recyele_quantity = '{recyele_quantity}' " +
                        $"WHERE order_id = '{order_id}' AND collect_money <> '月結' AND subtotal = '0'";
                    ConnectDatabase("修改", reviseQuery3);

                    //檢查備註是否更新
                    if (oldRemark != newRemark)
                    {
                        DialogResult anser = MessageBox.Show("此訂單備註已被更新！是否同意更新備註? 更新內容：" + newRemark, "注意", MessageBoxButtons.YesNoCancel);

                        switch (anser)
                        {
                            case DialogResult.Yes:

                                string reviseQuery2 =
                                    "UPDATE `order` SET " +
                                    $"remark = '{newRemark}' " +
                                    $"WHERE order_id = '{order_id}' " +
                                    "AND product_index = '1'";
                                ConnectDatabase("修改", reviseQuery2);

                                break;
                            case DialogResult.No:
                                UpdateRemarkForm mainForm = new UpdateRemarkForm(order_id);
                                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                mainForm.ShowDialog();
                                break;
                            case DialogResult.Cancel:

                                break;
                            default:
                                break;
                        }
                    }

                    resviceBucket(customer_id, newBucket);//更新客戶未回收桶數
                    updateSameIDRemain(customer_id, newRemain);
                    updateReserve(order_id);//更新商品庫存

                    putOrderToReportOrder(order_id);

                    string removeQuery =
                        "DELETE FROM `driver_order` WHERE " +
                        $"order_id = '{order_id}'";
                    ConnectDatabase("刪除", removeQuery);

                    string removeQuery1 =
                        "DELETE FROM `order` WHERE " +
                        $"order_id = '{order_id}' " +
                        "AND product_id = '000'";
                    ConnectDatabase("刪除", removeQuery1);

                    //檢查是否有收回維修的飲水機
                    foreach (DataRow order in datatable.Rows)
                    {
                        if (order[2].ToString() == "304" | order[2].ToString() == "305" | order[2].ToString() == "306" | order[2].ToString() == "307")
                        {
                            if (MessageBox.Show($"請確認此訂單是否有【收回】{order[0].ToString()}台維修飲水機", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                for (int i = 1; i <= int.Parse(order[0].ToString()); i++)
                                {
                                    UpdateWaterdispenserForm mainForm = new UpdateWaterdispenserForm(customer_id, "OrderOK");
                                    mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                    mainForm.ShowDialog();
                                }
                            }
                            else
                            {

                            }
                        }
                        else if (order[2].ToString() == "303")
                        {
                            if (MessageBox.Show("請確認此訂單是否有【送回】維修飲水機", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                WaterdispenserForm mainForm = new WaterdispenserForm();
                                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                mainForm.ShowDialog();
                            }
                            else
                            {

                            }
                        }
                    }

                    updateDriverOrderListview();
                }
                else
                {
                    //收款金額與付款金額不同
                    OrderOKDetilForm mainForm = new OrderOKDetilForm(order_id, pay_money, deliver_day, driver_comboBox.Text, morningorafter_comboBox_report.Text);
                    mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                    mainForm.ShowDialog();
                    if (orderOKDetil == "False") { return; }

                    string reviseQuery =
                        "UPDATE `order` SET " +
                        $"order_day = '{deliver_day}', " +
                        $"recyele_quantity = '{recyele_quantity}' " +
                        $"WHERE order_id = '{order_id}' AND collect_money <> '月結'";
                    ConnectDatabase("修改", reviseQuery);


                    string reviseQuery3 =
                        "UPDATE `order` SET " +
                        "order_OK = 'True', " +
                        "collect_OK = 'False', " +
                        $"order_day = '{deliver_day}', " +
                        $"recyele_quantity = '{recyele_quantity}' " +
                        $"WHERE order_id = '{order_id}' AND collect_money = '月結'";
                    ConnectDatabase("修改", reviseQuery3);

                    if (getCollectFalseOrserID(order_id).Count > 0)//把未收款的訂單改成已收款
                    {
                        foreach (string id in getCollectFalseOrserID(order_id))
                        {
                            string reviseQuery1 =
                                "UPDATE `order` SET " +
                                "collect_OK = 'True' " +
                                $"WHERE order_id = '{id}' AND collect_money <> '月結'";
                            ConnectDatabase("修改", reviseQuery1);

                            if (getIsMonthOrder(id) == "True")
                            {
                                string reviseQuery2 =
                                    "UPDATE `order` SET " +
                                    $"driver_id = '{getDriverNameOrID("name", driver_comboBox.Text)}', " +
                                    "collect_OK = 'True', " +
                                    "order_OK = 'True', " +
                                    "assign_OK = 'True' " +
                                    $"WHERE order_id = '{id}' AND collect_money <> '月結'";
                                ConnectDatabase("修改", reviseQuery2);
                            }
                        }
                    }

                    //檢查備註是否更新
                    if (oldRemark != newRemark)
                    {
                        DialogResult anser = MessageBox.Show("此訂單備註已被更新！是否同意更新備註? 更新內容：" + newRemark, "注意", MessageBoxButtons.YesNoCancel);

                        switch (anser)
                        {
                            case DialogResult.Yes:

                                string reviseQuery2 =
                                    "UPDATE `order` SET " +
                                    $"remark = '{newRemark}' " +
                                    $"WHERE order_id = '{order_id}' " +
                                    "AND product_index = '1'";
                                ConnectDatabase("修改", reviseQuery2);

                                break;
                            case DialogResult.No:
                                UpdateRemarkForm mainForm1 = new UpdateRemarkForm(order_id);
                                mainForm1.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                mainForm1.ShowDialog();
                                break;
                            case DialogResult.Cancel:

                                break;
                            default:
                                break;
                        }
                    }

                    resviceBucket(customer_id, newBucket);//更新客戶未回收桶數
                    updateSameIDRemain(customer_id, newRemain);
                    updateReserve(order_id);//更新商品庫存

                    putOrderToReportOrder(order_id);

                    string removeQuery =
                        "DELETE FROM `driver_order` WHERE " +
                        $"order_id = '{order_id}'";
                    ConnectDatabase("刪除", removeQuery);

                    string removeQuery1 =
                        "DELETE FROM `order` WHERE " +
                        $"order_id = '{order_id}' " +
                        "AND product_id = '000'";
                    ConnectDatabase("刪除", removeQuery1);

                    //檢查是否有收回維修的飲水機
                    foreach (DataRow order in datatable.Rows)
                    {
                        if (order[2].ToString() == "304" | order[2].ToString() == "305" | order[2].ToString() == "306" | order[2].ToString() == "307")
                        {
                            if (MessageBox.Show($"請確認此訂單是否有【收回】{order[0].ToString()}台維修飲水機", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                for (int i = 1; i <= int.Parse(order[0].ToString()); i++)
                                {
                                    UpdateWaterdispenserForm mainForm2 = new UpdateWaterdispenserForm(customer_id, "OrderOK");
                                    mainForm2.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                    mainForm2.ShowDialog();
                                }
                            }
                            else
                            {

                            }
                        }
                        else if (order[2].ToString() == "303")
                        {
                            if (MessageBox.Show("請確認此訂單是否有【送回】維修飲水機", "注意", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                WaterdispenserForm mainForm3 = new WaterdispenserForm();
                                mainForm3.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                                mainForm3.ShowDialog();
                            }
                            else
                            {

                            }
                        }
                    }

                    MessageBox.Show("此筆帳單銷單成功！");
                    updateDriverOrderListview();
                }
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (driver_comboBox.Text == "") { return; }
            
            string selectQuery = "SELECT order_id, recyele_quantity, pay_money, order_OK, remark, order_quantity FROM `driver_order` " +
                $"WHERE driver_id = '{getDriverNameOrID("name", driver_comboBox.Text)}' " +
                $"AND deliver_day = '{deliver_day_dtp.Value.ToString("yyyy-MM-dd")}' " +
                $"AND morningorafternoon = '{morningorafter_comboBox.Text}' " +
                "ORDER BY order_id ASC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count == 0 || driver_order_listview.Items.Count == 0) { return; }
            var index = 0;

            if (datatable.Rows.Count != driver_order_listview.Items.Count) { updateDriverOrderListview();  return; }
            foreach (DataRow item in datatable.Rows)
            {
                if (item[0].ToString() != driver_order_listview.Items[index].SubItems[0].Text) { updateDriverOrderListview();  return; }
                if (item[1].ToString() != driver_order_listview.Items[index].SubItems[4].Text) { updateDriverOrderListview(); return; }
                if (item[2].ToString() != driver_order_listview.Items[index].SubItems[5].Text) { updateDriverOrderListview(); return; }
                if ((item[3].ToString() == "True" ? "✔" : "") != driver_order_listview.Items[index].SubItems[6].Text) { updateDriverOrderListview(); return; }
                if (item[4].ToString() != driver_order_listview.Items[index].SubItems[10].Text) { updateDriverOrderListview(); return; }
                if (item[5].ToString() != driver_order_listview.Items[index].SubItems[3].Text) { updateDriverOrderListview(); return; }
                index++;
            }
            
        }
        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void OrderOKForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
        private void morningorafter_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDriverOrderListview();
        }

        private string billNumber;
        public string BillNumber
        {
            set
            {
                billNumber = value;
            }
        }
        private string orderOKDetil;
        public string OrderOKDetil
        {
            set
            {
                orderOKDetil = value;
            }
        }
        private void driver_floor_btn_Click(object sender, EventArgs e)
        {
            if (driver_order_listview.SelectedItems.Count.ToString() == "0") { return; }
            string order_day = deliver_day_dtp.Value.ToString("yyyy-MM-dd");
            string order_id = driver_order_listview.SelectedItems[0].SubItems[0].Text;
            string driver_name = driver_comboBox.Text;
            string customer_id = driver_order_listview.SelectedItems[0].SubItems[1].Text; ;
            string customer_name = driver_order_listview.SelectedItems[0].SubItems[2].Text;
            string morningorafternoon = morningorafter_comboBox_report.Text;
            DriverFloorDetilForm mainForm = new DriverFloorDetilForm(order_day, order_id, driver_name, customer_id, customer_name, morningorafternoon);
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
        }
        private void OrderOKForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = driver_order_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                driver_order_listview.Columns[0].Width = (int)(totalWidth * 0.0888); // 第一欄占 30%
                driver_order_listview.Columns[1].Width = (int)(totalWidth * 0.0640); // 第二欄占 30%
                driver_order_listview.Columns[2].Width = (int)(totalWidth * 0.1110); // 第二欄占 30%
                driver_order_listview.Columns[3].Width = (int)(totalWidth * 0.0518); // 第一欄占 30%
                driver_order_listview.Columns[4].Width = (int)(totalWidth * 0.0518); // 第二欄占 30%
                driver_order_listview.Columns[5].Width = (int)(totalWidth * 0.0592); // 第一欄占 30%
                driver_order_listview.Columns[6].Width = (int)(totalWidth * 0.0592); // 第二欄占 30%
                driver_order_listview.Columns[7].Width = (int)(totalWidth * 0.0592); // 第一欄占 30%
                driver_order_listview.Columns[8].Width = (int)(totalWidth * 0.1110); // 第二欄占 30%
                driver_order_listview.Columns[9].Width = (int)(totalWidth * 0.0444); // 第一欄占 30%
                driver_order_listview.Columns[10].Width = (int)(totalWidth * 0.1480); // 第二欄占 30%
                driver_order_listview.Columns[11].Width = (int)(totalWidth * 0.0592); // 第二欄占 30%
            }
        }
        private void driver_order_listview_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string order_id = driver_order_listview.SelectedItems[0].SubItems[0].Text;
            OrderDataReviseForm mainForm = new OrderDataReviseForm(order_id);
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
            updateDriverOrderListview();
        }
    }
}



