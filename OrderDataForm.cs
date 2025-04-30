using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace 超好企業系統
{
    public partial class OrderDataForm : Form
    {
        public OrderDataForm()
        {
            InitializeComponent();
            this.order_dataGridView.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e) { };
            search_comboBox.SelectedIndex = 0;
            newOrderID(dateTimePicker.Value.ToString("yyyy/MM/dd"));
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
        private string getCustomer(string info, string customer_id)
        {
            string selectQuery = $"SELECT {info} FROM `customer` " +
                    $"WHERE customer_id = '{customer_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null) { return ""; }
            return datatable.Rows[0][0].ToString();
        }
        private string getAnnouncement()
        {
            string selectQuery = $"SELECT announcementcol_content FROM `announcement` " +
                $"WHERE announcement_using = 'True' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            return datatable.Rows[0][0].ToString();
        }
        private void inputAddDataToAddCombo(string customer_id)
        {
            string customer_id_mark = customer_id.Contains("-") ? customer_id.Split('-')[0] : customer_id;
            string index = customer_id.Contains("-") ? customer_id.Split('-')[1] : "0";
            string selectQuery = "SELECT customer_address FROM customer " +
                $"WHERE customer_id_mark = '{customer_id_mark}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            customer_address_comboBox.Items.Clear();
            foreach (DataRow item in datatable.Rows)
            {
                customer_address_comboBox.Items.Add(item[0].ToString());
            }
            customer_address_comboBox.SelectedIndex = int.Parse(index);
            if (datatable.Rows.Count > 1)
            {
                timer1.Stop();
                CustomerAddressSelect mainForm = new CustomerAddressSelect(datatable);
                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                mainForm.ShowDialog();
                customer_address_comboBox.SelectedIndex = int.Parse(addressIndex);

                string customer_id2 = addressIndex == "0" ? customer_id_mark : customer_id_mark + "-" +addressIndex;
                
                string selectQuery2 = "SELECT * FROM customer " +
                             $"WHERE customer_id = '{customer_id2}'";
                DataTable datatable2 = ConnectDatabase("查詢", selectQuery2) as DataTable;
                if (datatable2 == null) { return; }
                if (datatable2 != null & datatable2.Rows.Count != 0)
                {
                    customer_id_textBox.Text = datatable2.Rows[0][0].ToString();
                    customer_name_textbox.Text = datatable2.Rows[0][1].ToString();
                    //inputAddDataToAddCombo(datatable.Rows[0][0].ToString());
                    customer_telephone_textbox.Text = datatable2.Rows[0][5].ToString();
                    bill_form_textBox.Text = datatable2.Rows[0][6].ToString();
                    customer_invoice_textbox.Text = datatable2.Rows[0][7].ToString();
                    collect_money_comboBox.Text = datatable2.Rows[0][9].ToString();
                    bucket_textBox.Text = datatable2.Rows[0][10].ToString();
                    remain_textBox.Text = datatable2.Rows[0][11].ToString();
                    collect_money_comboBox.Enabled = false;
                    customer_remark_textBox.Text = datatable2.Rows[0][15].ToString();
                    company_comboBox.Text = datatable2.Rows[0][14].ToString();
                    inputOverShortMoney(datatable2.Rows[0][0].ToString());
                    isHaveCustomerMemoNotFinish(customer_id_textBox.Text);
                }
                else
                {
                    customer_id_textBox.Text = "";
                    customer_name_textbox.Text = "";
                    //customer_address_comboBox.Items.Clear();
                    customer_telephone_textbox.Text = "";
                    bill_form_textBox.Text = "";
                    customer_invoice_textbox.Text = "";
                    collect_money_comboBox.Text = "";
                    bucket_textBox.Text = "";
                    remain_textBox.Text = "";
                    collect_money_comboBox.Enabled = false;
                    customer_remark_textBox.Text = "";
                    company_comboBox.Text = "";
                    over_short_textBox.Text = "";
                }

                isHaveDispenser();
                updateOrderListview();
                updateMonthCollectOrderListview();

                timer1.Start();
            }
        }
        private void inputOverShortMoney(string customer_id)
        {
            string selectQuery = "SELECT SUM(money) FROM money_over_short " +
                $"WHERE customer_id = '{customer_id}' " +
                $"GROUP BY customer_id";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if(datatable == null || datatable.Rows.Count == 0)
            {
                over_short_textBox.Text = "0";
            }
            else
            {
                over_short_textBox.Text = datatable.Rows[0][0].ToString();
            }
            
        }
        private void changeOrderListViewColumns()
        {
            string collect_money = collect_money_comboBox.Text;
            if (collect_money == "月結")
            {
                order_listview.Columns[9].Text = "結帳";
            }
            else
            {
                order_listview.Columns[9].Text = "收款";
            }
        }
        private void isHaveCustomerMemoNotFinish(string customer_id)
        {
            //檢查是否有客戶備忘錄未完成的資料
            string selectQuery = "SELECT memo_content FROM `customer_memo` " +
                $"WHERE customer_id = '{customer_id}' AND memo_finish = 'False'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null) { return; }
            if (datatable != null & datatable.Rows.Count != 0)
            {
                MessageBox.Show($"有【{datatable.Rows.Count}】筆備忘錄的資料未完成喔!!");
            }
            else
            {
            }
        }
        private void getClientData()
        {
            newOrderID(dateTimePicker.Value.ToString("yyyy/MM/dd"));
            customer_address_comboBox.SelectedIndexChanged -= customer_address_comboBox_SelectedIndexChanged;
            var textbox = search_textBox.Text;
            if (textbox == "")
            {
                customer_id_textBox.Text = "";
                customer_name_textbox.Text = "";
                customer_address_comboBox.Items.Clear();
                customer_telephone_textbox.Text = "";
                bill_form_textBox.Text = "";
                customer_invoice_textbox.Text = "";
                collect_money_comboBox.Text = "";
                bucket_textBox.Text = "";
                remain_textBox.Text = "";
                collect_money_comboBox.Enabled = false;
                customer_remark_textBox.Text = "";
                company_comboBox.Text = "";
                over_short_textBox.Text = "";
                changeOrderListViewColumns();
                customer_address_comboBox.SelectedIndexChanged += customer_address_comboBox_SelectedIndexChanged;
                return;
            }

            string selectQuery = "";

            switch (search_comboBox.Text)
            {
                case "全部搜尋":
                    selectQuery = "SELECT * FROM customer " +
                         $"WHERE customer_id LIKE '%{textbox}%' OR " +
                         $"customer_name LIKE '%{textbox}%' OR " +
                         $"customer_telephone LIKE '%{textbox}%' OR " +
                         $"customer_phone LIKE '%{textbox}%' OR " +
                         $"customer_invoice LIKE '%{textbox}%' OR "+
                         $"customer_address LIKE '%{textbox}%'";
                    break;
                case "客戶編號":
                    selectQuery = "SELECT * FROM customer " +
                        $"WHERE customer_id LIKE '%{textbox}%'";
                    break;
                case "客戶名稱":
                    selectQuery = "SELECT * FROM customer " +
                        $"WHERE customer_name LIKE '%{textbox}%'";
                    break;
                case "客戶電話":
                    selectQuery = "SELECT * FROM customer " +
                        $"WHERE customer_telephone LIKE '%{textbox}%' "+
                        $"OR customer_phone LIKE '%{textbox}%'";
                    break;
                case "統一編號":
                    selectQuery = "SELECT * FROM customer " +
                        $"WHERE customer_invoice LIKE '%{textbox}%' ";
                    break;
                case "客戶地址":
                    selectQuery = "SELECT * FROM customer " +
                        $"WHERE customer_address LIKE '%{textbox}%'";
                    break;
                default:

                    break;
            }

            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null) { return; }
            if (datatable != null & datatable.Rows.Count != 0)
            {
                customer_id_textBox.Text = datatable.Rows[0][0].ToString();
                customer_name_textbox.Text = datatable.Rows[0][1].ToString();
                customer_telephone_textbox.Text = datatable.Rows[0][5].ToString();
                bill_form_textBox.Text = datatable.Rows[0][6].ToString();
                customer_invoice_textbox.Text = datatable.Rows[0][7].ToString();
                collect_money_comboBox.Text = datatable.Rows[0][9].ToString();
                bucket_textBox.Text = datatable.Rows[0][10].ToString();
                remain_textBox.Text = datatable.Rows[0][11].ToString();
                collect_money_comboBox.Enabled = false;
                customer_remark_textBox.Text = datatable.Rows[0][15].ToString();
                company_comboBox.Text = datatable.Rows[0][14].ToString();
                inputOverShortMoney(datatable.Rows[0][0].ToString());
                inputAddDataToAddCombo(datatable.Rows[0][0].ToString());
            }
            else
            {
                customer_id_textBox.Text = "";
                customer_name_textbox.Text = "";
                customer_address_comboBox.Items.Clear();
                customer_telephone_textbox.Text = "";
                bill_form_textBox.Text = "";
                customer_invoice_textbox.Text = "";
                collect_money_comboBox.Text = "";
                bucket_textBox.Text = "";
                remain_textBox.Text = "";
                collect_money_comboBox.Enabled = false;
                customer_remark_textBox.Text = "";
                company_comboBox.Text = "";
                over_short_textBox.Text = "";
            }
            changeOrderListViewColumns();
            customer_address_comboBox.SelectedIndexChanged += customer_address_comboBox_SelectedIndexChanged;
        }
        private bool getIsJoinTex(string product_id)
        {
            string selectQuery = "SELECT is_join_tex FROM product " +
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
        private void newOrderID(string order_day)
        {
            string selectQuery = "SELECT order_id FROM `order` " +
                $"WHERE order_id_day = '{order_day}' " +
                "ORDER BY order_id DESC LIMIT 0 , 1";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count == 0)
            {
                order_id_textbox.Text = order_day.Replace("/","") + "0001";
                return;
            }
            var order_id = datatable.Rows[0][0].ToString();
            if (order_id.Substring(0, 8) == order_day.Replace("/", ""))
            {
                order_id_textbox.Text = (long.Parse(order_id) + 1).ToString();
            }
            else
            {
                order_id_textbox.Text = order_day.Replace("/", "") + "0001";
            }
        }
        private void allTextClear()
        {
            newOrderID(dateTimePicker.Value.ToString("yyyy/MM/dd"));
            search_comboBox.SelectedIndex = 0;
            search_textBox.Text = "";
            customer_id_textBox.Text = "";
            customer_name_textbox.Text = "";
            customer_address_comboBox.Items.Clear();
            customer_telephone_textbox.Text = "";
            bill_form_textBox.Text = "";
            customer_invoice_textbox.Text = "";
            collect_money_comboBox.Text = "";
            bucket_textBox.Text = "";
            remain_textBox.Text = "";
            collect_money_comboBox.Enabled = false;
            over_short_textBox.Text = "";
            changeOrderListViewColumns();

            bill_number_textBox.Text = "";
            tex_textBox.Text = "";
            total_textBox.Text = "";
            order_dataGridView.Rows.Clear();
            order_dataGridView.Enabled = false;
        }
        private string getSelectMonthCollectAddress(string customer_id_mark)
        {
            string selectQuery = "SELECT customer_address FROM customer " +
                $"WHERE customer_id_mark = '{customer_id_mark}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows.Count > 1)
            {
                timer1.Stop();
                CustomerAddressSelect mainForm = new CustomerAddressSelect(datatable);
                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                mainForm.ShowDialog();

                string customer_id2 = addressIndex == "0" ? customer_id_mark : customer_id_mark + "-" + addressIndex;

                timer1.Start();
                return customer_id2;
            }
            else
            {
                return customer_id_mark;
            }
        }
        private string getLastTimeQuantity(string order_id)
        {
            string lastTimeQuantity = "";
            if (order_listview.Items.Count == 0)
            {
                return "";
            }
            string lastOrderID = order_listview.Items[0].SubItems[0].Text;
            
            if (order_id == lastOrderID)
            {
                if (order_listview.Items.Count == 1)
                {
                    return "";
                }
                else
                {
                    lastTimeQuantity = order_listview.Items[1].SubItems[3].Text;
                }
            }
            else
            {
                lastTimeQuantity = order_listview.Items[0].SubItems[3].Text;
            }

            return lastTimeQuantity;
        }
        private string getLastTimeOrderDay(string order_id)
        {
            string lastTimeDay = "";
            if (order_listview.Items.Count == 0)
            {
                return "";
            }
            string lastOrderID = order_listview.Items[0].SubItems[0].Text;

            if (order_id == lastOrderID)
            {
                if (order_listview.Items.Count == 1)
                {
                    return "";
                }
                else
                {
                    lastTimeDay = DateTime.Parse( order_listview.Items[1].SubItems[1].Text ).ToString("MM/dd");
                }
            }
            else
            {
                lastTimeDay = DateTime.Parse(order_listview.Items[0].SubItems[1].Text).ToString("MM/dd");
            }

            return lastTimeDay;
        }
        private string getMonthTotalMoney(string search_customer_id, string day, string search_info)
        {
            string selectQuery = "SELECT SUM(o2.subtotal) as 金額 FROM `order` as o2 " +
                $"WHERE o2.customer_id in (select c.customer_id from `customer` as c where c.{search_info} = '{search_customer_id}') " +
                $"AND o2.order_OK = 'True' AND o2.collect_OK = 'False' AND o2.collect_money = '月結' AND o2.order_day <= '{day}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable == null)
            {
                return "-1";
            }
            else
            {
                return datatable.Rows[0][0].ToString();
            }
        }
        private string getMonthTotalTex(string search_customer_id, string day, string search_info)
        {
            string selectQuery = "SELECT SUM(o2.tex) as 金額 FROM `order` as o2 " +
                $"WHERE o2.customer_id in (select c.customer_id from `customer` as c where c.{search_info} = '{search_customer_id}') " +
                $"AND o2.order_OK = 'True' AND o2.collect_OK = 'False' AND o2.collect_money = '月結' AND o2.order_day <= '{day}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable == null)
            {
                return "-1";
            }
            else
            {
                return datatable.Rows[0][0].ToString();
            }
        }
        private List<Order> getOrdersWhereCollectIsMonth(string order_id)
        {
            List<Order> orders = new List<Order>();
            string selectQuery = "SELECT product_index, product_name, product_price, product_quantity, subtotal FROM `order` " +
                $"WHERE order_id = {order_id} AND collect_money = '月結'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            foreach (DataRow row in datatable.Rows)
            {
                string Id = "";
                string Day = "";
                string ProductIndex = row[0].ToString();
                string ProductID = "";
                string ProductName = row[1].ToString();
                string Price = row[2].ToString();
                string Quantity = row[3].ToString();
                string GiveFree = "";
                string GiveNoFree = "";
                string Tex = "";
                string SubTotal = row[4].ToString();
                string Remark = "";
                string Customer = "";
                string CustomerBillForm = "";
                string Driver = "";
                string IsOK = "";
                string RecycleQuantity = "";
                string CollectMoney = "";
                string CollectOK = "";
                string Assign_OK = "";
                string DriverChange = "";
                string BillNumber = "";
                string OrderIDDay = "";
                string Maker = "";
                Order order = new Order(Id, Day, ProductIndex, ProductID, ProductName, Price, Quantity, GiveFree, GiveNoFree, Tex, SubTotal, Remark, Customer, CustomerBillForm, Driver, IsOK, RecycleQuantity, CollectMoney, CollectOK, Assign_OK, DriverChange, BillNumber, OrderIDDay, Maker);
                orders.Add(order);
            }

            return orders;
        }
        private List<string> collect_OK_False_List(string customer_id)
        {
            string selectQuery = "SELECT order_id FROM `order` " +
                $"WHERE customer_id = '{customer_id}' " +
                "AND (( collect_OK = 'False' AND collect_money != '月結' AND order_OK = 'True') OR (collect_OK = 'False' AND product_name = '月結單'))";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            List<string> list = new List<string>();
            foreach (DataRow item in datatable.Rows)
            {
                list.Add(item[0].ToString());
            }
            list = list.Distinct().ToList();
            return list;
        }
        private List<string> isJoinOtherAddCollectFalseOrder(string customer_id)
        {
            string customer_id_mark = customer_id.Contains("-") ? customer_id.Split('-')[0] : customer_id;
            List<string> list = new List<string>();
            string selectQuery = "SELECT customer_id FROM `customer` " +
                $"WHERE customer_id_mark = {customer_id_mark} ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count == 0 || datatable.Rows.Count == 1 || datatable == null) { return list; }
            string sql = "";
            foreach (DataRow item in datatable.Rows)
            {
                if (item[0].ToString() != customer_id)
                {
                    sql += $",'{item[0].ToString()}'";
                }
            }
            sql = "(" + sql.Remove(0, 1) + ")";
            string selectQuery1 = "SELECT order_id FROM `order` " +
                $"WHERE customer_id in {sql} AND order_OK = 'True' AND collect_OK = 'False' AND collect_money != '月結' AND product_name != '月結單'";
            DataTable datatable1 = ConnectDatabase("查詢", selectQuery1) as DataTable;
            
            foreach (DataRow item in datatable1.Rows)
            {
                list.Add(item[0].ToString());
            }
            list = list.Distinct().ToList();
            return list;
        }
        private bool CheckForDuplicateOrder(string orderDate, string customerId)
        {
            // 這裡可以實作檢查資料庫中是否有相同日期和客戶編號的訂單
            // 返回 true 表示有重複訂單，false 表示沒有
            string query = $"SELECT COUNT(*) FROM `order` WHERE `order_day` = '{orderDate}' AND `customer_id` = '{customerId}'";
            DataTable result = ConnectDatabase("查詢", query) as DataTable;
            return Convert.ToInt32(result.Rows[0][0]) > 0;
        }
        private string collectFalseTotalMoney(string order_id)
        {
            string selectQuery = "SELECT subtotal  FROM `order` " +
                $"WHERE order_id = '{order_id}' AND collect_money != '月結' AND collect_OK = 'False'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            Double total = 0;
            foreach (DataRow item in datatable.Rows)
            {
                total = total + int.Parse(item[0].ToString());
            }
            return total.ToString();
        }
        private string getOrderProductName(string order_id)
        {
            string selectQuery = "SELECT product_id, DATE_FORMAT(order_day,'%Y-%m-%d')  FROM `order` " +
                $"WHERE order_id = '{order_id}' AND collect_money != '月結' AND collect_OK = 'False' " +
                $"GROUP BY product_id, order_day";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            string answer = "未收款項" + datatable.Rows[0][1].ToString();
            foreach (DataRow item in datatable.Rows)
            {
                if (item[0].ToString() == "0000")
                {
                    answer = "未收款月結單" + item[1].ToString();
                }
            }
            return answer;
        }
        private string getMorningOrAfternoon(string order_id)
        {
            string selectQuery = "SELECT morningorafternoon FROM report_day " +
             $"WHERE order_id = '{order_id}' and product_name <> '短溢收' and product_index = '1'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            return datatable.Rows[0][0].ToString();
        }
        private void isHaveDispenser()
        {
            if (customer_id_textBox.Text == "") { return; }
            string selectQuery = "SELECT * FROM `water_dispenser_list` " +
                $"WHERE customer_id = '{customer_id_textBox.Text}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows.Count == 0 || datatable == null) { return; }
            foreach(DataRow item in datatable.Rows)
            {
                if (item[11].ToString() == "True" && item[10].ToString() == "")
                {
                    timer1.Stop();
                    DialogResult result =  MessageBox.Show("飲水機已經維修完成！可以送回給客戶!", "飲水機維修", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        timer1.Start();
                    }
                    else
                    {
                        timer1.Start();
                    }
                }
            }
        }
        private string GenerateSerial(string keyName)
        {
            string today = dateTimePicker.Value.ToString("yyyyMMdd");
            string insertOrUpdateSql = $@"
                INSERT INTO serial_generators (key_name, date_key, last_serial)
                VALUES ('{keyName}', '{today}', 1)
                ON DUPLICATE KEY UPDATE last_serial = last_serial + 1";

            // 執行新增或更新
            ConnectDatabase("新增", insertOrUpdateSql);

            // 查詢更新後的流水號
            string selectSql = $@"
                SELECT last_serial FROM serial_generators
                WHERE key_name = '{keyName}' AND date_key = '{today}'";

            DataTable result = (DataTable)ConnectDatabase("查詢", selectSql);
            if (result.Rows.Count > 0)
            {
                int serial = Convert.ToInt32(result.Rows[0]["last_serial"]);
                return today + serial.ToString().PadLeft(4, '0');
            }

            // 查不到就回傳預設序號
            return today + "0001";
        }



        private void printOrder(string order_id)
        {
            string selectQuery = "SELECT * FROM `order` " +
                $"WHERE order_id = '{order_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows.Count == 0 | datatable == null)
            {
                MessageBox.Show("列印查無資料");
            }

            CultureInfo culture = new CultureInfo("zh-TW");
            culture.DateTimeFormat.Calendar = new TaiwanCalendar();

            int total = 0;
            int tex = 0;
            foreach (DataRow item in datatable.Rows)
            {
                total += Convert.ToInt32(item[10]);
                tex += Convert.ToInt32(item[9]);
            }

            PrintCustomer printCustomer = new PrintCustomer();
            printCustomer.Customer_id = datatable.Rows[0][12].ToString();
            printCustomer.Customer_name = getCustomer("customer_name", datatable.Rows[0][12].ToString()) + "    (" + datatable.Rows[0][17].ToString() + ")";
            printCustomer.Customer_address = getCustomer("customer_address", datatable.Rows[0][12].ToString());
            printCustomer.Customer_remark = getCustomer("customer_remark", datatable.Rows[0][12].ToString());
            printCustomer.Customer_invoice = getCustomer("customer_invoice", datatable.Rows[0][12].ToString());
            printCustomer.Customer_telephone = getCustomer("customer_telephone", datatable.Rows[0][12].ToString());
            printCustomer.Order_id = order_id;
            printCustomer.Date = dateTimePicker.Value.ToString("yyy      MM     dd", culture);
            printCustomer.Product_remark = datatable.Rows[0][11].ToString();
            if (datatable.Rows[0][17].ToString() == "月結")
            {
                total = 0;
                tex = 0;
            }
            printCustomer.Total = total.ToString();
            printCustomer.Tex = tex.ToString();
            printCustomer.Announcement = getAnnouncement();
            printCustomer.Driver_name = "";
            printCustomer.Remain = getCustomer("customer_remain", datatable.Rows[0][12].ToString());
            printCustomer.Bucket = getCustomer("customer_bucket", datatable.Rows[0][12].ToString());
            printCustomer.LastTimeQuantity = getLastTimeQuantity(order_id);
            printCustomer.LastTimeOrderDay = getLastTimeOrderDay(order_id);

            List<PrintOrder> printOrders = new List<PrintOrder>();
            foreach (DataRow item in datatable.Rows)
            {
                PrintOrder printOrder = new PrintOrder();
                printOrder.ProductID = item[3].ToString();
                printOrder.ProductName = item[4].ToString();
                int order_subtotal = int.Parse(item[10].ToString()) - int.Parse(item[9].ToString());

                if (int.Parse(item[3].ToString()) <= 200)
                {
                    //司機可修改
                    if (item[20].ToString() == "True")
                    {
                        if (item[17].ToString() == "月結")
                        {
                            printOrder.ProductPrice = "";
                            printOrder.ProductQuantity = item[6].ToString();
                            printOrder.Subtotal = "";
                        }
                        else if (item[17].ToString() == "預收")
                        {
                            if (item[4].ToString().Contains("請款"))
                            {
                                printOrder.ProductPrice = item[5].ToString();
                                printOrder.ProductQuantity = item[6].ToString();
                                printOrder.Subtotal = order_subtotal.ToString();
                            }
                            else
                            {
                                printOrder.ProductPrice = "";
                                printOrder.ProductQuantity = item[6].ToString();
                                printOrder.Subtotal = "";
                            }
                        }
                        else if (item[17].ToString() == "現金")
                        {
                            printOrder.ProductPrice = item[5].ToString();
                            printOrder.ProductQuantity = item[6].ToString();
                            printOrder.Subtotal = order_subtotal.ToString();
                        }
                    }
                    else
                    {
                        if (item[17].ToString() == "月結")
                        {
                            printOrder.ProductPrice = "";
                            printOrder.ProductQuantity = item[6].ToString();
                            printOrder.Subtotal = "";
                        }
                        else if (item[17].ToString() == "預收")
                        {
                            if (item[4].ToString().Contains("請款"))
                            {
                                printOrder.ProductPrice = item[5].ToString();
                                printOrder.ProductQuantity = item[6].ToString();
                                printOrder.Subtotal = order_subtotal.ToString();
                            }
                            else
                            {
                                printOrder.ProductPrice = "";
                                printOrder.ProductQuantity = item[6].ToString();
                                printOrder.Subtotal = "";
                            }
                        }
                        else if (item[17].ToString() == "現金")
                        {
                            printOrder.ProductPrice = item[5].ToString();
                            printOrder.ProductQuantity = item[6].ToString();
                            printOrder.Subtotal = order_subtotal.ToString();
                        }
                    }

                    if (item[6].ToString() == "0")
                    {
                        printOrder.ProductQuantity = "";
                        printOrder.Subtotal = "";
                    }
                }
                else
                {
                    //其他商品
                    printOrder.ProductPrice = item[5].ToString();
                    printOrder.ProductQuantity = item[6].ToString();
                    printOrder.Subtotal = order_subtotal.ToString();
                }

                if (total.ToString() == "0" && tex.ToString() == "0")
                {
                    printCustomer.Total = "";
                    printCustomer.Tex = "";
                }

                printOrders.Add(printOrder);
            }

            PrintHelper printHelper = new PrintHelper(printOrders, printCustomer);
            printHelper.printPreview217();
        }
        private void printMonthMoneyOrder(string search_customer_id, string day, string search_info)
        {
            List<PrintMonthOrder> printMonthOrders = new List<PrintMonthOrder>();
            string selectQuery = "SELECT o2.order_id, o2.order_day, SUM(o2.subtotal), c2.customer_id, c2.customer_name, c2.customer_telephone, c2.customer_bill_form, c2.customer_invoice " +
                "FROM `order` as o2 " +
                "JOIN `customer` as c2 " +
                $"WHERE c2.{search_info} = '{search_customer_id}' AND o2.customer_id = c2.customer_id AND o2.order_OK = 'True' AND o2.collect_OK = 'False' AND o2.collect_money = '月結' AND o2.order_day <= '{day}' " +
                "GROUP BY o2.order_id, o2.customer_id, o2.order_day";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            foreach (DataRow row in datatable.Rows)
            {
                PrintMonthOrder printMonthOrder = new PrintMonthOrder();
                printMonthOrder.Order_id = row[0].ToString();
                printMonthOrder.Order_date = row[1].ToString().Split(' ')[0];
                printMonthOrder.Subtotal = row[2].ToString();
                printMonthOrder.Customer_id = row[3].ToString();
                printMonthOrder.Customer_name = row[4].ToString();
                printMonthOrder.Customer_telephone = row[5].ToString();
                printMonthOrder.Customer_bill_form = row[6].ToString();
                printMonthOrder.Customer_invoice = row[7].ToString();
                printMonthOrder.Print_date = DateTime.Now.ToString("yyyy年MM月dd日");
                printMonthOrder.Print_people = MainForm.Maker;
                printMonthOrder.Driver_name = "";
                printMonthOrder.Total = getMonthTotalMoney(search_customer_id, day, search_info);
                printMonthOrder.Orders = getOrdersWhereCollectIsMonth(row[0].ToString());

                //updataCollectMoneyToTrue(row[0].ToString());
                printMonthOrders.Add(printMonthOrder);
            }
            PrintHelper printHelper = new PrintHelper(printMonthOrders);
            printHelper.printPreviewA4("Print");
        }

        private void updateOrderListview()
        {
            if (customer_id_textBox.Text == "") { return; }
            string selectQuery = "SELECT `order`.*, `product`.is_join_reserve, `product`.is_join_bucket, `driver`.driver_name FROM `order` " +
                    "JOIN `product` on `order`.product_id = `product`.product_id " +
                    "LEFT JOIN `driver` on `order`.driver_id = `driver`.driver_id " +
                    $"WHERE `order`.customer_id = '{customer_id_textBox.Text}'  AND `order`.product_id <> '0000' AND " +
                    $"if(`order`.product_id = '205', if(`order`.remark = '一般訂單', true, false), true) " +
                    "ORDER BY `order`.order_day DESC,  `order`.order_id DESC, `order`.product_index ASC ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            string selectQuery1 = "SELECT customer_bucket FROM `customer` " +
                $"WHERE customer_id = '{customer_id_textBox.Text}' ";
            DataTable datatable1 = ConnectDatabase("查詢", selectQuery1) as DataTable;

            int totalQuantity = 0;
            double totalTex = 0;
            double totalPrice = 0;
            string isCollectOK = "✔";
            string isBuckettOK = "未扣除";
            int nowBucket = int.Parse(datatable1.Rows[0][0].ToString());
            string firstOKOrder = "True";

            order_listview.Items.Clear();
            foreach (DataRow order in datatable.Rows)
            {
                if (order_listview.Items.Count == 0) 
                {
                }
                else
                {
                    if (order_listview.Items[order_listview.Items.Count - 1].Text != order[0].ToString())
                    {
                        totalQuantity = 0;
                        totalTex = 0;
                        totalPrice = 0;
                        isCollectOK = "✔";
                        isBuckettOK = "未扣除";

                        if(order_listview.Items[order_listview.Items.Count - 1].SubItems[8].Text == "✔")
                        {
                            firstOKOrder = "False";
                        }
                    }
                }

                ListViewItem item = new ListViewItem(order[0].ToString());//訂單編號
                item.SubItems.Add(order[1].ToString().Split(' ')[0]);//訂單日期
                item.SubItems.Add(order[4].ToString());//商品名稱

                if (Convert.ToBoolean(order[24].ToString()) & int.Parse(order[3].ToString()) < 201)
                {
                    if (order[17].ToString() == "預收")
                    {
                        if (order[7].ToString() == "False" & order[8].ToString() == "True")
                        {//預收送出
                            totalQuantity = totalQuantity + int.Parse(order[6].ToString());

                            if (Convert.ToBoolean(order[25].ToString()) == true && firstOKOrder == "False" && order[15].ToString() == "True")
                            {
                                if (isBuckettOK == "未扣除")
                                {
                                    nowBucket = nowBucket + (int.Parse(order[6].ToString()) - int.Parse(order[16].ToString()));
                                    isBuckettOK = "扣除";
                                }
                                else if (isBuckettOK == "扣除")
                                {
                                    nowBucket = nowBucket + int.Parse(order[6].ToString());
                                }
                            }

                        }
                        else if (order[7].ToString() == "True" & order[8].ToString() == "True")
                        {//水破補水
                            totalQuantity = totalQuantity + int.Parse(order[6].ToString());

                            if (Convert.ToBoolean(order[25].ToString()) == true && firstOKOrder == "False" && order[15].ToString() == "True")
                            {
                                if (isBuckettOK == "未扣除")
                                {
                                    nowBucket = nowBucket + (int.Parse(order[6].ToString()) - int.Parse(order[16].ToString()));
                                    isBuckettOK = "扣除";
                                }
                                else if (isBuckettOK == "扣除")
                                {
                                    nowBucket = nowBucket + int.Parse(order[6].ToString());
                                }
                            }
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
                        if (Convert.ToBoolean(order[25].ToString()) == true && firstOKOrder == "False" && order[15].ToString() == "True")
                        {
                            if (isBuckettOK == "未扣除")
                            {
                                nowBucket = nowBucket + (int.Parse(order[6].ToString()) - int.Parse(order[16].ToString()));
                                isBuckettOK = "扣除";
                            }
                            else if (isBuckettOK == "扣除")
                            {
                                nowBucket = nowBucket + int.Parse(order[6].ToString());
                            }
                        }
                    }
                }

                item.SubItems.Add(totalQuantity.ToString());//送瓶*

                item.SubItems.Add(order[16].ToString());//收瓶

                if (order[15].ToString() == "False")
                {
                    item.SubItems.Add(""); //欠瓶
                }
                else
                {
                    item.SubItems.Add(nowBucket.ToString()); //欠瓶
                }

                totalTex = totalTex + int.Parse(order[9].ToString());
                item.SubItems.Add(totalTex.ToString());//稅金*

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
                    isCollectOK = "";
                }
                else if (order[18].ToString() == "True")
                {
                    item.SubItems.Add("✔");//收款
                }

                item.SubItems.Add(order[26].ToString());//司機

                item.SubItems.Add(order[21].ToString());//發票號碼

                var index = order_listview.Items.Count;
                if (index == 0)
                {
                    item.SubItems[6].Text = totalTex.ToString();
                    item.SubItems[7].Text = totalPrice.ToString();
                    item.SubItems[9].Text = isCollectOK;

                    item.SubItems.Add(order[11].ToString());//備註

                    order_listview.Items.Add(item);
                }
                else
                {
                    if (order_listview.Items[index - 1].Text == order[0].ToString())
                    {
                        item.SubItems.Add(order_listview.Items[index - 1].SubItems[12].Text);//備註
                        order_listview.Items[index - 1].Remove();

                        item.SubItems[6].Text = totalTex.ToString();
                        item.SubItems[7].Text = totalPrice.ToString();
                        item.SubItems[9].Text = isCollectOK;

                        order_listview.Items.Add(item);
                    }
                    else
                    {
                        item.SubItems[6].Text = totalTex.ToString();
                        item.SubItems[7].Text = totalPrice.ToString();
                        item.SubItems[9].Text = isCollectOK;
                        item.SubItems.Add(order[11].ToString());//備註
                        order_listview.Items.Add(item);
                    }
                }
            };

        }
        private void updateMonthCollectOrderListview()
        {
            if (customer_id_textBox.Text == "") { return; }
            string selectQuery = "SELECT `order`.*, `driver`.driver_name FROM `order` " +
                    "LEFT JOIN `driver` on `order`.driver_id = `driver`.driver_id "+
                    $"WHERE `order`.customer_id = '{customer_id_textBox.Text}' " +
                    $"AND (case when `order`.product_id = '0000' then true  when `order`.product_id = '205' and `order`.remark = '月結訂單' then true else false end) " +
                    "ORDER BY `order`.order_id DESC, `order`.product_index ASC ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            double totalPrice = 0;

            month_collect_order_listview.Items.Clear();
            foreach (DataRow order in datatable.Rows)
            {
                if (month_collect_order_listview.Items.Count == 0) { }
                else
                {
                    if (month_collect_order_listview.Items[month_collect_order_listview.Items.Count - 1].Text != order[0].ToString())
                    {
                        totalPrice = 0;
                    }
                }

                ListViewItem item = new ListViewItem(order[0].ToString());//訂單編號
                item.SubItems.Add(order[1].ToString().Split(' ')[0]);//訂單日期
                item.SubItems.Add(order[4].ToString());//商品名稱

                totalPrice = totalPrice + int.Parse(order[10].ToString());
                item.SubItems.Add(totalPrice.ToString());//金額*

                if (order[18].ToString() == "False")
                {
                    item.SubItems.Add("");//收款
                }
                else if (order[18].ToString() == "True")
                {
                    item.SubItems.Add("✔");//收款
                }

                item.SubItems.Add(order[24].ToString());//司機

                item.SubItems.Add(order[21].ToString());//發票號碼

                var index = month_collect_order_listview.Items.Count;
                if (index == 0)
                {
                    item.SubItems[3].Text = totalPrice.ToString();

                    item.SubItems.Add(order[11].ToString());//備註

                    month_collect_order_listview.Items.Add(item);
                }
                else
                {
                    if (month_collect_order_listview.Items[index - 1].Text == order[0].ToString())
                    {
                        item.SubItems.Add(month_collect_order_listview.Items[index - 1].SubItems[7].Text);//備註
                        item.SubItems[2].Text = month_collect_order_listview.Items[index - 1].SubItems[2].Text;
                        month_collect_order_listview.Items[index - 1].Remove();

                        item.SubItems[3].Text = totalPrice.ToString();

                        month_collect_order_listview.Items.Add(item);
                    }
                    else
                    {
                        item.SubItems[3].Text = totalPrice.ToString();
                        item.SubItems.Add(order[11].ToString());//備註
                        month_collect_order_listview.Items.Add(item);
                    }
                }
            };

        }

        //當DataGridView增加一列的時候要新增一個序
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            order_dataGridView.Rows[0].Cells[0].Value = 1;

            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[0].Value = e.RowIndex+1;
            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[1].Value = "";
            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[2].Value = "";
            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[3].Value = "";
            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[4].Value = "";
            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[5].Value = collect_money_comboBox.Text;
            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[6].Value = bill_form_textBox.Text;
            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[7].Value = false;
            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[8].Value = false;
            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[9].Value = "";
            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[10].Value = "";
            order_dataGridView.Rows[order_dataGridView.Rows.Count - 1].Cells[11].Value = "";
        }
        //當DataGridView刪除一列的時候要改變序號
        private void order_dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (order_dataGridView.Rows.Count == 0) { return; }
            int count = order_dataGridView.Rows.Count;

            for (int i = 0; i<count; i++)
            {
                order_dataGridView.Rows[i].Cells[0].Value = i+1;
            }

            var total = 0;
            var tex = 0;

            for (int i = 0; i < order_dataGridView.Rows.Count - 1; i++)
            {
                tex = tex + int.Parse(order_dataGridView.Rows[i].Cells[9].Value.ToString());
                total = total + int.Parse(order_dataGridView.Rows[i].Cells[10].Value.ToString());
            }

            tex_textBox.Text = tex.ToString();
            total_textBox.Text = total.ToString();
        }
        //當DataGridView的cell值有改變時
        private void order_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            //輸入商品編號時
            if (e.ColumnIndex == 1)
            {
                var product_id = order_dataGridView.Rows[e.RowIndex].Cells[1].Value;
                if (product_id.ToString() == "") {
                    order_dataGridView.Rows[e.RowIndex].Cells[2].Value = "";
                    return;
                }
                
                if(product_id.ToString() == "000" | product_id.ToString() == "0000")
                {
                    return;
                }

                string selectQuery = "SELECT product_name FROM product " +
                    $"WHERE product_id = '{product_id}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                if (datatable.Rows.Count > 0)
                {
                    var product_name = datatable.Rows[0][0].ToString();
                    order_dataGridView.Rows[e.RowIndex].Cells[2].Value = product_name;
                    if (order_dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString() == "預收")
                    {
                        order_dataGridView.Rows[e.RowIndex].Cells[8].Value = true;
                    }
                }
                else
                {
                    MessageBox.Show("編號錯誤!請重新輸入!");
                    order_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    order_dataGridView.Rows[e.RowIndex].Cells[2].Value = "";
                }
            //輸入單價跟數量時還有判斷是不是搭贈或補送
            }else if (e.ColumnIndex == 3 | e.ColumnIndex == 4 | e.ColumnIndex == 5 | e.ColumnIndex == 6 | e.ColumnIndex == 7 | e.ColumnIndex == 8)
            {
                if (order_dataGridView.Rows[e.RowIndex].Cells[3].Value == null | order_dataGridView.Rows[e.RowIndex].Cells[4].Value == null) { return; }

                var product_id = order_dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                var price_value = order_dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                var quantity_value = order_dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                try
                {
                    
                    double product_price = double.Parse(price_value);
                    int product_quantity = int.Parse(quantity_value);
                    int subtex = 0;
                    int subtotal = 0;
                    if (getIsJoinTex(product_id))
                    {
                        if (order_dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString() == "不開")
                        {
                            subtex = 0;
                            subtotal = int.Parse(Math.Round(product_price * product_quantity + subtex, 0, MidpointRounding.AwayFromZero).ToString());
                        }
                        else if (order_dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString() == "三聯未稅")
                        {
                            double ssubtotal = Math.Round(product_price * product_quantity * 1.05, 0, MidpointRounding.AwayFromZero);
                            subtex = int.Parse(Math.Round(ssubtotal / 1.05 * 0.05, 0, MidpointRounding.AwayFromZero).ToString()); //四捨五入
                            subtotal = int.Parse(Math.Round(ssubtotal).ToString());

                        }
                        else if (order_dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString() == "三聯含稅" | order_dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString() == "二聯含稅")
                        {
                            subtex = int.Parse(Math.Round((product_price * product_quantity) / 1.05 * 0.05 , 0, MidpointRounding.AwayFromZero).ToString()); // 四捨五入
                            subtotal = int.Parse(Math.Round(product_price * product_quantity, 0, MidpointRounding.AwayFromZero).ToString());
                        }
                    }
                    else
                    {
                        subtex = 0;
                        subtotal = int.Parse(Math.Round(product_price * product_quantity + subtex, 0, MidpointRounding.AwayFromZero).ToString());
                    }


                    if (order_dataGridView.Rows[e.RowIndex].Cells[7].Value != null)
                    {
                        if (order_dataGridView.Rows[e.RowIndex].Cells[7].Value.ToString() == "True")
                        {
                            subtex = 0;
                            subtotal = 0;
                        }
                    }
                    if (order_dataGridView.Rows[e.RowIndex].Cells[8].Value != null)
                    {
                        if (order_dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString() == "True")
                        {
                            subtex = 0;
                            subtotal = 0;
                        }
                    }

                    if (int.Parse(order_dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()) < 201)
                    {
                        if (order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Contains("(贈送)"))
                        {
                            order_dataGridView.Rows[e.RowIndex].Cells[2].Value = order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Contains("(請款)") ? order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Replace("(請款)", "") : order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                        }
                        else
                        {
                            if (order_dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString() == "預收")
                            {
                                if (order_dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString() == "True")
                                {
                                    order_dataGridView.Rows[e.RowIndex].Cells[2].Value = order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Contains("(請款)") ? order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Replace("(請款)", "") : order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                                }
                                else
                                {
                                    order_dataGridView.Rows[e.RowIndex].Cells[2].Value = order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Contains("(請款)") ? order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString() : order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString() + "(請款)";
                                }
                            }
                            else
                            {
                                order_dataGridView.Rows[e.RowIndex].Cells[2].Value = order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Contains("(請款)") ? order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Replace("(請款)", "") : order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                            }
                        }
                        
                    }

                    order_dataGridView.Rows[e.RowIndex].Cells[9].Value = subtex.ToString();
                    order_dataGridView.Rows[e.RowIndex].Cells[10].Value = subtotal.ToString();
                    var total = 0;
                    var tex = 0;
                    
                    for (int i = 0; i < order_dataGridView.Rows.Count-1; i++)
                    {
                        tex = tex + int.Parse(order_dataGridView.Rows[i].Cells[9].Value.ToString());
                        total = total + int.Parse(order_dataGridView.Rows[i].Cells[10].Value.ToString());
                    }

                    tex_textBox.Text = tex.ToString();
                    total_textBox.Text = total.ToString();

                    //確認是否符合活動優惠1(預收儲值滿額贈)
                    if (order_dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString() == "預收" && order_dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString() == "False" && order_dataGridView.Rows[e.RowIndex].Cells[4].Value != null)
                    {
                        int product_num = int.Parse(order_dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString());

                        string selectQuery = "SELECT * FROM `sale_set` " +
                             $"WHERE sale_id = '0001'";
                        DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

                        int buyNum = int.Parse(datatable.Rows[0][3].ToString());
                        int freeNum = int.Parse(datatable.Rows[0][4].ToString());
                        string sale_is_use = datatable.Rows[0][2].ToString();

                        if (product_num >= buyNum && sale_is_use == "True")
                        {
                            DialogResult result = MessageBox.Show("此訂單符合預收優惠，需要幫你加上贈送的桶數嗎?", "注意", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                order_dataGridView.CellValueChanged -= order_dataGridView_CellValueChanged;

                                int product_Index = order_dataGridView.Rows.Count;
                                order_dataGridView.Rows.Add(product_Index.ToString());
                                order_dataGridView.Rows[product_Index - 1].Cells[1].Value = order_dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();//產品編號
                                order_dataGridView.Rows[product_Index - 1].Cells[2].Value = order_dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString().Replace("請款", "贈送");//產品名稱
                                order_dataGridView.Rows[product_Index - 1].Cells[3].Value = order_dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();//價格
                                order_dataGridView.Rows[product_Index - 1].Cells[4].Value = freeNum.ToString();//數量
                                order_dataGridView.Rows[product_Index - 1].Cells[5].Value = order_dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();//扣單別
                                order_dataGridView.Rows[product_Index - 1].Cells[6].Value = order_dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();//發票
                                order_dataGridView.Rows[product_Index - 1].Cells[7].Value = true;//補送
                                order_dataGridView.Rows[product_Index - 1].Cells[8].Value = false;//抵扣
                                order_dataGridView.Rows[product_Index - 1].Cells[9].Value = "0";//稅額
                                order_dataGridView.Rows[product_Index - 1].Cells[10].Value = "0";//小計
                                order_dataGridView.Rows[product_Index - 1].Cells[11].Value = "";//備註

                                order_dataGridView.Rows[product_Index].Cells[0].Value = product_Index + 1;
                                order_dataGridView.CellValueChanged += order_dataGridView_CellValueChanged;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    //確認是否符合優惠活動2(飲水機)
                    if (order_dataGridView.Rows[e.RowIndex].Cells[1].Value != null && order_dataGridView.Rows[e.RowIndex].Cells[10].Value.ToString() != "0")
                    {
                        string product_id1 = order_dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

                        if (product_id1 == "310" || product_id1 == "311" || product_id1 == "312")
                        {
                            string selectQuery = "SELECT * FROM `sale_set` " +
                             $"WHERE sale_id = '0002'";
                            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

                            string desktop_num1 = datatable.Rows[0][3].ToString();
                            string desktop_num2 = datatable.Rows[0][4].ToString();
                            string top_num1 = datatable.Rows[0][5].ToString();
                            string top_num2 = datatable.Rows[0][6].ToString();
                            string down_num1 = datatable.Rows[0][7].ToString();
                            string down_num2 = datatable.Rows[0][8].ToString();
                            string sale_is_use = datatable.Rows[0][2].ToString();

                            if (sale_is_use == "False") { return; }

                            DialogResult result = MessageBox.Show("此訂單符合購買飲水機優惠，需要幫你加上贈送的桶數嗎?", "注意", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                order_dataGridView.CellValueChanged -= order_dataGridView_CellValueChanged;

                                string num160 = "";
                                string num161 = "";

                                switch (product_id1)
                                {
                                    case "310":
                                        num160 = desktop_num1;
                                        num161 = desktop_num2;
                                        break;
                                    case "311":
                                        num160 = top_num1;
                                        num161 = top_num2;
                                        break;
                                    case "312":
                                        num160 = down_num1;
                                        num161 = down_num2;
                                        break ;
                                }

                                int product_Index = order_dataGridView.Rows.Count;
                                order_dataGridView.Rows.Add(product_Index.ToString());
                                order_dataGridView.Rows[product_Index - 1].Cells[1].Value = "160";//產品編號
                                order_dataGridView.Rows[product_Index - 1].Cells[2].Value = "竹炭水(贈送)";//產品名稱
                                order_dataGridView.Rows[product_Index - 1].Cells[3].Value = "0";//價格
                                order_dataGridView.Rows[product_Index - 1].Cells[4].Value = num160;//數量
                                order_dataGridView.Rows[product_Index - 1].Cells[5].Value = "預收";//扣單別
                                order_dataGridView.Rows[product_Index - 1].Cells[6].Value = order_dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();//發票
                                order_dataGridView.Rows[product_Index - 1].Cells[7].Value = true;//補送
                                order_dataGridView.Rows[product_Index - 1].Cells[8].Value = false;//抵扣
                                order_dataGridView.Rows[product_Index - 1].Cells[9].Value = "0";//稅額
                                order_dataGridView.Rows[product_Index - 1].Cells[10].Value = "0";//小計
                                order_dataGridView.Rows[product_Index - 1].Cells[11].Value = "";//備註

                                order_dataGridView.Rows[product_Index].Cells[0].Value = product_Index + 1;

                                order_dataGridView.Rows.Add((product_Index + 1).ToString());
                                order_dataGridView.Rows[product_Index].Cells[1].Value = "161";//產品編號
                                order_dataGridView.Rows[product_Index].Cells[2].Value = "鹼性水(贈送)";//產品名稱
                                order_dataGridView.Rows[product_Index].Cells[3].Value = "0";//價格
                                order_dataGridView.Rows[product_Index].Cells[4].Value = num161;//數量
                                order_dataGridView.Rows[product_Index].Cells[5].Value = "預收";//扣單別
                                order_dataGridView.Rows[product_Index].Cells[6].Value = order_dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();//發票
                                order_dataGridView.Rows[product_Index].Cells[7].Value = true;//補送
                                order_dataGridView.Rows[product_Index].Cells[8].Value = false;//抵扣
                                order_dataGridView.Rows[product_Index].Cells[9].Value = "0";//稅額
                                order_dataGridView.Rows[product_Index].Cells[10].Value = "0";//小計
                                order_dataGridView.Rows[product_Index].Cells[11].Value = "";//備註

                                order_dataGridView.Rows[product_Index + 1].Cells[0].Value = product_Index + 2;
                                order_dataGridView.CellValueChanged += order_dataGridView_CellValueChanged;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                catch
                {
                    //轉型失敗  
                }
            }
        }
        //當DataGridView雙擊刪除商品
        private void order_dataGridView_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            order_dataGridView.Rows.RemoveAt(e.RowIndex);
        }
        //當DataGridView雙擊商品編號時，顯示全部商品視窗
        private void order_dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string customer_id = customer_id_textBox.Text;
                ProductSearchForm mainForm = new ProductSearchForm(customer_id);
                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                mainForm.ShowDialog();
                order_dataGridView[e.ColumnIndex, e.RowIndex].Value = strValue;//顯示返回的值  
                order_dataGridView[3, e.RowIndex].Value = productPrice;//顯示返回的值  
                order_dataGridView.CurrentCell = order_dataGridView[4, e.RowIndex];
            }
        }
        //客戶編號發生改變時
        private void customer_id_textBox_TextChanged(object sender, EventArgs e)
        {
            if (customer_id_textBox.Text == "")
            {
                bill_number_textBox.Text = "";
                tex_textBox.Text = "";
                total_textBox.Text = "";
                collect_money_comboBox.Enabled = false;
                order_dataGridView.Rows.Clear();
                order_dataGridView.Enabled = false;
                driver_change_chb.Checked= false;
                driver_change_chb.Enabled=false;
                order_listview.Items.Clear();
                old_order_btn.Enabled = false;
                customer_memo_btn.Enabled = false;
            }
            else
            {
                bill_number_textBox.Text = "";
                tex_textBox.Text = "";
                total_textBox.Text = "";
                order_dataGridView.Rows.Clear();
                order_dataGridView.Enabled = true;
                driver_change_chb.Checked = false;
                driver_change_chb.Enabled = true;
                old_order_btn.Enabled=true;
                customer_memo_btn.Enabled = true;

                order_dataGridView.Rows[0].Cells[1].Value = "";
                order_dataGridView.Rows[0].Cells[2].Value = "";
                order_dataGridView.Rows[0].Cells[3].Value = "";
                order_dataGridView.Rows[0].Cells[4].Value = "";
                order_dataGridView.Rows[0].Cells[5].Value = getCustomer("customer_collect_money", customer_id_textBox.Text);
                order_dataGridView.Rows[0].Cells[6].Value = getCustomer("customer_bill_form", customer_id_textBox.Text);
                order_dataGridView.Rows[0].Cells[7].Value = false;
                order_dataGridView.Rows[0].Cells[8].Value = false; 
                order_dataGridView.Rows[0].Cells[9].Value = "";
                order_dataGridView.Rows[0].Cells[10].Value = "";
                order_dataGridView.Rows[0].Cells[11].Value = "";

            }

            
        }
        //滑鼠雙擊訂單列表
        private void order_listview_DoubleClick(object sender, EventArgs e)
        {
            order_dataGridView.CellValueChanged -= order_dataGridView_CellValueChanged;
            order_dataGridView.Rows.Clear();
            order_dataGridView.Enabled = true;
            var order_id = order_listview.SelectedItems[0].SubItems[0].Text;
            string selectQuery = "SELECT * FROM `order` " +
                         $"WHERE order_id = '{order_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null)
            {
                return;
            }
            foreach (DataRow row in datatable.Rows)
            {
                //order_id_textbox.Text = row[0].ToString();
                //dateTimePicker.Value.ToString("yyyy/MM/dd") = row[1].ToString();

                order_dataGridView.Rows.Add(row[2].ToString());//產品順序
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[1].Value = row[3].ToString();//產品編號
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[2].Value = row[4].ToString();//產品名稱
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[3].Value = row[5].ToString();//價格
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[4].Value = row[6].ToString();//數量
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[5].Value = row[17].ToString();//扣單別
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[6].Value = row[13].ToString();//發票
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[7].Value = row[7].ToString();//補送
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[8].Value = row[8].ToString();//抵扣
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[9].Value = row[9].ToString();//稅金
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[10].Value = row[10].ToString();//小計
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[11].Value = row[11].ToString();//備註
                bill_number_textBox.Text = row[21].ToString();
                tex_textBox.Text = order_listview.SelectedItems[0].SubItems[6].Text;
                total_textBox.Text = order_listview.SelectedItems[0].SubItems[7].Text;
            }
            order_dataGridView.Rows[datatable.Rows.Count].Cells[0].Value = (datatable.Rows.Count + 1).ToString();
            order_dataGridView.CellValueChanged += order_dataGridView_CellValueChanged;
        }
        //當視窗關閉時Timer停止
        private void OrderDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }
        //雙擊搜尋框時，跳出全部客戶視窗
        private void search_textBox_DoubleClick(object sender, EventArgs e)
        {
            CustomerSearchForm mainForm = new CustomerSearchForm("OrderDataForm", search_textBox.Text);
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
            search_comboBox.SelectedIndex = 1;
            search_textBox.Text = strValue; ;//顯示返回的值  
            getClientData();
            isHaveDispenser();
            updateOrderListview();
            updateMonthCollectOrderListview();
            isHaveCustomerMemoNotFinish(customer_id_textBox.Text);
        }
        //當搜尋框按下Enter、空白、向下鍵時
        private void search_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getClientData();
                isHaveDispenser();
                updateOrderListview();
                updateMonthCollectOrderListview();
                isHaveCustomerMemoNotFinish(customer_id_textBox.Text);
            }
            if (e.KeyCode == Keys.Space)
            {
                CustomerSearchForm mainForm = new CustomerSearchForm("OrderDataForm", search_textBox.Text);
                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                mainForm.ShowDialog();
                search_comboBox.SelectedIndex = 0;
                search_textBox.Text = strValue;//顯示返回的值  
                getClientData();
                isHaveDispenser();
                updateOrderListview();
                updateMonthCollectOrderListview();
                isHaveCustomerMemoNotFinish(customer_id_textBox.Text);
            }
            if (e.KeyCode == Keys.Down && customer_id_textBox.Text != "")
            {
                order_dataGridView.CurrentCell = order_dataGridView.Rows[0].Cells[1];
                order_dataGridView.BeginEdit(true);
            }

        }
        //當時間選擇器按下Enter時
        private void dateTimePicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search_textBox.Focus();
            }
        }
        //當時間選擇器改變時
        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            newOrderID(dateTimePicker.Value.ToString("yyyy/MM/dd"));
        }
        //當地址列表改變時
        private void customer_address_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = customer_address_comboBox.SelectedIndex == 0 ? "" : "-" + customer_address_comboBox.SelectedIndex.ToString();
            string customer_id = customer_id_textBox.Text.Substring(0, 6) + index;

            customer_id_textBox.Text = customer_id;

            isHaveDispenser();
            updateOrderListview();
            updateMonthCollectOrderListview();

            string selectQuery = "SELECT * FROM customer " +
                         $"WHERE customer_id = '{customer_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null) { return; }
            if (datatable != null & datatable.Rows.Count != 0)
            {
                customer_id_textBox.Text = datatable.Rows[0][0].ToString();
                customer_name_textbox.Text = datatable.Rows[0][1].ToString();
                //inputAddDataToAddCombo(datatable.Rows[0][0].ToString());
                customer_telephone_textbox.Text = datatable.Rows[0][5].ToString();
                bill_form_textBox.Text = datatable.Rows[0][6].ToString();
                customer_invoice_textbox.Text = datatable.Rows[0][7].ToString();
                collect_money_comboBox.Text = datatable.Rows[0][9].ToString();
                bucket_textBox.Text = datatable.Rows[0][10].ToString();
                remain_textBox.Text = datatable.Rows[0][11].ToString();
                collect_money_comboBox.Enabled = false;
                customer_remark_textBox.Text = datatable.Rows[0][15].ToString();
                company_comboBox.Text = datatable.Rows[0][14].ToString();
                isHaveCustomerMemoNotFinish(customer_id_textBox.Text);
            }
            else
            {
                customer_id_textBox.Text = "";
                customer_name_textbox.Text = "";
                //customer_address_comboBox.Items.Clear();
                customer_telephone_textbox.Text = "";
                bill_form_textBox.Text = "";
                customer_invoice_textbox.Text = "";
                collect_money_comboBox.Text = "";
                bucket_textBox.Text = "";
                remain_textBox.Text = "";
                collect_money_comboBox.Enabled = false;
                customer_remark_textBox.Text = "";
                company_comboBox.Text = "";
            }
        }


        //確認按鈕
        private void order_save_btn_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            newOrderID(dateTimePicker.Value.ToString("yyyy/MM/dd"));
            if (customer_id_textBox.Text == "")
            {
                MessageBox.Show("請輸入客戶編號");
                return;
            }

            if (CheckForDuplicateOrder(dateTimePicker.Value.ToString("yyyy-MM-dd"), customer_id_textBox.Text))
            {
                DialogResult result = MessageBox.Show("此日期已有訂單，是否要新增訂單?", "注意", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return; // 如果選擇不新增，則結束方法
                }
            }

            List<Order> orders = new List<Order>();
            var productNum = order_dataGridView.Rows.Count - 1;

            for (int i = 1; i <= productNum; i++)
            {
                if (order_dataGridView.Rows[i - 1].Cells[3].Value.ToString() == "" || order_dataGridView.Rows[i - 1].Cells[4].Value.ToString() == "")
                {
                    MessageBox.Show("價格跟數量不得空白");
                    return;
                }
                Order order = new Order(
                    order_id_textbox.Text,//ID
                    dateTimePicker.Value.ToString("yyyy-MM-dd"),//訂單日期
                    order_dataGridView.Rows[i - 1].Cells[0].Value.ToString(),//商品順序
                    order_dataGridView.Rows[i - 1].Cells[1].Value.ToString(),//商品ID
                    order_dataGridView.Rows[i - 1].Cells[2].Value.ToString(),//商品名稱
                    order_dataGridView.Rows[i - 1].Cells[3].Value.ToString(),//價格
                    order_dataGridView.Rows[i - 1].Cells[4].Value.ToString(),//數量
                    order_dataGridView.Rows[i - 1].Cells[7].Value.ToString(),//補送
                    order_dataGridView.Rows[i - 1].Cells[8].Value.ToString(),//抵扣
                    order_dataGridView.Rows[i - 1].Cells[9].Value.ToString(),//稅額
                    order_dataGridView.Rows[i - 1].Cells[10].Value.ToString(),//小計
                    order_dataGridView.Rows[i - 1].Cells[11].Value == null ? "" : order_dataGridView.Rows[i - 1].Cells[11].Value.ToString(),//備註
                    customer_id_textBox.Text,
                    order_dataGridView.Rows[i - 1].Cells[6].Value.ToString(),
                    "",
                    "False",
                    "0",
                    order_dataGridView.Rows[i - 1].Cells[5].Value.ToString(),
                    "False",
                    "False",
                    driver_change_chb.Checked ? "False" : "True",
                    bill_number_textBox.Text,
                    dateTimePicker.Value.ToString("yyyy-MM-dd"),
                    MainForm.Maker
                );

                if (order_dataGridView.Rows[i - 1].Cells[1].Value.ToString() == "" | order_dataGridView.Rows[i - 1].Cells[2].Value.ToString() == "")
                {

                }
                else
                {
                    orders.Add(order);
                }
            }


            List<string> list = collect_OK_False_List(customer_id_textBox.Text);
            var index = int.Parse(order_dataGridView.Rows.Count.ToString());
            if (list.Count > 0)
            {
                MessageBox.Show("注意！有筆款項未收！已將未收款項新增至此訂單！");
                foreach (string item in list)
                {
                    Order order = new Order(
                        order_id_textbox.Text,
                        dateTimePicker.Value.ToString("yyyy-MM-dd"),
                        index.ToString(),
                        "000",
                        $"{getOrderProductName(item)}",
                        collectFalseTotalMoney(item),
                        "1",
                        "False",
                        "False",
                        "0",
                        collectFalseTotalMoney(item),//小計金額
                        $"{item}",//備註：放未收款的訂單編號
                        customer_id_textBox.Text,
                        "不開",
                        "",
                        "False",
                        "0",
                        "現金",
                        "False",
                        "False",
                        "False",
                        bill_number_textBox.Text,
                        dateTimePicker.Value.ToString("yyyy-MM-dd"),
                        MainForm.Maker
                    );
                    orders.Add(order);
                    index++;
                }
            }

            if (isJoinOtherAddCollectFalseOrder(customer_id_textBox.Text).Count.ToString() != "0")
            {
                List<string> list1 = isJoinOtherAddCollectFalseOrder(customer_id_textBox.Text);
                DialogResult result = MessageBox.Show("系統偵測到此客戶其他地址有未收款，要一起加進此張訂單嗎?", "注意", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (list1.Count > 0)
                    {
                        MessageBox.Show("注意！有筆款項未收！已將未收款項新增至此訂單！");
                        foreach (string item in list1)
                        {
                            Order order = new Order(
                                order_id_textbox.Text,
                                dateTimePicker.Value.ToString("yyyy-MM-dd"),
                                index.ToString(),
                                "000",
                                $"{getOrderProductName(item)}",
                                collectFalseTotalMoney(item),
                                "1",
                                "False",
                                "False",
                                "0",
                                collectFalseTotalMoney(item),//小計金額
                                $"{item}",//備註：放未收款的訂單編號
                                customer_id_textBox.Text,
                                "不開",
                                "",
                                "False",
                                "0",
                                "現金",
                                "False",
                                "False",
                                "False",
                                bill_number_textBox.Text,
                                dateTimePicker.Value.ToString("yyyy-MM-dd"),
                                MainForm.Maker
                            );
                            orders.Add(order);
                            index++;
                        }
                    }
                }
                else
                {

                }
            }

            if (over_short_textBox.Text != "0")
            {
                string num = over_short_textBox.Text;
                num = num.Contains('-') ? num.Replace("-", "") : "-" + num;
                MessageBox.Show("注意！此訂單已加入短溢收差額！");
                Order order = new Order(
                    order_id_textbox.Text,
                    dateTimePicker.Value.ToString("yyyy-MM-dd"),
                    index.ToString(),
                    "000",
                    "短溢收",
                    $"{num}",
                    "1",
                    "False",
                    "False",
                    "0",
                    $"{num}",//小計金額
                    $"",//備註
                    customer_id_textBox.Text,
                    "不開",
                    "",
                    "False",
                    "0",
                    "現金",
                    "False",
                    "False",
                    "False",
                    bill_number_textBox.Text,
                    dateTimePicker.Value.ToString("yyyy-MM-dd"),
                    MainForm.Maker
                );
                orders.Add(order);
            }

            string new_order_id = GenerateSerial("order");

            var resultInsert = "";
            var is_have_new_remain = "False";
            foreach (var item in orders)
            {
                var product_quantity = int.Parse(item.Quantity);
                int remain = int.Parse(remain_textBox.Text);

                if (item.CollectMoney == "預收" & item.GiveNoFree == "True")
                {
                    if (remain < product_quantity)
                    {
                        if (is_have_new_remain == "False")
                        {
                            MessageBox.Show("請注意預收數量已不夠！");
                            //return;
                        }
                    }
                }
                else if (item.CollectMoney == "預收" & item.GiveNoFree == "False")
                {
                    is_have_new_remain = "True";
                }

                string insertQuery =
                "INSERT INTO `order` VALUES " +
                $"('{new_order_id}'," +
                $"'{item.Day}'," +
                $"'{item.ProductIndex}'," +
                $"'{item.ProductID}'," +
                $"'{item.ProductName}'," +
                $"'{item.Price}'," +
                $"'{item.Quantity}'," +
                $"'{item.GiveFree}', " +
                $"'{item.GiveNoFree}', " +
                $"'{item.Tex}', " +
                $"'{item.SubTotal}'," +
                $"'{item.Remark}'," +
                $"'{item.Customer}'," +
                $"'{item.CustomerBillForm}'," +
                $"'{item.Driver}'," +
                $"'{item.IsOK}'," +
                $"'{item.RecycleQuantity}'," +
                $"'{item.CollectMoney}'," +
                $"'{item.CollectOK}'," +
                $"'{item.Assign_OK}'," +
                $"'{item.DriverChange}'," +
                $"'{item.BillNumber}'," +
                $"'{item.Order_id_day}'," +
                $"'{item.Maker}')";

                resultInsert = ConnectDatabase("新增", insertQuery).ToString();
            }

            if (resultInsert == "-1")
            {
                MessageBox.Show("訂單資料儲存失敗!");
            }
            else
            {
                DialogResult result = MessageBox.Show("是否列印訂單", "注意", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    printOrder(new_order_id);
                }
                else
                {

                }
                bill_number_textBox.Text = "";
                tex_textBox.Text = "";
                total_textBox.Text = "";
                order_dataGridView.Rows.Clear();
                order_dataGridView.Enabled = true;
                driver_change_chb.Checked = false;
                driver_change_chb.Enabled = true;
                updateOrderListview();
                updateMonthCollectOrderListview();
                newOrderID(dateTimePicker.Value.ToString("yyyy/MM/dd"));
                search_textBox.Text = "";
                search_textBox.Focus();
            }
            timer1.Start();
        }
        //發票按鈕
        private void bill_number_btn_Click(object sender, EventArgs e)
        {
            if (order_listview.SelectedItems.Count == 0 && month_collect_order_listview.SelectedItems.Count == 0) {  return; }
            string order_id = "";
            string whoCall = "";
            if (order_tabControl.SelectedTab == orderTap)
            {
                order_id = order_listview.SelectedItems[0].SubItems[0].Text;
                whoCall = "一般訂單";
            }
            else if(order_tabControl.SelectedTab == monthTap)
            {
                order_id = month_collect_order_listview.SelectedItems[0].SubItems[0].Text;
                whoCall = "月結訂單";
            }
            

            BillNumberForm mainForm = new BillNumberForm(order_id, whoCall);
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();

            if (billNumber == "") {  return; }
            string reviseQuery =
                "UPDATE `order` SET " +
                $"bill_number = '{billNumber}'" +
                $"WHERE order_id = '{order_id}'";
            ConnectDatabase("修改", reviseQuery);
            updateOrderListview();
            updateMonthCollectOrderListview();

        }
        //刪除按鈕
        private void order_remove_btn_Click(object sender, EventArgs e)
        {
            if (order_listview.SelectedItems.Count <= 0) { return; }
            if (order_tabControl.SelectedTab == monthTap) { return; }
            var order_id = order_listview.SelectedItems[0].SubItems[0].Text;

            string selectQuery = "SELECT order_id FROM `order` " +
                $"WHERE order_id = '{order_id}' AND order_OK = 'False' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count == 0)
            {
                MessageBox.Show("無法刪除已銷單的訂單");
                return;
            }

            PasswordInputForm mainForm = new PasswordInputForm();
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
            if (strValue == "False") { return; }

            if (order_listview.SelectedItems.Count > 0)
            {
                string removeQuery =
                        "DELETE FROM `order` WHERE " +
                        $"order_id = '{order_id}'";
                var result = ConnectDatabase("修改", removeQuery).ToString();

                string removeQuery1 =
                        "DELETE FROM `driver_order` WHERE " +
                        $"order_id = '{order_id}'";
                result = ConnectDatabase("修改", removeQuery1).ToString();

                if (result != "-1")
                {
                    MessageBox.Show("訂單編號" + order_id + "已經刪除！");
                    newOrderID(dateTimePicker.Value.ToString("yyyy/MM/dd"));
                }
                else
                {
                    MessageBox.Show("訂單編號" + order_id + "刪除失敗！");
                }
                updateOrderListview();
            }
        }
        //離開視窗
        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //取消訂單
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            allTextClear();
            order_listview.Items.Clear();
        }
        //入帳按鈕
        private void collect_OK_btn_Click(object sender, EventArgs e)
        {
            if (order_listview.SelectedItems.Count == 0 && month_collect_order_listview.SelectedItems.Count == 0) { return; }
            if (order_tabControl.SelectedTab == orderTap)
            {
                List<string> order_id_list = new List<string>();
                List<string> total_money_list = new List<string>();
                string customer_id = customer_id_textBox.Text;

                foreach (ListViewItem item in order_listview.SelectedItems)
                {
                    Console.WriteLine(item.SubItems[9].Text);
                    Console.WriteLine(item.SubItems[8].Text);
                    if (item.SubItems[9].Text == "✔" || item.SubItems[8].Text == "")
                    {
                        MessageBox.Show("訂單無法入帳!");
                        return;
                    }
                    order_id_list.Add(item.SubItems[0].Text);
                    total_money_list.Add(item.SubItems[7].Text);
                }

                RemittanceInputForm mainForm = new RemittanceInputForm(order_id_list, total_money_list, customer_id);
                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                mainForm.ShowDialog();

                updateOrderListview();
            }
            else if (order_tabControl.SelectedTab == monthTap)
            {
                if (month_collect_order_listview.SelectedItems[0].SubItems[4].Text == "✔")
                {
                    MessageBox.Show("訂單無法入帳!");
                    return;
                }

                string order_id = month_collect_order_listview.SelectedItems[0].SubItems[0].Text;
                string totalMoney = month_collect_order_listview.SelectedItems[0].SubItems[3].Text;
                string customer_id = customer_id_textBox.Text;
                RemittanceInputForm mainForm = new RemittanceInputForm(order_id, totalMoney, customer_id);
                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                mainForm.ShowDialog();

                updateMonthCollectOrderListview();
            }

        }
        //月結按鈕
        private void month_money_btn_Click(object sender, EventArgs e)
        {
            if (customer_id_textBox.Text == "") { return; }
            if (order_tabControl.SelectedTab == monthTap) { return; }

            string customer_id = customer_id_textBox.Text;
            string customer_id_mark = customer_id.Contains("-") ? customer_id.Split('-')[0] : customer_id;
            var dayNow = dateTimePicker.Value.ToString("yyyy-MM-dd");
            string search_info;
            string search_customer_id;

            string selectQuery = "SELECT customer_id FROM `customer` " +
            $"WHERE customer_id_mark = '{customer_id_mark}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows.Count > 1)
            {
                DialogResult result = MessageBox.Show("系統偵測到此客戶有其他地址，要一起結帳嗎?", "注意", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        //全部一起結帳
                        search_info = "customer_id_mark";
                        search_customer_id = customer_id_mark;

                        break;
                    case DialogResult.No:
                        //單獨結帳
                        search_info = "customer_id";
                        search_customer_id = customer_id;

                        break;
                    case DialogResult.Cancel:

                        return;
                    default:
                        return;
                }
            }
            else if (datatable.Rows.Count == 1)
            {
                //單獨結帳
                search_info = "customer_id";
                search_customer_id = customer_id;
            }
            else
            {
                return;
            }

            string selectQuery1 = "SELECT o.order_id FROM `order` as o " +
                $"WHERE o.customer_id in (select c.customer_id from `customer` as c where c.{search_info} = '{search_customer_id}') " +
                $"AND o.order_OK = 'True' AND o.collect_OK = 'False' AND o.collect_money = '月結' AND o.order_day <= '{dayNow}' ";
            DataTable datatable1 = ConnectDatabase("查詢", selectQuery1) as DataTable;

            if (datatable1 == null || datatable1.Rows.Count == 0)
            {
                MessageBox.Show("查無尚未結帳月結訂單");
                return;
            }

            DialogResult result1 = MessageBox.Show($"是否確定要請款結帳到【{dayNow}】?總金額是【${getMonthTotalMoney(search_customer_id, dayNow, search_info)}】", "注意", MessageBoxButtons.YesNoCancel);

            switch (result1)
            {
                case DialogResult.Yes:

                    DialogResult result2 = MessageBox.Show("是否列印月結明細表", "注意", MessageBoxButtons.YesNoCancel);

                    switch (result2)
                    {
                        case DialogResult.Yes:
                            printMonthMoneyOrder(search_customer_id, dayNow, search_info);
                            break;
                        case DialogResult.No:

                            break;
                        case DialogResult.Cancel:

                            break;
                        default:
                            break;
                    }


                    string new_order_id = GenerateSerial("order");

                    List<Order> orders = new List<Order>();

                    Order order = new Order(
                        new_order_id,//ID
                        dateTimePicker.Value.ToString("yyyy-MM-dd"),//訂單日期
                       "1",//商品順序
                        "0000",//商品ID
                        "月結單",//商品名稱
                        getMonthTotalMoney(search_customer_id, dayNow, search_info),//價格
                        "1",//數量
                        "False",//補送
                        "False",//抵扣
                        getMonthTotalTex(customer_id_mark, dayNow, search_info),//稅額
                        getMonthTotalMoney(search_customer_id, dayNow, search_info),//小計
                        $"結帳日：{dayNow}",//備註
                        getSelectMonthCollectAddress(customer_id_mark),
                        "不開",
                        "",
                        "False",
                        "0",
                        "現金",
                        "False",
                        "False",
                        driver_change_chb.Checked ? "False" : "True",
                        bill_number_textBox.Text,
                        dateTimePicker.Value.ToString("yyyy-MM-dd"),
                        MainForm.Maker
                    );

                    orders.Add(order);

                    var resultInsert = "";

                    foreach (var item in orders)
                    {
                        string insertQuery =
                        "INSERT INTO `order` VALUES " +
                        $"('{item.Id}'," +
                        $"'{item.Day}'," +
                        $"'{item.ProductIndex}'," +
                        $"'{item.ProductID}'," +
                        $"'{item.ProductName}'," +
                        $"'{item.Price}'," +
                        $"'{item.Quantity}'," +
                        $"'{item.GiveFree}', " +
                        $"'{item.GiveNoFree}', " +
                        $"'{item.Tex}', " +
                        $"'{item.SubTotal}'," +
                        $"'{item.Remark}'," +
                        $"'{item.Customer}'," +
                        $"'{item.CustomerBillForm}'," +
                        $"'{item.Driver}'," +
                        $"'{item.IsOK}'," +
                        $"'{item.RecycleQuantity}'," +
                        $"'{item.CollectMoney}'," +
                        $"'{item.CollectOK}'," +
                        $"'{item.Assign_OK}'," +
                        $"'{item.DriverChange}'," +
                        $"'{item.BillNumber}'," +
                        $"'{item.Order_id_day}'," +
                        $"'{item.Maker}')";

                        resultInsert = ConnectDatabase("新增", insertQuery).ToString();
                    }

                    if (resultInsert == "-1")
                    {
                        MessageBox.Show("訂單資料儲存失敗!");
                        return;
                    }
                    else
                    {
                        DialogResult result3 = MessageBox.Show("是否列印訂單", "注意", MessageBoxButtons.YesNo);
                        if (result3 == DialogResult.Yes)
                        {
                            printOrder(orders[0].Id);
                        }
                        else
                        {

                        }

                        foreach (DataRow item in datatable1.Rows)
                        {
                            string reviseQuery =
                                "UPDATE `order` SET " +
                                "collect_OK = 'True' " +
                                $"WHERE order_id = '{item[0].ToString()}' AND collect_money = '月結'";
                            ConnectDatabase("修改", reviseQuery);
                        }

                        bill_number_textBox.Text = "";
                        tex_textBox.Text = "";
                        total_textBox.Text = "";
                        order_dataGridView.Rows.Clear();
                        order_dataGridView.Enabled = true;
                        driver_change_chb.Checked = false;
                        driver_change_chb.Enabled = true;
                        updateOrderListview();
                        updateMonthCollectOrderListview();
                        newOrderID(dateTimePicker.Value.ToString("yyyy/MM/dd"));
                        search_textBox.Text = "";
                        search_textBox.Focus();
                    }

                    break;
                case DialogResult.No:

                    return;
                case DialogResult.Cancel:

                    return;
                default:
                    return;
            }

        }
        //舊訂單按鈕
        private void old_order_btn_Click(object sender, EventArgs e)
        {
            string customer_id = customer_id_textBox.Text;
            if (customer_id.Contains('-') == true)
            {
                customer_id = customer_id.Split('-')[0];
            }
            OldOrderForm mainForm = new OldOrderForm(customer_id);
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
        }
        //更新回收數量按鈕
        private void update_recyele_quantity_btn_Click(object sender, EventArgs e)
        {
            if (order_listview.SelectedItems.Count == 0) { return; }
            if (order_tabControl.SelectedTab == monthTap) { return; }

            string customer_id = customer_id_textBox.Text;
            string bucket = bucket_textBox.Text;
            string order_id = order_listview.SelectedItems[0].SubItems[0].Text;
            string old_quantity = order_listview.SelectedItems[0].SubItems[4].Text;

            UpdateRecyeleQuantity mainForm = new UpdateRecyeleQuantity(old_quantity, customer_id, order_id, bucket);
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();

            getClientData();
            updateOrderListview();
        }
        //修改訂單按鈕
        private void order_revise_btn_Click(object sender, EventArgs e)
        {
            if (order_listview.SelectedItems.Count == 0 || order_listview.SelectedItems.Count > 1) { return; }
            if (order_tabControl.SelectedTab == monthTap) { return; }
            if (order_listview.SelectedItems[0].SubItems[8].Text == "✔" | order_listview.SelectedItems[0].SubItems[10].Text != "")
            {
                MessageBox.Show("已銷單或已派單的訂單不可改單!");
                return;
            }
            DialogResult result2 = MessageBox.Show("確定要改單嗎?", "注意", MessageBoxButtons.YesNo);
            if (result2 == DialogResult.Yes)
            {

            }
            else
            {
                return;
            }

            string order_id = order_listview.SelectedItems[0].SubItems[0].Text;
            string order_day = order_listview.SelectedItems[0].SubItems[1].Text;

            string removeQuery =
                "DELETE FROM `order` WHERE " +
                $"order_id = '{order_id}'";
            var result = ConnectDatabase("修改", removeQuery).ToString();

            if (result != "-1")
            {
                List<Order> orders = new List<Order>();
                var productNum = order_dataGridView.Rows.Count - 1;
                for (int i = 1; i <= productNum; i++)
                {
                    if (order_dataGridView.Rows[i - 1].Cells[3].Value.ToString() == "" || order_dataGridView.Rows[i - 1].Cells[4].Value.ToString() == "")
                    {
                        MessageBox.Show("價格跟數量不得空白");
                        return;
                    }

                    Order order = new Order(
                        order_id,//ID
                        order_day,//訂單日期
                        order_dataGridView.Rows[i - 1].Cells[0].Value.ToString(),//商品順序
                        order_dataGridView.Rows[i - 1].Cells[1].Value.ToString(),//商品ID
                        order_dataGridView.Rows[i - 1].Cells[2].Value.ToString(),//商品名稱
                        order_dataGridView.Rows[i - 1].Cells[3].Value.ToString(),//價格
                        order_dataGridView.Rows[i - 1].Cells[4].Value.ToString(),//數量
                        order_dataGridView.Rows[i - 1].Cells[7].Value.ToString(),//補送
                        order_dataGridView.Rows[i - 1].Cells[8].Value.ToString(),//抵扣
                        order_dataGridView.Rows[i - 1].Cells[9].Value.ToString(),//稅額
                        order_dataGridView.Rows[i - 1].Cells[10].Value.ToString(),//小計
                        order_dataGridView.Rows[i - 1].Cells[11].Value == null ? "" : order_dataGridView.Rows[i - 1].Cells[11].Value.ToString(),//備註
                        customer_id_textBox.Text,
                        order_dataGridView.Rows[i - 1].Cells[6].Value.ToString(),
                        "",
                        "False",
                        "0",
                        order_dataGridView.Rows[i - 1].Cells[5].Value.ToString(),
                        "False",
                        "False",
                        driver_change_chb.Checked ? "False" : "True",
                        bill_number_textBox.Text,
                        order_day,
                        MainForm.Maker
                    );

                    if (order_dataGridView.Rows[i - 1].Cells[1].Value.ToString() == "" | order_dataGridView.Rows[i - 1].Cells[2].Value.ToString() == "")
                    {

                    }
                    else
                    {
                        orders.Add(order);
                    }
                }



                List<string> list = collect_OK_False_List(customer_id_textBox.Text);
                var index = int.Parse(order_dataGridView.Rows.Count.ToString());
                if (list.Count > 0)
                {
                    MessageBox.Show("注意！有筆款項未收！已將未收款項新增至此訂單！");

                    foreach (string item in list)
                    {
                        Order order = new Order(
                            order_id,
                            order_day,
                            index.ToString(),
                            "000",
                            $"{getOrderProductName(item)}",
                            collectFalseTotalMoney(item),
                            "1",
                            "False",
                            "False",
                            "0",
                            collectFalseTotalMoney(item),//小計金額
                            $"{item}",//備註：放未收款的訂單編號
                            customer_id_textBox.Text,
                            "不開",
                            "",
                            "False",
                            "0",
                            "現金",
                            "False",
                            "False",
                            "False",
                            bill_number_textBox.Text,
                            order_day,
                            MainForm.Maker
                        );
                        orders.Add(order);
                        index++;
                    }
                }

                if (isJoinOtherAddCollectFalseOrder(customer_id_textBox.Text).Count.ToString() != "0")
                {
                    List<string> list1 = isJoinOtherAddCollectFalseOrder(customer_id_textBox.Text);
                    DialogResult result1 = MessageBox.Show("系統偵測到此客戶其他地址有未收款，要一起加進此張訂單嗎?", "注意", MessageBoxButtons.YesNo);
                    if (result1 == DialogResult.Yes)
                    {
                        if (list1.Count > 0)
                        {
                            MessageBox.Show("注意！有筆款項未收！已將未收款項新增至此訂單！");
                            foreach (string item in list1)
                            {
                                Order order = new Order(
                                    order_id,
                                    order_day,
                                    index.ToString(),
                                    "000",
                                    $"{getOrderProductName(item)}",
                                    collectFalseTotalMoney(item),
                                    "1",
                                    "False",
                                    "False",
                                    "0",
                                    collectFalseTotalMoney(item),//小計金額
                                    $"{item}",//備註：放未收款的訂單編號
                                    customer_id_textBox.Text,
                                    "不開",
                                    "",
                                    "False",
                                    "0",
                                    "現金",
                                    "False",
                                    "False",
                                    "False",
                                    bill_number_textBox.Text,
                                    order_day,
                                    MainForm.Maker
                                );
                                orders.Add(order);
                                index++;
                            }
                        }
                    }
                    else
                    {

                    }
                }

                if (over_short_textBox.Text != "0")
                {
                    string num = over_short_textBox.Text;
                    num = num.Contains('-') ? num.Replace("-", "") : "-" + num;
                    MessageBox.Show("注意！此訂單已加入短溢收差額！");
                    Order order = new Order(
                        order_id,
                        order_day,
                        index.ToString(),
                        "000",
                        "短溢收",
                        $"{num}",
                        "1",
                        "False",
                        "False",
                        "0",
                        $"{num}",//小計金額
                        $"",//備註
                        customer_id_textBox.Text,
                        "不開",
                        "",
                        "False",
                        "0",
                        "現金",
                        "False",
                        "False",
                        "False",
                        bill_number_textBox.Text,
                        order_day,
                        MainForm.Maker
                    );
                    orders.Add(order);
                }

                var resultInsert = "";
                var is_have_new_remain = "False";
                foreach (var item in orders)
                {
                    string insertQuery =
                    "INSERT INTO `order` VALUES " +
                    $"('{item.Id}'," +
                    $"'{item.Day}'," +
                    $"'{item.ProductIndex}'," +
                    $"'{item.ProductID}'," +
                    $"'{item.ProductName}'," +
                    $"'{item.Price}'," +
                    $"'{item.Quantity}'," +
                    $"'{item.GiveFree}', " +
                    $"'{item.GiveNoFree}', " +
                    $"'{item.Tex}', " +
                    $"'{item.SubTotal}'," +
                    $"'{item.Remark}'," +
                    $"'{item.Customer}'," +
                    $"'{item.CustomerBillForm}'," +
                    $"'{item.Driver}'," +
                    $"'{item.IsOK}'," +
                    $"'{item.RecycleQuantity}'," +
                    $"'{item.CollectMoney}'," +
                    $"'{item.CollectOK}'," +
                    $"'{item.Assign_OK}'," +
                    $"'{item.DriverChange}'," +
                    $"'{item.BillNumber}'," +
                    $"'{item.Order_id_day}'," +
                    $"'{item.Maker}')";

                    var product_quantity = int.Parse(item.Quantity);
                    int remain = int.Parse(remain_textBox.Text);

                    if (item.CollectMoney == "預收" & item.GiveNoFree == "True")
                    {
                        if (remain < product_quantity)
                        {
                            if (is_have_new_remain == "False")
                            {
                                MessageBox.Show("請注意預收數量已不夠！");
                                //return;
                            }
                        }
                    }
                    else if (item.CollectMoney == "預收" & item.GiveNoFree == "False")
                    {
                        is_have_new_remain = "True";
                        insertQuery =
                            "INSERT INTO `order` VALUES " +
                            $"('{item.Id}'," +
                            $"'{item.Day}'," +
                            $"'{item.ProductIndex}'," +
                            $"'{item.ProductID}'," +
                            $"'{item.ProductName}'," +
                            $"'{item.Price}'," +
                            $"'{item.Quantity}'," +
                            $"'{item.GiveFree}', " +
                            $"'{item.GiveNoFree}', " +
                            $"'{item.Tex}', " +
                            $"'{item.SubTotal}'," +
                            $"'{item.Remark}'," +
                            $"'{item.Customer}'," +
                            $"'{item.CustomerBillForm}'," +
                            $"'{item.Driver}'," +
                            $"'{item.IsOK}'," +
                            $"'{item.RecycleQuantity}'," +
                            $"'{item.CollectMoney}'," +
                            $"'{item.CollectOK}'," +
                            $"'{item.Assign_OK}'," +
                            $"'{item.DriverChange}'," +
                            $"'{item.BillNumber}'," +
                            $"'{item.Order_id_day}'," +
                            $"'{item.Maker}')";
                    }

                    resultInsert = ConnectDatabase("新增", insertQuery).ToString();
                }

                if (resultInsert == "-1")
                {
                    MessageBox.Show("訂單資料儲存失敗!");
                }
                else
                {
                    DialogResult result3 = MessageBox.Show("是否列印訂單", "注意", MessageBoxButtons.YesNo);
                    if (result3 == DialogResult.Yes)
                    {
                        printOrder(orders[0].Id);
                    }
                    else
                    {

                    }
                    bill_number_textBox.Text = "";
                    tex_textBox.Text = "";
                    total_textBox.Text = "";
                    order_dataGridView.Rows.Clear();
                    order_dataGridView.Enabled = true;
                    driver_change_chb.Checked = false;
                    driver_change_chb.Enabled = true;
                    updateOrderListview();
                    updateMonthCollectOrderListview();
                    newOrderID(dateTimePicker.Value.ToString("yyyy/MM/dd"));
                    search_textBox.Text = "";
                    search_textBox.Focus();
                }
            }
        }
        //搬運樓層按鈕
        private void driver_floor_btn_Click(object sender, EventArgs e)
        {
            if (order_listview.SelectedItems.Count == 0) { return; }
            if (order_listview.SelectedItems[0].SubItems[8].Text == "" || order_listview.SelectedItems[0].SubItems[10].Text == "") { return; }
            string order_day = DateTime.Parse(order_listview.SelectedItems[0].SubItems[1].Text).ToString("yyyy-MM-dd");
            string order_id = order_listview.SelectedItems[0].SubItems[0].Text;
            string driver_name = order_listview.SelectedItems[0].SubItems[10].Text;
            string customer_id = customer_id_textBox.Text;
            string customer_name = customer_name_textbox.Text;
            string morningorafternoon = getMorningOrAfternoon(order_id);


            DriverFloorDetilForm mainForm = new DriverFloorDetilForm(order_day, order_id, driver_name, customer_id, customer_name, morningorafternoon);
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
        }
        //列印按鈕
        private void print_order_btn_Click(object sender, EventArgs e)
        {
            if (order_tabControl.SelectedTab != orderTap || order_listview.SelectedItems.Count == 0) { return; }
            string order_id = order_listview.SelectedItems[0].SubItems[0].Text;

            printOrder(order_id);
        }
        //收空桶按鈕
        private void myself_recyele_quantity_btn_Click(object sender, EventArgs e)
        {
            if (customer_id_textBox.Text == "") { return; }

            string customer_id = customer_id_textBox.Text;
            string bucket = bucket_textBox.Text;
            string customer_bill_form = bill_form_textBox.Text;
            string collect_money = collect_money_comboBox.Text;

            RecyeleQuantityForm mainForm = new RecyeleQuantityForm(customer_id, customer_bill_form, collect_money, bucket);
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();

            getClientData();
            updateOrderListview();
        }
        //收款狀態按鈕
        private void order_detil_btn_Click(object sender, EventArgs e)
        {
            if (order_tabControl.SelectedTab != orderTap || order_listview.SelectedItems.Count == 0) { return; }
            string order_id = order_listview.SelectedItems[0].SubItems[0].Text;
            string customer_id = customer_id_textBox.Text;
            string customer_name = customer_name_textbox.Text;

            OrderDataDetilForm mainForm = new OrderDataDetilForm(order_id, customer_id, customer_name);
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
        }
        //客戶備忘錄按鈕
        private void customer_memo_btn_Click(object sender, EventArgs e)
        {
            if (customer_id_textBox.Text == "") { return; }
            string customer_id = customer_id_textBox.Text;
            CustomerMemoForm mainForm = new CustomerMemoForm(customer_id);
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
        }


        private void OrderDataForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = order_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                order_listview.Columns[0].Width = (int)(totalWidth * 0.1108); // 第一欄占 30%
                order_listview.Columns[1].Width = (int)(totalWidth * 0.0852); // 第二欄占 30%
                order_listview.Columns[2].Width = (int)(totalWidth * 0.1193); // 第三欄占 40%
                order_listview.Columns[3].Width = (int)(totalWidth * 0.0426); // 第一欄占 30%
                order_listview.Columns[4].Width = (int)(totalWidth * 0.0426); // 第二欄占 30%
                order_listview.Columns[5].Width = (int)(totalWidth * 0.0426); // 第三欄占 40%
                order_listview.Columns[6].Width = (int)(totalWidth * 0.0682); // 第一欄占 30%
                order_listview.Columns[7].Width = (int)(totalWidth * 0.0682); // 第二欄占 30%
                order_listview.Columns[8].Width = (int)(totalWidth * 0.0426); // 第三欄占 40%
                order_listview.Columns[9].Width = (int)(totalWidth * 0.0426); // 第一欄占 30%
                order_listview.Columns[10].Width = (int)(totalWidth * 0.0596); // 第二欄占 30%
                order_listview.Columns[11].Width = (int)(totalWidth * 0.1023); // 第三欄占 40%
                order_listview.Columns[12].Width = (int)(totalWidth * 0.1705); // 第一欄占 30%
            }

            int totalWidth1 = order_dataGridView.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth1 > 0)
            {
                order_dataGridView.Columns[0].Width = (int)(totalWidth1 * 0.0256); // 第一欄占 30%
                order_dataGridView.Columns[1].Width = (int)(totalWidth1 * 0.0555); // 第二欄占 30%
                order_dataGridView.Columns[2].Width = (int)(totalWidth1 * 0.1537); // 第三欄占 40%
                order_dataGridView.Columns[3].Width = (int)(totalWidth1 * 0.0555); // 第一欄占 30%
                order_dataGridView.Columns[4].Width = (int)(totalWidth1 * 0.0555); // 第二欄占 30%
                order_dataGridView.Columns[5].Width = (int)(totalWidth1 * 0.0683); // 第三欄占 40%
                order_dataGridView.Columns[6].Width = (int)(totalWidth1 * 0.1024); // 第一欄占 30%
                order_dataGridView.Columns[7].Width = (int)(totalWidth1 * 0.0555); // 第二欄占 30%
                order_dataGridView.Columns[8].Width = (int)(totalWidth1 * 0.0555); // 第三欄占 40%
                order_dataGridView.Columns[9].Width = (int)(totalWidth1 * 0.0597); // 第一欄占 30%
                order_dataGridView.Columns[10].Width = (int)(totalWidth1 * 0.0683); // 第二欄占 30%
                order_dataGridView.Columns[11].Width = (int)(totalWidth1 * 0.4099); // 第三欄占 40%
            }

            int totalWidth2 = month_collect_order_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth2 > 0)
            {
                month_collect_order_listview.Columns[0].Width = (int)(totalWidth2 * 0.1108); // 第一欄占 30%
                month_collect_order_listview.Columns[1].Width = (int)(totalWidth2 * 0.0852); // 第二欄占 30%
                month_collect_order_listview.Columns[2].Width = (int)(totalWidth2 * 0.1193); // 第三欄占 40%
                month_collect_order_listview.Columns[3].Width = (int)(totalWidth2 * 0.0682); // 第一欄占 30%
                month_collect_order_listview.Columns[4].Width = (int)(totalWidth2 * 0.0426); // 第二欄占 30%
                month_collect_order_listview.Columns[5].Width = (int)(totalWidth2 * 0.0596); // 第三欄占 40%
                month_collect_order_listview.Columns[6].Width = (int)(totalWidth2 * 0.1023); // 第一欄占 30%
                month_collect_order_listview.Columns[7].Width = (int)(totalWidth2 * 0.1705); // 第二欄占 30%
            }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (customer_id_textBox.Text == "") { return; }
            string selectQuery = "SELECT MAX(order_id) FROM `order` " +
                    $"WHERE customer_id = '{customer_id_textBox.Text}' " +
                    "GROUP BY order_id, order_day ORDER BY order_day DESC,  order_id DESC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count == 0) { return; }

            int count = order_listview.Items.Count + month_collect_order_listview.Items.Count;
            string lastOrderID = order_listview.Items.Count == 0 ? month_collect_order_listview.Items[0].SubItems[0].Text : order_listview.Items[0].SubItems[0].Text;
            string lastMonthOrderID = month_collect_order_listview.Items.Count == 0 ? order_listview.Items[0].SubItems[0].Text : month_collect_order_listview.Items[0].SubItems[0].Text;
            if (datatable.Rows.Count != count || (datatable.Rows[0][0].ToString() != lastOrderID & datatable.Rows[0][0].ToString() != lastMonthOrderID))
            {
                updateOrderListview();
                updateMonthCollectOrderListview();
                newOrderID(dateTimePicker.Value.ToString("yyyy/MM/dd"));
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter && order_dataGridView.SelectedCells.Count > 0 && order_save_btn.Focused.ToString() == "True")
            {
                order_save_btn.PerformClick();
                return true;
            }
            if (keyData == Keys.Enter && order_dataGridView.SelectedCells.Count > 0)
            {
                int icolumn = order_dataGridView.CurrentCell.ColumnIndex;
                int irow = order_dataGridView.CurrentCell.RowIndex;
                if (icolumn == order_dataGridView.Columns.Count - 1)
                {
                    if (irow == order_dataGridView.Rows.Count - 1)
                    {

                    }
                    else
                    {
                        order_dataGridView.CurrentCell = order_dataGridView[1, irow + 1];
                    }
                }
                else
                {
                    order_dataGridView.CurrentCell = order_dataGridView[icolumn + 1, irow];
                }
                return true;
            }
            else if (keyData == Keys.Down && order_dataGridView.SelectedCells.Count > 0)
            {
                order_save_btn.Focus();
                Console.WriteLine(order_save_btn.Focused.ToString());
                return true;
            }
            else if (keyData == Keys.Space && order_dataGridView.SelectedCells.Count > 0 && order_dataGridView.CurrentCell.ColumnIndex == 5)
            {
                DataGridViewComboBoxEditingControl comboBoxEditingControl = order_dataGridView.EditingControl as DataGridViewComboBoxEditingControl;
                if (comboBoxEditingControl != null)
                {
                    //comboBoxEditingControl.DroppedDown = true;
                    int count = comboBoxEditingControl.Items.Count - 1;
                    int selectIndex = comboBoxEditingControl.SelectedIndex;

                    if (selectIndex == count)
                    {
                        comboBoxEditingControl.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxEditingControl.SelectedIndex = selectIndex + 1;
                    }
                }

                return true;
            }
            else if (keyData == Keys.Space && order_dataGridView.SelectedCells.Count > 0 && order_dataGridView.CurrentCell.ColumnIndex == 6)
            {
                DataGridViewComboBoxEditingControl comboBoxEditingControl = order_dataGridView.EditingControl as DataGridViewComboBoxEditingControl;
                if (comboBoxEditingControl != null)
                {
                    //comboBoxEditingControl.DroppedDown = true;
                    int count = comboBoxEditingControl.Items.Count - 1;
                    int selectIndex = comboBoxEditingControl.SelectedIndex;

                    if (selectIndex == count)
                    {
                        comboBoxEditingControl.SelectedIndex = 0;
                    }
                    else
                    {
                        comboBoxEditingControl.SelectedIndex = selectIndex + 1;
                    }
                }

                return true;
            }
            else if (keyData == Keys.Space && order_dataGridView.SelectedCells.Count > 0 && order_dataGridView.CurrentCell.ColumnIndex == 1)
            {
                string customer_id = customer_id_textBox.Text;
                int C = order_dataGridView.CurrentCell.ColumnIndex;
                int R = order_dataGridView.CurrentCell.RowIndex;
                ProductSearchForm mainForm = new ProductSearchForm(customer_id);
                mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
                mainForm.ShowDialog();
                order_dataGridView[1, R].Value = strValue;//顯示返回的值  
                order_dataGridView[3, R].Value = productPrice;//顯示返回的值  
                order_dataGridView.CurrentCell = order_dataGridView[4, R];
                return true;

            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }


        private string strValue;
        public string StrValue
        {
            set
            {
                strValue = value;
            }
        }

        private string productPrice;
        public string ProductPrice
        {
            set
            {
                productPrice = value;
            }
        }

        private string billNumber;
        public string BillNumber
        {
            set
            {
                billNumber = value;
            }
        }

        private string addressIndex;
        public string AddressIndex
        {
            set
            {
                addressIndex = value;
            }
        }
    }
}
