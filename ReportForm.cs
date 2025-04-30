using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.X509;

namespace 超好企業系統
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            getDriverDataToCombobox();
            driver_comboBox.SelectedIndex = 0;
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

        private void ReportForm_Load(object sender, EventArgs e)
        {
            //this.reportViewer1.RefreshReport();
        }
        private DataTable GetTotal(DataTable dataTable)
        {
            DataTable result = new DataTable();
            int total = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                total = total + int.Parse(row[0].ToString());
            }
            result.Columns.Add("total");
            result.Rows.Add(total);
            return result;
        }

        private DataTable GetSubTotal(DataTable dataTable)
        {
            DataTable result = new DataTable();
            result = dataTable.Clone();
            foreach (DataRow row in dataTable.Rows)
            {
                int index = result.Rows.Count - 1;
                if (result.Rows.Count == 0)
                {
                    result.ImportRow(row);
                } else if (result.Rows[index][0].ToString() != row[0].ToString())
                {
                    result.ImportRow(row);
                } else if (result.Rows[index][0].ToString() == row[0].ToString())
                {
                    result.Rows[index][2] = int.Parse(result.Rows[index][2].ToString()) + int.Parse(row[2].ToString());
                }
            }
            return result;
        }

        private void getDriverDataToCombobox()
        {
            driver_comboBox.Items.Clear();
            string selectQuery = "SELECT driver_name FROM driver";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            foreach (DataRow item in datatable.Rows)
            {
                driver_comboBox.Items.Add(item[0]);
            }
        }

        private string getDriverNameOrID(string nameOrid, string value)
        {
            if (nameOrid == "name")
            {
                string selectQuery = "SELECT driver_id FROM driver " +
                $"WHERE driver_name = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else if (nameOrid == "id")
            {
                string selectQuery = "SELECT driver_name FROM driver " +
                $"WHERE driver_id = '{value}'";
                DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
                return datatable.Rows[0][0].ToString();
            }
            else
            {
                return null;
            }
        }

        private void not_collect_money_btn_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "UnCollectReport.rdlc";
            var order_day = DateTime.Now.ToString("yyyy-MM-dd");

            string selectQuery = "SELECT o.order_id, DATE_FORMAT(o.order_day,'%Y-%m-%d') as order_day, o.subtotal, o.customer_id, c.customer_name FROM `order` as o " +
                "JOIN `customer` as c on c.customer_id = o.customer_id " +
                "WHERE o.order_OK = 'True' AND o.collect_OK = 'False' AND o.collect_money <> '月結'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            datatable = GetSubTotal(datatable);

            var reportPararms = new List<ReportParameter>();
            reportPararms.Add(new ReportParameter("report_day", order_day));
            reportViewer1.LocalReport.SetParameters(reportPararms);

            ReportDataSource rp = new ReportDataSource("DataSet1", datatable);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rp);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.RefreshReport();
        }

        private void report_day_btn_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "DayReport.rdlc";
            var order_day = dateTimePicker.Value.ToString("yyyy-MM-dd");


            string selectQuery = "SELECT driver_id, product_name, product_quantity, subtotal FROM `report_day` " +
                $"WHERE order_day = '{order_day}' AND remark NOT IN ('預收', '前帳') ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            string selectQuery1 = "SELECT driver_id, subtotal FROM `report_day` " +
                $"WHERE order_day = '{order_day}' AND collect_OK = 'True' AND remark <> '抵扣' AND remark <> '月結'";
            DataTable datatable1 = ConnectDatabase("查詢", selectQuery1) as DataTable;

            ReportDataSource rp = new ReportDataSource("DataSet1", datatable);
            ReportDataSource rp1 = new ReportDataSource("DataSet2", datatable1);
            var reportPararms = new List<ReportParameter>();
            reportPararms.Add(new ReportParameter("report_day",  order_day));
            reportViewer1.LocalReport.SetParameters(reportPararms);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.LocalReport.DataSources.Add(rp1);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.RefreshReport();
        }

        private void report_month_btn_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "MonthReport.rdlc";
            var dayNow = dateTimePicker.Value;
            var order_day_1 = (dayNow.AddDays(dayNow.Day * -1).AddDays(1).Date).ToString("yyyy-MM-dd");
            var order_day_30 = (dayNow.AddDays(dayNow.Day * -1).AddDays(1).Date.AddMonths(1).AddMilliseconds(-1)).ToString("yyyy-MM-dd");


            string selectQuery = "SELECT driver_id, product_name, product_quantity, subtotal FROM `report_day` " +
                $"WHERE order_day >= '{order_day_1}' AND order_day <= '{order_day_30}' AND remark NOT IN ('預收', '前帳') ";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            string selectQuery1 = "SELECT driver_id, subtotal FROM `report_day` " +
                $"WHERE order_day >= '{order_day_1}' AND order_day <= '{order_day_30}' AND collect_OK = 'True' AND remark <> '抵付'";
            DataTable datatable1 = ConnectDatabase("查詢", selectQuery1) as DataTable;

            ReportDataSource rp = new ReportDataSource("DataSet1", datatable);
            ReportDataSource rp1 = new ReportDataSource("DataSet2", datatable1);
            var reportPararms = new List<ReportParameter>();
            reportPararms.Add(new ReportParameter("report_day", order_day_30));
            reportViewer1.LocalReport.SetParameters(reportPararms);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.LocalReport.DataSources.Add(rp1);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.RefreshReport();
        }

        private void prepaid_report_btn_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "PrepaidReport.rdlc";
            var order_day = DateTime.Now.ToString("yyyy-MM-dd");

            string selectQuery = "SELECT c.customer_id, c.customer_remain, o.product_price, (c.customer_remain * o.product_price) as subtotal, o.order_day " +
                "FROM `customer` as c "+
                "JOIN `order` as o on c.customer_id = o.customer_id inner join "+
                "(select c2.customer_id, max(o2.order_day) as q "+
                "from `customer` as c2 "+
                "join `order` as o2 on c2.customer_id = o2.customer_id AND o2.give_nofree = 'False' " +
                "group by c2.customer_id) "+
                "as temp on c.customer_id = temp.customer_id "+
                "and o.order_day = temp.q "+
                "WHERE c.customer_remain<> '0' AND o.collect_money = '預收' AND o.give_nofree = 'False'";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;
            Console.WriteLine(selectQuery);
            var reportPararms = new List<ReportParameter>();
            reportPararms.Add(new ReportParameter("report_day", order_day));
            reportViewer1.LocalReport.SetParameters(reportPararms);

            ReportDataSource rp = new ReportDataSource("DataSet1", datatable);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rp);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.RefreshReport();
        }

        private void report_detil_day_btn_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "DayDetilReport.rdlc";
            var order_day = dateTimePicker.Value.ToString("yyyy-MM-dd");
            var driver_name = driver_comboBox.Text;
            string product_quantity_total = "0";
            string recyele_quantity_total = "0";
            string unback_product_quantity_total = "0";
            string product_quantity_morning = "0";
            string recyele_quantity_morning = "0";
            string unback_product_quantity_morning = "0";
            string product_quantity_afternoon = "0";
            string recyele_quantity_afternoon = "0";
            string unback_product_quantity_afternoon = "0";


            string selectQuery = "SELECT DATE_FORMAT(o.order_day,'%Y-%m-%d') as order_day, o.order_id as order_id, c.customer_name as customer_name, o.product_name as product_name"+
                ", o.product_price as product_price, o.product_quantity as product_quantity, o.recyele_quantity as recyele_quantity" +
                ", o.collect_money as collect_money, IF(o.collect_OK = 'True', 'Y', '') as collect_OK, o.subtotal as subtotal, IF(o.collect_OK = 'True', o.subtotal, '0') as total, o.product_index as product_index, o.morningorafternoon, c.customer_id " +
                ", if(o.product_index = '1', ifnull(d.floor, ''), '') as floor, if(o.product_index = '1', ifnull(d.product_quantity, ''), '') as floor_quantity " +
                "FROM `report_day` as o " +
                "JOIN `customer` as c on o.customer_id = c.customer_id " +
                "left JOIN `driver_floor_detil` as d on o.order_id = d.order_id " +
                $"WHERE o.order_day = '{order_day}' AND o.driver_id = '{driver_name}' " +
                $"ORDER BY morningorafternoon ASC, order_id ASC, product_index ASC";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            string selectQuery3 = "select floor, morningorafternoon, sum(product_quantity) as product_quantity from `driver_floor_detil` " +
                "join `driver` as d on `driver_floor_detil`.driver_id = d.driver_id " +
                $"where order_day = '{order_day}' and d.driver_name = '{driver_name}' " +
                "group by floor, morningorafternoon order by morningorafternoon ASC, floor DESC";
            DataTable datatable3 = ConnectDatabase("查詢", selectQuery3) as DataTable;

            string selectQuery1 = "select SUM(case when o.product_id >= 1 and o.product_id <= 200 and p.is_join_bucket = true then if (o.collect_money = '預收' , if (o.give_nofree = 'True', o.product_quantity, 0 ), o.product_quantity) else 0 end) as product_quantity " +
                ", SUM(case when o.product_index = '1' then o.recyele_quantity else 0 end) as recyele_quantity " +
                ", SUM(case when o.product_id >= 1 and o.product_id <= 200 and p.is_join_bucket = false then  if (o.collect_money = '預收' , if (o.give_nofree = 'True', o.product_quantity, 0 ), o.product_quantity) else 0 end) as unback_product_quantity " +
                ", ifnull(r.morningorafternoon, '總計') as morningorafternoon " +
                "from `order` as o " +
                "join `driver` as d on o.driver_id = d.driver_id " +
                "join `product` as p on o.product_id = p.product_id " +
                "join `report_day` as r on o.order_id = r.order_id and r.product_name <> '短溢收' and r.product_index = '1' " +
                $"where o.order_OK = 'True' and o.order_day = '{order_day}' and d.driver_name = '{driver_name}' and r.morningorafternoon in ('上午','下午') " +
                $"group by r.morningorafternoon WITH ROLLUP ORDER BY morningorafternoon ASC ";
            DataTable datatable1 = ConnectDatabase("查詢", selectQuery1) as DataTable;

            if (datatable1.Rows.Count.ToString() == "2")
            {
                if (datatable1.Rows[0][3].ToString() == "上午")
                {
                    product_quantity_total = datatable1.Rows[1][0].ToString();
                    recyele_quantity_total = datatable1.Rows[1][1].ToString();
                    unback_product_quantity_total = datatable1.Rows[1][2].ToString();
                    product_quantity_morning = datatable1.Rows[0][0].ToString();
                    recyele_quantity_morning = datatable1.Rows[0][1].ToString();
                    unback_product_quantity_morning = datatable1.Rows[0][2].ToString();
                }
                else if (datatable1.Rows[0][3].ToString() == "下午")
                {
                    product_quantity_total = datatable1.Rows[1][0].ToString();
                    recyele_quantity_total = datatable1.Rows[1][1].ToString();
                    unback_product_quantity_total = datatable1.Rows[1][2].ToString();
                    product_quantity_afternoon = datatable1.Rows[0][0].ToString();
                    recyele_quantity_afternoon = datatable1.Rows[0][1].ToString();
                    unback_product_quantity_afternoon = datatable1.Rows[0][2].ToString();
                }
            }
            else if (datatable1.Rows.Count.ToString() == "3")
            {
                product_quantity_total = datatable1.Rows[2][0].ToString();
                recyele_quantity_total = datatable1.Rows[2][1].ToString();
                unback_product_quantity_total = datatable1.Rows[2][2].ToString();
                product_quantity_morning = datatable1.Rows[0][0].ToString();
                recyele_quantity_morning = datatable1.Rows[0][1].ToString();
                unback_product_quantity_morning = datatable1.Rows[0][2].ToString();
                product_quantity_afternoon = datatable1.Rows[1][0].ToString();
                recyele_quantity_afternoon = datatable1.Rows[1][1].ToString();
                unback_product_quantity_afternoon = datatable1.Rows[1][2].ToString();
            }


            ReportDataSource rp = new ReportDataSource("DataSet1", datatable);
            ReportDataSource rp1 = new ReportDataSource("DataSet2", datatable3);
            var reportPararms = new List<ReportParameter>();
            reportPararms.Add(new ReportParameter("report_day", DateTime.Now.ToString("yyyy-MM-dd")));
            reportPararms.Add(new ReportParameter("order_day", order_day));
            reportPararms.Add(new ReportParameter("driver_name", driver_name));
            reportPararms.Add(new ReportParameter("product_quantity_total", product_quantity_total));
            reportPararms.Add(new ReportParameter("recyele_quantity_total", recyele_quantity_total));
            reportPararms.Add(new ReportParameter("unback_product_quantity_total", unback_product_quantity_total));
            reportPararms.Add(new ReportParameter("product_quantity_morning", product_quantity_morning));
            reportPararms.Add(new ReportParameter("recyele_quantity_morning", recyele_quantity_morning));
            reportPararms.Add(new ReportParameter("unback_product_quantity_morning", unback_product_quantity_morning));
            reportPararms.Add(new ReportParameter("product_quantity_afternoon", product_quantity_afternoon));
            reportPararms.Add(new ReportParameter("recyele_quantity_afternoon", recyele_quantity_afternoon));
            reportPararms.Add(new ReportParameter("unback_product_quantity_afternoon", unback_product_quantity_afternoon));
            reportViewer1.LocalReport.SetParameters(reportPararms);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.LocalReport.DataSources.Add(rp1);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.RefreshReport();
        }

        private void driver_quantity_month_btn_Click(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportPath = "DriverQuantityMonthReport.rdlc";
            var dayNow = dateTimePicker.Value;
            var order_day_1 = (dayNow.AddDays(dayNow.Day * -1).AddDays(1).Date).ToString("yyyy-MM-dd");
            var order_day_30 = (dayNow.AddDays(dayNow.Day * -1).AddDays(1).Date.AddMonths(1).AddMilliseconds(-1)).ToString("yyyy-MM-dd");


            string selectQuery = "select d.driver_name, SUM(case when o.product_id >= 1 and o.product_id <= 200 and p.is_join_bucket = true then if (o.collect_money = '預收' , if (o.give_nofree = 'True', o.product_quantity, 0 ), o.product_quantity) else 0 end) as product_quantity " +
                ", SUM(case when o.product_index = '1' then o.recyele_quantity else 0 end) as recyele_quantity " +
                ", SUM(case when o.product_id >= 1 and o.product_id <= 200 and p.is_join_bucket = false then  if (o.collect_money = '預收' , if (o.give_nofree = 'True', o.product_quantity, 0 ), o.product_quantity) else 0 end) as unback_product_quantity " +
                "from `order` as o "+
                "join `driver` as d on o.driver_id = d.driver_id " +
                "join `product` as p on o.product_id = p.product_id " +
                $"where o.driver_id <> '000' and o.order_OK = 'True' and o.order_day >= '{order_day_1}' AND o.order_day <= '{order_day_30}' group by o.driver_id";
            DataTable datatable = ConnectDatabase("查詢", selectQuery) as DataTable;

            Console.WriteLine(selectQuery);
            ReportDataSource rp = new ReportDataSource("DataSet1", datatable);
            var reportPararms = new List<ReportParameter>();
            reportPararms.Add(new ReportParameter("report_day", DateTime.Now.ToString("yyyy-MM-dd")));
            reportViewer1.LocalReport.SetParameters(reportPararms);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rp);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.RefreshReport();
        }
    }
}
