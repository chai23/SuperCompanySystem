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
    public partial class PasswordInputForm : Form
    {
        public PasswordInputForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            var password = password_textbox.Text;
            if (password == "123456")
            {
                OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
                ChileForm.StrValue = "True";//使用父窗口指針賦值  
                this.Close();
            }
            else
            {
                MessageBox.Show("密碼錯誤");
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.StrValue = "False";//使用父窗口指針賦值  
            this.Close();
        }
    }
}
