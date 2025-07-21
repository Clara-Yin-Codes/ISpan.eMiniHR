using ISpan.eMiniHR.WinApp.Helper;

namespace ISpan.eMiniHR.WinApp.Services
{
    /// <summary>
    /// 動態菜單邏輯
    /// </summary>
    internal class MenuService
    {
        private static TabControl _tabControlMain = new TabControl();
        private static Panel _panelSidebar;

        /// <summary>
        /// 建立Manu與Button
        /// </summary>
        /// <param name="panelSidebar"></param>
        /// <param name="tabControl"></param>
        public static void CreateMenuWithBtn(Panel panelSidebar, TabControl tabControl)
        {
            _tabControlMain = tabControl;
            panelSidebar.Controls.Clear();
            panelSidebar.AutoScroll = true; // 若總高度超出可滾動
            CreateToggleBtn(panelSidebar); // 建立縮放左方清單按鈕

            // 依 ProgSysCode 群組
            var groupedItems = LoginSession.MenuItems
                .GroupBy(m => m.SystemName )
                .OrderByDescending(g => g.Key); // 可依需求排序群組

            int currentTop = 0; // 控制位置
            int buttonHeight = 40;
            bool initialVisible = false; // 控制菜單初始展開狀態

            // 為了重新排版，記錄所有群組元件
            List<(Button GroupButton, Panel SubPanel)> layoutList = new List<(Button, Panel)>();

            foreach (var group in groupedItems)
            {
                // 群組標題按鈕
                Button groupButton = new Button
                {
                    Text = $"▲  {group.Key}", // 群組名稱
                    Width = panelSidebar.Width,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Height = 30,
                    Top = currentTop,
                    Font = new Font("微軟正黑體", 10, FontStyle.Bold),
                    BackColor = Color.LightGray, // 淺灰色背景
                    FlatStyle = FlatStyle.Popup, // 平面風格
                    Tag = initialVisible // 用來儲存展開狀態，初始顯示
                };
                panelSidebar.Controls.Add(groupButton);

                // 子項目容器 Panel
                Panel subPanel = new Panel
                {
                    Width = panelSidebar.Width,
                    Height = group.Count() * buttonHeight, // 實際計算高度
                    Top = currentTop,
                    AutoScroll = true, // 若太多按鈕就出現卷軸
                    AutoSize = false,
                    BorderStyle = BorderStyle.None,
                    Visible = initialVisible, // 初始顯示
                    Tag = $"subPanel_{group.Key}"
                };

                int btnIndex = 0;
                foreach (var item in group)
                {
                    Button btn = new Button
                    {
                        Text = "　" + item.ProgName,
                        Width = panelSidebar.Width,
                        Height = buttonHeight,
                        Top = btnIndex * buttonHeight, // 設定按鈕的 Top
                        TextAlign = ContentAlignment.MiddleLeft, // 按鈕文字靠左對齊
                        Font = new Font("微軟正黑體", 11),
                        Tag = item.ProgSysId, // 用來識別是哪個項目
                        FlatStyle = FlatStyle.Standard, // 浮凸
                        BackColor = SystemColors.Control, // 灰底
                        ForeColor = Color.Black, // 黑字
                        Cursor = Cursors.Hand
                    };

                    // 滑鼠移入 → 藍底白字
                    btn.MouseEnter += (s, ev) =>
                    {
                        btn.BackColor = Color.FromArgb(92, 173, 255); // 藍底
                        btn.ForeColor = Color.White; // 白字
                    };

                    // 滑鼠移出 → 恢復原樣
                    btn.MouseLeave += (s, ev) =>
                    {
                        btn.BackColor = SystemColors.Control; // 灰底
                        btn.ForeColor = Color.Black; // 黑字
                    };

                    btn.Click += SidebarButton_Click;

                    subPanel.Controls.Add(btn);
                    btnIndex++; // 下一顆按鈕往下排
                }

                // 加入子 Panel 到主面板
                panelSidebar.Controls.Add(subPanel);
                layoutList.Add((groupButton, subPanel));
            }

            // 初始排版一次
            Relayout(panelSidebar, layoutList);

            // 加入點擊事件：切換顯示 + 重新排版
            foreach (var (groupButton, subPanel) in layoutList)
            {
                groupButton.Click += (s, e) =>
                {
                    bool isExpanded = (bool)groupButton.Tag;
                    groupButton.Tag = !isExpanded;
                    groupButton.Text = isExpanded ? $"▲  {groupButton.Text.Substring(3)}" : $"▼  {groupButton.Text.Substring(3)}"; // 切換箭頭方向
                    subPanel.Visible = !isExpanded;

                    Relayout(panelSidebar, layoutList); // 重新排版所有群組的 Top
                };
            }
        }

        /// <summary>
        /// 排版方法：重新排列所有群組的 Top
        /// </summary>
        /// <param name="container"></param>
        /// <param name="layoutList"></param>
        private static void Relayout(Panel container, List<(Button GroupButton, Panel SubPanel)> layoutList)
        {
            int currentTop = 0;
            foreach (var (groupButton, subPanel) in layoutList)
            {
                groupButton.Top = currentTop;
                currentTop += groupButton.Height;

                if (subPanel.Visible)
                {
                    subPanel.Top = currentTop;
                    currentTop += subPanel.Height;
                }
                else
                {
                    subPanel.Top = currentTop;
                }
            }
        }

        /// <summary>
        /// 建立左方側邊欄的縮放按鈕
        /// </summary>
        /// <param name="panelSidebar"></param>
        private static void CreateToggleBtn(Panel panelSidebar)
        {
            Button btnToggle = new Button
            {
                Name = "btnToggle",
                Text = "<<",
                Width = 40,
                Height = 80,
                TextAlign = ContentAlignment.BottomCenter, // 文字置中
                Font = new Font("微軟正黑體", 10, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right
            };

            _panelSidebar = panelSidebar; // 儲存側邊欄參考

            btnToggle.FlatAppearance.BorderSize = 0;
            btnToggle.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnToggle.FlatAppearance.MouseDownBackColor = Color.Transparent;

            // 設定按鈕位置
            btnToggle.Location = new Point(
                panelSidebar.ClientSize.Width - btnToggle.Width,
                panelSidebar.ClientSize.Height - btnToggle.Height - 20
            );

            // 當側邊欄大小改變時，調整按鈕位置（每次重算）
            panelSidebar.Resize += (s, e) =>
            {
                int newWidth = panelSidebar.ClientSize.Width - btnToggle.Width;
                int newHeight = panelSidebar.ClientSize.Height - btnToggle.Height - 20;

                btnToggle.Location = new Point(newWidth, newHeight);
            };

            // 按鈕點擊事件：切換側邊欄展開或收起
            btnToggle.Click += (s, e) =>
            {
                bool isExpanded = _panelSidebar.Width > 50;

                _panelSidebar.Width = isExpanded ? 40 : 127;
                btnToggle.Text = isExpanded ? "展\n開\n功\n能" : "<<";

                foreach (Control ctrl in _panelSidebar.Controls)
                    ctrl.Visible = ctrl == btnToggle || !isExpanded;
            };

            panelSidebar.Controls.Add(btnToggle); // 
            panelSidebar.Controls.SetChildIndex(btnToggle, 0); // 確保在上面
        }

        /// <summary>
        /// 菜單按鈕點擊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SidebarButton_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            string progId = clickedBtn.Tag.ToString(); // 取得按鈕的 Tag 屬性

            TabStyleHelper.ShowPageByCode(progId, _tabControlMain);
        }
    }
}
