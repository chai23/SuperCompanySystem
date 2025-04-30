using MySqlX.XDevAPI;
using System;
using System.Collections;
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
    public partial class PermissionsSettingForm : Form
    {
        public PermissionsSettingForm()
        {
            InitializeComponent();
            updatePersonnel_listview();
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
        private void updatePersonnel_listview()
        {
            string selectQuery = "SELECT * FROM `personnel_list` " +
                    "ORDER BY personnel_id ASC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            personnel_listview.Items.Clear();
            foreach (DataRow personnel in datatable.Rows)
            {
                ListViewItem item = new ListViewItem(personnel[0].ToString());//編號
                item.SubItems.Add(personnel[1].ToString().Split(' ')[0]);//名稱
                item.SubItems.Add(personnel[2].ToString());//帳號
                item.SubItems.Add(personnel[3].ToString());//密碼
                item.SubItems.Add(personnel[4].ToString());//權限

                personnel_listview.Items.Add(item);
            };

        }
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            name_textBox.Enabled = true;
            account_number_textBox.Enabled = true;
            password_textBox.Enabled = true;
            level_comboBox.Enabled = true;
            name_textBox.Text = "";
            account_number_textBox.Text = "";
            password_textBox.Text = "";
            level_comboBox.Text = "";
            new_btn.Enabled = false;
            remove_btn.Enabled = false;
            OK_btn.Enabled = true;
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            if (personnel_listview.SelectedItems.Count == 0) {  return; }
            string personnel_id = personnel_listview.SelectedItems[0].SubItems[0].Text; 
            if (personnel_id == "0001") 
            { 
                MessageBox.Show("老闆不可以刪除！"); 
                return;
            }
            string removeQuery =
                "DELETE FROM `personnel_list` WHERE " +
                $"personnel_id = '{personnel_id}'";
            ConnectDatabase("刪除", removeQuery);
            updatePersonnel_listview();
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            if (name_textBox.Text == "" || account_number_textBox.Text == "" || password_textBox.Text == "" || level_comboBox.Text == "")
            {
                MessageBox.Show("資料輸入不完整");
                return;
            }

            string selectQuery = "SELECT personnel_id FROM `personnel_list` " +
                "ORDER BY personnel_id DESC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            string new_personnel_id = (int.Parse(datatable.Rows[0][0].ToString()) + 1).ToString().PadLeft(4, '0');

            //客戶編號可以使用，所以是按下新增按鈕
            string insertQuery =
            "INSERT INTO personnel_list VALUES " +
            $"('{new_personnel_id}'," +
            $"'{name_textBox.Text}'," +
            $"'{account_number_textBox.Text}'," +
            $"'{password_textBox.Text}'," +
            $"'{level_comboBox.Text}')";
            if (ConnectDatabase("新增", insertQuery).ToString() == "1")
            {
                MessageBox.Show("新增成功");
                new_btn.Enabled = true;
                remove_btn.Enabled = true;
                OK_btn.Enabled = false;
            }
            else
            { MessageBox.Show(ConnectDatabase("新增", insertQuery).ToString()); }

            updatePersonnel_listview();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personnel_listview_DoubleClick(object sender, EventArgs e)
        {
            //name_textBox.Enabled = true;
            //account_number_textBox.Enabled = true;
            //password_textBox.Enabled = true;
            //level_comboBox.Enabled = true;
            name_textBox.Text = personnel_listview.SelectedItems[0].SubItems[1].Text;
            account_number_textBox.Text = personnel_listview.SelectedItems[0].SubItems[2].Text;
            password_textBox.Text = personnel_listview.SelectedItems[0].SubItems[3].Text;
            level_comboBox.Text = personnel_listview.SelectedItems[0].SubItems[4].Text;
        }

        private void PermissionsSettingForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = personnel_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                personnel_listview.Columns[0].Width = (int)(totalWidth * 0.1797); // 第一欄占 30%
                personnel_listview.Columns[1].Width = (int)(totalWidth * 0.2696); // 第二欄占 30%
                personnel_listview.Columns[2].Width = (int)(totalWidth * 0.1797); // 第三欄占 40%
                personnel_listview.Columns[3].Width = (int)(totalWidth * 0.1797); // 第一欄占 30%
                personnel_listview.Columns[4].Width = (int)(totalWidth * 0.1797); // 第二欄占 30%
            }
        }
    }
}
