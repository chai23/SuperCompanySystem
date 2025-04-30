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
    public partial class CustomerAddressSelect : Form
    {
        public CustomerAddressSelect(DataTable dataTable)
        {
            InitializeComponent();
            updataCustomerAddressListView(dataTable);
            customer_address_listview.Focus();
        }

        private void updataCustomerAddressListView(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows) 
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                customer_address_listview.Items.Add(item);
            }
        }

        private void selectOK()
        {
            var addressIndex = customer_address_listview.FocusedItem.Index;
            OrderDataForm ChileForm = (OrderDataForm)this.Owner;//把Form2的父窗口指針賦給lForm1  
            ChileForm.AddressIndex = addressIndex.ToString();//使用父窗口指針賦值  
            this.Close();
        }

        private void customer_address_listview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectOK();
            }
        }

        private void customer_address_listview_DoubleClick(object sender, EventArgs e)
        {
            selectOK();
        }

        private void CustomerAddressSelect_Resize(object sender, EventArgs e)
        {
            int totalWidth = customer_address_listview.ClientSize.Width; // 取得 `ListView` 的可視寬度
            if (totalWidth > 0)
            {
                customer_address_listview.Columns[0].Width = (int)(totalWidth * 1); // 第一欄占 30%
            }
        }
    }
}
