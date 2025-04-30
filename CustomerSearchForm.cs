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
    public partial class CustomerSearchForm : Form
    {
        public CustomerSearchForm(string whoOpen, string customerText)
        {
            InitializeComponent();
            search_comboBox.SelectedIndex = 0;
            search_textBox.Text = customerText;
            WhoOpen = whoOpen;
            CustomerText = customerText;
            getClientData();
        }

        private string WhoOpen {  get; set; }
        private string CustomerText { get; set; }
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
        private void getClientData()
        {
            var textbox = search_textBox.Text;
            if (textbox == "") { return; }

            switch (search_comboBox.Text)
            {
                case "全部搜尋":
                    string selectQuery = "SELECT * FROM customer " +
                         $"WHERE customer_id LIKE '%{textbox}%' OR " +
                         $"customer_name LIKE '%{textbox}%' OR " +
                         $"customer_telephone LIKE '%{textbox}%' OR " +
                         $"customer_phone LIKE '%{textbox}%' OR " +
                         $"customer_invoice LIKE '%{textbox}%' OR " +
                         $"customer_address LIKE '%{textbox}%'";
                    DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                    if (datatable == null) { return; }
                    if (datatable != null & datatable.Rows.Count != 0)
                    {
                        alldata_listview.Items.Clear();

                        foreach (DataRow row in datatable.Rows)
                        {
                            ListViewItem item = new ListViewItem(row[0].ToString());
                            for (int i = 1; i < datatable.Columns.Count; i++)
                            {
                                item.SubItems.Add(row[i].ToString());
                            }
                            alldata_listview.Items.Add(item);
                        }
                    }
                    else
                    {
                        alldata_listview.Items.Clear();
                    }
                    break;
                case "客戶編號":
                    selectQuery = "SELECT * FROM customer " +
                         $"WHERE customer_id LIKE '%{textbox}%'";
                    datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                    if (datatable == null) { return; }
                    if (datatable != null & datatable.Rows.Count != 0)
                    {
                        alldata_listview.Items.Clear();

                        foreach (DataRow row in datatable.Rows)
                        {
                            ListViewItem item = new ListViewItem(row[0].ToString());
                            for (int i = 1; i < datatable.Columns.Count; i++)
                            {
                                item.SubItems.Add(row[i].ToString());
                            }
                            alldata_listview.Items.Add(item);
                        }
                    }
                    else
                    {
                        alldata_listview.Items.Clear();
                    }
                    break;
                case "客戶名稱":
                    selectQuery = "SELECT * FROM customer " +
                        $"WHERE customer_name LIKE '%{textbox}%'";
                    datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                    if (datatable == null) { return; }
                    if (datatable != null & datatable.Rows.Count != 0)
                    {
                        alldata_listview.Items.Clear();

                        foreach (DataRow row in datatable.Rows)
                        {
                            ListViewItem item = new ListViewItem(row[0].ToString());
                            for (int i = 1; i < datatable.Columns.Count; i++)
                            {
                                item.SubItems.Add(row[i].ToString());
                            }
                            alldata_listview.Items.Add(item);
                        }
                    }
                    else
                    {
                        alldata_listview.Items.Clear();
                    }
                    break;
                case "客戶電話":
                    selectQuery = "SELECT * FROM customer " +
                        $"WHERE customer_telephone LIKE '%{textbox}%' " +
                        $"OR customer_phone LIKE '%{textbox}%'";
                    datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                    if (datatable == null) { return; }
                    if (datatable != null & datatable.Rows.Count != 0)
                    {
                        alldata_listview.Items.Clear();

                        foreach (DataRow row in datatable.Rows)
                        {
                            ListViewItem item = new ListViewItem(row[0].ToString());
                            for (int i = 1; i < datatable.Columns.Count; i++)
                            {
                                item.SubItems.Add(row[i].ToString());
                            }
                            alldata_listview.Items.Add(item);
                        }
                    }
                    else
                    {
                        alldata_listview.Items.Clear();
                    }
                    break;
                case "統一編號":
                    selectQuery = "SELECT * FROM customer " +
                        $"WHERE customer_invoice LIKE '%{textbox}%' ";
                    datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                    if (datatable == null) { return; }
                    if (datatable != null & datatable.Rows.Count != 0)
                    {
                        alldata_listview.Items.Clear();

                        foreach (DataRow row in datatable.Rows)
                        {
                            ListViewItem item = new ListViewItem(row[0].ToString());
                            for (int i = 1; i < datatable.Columns.Count; i++)
                            {
                                item.SubItems.Add(row[i].ToString());
                            }
                            alldata_listview.Items.Add(item);
                        }
                    }
                    else
                    {
                        alldata_listview.Items.Clear();
                    }
                    break;
                case "客戶地址":
                    selectQuery = "SELECT * FROM customer " +
                        $"WHERE customer_address LIKE '%{textbox}%'";
                    datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                    if (datatable == null) { return; }
                    if (datatable != null & datatable.Rows.Count != 0)
                    {
                        alldata_listview.Items.Clear();

                        foreach (DataRow row in datatable.Rows)
                        {
                            ListViewItem item = new ListViewItem(row[0].ToString());
                            for (int i = 1; i < datatable.Columns.Count; i++)
                            {
                                item.SubItems.Add(row[i].ToString());
                            }
                            alldata_listview.Items.Add(item);
                        }
                    }
                    else
                    {
                        alldata_listview.Items.Clear();
                    }
                    break;
                default:

                    break;
            }
        }
        private void search_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            getClientData();
        }

        private void search_textBox_TextChanged(object sender, EventArgs e)
        {
            if (search_textBox.Text.Length >= 4)
            {
                getClientData();
            }
        }

        private void alldata_listview_DoubleClick(object sender, EventArgs e)
        {
            if (WhoOpen == "OrderDataForm")
            {
                var customer_id = alldata_listview.SelectedItems[0].SubItems[0].Text;
                OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
                ChileForm.StrValue = customer_id;//使用父窗口指針賦值  
                this.Close();
            }
            else if (WhoOpen == "CustomerDataForm")
            {
                var customer_id = alldata_listview.SelectedItems[0].SubItems[0].Text;
                CustomerDataForm ChileForm = (CustomerDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
                ChileForm.StrValue = customer_id;//使用父窗口指針賦值  
                this.Close();
            }
         }

        private void search_textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getClientData();
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            if (WhoOpen == "OrderDataForm")
            {
                OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
                ChileForm.StrValue = CustomerText;//使用父窗口指針賦值  
                this.Close();
            }
            else if (WhoOpen == "CustomerDataForm")
            {
                CustomerDataForm ChileForm = (CustomerDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
                ChileForm.StrValue = CustomerText;//使用父窗口指針賦值  
                this.Close();
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                if (WhoOpen == "OrderDataForm")
                {
                    OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
                    ChileForm.StrValue = CustomerText;//使用父窗口指針賦值  
                    this.Close();
                }
                else if (WhoOpen == "CustomerDataForm")
                {
                    CustomerDataForm ChileForm = (CustomerDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
                    ChileForm.StrValue = CustomerText;//使用父窗口指針賦值  
                    this.Close();
                }
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CustomerSearchForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = alldata_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                alldata_listview.Columns[0].Width = (int)(totalWidth * 0.075); // 第一欄占 30%
                alldata_listview.Columns[1].Width = (int)(totalWidth * 0.1680); // 第二欄占 30%
                alldata_listview.Columns[2].Width = (int)(totalWidth * 0.2693); // 第三欄占 40%
                alldata_listview.Columns[3].Width = (int)(totalWidth * 0.1008); // 第一欄占 30%
                alldata_listview.Columns[4].Width = (int)(totalWidth * 0.1008); // 第二欄占 30%
                alldata_listview.Columns[5].Width = (int)(totalWidth * 0.1008); // 第三欄占 40%
                alldata_listview.Columns[6].Width = (int)(totalWidth * 0.0840); // 第一欄占 30%
                alldata_listview.Columns[7].Width = (int)(totalWidth * 0.1008); // 第二欄占 30%
                alldata_listview.Columns[8].Width = (int)(totalWidth * 0.1008); // 第三欄占 40%
                alldata_listview.Columns[9].Width = (int)(totalWidth * 0.0841); // 第一欄占 30%
                alldata_listview.Columns[10].Width = (int)(totalWidth * 0.0841); // 第二欄占 30%
                alldata_listview.Columns[11].Width = (int)(totalWidth * 0.0841); // 第三欄占 40%
                alldata_listview.Columns[12].Width = (int)(totalWidth * 0.0505); // 第一欄占 30%
                alldata_listview.Columns[13].Width = (int)(totalWidth * 0.0505); // 第一欄占 30%
                alldata_listview.Columns[14].Width = (int)(totalWidth * 0.0673); // 第二欄占 30%
                alldata_listview.Columns[15].Width = (int)(totalWidth * 0.1683); // 第三欄占 40%
            }
        }
    }
}
