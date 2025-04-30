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
    public partial class UpdateRemarkForm : Form
    {
        public UpdateRemarkForm(string order_id)
        {
            InitializeComponent();
            Order_id = order_id;
        }
        private string Order_id { get; set; }
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
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string reviseQuery2 =
                "UPDATE `order` SET " +
                $"remark = '{remark_textbox.Text}' " +
                $"WHERE order_id = '{Order_id}' " +
                "AND product_index = '1'";
            ConnectDatabase("修改", reviseQuery2);
            this.Close();
        }
    }
}
