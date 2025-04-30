using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Common;
using ZXing;
using Mysqlx.Crud;

namespace 超好企業系統
{
    internal class PrintHelper
    {
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private PrintDocument printDocument = new PrintDocument();
        private List<PrintOrder> printOrder = new List<PrintOrder>();
        private PrintCustomer printCustomer = new PrintCustomer();
        private List<PrintMonthOrder> printMonthOrder = new List<PrintMonthOrder>();
        private int page = 0;

        public PrintHelper(List<PrintOrder> printOrder, PrintCustomer printCustomer) 
        {
            this.printOrder = printOrder;
            this.printCustomer = printCustomer;
            printDocument.PrintPage += printDocument_PrintPage;
            printDocument.EndPrint += PrintDocument_EndPrint;
        }
        public PrintHelper(List<PrintMonthOrder> printMonthOrders)
        {
            this.printMonthOrder = printMonthOrders;
            printDocument.BeginPrint += PrintDocument_BeginPrint;
            printDocument.PrintPage += printDocument_PrintPage_A4;
        }

        private Image getImage(string order_id)
        {
            // 建立 BarcodeWriter 物件
            BarcodeWriter barcodeWriter = new BarcodeWriter();

            // 設定條碼格式為 CODE128
            barcodeWriter.Format = BarcodeFormat.CODE_128;

            // 設定條碼內容
            string barcodeContent = order_id;

            // 設定條碼相關選項
            EncodingOptions options = new EncodingOptions
            {
                Width = 52,  // 設定條碼寬度
                Height = 26, // 設定條碼高度
                PureBarcode = true // 不顯示文字資訊
            };
            barcodeWriter.Options = options;


            // 生成條碼圖片並儲存
            using (var barcodeBitmap = barcodeWriter.Write(barcodeContent))
            {
                barcodeBitmap.Save($"{order_id}.png"); // 儲存成圖片檔
            }
            Bitmap temporary = new Bitmap(Application.StartupPath + $"\\{order_id}.png");
            Bitmap img = new Bitmap(temporary);
            temporary.Dispose();
            return img;
        }

        private void PrintDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            page = 0;
        }

