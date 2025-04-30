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
    public partial class ReviceCustomerArea : Form
    {
        public ReviceCustomerArea()
        {
            InitializeComponent();
            InputAreaDataToListbox();
            InputLastClientDataToSingleTap();
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
            area_id_2_comboBox.Items.Clear();
            string selectQuery = "SELECT * FROM area";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count != 0)
            {
                foreach (DataRow item in datatable.Rows)
                {
                    area_id_comboBox.Items.Add(item[1]);
                    area_id_2_comboBox.Items.Add(item[1]);
                }
            }
        }

        private void InputClientDataToSingleTap(string customer_id)
        {

            string selectQuery = "SELECT * FROM customer " +
                $"WHERE customer_id = '{customer_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows.Count != 0)
            {
                customer_id_textbox.Text = datatable.Rows[0][0].ToString();
                customer_name_textbox.Text = datatable.Rows[0][1].ToString();
                customer_address_textbox.Text = datatable.Rows[0][2].ToString();
                contact_person_textbox.Text = datatable.Rows[0][3].ToString();
                customer_phone_textbox.Text = datatable.Rows[0][4].ToString();
                customer_telephone_textbox.Text = datatable.Rows[0][5].ToString();
                bill_form_comboBox.Text = datatable.Rows[0][6].ToString();
                customer_invoice_textbox.Text = datatable.Rows[0][7].ToString();
                customer_bill_address_textbox.Text = datatable.Rows[0][8].ToString();
                collect_money_comboBox.Text = datatable.Rows[0][9].ToString();
                area_id_comboBox.Text = getAreaNameOrID("id", datatable.Rows[0][12].ToString());
                area_id_2_comboBox.Text = getAreaNameOrID("id", datatable.Rows[0][13].ToString());
                company_comboBox.Text = datatable.Rows[0][14].ToString();
                customer_remark_textBox.Text = datatable.Rows[0][15].ToString();
            }
        }
        //把最後一筆資料放到單筆資料的頁面
        private void InputLastClientDataToSingleTap()
        {
            string selectQuery = "SELECT customer_id_mark FROM customer " +
                $"ORDER BY customer_id_mark DESC LIMIT 0 , 1";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            InputClientDataToSingleTap(datatable.Rows[0][0].ToString());
        }
        private void ChangeData(object sender)
        {
            Button btn = sender as Button;
            string selectQuery = "SELECT customer_id FROM customer ORDER BY customer_id ASC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            switch (btn.Name)
            {
                case "first_data_btn":
                    if (datatable.Rows.Count != 0)
                    {
                        InputClientDataToSingleTap(datatable.Rows[0][0].ToString());
                    }
                    break;
                case "up_data_btn":
                    if (customer_id_textbox.Text != "")
                    {
                        if (datatable.Rows.Count == 0) { return; }
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if (customer_id_textbox.Text == datatable.Rows[i][0].ToString())
                            {
                                if (i == 0) { return; }
                                InputClientDataToSingleTap(datatable.Rows[i - 1][0].ToString());
                                return;
                            }
                        }
                    }
                    break;
                case "down_data_btn":
                    if (customer_id_textbox.Text != "")
                    {
                        if (datatable.Rows.Count == 0) { return; }
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if (customer_id_textbox.Text == datatable.Rows[i][0].ToString())
                            {
                                if (i == datatable.Rows.Count - 1) { return; }
                                InputClientDataToSingleTap(datatable.Rows[i + 1][0].ToString());
                                return;
                            }
                        }
                    }
                    break;
                case "last_data_btn":
                    if (datatable.Rows.Count != 0)
                    {
                        var count = datatable.Rows.Count - 1;
                        InputClientDataToSingleTap(datatable.Rows[count][0].ToString());
                    }
                    break;
                default:
                    break;
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
        private void up_data_btn_Click(object sender, EventArgs e)
        {
            ChangeData(sender);
        }

        private void down_data_btn_Click(object sender, EventArgs e)
        {
            ChangeData(sender);
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string reviseQuery =
                "UPDATE customer SET " +
                $"area_id = '{getAreaNameOrID("name",area_id_comboBox.Text)}', " +
                $"area_id_2 = '{getAreaNameOrID("name", area_id_2_comboBox.Text)}' " +
                $"WHERE customer_id = '{customer_id_textbox.Text}'";
            ConnectDatabase("修改", reviseQuery).ToString();
        }
    }
}
