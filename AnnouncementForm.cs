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
    public partial class AnnouncementForm : Form
    {
        public AnnouncementForm()
        {
            InitializeComponent();
            updateAnnouncement_listview();
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

        private string newAnnouncementID()
        {
            string selectQuery = "SELECT announcement_id FROM `announcement` " +
                "ORDER BY announcement_id DESC LIMIT 0 , 1";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            var day = DateTime.Now.ToString("yyyy-MM-dd");
            if (datatable.Rows.Count == 0)
            {
                return day.Replace("-", "") + "0001"; 
            }
            var order_id = datatable.Rows[0][0].ToString();
            if (order_id.Substring(0, 8) == day.Replace("-", ""))
            {
                return (long.Parse(order_id) + 1).ToString();
            }
            else
            {
                return day.Replace("-", "") + "0001";
            }
        }

        private void updateAnnouncement_listview()
        {
            string selectQuery = "SELECT * FROM `announcement` " +
                    "ORDER BY announcement_id DESC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            announcement_listview.Items.Clear();
            foreach (DataRow announcement in datatable.Rows)
            {
                ListViewItem item = new ListViewItem(announcement[0].ToString());//公告編號
                item.SubItems.Add(announcement[1].ToString().Split(' ')[0]);//公告日期
                item.SubItems.Add(announcement[2].ToString());//公告標題
                if (announcement[4].ToString() == "True")
                {
                    item.SubItems.Add("使用中");//公告使用
                }
                else
                {
                    item.SubItems.Add("");//公告使用
                }

                announcement_listview.Items.Add(item);
            };

        }

        private Announcement GetAnnouncement()
        {
            string ann_id = newAnnouncementID();
            string ann_day = DateTime.Now.ToString("yyyy-MM-dd");
            string ann_title = title_textBox.Text;
            string ann_content = content_textBox.Text;
            string ann_using = "True";

            Announcement announcement = new Announcement(ann_id, ann_day, ann_title, ann_content, ann_using);
            return announcement;
        }

        private void allUsingToFalse(string announcement_id)
        {
            string reviseQuery =
                "UPDATE announcement SET " +
                "announcement_using = 'False'";
            ConnectDatabase("修改", reviseQuery);
            if (announcement_id != "")
            {
                string reviseQuery2 =
                    "UPDATE announcement SET " +
                    $"announcement_using = 'True' WHERE announcement_id = {announcement_id}";
                ConnectDatabase("修改", reviseQuery2);
            }
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            if (title_textBox.Text == "")
            {
                MessageBox.Show("資料輸入不完整");
                return;
            }
            allUsingToFalse("");
            string insertQuery =
            "INSERT INTO announcement VALUES " +
            $"('{GetAnnouncement().Id}'," +
            $"'{GetAnnouncement().Day}'," +
            $"'{GetAnnouncement().Title}'," +
            $"'{GetAnnouncement().Content}'," +
            $"'{GetAnnouncement().AnnUsing}')";
            if (ConnectDatabase("新增", insertQuery).ToString() == "1")
            {
                MessageBox.Show(GetAnnouncement().Title + "：新增成功");
            }else
            { MessageBox.Show(ConnectDatabase("新增", insertQuery).ToString()); }

            updateAnnouncement_listview();
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            if (announcement_listview.SelectedItems.Count == 0) { return; }
            var announcement_id = announcement_listview.SelectedItems[0].SubItems[0].Text;
            allUsingToFalse(announcement_id);
            updateAnnouncement_listview();
        }

        private void announcement_listview_Click(object sender, EventArgs e)
        {
            title_textBox.Text = "";
            content_textBox.Text = "";
            var announcement_id = announcement_listview.SelectedItems[0].SubItems[0].Text;
            string selectQuery = "SELECT * FROM `announcement` " +
                $"WHERE announcement_id = '{announcement_id}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            title_textBox.Text = datatable.Rows[0][2].ToString();
            content_textBox.Text = datatable.Rows[0][3].ToString();
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            if (announcement_listview.SelectedItems.Count == 0) { return; }

            var announcement_id = announcement_listview.SelectedItems[0].SubItems[0].Text;
            string removeQuery =
                "DELETE FROM announcement WHERE " +
                $"announcement_id = '{announcement_id}'";
            ConnectDatabase("刪除", removeQuery);
            title_textBox.Text = "";
            content_textBox.Text = "";
            updateAnnouncement_listview();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AnnouncementForm_Resize(object sender, EventArgs e)
        {
            int totalWidth = announcement_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                announcement_listview.Columns[0].Width = (int)(totalWidth * 0); // 第一欄占 30%
                announcement_listview.Columns[1].Width = (int)(totalWidth * 0.2638); // 第二欄占 30%
                announcement_listview.Columns[2].Width = (int)(totalWidth * 0.5277); // 第三欄占 40%
                announcement_listview.Columns[3].Width = (int)(totalWidth * 0.1583); // 第一欄占 30%
            }
        }
    }
}
