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
    public partial class OrderDaySelectForm : Form
    {
        public OrderDaySelectForm()
        {
            InitializeComponent();
        }

        private void OK_btn_Click(object sender, EventArgs e)
        {
            var order_day = dateTimePicker.Value.ToString("yyyy-MM-dd");
            OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.StrValue = order_day;//使用父窗口指針賦值  
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            var order_day = DateTime.Now.ToString("yyyy-MM-dd");
            OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.StrValue = order_day;//使用父窗口指針賦值  
            this.Close();
        }

        private void groupBox1_Paint_1(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }
    }
}
