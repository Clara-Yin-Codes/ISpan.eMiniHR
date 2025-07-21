using ISpan.eMiniHR.DataAccess.Models;
using ISpan.eMiniHR.WinApp.Helper;
using ISpan.eMiniHR.WinApp.Services;
using static ISpan.eMiniHR.WinApp.Services.MenuService;

namespace ISpan.eMiniHR.WinApp.Forms
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			SetFormStyle(); // 設定表單框架

			// 設定 分頁 TabControl
			TabStyleHelper.ApplyCustomStyle(tabControlMain);

			// 設定登出與狀態列
			FooterInfoProvider.CreateFooterWithLogout(this);

			// 建立菜單
			LoadSidebarMenu();
		}

		public void SetFormStyle()
		{
			// 設定主表單框架
			FormBorderStyle = FormBorderStyle.None; // 隱藏邊框
			MaximumSize = new Size(0, 0); // 無限制
			MinimumSize = new Size(1200, 800); // 最小尺寸限制

			// 自訂表單位置為置中
			StartPosition = FormStartPosition.Manual;

			int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
			int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

			int formWidth = Width;
			int formHeight = Height;

			int x = (screenWidth - formWidth) / 2;
			int y = (screenHeight - formHeight) / 2;

			Location = new Point(x, y);
		}

		/// <summary>
		/// 設定菜單清單
		/// </summary>
		private void LoadSidebarMenu()
		{
			var repo = new ProgramsConfigRepository();
			var user = LoginSession.User;
			List<ProgramsConfigDto> menuItems = new List<ProgramsConfigDto>();
			if (user.IsAdmin)
			{
				menuItems = repo.GetAllMenu(null);
			}
			else
			{
				var arr = user.Permissions.Select(a => a.ProgSysId).ToList();
				if (arr != null)
				{
					menuItems = repo.GetAllMenu(arr);
				}
			}

			if (menuItems.Count > 0) LoginSession.SetMenuItems(menuItems);

			// 建立菜單按鈕
			CreateMenuWithBtn(panelSidebar, tabControlMain);
		}

		/// <summary>
		/// 關閉主表單時，確保整個應用程式結束
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			LoginSession.Logout();
			Application.Exit();
		}
	}
}
