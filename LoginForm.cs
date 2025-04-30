using System;
using System.Data;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace 超好企業系統
{
    public partial class LoginForm : KryptonForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private object ConnectDatabase()
        {
            // 設定你的MySQL連接字串
            //string connectionString = "Server=125.228.16.160;Database=database;User ID=user;Password=chaaii23;";
            // 建立MySqlDatabase物件
            MySqlHelper mySqlDb = new MySqlHelper();

            string rowsInserted = mySqlDb.TryConnect();
            return rowsInserted;
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

        private void login_btn_Click(object sender, EventArgs e)
        {
            string account_number = acccount_number_textbox.Text;
            string password = password_textbox.Text;

            string selectQuery = "SELECT personnel_name, personnel_account_number, personnel_password FROM personnel_list " +
                $"WHERE personnel_account_number = '{account_number}'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            if (datatable == null || datatable.Rows.Count == 0)
            {
                MessageBox.Show("查無此帳號！請確認帳號是否正確！");
            }
            else
            {
                if (password == datatable.Rows[0][2].ToString())
                {
                    MessageBox.Show("登入成功！");
                    this.Hide();
                    var mainForm = new MainForm("員工："+datatable.Rows[0][0].ToString());
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("密碼錯誤！");
                }
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (ConnectDatabase() as string == "資料庫連接成功")
            {

            }
            else
            {
                MessageBox.Show("資料庫連接失敗！請洽詢開發人員！");
                this.Close();
            }
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                login_btn_Kry.PerformClick();
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
