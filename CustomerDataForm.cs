using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace 超好企業系統
{
    public partial class CustomerDataForm : Form
    {
        public CustomerDataForm()
        {
            InitializeComponent();
            InputAreaDataToListbox();
            InputLastClientDataToSingleTap();
        }

        //將單筆頁面的輸入轉成Customer的型別
        private Customer GetCustomer()
        {
            string cus_id = customer_id_textbox.Text;
            string cus_name = customer_name_textbox.Text;
            string cus_address = customer_address_textbox.Text;
            string contact_person = contact_person_textbox.Text;
            string cus_phone = customer_phone_textbox.Text;
            string cus_telephone = customer_telephone_textbox.Text;
            string cus_bill_form = bill_form_comboBox.Text;
            string cus_invoice = customer_invoice_textbox.Text;
            string cus_bill_address = customer_bill_address_textbox.Text;
            string cus_collect_money = collect_money_comboBox.Text;
            string bucket = bucket_textBox.Text;
            string remain = remain_textbox.Text;
            string area_id = getAreaNameOrID("name", area_id_comboBox.Text);
            string area_id_2 = getAreaNameOrID("name", area_id_2_comboBox.Text);
            string company = company_comboBox.Text;
            string remark = customer_remark_textBox.Text;
            string customer_id_mark = customer_id_textbox.Text;
            string old_remain = old_remain_textbox.Text;
            string old_bucket = old_bucket_textbox.Text;
            string add_day = dateTimePicker.Value.ToString("yyyy-MM-dd");

            Customer customer = new Customer(cus_id,cus_name,cus_address,contact_person, cus_phone, cus_telephone,cus_bill_form,cus_invoice, cus_bill_address, cus_collect_money,bucket,remain,area_id, area_id_2,company, remark, customer_id_mark, old_remain, old_bucket, add_day);
            return customer;
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
        private void InputClientDataToSingleTap(string customer_id)
        {

            string selectQuery = "SELECT * FROM customer " +
                $"WHERE customer_id_mark = '{customer_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows.Count != 0)
            {
                customer_id_textbox.Text = datatable.Rows[0][16].ToString();
                customer_name_textbox.Text = datatable.Rows[0][1].ToString();
                customer_address_textbox.Text = datatable.Rows[0][2].ToString();
                contact_person_textbox.Text = datatable.Rows[0][3].ToString();
                customer_phone_textbox.Text = datatable.Rows[0][4].ToString();
                customer_telephone_textbox.Text = datatable.Rows[0][5].ToString();
                bill_form_comboBox.Text = datatable.Rows[0][6].ToString();
                customer_invoice_textbox.Text = datatable.Rows[0][7].ToString();
                customer_bill_address_textbox.Text = datatable.Rows[0][8].ToString();
                collect_money_comboBox.Text = datatable.Rows[0][9].ToString();
                bucket_textBox.Text = datatable.Rows[0][10].ToString();
                remain_textbox.Text = datatable.Rows[0][11].ToString();
                area_id_comboBox.Text = getAreaNameOrID("id", datatable.Rows[0][12].ToString());
                area_id_2_comboBox.Text = getAreaNameOrID("id", datatable.Rows[0][13].ToString());
                company_comboBox.Text = datatable.Rows[0][14].ToString();
                customer_remark_textBox.Text = datatable.Rows[0][15].ToString();
                old_remain_textbox.Text = datatable.Rows[0][17].ToString();
                old_bucket_textbox.Text = datatable.Rows[0][18].ToString();
                dateTimePicker.Value = DateTime.Parse(datatable.Rows[0][19].ToString());
            }

            custAdd_listview.Items.Clear();
            int index = 1;
            foreach (DataRow add in datatable.Rows)
            {
                ListViewItem item = new ListViewItem(index.ToString()); //序
                item.SubItems.Add(add[2].ToString()); //客戶地址
                item.SubItems.Add(add[12].ToString()); //主要送貨區域
                item.SubItems.Add(add[13].ToString()); //次要送貨區域
                item.SubItems.Add(add[15].ToString()); //備註

                custAdd_listview.Items.Add(item);
                index++;
            }
        }
        //把最後一筆資料放到單筆資料的頁面
        private void InputLastClientDataToSingleTap()
        {
            string selectQuery = "SELECT customer_id_mark FROM customer " +
                $"ORDER BY customer_id_mark DESC LIMIT 0 , 1";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            InputClientDataToSingleTap(datatable.Rows[0][0].ToString());
        }
        private void AllTextClear()
        {
            customer_id_textbox.Text = "";
            customer_name_textbox.Text = "";
            customer_address_textbox.Text = "";
            contact_person_textbox.Text = "";
            customer_phone_textbox.Text = "";
            customer_telephone_textbox.Text = "";
            bill_form_comboBox.Text = "";
            customer_invoice_textbox.Text = "";
            customer_bill_address_textbox.Text = "";
            collect_money_comboBox.Text = "";
            bucket_textBox.Text = "";
            remain_textbox.Text = "";
            area_id_comboBox.Text = "";
            area_id_2_comboBox.Text = "";
            company_comboBox.Text = "";
            customer_remark_textBox.Text = "";
            old_remain_textbox.Text = "";
            old_bucket_textbox.Text = "";
            custAdd_listview.Items.Clear();
            dateTimePicker.Value = DateTime.Now;
        }
        private void IsAllTextEnable(bool enable)
        {
            if (enable == true)
            {
                customer_id_textbox.Enabled = true;
                customer_name_textbox.Enabled = true;
                customer_address_textbox.Enabled = true;
                contact_person_textbox.Enabled = true;
                customer_phone_textbox.Enabled = true;
                customer_telephone_textbox.Enabled = true;
                bill_form_comboBox.Enabled = true;
                customer_invoice_textbox.Enabled = true;
                customer_bill_address_textbox.Enabled= true;
                collect_money_comboBox.Enabled = true;
                bucket_textBox.Enabled = true;
                remain_textbox.Enabled = true;
                area_id_comboBox.Enabled = true;
                area_id_2_comboBox.Enabled = true;
                company_comboBox.Enabled = true;
                customer_remark_textBox.Enabled = true;
                old_remain_textbox.Enabled = true;
                old_bucket_textbox.Enabled = true;
                dateTimePicker.Enabled = true;
            }
            else if (enable == false)
            {
                customer_id_textbox.Enabled = false;
                customer_name_textbox.Enabled = false;
                customer_address_textbox.Enabled = false;
                contact_person_textbox.Enabled = false;
                customer_phone_textbox.Enabled = false;
                customer_telephone_textbox.Enabled = false;
                bill_form_comboBox.Enabled= false;
                customer_invoice_textbox.Enabled = false;
                customer_bill_address_textbox.Enabled = false;
                collect_money_comboBox.Enabled= false;
                bucket_textBox.Enabled = false; 
                remain_textbox.Enabled = false;
                area_id_comboBox.Enabled = false;
                area_id_2_comboBox.Enabled = false;
                company_comboBox.Enabled = false;
                customer_remark_textBox.Enabled= false;
                old_remain_textbox.Enabled = false;
                old_bucket_textbox.Enabled = false;
                dateTimePicker.Enabled = false;
            }
        }
        //接受按鈕的輸入改變單筆資料的頁面
        private void ChangeData(object sender)
        {
            Button btn = sender as Button;
            if (data_tabControl.SelectedTab == all_data_tabpage) { return; }
            string selectQuery = "SELECT customer_id_mark FROM customer group by customer_id_mark ORDER BY customer_id_mark ASC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            switch (btn.Name)
            {
                case "first_data_btn":
                    if (datatable.Rows.Count != 0)
                    {
                        InputClientDataToSingleTap(datatable.Rows[0][0].ToString());
                    }
                    break;
                case "up_data_btn":
                    if (customer_id_textbox.Text != "")
                    {
                        if (datatable.Rows.Count == 0) { return; }
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if (customer_id_textbox.Text == datatable.Rows[i][0].ToString())
                            {
                                if (i == 0) { return; }
                                InputClientDataToSingleTap(datatable.Rows[i - 1][0].ToString());
                                return;
                            }
                        }
                    }
                    break;
                case "down_data_btn":
                    if (customer_id_textbox.Text != "")
                    {
                        if (datatable.Rows.Count == 0) { return; }
                        for (int i = 0; i < datatable.Rows.Count; i++)
                        {
                            if (customer_id_textbox.Text == datatable.Rows[i][0].ToString())
                            {
                                if (i == datatable.Rows.Count-1) { return; }
                                InputClientDataToSingleTap(datatable.Rows[i + 1][0].ToString());
                                return;
                            }
                        }
                    }
                    break;
                case "last_data_btn":
                    if (datatable.Rows.Count != 0)
                    {
                        var count = datatable.Rows.Count - 1;
                        InputClientDataToSingleTap(datatable.Rows[count][0].ToString());
                    }
                    break;
                default:
                    break;
            }
        }

        private void updateRemainOrderListView(string customer_id)
        {
            remain_order_ListView.Items.Clear();
            string sql = "";

            string selectQuery = "SELECT customer_id FROM `customer` " +
                $"WHERE customer_id_mark = '{customer_id}' ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            foreach (DataRow item in datatable.Rows)
            {
                if (item[0].ToString().Contains('-'))
                {
                    sql = sql + $" OR o.customer_id = '{item[0].ToString()}'";
                }
            }
            string selectQuery1 = "SELECT o.order_id, o.order_day, o.product_name, o.product_quantity, o.customer_id, o.give_nofree, c.customer_address, o.give_free, o.product_id FROM `order` as o , `customer` as c " +
                $"WHERE (o.customer_id = '{customer_id}'" + sql + ") and o.collect_money = '預收' and o.customer_id = c.customer_id ORDER BY order_day ASC";
            DataTable datatable1 = ConnectDatabase("查詢", selectQuery1) as DataTable;

            int quantity = int.Parse(old_remain_textbox.Text);

            foreach (DataRow order in datatable1.Rows)
            {
                if (int.Parse(order[8].ToString()) >= 1 && int.Parse(order[8].ToString()) <= 200)
                {

                    ListViewItem item = new ListViewItem(order[0].ToString()); //order_id
                    item.SubItems.Add(order[1].ToString().Split(' ')[0]); //order_day
                    item.SubItems.Add(order[2].ToString()); //product_name
                    if (order[5].ToString() == "True" & order[7].ToString() == "False")
                    {
                        quantity = quantity - int.Parse(order[3].ToString());
                        item.SubItems.Add(""); //product_quantity
                        item.SubItems.Add(order[3].ToString()); //product_quantity
                    }
                    else if (order[5].ToString() == "False" & order[7].ToString() == "False")
                    {
                        quantity = quantity + int.Parse(order[3].ToString());
                        item.SubItems.Add(order[3].ToString()); //product_quantity
                        item.SubItems.Add(""); //product_quantity
                    }
                    else if (order[5].ToString() == "False" & order[7].ToString() == "True")
                    {
                        quantity = quantity + int.Parse(order[3].ToString());
                        item.SubItems.Add(order[3].ToString()); //product_quantity
                        item.SubItems.Add(""); //product_quantity
                    }
                    else if (order[5].ToString() == "True" & order[7].ToString() == "True")
                    {

                    }

                    item.SubItems.Add(quantity.ToString()); //剩餘數量
                    item.SubItems.Add(order[6].ToString()); //客戶地址

                    remain_order_ListView.Items.Add(item);
                }
            }
        }

        private void InputAreaDataToListbox()
        {
            area_id_comboBox.Items.Clear();
            area_id_2_comboBox.Items.Clear();
            string selectQuery = "SELECT * FROM area";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count != 0)
            {
                foreach (DataRow item in datatable.Rows)
                {
                    area_id_comboBox.Items.Add(item[1]);
                    area_id_2_comboBox.Items.Add(item[1]);
                }
            }
        }

        private string getAreaNameOrID(string nameOrid, string value)
        {
            if (value == "無") { return "無"; }
            if (nameOrid == "name")
            {
                string selectQuery = "SELECT area_id FROM area " +
                $"WHERE area_name = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else if (nameOrid == "id")
            {
                string selectQuery = "SELECT area_name FROM area " +
                $"WHERE area_id = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }

        //按下離開按鈕
        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //按下新增按鈕
        private void new_btn_Click(object sender, EventArgs e)
        {
            data_tabControl.SelectedTab = single_data_tabpage;
            new_btn.Enabled = false;
            remove_btn.Enabled = false;
            revise_btn.Enabled = false;
            serch_btn.Enabled = false;
            save_btn.Enabled = true;
            cancel_btn.Enabled = true;
            first_data_btn.Enabled = false;
            up_data_btn.Enabled = false;
            down_data_btn.Enabled = false;
            last_data_btn.Enabled = false;

            AllTextClear();
            IsAllTextEnable(true);

        }
        //按下刪除按鈕
        private void remove_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("如果輸入錯誤資料，請聯絡MIS工程師，請勿輕易刪除資料!");
            return;

            if (data_tabControl.SelectedTab == all_data_tabpage & alldata_listview.SelectedItems.Count == 0) 
            { 
                return;
            }
            else if(data_tabControl.SelectedTab == all_data_tabpage)
            {
                data_tabControl.SelectedTab = single_data_tabpage;
                InputClientDataToSingleTap(alldata_listview.SelectedItems[0].SubItems[0].Text);
            }


            if (customer_id_textbox.Text != "")
            {
                DialogResult result = MessageBox.Show("確定要刪除" + customer_name_textbox.Text + "的資料嗎", "注意", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        string removeQuery =
                        "DELETE FROM customer WHERE " +
                        $"customer_id_mark = '{customer_id_textbox.Text}'";
                        string anser = ConnectDatabase("刪除", removeQuery).ToString();
                        if (anser == "-1")
                        {
                            MessageBox.Show("檔案刪除失敗");
                        }
                        else
                        {
                            MessageBox.Show(GetCustomer().Name + "：檔案刪除成功");
                            AllTextClear();
                            InputLastClientDataToSingleTap();
                        }
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
        //按下修改按鈕
        private void revise_btn_Click(object sender, EventArgs e)
        {
            if (customer_id_textbox.Text == "") { return; }
            data_tabControl.SelectedTab = single_data_tabpage;
            new_btn.Enabled = false;
            remove_btn.Enabled = false;
            revise_btn.Enabled = false;
            serch_btn.Enabled = false;
            save_btn.Enabled = true;
            cancel_btn.Enabled = true;

            first_data_btn.Enabled = false;
            up_data_btn.Enabled = false;
            down_data_btn.Enabled = false;
            last_data_btn.Enabled = false;

            IsAllTextEnable(true);
            customer_id_textbox.Enabled=false;
        }
        //按下儲存按鈕
        private void save_btn_Click(object sender, EventArgs e)
        {
            if (customer_id_textbox.Text == "" | customer_name_textbox.Text == "" | customer_address_textbox.Text == "" | customer_telephone_textbox.Text == "" | bill_form_comboBox.Text == "" | collect_money_comboBox.Text == "" | area_id_comboBox.Text =="" | remain_textbox.Text =="" | bucket_textBox.Text == "" | old_remain_textbox.Text == "" | old_bucket_textbox.Text == "")
            {
                MessageBox.Show("資料輸入不完整");
                return;
            }

            if (customer_id_textbox.Enabled == false)
            {
                if (customer_name_textbox.Enabled == false)
                {
                    //客戶編號跟名稱都不能使用，所以是按下新增地址
                    string customser_id_mark = customer_id_textbox.Text;
                    int selectIndex = custAdd_listview.Items.Count;
                    string customr_id = customser_id_mark + "-" + selectIndex.ToString();

                    string insertQuery =
                        "INSERT INTO customer VALUES " +
                        $"('{customr_id}'," +
                        $"'{GetCustomer().Name}'," +
                        $"'{GetCustomer().Address}'," +
                        $"'{GetCustomer().ContactPerson}'," +
                        $"'{GetCustomer().Phone}'," +
                        $"'{GetCustomer().Telephone}'," +
                        $"'{GetCustomer().BillForm}'," +
                        $"'{GetCustomer().Invoice}'," +
                        $"'{GetCustomer().BillAddress}', " +
                        $"'{GetCustomer().CollectMoney}'," +
                        $"'{GetCustomer().Bucket}'," +
                        $"'{GetCustomer().Remain}'," +
                        $"'{GetCustomer().Area_id}'," +
                        $"'{GetCustomer().Area_id_2}'," +
                        $"'{GetCustomer().Company}'," +
                        $"'{GetCustomer().Remark}'," +
                        $"'{GetCustomer().CustomerIDMark}'," +
                        $"'{GetCustomer().OldRemain}'," +
                        $"'{GetCustomer().OldBucket}'," +
                        $"'{GetCustomer().AddDay}')";
                    if (ConnectDatabase("新增", insertQuery).ToString() == "1")
                    {
                        MessageBox.Show(GetCustomer().Name + "：檔案新增成功");
                        AllTextClear();
                        InputClientDataToSingleTap(customser_id_mark);
                    }
                    else if (ConnectDatabase("新增", insertQuery).ToString() == "-1")
                    { MessageBox.Show(GetCustomer().Id + "：編號已被註冊，請改用其他編號！"); }
                    else
                    { MessageBox.Show(ConnectDatabase("新增", insertQuery).ToString()); }
                }
                else
                {
                    //客戶編號不能使用，所以是按下修改按鈕
                    string customer_id = "";
                    if (custAdd_listview.SelectedItems.Count == 0)
                    {
                        customer_id = customer_id_textbox.Text;
                    }
                    else
                    {
                        string selectIndex = custAdd_listview.SelectedItems[0].SubItems[0].Text;
                        customer_id = selectIndex == "1" ? customer_id_textbox.Text : customer_id_textbox.Text + "-" + (int.Parse(selectIndex) - 1).ToString();
                    }
                    string reviseQuery =
                    "UPDATE customer SET " +
                    $"customer_name = '{GetCustomer().Name}', " +
                    $"customer_address = '{GetCustomer().Address}', " +
                    $"contact_person = '{GetCustomer().ContactPerson}', " +
                    $"customer_phone = '{GetCustomer().Phone}', " +
                    $"customer_telephone = '{GetCustomer().Telephone}', " +
                    $"customer_bill_form = '{GetCustomer().BillForm}', " +
                    $"customer_invoice = '{GetCustomer().Invoice}', " +
                    $"customer_bill_address = '{GetCustomer().BillAddress}', " +
                    $"customer_collect_money = '{GetCustomer().CollectMoney}', " +
                    $"customer_bucket = '{GetCustomer().Bucket}', " +
                    $"customer_remain = '{GetCustomer().Remain}', " +
                    $"area_id = '{GetCustomer().Area_id}', " +
                    $"area_id_2 = '{GetCustomer().Area_id_2}', " +
                    $"company = '{GetCustomer().Company}', " +
                    $"customer_remark = '{GetCustomer().Remark}', " +
                    $"old_remain = '{GetCustomer().OldRemain}', " +
                    $"old_remain = '{GetCustomer().OldBucket}', " +
                    $"add_day = '{GetCustomer().AddDay}' " +
                    $"WHERE customer_id = '{customer_id}'";
                    if (ConnectDatabase("修改", reviseQuery).ToString() == "1")
                    {
                        MessageBox.Show(GetCustomer().Name + "：檔案修改成功");
                    }
                    else
                    { MessageBox.Show("檔案修改失敗"); }
                }
            }
            else if (customer_id_textbox.Enabled == true)
            {
                //客戶編號可以使用，所以是按下新增按鈕
                string insertQuery =
                "INSERT INTO customer VALUES " +
                $"('{GetCustomer().Id}'," +
                $"'{GetCustomer().Name}'," +
                $"'{GetCustomer().Address}'," +
                $"'{GetCustomer().ContactPerson}'," +
                $"'{GetCustomer().Phone}'," +
                $"'{GetCustomer().Telephone}'," +
                $"'{GetCustomer().BillForm}'," +
                $"'{GetCustomer().Invoice}'," +
                $"'{GetCustomer().BillAddress}', "+
                $"'{GetCustomer().CollectMoney}'," +
                $"'{GetCustomer().Bucket}',"+
                $"'{GetCustomer().Remain}'," +
                $"'{GetCustomer().Area_id}'," +
                $"'{GetCustomer().Area_id_2}'," +
                $"'{GetCustomer().Company}'," +
                $"'{GetCustomer().Remark}'," +
                $"'{GetCustomer().CustomerIDMark}'," +
                $"'{GetCustomer().OldRemain}'," +
                $"'{GetCustomer().OldBucket}'," +
                $"'{GetCustomer().AddDay}')";
                if (ConnectDatabase("新增", insertQuery).ToString() == "1")
                {
                    MessageBox.Show(GetCustomer().Name + "：檔案新增成功");
                    AllTextClear();
                    InputLastClientDataToSingleTap();
                }
                else if (ConnectDatabase("新增", insertQuery).ToString() == "-1")
                { MessageBox.Show(GetCustomer().Id + "：編號已被註冊，請改用其他編號！"); }
                else
                { MessageBox.Show(ConnectDatabase("新增", insertQuery).ToString()); }
            }
            new_btn.Enabled = true;
            revise_btn.Enabled=true;
            remove_btn.Enabled=true;
            serch_btn.Enabled=true;
            save_btn.Enabled=false;
            cancel_btn.Enabled=false;

            first_data_btn.Enabled = true;
            up_data_btn.Enabled = true;
            down_data_btn.Enabled = true;
            last_data_btn.Enabled = true;

            InputClientDataToSingleTap(customer_id_textbox.Text);
            IsAllTextEnable(false);

        }
        //按下取消按鈕
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            AllTextClear();
            IsAllTextEnable(false);
            new_btn.Enabled = true;
            revise_btn.Enabled = true;
            remove_btn.Enabled = true;
            serch_btn.Enabled = true;
            save_btn.Enabled = false;
            cancel_btn.Enabled = false;

            first_data_btn.Enabled = true;
            up_data_btn.Enabled = true;
            down_data_btn.Enabled = true;
            last_data_btn.Enabled = true;
            InputLastClientDataToSingleTap();
        }
        //按下查詢按鈕
        private string strValue;
        public string StrValue
        {
            set
            {
                strValue = value;
            }
        }
        private void serch_btn_Click(object sender, EventArgs e)
        {
            CustomerSearchForm mainForm = new CustomerSearchForm("CustomerDataForm","");
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog(); 
            data_tabControl.SelectedIndex = 0;

            if (strValue == "") { return; }

            InputClientDataToSingleTap(strValue.Contains("-") ? strValue.Split('-')[0] : strValue);//顯示返回的值  
        }

        private void data_tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (data_tabControl.SelectedIndex == 1)
            {
                //滑鼠點擊全部資料的頁面時去資料庫調資料
                string selectQuery = "SELECT * FROM customer";
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
                    InputLastClientDataToSingleTap();
                }
                else
                {
                    string id = alldata_listview.SelectedItems[0].SubItems[0].Text;
                    InputClientDataToSingleTap(id.Contains("-") ? id.Substring(0, 6) : id);
                }
            }
        }
        //按下首筆按鈕
        private void first_data_btn_Click(object sender, EventArgs e)
        {
            ChangeData(sender);
        }
        //按下上筆按鈕
        private void up_data_btn_Click(object sender, EventArgs e)
        {
            ChangeData(sender);
        }
        //按下下筆按鈕
        private void down_data_btn_Click(object sender, EventArgs e)
        {
            ChangeData(sender);
        }
        //按下末筆按鈕
        private void last_data_btn_Click(object sender, EventArgs e)
        {
            ChangeData(sender);
        }

        private void custAdd_listview_MouseClick(object sender, MouseEventArgs e)
        {
            if (custAdd_listview.SelectedItems.Count == 0) {return;}
            string customer_id_mark = customer_id_textbox.Text;
            string index = (int.Parse(custAdd_listview.SelectedItems[0].SubItems[0].Text) - 1).ToString();
            string customer_id = index == "0" ? customer_id_mark : customer_id_mark + "-" + index;
            string selectQuery = "SELECT * FROM customer " +
                $"WHERE customer_id = '{customer_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows.Count != 0)
            {
                customer_id_textbox.Text = datatable.Rows[0][16].ToString();
                customer_name_textbox.Text = datatable.Rows[0][1].ToString();
                customer_address_textbox.Text = datatable.Rows[0][2].ToString();
                contact_person_textbox.Text = datatable.Rows[0][3].ToString();
                customer_phone_textbox.Text = datatable.Rows[0][4].ToString();
                customer_telephone_textbox.Text = datatable.Rows[0][5].ToString();
                bill_form_comboBox.Text = datatable.Rows[0][6].ToString();
                customer_invoice_textbox.Text = datatable.Rows[0][7].ToString();
                customer_bill_address_textbox.Text = datatable.Rows[0][8].ToString();
                collect_money_comboBox.Text = datatable.Rows[0][9].ToString();
                bucket_textBox.Text = datatable.Rows[0][10].ToString();
                remain_textbox.Text = datatable.Rows[0][11].ToString();
                area_id_comboBox.Text = getAreaNameOrID("id", datatable.Rows[0][12].ToString());
                area_id_2_comboBox.Text = getAreaNameOrID("id", datatable.Rows[0][13].ToString());
                company_comboBox.Text = datatable.Rows[0][14].ToString();
                customer_remark_textBox.Text = datatable.Rows[0][15].ToString();
                old_remain_textbox.Text = datatable.Rows[0][17].ToString();
                old_bucket_textbox.Text = datatable.Rows[0][18].ToString();
                dateTimePicker.Value = DateTime.Parse(datatable.Rows[0][19].ToString());
            }
        }

        private void new_add_btn_Click(object sender, EventArgs e)
        {
            if (customer_id_textbox.Text == "") { return; }
            data_tabControl.SelectedTab = single_data_tabpage;
            new_btn.Enabled = false;
            remove_btn.Enabled = false;
            revise_btn.Enabled = false;
            serch_btn.Enabled = false;
            save_btn.Enabled = true;
            cancel_btn.Enabled = true;

            first_data_btn.Enabled = false;
            up_data_btn.Enabled = false;
            down_data_btn.Enabled = false;
            last_data_btn.Enabled = false;

            IsAllTextEnable(true);
            customer_id_textbox.Enabled = false;
            customer_name_textbox.Enabled = false;

            customer_address_textbox.Text = "";
        }

        private void remove_add_btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("如果輸入錯誤資料，請聯絡MIS工程師，請勿輕易刪除資料!");
            return;

            if (custAdd_listview.SelectedItems.Count == 0) {  return; }
            string customer_id_mark = customer_id_textbox.Text;
            int selectIndex = custAdd_listview.SelectedItems[0].Index;
            string customer_id = selectIndex == 0 ? customer_id_mark : customer_id_mark + "-" + selectIndex.ToString();

            DialogResult result = MessageBox.Show("確定要刪除這筆地址的資料嗎", "注意", MessageBoxButtons.YesNoCancel);

            switch (result)
            {
                case DialogResult.Yes:
                    string removeQuery =
                    "DELETE FROM customer WHERE " +
                    $"customer_id = '{customer_id}'";
                    string anser = ConnectDatabase("刪除", removeQuery).ToString();
                    if (anser == "-1")
                    {
                        MessageBox.Show("檔案刪除失敗");
                    }
                    else
                    {
                        MessageBox.Show(GetCustomer().Name + "：檔案刪除成功");
                        InputClientDataToSingleTap(customer_id_mark);
                    }
                    break;
                case DialogResult.No:

                    break;
                case DialogResult.Cancel:

                    break;
                default:
                    break;
            }
        }

        private void custAdd_tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (custAdd_tabControl.SelectedIndex == 1)
            {
                updateRemainOrderListView(customer_id_textbox.Text);
            }
        }

        private void map_btn_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReviceCustomerArea mainForm = new ReviceCustomerArea();
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
        }

        private void CustomerDataForm_Resize(object sender, EventArgs e)
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

            int totalWidth1 = custAdd_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth1 > 0)
            {
                custAdd_listview.Columns[0].Width = (int)(totalWidth1 * 0.0336); // 第一欄占 30%
                custAdd_listview.Columns[1].Width = (int)(totalWidth1 * 0.5050); // 第二欄占 30%
                custAdd_listview.Columns[2].Width = (int)(totalWidth1 * 0.1262); // 第三欄占 40%
                custAdd_listview.Columns[3].Width = (int)(totalWidth1 * 0.1262); // 第一欄占 30%
                custAdd_listview.Columns[4].Width = (int)(totalWidth1 * 0.2525); // 第二欄占 30%
            }

            int totalWidth2 = remain_order_ListView.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth2 > 0)
            {
                remain_order_ListView.Columns[0].Width = (int)(totalWidth2 * 0.1094); // 第一欄占 30%
                remain_order_ListView.Columns[1].Width = (int)(totalWidth2 * 0.0841); // 第二欄占 30%
                remain_order_ListView.Columns[2].Width = (int)(totalWidth2 * 0.1010); // 第三欄占 40%
                remain_order_ListView.Columns[3].Width = (int)(totalWidth2 * 0.0673); // 第一欄占 30%
                remain_order_ListView.Columns[4].Width = (int)(totalWidth2 * 0.0673); // 第二欄占 30%
                remain_order_ListView.Columns[5].Width = (int)(totalWidth2 * 0.0673); // 第一欄占 30%
                remain_order_ListView.Columns[6].Width = (int)(totalWidth2 * 0.2525); // 第二欄占 30%
            }
        }
    }
}
