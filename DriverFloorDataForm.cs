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
    public partial class DriverFloorDataForm : Form
    {
        public DriverFloorDataForm()
        {
            InitializeComponent();
            getDriverDataToCombobox();
            morningorafter_comboBox.SelectedIndex = 0;
            driver_comboBox.SelectedIndex = 0;
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

        private void updataDriverFloorListView()
        {
            driver_floor_listview.Items.Clear();

            string order_day = driver_floor_day_dtp.Value.ToString("yyyy-MM-dd");
            string driver_id = getDriverNameOrID("name", driver_comboBox.Text);
            string morningorafternoon = morningorafter_comboBox.Text;

            int four_floor = 0;
            int three_floor = 0;
            int two_floor = 0;
            int B1_floor = 0;

            string selectQuery = "SELECT *  FROM `driver_floor_detil` " +
                $"WHERE order_day = '{order_day}' and driver_id = '{driver_id}' and morningorafternoon = '{morningorafternoon}' " +
                $"ORDER BY order_day DESC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            Console.WriteLine(selectQuery );
            if (datatable.Rows.Count == 0 || datatable == null) { return; }

            foreach (DataRow row in datatable.Rows)
            {
                ListViewItem item = new ListViewItem(row[2].ToString());//訂單編號
                item.SubItems.Add(row[4].ToString());//客戶編號
                item.SubItems.Add(row[7].ToString());//上午/下午
                item.SubItems.Add(row[5].ToString() == "二樓" ? row[6].ToString() : "");//二樓
                item.SubItems.Add(row[5].ToString() == "三樓" ? row[6].ToString() : "");//三樓
                item.SubItems.Add(row[5].ToString() == "四樓" ? row[6].ToString() : "");//四樓
                item.SubItems.Add(row[5].ToString() == "B1" ? row[6].ToString() : "");//B1
                item.SubItems.Add(row[0].ToString());//driver_floor_id

                driver_floor_listview.Items.Add(item);

                switch (row[5].ToString())
                {
                    case "二樓":
                        two_floor += int.Parse(row[6].ToString());
                        break;
                    case "三樓":
                        three_floor += int.Parse(row[6].ToString());
                        break;
                    case "四樓":
                        four_floor += int.Parse(row[6].ToString());
                        break;
                    case "B1":
                        B1_floor += int.Parse(row[6].ToString());
                        break;
                }
            }

            four_product_quantity.Text = four_floor.ToString();
            three_product_quantity.Text = three_floor.ToString();
            two_product_quantity.Text = two_floor.ToString();
            B1_product_quantity.Text = B1_floor.ToString();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void driver_floor_listview_DoubleClick(object sender, EventArgs e)
        {

        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            updataDriverFloorListView();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DriverFloorDataForm_Resize(object sender, EventArgs e)
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
                driver_floor_listview.Columns[7].Width = (int)(totalWidth * 0); // 第三欄占 40%
            }
        }
    }
}
