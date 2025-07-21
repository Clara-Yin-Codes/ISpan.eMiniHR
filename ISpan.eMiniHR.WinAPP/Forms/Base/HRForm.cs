using ISpan.eMiniHR.WinApp.Components;
using ISpan.eMiniHR.WinApp.Interfaces;
using ISpan.eMiniHR.WinApp.Services;
using System.ComponentModel;

namespace ISpan.eMiniHR.WinApp.Forms.Base
{
	public partial class HRForm : UserControl, IPermissionButtonHost
    {
		public PermissionToolBar PermissionBar { get; private set; }

		public HRForm()
		{
			InitializeComponent();

			// 按鈕初始化
			PermissionBar = new PermissionToolBar
			{
				Dock = DockStyle.Fill, // 或可視需求改成 Top, None, etc.
				Margin = new Padding(0)
			};

            PermissionBar.PermissionButtonClicked += PermissionBar_PermissionButtonClicked;

            // 加入到指定容器（TableLayoutPanel 的第1列第2欄）
            headerLayout.Controls.Add(PermissionBar, 1, 0);
		}

        private void HRForm_Load(object sender, EventArgs e)
		{
			ShowSubPage();
		}

		/// <summary>
		/// 顯示子頁面
		/// </summary>
		public void ShowSubPage()
		{
			var progs = LoginSession.MenuItems.FirstOrDefault(a => a.ProgSysId == _progSysId);

			string projectName = "ISpan.eMiniHR.WinApp.Forms";
			string fullTypeName = $"{projectName}.{progs.ProgId}";

			Type pageType = Type.GetType(fullTypeName);

			if (pageType == null)
			{
				fullTypeName = $"{projectName}.Base.UnderMaintenance";

				pageType = Type.GetType(fullTypeName);
			}

			UserControl page = Activator.CreateInstance(pageType) as UserControl;

			page.Dock = DockStyle.Fill;

			contentPanel.Controls.Add(page);

            // 若子頁面實作了 IPageWithPermission，則綁定事件
            if (page is IPageWithPermission permissionAwarePage)
            {
                PermissionBar.PermissionButtonClicked += (s, btn) =>
                {
                    permissionAwarePage.OnPermissionAction(btn.Text);
                };
            }
        }

        #region 載入權限工具列
        public void LoadPermissionBar()
		{
			PermissionBar?.LoadPermission(_progSysId);
		}

        private void PermissionBar_PermissionButtonClicked(object? sender, Button clickedBtn)
        {
        }
		
		/// <summary>
		/// 顯示可用按鈕
		/// </summary>
		/// <param name="activeTexts"></param>
        public void SetActivePermissionByTexts(IEnumerable<string> activeTexts)
        {
            foreach (var btn in PermissionBar.Buttons)
            {
                if (activeTexts.Contains(btn.Text))
                {
                    btn.BackColor = Color.White;
                }
                else
                {
                    btn.BackColor = Color.Gray;
                }
            }
        }

        /// <summary>
        /// 限制按鈕為可用狀態，根據按鈕文字
        /// </summary>
        /// <param name="texts"></param>
        public void SetButtonEnabledByTexts(IEnumerable<string> texts)
        {
            foreach (var btn in PermissionBar.Buttons)
            {
                // 比對 Tag 或 Text（通常建議用 Tag，比較穩定）
                btn.Enabled = texts.Contains(btn.Tag?.ToString());
            }
        }
        #endregion

        private string _progSysId = string.Empty;
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
						PermissionBar?.LoadPermission(_progSysId);

						var menu = LoginSession.MenuItems.FirstOrDefault(a => a.ProgSysId == _progSysId);

						if (lblTitle != null) lblTitle.Text = menu?.ProgName ?? "未命名功能";
					}
				}
			}
		}
	}
}
