using Microsoft.AspNetCore.SignalR.Client;
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
    public partial class MainForm : Form
    {
        private NotifyIcon notifyIcon;
        private HubConnection _connection;
        public MainForm(string personnel_name)
        {
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            InitializeNotifyIcon();
            ConnectToSignalR();
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            account_name_label.Text = personnel_name;
            Maker = personnel_name.Split('：')[1];
            if (account_name_label.Text != "員工：李佳霖")
            {
                permissions_setting_btn.Visible = false;
                all_order_search_btn.Visible = false;
            }
        }

        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.Visible = true;
        }

        private void ShowNotification(string message)
        {
            notifyIcon.BalloonTipTitle = "系統通知";
            notifyIcon.BalloonTipText = message;
            notifyIcon.ShowBalloonTip(10000); // 顯示 3 秒
        }

        private async void ConnectToSignalR()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://122.117.156.246:5000/notificationHub")
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string>("ReceiveNotification", (message) =>
            {
                Invoke(new Action(() =>
                {
                    ShowNotification(message);
                }));
            });

            try
            {
                await _connection.StartAsync();
            }
            catch (Exception ex)
            {
            }
        }

        public static string Maker;

        CustomerDataForm customerDataForm = new CustomerDataForm();
        DriverDataForm driverDataForm = new DriverDataForm();
        ProductDataForm productDataForm = new ProductDataForm();
        AreaDataForm areaDataForm = new AreaDataForm();
        OrderDataForm orderDataForm = new OrderDataForm();
        OrderAssignFormBeBe orderAssignFormBeBe = new OrderAssignFormBeBe();
        OrderOKForm orderOKForm = new OrderOKForm();
        OrderSearchForm orderSearchForm = new OrderSearchForm();
        ReportForm reportForm = new ReportForm();
        AnnouncementForm announcementForm = new AnnouncementForm();
        WaterdispenserForm waterdispenserForm = new WaterdispenserForm();
        MonthCollectMoneyForm monthCollectMoneyForm = new MonthCollectMoneyForm();
        PermissionsSettingForm permissionsSettingForm = new PermissionsSettingForm();
        AllOrderSearchForm allOrderSearchForm = new AllOrderSearchForm();
        SaleSetForm saleSetForm = new SaleSetForm();
        CollectMoneyHistoryForm collectMoneyHistoryForm = new CollectMoneyHistoryForm();
        BankFiveNumForm bankFiveNumForm = new BankFiveNumForm();
        DriverFloorDataForm driverFloorDataForm = new DriverFloorDataForm();
        private void customer_data_btn_Click(object sender, EventArgs e)
        {
            if (customerDataForm != null)
            {
                if (customerDataForm.IsDisposed)
                {
                    customerDataForm = new CustomerDataForm();
                    customerDataForm.Show();
                    customerDataForm.Focus();
                    customerDataForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    customerDataForm.Show();
                    customerDataForm.Focus();
                    customerDataForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void driver_data_btn_Click(object sender, EventArgs e)
        {
            if (driverDataForm != null)
            {
                if (driverDataForm.IsDisposed)
                {
                    driverDataForm = new DriverDataForm();
                    driverDataForm.Show();
                    driverDataForm.Focus();
                    driverDataForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    driverDataForm.Show();
                    driverDataForm.Focus();
                    driverDataForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void product_data_btn_Click(object sender, EventArgs e)
        {
            if (productDataForm != null)
            {
                if (productDataForm.IsDisposed)
                {
                    productDataForm = new ProductDataForm();
                    productDataForm.Show();
                    productDataForm.Focus();
                    productDataForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    productDataForm.Show();
                    productDataForm.Focus();
                    productDataForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void order_data_btn_Click(object sender, EventArgs e)
        {
            if (orderDataForm != null)
            {
                if (orderDataForm.IsDisposed)
                {
                    orderDataForm = new OrderDataForm();
                    orderDataForm.Show();
                    orderDataForm.Focus();
                    orderDataForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    orderDataForm.Show();
                    orderDataForm.Focus();
                    orderDataForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void order_assign_btn_Click(object sender, EventArgs e)
        {
            if (orderAssignFormBeBe != null)
            {
                if (orderAssignFormBeBe.IsDisposed)
                {
                    orderAssignFormBeBe = new OrderAssignFormBeBe();
                    orderAssignFormBeBe.Show();
                    orderAssignFormBeBe.Focus();
                    orderAssignFormBeBe.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    orderAssignFormBeBe.Show();
                    orderAssignFormBeBe.Focus();
                    orderAssignFormBeBe.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void area_data_btn_Click(object sender, EventArgs e)
        {
            if (areaDataForm != null)
            {
                if (areaDataForm.IsDisposed)
                {
                    areaDataForm = new AreaDataForm();
                    areaDataForm.Show();
                    areaDataForm.Focus();
                    areaDataForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    areaDataForm.Show();
                    areaDataForm.Focus();
                    areaDataForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void order_OK_btn_Click(object sender, EventArgs e)
        {
            if (orderOKForm != null)
            {
                if (orderOKForm.IsDisposed)
                {
                    orderOKForm = new OrderOKForm();
                    orderOKForm.Show();
                    orderOKForm.Focus();
                    orderOKForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    orderOKForm.Show();
                    orderOKForm.Focus();
                    orderOKForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void order_search_btn_Click(object sender, EventArgs e)
        {
            if (orderSearchForm != null)
            {
                if (orderSearchForm.IsDisposed)
                {
                    orderSearchForm = new OrderSearchForm();
                    orderSearchForm.Show();
                    orderSearchForm.Focus();
                    orderSearchForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    orderSearchForm.Show();
                    orderSearchForm.Focus();
                    orderSearchForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void announcement_btn_Click(object sender, EventArgs e)
        {
            if (announcementForm != null)
            {
                if (announcementForm.IsDisposed)
                {
                    announcementForm = new AnnouncementForm();
                    announcementForm.Show();
                    announcementForm.Focus();
                    announcementForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    announcementForm.Show();
                    announcementForm.Focus();
                    announcementForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void water_dispenser_btn_Click(object sender, EventArgs e)
        {
            if (waterdispenserForm != null)
            {
                if (waterdispenserForm.IsDisposed)
                {
                    waterdispenserForm = new WaterdispenserForm();
                    waterdispenserForm.Show();
                    waterdispenserForm.Focus();
                    waterdispenserForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    waterdispenserForm.Show();
                    waterdispenserForm.Focus();
                    waterdispenserForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void report_btn_Click(object sender, EventArgs e)
        {
            if (reportForm != null)
            {
                if (reportForm.IsDisposed)
                {
                    reportForm = new ReportForm();
                    reportForm.Show();
                    reportForm.Focus();
                    reportForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    reportForm.Show();
                    reportForm.Focus();
                    reportForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void month_OK_btn_Click(object sender, EventArgs e)
        {
            if (monthCollectMoneyForm != null)
            {
                if (monthCollectMoneyForm.IsDisposed)
                {
                    monthCollectMoneyForm = new MonthCollectMoneyForm();
                    monthCollectMoneyForm.Show();
                    monthCollectMoneyForm.Focus();
                    monthCollectMoneyForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    monthCollectMoneyForm.Show();
                    monthCollectMoneyForm.Focus();
                    monthCollectMoneyForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void permissions_setting_btn_Click(object sender, EventArgs e)
        {
            if (permissionsSettingForm != null)
            {
                if (permissionsSettingForm.IsDisposed)
                {
                    permissionsSettingForm = new PermissionsSettingForm();
                    permissionsSettingForm.Show();
                    permissionsSettingForm.Focus();
                    permissionsSettingForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    permissionsSettingForm.Show();
                    permissionsSettingForm.Focus();
                    permissionsSettingForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void groupBox1_Paint_1(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(this.BackColor);
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void min_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void all_order_search_btn_Click(object sender, EventArgs e)
        {
            if (allOrderSearchForm != null)
            {
                if (allOrderSearchForm.IsDisposed)
                {
                    allOrderSearchForm = new AllOrderSearchForm();
                    allOrderSearchForm.Show();
                    allOrderSearchForm.Focus();
                    allOrderSearchForm.WindowState = FormWindowState.Normal;
                }
                else//如果窗体2没有被释放掉
                {
                    allOrderSearchForm.Show();
                    allOrderSearchForm.Focus();
                    allOrderSearchForm.WindowState = FormWindowState.Normal;
                }
            }
        }

        private void sale_set_btn_Click(object sender, EventArgs e)
        {
            if (saleSetForm.IsDisposed)
            {
                saleSetForm = new SaleSetForm();
                saleSetForm.Show();
                saleSetForm.Focus();
                saleSetForm.WindowState = FormWindowState.Normal;
            }
            else//如果窗体2没有被释放掉
            {
                saleSetForm.Show();
                saleSetForm.Focus();
                saleSetForm.WindowState = FormWindowState.Normal;
            }
        }

        private void collect_money_history_btn_Click(object sender, EventArgs e)
        {
            if (collectMoneyHistoryForm.IsDisposed)
            {
                collectMoneyHistoryForm = new CollectMoneyHistoryForm();
                collectMoneyHistoryForm.Show();
                collectMoneyHistoryForm.Focus();
                collectMoneyHistoryForm.WindowState = FormWindowState.Normal;
            }
            else//如果窗体2没有被释放掉
            {
                collectMoneyHistoryForm.Show();
                collectMoneyHistoryForm.Focus();
                collectMoneyHistoryForm.WindowState = FormWindowState.Normal;
            }
        }

        private void cust_bank_num_btn_Click(object sender, EventArgs e)
        {
            if (bankFiveNumForm.IsDisposed)
            {
                bankFiveNumForm = new BankFiveNumForm();
                bankFiveNumForm.Show();
                bankFiveNumForm.Focus();
                bankFiveNumForm.WindowState = FormWindowState.Normal;
            }
            else//如果窗体2没有被释放掉
            {
                bankFiveNumForm.Show();
                bankFiveNumForm.Focus();
                bankFiveNumForm.WindowState = FormWindowState.Normal;
            }
        }

        private void driver_floor_btn_Click(object sender, EventArgs e)
        {
            if (driverFloorDataForm.IsDisposed)
            {
                driverFloorDataForm = new DriverFloorDataForm();
                driverFloorDataForm.Show();
                driverFloorDataForm.Focus();
                driverFloorDataForm.WindowState = FormWindowState.Normal;
            }
            else//如果窗体2没有被释放掉
            {
                driverFloorDataForm.Show();
                driverFloorDataForm.Focus();
                driverFloorDataForm.WindowState = FormWindowState.Normal;
            }
        }
    }
}
