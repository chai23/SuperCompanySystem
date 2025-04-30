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
    public partial class RemittanceInputForm : Form
    {
        public RemittanceInputForm()
        {
            InitializeComponent();
        }
        public RemittanceInputForm(List<string> order_id_list, List<string> total_money_list, string customer_id)
        {
            InitializeComponent();
            oorder_id_list = order_id_list;
            ttotal_money_list = total_money_list;
            ccustomer_id = customer_id;
            inputTotalMoney(total_money_list);
            over_short_textBox.Text = "0";
            whoCall = "order";
            morningorafter_comboBox_report.SelectedIndex = 0;
            money_remittance_comboBox.SelectedIndex = 0;
            bank_comboBox.SelectedIndex = 0;
        }

        public RemittanceInputForm(string order_id, string totalMoney, string customer_id)
        {
            InitializeComponent();
            oorder_id = order_id;
            ttotalMoney = totalMoney;
            ccustomer_id = customer_id;
            driver_money_textBox.Text = totalMoney;
            over_short_textBox.Text = "0";
            whoCall = "month";
            morningorafter_comboBox_report.SelectedIndex = 0;
            money_remittance_comboBox.SelectedIndex = 0;
            bank_comboBox.SelectedIndex = 0;
        }

        private List<string> oorder_id_list;
        private List<string> ttotal_money_list;
        private string oorder_id;
        private string ttotalMoney;
        private string ccustomer_id;
        private string whoCall;

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

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
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
        private string getOrderDay(string order_id)
        {
            string selectQuery = "SELECT DATE_FORMAT(order_day,'%Y-%m-%d') FROM `order` " +
                $"WHERE order_id = '{order_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            return datatable.Rows[0][0].ToString();
        }
        private string getCustomerNameOrID(string nameOrid, string value)
        {
            if (value == "")
            {
                return "";
            }
            if (nameOrid == "name")
            {
                string selectQuery = "SELECT customer_id FROM `customer` " +
                $"WHERE customer_name = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else if (nameOrid == "id")
            {
                string selectQuery = "SELECT customer_name FROM `customer` " +
                $"WHERE customer_id = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }
        private void inputTotalMoney(List<string> total_money_list)
        {
            int total = 0;
            foreach (string item in total_money_list)
            {
                total += int.Parse(item);
            }
            driver_money_textBox.Text = total.ToString();
        }
        private int getRemittanceID()
        {
            string selectQuery = "SELECT remittance_list_id FROM `remittance_list` ORDER BY remittance_list_id DESC LIMIT 0, 1";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null | datatable.Rows.Count == 0)
            {
                return 0;
            }
            return int.Parse(datatable.Rows[0][0].ToString());
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (money_remittance_comboBox.Text == "司機收錢")
            {
                if (whoCall == "order")
                {
                    string order_day = dateTimePicker.Value.ToString("yyyy-MM-dd");
                    string order_driver_name;
                    
                    /*for (int i = 0; i < oorder_id_list.Count; i++)
                    {
                        order_driver_name = getOrderDriverName(oorder_id_list[i]);
                        if (order_driver_name == bank_comboBox.Text)
                        {
                            MessageBox.Show("收款司機不可以跟原送貨司機一樣!");
                            return;
                        }
                    }*/

                    for (int i = 0; i < oorder_id_list.Count; i++)
                    {
                        string insertQuery =
                            "INSERT INTO `report_day` VALUES " +
                            $"('{oorder_id_list[i]}'," +//order_id
                            $"'{order_day}'," +//order_day
                            $"'{bank_comboBox.Text}'," +//driver_id
                            $"'{"純收款"}'," +//product_name
                            $"'{ttotal_money_list[i]}'," +//product_price
                            $"'{"1"}'," +//product_quantity
                            $"'{ttotal_money_list[i]}'," +//subtotal
                            $"'{"True"}'," +//collect_OK
                            $"'{"現金"}'," +//remark
                            $"'{ccustomer_id}'," +//customer_id
                            $"'{"0"}'," +//recyele_quantity
                            $"'{"現金"}'," +//collect_money
                            $"'{"1"}'," +//product_index
                            $"'{morningorafter_comboBox_report.Text}')";//morningorafter

                        string resultInsert = ConnectDatabase("新增", insertQuery).ToString();
                        if (resultInsert == "-1")
                        {
                            MessageBox.Show("登錄錯誤!");
                            return;
                        }

                        string reviseQuery =
                            "UPDATE `order` SET " +
                            $"collect_OK = 'True'" +
                            $"WHERE order_id = '{oorder_id_list[i]}'";
                        ConnectDatabase("修改", reviseQuery);

                        //出現短溢收
                        if (over_short_textBox.Text != "0" && i == 0)
                        {
                            string insertQuery2 =
                                "INSERT INTO `money_over_short` VALUES " +
                                $"('{getMoneyOverShortID()}', " + //money_over_short_id
                                $"'{ccustomer_id}', " + //customer_id
                                $"'{getCustomerNameOrID("id", ccustomer_id)}', " + //customer_name
                                $"'{over_short_textBox.Text}', " + //money
                                $"'{oorder_id_list[i]}', " + //order_id
                                $"'{order_day}', " + //order_OK_day
                                $"'{MainForm.Maker}')"; //maker

                            ConnectDatabase("新增", insertQuery2).ToString();

                            string insertQuery1 =
                                "INSERT INTO `report_day` VALUES " +
                                $"('{oorder_id_list[i]}', " +//order_id
                                $"'{order_day}', " +//order_day
                                $"'{bank_comboBox.Text}', " +//driver_id
                                $"'{"短溢收"}', " +//product_name
                                $"'{over_short_textBox.Text}', " +//product_price
                                $"'{"1"}', " +//product_quantity
                                $"'{over_short_textBox.Text}', " +//subtotal
                                $"'{"True"}', " +//collect_OK
                                $"'{"短溢收"}', " +//remark
                                $"'{ccustomer_id}', " +//customer_id
                                $"'{"0"}', " +//recyele_quantity
                                $"'{"現金"}', " +//collect_money
                                $"'{"2"}', " +//product_index
                                $"'{morningorafter_comboBox_report.Text}')";//morningorafternoon

                            ConnectDatabase("新增", insertQuery1).ToString();
                        }
                    }
                }
                else if (whoCall == "month")
                {
                    string driver_id = getDriverNameOrID("name", bank_comboBox.Text);
                    string order_day = dateTimePicker.Value.ToString("yyyy-MM-dd");
                    string reviseQuery =
                        "UPDATE `order` SET " +
                        $"collect_OK = 'True', order_OK = 'True',  assign_OK = 'True', order_day = '{order_day}', driver_id = '{driver_id}'" +
                        $"WHERE order_id = '{oorder_id}'";
                    ConnectDatabase("修改", reviseQuery);

                    string insertQuery =
                        "INSERT INTO `report_day` VALUES " +
                        $"('{oorder_id}'," +//order_id
                        $"'{order_day}'," +//order_day
                        $"'{bank_comboBox.Text}'," +//driver_id
                        $"'{"未收款月結單"+ getOrderDay(oorder_id)}'," +//product_name
                        $"'{ttotalMoney}'," +//product_price
                        $"'{"1"}'," +//product_quantity
                        $"'{ttotalMoney}'," +//subtotal
                        $"'{"True"}'," +//collect_OK
                        $"'{"現金"}'," +//remark
                        $"'{ccustomer_id}'," +//customer_id
                        $"'{"0"}'," +//recyele_quantity
                        $"'{"現金"}'," +//collect_money
                        $"'{"1"}'," +//product_index
                        $"'{morningorafter_comboBox_report.Text}')";//morningorafter

                    ConnectDatabase("新增", insertQuery);

                    //出現短溢收
                    if (over_short_textBox.Text != "0")
                    {
                        string insertQuery2 =
                            "INSERT INTO `money_over_short` VALUES " +
                            $"('{getMoneyOverShortID()}', " + //money_over_short_id
                            $"'{ccustomer_id}', " + //customer_id
                            $"'{getCustomerNameOrID("id", ccustomer_id)}', " + //customer_name
                            $"'{over_short_textBox.Text}', " + //money
                            $"'{oorder_id}', " + //order_id
                            $"'{order_day}', " + //order_OK_day
                            $"'{MainForm.Maker}')"; //maker

                        ConnectDatabase("新增", insertQuery2).ToString();

                        string insertQuery1 =
                            "INSERT INTO `report_day` VALUES " +
                            $"('{oorder_id}', " +//order_id
                            $"'{order_day}', " +//order_day
                            $"'{bank_comboBox.Text}', " +//driver_id
                            $"'{"短溢收"}', " +//product_name
                            $"'{over_short_textBox.Text}', " +//product_price
                            $"'{"1"}', " +//product_quantity
                            $"'{over_short_textBox.Text}', " +//subtotal
                            $"'{"True"}', " +//collect_OK
                            $"'{"短溢收"}', " +//remark
                            $"'{ccustomer_id}', " +//customer_id
                            $"'{"0"}', " +//recyele_quantity
                            $"'{"現金"}', " +//collect_money
                            $"'{"2"}', " +//product_index
                            $"'{morningorafter_comboBox_report.Text}')";//morningorafternoon

                        ConnectDatabase("新增", insertQuery1).ToString();
                    }
                }

                this.Close();
            }
            else
            {
                string remittance_list_id = (getRemittanceID() + 1).ToString();
                string remittance_day = dateTimePicker.Value.ToString("yyyy-MM-dd");
                string bank = bank_comboBox.Text;
                string money_remittance = money_remittance_comboBox.Text;
                string collect_money_bank_num = collect_money_bank_num_textbox.Text;
                string remark = remittance_list_id;
                string hand_money = money_textBox.Text == ""? "0":money_textBox.Text;
                string over_short_money = over_short_textBox.Text == ""? "0":over_short_textBox.Text;
                string resultInsert = "";

                if (whoCall == "order")
                {
                    for (int i = 0; i < oorder_id_list.Count; i++)
                    {

                        string insertQuery =
                            "INSERT INTO `remittance_list` VALUES " +
                            $"('{(getRemittanceID() + 1).ToString()}'," +
                            $"'{remittance_day}'," +
                            $"'{oorder_id_list[i]}'," +
                            $"'{bank}'," +
                            $"'{collect_money_bank_num}'," +
                            $"'{ttotal_money_list[i]}'," +
                            $"'{money_remittance}'," +
                            $"'{remark}'," +
                            $"'{MainForm.Maker}'," +
                            $"'{hand_money}'," +
                            $"'{over_short_money}')";

                        resultInsert = ConnectDatabase("新增", insertQuery).ToString();
                        if (resultInsert == "-1")
                        {
                            MessageBox.Show("登錄錯誤!");
                            return;
                        }

                        string reviseQuery =
                            "UPDATE `order` SET " +
                            $"collect_OK = 'True'" +
                            $"WHERE order_id = '{oorder_id_list[i]}'";
                        ConnectDatabase("修改", reviseQuery);

                        //出現短溢收
                        if (over_short_textBox.Text != "0" && i == 0)
                        {
                            string insertQuery2 =
                                "INSERT INTO `money_over_short` VALUES " +
                                $"('{getMoneyOverShortID()}', " + //money_over_short_id
                                $"'{ccustomer_id}', " + //customer_id
                                $"'{getCustomerNameOrID("id", ccustomer_id)}', " + //customer_name
                                $"'{over_short_textBox.Text}', " + //money
                                $"'{oorder_id_list[i]}', " + //order_id
                                $"'{remittance_day}', " + //order_OK_day
                                $"'{MainForm.Maker}')"; //maker

                            ConnectDatabase("新增", insertQuery2).ToString();
                        }
                    }
                }
                else if (whoCall == "month")
                {
                    string insertQuery =
                        "INSERT INTO `remittance_list` VALUES " +
                        $"('{(getRemittanceID() + 1).ToString()}'," +
                        $"'{remittance_day}'," +
                        $"'{oorder_id}'," +
                        $"'{bank}'," +
                        $"'{collect_money_bank_num}'," +
                        $"'{ttotalMoney}'," +
                        $"'{money_remittance}'," +
                        $"'{remark}'," +
                        $"'{MainForm.Maker}'," +
                        $"'{hand_money}'," +
                        $"'{over_short_money}')";

                    resultInsert = ConnectDatabase("新增", insertQuery).ToString();
                    if (resultInsert == "-1")
                    {
                        MessageBox.Show("登錄錯誤!");
                        return;
                    }

                    string reviseQuery =
                        "UPDATE `order` SET " +
                        $"collect_OK = 'True', order_OK = 'True',  assign_OK = 'True', order_day = '{remittance_day}'" +
                        $"WHERE order_id = '{oorder_id}'";
                    ConnectDatabase("修改", reviseQuery);


                    //出現短溢收
                    if (over_short_textBox.Text != "0")
                    {
                        string insertQuery2 =
                            "INSERT INTO `money_over_short` VALUES " +
                            $"('{getMoneyOverShortID()}', " + //money_over_short_id
                            $"'{ccustomer_id}', " + //customer_id
                            $"'{getCustomerNameOrID("id", ccustomer_id)}', " + //customer_name
                            $"'{over_short_textBox.Text}', " + //money
                            $"'{oorder_id}', " + //order_id
                            $"'{remittance_day}', " + //order_OK_day
                            $"'{MainForm.Maker}')"; //maker

                        ConnectDatabase("新增", insertQuery2).ToString();
                    }
                }

                this.Close();
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void money_remittance_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (money_remittance_comboBox.Text == "司機收錢")
            {
                label2.Text = "司機名稱";
                bank_comboBox.Items.Clear();

                string selectQuery = "SELECT driver_name FROM `driver`";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

                bank_comboBox.Items.Clear();
                foreach (DataRow row in datatable.Rows)
                {
                    bank_comboBox.Items.Add(row[0].ToString());
                }
                bank_comboBox.SelectedIndex = 0;
                label6.Visible = false;
                label3.Visible = false;

                collect_money_bank_num_textbox.Visible = false;
                money_textBox.Visible = false;
                money_textBox.Text = "";

                label5.Visible = true;
                morningorafter_comboBox_report.Visible = true;
            }
            else
            {
                bank_comboBox.Items.Clear();
                label2.Text = "匯入銀行";
                bank_comboBox.Items.Add("中信臺灣之水");
                bank_comboBox.Items.Add("中信左營企業");
                bank_comboBox.Items.Add("華南左營企業");
                bank_comboBox.Items.Add("陽信左營企業");
                bank_comboBox.SelectedIndex = 0;

                label6.Visible = true;
                label3.Visible = true;

                collect_money_bank_num_textbox.Visible = true;
                money_textBox.Visible = true;
                money_textBox.Text = "";

                label5.Visible = false;
                morningorafter_comboBox_report.Visible = false;

            }
        }

        private void order_money_textbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int totalMoney = int.Parse(driver_money_textBox.Text);
                int handMoney = int.Parse(money_textBox.Text == "" ? "0" : money_textBox.Text);
                int payMoney = int.Parse(order_money_textbox.Text == "" ? "0" : order_money_textbox.Text);
                over_short_textBox.Text = ((handMoney + payMoney) - totalMoney).ToString();
            }
            catch 
            {
                over_short_textBox.Text = "0";
            }

        }

        private void money_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int totalMoney = int.Parse(driver_money_textBox.Text);
                int handMoney = int.Parse(money_textBox.Text == "" ? "0" : money_textBox.Text);
                int payMoney = int.Parse(order_money_textbox.Text == "" ? "0" : order_money_textbox.Text);
                over_short_textBox.Text = ((handMoney + payMoney) - totalMoney).ToString();
            }
            catch
            {
                over_short_textBox.Text = "0";
            }
        }
    }
}
