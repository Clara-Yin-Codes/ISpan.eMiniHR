using ISpan.eMiniHR.WinApp.Forms.Base;
using ISpan.eMiniHR.WinApp.Services;
using static ISpan.eMiniHR.WinApp.Services.ErrorHandler;

namespace ISpan.eMiniHR.WinApp.Helper
{
    /// <summary>
    /// 切換頁籤邏輯
    /// </summary>
    internal class TabStyleHelper
    {
        /// <summary>
        /// 套用自訂 TabControl 樣式（含 Padding 與 DrawMode）
        /// </summary>
        public static void ApplyCustomStyle(TabControl tabControl)
        {
            tabControl.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl.Padding = new Point(20, 5);

            // 調整每個 tab 的寬高
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.ItemSize = new Size(150, 25);

            // 避免重複掛載事件
            tabControl.DrawItem -= tabControl_DrawItem; // 避免重複掛載
            tabControl.DrawItem += tabControl_DrawItem;
        }

        /// <summary>
        /// 自訂繪製 Tab 頁（含文字與關閉按鈕）
        /// </summary>
        private static void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabRect = tabControl.GetTabRect(e.Index);
            tabRect.Inflate(-2, -2);

            Font drawFont = new Font("微軟正黑體", tabPage.Font.Size + 2, FontStyle.Regular);

            bool isSelected = e.Index == tabControl.SelectedIndex;

            // 畫底色（被選中 → 淺藍色，未選中 → 不上色）
            if (isSelected)
            {
                using (Brush backgroundBrush = new SolidBrush(Color.LightSkyBlue))
                {
                    e.Graphics.FillRectangle(backgroundBrush, tabRect);
                }
            }

            // 畫文字（居中）
            TextRenderer.DrawText(
                e.Graphics,
                tabPage.Text,
                drawFont,
                tabRect,
                Color.Black,
                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

            // 畫關閉按鈕（x）
            Rectangle closeButton = new Rectangle(
                tabRect.Right - 15,
                tabRect.Top + (tabRect.Height - 15) / 2,
                15, 15);
            e.Graphics.DrawString("x", e.Font, Brushes.Black, closeButton.Location);
        }

		/// <summary>
		/// 顯示頁面
		/// </summary>
		/// <param name="progId"></param>
		public static void ShowPageByCode(string progSysId, TabControl tabControlMain)
		{
            try
            {
                var progs = LoginSession.MenuItems.FirstOrDefault(a => a.ProgSysId == progSysId);

                string projectName = "ISpan.eMiniHR.WinApp.Forms"; // 專案路徑
                string baseTypeName = $"{projectName}.Base"; // 基底
                string formName = "HRForm"; // 標題與工具列設定
                string subTypeName = $"{projectName}.{progs.ProgId}"; // 實際UserControl

                // 嘗試取得子畫面型別（程式頁面）
                var pageType = Type.GetType(subTypeName);

                //throw new Exception(typeof(EmployeeInfo).AssemblyQualifiedName); // 檢查傳入的型別

                if (pageType == null)
                {
                    formName = "UnderMaintenance";
                }

                var fullPageType = Type.GetType($"{baseTypeName}.{formName}");

                UserControl page = Activator.CreateInstance(fullPageType) as UserControl;
				page.Dock = DockStyle.Fill;

				if (page is HRForm hrPage && progs != null)
                {
                    hrPage.ProgSysId = progs.ProgSysId; // 設定程式 ID
                    hrPage.LoadPermissionBar();         // 載入權限工具列
                }

                ShowTabPageByCode(progSysId, page, tabControlMain); // 顯示頁面分頁籤
            }
            catch (Exception ex)
            {
				// 錯誤處理
				HandleErrorMsg(ex);
				return;
			}
		}

		/// <summary>
		/// 顯示頁面
		/// </summary>
		/// <param name="progId"></param>
		public static void ShowPageByCode2(string progSysId, TabControl tabControlMain)
        {
            var progs = LoginSession.MenuItems.FirstOrDefault(a => a.ProgSysId == progSysId);

            string projectName = "ISpan.eMiniHR.WinApp.Forms";
            string fullTypeName = $"{projectName}.{progs.ProgId}";

            Type pageType = Type.GetType(fullTypeName);

            if (pageType == null)
            {
                fullTypeName = $"{projectName}.Base.UnderMaintenance";

                pageType = Type.GetType(fullTypeName);
            }

            UserControl page = Activator.CreateInstance(pageType) as UserControl;

            // 如果該頁面繼承 HR，就設定中文標題
            if (page is HR hrPage)
            {
                hrPage.ProgSysId = progs.ProgSysId; // 設定程式 ID
                hrPage.LoadPermissionBar(); // 載入權限工具列
            }

            ShowTabPageByCode(progSysId, page, tabControlMain); // 顯示頁面分頁籤
        }

        /// <summary>
        /// 建立頁籤
        /// </summary>
        /// <param name="progId"></param>
        /// <param name="progName"></param>
        /// <param name="page"></param>
        public static void ShowTabPageByCode(string progId, UserControl page, TabControl tabControlMain)
        {
            try
            {
                // 判斷是否已有相同的 tab
                foreach (TabPage existingTab in tabControlMain.TabPages)
                {
                    if (existingTab.Name == progId)
                    {
                        tabControlMain.SelectedTab = existingTab;
                        return;
                    }
                }

                var progs = LoginSession.MenuItems.FirstOrDefault(a => a.ProgSysId == progId);
                // 建立 TabPage
                TabPage tab = new TabPage
                {
                    Name = progId,
                    Text = progs.ProgName // 建立 Dictionary 或用 LINQ 查
                };

                // 建立 panelMain 放 UserControl
                Panel panelMain = new Panel
                {
                    Name = "panelMain",
                    Dock = DockStyle.Fill,
                    BackColor = Color.Transparent
                };

                tab.Controls.Add(panelMain);

                panelMain.Controls.Add(page);

                LockPanelControls(panelMain); // 鎖定拖曳

                // 加入 Tab 並選取
                tabControlMain.TabPages.Add(tab);
                tabControlMain.SelectedTab = tab;

                tabControlMain.MouseUp -= TabControlMain_MouseUp; // 避免註冊多次
                tabControlMain.MouseUp += TabControlMain_MouseUp;
            }
            catch (Exception ex)
            {
                // 錯誤處理
                HandleErrorMsg(ex);
                return;
            }
        }

        /// <summary>
        /// 鎖定 Panel 裡的所有控制項，防止拖曳
        /// </summary>
        /// <param name="parent"></param>
        private static void LockPanelControls(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                // 禁用拖曳相關屬性
                c.AllowDrop = false;

                // 遞迴處理子控制項
                if (c.HasChildren) LockPanelControls(c);
            }
        }

        /// <summary>
        /// 移除頁籤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void TabControlMain_MouseUp(object sender, MouseEventArgs e)
        {
            TabControl tabControl = sender as TabControl;

            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                Rectangle tabRect = tabControl.GetTabRect(i);
                Rectangle closeButton = new Rectangle(tabRect.Right - 15, tabRect.Top + (tabRect.Height - 15) / 2, 15, 15);

                if (closeButton.Contains(e.Location))
                {
                    tabControl.TabPages.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
