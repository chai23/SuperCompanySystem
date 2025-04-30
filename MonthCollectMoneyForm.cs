using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 超好企業系統
{
    public partial class MonthCollectMoneyForm : Form
    {
        public MonthCollectMoneyForm()
        {
            InitializeComponent();
            getMonthClientData();
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

        private void getMonthClientData()
        {
            alldata_listview.Items.Clear();
            var dayNow = dateTimePicker.Value;
            var order_day_1 = (dayNow.AddDays(dayNow.Day * -1).AddDays(1).Date).ToString("yyyy-MM-dd");
            var order_day_30 = (dayNow.AddDays(dayNow.Day * -1).AddDays(1).Date.AddMonths(1).AddMilliseconds(-1)).ToString("yyyy-MM-dd");
            string selectQuery = "SELECT c2.customer_id, c2.customer_name, c2.customer_telephone, c2.customer_bill_form, c2.customer_invoice, c2.customer_collect_money, SUM(o2.subtotal) as 金額, MAX(o2.bill_number) as bill_number " +
                "FROM `order` as o2 " +
                "JOIN `customer` as c2 " +
                $"WHERE o2.customer_id = c2.customer_id AND o2.order_OK = 'True' AND o2.collect_OK = 'False' AND o2.collect_money = '月結' AND o2.order_day >= '{order_day_1}' AND o2.order_day <= '{order_day_30}' " +
                "GROUP BY c2.customer_id";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable == null)  { return; }
            if (datatable != null & datatable.Rows.Count != 0)
            {
                alldata_listview.Items.Clear();

                foreach (DataRow row in datatable.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    for (int i = 1; i < datatable.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    alldata_listview.Items.Add(item);
                }
            }
        }

        private List<Order> getOrders(string order_id)
        {
            List<Order> orders = new List<Order>();
            string selectQuery = "SELECT product_index, product_name, product_price, product_quantity, subtotal FROM `order` " +
                $"WHERE order_id = {order_id} ";
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

        private void alldata_listview_DoubleClick(object sender, EventArgs e)
        {
            List<PrintMonthOrder> printMonthOrders = new List<PrintMonthOrder>();
            string customer_id = alldata_listview.SelectedItems[0].SubItems[0].Text;

            var dayNow = dateTimePicker.Value;
            var order_day_1 = (dayNow.AddDays(dayNow.Day * -1).AddDays(1).Date).ToString("yyyy-MM-dd");
            var order_day_30 = (dayNow.AddDays(dayNow.Day * -1).AddDays(1).Date.AddMonths(1).AddMilliseconds(-1)).ToString("yyyy-MM-dd");

            string selectQuery = "SELECT o2.order_id, o2.order_day, SUM(o2.subtotal), c2.customer_id, c2.customer_name, c2.customer_telephone, c2.customer_bill_form, c2.customer_invoice " +
                "FROM `order` as o2 " +
                "JOIN `customer` as c2 " +
                $"WHERE c2.customer_id = '{customer_id}' AND o2.customer_id = c2.customer_id AND o2.order_OK = 'True' AND o2.collect_OK = 'False' AND o2.collect_money = '月結' AND o2.order_day >= '{order_day_1}' AND o2.order_day <= '{order_day_30}' " +
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
                printMonthOrder.Print_people = "李嘉民";
                printMonthOrder.Driver_name = "";
                printMonthOrder.Total = alldata_listview.SelectedItems[0].SubItems[6].Text;
                printMonthOrder.Orders = getOrders(row[0].ToString());

                printMonthOrders.Add(printMonthOrder);
            }

            PrintHelper printHelper = new PrintHelper(printMonthOrders);
            printHelper.printPreviewA4("notPrint");
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (alldata_listview.SelectedItems.Count == 0) {  return; }
            List<PrintMonthOrder> printMonthOrders = new List<PrintMonthOrder>();
            string customer_id = alldata_listview.SelectedItems[0].SubItems[0].Text;

            var dayNow = dateTimePicker.Value;
            var order_day_1 = (dayNow.AddDays(dayNow.Day * -1).AddDays(1).Date).ToString("yyyy-MM-dd");
            var order_day_30 = (dayNow.AddDays(dayNow.Day * -1).AddDays(1).Date.AddMonths(1).AddMilliseconds(-1)).ToString("yyyy-MM-dd");

            string selectQuery = "SELECT o2.order_id, o2.order_day, SUM(o2.subtotal), c2.customer_id, c2.customer_name, c2.customer_telephone, c2.customer_bill_form, c2.customer_invoice " +
                "FROM `order` as o2 " +
                "JOIN `customer` as c2 " +
                $"WHERE c2.customer_id = '{customer_id}' AND o2.customer_id = c2.customer_id AND o2.order_OK = 'True' AND o2.collect_OK = 'False' AND o2.collect_money = '月結' AND o2.order_day >= '{order_day_1}' AND o2.order_day <= '{order_day_30}' " +
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
                printMonthOrder.Print_people = "李嘉民";
                printMonthOrder.Driver_name = "";
                printMonthOrder.Total = alldata_listview.SelectedItems[0].SubItems[6].Text;
                printMonthOrder.Orders = getOrders(row[0].ToString());

                printMonthOrders.Add(printMonthOrder);
            }

            PrintHelper printHelper = new PrintHelper(printMonthOrders);
            printHelper.printPreviewA4("Print");
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            getMonthClientData();
        }

        private void MonthCollectMoneyForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = alldata_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                alldata_listview.Columns[0].Width = (int)(totalWidth * 0.0821); // 第一欄占 30%
                alldata_listview.Columns[1].Width = (int)(totalWidth * 0.2281); // 第二欄占 30%
                alldata_listview.Columns[2].Width = (int)(totalWidth * 0.1368); // 第三欄占 40%
                alldata_listview.Columns[3].Width = (int)(totalWidth * 0.0912); // 第一欄占 30%
                alldata_listview.Columns[4].Width = (int)(totalWidth * 0.1368); // 第二欄占 30%
                alldata_listview.Columns[5].Width = (int)(totalWidth * 0.0912); // 第三欄占 40%
                alldata_listview.Columns[6].Width = (int)(totalWidth * 0.0912); // 第三欄占 40%
                alldata_listview.Columns[7].Width = (int)(totalWidth * 0.1368); // 第三欄占 40%
            }
        }
    }
}
