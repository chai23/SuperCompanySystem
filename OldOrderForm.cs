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
    public partial class OldOrderForm : Form
    {
        public OldOrderForm(string customer_id)
        {
            InitializeComponent();
            Customer_id = customer_id;
            getOldOrder();
        }

        private string Customer_id {  get; set; }

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

        private void getOldOrder()
        {
            string selectQuery = "SELECT * FROM `old_order` " +
                $"WHERE customer_id = '{Customer_id}' " +
                "ORDER BY order_day DESC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            order_listview.Items.Clear();

            foreach (DataRow order in datatable.Rows)
            {
                ListViewItem item = new ListViewItem(order[0].ToString());
                item.SubItems.Add(order[1].ToString().Split(' ')[0]);
                for (int i = 2; i< datatable.Columns.Count; i++)
                {
                    item.SubItems.Add(order[i].ToString());
                }
                order_listview.Items.Add(item);
            }
        }

        private void OldOrderForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = order_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                order_listview.Columns[0].Width = (int)(totalWidth * 0.1108); // 第一欄占 30%
                order_listview.Columns[1].Width = (int)(totalWidth * 0.0937); // 第二欄占 30%
                order_listview.Columns[2].Width = (int)(totalWidth * 0.0255); // 第三欄占 40%
                order_listview.Columns[3].Width = (int)(totalWidth * 0.0426); // 第一欄占 30%
                order_listview.Columns[4].Width = (int)(totalWidth * 0.1278); // 第二欄占 30%
                order_listview.Columns[5].Width = (int)(totalWidth * 0.0426); // 第三欄占 40%
                order_listview.Columns[6].Width = (int)(totalWidth * 0.0426); // 第三欄占 40%
                order_listview.Columns[7].Width = (int)(totalWidth * 0.0426); // 第三欄占 40%
                order_listview.Columns[8].Width = (int)(totalWidth * 0.0596); // 第一欄占 30%
                order_listview.Columns[9].Width = (int)(totalWidth * 0.1705); // 第二欄占 30%
                order_listview.Columns[10].Width = (int)(totalWidth * 0.0767); // 第三欄占 40%
                order_listview.Columns[11].Width = (int)(totalWidth * 0.0682); // 第三欄占 40%
                order_listview.Columns[12].Width = (int)(totalWidth * 0.0682); // 第三欄占 40%
            }
        }
    }
}
