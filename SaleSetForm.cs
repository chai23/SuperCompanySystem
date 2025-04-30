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
    public partial class SaleSetForm : Form
    {
        public SaleSetForm()
        {
            InitializeComponent();
            updateSaleData();
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

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }
        private void updateSaleData()
        {
            string selectQuery = "SELECT * FROM `sale_set`";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            foreach (DataRow item in datatable.Rows)
            {
                if (item[0].ToString() == "0001")
                {
                    open_btn1.Text = item[2].ToString() == "True" ? "開啟中" : "關閉中";
                    buy_num_textBox.Text = item[3].ToString();
                    free_num_textBox.Text = item[4].ToString();
                }
                else if (item[0].ToString() == "0002")
                {
                    open_btn2.Text = item[2].ToString() == "True" ? "開啟中" : "關閉中";
                    desktop_num1.Text = item[3].ToString();
                    desktop_num2.Text = item[4].ToString();
                    top_num1.Text = item[5].ToString();
                    top_num2.Text = item[6].ToString();
                    down_num1.Text = item[7].ToString();
                    down_num2.Text = item[8].ToString();
                }
                else if (item[0].ToString() == "0003")
                {
                    open_btn3.Text = item[2].ToString() == "True" ? "開啟中" : "關閉中";
                }
                else if (item[0].ToString() == "0004")
                {
                    open_btn4.Text = item[2].ToString() == "True" ? "開啟中" : "關閉中";
                }
             }
        }
        
        private void open_btn1_Click(object sender, EventArgs e)
        {
            if (open_btn1.Text == "開啟中")
            {
                open_btn1.Text = "關閉中";
            }
            else if (open_btn1.Text == "關閉中")
            {
                open_btn1.Text = "開啟中";
            }
        }

        private void open_btn2_Click(object sender, EventArgs e)
        {
            if (open_btn2.Text == "開啟中")
            {
                open_btn2.Text = "關閉中";
            }
            else if (open_btn2.Text == "關閉中")
            {
                open_btn2.Text = "開啟中";
            }
        }

        private void open_btn3_Click(object sender, EventArgs e)
        {
            if (open_btn3.Text == "開啟中")
            {
                open_btn3.Text = "關閉中";
            }
            else if (open_btn3.Text == "關閉中")
            {
                open_btn3.Text = "開啟中";
            }
        }

        private void open_btn4_Click(object sender, EventArgs e)
        {
            if (open_btn4.Text == "開啟中")
            {
                open_btn4.Text = "關閉中";
            }
            else if (open_btn4.Text == "關閉中")
            {
                open_btn4.Text = "開啟中";
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string open1 = open_btn1.Text == "開啟中" ? "True" : "False";
            string open2 = open_btn2.Text == "開啟中" ? "True" : "False";
            string open3 = open_btn3.Text == "開啟中" ? "True" : "False";
            string open4 = open_btn4.Text == "開啟中" ? "True" : "False";

            string reviseQuery =
                "UPDATE `sale_set` SET " +
                $"sale_num1 = '{buy_num_textBox.Text}', " +
                $"sale_num2 = '{free_num_textBox.Text}', " +
                $"sale_is_use = '{open1}' " +
                $"WHERE sale_id = '0001'";
            ConnectDatabase("修改", reviseQuery);

            string reviseQuery1 =
                "UPDATE `sale_set` SET " +
                $"sale_num1 = '{desktop_num1.Text}', " +
                $"sale_num2 = '{desktop_num2.Text}', " +
                $"sale_num3 = '{top_num1.Text}', " +
                $"sale_num4 = '{top_num2.Text}', " +
                $"sale_num5 = '{down_num1.Text}', " +
                $"sale_num6 = '{down_num2.Text}', " +
                $"sale_is_use = '{open2}' " +
                $"WHERE sale_id = '0002'";
            ConnectDatabase("修改", reviseQuery1);

            string reviseQuery2 =
                "UPDATE `sale_set` SET " +
                $"sale_is_use = '{open3}' " +
                $"WHERE sale_id = '0003'";
            ConnectDatabase("修改", reviseQuery2);

            string reviseQuery3 =
                "UPDATE `sale_set` SET " +
                $"sale_is_use = '{open4}' " +
                $"WHERE sale_id = '0004'";
            ConnectDatabase("修改", reviseQuery3);

            this.Close();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
