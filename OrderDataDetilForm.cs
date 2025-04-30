using Org.BouncyCastle.Tls.Crypto;
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
    public partial class OrderDataDetilForm : Form
    {
        public OrderDataDetilForm(string order_id, string customer_id, string customer_name)
        {
            InitializeComponent();
            this.Order_id = order_id;
            this.Customer_id = customer_id;
            this.Customer_name = customer_name;
            updateOrderListView(order_id);
        }
        private string Order_id { get; set; }
        private string Customer_id { get; set; }
        private string Customer_name { get; set; }

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

            int finishNum = 0;
            int notFinishNum = 0;
            foreach (DataRow row in datatable.Rows)
            {
                if (row[18].ToString() == "True")
                {
                    finishNum += int.Parse(row[10].ToString());
                }
                else
                {
                    notFinishNum += int.Parse(row[10].ToString());
                }
            }
            finish_money_textbox.Text = finishNum.ToString();
            not_finish_money_textBox.Text = notFinishNum.ToString();


            foreach (DataRow row in datatable.Rows)
            {
                

                order_dataGridView.Rows.Add(row[18].ToString() == "True" ? true : false);//
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
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrderDataDetilForm_Resize(object sender, EventArgs e)
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
    }
}
