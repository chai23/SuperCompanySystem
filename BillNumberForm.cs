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
    public partial class BillNumberForm : Form
    {
        public BillNumberForm()
        {
            InitializeComponent();
        }

        public BillNumberForm(string order_id, string whoCall)
        {
            InitializeComponent();
            this.OrderID = order_id;
            this.WhoCall = whoCall;
        }

        private string OrderID {  get; set; }

        private string WhoCall { get; set; }

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

        private List<Order> getOrderDate(string order_id)
        {
            List<Order> orders = new List<Order>();
            string selectQuery = "SELECT * FROM `order` " +
                $"WHERE order_id = '{order_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            foreach (DataRow item in datatable.Rows)
            {
                Order order = new Order(
                    item[0].ToString(),//ID
                    item[1].ToString(),//訂單日期
                    item[2].ToString(),//商品順序
                    item[3].ToString(),//商品ID
                    item[4].ToString(),//商品名稱
                    item[5].ToString(),//價格
                    item[6].ToString(),//數量
                    item[7].ToString(),//搭贈
                    item[8].ToString(),//補送
                    item[9].ToString(),//稅額
                    item[10].ToString(),//小計
                    item[11].ToString(),//備註
                    item[12].ToString(),
                    item[13].ToString(),
                    item[14].ToString(),
                    item[15].ToString(),
                    item[16].ToString(),
                    item[17].ToString(),
                    item[18].ToString(),
                    item[19].ToString(),
                    item[20].ToString(),
                    item[21].ToString(),
                    item[22].ToString(),
                    item[23].ToString()
                );
                orders.Add( order );
            }

            return orders;
        }

        private void updateOrder(List<Order> orders)
        {
            string order_id = orders[0].Id;
            string removeQuery =
                "DELETE FROM `order` WHERE " +
                $"order_id = '{order_id}'";
            ConnectDatabase("刪除", removeQuery);

            foreach (var item in orders)
            {
                string insertQuery =
                "INSERT INTO `order` VALUES " +
                $"('{item.Id}'," +
                $"'{DateTime.Parse(item.Day).ToString("yyyy-MM-dd")}'," +
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
                $"'{DateTime.Parse(item.Order_id_day).ToString("yyyy-MM-dd")}'," +
                $"'{item.Maker}')";

                ConnectDatabase("新增", insertQuery).ToString();
            }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void order_save_btn_Click(object sender, EventArgs e)
        {
            var bill_number = bill_number_textBox.Text;

            if (money_textbox.Text != "")
            {
                int money = 0;
                if (int.TryParse(money_textbox.Text, out money)){
                    List<Order> orders = getOrderDate(OrderID);

                    Order order = new Order(
                        orders[0].Id,//ID
                        orders[0].Day,//訂單日期
                        (orders.Count + 1).ToString(),//商品順序
                        "205",//商品ID
                        "稅金折讓費",//商品名稱
                        money_textbox.Text,//價格
                        "1",//數量
                        "False",//搭贈
                        "False",//補送
                        "0",//稅額
                        money_textbox.Text,//小計
                        WhoCall,//備註
                        orders[0].Customer,
                        orders[0].CustomerBillForm,
                        orders[0].Driver,
                        orders[0].IsOK,
                        orders[0].RecycleQuantity,
                        orders[0].CollectMoney,
                        orders[0].CollectOK,
                        orders[0].Assign_OK,
                        orders[0].DriverChange,
                        orders[0].BillNumber,
                        orders[0].Order_id_day,
                        orders[0].Maker
                    );
                    orders.Add(order);

                    updateOrder(orders);

                }
                else
                {
                    MessageBox.Show("折讓金額請輸入正確!");
                    return;
                }
            }

            OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.BillNumber = bill_number;//使用父窗口指針賦值  
            this.Close();
            
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            var bill_number = "";

            OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.BillNumber = bill_number;//使用父窗口指針賦值  
            this.Close();
            
        }
    }
}
