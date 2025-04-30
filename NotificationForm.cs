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
    public partial class NotificationForm : Form
    {
        private Label messageLabel;
        private Timer closeTimer;

        public NotificationForm(string title, string message)
        {
            this.Text = title;
            this.TopMost = true;
            this.Size = new Size(250, 100);
            this.StartPosition = FormStartPosition.Manual;
            this.FormBorderStyle = FormBorderStyle.None;

            // 設定顯示位置 (右下角疊加)
            int screenX = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 10;
            int screenY = Screen.PrimaryScreen.WorkingArea.Height - this.Height - 10 - (50 * Application.OpenForms.Count);
            this.Location = new Point(screenX, screenY);
            
            messageLabel = new Label()
            {
                Text = message,
                AutoSize = false,
                Size = new Size(230, 50),
                Location = new Point(10, 10)
            };
            this.Controls.Add(messageLabel);

            // 計時器自動關閉
            closeTimer = new Timer();
            closeTimer.Interval = 3000; // 3秒後關閉
            closeTimer.Tick += (s, e) => { this.Close(); };
            closeTimer.Start();
        }
    }
}
