using Google.Protobuf;
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
    public partial class OrderDataReviseForm : Form
    {
        public OrderDataReviseForm(string order_id)
        {
            InitializeComponent();
            SearchOrderData(order_id);
        }
        public OrderDataReviseForm(string order_id, string orderSearch)
        {
            InitializeComponent();
            SearchOrderData(order_id);
            if(orderSearch == "orderSearch")
            {
                order_dataGridView.Enabled = false;
                cancel_btn.Text = "離開";
                order_save_btn.Visible = false;
            }
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
        private void SearchOrderData(string order_id)
        {
            string selectQuery = "SELECT customer_id, product_index, product_id, product_name, product_price, product_quantity, give_free, give_nofree, collect_money, customer_bill_form, tex, subtotal, remark, bill_number FROM `order` " +
                $"WHERE order_id = '{order_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            foreach (DataRow order in datatable.Rows)
            {
                DataGridViewRow row = (DataGridViewRow)order_dataGridView.Rows[0].Clone();
                row.Cells[0].Value = order[1].ToString(); //序
                row.Cells[1].Value = order[2].ToString(); //商品ID
                row.Cells[2].Value = order[3].ToString(); //商品名稱
                row.Cells[3].Value = order[4].ToString(); //商品價格
                row.Cells[4].Value = order[5].ToString(); //商品數量
                row.Cells[5].Value = order[6].ToString(); //補送
                row.Cells[6].Value = order[7].ToString(); //抵扣
                row.Cells[7].Value = order[8].ToString(); //扣單別
                row.Cells[8].Value = order[9].ToString(); //發票
                row.Cells[9].Value = order[10].ToString(); //稅金
                row.Cells[10].Value = order[11].ToString(); //小計
                row.Cells[11].Value = order[12].ToString(); // 備註
                order_dataGridView.Rows.Add(row);
            }

            string selectQuery1 = "SELECT customer_name, customer_address, customer_invoice, customer_telephone FROM `customer` " +
                $"WHERE customer_id = '{datatable.Rows[0][0].ToString()}'";
            DataTable datatable1 = ConnectDatabase("查詢", selectQuery1) as DataTable;

            order_id_textbox.Text = order_id;
            customer_id_textBox.Text = datatable.Rows[0][0].ToString();
            customer_name_textbox.Text = datatable1.Rows[0][0].ToString();
            customer_address_textbox.Text = datatable1.Rows[0][1].ToString();
            customer_invoice_textbox.Text = datatable1.Rows[0][2].ToString();
            customer_telephone_textbox.Text = datatable1.Rows[0][3].ToString();
            bill_number_textBox.Text = datatable.Rows[0][11].ToString();

            var total = 0;
            var tex = 0;
            for (int i = 0; i <= datatable.Rows.Count-1; i++)
            {
                tex = tex + int.Parse(order_dataGridView.Rows[i].Cells[9].Value.ToString());
                total = total + int.Parse(order_dataGridView.Rows[i].Cells[10].Value.ToString());
            }

            tex_textBox.Text = tex.ToString();
            total_textBox.Text = total.ToString();

            string selectQuery2 = "SELECT deliver_day FROM `driver_order` " +
                $"WHERE order_id = '{order_id}'";
            DataTable datatable2 = ConnectDatabase("查詢", selectQuery2) as DataTable;
            if (datatable2.Rows.Count == 0 || datatable2 == null)
            {
                deliver_day_dtp.Visible = false;
                deliver_day_label.Text = "送貨日期：尚未派單";
            }
            else
            {
                DateTime dt = Convert.ToDateTime(datatable2.Rows[0][0].ToString());
                deliver_day_dtp.Value = dt;
            }

        }
        private bool getIsJoinReserve(string product_id)
        {
            string selectQuery = "SELECT is_join_reserve FROM product " +
                $"WHERE product_id = '{product_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count > 0)
            {
                return Convert.ToBoolean(datatable.Rows[0][0]);
            }
            else
            {
                return false;
            }
        }
        private bool getIsJoinTex(string product_id)
        {
            string selectQuery = "SELECT is_join_tex FROM product " +
                $"WHERE product_id = '{product_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            if (datatable.Rows.Count > 0)
            {
                return Convert.ToBoolean(datatable.Rows[0][0]);
            }
            else
            {
                return false;
            }
        }
        private string getCustomerBillFormFromOrderID(string order_id)
        {
            string selectQuery = "SELECT customer_bill_form FROM `order` " +
                $"WHERE order_id = '{order_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            return datatable.Rows[0][0].ToString();
        }
        private bool getIsGiveNoFree(string order_id, string product_index)
        {
            bool isTrue = false;
            string selectQuery = "SELECT collect_money, give_nofree, give_free FROM `order` " +
                $"WHERE order_id = '{order_id}' AND product_index = '{product_index}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable.Rows[0][0].ToString() == "預收")
            {
                if(datatable.Rows[0][1].ToString() == "True" & datatable.Rows[0][2].ToString() == "False")
                {//預收送水
                    isTrue = true;
                }
                else if (datatable.Rows[0][1].ToString() == "True" & datatable.Rows[0][2].ToString() == "True")
                {//破水補送
                    isTrue = true;
                }
                else if (datatable.Rows[0][1].ToString() == "False" & datatable.Rows[0][2].ToString() == "False")
                {//預收儲值

                }
                else if (datatable.Rows[0][1].ToString() == "False" & datatable.Rows[0][2].ToString() == "True")
                {//儲值贈送

                }
            }
            else
            {
                isTrue = true;
            }

            return isTrue;
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void order_dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            if (cancel_btn.Text == "離開") {  return; }
            if (e.ColumnIndex == 4 || e.ColumnIndex == 3 || e.ColumnIndex ==8)
            {
                if (order_dataGridView.Rows[e.RowIndex].Cells[3].Value == null | order_dataGridView.Rows[e.RowIndex].Cells[4].Value == null) { return; }

                var product_id = order_dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                var price_value = order_dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                var quantity_value = order_dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                var customer_bill_form = order_dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                try
                {
                    double product_price = double.Parse(price_value);
                    int product_quantity = int.Parse(quantity_value);
                    int subtex = 0;
                    int subtotal = 0;
                    if (getIsJoinTex(product_id) == false | customer_bill_form == "不開")
                    {
                        subtex = 0;
                        subtotal = int.Parse(Math.Round(product_price * product_quantity + subtex).ToString());
                    }
                    else if (customer_bill_form == "三聯未稅")
                    {
                        double ssubtotal = Math.Round(product_price * product_quantity * 1.05, 0, MidpointRounding.AwayFromZero);
                        subtex = int.Parse(Math.Round(ssubtotal / 1.05 * 0.05, 0, MidpointRounding.AwayFromZero).ToString()); //四捨五入
                        subtotal = int.Parse(Math.Round(ssubtotal).ToString());
                    }
                    else if (customer_bill_form == "三聯含稅" | customer_bill_form == "二聯含稅")
                    {
                        subtex = int.Parse(Math.Round((product_price * product_quantity) / 1.05 * 0.05, 0, MidpointRounding.AwayFromZero).ToString()); // 四捨五入
                        subtotal = int.Parse(Math.Round(product_price * product_quantity).ToString());
                    }

                    if (order_dataGridView.Rows[e.RowIndex].Cells[5].Value != null)
                    {
                        if (order_dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString() == "True")
                        {
                            subtex = 0;
                            subtotal = 0;
                        }
                    }
                    if (order_dataGridView.Rows[e.RowIndex].Cells[6].Value != null)
                    {
                        if (order_dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString() == "True")
                        {
                            subtex = 0;
                            subtotal = 0;
                        }
                    }
                    order_dataGridView.Rows[e.RowIndex].Cells[9].Value = subtex.ToString();
                    order_dataGridView.Rows[e.RowIndex].Cells[10].Value = subtotal.ToString();
                    var total = 0;
                    var tex = 0;
                    for (int i = 0; i <= e.RowIndex; i++)
                    {
                        tex = tex + int.Parse(order_dataGridView.Rows[i].Cells[9].Value.ToString());
                        total = total + int.Parse(order_dataGridView.Rows[i].Cells[10].Value.ToString());
                    }

                    tex_textBox.Text = tex.ToString();
                    total_textBox.Text = total.ToString();
                }
                catch
                {
                    //轉型失敗  
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void order_save_btn_Click(object sender, EventArgs e)
        {
            string order_id = order_id_textbox.Text;
            int totalQuantity = 0;

            for (int i = 0;i < order_dataGridView.Rows.Count - 1; i++)
            {
                string reviseQuery =
                    "UPDATE `order` SET " +
                    $"product_price = '{order_dataGridView.Rows[i].Cells[3].Value}', " +
                    $"product_quantity = '{order_dataGridView.Rows[i].Cells[4].Value}', " +
                    $"tex = '{order_dataGridView.Rows[i].Cells[9].Value}', " +
                    $"subtotal = '{order_dataGridView.Rows[i].Cells[10].Value}', " +
                    $"customer_bill_form = '{order_dataGridView.Rows[i].Cells[8].Value}' " +
                    $"WHERE order_id = '{order_id}' " +
                    $"AND product_index = '{i+1}'";
                string result =  ConnectDatabase("修改", reviseQuery).ToString();

                if (result == "-1")
                {
                    MessageBox.Show("訂單修改失敗！");
                    return;
                }

                if (getIsJoinReserve(order_dataGridView.Rows[i].Cells[1].Value.ToString()) & int.Parse(order_dataGridView.Rows[i].Cells[1].Value.ToString()) < 201)
                {
                    if (getIsGiveNoFree(order_id, (i+1).ToString()))
                    {
                        totalQuantity = totalQuantity + int.Parse(order_dataGridView.Rows[i].Cells[4].Value.ToString());
                    }
                }
            }

            string reviseQuery1 =
                "UPDATE `driver_order` SET " +
                $"order_quantity = '{totalQuantity}' " +
                $"WHERE order_id = '{order_id}' ";
            string result1 = ConnectDatabase("修改", reviseQuery1).ToString();
            if (result1 == "-1")
            {
                MessageBox.Show("訂單修改失敗！");
                return;
            }

            MessageBox.Show("訂單修改完成！");
            this.Close();
        }

        private void OrderDataReviseForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = order_dataGridView.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                order_dataGridView.Columns[0].Width = (int)(totalWidth * 0.0258); // 第一欄占 30%
                order_dataGridView.Columns[1].Width = (int)(totalWidth * 0.1076); // 第二欄占 30%
                order_dataGridView.Columns[2].Width = (int)(totalWidth * 0.1722); // 第三欄占 40%
                order_dataGridView.Columns[3].Width = (int)(totalWidth * 0.0602); // 第一欄占 30%
                order_dataGridView.Columns[4].Width = (int)(totalWidth * 0.0602); // 第二欄占 30%
                order_dataGridView.Columns[5].Width = (int)(totalWidth * 0.0602); // 第三欄占 40%
                order_dataGridView.Columns[6].Width = (int)(totalWidth * 0.0602); // 第三欄占 40%
                order_dataGridView.Columns[7].Width = (int)(totalWidth * 0.0861); // 第三欄占 40%
                order_dataGridView.Columns[8].Width = (int)(totalWidth * 0.0861); // 第一欄占 30%
                order_dataGridView.Columns[9].Width = (int)(totalWidth * 0.0602); // 第二欄占 30%
                order_dataGridView.Columns[10].Width = (int)(totalWidth * 0.0689); // 第三欄占 40%
                order_dataGridView.Columns[11].Width = (int)(totalWidth * 0.3014); // 第三欄占 40%
            }
        }
    }
}
