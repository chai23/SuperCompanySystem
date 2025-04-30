using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 超好企業系統
{
    public partial class DriverFloorForm : Form
    {
        public DriverFloorForm()
        {
            InitializeComponent();
            getDriverDataToCombobox();
            updateDriverFloorListView();
            morningorafter_comboBox.SelectedIndex = 0;
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

        private Boolean getIsRegister(string register_id)
        {
            string selectQuery = "SELECT register_id FROM driver_floor " +
                $"WHERE register_id = '{register_id}'";
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

        private void updateDriverFloorListView()
        {
            if (driver_comboBox.Text == "")
            {
                return;
            }
            driver_floor_listview.Items.Clear();
            string driver_id = getDriverNameOrID("name", driver_comboBox.Text);

            string selectQuery = "SELECT * FROM driver_floor " +
                $"WHERE driver_id = '{driver_id}' " +
                "ORDER BY register_day DESC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows.Count == 0 || datatable == null) { return; } 

            foreach (DataRow data in datatable.Rows)
            {
                ListViewItem item = new ListViewItem(DateTime.Parse(data[2].ToString()).ToString("yyyy-MM-dd"));//日期
                item.SubItems.Add(getDriverNameOrID("id", data[1].ToString()));//司機
                item.SubItems.Add(data[3].ToString());//上午/下午
                item.SubItems.Add(data[4].ToString());//二樓
                item.SubItems.Add(data[5].ToString());//三樓
                item.SubItems.Add(data[6].ToString());//四樓
                item.SubItems.Add(data[7].ToString());//B1

                driver_floor_listview.Items.Add(item);
            }
        }
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void order_save_btn_Click(object sender, EventArgs e)
        {
            if (driver_comboBox.Text == "")
            {
                MessageBox.Show("請選擇司機");
                return;
            }
            string driver_id = getDriverNameOrID("name", driver_comboBox.Text);
            string register_day = driver_floor_day_dtp.Value.ToString("yyyy-MM-dd");
            string register_time = morningorafter_comboBox.Text;
            string two_quantity = two_product_quantity.Text == "" ? "0" : two_product_quantity.Text;
            string three_quantity = three_product_quantity.Text == "" ? "0" : three_product_quantity.Text;
            string four_quantity = four_product_quantity.Text == "" ? "0" : four_product_quantity.Text;
            string B1_quantity = B1_product_quantity.Text == "" ? "0" : B1_product_quantity.Text;
            string register_id = driver_floor_day_dtp.Value.ToString("yyyyMMdd") + driver_id + (register_time == "上午" ? "morning" : "afternoon");
            int a = 0, b = 0;

            if (getIsRegister(register_id) == true)
            {
                DialogResult result = MessageBox.Show("此筆紀錄已經登記過，是否要修改資料", "注意", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if ( int.TryParse(two_quantity, out a) && int.TryParse(three_quantity, out b))
                    {
                        string insertQuery =
                            "UPDATE `driver_floor` SET " +
                            $"two_product_quantity = '{two_quantity}', " +
                            $"three_product_quantity = '{three_quantity}', " +
                            $"four_product_quantity = '{four_quantity}', " +
                            $"B1_product_quantity = '{B1_quantity}' " +
                            $"WHERE register_id = '{register_id}'";

                        ConnectDatabase("新增", insertQuery);
                        updateDriverFloorListView();
                    }
                    else
                    {
                        MessageBox.Show("請輸入正確的數量");
                    }
                    return;
                }
                else
                {
                    return;
                }
            }

            if (int.TryParse(two_quantity, out a) && int.TryParse(three_quantity, out b))
            {
                string insertQuery =
                    "INSERT INTO `driver_floor` VALUES " +
                    $"('{register_id}'," +
                    $"'{driver_id}'," +
                    $"'{register_day}'," +
                    $"'{register_time}'," +
                    $"'{two_quantity}'," +
                    $"'{three_quantity}'," +
                    $"'{four_quantity}'," +
                    $"'{B1_quantity}')";

                ConnectDatabase("新增", insertQuery);

                two_product_quantity.Text = "";
                three_product_quantity.Text = "";
                four_product_quantity.Text = "";
                B1_product_quantity.Text = "";
                updateDriverFloorListView();
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

        private void driver_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDriverFloorListView();
        }

        private void DriverFloorForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = driver_floor_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                driver_floor_listview.Columns[0].Width = (int)(totalWidth * 0.2380); // 第一欄占 30%
                driver_floor_listview.Columns[1].Width = (int)(totalWidth * 0.1831); // 第二欄占 30%
                driver_floor_listview.Columns[2].Width = (int)(totalWidth * 0.1465); // 第三欄占 40%
                driver_floor_listview.Columns[3].Width = (int)(totalWidth * 0.1098); // 第一欄占 30%
                driver_floor_listview.Columns[4].Width = (int)(totalWidth * 0.1098); // 第二欄占 30%
                driver_floor_listview.Columns[5].Width = (int)(totalWidth * 0.1098); // 第三欄占 40%
                driver_floor_listview.Columns[6].Width = (int)(totalWidth * 0.1098); // 第三欄占 40%
            }
        }
    }
}
