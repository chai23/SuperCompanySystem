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
    public partial class ProductDataForm : Form
    {
        public ProductDataForm()
        {
            InitializeComponent();
            InputLastClientDataToSingleTap();
        }

        //將單筆頁面的輸入轉成Customer的型別
        private Product GetProduct()
        {
            string prod_id = product_id_textbox.Text;
            string prod_name = product_name_textbox.Text;
            string prod_unit = product_unit_textbox.Text;
            string prod_cost = product_cost_textbox.Text;
            string prod_price = product_price_textbox.Text;
            string prod_reserve = product_reserve_textbox.Text;
            bool is_join_reserve = is_join_reserve_chb.Checked;
            bool special = spacial_product_chb.Checked;
            bool is_join_tex = is_join_tex_chb.Checked;
            bool is_join_remain = is_join_remain_chb.Checked;
            bool is_join_bucket = is_join_bucket_chb.Checked;

            Product product = new Product(prod_id,prod_name,prod_unit,prod_cost,prod_price,prod_reserve,is_join_reserve,special, is_join_tex, is_join_bucket, is_join_remain);
            return product;
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
        private void InputLastClientDataToSingleTap()
        {
            string selectQuery = "SELECT * FROM product";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count != 0)
            {
                var count = datatable.Rows.Count - 1;
                product_id_textbox.Text = datatable.Rows[count][0].ToString();
                product_name_textbox.Text = datatable.Rows[count][1].ToString();
                product_unit_textbox.Text = datatable.Rows[count][2].ToString();
                product_cost_textbox.Text = datatable.Rows[count][3].ToString();
                product_price_textbox.Text = datatable.Rows[count][4].ToString();
                product_reserve_textbox.Text = datatable.Rows[count][5].ToString();
                is_join_reserve_chb.Checked = Convert.ToBoolean(datatable.Rows[count][6]);
                spacial_product_chb.Checked = Convert.ToBoolean(datatable.Rows[count][7]);
                is_join_tex_chb.Checked = Convert.ToBoolean(datatable.Rows[count][8]);
                is_join_bucket_chb.Checked = Convert.ToBoolean(datatable.Rows[count][9]);
                is_join_remain_chb.Checked = Convert.ToBoolean(datatable.Rows[count][10]);
            }
        }
        private void AllTextClear()
        {
            product_id_textbox.Text = "";
            product_name_textbox.Text = "";
            product_unit_textbox.Text = "";
            product_cost_textbox.Text = "";
            product_price_textbox.Text = "";
            product_reserve_textbox.Text = "";
            is_join_reserve_chb.Checked = false;
            spacial_product_chb.Checked = false;
            is_join_tex_chb.Checked = false;
            is_join_bucket_chb.Checked = false;
            is_join_remain_chb.Checked = false;
        }
        private void IsAllTextEnable(bool enable)
        {
            if (enable == true)
            {
                product_id_textbox.Enabled = true;
                product_name_textbox.Enabled = true;
                product_unit_textbox.Enabled = true;
                product_cost_textbox.Enabled = true;
                product_price_textbox.Enabled = true;
                product_reserve_textbox.Enabled = true;
                is_join_reserve_chb.Enabled = true;
                spacial_product_chb.Enabled=true;
                is_join_tex_chb.Enabled = true;
                is_join_bucket_chb.Enabled = true;
                is_join_remain_chb.Enabled = true;
            }
            else if (enable == false)
            {
                product_id_textbox.Enabled = false;
                product_name_textbox.Enabled = false;
                product_unit_textbox.Enabled = false;
                product_cost_textbox.Enabled = false;
                product_price_textbox.Enabled = false;
                product_reserve_textbox.Enabled = false;
                is_join_reserve_chb.Enabled = false;
                spacial_product_chb.Enabled = false;
                is_join_tex_chb.Enabled = false;
                is_join_bucket_chb.Enabled = false;
                is_join_remain_chb.Enabled = false;
            }
        }
        //接受按鈕的輸入改變單筆資料的頁面
        private void ChangeData(object sender)
        {
            Button btn = sender as Button;
            if (data_tabControl.SelectedTab == all_data_tabpage) { return; }
            string selectQuery = "SELECT * FROM product";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            switch (btn.Name)
            {
                case "first_data_btn":
                    if (datatable.Rows.Count != 0)
                    {
                        product_id_textbox.Text = datatable.Rows[0][0].ToString();
                        product_name_textbox.Text = datatable.Rows[0][1].ToString();
                        product_unit_textbox.Text = datatable.Rows[0][2].ToString();
                        product_cost_textbox.Text = datatable.Rows[0][3].ToString();
                        product_price_textbox.Text = datatable.Rows[0][4].ToString();
                        product_reserve_textbox.Text = datatable.Rows[0][5].ToString();
                        is_join_reserve_chb.Checked = Convert.ToBoolean(datatable.Rows[0][6]);
                        spacial_product_chb.Checked = Convert.ToBoolean(datatable.Rows[0][7]);
                        is_join_tex_chb.Checked = Convert.ToBoolean(datatable.Rows[0][8]);
                        is_join_bucket_chb.Checked = Convert.ToBoolean(datatable.Rows[0][9]);
                        is_join_remain_chb.Checked = Convert.ToBoolean(datatable.Rows[0][10]);
                    }
                    break;
                case "up_data_btn":
                    if (product_id_textbox.Text != "")
                    {
                        if (datatable.Rows.Count == 0) { return; }
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if (product_id_textbox.Text == datatable.Rows[i][0].ToString())
                            {
                                if (i == 0) { return; }
                                product_id_textbox.Text = datatable.Rows[i - 1][0].ToString();
                                product_name_textbox.Text = datatable.Rows[i - 1][1].ToString();
                                product_unit_textbox.Text = datatable.Rows[i - 1][2].ToString();
                                product_cost_textbox.Text = datatable.Rows[i - 1][3].ToString();
                                product_price_textbox.Text = datatable.Rows[i - 1][4].ToString();
                                product_reserve_textbox.Text = datatable.Rows[i - 1][5].ToString() ;
                                is_join_reserve_chb.Checked = Convert.ToBoolean(datatable.Rows[i - 1][6]);
                                spacial_product_chb.Checked = Convert.ToBoolean(datatable.Rows[i - 1][7]);
                                is_join_tex_chb.Checked = Convert.ToBoolean(datatable.Rows[i - 1][8]);
                                is_join_bucket_chb.Checked = Convert.ToBoolean(datatable.Rows[i - 1][9]);
                                is_join_remain_chb.Checked = Convert.ToBoolean(datatable.Rows[i - 1][10]);
                                return;
                            }
                        }
                    }
                    break;
                case "down_data_btn":
                    if (product_id_textbox.Text != "")
                    {
                        if (datatable.Rows.Count == 0) { return; }
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if (product_id_textbox.Text == datatable.Rows[i][0].ToString())
                            {
                                if (i == datatable.Rows.Count - 1) { return; }
                                product_id_textbox.Text = datatable.Rows[i + 1][0].ToString();
                                product_name_textbox.Text = datatable.Rows[i + 1][1].ToString();
                                product_unit_textbox.Text = datatable.Rows[i + 1][2].ToString();
                                product_cost_textbox.Text = datatable.Rows[i + 1][3].ToString();
                                product_price_textbox.Text = datatable.Rows[i + 1][4].ToString();
                                product_reserve_textbox.Text = datatable.Rows[i + 1][5].ToString();
                                is_join_reserve_chb.Checked = Convert.ToBoolean(datatable.Rows[i + 1][6]);
                                spacial_product_chb.Checked = Convert.ToBoolean(datatable.Rows[i + 1][7]);
                                is_join_tex_chb.Checked = Convert.ToBoolean(datatable.Rows[i + 1][8]);
                                is_join_bucket_chb.Checked = Convert.ToBoolean(datatable.Rows[i + 1][9]);
                                is_join_remain_chb.Checked = Convert.ToBoolean(datatable.Rows[i + 1][10]);
                                return;
                            }
                        }
                    }
                    break;
                case "last_data_btn":
                    if (datatable.Rows.Count != 0)
                    {
                        var count = datatable.Rows.Count - 1;
                        product_id_textbox.Text = datatable.Rows[count][0].ToString();
                        product_name_textbox.Text = datatable.Rows[count][1].ToString();
                        product_unit_textbox.Text = datatable.Rows[count][2].ToString();
                        product_cost_textbox.Text = datatable.Rows[count][3].ToString();
                        product_price_textbox.Text = datatable.Rows[count][4].ToString();
                        product_reserve_textbox.Text = datatable.Rows[count][5].ToString();
                        is_join_reserve_chb.Checked = Convert.ToBoolean(datatable.Rows[count][6]);
                        spacial_product_chb.Checked = Convert.ToBoolean(datatable.Rows[count][7]);
                        is_join_tex_chb.Checked = Convert.ToBoolean(datatable.Rows[count][8]);
                        is_join_bucket_chb.Checked = Convert.ToBoolean(datatable.Rows[count][9]);
                        is_join_remain_chb.Checked = Convert.ToBoolean(datatable.Rows[count][10]);
                    }
                    break;
                default:
                    break;
            }
        }


        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        "DELETE FROM product WHERE " +
                        $"product_id = '{GetProduct().Id}'";
                        if (ConnectDatabase("刪除", removeQuery).ToString() == "1")
                        {
                            MessageBox.Show(GetProduct().Name + "：檔案刪除成功");
                            AllTextClear();
                            InputLastClientDataToSingleTap();
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
            if (product_id_textbox.Text == "") { return; }
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
            product_id_textbox.Enabled = false;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (product_id_textbox.Text == "" | product_name_textbox.Text == "" | product_price_textbox.Text == "" | product_reserve_textbox.Text == "")
            {
                MessageBox.Show("資料輸入不完整");
                return;
            }

            if (product_id_textbox.Enabled == false)
            {
                //商品編號不能使用，所以是按下修改按鈕
                string reviseQuery =
                "UPDATE product SET " +
                $"product_name = '{GetProduct().Name}', " +
                $"product_unit = '{GetProduct().Unit}', " +
                $"product_cost = '{GetProduct().Cost}', " +
                $"product_price = '{GetProduct().Price}', " +
                $"product_reserve = '{GetProduct().Reserve}', " +
                $"is_join_reserve = {GetProduct().IsJoinReserve}, " +
                $"special_product = {GetProduct().Special}, " +
                $"is_join_tex = {GetProduct().IsJoinTex}, " +
                $"is_join_bucket = {GetProduct().IsJoinBucket}, " +
                $"is_join_remain = {GetProduct().IsJoinRemain} " +
                $"WHERE product_id = '{GetProduct().Id}'";
                Console.WriteLine( reviseQuery );   
                if (ConnectDatabase("修改", reviseQuery).ToString() == "1")
                {
                    MessageBox.Show(GetProduct().Name + "：檔案修改成功");
                }
                else
                { MessageBox.Show("檔案修改失敗"); }
            }
            else if (product_id_textbox.Enabled == true)
            {
                //客戶編號可以使用，所以是按下新增按鈕
                string insertQuery =
                "INSERT INTO product VALUES " +
                $"('{GetProduct().Id}'," +
                $"'{GetProduct().Name}'," +
                $"'{GetProduct().Unit}'," +
                $"'{GetProduct().Cost}'," +
                $"'{GetProduct().Price}'," +
                $"'{GetProduct().Reserve}'," +
                $"{GetProduct().IsJoinReserve}," +
                $"{GetProduct().Special}," +
                $"{GetProduct().IsJoinTex}," +
                $"{GetProduct().IsJoinBucket}," +
                $"{GetProduct().IsJoinRemain})";
                if (ConnectDatabase("新增", insertQuery).ToString() == "1")
                {
                    MessageBox.Show(GetProduct().Name + "：檔案新增成功");
                    AllTextClear();
                    InputLastClientDataToSingleTap();
                }
                else if (ConnectDatabase("新增", insertQuery).ToString() == "-1")
                { MessageBox.Show(GetProduct().Id + "：編號已被註冊，請改用其他編號！"); }
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
            InputLastClientDataToSingleTap();
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

        private void data_tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (data_tabControl.SelectedIndex == 1)
            {
                //滑鼠點擊全部資料的頁面時去資料庫調資料
                string selectQuery = "SELECT * FROM product WHERE product_id <> '000' AND product_id <> '0000'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                alldata_listview.Items.Clear();

                foreach (DataRow row in datatable.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    for (int i = 1; i < datatable.Columns.Count; i++)
                    {
                        item.SubItems.Add(row[i].ToString());
                    }
                    if (item.SubItems[6].Text == "True")
                    {
                        item.SubItems[6].Text = "是";
                    }
                    else
                    {
                        item.SubItems[6].Text = "否";
                    }
                    if (item.SubItems[7].Text == "True")
                    {
                        item.SubItems[7].Text = "是";
                    }
                    else
                    {
                        item.SubItems[7].Text = "否";
                    }
                    if (item.SubItems[8].Text == "True")
                    {
                        item.SubItems[8].Text = "是";
                    }
                    else
                    {
                        item.SubItems[8].Text = "否";
                    }
                    if (item.SubItems[9].Text == "True")
                    {
                        item.SubItems[9].Text = "是";
                    }
                    else
                    {
                        item.SubItems[9].Text = "否";
                    }
                    if (item.SubItems[10].Text == "True")
                    {
                        item.SubItems[10].Text = "是";
                    }
                    else
                    {
                        item.SubItems[10].Text = "否";
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
                    InputLastClientDataToSingleTap();
                }
                else
                {
                    var id = alldata_listview.SelectedItems[0].SubItems[0].Text;
                    var name = alldata_listview.SelectedItems[0].SubItems[1].Text;
                    var unit = alldata_listview.SelectedItems[0].SubItems[2].Text;
                    var cost = alldata_listview.SelectedItems[0].SubItems[3].Text;
                    var price = alldata_listview.SelectedItems[0].SubItems[4].Text;
                    var reserve = alldata_listview.SelectedItems[0].SubItems[5].Text;
                    var is_join_reserve = alldata_listview.SelectedItems[0].SubItems[6].Text;
                    var special = alldata_listview.SelectedItems[0].SubItems[7].Text;
                    var is_join_tex = alldata_listview.SelectedItems[0].SubItems[8].Text;
                    var is_join_bucket = alldata_listview.SelectedItems[0].SubItems[9].Text;
                    var is_join_remain = alldata_listview.SelectedItems[0].SubItems[10].Text;

                    product_id_textbox.Text = id;
                    product_name_textbox.Text = name;
                    product_unit_textbox.Text = unit;
                    product_cost_textbox.Text = cost;
                    product_price_textbox.Text = price;
                    product_reserve_textbox.Text = reserve;
                    if (is_join_reserve == "是")
                    {
                        is_join_reserve_chb.Checked = true;
                    }
                    else
                    {
                        is_join_reserve_chb.Checked = false;
                    }
                    if (special == "是")
                    {
                        spacial_product_chb.Checked = true;
                    }
                    else
                    {
                        spacial_product_chb.Checked = false;
                    }
                    if (is_join_tex == "是")
                    {
                        is_join_tex_chb.Checked = true;
                    }
                    else
                    {
                        is_join_tex_chb.Checked = false;
                    }
                    if (is_join_bucket == "是")
                    {
                        is_join_bucket_chb.Checked = true;
                    }
                    else
                    {
                        is_join_bucket_chb.Checked = false;
                    }
                    if (is_join_remain == "是")
                    {
                        is_join_remain_chb.Checked = true;
                    }
                    else
                    {
                        is_join_remain_chb.Checked = false;
                    }
                }
            }
        }

        private void ProductDataForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = alldata_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                alldata_listview.Columns[0].Width = (int)(totalWidth * 0.0755); // 第一欄占 30%
                alldata_listview.Columns[1].Width = (int)(totalWidth * 0.1258); // 第二欄占 30%
                alldata_listview.Columns[2].Width = (int)(totalWidth * 0.0587); // 第三欄占 40%
                alldata_listview.Columns[3].Width = (int)(totalWidth * 0.0838); // 第一欄占 30%
                alldata_listview.Columns[4].Width = (int)(totalWidth * 0.0838); // 第二欄占 30%
                alldata_listview.Columns[5].Width = (int)(totalWidth * 0.0838); // 第三欄占 40%
                alldata_listview.Columns[6].Width = (int)(totalWidth * 0.1006); // 第一欄占 30%
                alldata_listview.Columns[7].Width = (int)(totalWidth * 0.1006); // 第二欄占 30%
                alldata_listview.Columns[8].Width = (int)(totalWidth * 0.1006); // 第三欄占 40%
                alldata_listview.Columns[9].Width = (int)(totalWidth * 0.1006); // 第一欄占 30%
                alldata_listview.Columns[10].Width = (int)(totalWidth * 0.1006); // 第二欄占 30%
            }
        }
    }
}
