using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 超好企業系統
{
    public partial class CustomerMemoForm : Form
    {
        public CustomerMemoForm()
        {
            InitializeComponent();
        }
        public CustomerMemoForm(string customer_id)
        {
            InitializeComponent();
            customer_id_textBox.Text = customer_id;
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
        private string newOrderID(string memo_day)
        {
            string selectQuery = "SELECT customer_memo_id FROM `customer_memo` " +
                $"WHERE memo_day = '{memo_day}' " +
                "ORDER BY customer_memo_id DESC LIMIT 0 , 1";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count == 0)
            {
                return memo_day.Replace("-", "") + "0001";
            }
            var customer_memo_id = datatable.Rows[0][0].ToString();
            if (customer_memo_id.Substring(0, 8) == memo_day.Replace("-", ""))
            {
                return (long.Parse(customer_memo_id) + 1).ToString();
            }
            else
            {
                return memo_day.Replace("-", "") + "0001";
            }
        }
        private void getClientData()
        {
            var textbox = customer_id_textBox.Text;
            if (textbox == "") { return; }

            string selectQuery = "SELECT customer_name FROM customer " +
                        $"WHERE customer_id LIKE '%{textbox}%'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null) { return; }
            if (datatable != null & datatable.Rows.Count != 0)
            {
                customer_name_textBox.Text = datatable.Rows[0][0].ToString();
                updataMemoListView(customer_id_textBox.Text);
            }
            else
            {
                customer_name_textBox.Text = "";
            }
        }
        
        private void updataMemoListView(string customer_id)
        {
            string selectQuery = "SELECT customer_memo_id, memo_day, memo_content, memo_finish FROM `customer_memo` " +
                $"WHERE customer_id = '{customer_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null) { return; }
            if (datatable != null & datatable.Rows.Count != 0)
            {
                memo_listview.Items.Clear();
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(datatable.Rows[i][0].ToString());//編號
                    item.SubItems.Add(DateTime.Parse(datatable.Rows[i][1].ToString()).ToString("yyyy-MM-dd"));//日期
                    item.SubItems.Add(datatable.Rows[i][2].ToString());//內容
                    if (datatable.Rows[i][3].ToString() == "True")
                    {
                        item.SubItems.Add("✔");//完成
                    }
                    else
                    {
                        item.SubItems.Add("");//未完成
                    }
                    memo_listview.Items.Add(item);
                }
            }
        }
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void customer_id_textBox_TextChanged(object sender, EventArgs e)
        {
            if (customer_id_textBox.Text.Length >= 4)
            {
                getClientData();
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void new_btn_Click(object sender, EventArgs e)
        {
            if (customer_id_textBox.Text == "" || customer_name_textBox.Text == "" || memo_content_textBox.Text == "")
            {
                MessageBox.Show("請輸入完整資料");
                return;
            }
            string memo_day = DateTime.Now.ToString("yyyy-MM-dd");
            string customer_memo_id = newOrderID(memo_day);
            string customer_id = customer_id_textBox.Text;
            string memo_content = memo_content_textBox.Text;

            string insertQuery = "INSERT INTO `customer_memo` " +
                $"(`customer_memo_id`, `memo_day`, `memo_content`, `memo_finish`, `customer_id`) " +
                $"VALUES ('{customer_memo_id}', '{memo_day}', '{memo_content}', 'False', '{customer_id}')";
            string rowsInserted = ConnectDatabase("新增", insertQuery) as string;

            if (rowsInserted == "1")
            {
                MessageBox.Show("新增成功");
                memo_content_textBox.Text = "";
                updataMemoListView(customer_id_textBox.Text);
            }
            else
            {
                MessageBox.Show("新增失敗");
            }

        }
        private void remove_btn_Click(object sender, EventArgs e)
        {
            if (memo_listview.SelectedItems.Count == 0)
            {
                MessageBox.Show("請選擇要刪除的資料");
                return;
            }
            string customer_memo_id = memo_listview.SelectedItems[0].SubItems[0].Text;
            string deleteQuery = "DELETE FROM `customer_memo` " +
                $"WHERE customer_memo_id = '{customer_memo_id}'";
            string rowsRemoved = ConnectDatabase("刪除", deleteQuery) as string;
            if (rowsRemoved == "1")
            {
                MessageBox.Show("刪除成功");
                updataMemoListView(customer_id_textBox.Text);
            }
            else
            {
                MessageBox.Show("刪除失敗");
            }
        }

        private void memo_finish_OK_btn_Click(object sender, EventArgs e)
        {
            if (memo_listview.SelectedItems.Count == 0)
            {
                MessageBox.Show("請選擇要標示完成的資料");
                return;
            }
            string customer_memo_id = memo_listview.SelectedItems[0].SubItems[0].Text;
            string reviseQuery = "UPDATE `customer_memo` " +
                $"SET memo_finish = 'True' " +
                $"WHERE customer_memo_id = '{customer_memo_id}'";
            string rowsRevised = ConnectDatabase("修改", reviseQuery) as string;
            if (rowsRevised == "1")
            {
                MessageBox.Show("標示完成成功");
                updataMemoListView(customer_id_textBox.Text);
            }
            else
            {
                MessageBox.Show("標示完成失敗");
            }
        }

        private void CustomerMemoForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = memo_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                memo_listview.Columns[0].Width = (int)(totalWidth * 0); // 第一欄占 30%
                memo_listview.Columns[1].Width = (int)(totalWidth * 0.2650); // 第二欄占 30%
                memo_listview.Columns[2].Width = (int)(totalWidth * 0.583); // 第三欄占 40%
                memo_listview.Columns[3].Width = (int)(totalWidth * 0.106); // 第一欄占 30%
            }
        }

        private void memo_listview_DoubleClick(object sender, EventArgs e)
        {
            string customer_memo_id = memo_listview.SelectedItems[0].SubItems[0].Text;
            string selectQuery = "SELECT memo_content FROM `customer_memo` " +
                $"WHERE customer_memo_id = '{customer_memo_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null) { return; }
            if (datatable != null & datatable.Rows.Count != 0)
            {
                memo_content_textBox.Text = "";
                memo_content_textBox.Text = datatable.Rows[0][0].ToString();
            }
            else
            {
                memo_content_textBox.Text = "";
            }
        }
    }
}
