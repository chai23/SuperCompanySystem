using Mysqlx.Crud;
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
    public partial class ProductSearchForm : Form
    {
        public ProductSearchForm(string customer_id)
        {
            InitializeComponent();
            Customer_id = customer_id;
            getProductData();
        }

        private string Customer_id { get; set; }

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

        private void getProductData()
        {
            string selectQuery = "SELECT o1.product_id, o1.product_name, o1.product_price "+
                "FROM `order` as o1 " +
                "INNER JOIN(SELECT product_name, max(order_day) as order_day " +
                    "FROM `order` "+
                    $"WHERE customer_id = '{Customer_id}' and product_id > 1 and product_id < 201 " +
                    "GROUP BY  product_name) as o2 "+
                 "on o1.product_name = o2.product_name " +
                 "AND o1.order_day = o2.order_day "+
                $"WHERE o1.customer_id = '{Customer_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            Console.WriteLine(selectQuery);
            alldata_listview.Items.Clear();

            foreach (DataRow product in datatable.Rows)
            {
                ListViewItem item = new ListViewItem(product[0].ToString());
                item.SubItems.Add(product[1].ToString());
                item.SubItems.Add(product[2].ToString());
                alldata_listview.Items.Add(item);
            }
        }

        private void alldata_listview_DoubleClick(object sender, EventArgs e)
        {
            var product_id = alldata_listview.SelectedItems[0].SubItems[0].Text;
            var product_price = alldata_listview.SelectedItems[0].SubItems[2].Text;
            OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.StrValue = product_id;//使用父窗口指針賦值  
            ChileForm.ProductPrice = product_price;
            this.Close();
        }

        private void alldata_listview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && alldata_listview.SelectedItems.Count > 0)
            {
                var product_id = alldata_listview.SelectedItems[0].SubItems[0].Text;
                var product_price = alldata_listview.SelectedItems[0].SubItems[2].Text;
                OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
                ChileForm.StrValue = product_id;//使用父窗口指針賦值  
                ChileForm.ProductPrice = product_price;
                this.Close();
            }
        }

        private void customer_product_btn_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT o1.product_id, o1.product_name, o1.product_price " +
                "FROM `order` o1 " +
                "INNER JOIN(SELECT product_id, max(order_day) as order_day " +
                    "FROM `order` " +
                    $"WHERE customer_id = '{Customer_id}' " +
                    "GROUP BY product_id, product_name) o2 " +
                 "on o1.product_id = o2.product_id " +
                 "AND o1.order_day = o2.order_day " +
                $"WHERE o1.customer_id = '{Customer_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            Console.WriteLine(selectQuery);
            alldata_listview.Items.Clear();

            foreach (DataRow product in datatable.Rows)
            {
                ListViewItem item = new ListViewItem(product[0].ToString());
                item.SubItems.Add(product[1].ToString());
                item.SubItems.Add(product[2].ToString());
                alldata_listview.Items.Add(item);
            }
        }

        private void all_product_btn_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM product ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            alldata_listview.Items.Clear();

            foreach (DataRow product in datatable.Rows)
            {
                ListViewItem item = new ListViewItem(product[0].ToString());
                item.SubItems.Add(product[1].ToString());
                item.SubItems.Add("0");
                alldata_listview.Items.Add(item);
            }
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            var product_id = "";
            var product_price = "";
            OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.StrValue = product_id;//使用父窗口指針賦值  
            ChileForm.ProductPrice = product_price;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                var product_id = "";
                var product_price = "";
                OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
                ChileForm.StrValue = product_id;//使用父窗口指針賦值  
                ChileForm.ProductPrice = product_price;
                this.Close();
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ProductSearchForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = alldata_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                alldata_listview.Columns[0].Width = (int)(totalWidth * 0.1636); // 第一欄占 30%
                alldata_listview.Columns[1].Width = (int)(totalWidth * 0.5237); // 第二欄占 30%
                alldata_listview.Columns[2].Width = (int)(totalWidth * 0.1636); // 第三欄占 40%
            }
        }
    }
}
