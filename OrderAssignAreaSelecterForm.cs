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
    public partial class OrderAssignAreaSelecterForm : Form
    {
        public OrderAssignAreaSelecterForm()
        {
            InitializeComponent();
            getAreaData();
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
        private void getAreaData()
        {
            string selectQuery = "SELECT area_name FROM area ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable == null) { return; }
            if (datatable != null & datatable.Rows.Count != 0)
            {
                area_checkedListBox.Items.Clear();

                foreach (DataRow row in datatable.Rows)
                {
                    area_checkedListBox.Items.Add(row[0].ToString());
                }
            }
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            ArrayList season = new ArrayList();
            for (int i = 0; i < area_checkedListBox.Items.Count; i++)
            {
                if (area_checkedListBox.GetItemChecked(i))
                {
                    season.Add(area_checkedListBox.GetItemText(area_checkedListBox.Items[i]));
                }
            }
            OrderAssignFormBeBe ChileForm = (OrderAssignFormBeBe)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.ArrValue = season;//使用父窗口指針賦值  
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            ArrayList season = new ArrayList();
            OrderAssignFormBeBe ChileForm = (OrderAssignFormBeBe)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.ArrValue = season;//使用父窗口指針賦值  
            this.Close();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }
    }
}
