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
    public partial class AreaDataForm : Form
    {
        public AreaDataForm()
        {
            InitializeComponent();
            InputDriverDataToListbox();
            InputLastAreaDataToSingleTap();
        }

        //將單筆頁面的輸入轉成Area的型別
        private Area GetArea()
        {
            string id = area_id_textbox.Text;
            string name = area_name_textbox.Text;
            string driver = getDriverNameOrID("name", area_driver_combobox.Text);
            string deliverday = area_deliver_day_textbox.Text;

            Area area = new Area(id,name,driver, deliverday);
            return area;
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
        private void InputLastAreaDataToSingleTap()
        {
            string selectQuery = "SELECT * FROM area";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count != 0)
            {
                var count = datatable.Rows.Count - 1;
                area_id_textbox.Text = datatable.Rows[count][0].ToString();
                area_name_textbox.Text = datatable.Rows[count][1].ToString();
                area_driver_combobox.Text = getDriverNameOrID("id", datatable.Rows[count][2].ToString());
                area_deliver_day_textbox.Text = datatable.Rows[count][3].ToString();
            }
        }
        private void AllTextClear()
        {
            area_id_textbox.Text = "";
            area_name_textbox.Text = "";
            area_driver_combobox.Text = "";
            area_deliver_day_textbox.Text = "";
        }
        private void IsAllTextEnable(bool enable)
        {
            if (enable == true)
            {
                area_id_textbox.Enabled = true;
                area_name_textbox.Enabled = true;
                area_driver_combobox.Enabled = true;
                area_deliver_day_textbox.Enabled = true;
            }
            else if (enable == false)
            {
                area_id_textbox.Enabled = false;
                area_name_textbox.Enabled = false;
                area_driver_combobox.Enabled = false;
                area_deliver_day_textbox.Enabled = false;
            }
        }
        //接受按鈕的輸入改變單筆資料的頁面
        private void ChangeData(object sender)
        {
            Button btn = sender as Button;
            if (data_tabControl.SelectedTab == all_data_tabpage) { return; }
            string selectQuery = "SELECT * FROM area";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            switch (btn.Name)
            {
                case "first_data_btn":
                    if (datatable.Rows.Count != 0)
                    {
                        area_id_textbox.Text = datatable.Rows[0][0].ToString();
                        area_name_textbox.Text = datatable.Rows[0][1].ToString();
                        area_driver_combobox.Text = getDriverNameOrID("id", datatable.Rows[0][2].ToString());
                        area_deliver_day_textbox.Text = datatable.Rows[0][3].ToString();
                    }
                    break;
                case "up_data_btn":
                    if (area_id_textbox.Text != "")
                    {
                        if (datatable.Rows.Count == 0) { return; }
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if (area_id_textbox.Text == datatable.Rows[i][0].ToString())
                            {
                                if (i == 0) { return; }
                                area_id_textbox.Text = datatable.Rows[i - 1][0].ToString();
                                area_name_textbox.Text = datatable.Rows[i - 1][1].ToString();
                                area_driver_combobox.Text = getDriverNameOrID("id", datatable.Rows[i - 1][2].ToString());
                                area_deliver_day_textbox.Text = datatable.Rows[i - 1][3].ToString();
                                return;
                            }
                        }
                    }
                    break;
                case "down_data_btn":
                    if (area_id_textbox.Text != "")
                    {
                        if (datatable.Rows.Count == 0) { return; }
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if (area_id_textbox.Text == datatable.Rows[i][0].ToString())
                            {
                                if (i == datatable.Rows.Count - 1) { return; }
                                area_id_textbox.Text = datatable.Rows[i + 1][0].ToString();
                                area_name_textbox.Text = datatable.Rows[i + 1][1].ToString();
                                area_driver_combobox.Text = getDriverNameOrID("id", datatable.Rows[i + 1][2].ToString());
                                area_deliver_day_textbox.Text = datatable.Rows[i + 1][3].ToString();
                                return;
                            }
                        }
                    }
                    break;
                case "last_data_btn":
                    if (datatable.Rows.Count != 0)
                    {
                        var count = datatable.Rows.Count - 1;
                        area_id_textbox.Text = datatable.Rows[count][0].ToString();
                        area_name_textbox.Text = datatable.Rows[count][1].ToString();
                        area_driver_combobox.Text = getDriverNameOrID("id", datatable.Rows[count][2].ToString());
                        area_deliver_day_textbox.Text = datatable.Rows[count][3].ToString();
                    }
                    break;
                default:
                    break;
            }
        }
        private void InputDriverDataToListbox()
        {
            area_driver_combobox.Items.Clear();
            string selectQuery = "SELECT * FROM driver";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count != 0)
            {
                foreach (DataRow item in datatable.Rows)
                {
                    area_driver_combobox.Items.Add(item[1]);
                }
            }
        }
        private string getDriverNameOrID(string nameOrid, string value)
        {
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
                        "DELETE FROM area WHERE " +
                        $"area_id = '{GetArea().Id}'";
                        if (ConnectDatabase("刪除", removeQuery).ToString() == "1")
                        {
                            MessageBox.Show(GetArea().Name + "：檔案刪除成功");
                            AllTextClear();
                            InputLastAreaDataToSingleTap();
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
            if (area_id_textbox.Text == "") { return; }
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
            area_id_textbox.Enabled = false;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (area_id_textbox.Text == "" | area_name_textbox.Text == "" | area_driver_combobox.Text == "" | area_deliver_day_textbox.Text == "")
            {
                MessageBox.Show("資料輸入不完整");
                return;
            }

            if (area_id_textbox.Enabled == false)
            {
                //司機編號不能使用，所以是按下修改按鈕
                string reviseQuery =
                "UPDATE area SET " +
                $"area_name = '{GetArea().Name}', " +
                $"driver_id = '{GetArea().Driver}', " +
                $"deliver_day = '{GetArea().DeliverDay}' " +
                $"WHERE area_id = '{GetArea().Id}'";
                if (ConnectDatabase("修改", reviseQuery).ToString() == "1")
                {
                    MessageBox.Show(GetArea().Name + "：檔案修改成功");
                }
                else
                { MessageBox.Show("檔案修改失敗"); }
            }
            else if (area_id_textbox.Enabled == true)
            {
                //客戶編號可以使用，所以是按下新增按鈕
                string insertQuery =
                "INSERT INTO area (area_id, area_name, driver_id, deliver_day) VALUES " +
                $"('{GetArea().Id}'," +
                $"'{GetArea().Name}'," +
                $"'{GetArea().Driver}'," +
                $"'{GetArea().DeliverDay}')";
                if (ConnectDatabase("新增", insertQuery).ToString() == "1")
                {
                    MessageBox.Show(GetArea().Name + "：檔案新增成功");
                    AllTextClear();
                    InputLastAreaDataToSingleTap();
                }
                else if (ConnectDatabase("新增", insertQuery).ToString() == "-1")
                { MessageBox.Show(GetArea().Id + "：編號已被註冊，請改用其他編號！"); }
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
            InputLastAreaDataToSingleTap();
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
                string selectQuery = "SELECT * FROM area";
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
                    InputLastAreaDataToSingleTap();
                }
                else
                {
                    var id = alldata_listview.SelectedItems[0].SubItems[0].Text;
                    var name = alldata_listview.SelectedItems[0].SubItems[1].Text;
                    var driver = alldata_listview.SelectedItems[0].SubItems[2].Text;
                    var deliverday = alldata_listview.SelectedItems[0].SubItems[3].Text;

                    area_id_textbox.Text = id;
                    area_name_textbox.Text = name;
                    area_driver_combobox.Text = getDriverNameOrID("id", driver);
                    area_deliver_day_textbox.Text = deliverday;
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

        private void AreaDataForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = alldata_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                alldata_listview.Columns[0].Width = (int)(totalWidth * 0.075); // 第一欄占 30%
                alldata_listview.Columns[1].Width = (int)(totalWidth * 0.125); // 第二欄占 30%
                alldata_listview.Columns[2].Width = (int)(totalWidth * 0.2666); // 第三欄占 40%
                alldata_listview.Columns[3].Width = (int)(totalWidth * 0.125); // 第一欄占 30%
            }
        }
    }


}
