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
    public partial class DriverFloorDetilForm : Form
    {
        public DriverFloorDetilForm(string order_day, string order_id, string driver_name, string customer_id, string customer_name, string morningorafternoon)
        {
            InitializeComponent();
            floor_comboBox.SelectedIndex = 0;

            order_day_textbox.Text = order_day;
            order_id_extbox.Text = order_id;
            driver_name_textbox.Text = driver_name;
            customer_id_textbox.Text = customer_id;
            customer_name_textbox.Text = customer_name;
            morningorafternoon_textbox.Text = morningorafternoon;

            this.Order_day = order_day;
            this.Order_id = order_id;
            this.Driver_name = driver_name;
            this.Customer_id = customer_id;
            this.Customer_name = customer_name;
            this.Morningorafternoon = morningorafternoon;
        }
        private string Order_day {  get; set; }
        private string Order_id { get; set; }
        private string Driver_name { get; set; }
        private string Customer_id { get; set; }
        private string Customer_name { get; set; }
        private string Morningorafternoon { get; set; }
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
        private string newDriverFloorID(string order_day)
        {
            string selectQuery = "SELECT driver_floor_id FROM `driver_floor_detil` " +
                $"WHERE order_day = '{order_day}' " +
                "ORDER BY driver_floor_id DESC LIMIT 0 , 1";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            Console.WriteLine(selectQuery);
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
        private string getDriverNameOrID(string nameOrid, string value)
        {
            if (value == "")
            {
                return "";
            }
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
        private Boolean isHaveOrderID(string order_id)
        {
            string selectQuery = "SELECT order_id " +
                "FROM `driver_floor_detil` " +
                $"WHERE order_id = '{order_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows.Count == 0 || datatable == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void order_save_btn_Click(object sender, EventArgs e)
        {
            if(isHaveOrderID(Order_id) == true)
            {
                DialogResult result = MessageBox.Show("此訂單已經登錄過!還要登陸其他樓層嗎?", "注意", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                }
                else
                {
                    return;
                }
            }

            string driver_floor_id = newDriverFloorID(Order_day);
            int a = 0;
            if (int.TryParse(product_quantity_textbox.Text, out a))
            {
                string insertQuery =
                    "INSERT INTO `driver_floor_detil` VALUES " +
                    $"('{driver_floor_id}'," +
                    $"'{Order_day}'," +
                    $"'{Order_id}'," +
                    $"'{getDriverNameOrID("name", Driver_name)}'," +
                    $"'{Customer_id}'," +
                    $"'{floor_comboBox.Text}'," +
                    $"'{product_quantity_textbox.Text}'," +
                    $"'{Morningorafternoon}'," +
                    $"'{MainForm.Maker}')";

                ConnectDatabase("新增", insertQuery);
                this.Close();
            }
            else
            {
                MessageBox.Show("請輸入正確的數量");
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
