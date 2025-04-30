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
    public partial class OrderOKDetilForm : Form
    {
        public OrderOKDetilForm(string order_id, string driver_money, string deliver_day, string driver_name, string morningorafternoon)
        {
            InitializeComponent();
            driver_money_textBox.Text = driver_money;
            order_money_textbox.Text = "0";
            over_short_textBox.Text = "0";
            this.Order_id = order_id;
            this.Deliver_day = deliver_day;
            this.Driver_name = driver_name;
            this.Morningorafternoon = morningorafternoon; 
            updateOrderListView(order_id);
        }

        private string Order_id { get; set; }
        private string Deliver_day { get; set; }
        private string Driver_name { get; set; }
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
        private void updateOrderListView(string order_id)
        {
            string selectQuery = "SELECT `order`.*, `customer`.customer_name FROM `order` " +
                "JOIN `customer` on `order`.customer_id = `customer`.customer_id " +
             $"WHERE `order`.order_id = '{order_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null)
            {
                return;
            }

            customer_id_textBox.Text = datatable.Rows[0][12].ToString();
            customer_name_textbox.Text = datatable.Rows[0][24].ToString();
            order_id_textBox.Text = order_id;

            foreach (DataRow row in datatable.Rows)
            {
                //order_id_textbox.Text = row[0].ToString();
                //dateTimePicker.Value.ToString("yyyy/MM/dd") = row[1].ToString();

                order_dataGridView.Rows.Add(false);//
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[1].Value = row[2].ToString();//產品順序
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[2].Value = row[3].ToString();//產品編號
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[3].Value = row[4].ToString();//產品名稱
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[4].Value = row[5].ToString();//價格
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[5].Value = row[6].ToString();//數量
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[6].Value = row[17].ToString();//扣單別
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[7].Value = row[13].ToString();//發票
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[8].Value = row[7].ToString();//補送
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[9].Value = row[8].ToString();//抵扣
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[10].Value = row[9].ToString();//稅金
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[11].Value = row[10].ToString();//小計
                order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[12].Value = row[11].ToString();//備註

                if (row[17].ToString() == "月結")
                {
                    order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[10].Value = "0";
                    order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[11].Value = "0";
                    order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[0].Value = true;
                }

                if (row[10].ToString() == "0")
                {
                    order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[0].Value = true;
                }

                if (row[3].ToString() == "短溢收")
                {
                    order_dataGridView.Rows[int.Parse(row[2].ToString()) - 1].Cells[0].Value = true;
                }
            }
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
               return  (int.Parse(datatable.Rows[0][0].ToString()) + 1).ToString().PadLeft(5, '0');
            }
        }

        private void order_save_btn_Click(object sender, EventArgs e)
        {
            string index = "";
            string isHaveOverShort = "False";
            int i_index = 0;
            for (int i = 0; i < order_dataGridView.Rows.Count; i++)
            {
                if (order_dataGridView.Rows[i].Cells[0].Value.ToString() == "False")
                {
                    index += "," + (i + 1).ToString();
                }
                if (order_dataGridView.Rows[i].Cells[3].Value.ToString() == "短溢收")
                {
                    i_index = i;
                    isHaveOverShort = "True";
                }
            }

            string reviseQuery =
                        "UPDATE `order` SET " +
                        "order_OK = 'True', " +
                        "collect_OK = 'True' " +
                        $"WHERE order_id = '{Order_id}' AND collect_money <> '月結'";
            ConnectDatabase("修改", reviseQuery);

            if (index != "")
            {
                index = index.Remove(0, 1);

                string reviseQuery1 =
                    "UPDATE `order` SET " +
                    "order_OK = 'True', " +
                    "collect_OK = 'False' " +
                    $"WHERE order_id = '{Order_id}' AND product_index in ({index})";
                ConnectDatabase("修改", reviseQuery1);
            }

            if (isHaveOverShort == "True")
            {
                //訂單內有出現短溢收
                if (over_short_textBox.Text == "0")
                {
                    string order_over_short_money = order_dataGridView.Rows[i_index].Cells[4].Value.ToString();

                    string insertQuery =
                    "INSERT INTO `money_over_short` VALUES " +
                    $"('{getMoneyOverShortID()}', " + //money_over_short_id
                    $"'{customer_id_textBox.Text}', " + //customer_id
                    $"'{customer_name_textbox.Text}', " + //customer_name
                    $"'{order_over_short_money}', " + //money
                    $"'{order_id_textBox.Text}', " + //order_id
                    $"'{Deliver_day}', " + //order_OK_day
                    $"'{MainForm.Maker}')"; //maker

                    ConnectDatabase("新增", insertQuery).ToString();

                    string insertQuery1 =
                        "INSERT INTO `report_day` VALUES " +
                        $"('{order_id_textBox.Text}', " +//order_id
                        $"'{Deliver_day}', " +//order_day
                        $"'{Driver_name}', " +//driver_id
                        $"'{"短溢收"}', " +//product_name
                        $"'{order_over_short_money}', " +//product_price
                        $"'{"1"}', " +//product_quantity
                        $"'{order_over_short_money}', " +//subtotal
                        $"'{"True"}', " +//collect_OK
                        $"'{"短溢收"}', " +//remark
                        $"'{customer_id_textBox.Text}', " +//customer_id
                        $"'{"0"}', " +//recyele_quantity
                        $"'{"現金"}', " +//collect_money
                        $"'{(order_dataGridView.Rows.Count).ToString()}', " +//product_index
                        $"'{Morningorafternoon}')";//morningorafternoon

                    ConnectDatabase("新增", insertQuery1).ToString();

                    string removeQuery =
                        "DELETE FROM `order` WHERE " +
                        $"order_id = '{order_id_textBox.Text}' AND product_id = '000' AND product_name = '短溢收'";
                    ConnectDatabase("刪除", removeQuery);
                }
                else
                {
                    string order_over_short_money = order_dataGridView.Rows[i_index].Cells[4].Value.ToString();

                    string insertQuery =
                    "INSERT INTO `money_over_short` VALUES " +
                    $"('{getMoneyOverShortID()}', " + //money_over_short_id
                    $"'{customer_id_textBox.Text}', " + //customer_id
                    $"'{customer_name_textbox.Text}', " + //customer_name
                    $"'{order_over_short_money}', " + //money
                    $"'{order_id_textBox.Text}', " + //order_id
                    $"'{Deliver_day}', " + //order_OK_day
                    $"'{MainForm.Maker}')"; //maker

                    ConnectDatabase("新增", insertQuery).ToString();

                    string insertQuery1 =
                        "INSERT INTO `money_over_short` VALUES " +
                        $"('{getMoneyOverShortID()}', " + //money_over_short_id
                        $"'{customer_id_textBox.Text}', " + //customer_id
                        $"'{customer_name_textbox.Text}', " + //customer_name
                        $"'{over_short_textBox.Text}', " + //money
                        $"'{order_id_textBox.Text}', " + //order_id
                        $"'{Deliver_day}', " + //order_OK_day
                        $"'{MainForm.Maker}')"; //maker

                    ConnectDatabase("新增", insertQuery1).ToString();

                    string insertQuery2 =
                        "INSERT INTO `report_day` VALUES " +
                        $"('{order_id_textBox.Text}', " +//order_id
                        $"'{Deliver_day}', " +//order_day
                        $"'{Driver_name}', " +//driver_id
                        $"'{"短溢收"}', " +//product_name
                        $"'{order_over_short_money}', " +//product_price
                        $"'{"1"}', " +//product_quantity
                        $"'{order_over_short_money}', " +//subtotal
                        $"'{"True"}', " +//collect_OK
                        $"'{"短溢收"}', " +//remark
                        $"'{customer_id_textBox.Text}', " +//customer_id
                        $"'{"0"}', " +//recyele_quantity
                        $"'{"現金"}', " +//collect_money
                        $"'{(order_dataGridView.Rows.Count).ToString()}', " +//product_index
                        $"'{Morningorafternoon}')";//morningorafternoon

                    ConnectDatabase("新增", insertQuery2).ToString();

                    string insertQuery3=
                        "INSERT INTO `report_day` VALUES " +
                        $"('{order_id_textBox.Text}', " +//order_id
                        $"'{Deliver_day}', " +//order_day
                        $"'{Driver_name}', " +//driver_id
                        $"'{"短溢收"}', " +//product_name
                        $"'{over_short_textBox.Text}', " +//product_price
                        $"'{"1"}', " +//product_quantity
                        $"'{over_short_textBox.Text}', " +//subtotal
                        $"'{"True"}', " +//collect_OK
                        $"'{"短溢收"}', " +//remark
                        $"'{customer_id_textBox.Text}', " +//customer_id
                        $"'{"0"}', " +//recyele_quantity
                        $"'{"現金"}', " +//collect_money
                        $"'{(order_dataGridView.Rows.Count+1).ToString()}', " +//product_index
                        $"'{Morningorafternoon}')";//morningorafternoon

                    ConnectDatabase("新增", insertQuery3).ToString();

                    string removeQuery =
                        "DELETE FROM `order` WHERE " +
                        $"order_id = '{order_id_textBox.Text}' AND product_id = '000' AND product_name = '短溢收'";
                    ConnectDatabase("刪除", removeQuery);
                }
            }
            else
            {
                //訂單內沒有出現短溢收
                if (over_short_textBox.Text == "0")
                {

                }
                else
                {
                    string insertQuery =
                    "INSERT INTO `money_over_short` VALUES " +
                    $"('{getMoneyOverShortID()}', " + //money_over_short_id
                    $"'{customer_id_textBox.Text}', " + //customer_id
                    $"'{customer_name_textbox.Text}', " + //customer_name
                    $"'{over_short_textBox.Text}', " + //money
                    $"'{order_id_textBox.Text}', " + //order_id
                    $"'{Deliver_day}', " + //order_OK_day
                    $"'{MainForm.Maker}')"; //maker

                    ConnectDatabase("新增", insertQuery).ToString();

                    string insertQuery1 =
                        "INSERT INTO `report_day` VALUES " +
                        $"('{order_id_textBox.Text}', " +//order_id
                        $"'{Deliver_day}', " +//order_day
                        $"'{Driver_name}', " +//driver_id
                        $"'{"短溢收"}', " +//product_name
                        $"'{over_short_textBox.Text}', " +//product_price
                        $"'{"1"}', " +//product_quantity
                        $"'{over_short_textBox.Text}', " +//subtotal
                        $"'{"True"}', " +//collect_OK
                        $"'{"短溢收"}', " +//remark
                        $"'{customer_id_textBox.Text}', " +//customer_id
                        $"'{"0"}', " +//recyele_quantity
                        $"'{"現金"}', " +//collect_money
                        $"'{(order_dataGridView.Rows.Count+1).ToString()}', " +//product_index
                        $"'{Morningorafternoon}')";//morningorafternoon

                    ConnectDatabase("新增", insertQuery1).ToString();

                    string removeQuery =
                        "DELETE FROM `order` WHERE " +
                        $"order_id = '{order_id_textBox.Text}' AND product_id = '000' AND product_name = '短溢收'";
                    ConnectDatabase("刪除", removeQuery);
                }
            }
            OrderOKForm ChileForm = (OrderOKForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.OrderOKDetil = "True";//使用父窗口指針賦值  
            this.Close();
        }

        private void order_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            if (e.ColumnIndex == 0)
            {
                if (order_dataGridView.Rows[e.RowIndex].Cells[11].Value.ToString() == "0")
                {
                    order_dataGridView.Rows[e.RowIndex].Cells[0].Value = true;
                }
                if (order_dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString() == "短溢收")
                {
                    order_dataGridView.Rows[e.RowIndex].Cells[0].Value = true;
                }

                int total = 0;
                for (int i = 0; i < order_dataGridView.Rows.Count; i++)
                {
                    if (order_dataGridView.Rows[i].Cells[0].Value.ToString() == "True")
                    {
                        total += int.Parse(order_dataGridView.Rows[i].Cells[11].Value.ToString());
                    }
                }
                order_money_textbox.Text = total.ToString();
            }
        }

        private void order_money_textbox_TextChanged(object sender, EventArgs e)
        {
            int driver_money = int.Parse(driver_money_textBox.Text);
            int order_money = int.Parse(order_money_textbox.Text);
            int over_short_money = driver_money - order_money;
            over_short_textBox.Text = over_short_money.ToString();
        }

        private void OrderOKDetilForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = order_dataGridView.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                order_dataGridView.Columns[0].Width = (int)(totalWidth * 0.0512); // 第一欄占 30%
                order_dataGridView.Columns[1].Width = (int)(totalWidth * 0.0256); // 第二欄占 30%
                order_dataGridView.Columns[2].Width = (int)(totalWidth * 0.1067); // 第三欄占 40%
                order_dataGridView.Columns[3].Width = (int)(totalWidth * 0.1707); // 第一欄占 30%
                order_dataGridView.Columns[4].Width = (int)(totalWidth * 0.0597); // 第二欄占 30%
                order_dataGridView.Columns[5].Width = (int)(totalWidth * 0.0597); // 第三欄占 40%
                order_dataGridView.Columns[6].Width = (int)(totalWidth * 0.0683); // 第三欄占 40%
                order_dataGridView.Columns[7].Width = (int)(totalWidth * 0.1280); // 第三欄占 40%
                order_dataGridView.Columns[8].Width = (int)(totalWidth * 0.0597); // 第一欄占 30%
                order_dataGridView.Columns[9].Width = (int)(totalWidth * 0.0597); // 第二欄占 30%
                order_dataGridView.Columns[10].Width = (int)(totalWidth * 0.0597); // 第三欄占 40%
                order_dataGridView.Columns[11].Width = (int)(totalWidth * 0.0683); // 第三欄占 40%
                order_dataGridView.Columns[12].Width = (int)(totalWidth * 0.2988); // 第三欄占 40%
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            OrderOKForm ChileForm = (OrderOKForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.OrderOKDetil = "False";//使用父窗口指針賦值  
            this.Close();
        }
    }
}
