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
    public partial class WaterdispenserForm : Form
    {
        public WaterdispenserForm()
        {
            InitializeComponent();
            updateWaterDispenser_listview();
            timer1.Start();
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
        private void updateWaterDispenser_listview()
        {
            string selectQuery = "SELECT * FROM `water_dispenser_list` " +
                    "ORDER BY dispenser_id DESC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            water_dispenser_listview.Items.Clear();
            foreach (DataRow dispenser in datatable.Rows)
            {
                ListViewItem item = new ListViewItem(dispenser[0].ToString());//維修單編號
                item.SubItems.Add(dispenser[1].ToString());//客戶編號
                item.SubItems.Add(dispenser[2].ToString());//客戶名稱
                item.SubItems.Add(dispenser[3].ToString());//桌(廠牌)
                item.SubItems.Add(dispenser[4].ToString());//立(廠牌)
                item.SubItems.Add(dispenser[5].ToString());//清洗
                item.SubItems.Add(dispenser[6].ToString());//維修
                item.SubItems.Add(dispenser[7].ToString().Split(' ')[0]);//日期
                item.SubItems.Add(dispenser[8].ToString().Split(' ')[0]);//送回
                item.SubItems.Add(dispenser[9].ToString().Split(' ')[0]);//收錢
                item.SubItems.Add(dispenser[10].ToString());//司機

                water_dispenser_listview.Items.Add(item);
            };

        }
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void WaterdispenserForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void Insert_btn_Click(object sender, EventArgs e)
        {
            UpdateWaterdispenserForm mainForm = new UpdateWaterdispenserForm();
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
            updateWaterDispenser_listview();
        }

        private void revise_btn_Click(object sender, EventArgs e)
        {
            if (water_dispenser_listview.SelectedItems.Count == 0) {  return; }
            string dispenser_id = water_dispenser_listview.SelectedItems[0].SubItems[0].Text;
            UpdateWaterdispenserForm mainForm = new UpdateWaterdispenserForm(dispenser_id);
            mainForm.Owner = this;//重要的一步，主要是使Form2的Owner指針指向Form1  
            mainForm.ShowDialog();
            updateWaterDispenser_listview();
        }

        private void WaterdispenserForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = water_dispenser_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                water_dispenser_listview.Columns[0].Width = (int)(totalWidth * 0.0969); // 第一欄占 30%
                water_dispenser_listview.Columns[1].Width = (int)(totalWidth * 0.0872); // 第二欄占 30%
                water_dispenser_listview.Columns[2].Width = (int)(totalWidth * 0.1163); // 第三欄占 40%
                water_dispenser_listview.Columns[3].Width = (int)(totalWidth * 0.0775); // 第一欄占 30%
                water_dispenser_listview.Columns[4].Width = (int)(totalWidth * 0.0775); // 第二欄占 30%
                water_dispenser_listview.Columns[5].Width = (int)(totalWidth * 0.0872); // 第三欄占 40%
                water_dispenser_listview.Columns[6].Width = (int)(totalWidth * 0.0872); // 第一欄占 30%
                water_dispenser_listview.Columns[7].Width = (int)(totalWidth * 0.0872); // 第二欄占 30%
                water_dispenser_listview.Columns[8].Width = (int)(totalWidth * 0.0872); // 第三欄占 40%
                water_dispenser_listview.Columns[9].Width = (int)(totalWidth * 0.0872); // 第一欄占 30%
                water_dispenser_listview.Columns[10].Width = (int)(totalWidth * 0.0775); // 第二欄占 30%
            }
        }
    }
}
