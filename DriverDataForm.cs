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
    public partial class DriverDataForm : Form
    {
        public DriverDataForm()
        {
            InitializeComponent();
            InputLastDriverDataToSingleTap();
        }

        //將單筆頁面的輸入轉成Customer的型別
        private Driver GetDriver()
        {
            string dvr_id = driver_id_textbox.Text;
            string dvr_name = driver_name_textbox.Text;
            string dvr_address = driver_address_textbox.Text;
            string contact_person = contact_person_textbox.Text;
            string dvr_telephone = driver_telephone_textbox.Text;
            string order_num = order_num_textBox.Text;
            string order_quantity = order_quantity_textBox.Text;

            Driver driver = new Driver(dvr_id, dvr_name, dvr_address, contact_person, dvr_telephone, order_num, order_quantity);
            return driver;
        }
        //連線到資料庫
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
        //把最後一筆資料放到單筆資料的頁面
        private void InputLastDriverDataToSingleTap()
        {
            string selectQuery = "SELECT * FROM driver";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count != 0)
            {
                var count = datatable.Rows.Count - 1;
                driver_id_textbox.Text = datatable.Rows[count][0].ToString();
                driver_name_textbox.Text = datatable.Rows[count][1].ToString();
                driver_address_textbox.Text = datatable.Rows[count][2].ToString();
                contact_person_textbox.Text = datatable.Rows[count][3].ToString();
                driver_telephone_textbox.Text = datatable.Rows[count][4].ToString();
                order_num_textBox.Text = datatable.Rows[count][5].ToString();
                order_quantity_textBox.Text = datatable.Rows[count][6].ToString();
            }
        }
        private void AllTextClear()
        {
            driver_id_textbox.Text = "";
            driver_name_textbox.Text = "";
            driver_address_textbox.Text = "";
            contact_person_textbox.Text = "";
            driver_telephone_textbox.Text = "";
            order_num_textBox.Text = "";
            order_quantity_textBox.Text = "";
        }
        private void IsAllTextEnable(bool enable)
        {
            if (enable == true)
            {
                driver_id_textbox.Enabled = true;
                driver_name_textbox.Enabled = true;
                driver_address_textbox.Enabled = true;
                contact_person_textbox.Enabled = true;
                driver_telephone_textbox.Enabled = true;
                order_num_textBox.Enabled = true; 
                order_quantity_textBox.Enabled = true;
            }
            else if (enable == false)
            {
                driver_id_textbox.Enabled = false;
                driver_name_textbox.Enabled = false;
                driver_address_textbox.Enabled = false;
                contact_person_textbox.Enabled = false;
                driver_telephone_textbox.Enabled = false;
                order_num_textBox.Enabled = false;
                order_quantity_textBox.Enabled = false;
            }
        }
        //接受按鈕的輸入改變單筆資料的頁面
        private void ChangeData(object sender)
        {
            Button btn = sender as Button;
            if (data_tabControl.SelectedTab == all_data_tabpage) { return; }
            string selectQuery = "SELECT * FROM driver";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            switch (btn.Name)
            {
                case "first_data_btn":
                    if (datatable.Rows.Count != 0)
                    {
                        driver_id_textbox.Text = datatable.Rows[0][0].ToString();
                        driver_name_textbox.Text = datatable.Rows[0][1].ToString();
                        driver_address_textbox.Text = datatable.Rows[0][2].ToString();
                        contact_person_textbox.Text = datatable.Rows[0][3].ToString();
                        driver_telephone_textbox.Text = datatable.Rows[0][4].ToString();
                        order_num_textBox.Text = datatable.Rows[0][5].ToString();
                        order_quantity_textBox.Text = datatable.Rows[0][6].ToString();
                    }
                    break;
                case "up_data_btn":
                    if (driver_id_textbox.Text != "")
                    {
                        if (datatable.Rows.Count == 0) { return; }
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if (driver_id_textbox.Text == datatable.Rows[i][0].ToString())
                            {
                                if (i == 0) { return; }
                                driver_id_textbox.Text = datatable.Rows[i - 1][0].ToString();
                                driver_name_textbox.Text = datatable.Rows[i - 1][1].ToString();
                                driver_address_textbox.Text = datatable.Rows[i - 1][2].ToString();
                                contact_person_textbox.Text = datatable.Rows[i - 1][3].ToString();
                                driver_telephone_textbox.Text = datatable.Rows[i - 1][4].ToString();
                                order_num_textBox.Text = datatable.Rows[i - 1][5].ToString();
                                order_quantity_textBox.Text = datatable.Rows[i - 1][6].ToString();
                                return;
                            }
                        }
                    }
                    break;
                case "down_data_btn":
                    if (driver_id_textbox.Text != "")
                    {
                        if (datatable.Rows.Count == 0) { return; }
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if (driver_id_textbox.Text == datatable.Rows[i][0].ToString())
                            {
                                if (i == datatable.Rows.Count - 1) { return; }
                                driver_id_textbox.Text = datatable.Rows[i + 1][0].ToString();
                                driver_name_textbox.Text = datatable.Rows[i + 1][1].ToString();
                                driver_address_textbox.Text = datatable.Rows[i + 1][2].ToString();
                                contact_person_textbox.Text = datatable.Rows[i + 1][3].ToString();
                                driver_telephone_textbox.Text = datatable.Rows[i + 1][4].ToString();
                                order_num_textBox.Text = datatable.Rows[i + 1][5].ToString();
                                order_quantity_textBox.Text = datatable.Rows[i + 1][6].ToString();
                                return;
                            }
                        }
                    }
                    break;
                case "last_data_btn":
                    if (datatable.Rows.Count != 0)
                    {
                        var count = datatable.Rows.Count - 1;
                        driver_id_textbox.Text = datatable.Rows[count][0].ToString();
                        driver_name_textbox.Text = datatable.Rows[count][1].ToString();
                        driver_address_textbox.Text = datatable.Rows[count][2].ToString();
                        contact_person_textbox.Text = datatable.Rows[count][3].ToString();
                        driver_telephone_textbox.Text = datatable.Rows[count][4].ToString();
                        order_num_textBox.Text = datatable.Rows[count][5].ToString();
                        order_quantity_textBox.Text = datatable.Rows[count][6].ToString();
                    }
                    break;
                default:
                    break;
            }
        }


        private void new_btn_Click(object sender, EventArgs e)
        {
            data_tabControl.SelectedTab = single_data_tabpage;
            new_btn.Enabled = false;
            remove_btn.Enabled = false;
            revise_btn.Enabled = false;
            save_btn.Enabled = true;
            cancel_btn.Enabled = true;

            first_data_btn.Enabled = false;
            up_data_btn.Enabled = false;
            down_data_btn.Enabled = false;
            last_data_btn.Enabled = false;

            AllTextClear();
            IsAllTextEnable(true);
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("如果輸入錯誤資料，請聯絡MIS工程師，請勿輕易刪除資料!");
            return;

            if (alldata_listview.Items.Count > 0)
            {
                if (alldata_listview.SelectedItems.Count == 0)
                {
                    MessageBox.Show("請選擇要刪除的資料");
                    return;
                }
                data_tabControl.SelectedTab = single_data_tabpage;
                DialogResult result = MessageBox.Show("確定要刪除" + alldata_listview.SelectedItems[0].SubItems[1].Text + "的資料嗎", "注意", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        string removeQuery =
                        "DELETE FROM driver WHERE " +
                        $"driver_id = '{GetDriver().Id}'";
                        if (ConnectDatabase("刪除", removeQuery).ToString() == "1")
                        {
                            MessageBox.Show(GetDriver().Name + "：檔案刪除成功");
                            AllTextClear();
                            InputLastDriverDataToSingleTap();
                        }
                        else
                        { MessageBox.Show("檔案刪除失敗"); }
                        break;
                    case DialogResult.No:

                        break;
                    case DialogResult.Cancel:

                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("請選擇要刪除的資料");
            }
        }

        private void revise_btn_Click(object sender, EventArgs e)
        {
            if (driver_id_textbox.Text == "") { return; }
            data_tabControl.SelectedTab = single_data_tabpage;
            new_btn.Enabled = false;
            remove_btn.Enabled = false;
            revise_btn.Enabled = false;
            save_btn.Enabled = true;
            cancel_btn.Enabled = true;

            first_data_btn.Enabled = false;
            up_data_btn.Enabled = false;
            down_data_btn.Enabled = false;
            last_data_btn.Enabled = false;

            IsAllTextEnable(true);
            driver_id_textbox.Enabled = false;
            driver_name_textbox.Enabled = false;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (driver_id_textbox.Text == "" | driver_name_textbox.Text == "" | driver_telephone_textbox.Text == "" | order_num_textBox.Text == "" | order_quantity_textBox.Text == "")
            {
                MessageBox.Show("資料輸入不完整");
                return;
            }

            if (driver_id_textbox.Enabled == false)
            {
                //司機編號不能使用，所以是按下修改按鈕
                string reviseQuery =
                "UPDATE driver SET " +
                $"driver_name = '{GetDriver().Name}', " +
                $"driver_address = '{GetDriver().Address}', " +
                $"contact_person = '{GetDriver().ContactPerson}', " +
                $"driver_telephone = '{GetDriver().Telephone}', " +
                $"order_num = '{GetDriver().OrderNum}', " +
                $"order_quantity = '{GetDriver().OrderQuantity}' " +
                $"WHERE driver_id = '{GetDriver().Id}'";
                if (ConnectDatabase("修改", reviseQuery).ToString() == "1")
                {
                    MessageBox.Show(GetDriver().Name + "：檔案修改成功");
                }
                else
                { MessageBox.Show("檔案修改失敗"); }
            }
            else if (driver_id_textbox.Enabled == true)
            {
                //客戶編號可以使用，所以是按下新增按鈕
                string insertQuery =
                "INSERT INTO driver VALUES " +
                $"('{GetDriver().Id}'," +
                $"'{GetDriver().Name}'," +
                $"'{GetDriver().Address}'," +
                $"'{GetDriver().ContactPerson}'," +
                $"'{GetDriver().Telephone}'," +
                $"'{GetDriver().OrderNum}'," +
                $"'{GetDriver().OrderQuantity}')"; 
                if (ConnectDatabase("新增", insertQuery).ToString() == "1")
                {
                    MessageBox.Show(GetDriver().Name + "：檔案新增成功");
                    AllTextClear();
                    InputLastDriverDataToSingleTap();
                }
                else if (ConnectDatabase("新增", insertQuery).ToString() == "-1")
                { MessageBox.Show(GetDriver().Id + "：編號已被註冊，請改用其他編號！"); }
                else
                { MessageBox.Show(ConnectDatabase("新增", insertQuery).ToString()); }
            }
            new_btn.Enabled = true;
            revise_btn.Enabled = true;
            remove_btn.Enabled = true;
            save_btn.Enabled = false;
            cancel_btn.Enabled = false;

            first_data_btn.Enabled = true;
            up_data_btn.Enabled = true;
            down_data_btn.Enabled = true;
            last_data_btn.Enabled = true;

            IsAllTextEnable(false);

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            AllTextClear();
            IsAllTextEnable(false);
            new_btn.Enabled = true;
            revise_btn.Enabled = true;
            remove_btn.Enabled = true;
            save_btn.Enabled = false;
            cancel_btn.Enabled = false;

            first_data_btn.Enabled = true;
            up_data_btn.Enabled = true;
            down_data_btn.Enabled = true;
            last_data_btn.Enabled = true;
            InputLastDriverDataToSingleTap();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void data_tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (data_tabControl.SelectedIndex == 1)
            {
                //滑鼠點擊全部資料的頁面時去資料庫調資料
                string selectQuery = "SELECT * FROM driver";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
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
            else if (data_tabControl.SelectedIndex == 0)
            {
                //滑鼠點擊單筆資料的頁面時
                if (new_btn.Enabled == false) { return; }
                if (alldata_listview.SelectedItems.Count == 0)
                {
                    InputLastDriverDataToSingleTap();
                }
                else
                {
                    var id = alldata_listview.SelectedItems[0].SubItems[0].Text;
                    var name = alldata_listview.SelectedItems[0].SubItems[1].Text;
                    var address = alldata_listview.SelectedItems[0].SubItems[2].Text;
                    var contactPerson = alldata_listview.SelectedItems[0].SubItems[3].Text;
                    var telephone = alldata_listview.SelectedItems[0].SubItems[4].Text;
                    var orderNum = alldata_listview.SelectedItems[0].SubItems[5].Text;
                    var orderQuantity = alldata_listview.SelectedItems[0].SubItems[6].Text;

                    driver_id_textbox.Text = id;
                    driver_name_textbox.Text = name;
                    driver_address_textbox.Text = address;
                    contact_person_textbox.Text = contactPerson;
                    driver_telephone_textbox.Text = telephone;
                    order_num_textBox.Text = orderNum;
                    order_quantity_textBox.Text = orderQuantity;
                }
            }
        }

        private void first_data_btn_Click(object sender, EventArgs e)
        {
            ChangeData(sender);
        }

        private void up_data_btn_Click(object sender, EventArgs e)
        {
            ChangeData(sender);
        }

        private void down_data_btn_Click(object sender, EventArgs e)
        {
            ChangeData(sender);
        }

        private void last_data_btn_Click(object sender, EventArgs e)
        {
            ChangeData(sender);
        }

        private void DriverDataForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = alldata_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                alldata_listview.Columns[0].Width = (int)(totalWidth * 0.0756); // 第一欄占 30%
                alldata_listview.Columns[1].Width = (int)(totalWidth * 0.1260); // 第二欄占 30%
                alldata_listview.Columns[2].Width = (int)(totalWidth * 0.2689); // 第三欄占 40%
                alldata_listview.Columns[3].Width = (int)(totalWidth * 0.1260); // 第一欄占 30%
                alldata_listview.Columns[4].Width = (int)(totalWidth * 0.1260); // 第二欄占 30%
                alldata_listview.Columns[5].Width = (int)(totalWidth * 0.1008); // 第三欄占 40%
                alldata_listview.Columns[6].Width = (int)(totalWidth * 0.1008); // 第三欄占 40%
            }
        }
    }
}