        private void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            string folderPath = System.Windows.Forms.Application.StartupPath;
            string order_id = printCustomer.Order_id;
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("指定的資料夾路徑不存在。");
                return;
            }

            try
            {
                string[] files = Directory.GetFiles(folderPath, $"{order_id}.png");
                foreach (string file in files)
                {
                    File.Delete(file);
                    Console.WriteLine($"刪除檔案: {file}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"刪除檔案時發生錯誤: {ex.Message}");
            }
        }

        public void printPreview217()
        {
            PaperSize psz = new PaperSize();
            psz.Width = 854;
            psz.Height = 500;
            printDocument.DefaultPageSettings.PaperSize = psz; //設定紙張大小
            // PrintPreviewDialog 標準使用方式
            printPreviewDialog.Document = printDocument;
            //printPreviewDialog.ShowDialog();
            printDocument.Print();
        }

        public void printPreviewA4(string isPrint)
        {
            PaperSize psz = new PaperSize();
            psz.Width = 826;
            psz.Height = 1169;
            printDocument.DefaultPageSettings.PaperSize = psz; //設定紙張大小
            // PrintPreviewDialog 標準使用方式
            printPreviewDialog.Document = printDocument;
            //foreach (String strPrinter in PrinterSettings.InstalledPrinters) {
            //     MessageBox.Show(strPrinter);
            // }
            if (isPrint == "Print")
            {
                Boolean havePrinterName = false;
                foreach (string printName in PrinterSettings.InstalledPrinters)
                {
                    if (printName == "Brother MFC-J4340DW Printer")
                    {
                        havePrinterName = true;
                    }
                }
                if (havePrinterName == true) 
                {
                    printDocument.PrinterSettings.PrinterName = "Brother MFC-J4340DW Printer";
                    printDocument.Print();
                }
                else
                {
                    MessageBox.Show("找不到印表機");
                }
                //(printPreviewDialog as Form).WindowState = FormWindowState.Maximized;
                //printPreviewDialog.ShowDialog();
            }
            else if (isPrint == "notPrint")
            { 
                (printPreviewDialog as Form).WindowState = FormWindowState.Maximized;
                printPreviewDialog.ShowDialog();
            }
            //printDocument.PrinterSettings.PrinterName = "Brother MFC-J4340DW Printer";
            //printDocument.Print();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            //列印文字
            System.Drawing.Font printFont = new System.Drawing.Font("新細明體", 10);//設定字型與大小
            float leftMargin = e.MarginBounds.Left;//取得文件左邊界
            float topMargin = e.MarginBounds.Top;//取得文件上邊界
            int count = 0;//起始列印的行數
            float yPos = 0f;//收集成列印起始點的參數
            yPos = topMargin + count * printFont.GetHeight(e.Graphics);

            // public void DrawString (
            // string s, 要繪製的字串。
            // Font font, Font，定義字串的文字格式。
            // Brush brush, Brush，決定所繪製文字的色彩和紋理。
            // float x, 繪製文字左上角的 X 座標。
            // float y, 繪製文字左上角的 Y 座標。
            // StringFormat format StringFormat，指定套用到所繪製文字的格式化屬性，例如，行距和對齊。
            //)
            //將要列印的文字放入要列印的文件中
            e.Graphics.DrawString(printCustomer.Customer_id, printFont, Brushes.Black, 110, 102, new StringFormat());//客戶編號
            e.Graphics.DrawString(printCustomer.Customer_name, printFont, Brushes.Black, 110, 120, new StringFormat());//客戶名稱
            e.Graphics.DrawString(printCustomer.Customer_address, printFont, Brushes.Black, 110, 138, new StringFormat());//客戶地址
            e.Graphics.DrawString(printCustomer.Customer_remark, printFont, Brushes.Black, 110, 156, new StringFormat());//客戶常態備註

            e.Graphics.DrawString(printCustomer.Customer_invoice, printFont, Brushes.Black, 514, 120, new StringFormat());//統編
            e.Graphics.DrawString(printCustomer.Customer_telephone, printFont, Brushes.Black, 514, 138, new StringFormat());//電話
            e.Graphics.DrawString(printCustomer.Order_id, printFont, Brushes.Black, 514, 156, new StringFormat());//訂單編號
            e.Graphics.DrawImage(getImage(printCustomer.Order_id),230,85);

            e.Graphics.DrawString(printCustomer.Date, printFont, Brushes.Black, 648, 155, new StringFormat());//日期
            e.Graphics.DrawString(printCustomer.LastTimeQuantity, printFont, Brushes.Black, 750, 80, new StringFormat());//上次送瓶數量

            int num = 200;
            int num1 = 358;

            foreach (PrintOrder order in printOrder)
            {
                if (order.ProductID == "000" && order.ProductName.Contains("未收款月結單"))
                {
                    e.Graphics.DrawString(order.ProductName, printFont, Brushes.Black, 53, num1, new StringFormat());
                    e.Graphics.DrawString("$"+order.ProductPrice, printFont, Brushes.Black, 230, num1, new StringFormat());
                    num1 += 17;
                    continue; // 跳過這筆資料
                }
                e.Graphics.DrawString(order.ProductID, printFont, Brushes.Black, 53, num, new StringFormat());
                e.Graphics.DrawString(order.ProductName, printFont, Brushes.Black, 110, num, new StringFormat());
                e.Graphics.DrawString(order.ProductQuantity, printFont, Brushes.Black, 365, num, new StringFormat());
                e.Graphics.DrawString(order.ProductPrice, printFont, Brushes.Black, 440, num, new StringFormat());
                e.Graphics.DrawString(order.Subtotal, printFont, Brushes.Black, 525, num, new StringFormat());
                num += 17;
            }

            e.Graphics.DrawString(printCustomer.Product_remark, printFont, Brushes.Black, 40, 295, new StringFormat());

            e.Graphics.DrawString(printCustomer.Total, printFont, Brushes.Black, 535, 320, new StringFormat());
            e.Graphics.DrawString("稅金："+printCustomer.Tex, printFont, Brushes.Black, 500, 300, new StringFormat());

            e.Graphics.DrawString(printCustomer.Announcement, printFont, Brushes.Black, 615, 210, new StringFormat());

            e.Graphics.DrawString(printCustomer.Driver_name, printFont, Brushes.Black, 440, 436, new StringFormat());
            e.Graphics.DrawString(printCustomer.Remain, printFont, Brushes.Black, 725, 436, new StringFormat());
            e.Graphics.DrawString(printCustomer.Bucket, printFont, Brushes.Black, 435, 358, new StringFormat());
            e.Graphics.DrawString(printCustomer.LastTimeOrderDay, printFont, Brushes.Black, 390, 358, new StringFormat());
        }

        private void printDocument_PrintPage_A4(object sender, PrintPageEventArgs e)
        {
            //列印文字
            System.Drawing.Font printFontTitle = new System.Drawing.Font("微軟正黑體", 25);//設定字型與大小
            System.Drawing.Font printFontTotal = new System.Drawing.Font("微軟正黑體", 15);//設定字型與大小
            System.Drawing.Font printFont = new System.Drawing.Font("微軟正黑體", 12);//設定字型與大小
            float leftMargin = e.MarginBounds.Left;//取得文件左邊界
            float topMargin = e.MarginBounds.Top;//取得文件上邊界
            int count = 0;//起始列印的行數
            float yPos = 0f;//收集成列印起始點的參數
            yPos = topMargin + count * printFont.GetHeight(e.Graphics);

            e.HasMorePages = false;
            page++;

            if (page == 1)
            {
                // public void DrawString (
                // string s, 要繪製的字串。
                // Font font, Font，定義字串的文字格式。
                // Brush brush, Brush，決定所繪製文字的色彩和紋理。
                // float x, 繪製文字左上角的 X 座標。
                // float y, 繪製文字左上角的 Y 座標。
                // StringFormat format StringFormat，指定套用到所繪製文字的格式化屬性，例如，行距和對齊。
                //)
                //將要列印的文字放入要列印的文件中
                e.Graphics.DrawString("超好企業水公司月結請款單", printFontTitle, Brushes.Black, 190, 50, new StringFormat());//標題
                e.Graphics.DrawString($"客戶編號：{printMonthOrder[0].Customer_id}", printFont, Brushes.Black, 110, 110, new StringFormat());//標題
                e.Graphics.DrawString($"客戶名稱：{printMonthOrder[0].Customer_name}", printFont, Brushes.Black, 110, 129, new StringFormat());//標題
                e.Graphics.DrawString($"客戶電話：{printMonthOrder[0].Customer_telephone}", printFont, Brushes.Black, 110, 148, new StringFormat());//標題
                e.Graphics.DrawString($"發票：{printMonthOrder[0].Customer_bill_form}", printFont, Brushes.Black, 460, 110, new StringFormat());//標題
                e.Graphics.DrawString($"統一編號：{printMonthOrder[0].Customer_invoice}", printFont, Brushes.Black, 460, 129, new StringFormat());//標題
                e.Graphics.DrawString($"製單日期：{printMonthOrder[0].Print_date}", printFont, Brushes.Black, 460, 148, new StringFormat());//標題

                e.Graphics.DrawString("**", printFont, Brushes.Black, 80, 200, new StringFormat());//標題
                e.Graphics.DrawString("送貨日期", printFont, Brushes.Black, 110, 200, new StringFormat());//標題
                e.Graphics.DrawString("商品", printFont, Brushes.Black, 250, 200, new StringFormat());//標題
                e.Graphics.DrawString("數量", printFont, Brushes.Black, 480, 200, new StringFormat());//標題
                e.Graphics.DrawString("小計", printFont, Brushes.Black, 560, 200, new StringFormat());//標題

                int num = 220;
                int totalQuantity = 0;
                string isHaveOtherAdd = "False";

                foreach (PrintMonthOrder order in printMonthOrder)
                {
                    e.Graphics.DrawString($"{order.Order_date}", printFont, Brushes.Black, 110, num, new StringFormat());//標題
                    if (order.Customer_id.Contains('-'))
                    {
                        e.Graphics.DrawString($"{order.Customer_id.Split('-')[1]}", printFont, Brushes.Black, 80, num, new StringFormat());//標題
                        isHaveOtherAdd = "True";
                    }
                    int datilnum = num;
                    foreach (Order datilOrder in order.Orders)
                    {
                        e.Graphics.DrawString($"{datilOrder.ProductName}", printFont, Brushes.Black, 250, datilnum, new StringFormat());//標題
                        e.Graphics.DrawString($"{datilOrder.Quantity}", printFont, Brushes.Black, 480, datilnum, new StringFormat());//標題
                        totalQuantity += int.Parse(datilOrder.Quantity);
                        e.Graphics.DrawString($"${datilOrder.SubTotal}", printFont, Brushes.Black, 560, datilnum, new StringFormat());//標題
                        datilnum += 20;
                    }
                    num = datilnum - 20 + 23;

                    /*e.Graphics.DrawString($"{order.Order_date}", printFont, Brushes.Black, 110, num, new StringFormat());//標題
                    e.Graphics.DrawString($"{order.Order_id}", printFont, Brushes.Black, 310, num, new StringFormat());//標題
                    e.Graphics.DrawString($"金額：${order.Subtotal}", printFont, Brushes.Black, 550, num, new StringFormat());//標題


                    e.Graphics.DrawString("序", printFont, Brushes.Black, 120, datilnum - 20, new StringFormat());//標題
                    e.Graphics.DrawString("商品", printFont, Brushes.Black, 145, datilnum - 20, new StringFormat());//標題
                    e.Graphics.DrawString("單價", printFont, Brushes.Black, 410, datilnum - 20, new StringFormat());//標題
                    e.Graphics.DrawString("數量", printFont, Brushes.Black, 470, datilnum - 20, new StringFormat());//標題
                    e.Graphics.DrawString("小計", printFont, Brushes.Black, 530, datilnum - 20, new StringFormat());//標題
                    foreach (Order datilOrder in order.Orders)
                    {
                        e.Graphics.DrawString($"{datilOrder.ProductIndex}", printFont, Brushes.Black, 120, datilnum, new StringFormat());//標題
                        e.Graphics.DrawString($"{datilOrder.ProductName}", printFont, Brushes.Black, 145, datilnum, new StringFormat());//標題
                        e.Graphics.DrawString($"${datilOrder.Price}", printFont, Brushes.Black, 410, datilnum, new StringFormat());//標題
                        e.Graphics.DrawString($"{datilOrder.Quantity}", printFont, Brushes.Black, 470, datilnum, new StringFormat());//標題
                        totalQuantity += int.Parse(datilOrder.Quantity);
                        e.Graphics.DrawString($"${datilOrder.SubTotal}", printFont, Brushes.Black, 530, datilnum, new StringFormat());//標題
                        datilnum += 20;
                    }*/
                }
                e.Graphics.DrawString($"總數量：{totalQuantity}", printFontTotal, Brushes.Black, 350, num+10, new StringFormat());//標題
                e.Graphics.DrawString($"總金額：${printMonthOrder[0].Total}", printFontTotal, Brushes.Black, 525, num+10, new StringFormat());//標題


                if (isHaveOtherAdd == "True")
                {
                    var groupedOrders = printMonthOrder
                        .SelectMany(co => co.Orders, (co, order) => new
                        {
                            co.Customer_id,
                            order.ProductName,
                            Quantity = int.Parse(order.Quantity), // 直接轉成 int
                            SubTotal = int.Parse(order.SubTotal) // 直接轉成 int
                        })
                        .GroupBy(o => new { o.Customer_id, o.ProductName }) // 依 Customer_id 和 ProductName 分組
                        .Select(g => new
                        {
                            Customer_id = g.Key.Customer_id,
                            ProductName = g.Key.ProductName,
                            TotalValue = g.Sum(o => o.Quantity), // 加總 Quantity
                             TotalMoney = g.Sum(o => o.SubTotal) // 加總 Quantity
                        })
                        .OrderBy(g => g.Customer_id)
                        .GroupBy(g => g.Customer_id) // 再次依 Customer_id 分組，變成二維結構
                        .Select(g => g.ToList())  // 每個 Customer_id 對應一個 List<>
                        .ToList();

                    num += 100;
                    foreach (var o in groupedOrders)
                    {
                        e.Graphics.DrawString($"{o[0].Customer_id}", printFont, Brushes.Black, 110, num, new StringFormat());//標題
                        foreach (var item in o)
                        {
                            e.Graphics.DrawString($"{item.ProductName}", printFont, Brushes.Black, 230, num, new StringFormat());//標題
                            e.Graphics.DrawString($"{item.TotalValue}桶", printFont, Brushes.Black, 380, num, new StringFormat());//標題
                            e.Graphics.DrawString($"${item.TotalMoney}", printFont, Brushes.Black, 480, num, new StringFormat());//標題
                            num += 25;
                        }
                    }
                }


                e.Graphics.DrawString($"公司章：", printFont, Brushes.Black, 110, 1014, new StringFormat());//標題
                e.Graphics.DrawString($"製單人員：{printMonthOrder[0].Print_people}", printFont, Brushes.Black, 110, 1104, new StringFormat());//標題
                e.Graphics.DrawString($"收款人員：{printMonthOrder[0].Driver_name}", printFont, Brushes.Black, 310, 1104, new StringFormat());//標題
                e.Graphics.DrawString($"客戶簽收：", printFont, Brushes.Black, 510, 1104, new StringFormat());//標題

            }
            else if (page == 2)
            {
                // public void DrawString (
                // string s, 要繪製的字串。
                // Font font, Font，定義字串的文字格式。
                // Brush brush, Brush，決定所繪製文字的色彩和紋理。
                // float x, 繪製文字左上角的 X 座標。
                // float y, 繪製文字左上角的 Y 座標。
                // StringFormat format StringFormat，指定套用到所繪製文字的格式化屬性，例如，行距和對齊。
                //)
                //將要列印的文字放入要列印的文件中
                /*
                e.Graphics.DrawString("月結收款單(公司聯)", printFontTitle, Brushes.Black, 230, 50, new StringFormat());//標題
                e.Graphics.DrawString($"客戶編號：{printMonthOrder[0].Customer_id}", printFont, Brushes.Black, 110, 100, new StringFormat());//標題
                e.Graphics.DrawString($"客戶名稱：{printMonthOrder[0].Customer_name}", printFont, Brushes.Black, 110, 119, new StringFormat());//標題
                e.Graphics.DrawString($"客戶電話：{printMonthOrder[0].Customer_telephone}", printFont, Brushes.Black, 110, 138, new StringFormat());//標題
                e.Graphics.DrawString($"發票：{printMonthOrder[0].Customer_bill_form}", printFont, Brushes.Black, 460, 100, new StringFormat());//標題
                e.Graphics.DrawString($"統一編號：{printMonthOrder[0].Customer_invoice}", printFont, Brushes.Black, 460, 119, new StringFormat());//標題
                e.Graphics.DrawString($"製單日期：{printMonthOrder[0].Print_date}", printFont, Brushes.Black, 460, 138, new StringFormat());//標題

                int num = 200;
                int orderCount = printMonthOrder.Count;

                e.Graphics.DrawString($"總金額：${printMonthOrder[0].Total}", printFontTotal, Brushes.Black, 525, num + ((orderCount + 2) * 19), new StringFormat());//標題

                foreach (PrintMonthOrder order in printMonthOrder)
                {
                    e.Graphics.DrawString($"送貨日期：{order.Order_date}", printFont, Brushes.Black, 110, num, new StringFormat());//標題
                    e.Graphics.DrawString($"送貨單號：{order.Order_id}", printFont, Brushes.Black, 310, num, new StringFormat());//標題
                    e.Graphics.DrawString($"金額：${order.Subtotal}", printFont, Brushes.Black, 550, num, new StringFormat());//標題
                    num += 19;
                }

                e.Graphics.DrawString($"製單人員：{printMonthOrder[0].Print_people}", printFont, Brushes.Black, 110, 530, new StringFormat());//標題
                e.Graphics.DrawString($"收款人員：{printMonthOrder[0].Driver_name}", printFont, Brushes.Black, 310, 530, new StringFormat());//標題
                e.Graphics.DrawString($"客戶簽收：", printFont, Brushes.Black, 510, 530, new StringFormat());//標題

                e.Graphics.DrawString("---------------------------------------------------------------------------------------------------------------", printFont, Brushes.Black, 0, 584, new StringFormat());//標題

                e.Graphics.DrawString("月結收款單(收款聯)", printFontTitle, Brushes.Black, 230, 634, new StringFormat());//標題
                e.Graphics.DrawString($"客戶編號：{printMonthOrder[0].Customer_id}", printFont, Brushes.Black, 110, 684, new StringFormat());//標題
                e.Graphics.DrawString($"客戶名稱：{printMonthOrder[0].Customer_name}", printFont, Brushes.Black, 110, 703, new StringFormat());//標題
                e.Graphics.DrawString($"客戶電話：{printMonthOrder[0].Customer_telephone}", printFont, Brushes.Black, 110, 722, new StringFormat());//標題
                e.Graphics.DrawString($"發票：{printMonthOrder[0].Customer_bill_form}", printFont, Brushes.Black, 460, 684, new StringFormat());//標題
                e.Graphics.DrawString($"統一編號：{printMonthOrder[0].Customer_invoice}", printFont, Brushes.Black, 460, 703, new StringFormat());//標題
                e.Graphics.DrawString($"製單日期：{printMonthOrder[0].Print_date}", printFont, Brushes.Black, 460, 722, new StringFormat());//標題

                int num2 = 784;
                int orderCount2 = printMonthOrder.Count;

                e.Graphics.DrawString($"總金額：${printMonthOrder[0].Total}", printFontTotal, Brushes.Black, 525, num2 + ((orderCount2 + 2) * 19), new StringFormat());//標題

                foreach (PrintMonthOrder order in printMonthOrder)
                {
                    e.Graphics.DrawString($"送貨日期：{order.Order_date}", printFont, Brushes.Black, 110, num2, new StringFormat());//標題
                    e.Graphics.DrawString($"送貨單號：{order.Order_id}", printFont, Brushes.Black, 310, num2, new StringFormat());//標題
                    e.Graphics.DrawString($"金額：${order.Subtotal}", printFont, Brushes.Black, 550, num2, new StringFormat());//標題
                    num2 += 19;
                }

                e.Graphics.DrawString($"製單人員：{printMonthOrder[0].Print_people}", printFont, Brushes.Black, 110, 1104, new StringFormat());//標題
                e.Graphics.DrawString($"收款人員：{printMonthOrder[0].Driver_name}", printFont, Brushes.Black, 310, 1104, new StringFormat());//標題
                e.Graphics.DrawString($"客戶簽收：", printFont, Brushes.Black, 510, 1104, new StringFormat());//標題
 
                e.HasMorePages = false;
                */
            }





        }
    }
}
