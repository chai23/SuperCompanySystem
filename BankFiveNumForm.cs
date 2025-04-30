using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace 超好企業系統
{
    public partial class BankFiveNumForm : Form
    {
        public BankFiveNumForm()
        {
            InitializeComponent();
        }

        private string bankNumID {  get; set; }

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

        private void updateListView(string idORNum, string name)
        {
            alldata_listview.Items.Clear();
            string selectQuery = "SELECT * FROM `cust_bank_five_num` " +
                $"WHERE {idORNum} LIKE '%{name}%'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable == null || datatable.Rows.Count == 0) { return; }
            int index = 1;
            foreach (DataRow row in datatable.Rows) 
            {
                ListViewItem item = new ListViewItem(index.ToString());
                item.SubItems.Add(row[1].ToString());//客戶編號
                item.SubItems.Add(row[3].ToString());//銀行名稱
                item.SubItems.Add(row[2].ToString());//末五碼
                item.SubItems.Add(row[4].ToString());//備註
                item.SubItems.Add(row[0].ToString());//備註

                alldata_listview.Items.Add(item);
                index++;
            }
        }

        private void getClientData()
        {
            var textbox = customer_id_textBox.Text;
            if (textbox == "") { return; }

             string selectQuery = "SELECT customer_name FROM customer " +
                $"WHERE customer_id = '{textbox}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable == null || datatable.Rows.Count == 0)
            {
                MessageBox.Show("查無客戶");
                customer_id_textBox.Text = "";
                return;
            }
            if (datatable != null & datatable.Rows.Count != 0)
            {
                customer_name_textBox.Text = datatable.Rows[0][0].ToString();
            }
        }

        private string getBankNumID(string customer_id)
        {
            string ID;
            string selectQuery = "SELECT bank_num_id FROM cust_bank_five_num " +
                $"WHERE customer_id = '{customer_id}' " +
                $"ORDER BY bank_num_id DESC ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable == null || datatable.Rows.Count == 0)
            {
                ID = customer_id + ":1";
            }
            else
            {
                string index = (int.Parse(datatable.Rows[0][0].ToString().Split(':')[1]) + 1).ToString();
                ID = customer_id + ":"+ index;
            }

            return ID;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            if (customer_name_textBox.Text == "")
            {
                MessageBox.Show("請輸入客戶編號"); 
                return;
            }

            string customer_id = customer_id_textBox.Text;
            string bank_num_id = getBankNumID(customer_id);
            string bank_num = bank_num_textBox.Text;
            string bank_name = bank_name_textbox.Text;
            string remark = remark_textBox.Text;

            if (new_btn.Text == "新增")
            {
                string insertQuery =
                    "INSERT INTO `cust_bank_five_num` VALUES " +
                    $"('{bank_num_id}'," +//bank_num_id
                    $"'{customer_id}'," +//customer_id
                    $"'{bank_num}'," +//bank_num
                    $"'{bank_name}'," +//bank_name
                    $"'{remark}')";//remark

                string result = ConnectDatabase("新增", insertQuery).ToString();

                if (result != "-1")
                {
                    MessageBox.Show("新增成功!");
                    customer_ID_search_textBox.Text = customer_id;
                    bank_num_search_textBox.Text = "";
                    updateListView("customer_id", customer_ID_search_textBox.Text);

                    customer_id_textBox.Text = "";
                    customer_name_textBox.Text = "";
                    bank_name_textbox.Text = "";
                    bank_num_textBox.Text = "";
                    remark_textBox.Text = "";
                }
                else
                {
                    MessageBox.Show("新增失敗!");
                }
            }
            else if (new_btn.Text == "修改")
            {
                string reviseQuery =
                    "UPDATE `cust_bank_five_num` SET " +
                    $"bank_num = '{bank_num}', " +
                    $"bank_name = '{bank_name}', " +
                    $"remark = '{remark}' " +
                    $"WHERE bank_num_id = '{bankNumID}' ";

                string result = ConnectDatabase("新增", reviseQuery).ToString();

                if (result != "-1")
                {
                    MessageBox.Show("修改成功!");
                    customer_ID_search_textBox.Text = customer_id;
                    bank_num_search_textBox.Text = "";
                    updateListView("customer_id", customer_ID_search_textBox.Text);

                    customer_id_textBox.Text = "";
                    customer_name_textBox.Text = "";
                    bank_name_textbox.Text = "";
                    bank_num_textBox.Text = "";
                    remark_textBox.Text = "";

                    new_btn.Text = "新增";
                    customer_id_textBox.Enabled = true;
                }
                else
                {
                    MessageBox.Show("修改失敗!");
                }
            }
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            if (alldata_listview.SelectedItems.Count == 0) {  return; }
            string customer_id = alldata_listview.SelectedItems[0].SubItems[1].Text;
            string ID = alldata_listview.SelectedItems[0].SubItems[5].Text;
            string removeQuery =
                "DELETE FROM `cust_bank_five_num` WHERE " +
                $"bank_num_id = '{ID}'";
            ConnectDatabase("刪除", removeQuery);

            customer_ID_search_textBox.Text = customer_id;
            bank_num_search_textBox.Text = "";
            updateListView("customer_id", customer_ID_search_textBox.Text);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            if (bank_num_search_textBox.Text == "" && customer_ID_search_textBox.Text == "") {  return; }
            if (bank_num_search_textBox.Text != "" && customer_ID_search_textBox.Text != "") { return; }

            if (bank_num_search_textBox.Text != "")
            {
                updateListView("bank_num", bank_num_search_textBox.Text);
            }
            else if (customer_ID_search_textBox.Text != "")
            {
                updateListView("customer_id", customer_ID_search_textBox.Text);
            }
        }

        private void customer_id_textBox_TextChanged(object sender, EventArgs e)
        {
            if (customer_id_textBox.Text.Length >= 6)
            {
                getClientData();
            }
        }

        private void alldata_listview_DoubleClick(object sender, EventArgs e)
        {
            bankNumID = alldata_listview.SelectedItems[0].SubItems[5].Text;
            new_btn.Text = "修改";
            customer_id_textBox.Enabled = false;

            customer_id_textBox.Text = alldata_listview.SelectedItems[0].SubItems[1].Text;
            bank_name_textbox.Text = alldata_listview.SelectedItems[0].SubItems[2].Text;
            bank_num_textBox.Text = alldata_listview.SelectedItems[0].SubItems[3].Text;
            remark_textBox.Text = alldata_listview.SelectedItems[0].SubItems[4].Text;
        }

        private void BankFiveNumForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = alldata_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                alldata_listview.Columns[0].Width = (int)(totalWidth * 0.0787); // 第一欄占 30%
                alldata_listview.Columns[1].Width = (int)(totalWidth * 0.2362); // 第二欄占 30%
                alldata_listview.Columns[2].Width = (int)(totalWidth * 0.2362); // 第三欄占 40%
                alldata_listview.Columns[3].Width = (int)(totalWidth * 0.1968); // 第一欄占 30%
                alldata_listview.Columns[4].Width = (int)(totalWidth * 0.2952); // 第三欄占 40%
                alldata_listview.Columns[5].Width = (int)(totalWidth * 0); // 第一欄占 30%
            }
        }
    }
}
