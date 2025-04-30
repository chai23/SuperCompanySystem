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
    public partial class UpdateWaterdispenserForm : Form
    {
        public UpdateWaterdispenserForm()
        {
            InitializeComponent();
            updateDriver();
            getNewDispenserID();
            dispenser_id_textBox.Enabled = false;
            dispenser_OK_btn.Text = "新增完成";

            label7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            output_day_dtp.Visible = false;
            money_day_dtp.Visible = false;
            driver_comboBox.Visible = false;
        }
        public UpdateWaterdispenserForm(string customer_id, string whoCall)
        {
            InitializeComponent();
            updateDriver();
            getNewDispenserID();
            dispenser_id_textBox.Enabled = false;
            dispenser_OK_btn.Text = "新增完成";
            customer_id_textbox.Text = customer_id;
            customer_name_textBox.Text = getCustomerNameOrID("id", customer_id);
            customer_id_textbox.Enabled = false;
            customer_name_textBox.Enabled = false;

            label7.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            output_day_dtp.Visible = false;
            money_day_dtp.Visible=false;
            driver_comboBox.Visible = false;
        }

        public UpdateWaterdispenserForm(string dispenser_id)
        {
            InitializeComponent();
            updateDriver();
            dispenser_id_textBox.Enabled = false;
            customer_id_textbox.Enabled = false;
            customer_name_textBox.Enabled = false;
            dispenser_OK_btn.Text = "修改完成";
            updateDispenserData(dispenser_id);
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

        private void updateDispenserData(string dispenser_id)
        {
            string selectQuery = "SELECT * FROM `water_dispenser_list` " +
                $"WHERE dispenser_id = {dispenser_id}";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            dispenser_id_textBox.Text = dispenser_id;
            customer_id_textbox.Text = datatable.Rows[0][1].ToString();
            customer_name_textBox.Text = datatable.Rows[0][2].ToString();
            desktop_brand_textBox.Text = datatable.Rows[0][3].ToString();
            upright_brand_textBox.Text = datatable.Rows[0][4].ToString();
            wash_textBox.Text = datatable.Rows[0][5].ToString();
            repair_textBox.Text = datatable.Rows[0][6].ToString();
            input_day_dtp.Value = DateTime.Parse(datatable.Rows[0][7].ToString());
            output_day_dtp.Value = DateTime.Parse(datatable.Rows[0][8].ToString());
            money_day_dtp.Value = DateTime.Parse(datatable.Rows[0][9].ToString());
            driver_comboBox.Text = datatable.Rows[0][10].ToString();
            error_textBox.Text = datatable.Rows[0][12].ToString();
        }
        private void updateDriver()
        {
            driver_comboBox.Items.Clear();
            string selectQuery = "SELECT driver_name FROM `driver`";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            foreach (DataRow item in datatable.Rows)
            {
                driver_comboBox.Items.Add(item[0]);
            }
            driver_comboBox.Items.Add("報廢無載回");
        }
        private string getCustomerNameOrID(string nameOrid, string value)
        {
            if (nameOrid == "name")
            {
                string selectQuery = "SELECT customer_id FROM customer " +
                $"WHERE customer_name = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else if (nameOrid == "id")
            {
                string selectQuery = "SELECT customer_name FROM customer " +
                $"WHERE customer_id = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }
        private void getNewDispenserID()
        {
            string selectQuery = "SELECT dispenser_id FROM `water_dispenser_list`" +
                    "ORDER BY dispenser_id DESC limit 1";
            DataTable datatable =  ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable == null || datatable.Rows.Count == 0) 
            {
                dispenser_id_textBox.Text = "00001";
            }
            else
            {
                dispenser_id_textBox.Text = (int.Parse(datatable.Rows[0][0].ToString()) + 1).ToString().PadLeft(5, '0');
            }
        }
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dispenser_OK_btn_Click(object sender, EventArgs e)
        {
            if (dispenser_id_textBox.Text == "" || customer_id_textbox.Text == "")
            { 
                MessageBox.Show("資料不完整！無法完成！");
                return;
            }

            if (dispenser_OK_btn.Text == "新增完成") 
            {
                string insertQuery =
                    "INSERT INTO `water_dispenser_list` VALUES " +
                    $"('{dispenser_id_textBox.Text}'," +
                    $"'{customer_id_textbox.Text}'," +
                    $"'{customer_name_textBox.Text}'," +
                    $"'{desktop_brand_textBox.Text}'," +
                    $"'{upright_brand_textBox.Text}'," +
                    $"'{wash_textBox.Text}'," +
                    $"'{repair_textBox.Text}'," +
                    $"'{input_day_dtp.Value.ToString("yyyy-MM-dd")}'," +
                    $"'{output_day_dtp.Value.ToString("yyyy-MM-dd")}'," +
                    $"'{money_day_dtp.Value.ToString("yyyy-MM-dd")}'," +
                    $"'{driver_comboBox.Text}'," +
                    $"'False'," +
                    $"'{error_textBox.Text}')";

                string result = ConnectDatabase("新增", insertQuery).ToString();
                if (result == "-1")
                {
                    MessageBox.Show("儲存失敗");
                }
                else
                {
                    this.Close();
                }
            }
            else if (dispenser_OK_btn.Text == "修改完成")
            {
                string reviseQuery =
                    "UPDATE `water_dispenser_list` SET " +
                    $"desktop_brand = '{desktop_brand_textBox.Text}', " +
                    $"upright_brand = '{upright_brand_textBox.Text}', " +
                    $"wash = '{wash_textBox.Text}', " +
                    $"repair = '{repair_textBox.Text}', " +
                    $"input_day = '{input_day_dtp.Value.ToString("yyyy-MM-dd")}', " +
                    $"output_day = '{output_day_dtp.Value.ToString("yyyy-MM-dd")}', " +
                    $"money_day = '{money_day_dtp.Value.ToString("yyyy-MM-dd")}', " +
                    $"driver_id = '{driver_comboBox.Text}', " +
                    $"error = '{error_textBox.Text}' " +
                    $"WHERE dispenser_id = '{dispenser_id_textBox.Text}'";

                if (ConnectDatabase("修改", reviseQuery).ToString() == "1")
                {
                    MessageBox.Show("檔案修改成功");
                    this.Close();
                }
                else
                { MessageBox.Show("檔案修改失敗"); }
            }
        }
    }
}
