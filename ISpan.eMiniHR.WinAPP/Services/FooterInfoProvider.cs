using ISpan.eMiniHR.WinApp.Forms;
using ISpan.eMiniHR.WinApp.Properties;
using ISpan.eMiniHR.WinApp.Services;
using Timer = System.Windows.Forms.Timer;

namespace ISpan.eMiniHR.WinApp.Services
{
    /// <summary>
    /// 資訊列服務
    /// </summary>
    public static class FooterInfoProvider
    {
        private static DateTime loginTime; // 登入時間
        private static Label lblLoginDuration = new Label(); // 用於顯示已登入時間

        /// <summary>
        /// 建立 Footer 與登出按鈕
        /// </summary>
        /// <param name="currentForm">目前畫面</param>
        /// <param name="logoutClickHandler">登出按鈕點擊事件</param>
        public static void CreateFooterWithLogout(Form currentForm, EventHandler? logoutClickHandler = null) {

            int footerHeight = 40; // Footer 高度

            var panelFooter = CreateFooterPanel(currentForm, footerHeight); // 建立 Footer Panel
            AddLogoutButton(panelFooter, logoutClickHandler ?? ((s, e) => 
                PerformLogout(currentForm)), footerHeight); // 增加登出按鈕
            AddUserInfo(panelFooter); // 增加登入者資訊
            AddLoginTimeLabel(panelFooter); // 增加登入時間顯示
            StartLoginDurationTimer(panelFooter); // 啟動登入時間計時器
        }

        /// <summary>
        /// 建立 Footer Panel
        /// </summary>
        /// <param name="form"></param>
        /// <param name="footerHeight"></param>
        /// <returns></returns>
        private static Panel CreateFooterPanel(Form form, int footerHeight)
        {
            // 建立 Footer Panel
            var panel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = footerHeight,
                BackColor = Color.LightGray
            };
            form.Controls.Add(panel);
            return panel;
        }

        /// <summary>
        /// 增加登入時間顯示 Label 到指定 Panel
        /// </summary>
        /// <param name="panel"></param>
        private static void AddUserInfo(Panel panel)
        {
            panel.Controls.Add(new Label
            {
                //Text = $"登入者：{LoginUserInfo.LoginSession.CurrentUser.EmpName}",
                Text = $"登入者：{LoginSession.User.EmpNm}",
                Dock = DockStyle.Left,
                AutoSize = true,
                Font = new Font("微軟正黑體", 12, FontStyle.Bold),
                Padding = new Padding(0, 10, 0, 0), // 左,上,右,下
            });
        }

        /// <summary>
        /// 登入時間與更新
        /// </summary>
        /// <param name="panel"></param>
        private static void AddLoginTimeLabel(Panel panel)
        {
            loginTime = LoginSession.User.LoginTime;

            panel.Controls.Add(new Label
            {
                Text = $"登入時間：{loginTime:yyyy/MM/dd HH:mm:ss}",
                AutoSize = true,
                Font = new Font("微軟正黑體", 12, FontStyle.Bold),
                Padding = new Padding(200, 10, 0, 0)
            });

            lblLoginDuration = new Label
            {
                Text = "已登入時間：00:00:00秒",
                AutoSize = true,
                Font = new Font("微軟正黑體", 12, FontStyle.Bold),
                Padding = new Padding(800, 10, 0, 0)
            };
            panel.Controls.Add(lblLoginDuration);
        }

        /// <summary>
        /// 啟動 Timer
        /// </summary>
        /// <param name="panel"></param>
        private static void StartLoginDurationTimer(Panel panel)
        {
            var timer = new Timer { Interval = 1000 }; // 每秒更新一次
            timer.Tick += (s, e) =>
            {
                var duration = DateTime.Now - loginTime;
                lblLoginDuration.Text = $"已登入時間：{duration:hh\\:mm\\:ss}" ?? "";
            };
            timer.Start();
        }

        /// <summary>
        /// 登出按鈕加入到指定 Panel
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="onClick"></param>
        private static void AddLogoutButton(Panel panel, EventHandler onClick, int footerHeight)
        {
            // 建立 登出按鈕（含圖示）
            var btnLogout = new Button
            {
                Width = footerHeight,
                Height = footerHeight,
                Dock = DockStyle.Right,
                ImageAlign = ContentAlignment.MiddleCenter, // 圖示對齊方式
                FlatStyle = FlatStyle.Flat // 無邊框
            };

            // 設定登出按鈕無外框
            btnLogout.FlatAppearance.BorderSize = 0;

            // 載入圖示
            var original = Resources.logout;
            btnLogout.Image = new Bitmap(original, new Size(footerHeight - 10, footerHeight - 10));

            btnLogout.Click += onClick;
            panel.Controls.Add(btnLogout);
        }

        /// <summary>
        /// 登出事件
        /// </summary>
        /// <param name="currentForm">目前畫面</param>
        public static void PerformLogout(Form currentForm)
        {
            if (MessageBox.Show("確定要登出嗎？", "登出確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // 清除登入者資訊
                LoginSession.Logout();

                // 隱藏目前畫面（例如 MainForm）
                currentForm.Hide();

                // 回到登入畫面
                new LoginForm().Show();
            }
        }  
    }
}
