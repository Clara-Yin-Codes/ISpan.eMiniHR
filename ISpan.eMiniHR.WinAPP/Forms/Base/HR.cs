using ISpan.eMiniHR.WinApp.Components;
using ISpan.eMiniHR.WinApp.Services;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ISpan.eMiniHR.WinApp.Forms.Base
{
    public class HR : UserControl
    {
        /// <summary>
        /// 標題
        /// </summary>
        protected Label lblTitle = new Label();
        private string _progName = string.Empty;
        private string _progSysId = string.Empty;
        public virtual Size defaultFormSize => new Size(1000, 600); // 設定頁面大小
        //protected FlowLayoutPanel panelToolButtons;

        private readonly Panel _internalContentHost = new Panel
        {
            Dock = DockStyle.Fill,
            Margin = new Padding(10),
            BackColor = Color.Transparent // 為了設計畫面看得到
        };

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Browsable(false)]
        public Panel ContentContainer => _internalContentHost;

        private Panel _contentPanel;

        public Panel ContentPanel => _contentPanel;

        /// <summary>
        /// 取得權限工具列
        /// </summary>
        public PermissionToolBar PermissionBar { get; private set; }

        public void LoadPermissionBar()
        {
            if (PermissionBar == null || string.IsNullOrEmpty(_progSysId)) return;

            if (!IsInDesignMode())
            {
                PermissionBar.LoadPermission(_progSysId);
            }
        }

        public void SetToolButtonBkColortoWhite(string btn)
        {
            if (PermissionBar == null || string.IsNullOrWhiteSpace(btn)) return;

            var buttons = PermissionBar.Controls.OfType<System.Windows.Forms.Button>();

            var setBtn = buttons.FirstOrDefault(a => a.Text == btn);
            if (setBtn == null) return; // ✅ 防止 null reference

            setBtn.BackColor = Color.White;

            // 綁定事件（避免重複）
            setBtn.Click -= ToolBarButton_Click;
            setBtn.Click += ToolBarButton_Click;
        }

        protected void ToolBarButton_Click(object? sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Button btn)
            {
                MessageBox.Show($"你按下了：{btn.Text}");
            }
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    //base.OnLoad(e);
        //    // 設定預設大小
        //    this.Size = defaultFormSize;
        //    // 載入權限工具列
        //    LoadPermissionBar();
        //    // 將所有元件移到 contentPanel
        //    OnLoadContent();
        //}

        /// <summary>
        /// 取得程式ID
        /// </summary>
        public string ProgSysId
        {
            get => _progSysId;
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    _progSysId = value;

                    if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                    {
                        // 更新權限工具列
                        PermissionBar.LoadPermission(_progSysId);

                        var menu = LoginSession.MenuItems.FirstOrDefault(a => a.ProgSysId == _progSysId);
                        _progName = menu?.ProgName ?? "未命名功能";

                        if (lblTitle != null) lblTitle.Text = _progName;
                    }
                }
            }
        }

        public HR()
        {
            InitializeBaseUI(); // 永遠執行 UI 初始化

            //if (!IsInDesignMode()) // 避開設計階段進行資料邏輯
            //{
            //    LoadPermissionBar();
            //}
        }

        private static bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
                   System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
        }

        private void InitializeBaseUI()
        {
            Dock = DockStyle.Fill;
            AutoScaleMode = AutoScaleMode.None; // 強制關閉比例縮放

            int titleWidth = 300; // 標題寬度
            int titleHeight = 65; // 標題高度

            // 設定標題及權限工具列
            var headerLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                ColumnCount = 2,
                RowCount = 1,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            // 設定標題與工具列的欄距
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, titleWidth));
            headerLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // 設定標題
            lblTitle = new Label
            {
                Text = _progName,
                AutoSize = false,
                Width = titleWidth,
                Font = new Font("微軟正黑體", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
                Margin = new Padding(0, 20, 80, 0)
            };

            PermissionBar = new PermissionToolBar();

            // 分別放入兩欄
            headerLayout.Controls.Add(lblTitle, 0, 0);
            headerLayout.Controls.Add(PermissionBar, 1, 0);

            _contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(10),
                BackColor = Color.Transparent // 讓設計階段可視
            };

            this.Controls.Add(_contentPanel);
            this.Controls.Add(headerLayout);

            // ===== 外層 layout，放 header 和內容區（兩列） =====
            //var outerLayout = new TableLayoutPanel
            //{
            //    Dock = DockStyle.Fill,
            //    RowCount = 2,
            //    ColumnCount = 1
            //};

            //outerLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, titleHeight)); // 標題高度
            //outerLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));  // 主內容 - 填滿

            //outerLayout.Controls.Add(headerLayout, 0, 0);    // 標題
            //outerLayout.Controls.Add(_internalContentHost, 0, 1);    // 子畫面只能放這裡

            //Controls.Add(outerLayout);
        }

        /// <summary>
        /// 將所有元件插入contentPanel
        /// </summary>
        //public void OnLoadContent()
        //{
        //    if (this.DesignMode) return; // 設計階段不要動手

        //    var toMove = Controls
        //        .Cast<Control>()
        //        .Where(ctrl =>
        //            ctrl != contentPanel &&         // 不要搬自己
        //            ctrl.Parent != contentPanel && // 不要搬已經在 contentPanel 裡的
        //            !(ctrl is TableLayoutPanel))   // 不搬 LayoutPanel 本身（避免循環）
        //        .ToList();

        //    foreach (var ctrl in toMove)
        //    {
        //        Controls.Remove(ctrl);
        //        contentPanel.Controls.Add(ctrl);
        //    }
        //}

        /// <summary>
        /// 載入子類別時，請覆寫此方法以載入資料
        /// </summary>
        public virtual void LoadData() { }
    }
}
