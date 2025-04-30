using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
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
    public partial class OrderAssignFormBeBe : Form
    {
        public OrderAssignFormBeBe()
        {
            InitializeComponent();
            InputAreaDataToListbox();
            getDriverDataToCombobox();
            area_id_comboBox.SelectedIndex = 0;
            morningorafternoon_combobox.SelectedIndex = 0;
        }

        private ArrayList arrValue;
        public ArrayList ArrValue
        {
            set
            {
                arrValue = value;
            }
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
        private void InputAreaDataToListbox()
        {
            area_id_comboBox.Items.Clear();
            string selectQuery = "SELECT * FROM area";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count != 0)
            {
                area_id_comboBox.Items.Add("全部區域");
                area_id_comboBox.Items.Add("多選區域");
                foreach (DataRow item in datatable.Rows)
                {
                    area_id_comboBox.Items.Add(item[1]);
                }
            }
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
        private string getCustomer(string info, string customer_id)
        {
            string selectQuery = $"SELECT {info} FROM `customer` " +
                    $"WHERE customer_id = '{customer_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null) { return ""; }
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
        private string getAreaID(string customer_id)
        {
            string selectQuery = "SELECT area_id FROM `customer` " +
                    $"WHERE customer_id = '{customer_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            return datatable.Rows[0][0].ToString();
        }
        private string getDriverOrderDeliverDay(string order_id)
        {
            string selectQuery = "SELECT deliver_day FROM driver_order " +
                $"WHERE order_id = '{order_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count == 0) { return ""; }
            return datatable.Rows[0][0].ToString().Split(' ')[0];
        }
        private string getDriverOrderMorningOrAfternoon(string order_id)
        {
            string selectQuery = "SELECT morningorafternoon FROM driver_order " +
                $"WHERE order_id = '{order_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count == 0) { return ""; }
            return datatable.Rows[0][0].ToString();
        }
        private string getOrderTotalQuantity(string order_id)
        {
            string selectQuery = "SELECT product_id, collect_money, give_nofree, product_quantity, give_free FROM `order` " +
                $"WHERE order_id = {order_id}";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            int totalQuantity = 0;

            foreach (DataRow order in datatable.Rows)
            {
                if (getIsJoinReserve(order[0].ToString()) & int.Parse(order[0].ToString()) < 201)
                {
                    if (order[1].ToString() == "預收")
                    {
                        if (order[2].ToString() == "True" & order[4].ToString() == "False")
                        {//預收送水
                            totalQuantity = totalQuantity + int.Parse(order[3].ToString());
                        }
                        else if (order[2].ToString() == "False" & order[4].ToString() == "True")
                        {//儲值贈送

                        }
                        else if (order[2].ToString() == "True" & order[4].ToString() == "True")
                        {//破水補送
                            totalQuantity = totalQuantity + int.Parse(order[3].ToString());
                        }
                        else if (order[2].ToString() == "False" & order[4].ToString() == "False")
                        {//儲值請款

                        }
                    }
                    else
                    {
                        totalQuantity = totalQuantity + int.Parse(order[3].ToString());
                    }
                }
            }
            return totalQuantity.ToString();
        }
        private bool getOrderIsOrderOKFromDriverOrder(string order_id)
        {
            string selectQuery = "SELECT order_OK FROM `driver_order` " +
                $"WHERE order_id = {order_id}";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            return datatable.Rows[0][0].ToString() == "True";
        }
        private string isDriverOrderFull(string driver_id, string deliver_day, string morningorafternoon)
        {
            string selectQuery = "SELECT a.order_num, a.order_quantity, b.* FROM `driver` as a JOIN `driver_order` as b on a.driver_id = b.driver_id " +
                    $"WHERE a.driver_id = '{driver_id}' and b.deliver_day = '{deliver_day}' and b.morningorafternoon = '{morningorafternoon}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows.Count == 0)
            {
                return "False";
            }
            int order_num = int.Parse(datatable.Rows.Count.ToString());
            int order_quqntity = 0;
            int driver_order_num = int.Parse(datatable.Rows[0][0].ToString());
            int driver_order_quantity = int.Parse(datatable.Rows[0][1].ToString());

            foreach (DataRow item in datatable.Rows)
            {
                order_quqntity = order_quqntity + int.Parse(item[4].ToString());
            }

            if (order_num < driver_order_num & order_quqntity < driver_order_quantity)
            {
                return "False";
            }
            else
            {
                return "True";
            }
        }
        private void putOrderToDriverOrder(string driver_id, string order_id, string order_quantity, string customer_name, string recyele_quantity, string pay_money, string order_OK, string deliver_day, string morningorafternoon, string remark)
        {
            string insertQuery =
                "INSERT INTO `driver_order` VALUES " +
                $"('{driver_id}'," +
                $"'{order_id}'," +
                $"'{order_quantity}'," +
                $"'{customer_name}'," +
                $"'{recyele_quantity}'," +
                $"'{pay_money}'," +
                $"'{order_OK}'," +
                $"'{deliver_day}'," +
                $"'{morningorafternoon}'," +
                $"'{remark}')";

            ConnectDatabase("新增", insertQuery);
        }
        private void assign_order(string order_id)
        {
            if (driver_comboBox.Text == "") { return; }
            string selectQuery = "SELECT assign_OK, driver_id, customer_id, remark FROM `order` " +
                $"WHERE order_id = {order_id}";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows[0][0].ToString() == "True" & driver_comboBox.Text == getDriverNameOrID("id", datatable.Rows[0][1].ToString()) & deliver_day_dtp.Value.ToString("yyyy/M/dd") == getDriverOrderDeliverDay(order_id) & morningorafternoon_combobox.Text == getDriverOrderMorningOrAfternoon(order_id))
            {
                DialogResult anser = MessageBox.Show(getCustomer("customer_name", datatable.Rows[0][2].ToString()) + "的派單資料一樣!", "注意", MessageBoxButtons.OKCancel);

                switch (anser)
                {
                    case DialogResult.OK:

                        return;
                    case DialogResult.Cancel:

                        return;
                    default:
                        return;
                }
            }

            if (isDriverOrderFull(getDriverNameOrID("name", driver_comboBox.Text), deliver_day_dtp.Value.ToString("yyyy-MM-dd"), morningorafternoon_combobox.Text) == "True")
            {
                DialogResult anser = MessageBox.Show(driver_comboBox.Text + "的訂單已經滿單，還要再加單嗎?", "注意", MessageBoxButtons.YesNoCancel);

                switch (anser)
                {
                    case DialogResult.Yes:

                        break;
                    case DialogResult.No:

                        return;
                    case DialogResult.Cancel:

                        return;
                    default:
                        return;
                }
            }

            if (getDriverOrderDeliverDay(order_id) != "")
            {
                DialogResult anser = MessageBox.Show("此訂單已經派給司機，要更改司機或日期嗎?", "注意", MessageBoxButtons.YesNoCancel);

                switch (anser)
                {
                    case DialogResult.Yes:

                        string removeQuery =
                            "DELETE FROM `driver_order` WHERE " +
                            $"order_id = '{order_id}'";
                        ConnectDatabase("修改", removeQuery);

                        break;
                    case DialogResult.No:

                        return;
                    case DialogResult.Cancel:

                        return;
                    default:
                        return;
                }
            }

            string reviseQuery =
            "UPDATE `order` SET " +
            "assign_OK = 'True', " +
            $"order_day = '{deliver_day_dtp.Value.ToString("yyyy-MM-dd")}', " +
            $"driver_id = '{getDriverNameOrID("name", driver_comboBox.Text)}' " +
            $"WHERE order_id = '{order_id}'";
            var result = ConnectDatabase("修改", reviseQuery).ToString();
            if (result == "-1")
            {
                MessageBox.Show($"訂單編號{order_id}派單失敗！");
            }
            else
            {
                //MessageBox.Show($"訂單編號{order_id}已經派單完成！");
                //列印訂單
                //printOrder(item.SubItems[0].Text);

                //將訂單送到driver_order
                var order_quantity = getOrderTotalQuantity(order_id);
                var driver_id = getDriverNameOrID("name", driver_comboBox.Text);
                var customer_name = getCustomer("customer_name", datatable.Rows[0][2].ToString());
                var recyele_quantity = "0";
                var pay_money = "0";
                var order_OK = "False";
                var deliver_day = deliver_day_dtp.Value.ToString("yyyy-MM-dd");
                var morningorafternoon = morningorafternoon_combobox.Text;
                var remark = datatable.Rows[0][3].ToString();
                putOrderToDriverOrder(driver_id, order_id, order_quantity, customer_name, recyele_quantity, pay_money, order_OK, deliver_day, morningorafternoon, remark);
            }
            if (customer_id_search_textbox.Text != "")
            {
                updateOrderListview(customer_id_search_textbox.Text);
            }
            else
            {
                updateOrderListview();
            }
            updateDriverProductListview();
            order_id_textbox.Focus();
        }
        private void updateOrderListview()
        {
            if (area_id_comboBox.Text == "") { return; }
            order_listview.Items.Clear();

            var area_2_is_true = area_id_2_checkBox.Checked;

            string sql = "";
            if (area_id_comboBox.Text == "全部區域")
            {
                sql = "";
            }
            else if (area_id_comboBox.Text == "多選區域")
            {
                if (arrValue.Count == 0) { return; }
                foreach (string area in arrValue)
                {
                    string area_id = getAreaNameOrID("name", area);
                    sql = sql + $"cust.area_id = '{area_id}' OR ";
                }
                sql = sql.Substring(0, sql.Length - 4);
                sql = "AND (" + sql + ")";
            }
            else
            {
                string area_id = getAreaNameOrID("name", area_id_comboBox.Text);
                sql = $"AND (cust.area_id = '{area_id}'";
                if (area_2_is_true == true)
                {
                    sql = sql + $" OR cust.area_id_2 = '{area_id}')";
                }
                else
                {
                    sql = sql + $")";
                }
            }

            string selectQuery2 = "SELECT `order`.*, cust.customer_name, are.area_name, cust.customer_address, prod.is_join_reserve, if(driv.driver_name is Null, '', driv.driver_name) as driver_name " +
                ", if(drivOrder.deliver_day is Null, '', drivOrder.deliver_day) as deliver_day, if(drivOrder.morningorafternoon is Null, '', drivOrder.morningorafternoon) as morningorafternoon FROM `order` " +
                "JOIN customer as cust on cust.customer_id = `order`.customer_id " +
                "JOIN product as prod on prod.product_id = `order`.product_id " +
                "LEFT JOIN driver as driv on driv.driver_id = `order`.driver_id " +
                "LEFT JOIN driver_order as drivOrder on drivOrder.order_id = `order`.order_id " +
                $"JOIN area as are on are.area_id = cust.area_id " +
                $"WHERE `order`.order_OK = 'False' {sql} AND `order`.product_id <> '0000' AND " +
                $"if(`order`.product_id = '205', if(`order`.remark = '一般訂單', true, false), true) " +
                "ORDER BY `order`.order_id ASC, `order`.product_index ASC";
            DataTable datatable2 = ConnectDatabase("查詢", selectQuery2) as DataTable;

            int totalQuantity = 0;
            double totalPrice = 0;

            foreach (DataRow order in datatable2.Rows)
            {
                if (order[15].ToString() == "True") { return; }
                if (order_listview.Items.Count == 0) { }
                else
                {
                    if (order_listview.Items[order_listview.Items.Count - 1].Text != order[0].ToString())
                    {
                        totalQuantity = 0;
                        totalPrice = 0;
                    }
                }

                ListViewItem item = new ListViewItem(order[0].ToString());//訂單編號
                item.SubItems.Add(order[1].ToString().Split(' ')[0]);//訂單日期

                item.SubItems.Add(order[24].ToString());//客戶名稱

                item.SubItems.Add(order[26].ToString());//客戶地址

                if (Convert.ToBoolean(order[27]) & int.Parse(order[3].ToString()) < 201)
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
                item.SubItems.Add(totalQuantity.ToString());//送瓶

                if (order[17].ToString() != "月結")
                {
                    totalPrice = totalPrice + int.Parse(order[10].ToString());
                }
                item.SubItems.Add(totalPrice.ToString());//金額

                item.SubItems.Add(order[28].ToString());//司機

                if (order[19].ToString() == "False")
                {
                    item.SubItems.Add("");//派單
                }
                else if (order[19].ToString() == "True")
                {
                    item.SubItems.Add("✔");//派單
                }

                item.SubItems.Add(order[25].ToString());//區域

                item.SubItems.Add(order[29].ToString());//送貨日期

                item.SubItems.Add(order[30].ToString());//班別

                item.SubItems.Add(order[2].ToString() == "1" ? order[11].ToString() : "");//訂單備註

                var index = order_listview.Items.Count;
                if (index == 0)
                {
                    item.SubItems[5].Text = totalPrice.ToString();
                    order_listview.Items.Add(item);
                }
                else
                {
                    if (order_listview.Items[index - 1].Text == order[0].ToString())
                    {
                        order_listview.Items[index - 1].Remove();

                        item.SubItems[5].Text = totalPrice.ToString();
                        order_listview.Items.Add(item);
                    }
                    else
                    {
                        item.SubItems[5].Text = totalPrice.ToString();
                        order_listview.Items.Add(item);
                    }
                }
            }

            //order_listview.Sorting = SortOrder.Ascending;
            //order_listview.ListViewItemSorter = new ListViewItemComparer(0, order_listview.Sorting);
            //order_listview.Sort();
        }
        private void updateOrderListview(string customer_id)
        {
            if (customer_id_search_textbox.Text == "") { return; }
            order_listview.Items.Clear();

            string selectQuery2 = "SELECT * FROM `order` " +
                $"WHERE EXISTS (SELECT * FROM `customer` " +
                $"WHERE customer.customer_id = `order`.customer_id AND `order`.order_OK = 'False' AND `customer`.customer_id_mark = '{customer_id}' " +
                $"AND `order`.product_id <> '0000' AND if(`order`.product_id = '205', if(`order`.remark = '一般訂單', true, false), true) ) " +
                "ORDER BY `order`.order_id DESC, `order`.product_index ASC";
            DataTable datatable2 = ConnectDatabase("查詢", selectQuery2) as DataTable;

            if(datatable2.Rows.Count == 0 | datatable2 == null)
            {
                MessageBox.Show("查無資料");
            }

            int totalQuantity = 0;
            double totalPrice = 0;

            foreach (DataRow order in datatable2.Rows)
            {
                if (order[15].ToString() == "True") { return; }
                if (order_listview.Items.Count == 0) { }
                else
                {
                    if (order_listview.Items[order_listview.Items.Count - 1].Text != order[0].ToString())
                    {
                        totalQuantity = 0;
                        totalPrice = 0;
                    }
                }

                ListViewItem item = new ListViewItem(order[0].ToString());//訂單編號
                item.SubItems.Add(order[1].ToString().Split(' ')[0]);//訂單日期

                item.SubItems.Add(getCustomer("customer_name", order[12].ToString()));//客戶名稱

                item.SubItems.Add(getCustomer("customer_address", order[12].ToString()));//客戶地址

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
                item.SubItems.Add(totalQuantity.ToString());//送瓶

                if (order[17].ToString() != "月結")
                {
                    totalPrice = totalPrice + int.Parse(order[10].ToString());
                }
                item.SubItems.Add(totalPrice.ToString());//金額

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

                item.SubItems.Add(getDriverOrderDeliverDay(order[0].ToString()));//送貨日期

                item.SubItems.Add(getDriverOrderMorningOrAfternoon(order[0].ToString()));//班別

                item.SubItems.Add(order[2].ToString() == "1" ? order[11].ToString() : "");//訂單備註

                var index = order_listview.Items.Count;
                if (index == 0)
                {
                    item.SubItems[5].Text = totalPrice.ToString();
                    order_listview.Items.Add(item);
                }
                else
                {
                    if (order_listview.Items[index - 1].Text == order[0].ToString())
                    {
                        order_listview.Items[index - 1].Remove();

                        item.SubItems[5].Text = totalPrice.ToString();
                        order_listview.Items.Add(item);
                    }
                    else
                    {
                        item.SubItems[5].Text = totalPrice.ToString();
                        order_listview.Items.Add(item);
                    }
                }
            }

            //order_listview.Sorting = SortOrder.Ascending;
            //order_listview.ListViewItemSorter = new ListViewItemComparer(0, order_listview.Sorting);
            //order_listview.Sort();
        }
        private void updateDriverProductListview()
        {
            if (driver_comboBox.Text == "") { return; }

            driver_product_listview.Items.Clear();
            order_number_textbox.Text = "";
            product_number_textbox.Text = "";
            var quantity = 0;
            string selectQuery = "SELECT order_id FROM `driver_order` " +
                $"WHERE driver_id = '{getDriverNameOrID("name", driver_comboBox.Text)}' " +
                $"AND deliver_day = '{deliver_day_dtp.Value.ToString("yyyy-MM-dd")}' " +
                $"AND morningorafternoon = '{morningorafternoon_combobox.Text}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if ( datatable == null || datatable.Rows.Count == 0) { return; }
            string all_order_id = "";

            foreach (DataRow order in datatable.Rows)
            {
                all_order_id += "order_id = '" + order[0].ToString() + "' OR ";
            }
            all_order_id = all_order_id.Substring(0, all_order_id.Length - 4);
            string selectQuery2 = "SELECT product_name, SUM(product_quantity), product_id FROM `order` " +
            $"WHERE {all_order_id} " +
            "GROUP BY product_name, product_id";
            DataTable datatable2 = ConnectDatabase("查詢", selectQuery2) as DataTable;
            foreach (DataRow order in datatable2.Rows)
            {
                ListViewItem item = new ListViewItem(order[0].ToString());
                item.SubItems.Add(order[1].ToString());
                if (int.Parse(order[2].ToString()) < 201 && order[2].ToString() != "000" && order[2].ToString() != "0000")
                {
                    if (order[0].ToString().Contains("(請款)"))
                    {
                        
                    }
                    else
                    {
                        quantity += int.Parse(order[1].ToString());
                    }
                }
                
                driver_product_listview.Items.Add(item);
            }

            driver_product_listview.Sorting = SortOrder.Ascending;
            driver_product_listview.ListViewItemSorter = new ListViewItemComparer(0, driver_product_listview.Sorting);
            driver_product_listview.Sort();

            order_number_textbox.Text = datatable.Rows.Count.ToString();
            product_number_textbox.Text = quantity.ToString();
        }
        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void order_search_btn_Click(object sender, EventArgs e)
        {
            if (area_id_comboBox.Text == "") { return; }
            if (area_id_comboBox.Text == "多選區域")
            {
                order_listview.Items.Clear();
                return;
            }
            else if (area_id_comboBox.Text == "全部區域")
            {
                updateOrderListview();
                return;
            }
            updateOrderListview();
        }
        private void search_area_btn_Click(object sender, EventArgs e)
        {
            if (arrValue != null)
            {
                arrValue.Clear();
            }
            OrderAssignAreaSelecterForm mainForm = new OrderAssignAreaSelecterForm();
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
            area_id_comboBox.SelectedIndex = 1;
            updateOrderListview();
        }
        private void order_id_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter){
                int order_listview_count = order_listview.Items.Count;
                for (int i = 0; i < order_listview_count; i++)
                {
                    if (order_listview.Items[i].Text == order_id_textbox.Text)
                    {
                        assign_order(order_id_textbox.Text);
                        order_id_textbox.SelectAll();
                        return;
                    }
                }
                MessageBox.Show("未搜尋到此訂單！");
                order_id_textbox.SelectAll();
                order_id_textbox.Focus();
            }
        }
        private void order_id_textbox_Enter(object sender, EventArgs e)
        {
            //當order_textbox被focus的時候把輸入法改成英文
            this.order_id_textbox.ImeMode = System.Windows.Forms.ImeMode.Disable;
        }
        private void order_listview_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (order_listview.Sorting == SortOrder.Ascending)
            {
                order_listview.Sorting = SortOrder.Descending;
            }
            else
            {
                order_listview.Sorting = SortOrder.Ascending;
            }

            order_listview.ListViewItemSorter = new ListViewItemComparer(e.Column, order_listview.Sorting);
            order_listview.Sort();
        }
        private void area_id_2_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            updateOrderListview();
        }
        private void driver_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDriverProductListview();
        }
        private void order_listview_DoubleClick(object sender, EventArgs e)
        {
            if(driver_comboBox.Text == "") { return; }
            assign_order(order_listview.SelectedItems[0].SubItems[0].Text);
        }

        private void customer_id_search_btn_Click(object sender, EventArgs e)
        {
            string customer_id = customer_id_search_textbox.Text;

            updateOrderListview(customer_id);
        }

        private void assign_btn_Click(object sender, EventArgs e)
        {
            if (driver_comboBox.Text == "") { return; }

            int order_listview_count = order_listview.Items.Count;
            for (int i = 0; i < order_listview_count; i++)
            {
                if (order_listview.Items[i].Text == order_id_textbox.Text)
                {
                    assign_order(order_id_textbox.Text);
                    order_id_textbox.SelectAll();
                    return;
                }
            }
            MessageBox.Show("未搜尋到此訂單！");
            order_id_textbox.SelectAll();
            order_id_textbox.Focus();
        }

        private void cancel_assign_btn_Click(object sender, EventArgs e)
        {
            if (order_listview.SelectedItems.Count == 0 & order_id_textbox.Text == "") { return ; }
            if (order_listview.SelectedItems.Count != 0)
            {
                string order_id = order_listview.SelectedItems[0].SubItems[0].Text;
                if (getOrderIsOrderOKFromDriverOrder(order_id) == true)
                {
                    MessageBox.Show("不可取消已送達的訂單");
                    return;
                }

                string reviseQuery =
                    "UPDATE `order` SET " +
                    "assign_OK = 'False', " +
                    "order_day = order_id_day, " +
                    "driver_id = '' " +
                    $"WHERE order_id = '{order_id}'";
                var result = ConnectDatabase("修改", reviseQuery).ToString();

                string removeQuery =
                    "DELETE FROM `driver_order` WHERE " +
                    $"order_id = '{order_id}'";
                var result1 =  ConnectDatabase("修改", removeQuery).ToString();
                if (result == "-1" | result1 == "-1")
                {
                    MessageBox.Show($"取消訂單編號{order_id}派單失敗！");
                }
                else
                {
                    MessageBox.Show($"取消訂單編號{order_id}派單成功！");
                }
                updateOrderListview();
                return;
            }
            else if(order_id_textbox.Text != "")
            {
                string order_id = order_id_textbox.Text;

                if (getOrderIsOrderOKFromDriverOrder(order_id) == true)
                {
                    MessageBox.Show("不可取消已送達的訂單");
                    return;
                }

                string reviseQuery =
                    "UPDATE `order` SET " +
                    "assign_OK = 'False', " +
                    "order_day = order_id_day, " +
                    "driver_id = '' " +
                    $"WHERE order_id = '{order_id}'";
                var result = ConnectDatabase("修改", reviseQuery).ToString();

                string removeQuery =
                    "DELETE FROM `driver_order` WHERE " +
                    $"order_id = '{order_id}'";
                var result1 = ConnectDatabase("修改", removeQuery).ToString();
                if (result == "-1" | result1 == "-1")
                {
                    MessageBox.Show($"取消訂單編號{order_id}派單失敗！");
                }
                else
                {
                    MessageBox.Show($"取消訂單編號{order_id}派單成功！");
                }
                updateOrderListview();
                return;
            }
            else
            {
                MessageBox.Show("請選擇要取消的訂單");
            }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void deliver_day_dtp_ValueChanged(object sender, EventArgs e)
        {
            updateDriverProductListview();
        }

        private void OrderAssignFormBeBe_Resize(object sender, EventArgs e)
        {
            int totalWidth = order_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                order_listview.Columns[0].Width = (int)(totalWidth * 0.1); // 第一欄占 30%
                order_listview.Columns[1].Width = (int)(totalWidth * 0.0833); // 第二欄占 30%
                order_listview.Columns[2].Width = (int)(totalWidth * 0.15); // 第三欄占 40%
                order_listview.Columns[3].Width = (int)(totalWidth * 0.15); // 第一欄占 30%
                order_listview.Columns[4].Width = (int)(totalWidth * 0.0375); // 第二欄占 30%
                order_listview.Columns[5].Width = (int)(totalWidth * 0.0541); // 第三欄占 40%
                order_listview.Columns[6].Width = (int)(totalWidth * 0.0583); // 第三欄占 40%
                order_listview.Columns[7].Width = (int)(totalWidth * 0.0416); // 第三欄占 40%
                order_listview.Columns[8].Width = (int)(totalWidth * 0.075); // 第一欄占 30%
                order_listview.Columns[9].Width = (int)(totalWidth * 0.0833); // 第二欄占 30%
                order_listview.Columns[10].Width = (int)(totalWidth * 0.0416); // 第三欄占 40%
                order_listview.Columns[11].Width = (int)(totalWidth * 0.15); // 第三欄占 40%
            }

            int totalWidth1 = driver_product_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth1 > 0)
            {
                driver_product_listview.Columns[0].Width = (int)(totalWidth1 * 0.3116); // 第一欄占 30%
                driver_product_listview.Columns[1].Width = (int)(totalWidth1 * 0.2077); // 第二欄占 30%
            }
        }
    }

    //Listview排序
    public class ListViewItemComparer : IComparer
    {

        private int col;

        private SortOrder order;
        public ListViewItemComparer()
        {
            col = 0;
            order = SortOrder.Ascending;
        }

        public ListViewItemComparer(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }

        public int Compare(object x, object y)
        {
            int returnVal = -1;
            double a = 0, b = 0;

            try
            {
                if (double.TryParse(((ListViewItem)x).SubItems[col].Text, out a) && double.TryParse(((ListViewItem)y).SubItems[col].Text, out b))
                {
                    returnVal = a >= b ? (a == b ? 0 : 1) : -1;
                    if (order == SortOrder.Descending)
                    {
                        returnVal *= -1;
                    }
                }
                else
                {
                    returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
                    // Determine whether the sort order is descending.
                    if (order == SortOrder.Descending)
                    {
                        // Invert the value returned by String.Compare.
                        returnVal *= -1;
                    }
                }
            }
            catch (Exception ex)
            {
                //do nothing
            }
            return returnVal;
        }
    }
}
