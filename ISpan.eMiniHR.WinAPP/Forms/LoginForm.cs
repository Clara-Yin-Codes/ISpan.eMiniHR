using ISpan.eMiniHR.DataAccess.DapperRepositories;
using ISpan.eMiniHR.WinApp.Properties;
using ISpan.eMiniHR.WinApp.Services;
using System.Drawing.Drawing2D;
using static ISpan.eMiniHR.WinApp.Services.ErrorHandler;
using Timer = System.Windows.Forms.Timer;

namespace ISpan.eMiniHR.WinApp.Forms
{
	public partial class LoginForm : Form
	{
		private bool isPasswordVisible = false; // 用來控制密碼是否顯示為明文
		private PictureBox logoBox = new PictureBox(); // 用來存放背景Logo的PictureBox

		public LoginForm()
		{
			InitializeComponent();
		}

		private void LoginForm_Load(object sender, System.EventArgs e)
		{
			InitFormStyle(); // 初始化表單樣式
			InitPasswordBox(); // 初始化密碼框樣式
			InitEyeToggle(); // 初始化眼睛圖示
			InitLogo(); // 初始化背景Logo
		}

		#region 表單設計與設定
		/// <summary>
		/// 初始表單樣式設定
		/// </summary>
		private void InitFormStyle()
		{
			// 停用表單放大按鈕
			MaximizeBox = false;
			MaximumSize = Size; // 禁止放大視窗
			MinimumSize = Size; // 禁止縮小視窗

			// 設定無邊框，否則無法呈現圓角
			FormBorderStyle = FormBorderStyle.None;
			StartPosition = FormStartPosition.CenterScreen;

			// 初始圓角 + 監聽視窗大小改變
			SetFormRound(50);
			Resize += (s, ev) => SetFormRound(50);

			#if DEBUG
						// 在開發模式下，顯示測試按鈕
						testBtn.Visible = true;
			#elif RELEASE
							// 在正式模式下，隱藏測試按鈕
							testBtn.Visible = false;
			#endif
		}

		/// <summary>
		/// 密碼框初始化設定
		/// </summary>
		private void InitPasswordBox()
		{
			txtPassword.UseSystemPasswordChar = true;
		}

		/// <summary>
		/// 眼睛圖示初始化設定
		/// </summary>
		private void InitEyeToggle()
		{
			picEyeToggle.Image = Resources.eye_closed;
			picEyeToggle.SizeMode = PictureBoxSizeMode.StretchImage; // 設定圖示大小模式為拉伸
			picEyeToggle.Cursor = Cursors.Hand; // 設定鼠標樣式為手形
			picEyeToggle.Click += TogglePasswordVisibility; // 點擊事件切換密碼顯示狀態
		}

		/// <summary>
		/// 顯示或隱藏密碼
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TogglePasswordVisibility(object? sender, EventArgs e)
		{
			isPasswordVisible = !isPasswordVisible;
			txtPassword.UseSystemPasswordChar = !isPasswordVisible; // 切換密碼顯示狀態

			// 專案資源中的 eye_open 和 eye_closed 圖示
			picEyeToggle.Image = isPasswordVisible ? Resources.eye_open : Resources.eye_closed;
		}
		#endregion

		#region 背景Logo和動畫
		/// <summary>
		/// 初始化背景Logo
		/// </summary>
		private void InitLogo()
		{
			if (Controls.ContainsKey("logoBox")) return;

			// 設定視窗背景Logo
			logoBox = new PictureBox
			{
				Name = "logoBox",
				SizeMode = PictureBoxSizeMode.Zoom,
				BackColor = Color.Transparent,
				Size = new Size(200, 200),
				Location = new Point(Width / 2 - 100, 20)
			};

			Image gifImage = Resources.eMiniHRlogo_AddSize;
			logoBox.Image = gifImage;
			HandleGifAnimation(gifImage);

			Controls.Add(logoBox);
		}

		/// <summary>
		/// 處理 GIF 動畫顯示
		/// </summary>
		/// <param name="gifImage"></param>
		private void HandleGifAnimation(Image gifImage)
		{
			if (!ImageAnimator.CanAnimate(gifImage)) return;

			Timer stopTimer = new Timer { Interval = 5000 };
			stopTimer.Tick += (s, e) =>
			{
				stopTimer.Stop();
				ImageAnimator.UpdateFrames(gifImage);
				Bitmap currentFrame = new Bitmap(logoBox.Width, logoBox.Height);
				using (Graphics g = Graphics.FromImage(currentFrame))
				{
					g.DrawImage(gifImage, new Rectangle(Point.Empty, logoBox.Size));
				}

				ImageAnimator.StopAnimate(gifImage, null);
				logoBox.Paint -= LogoBox_Paint;
				logoBox.Image = currentFrame;
			};

			logoBox.Paint += LogoBox_Paint;
			ImageAnimator.Animate(gifImage, (s, e) => logoBox.Invalidate());
			stopTimer.Start();
		}

		/// <summary>
		/// 設定 LogoBox 的繪製事件，確保 GIF 動畫能正確顯示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LogoBox_Paint(object? sender, PaintEventArgs e)
		{
			if (logoBox.Image != null)
			{
				ImageAnimator.UpdateFrames(logoBox.Image);
				e.Graphics.DrawImage(logoBox.Image, new Rectangle(Point.Empty, logoBox.Size));
			}
		}
		#endregion

		#region 視窗圈角
		/// <summary>
		/// raphicsPath 用來設定視窗圓角
		/// </summary>
		/// <param name="radius">圓角</param>
		private void SetFormRound(int radius)
		{
			GraphicsPath path = new GraphicsPath();
			path.StartFigure();
			path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
			path.AddArc(new Rectangle(Width - radius, 0, radius, radius), 270, 90);
			path.AddArc(new Rectangle(Width - radius, Height - radius, radius, radius), 0, 90);
			path.AddArc(new Rectangle(0, Height - radius, radius, radius), 90, 90);
			path.CloseFigure();
			Region = new Region(path);
		}
		#endregion

		/// <summary>
		/// 關閉主表單時，確保整個應用程式結束
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		private void testBtn_Click(object sender, EventArgs e)
		{
			var user = LoginRepository.GetLogin(null, null, true);

			if (user == null)
			{
				MessageBox.Show("帳號或密碼錯誤", "登入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 登入成功，切換畫面
			LoginSession.SetLoginUser(user);

			// 隱藏目前畫面（例如 MainForm）
			Hide();

			// 回到登入畫面
			new MainForm().Show();
		}

		private void loginBtn_Click(object sender, EventArgs e)
		{
			try
			{
				string account = txtAccunt.Text.Trim();
				string password = txtPassword.Text;

				// 驗證帳號密碼是否為空
				if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(password))
				{
					MessageBox.Show("請輸入帳號與密碼", "登入失敗", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				var user = LoginRepository.GetLogin(account, password);

				if (user == null)
				{
					MessageBox.Show("帳號或密碼錯誤", "登入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
					txtPassword.Text = string.Empty;
					return;
				}

				// 登入成功，切換畫面
				LoginSession.SetLoginUser(user);
				Hide();
				new MainForm().Show();
			}
			catch (Exception ex)
			{
				// 錯誤處理
				HandleErrorMsg(ex);
				return;
			}
		}

		private void txtAccunt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				txtPassword.Focus();
			}
		}

		private void txtPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = true;  // 阻止其他控制項處理
				e.SuppressKeyPress = true;  // 阻止系統發出聲音
				loginBtn_Click(sender, e);  // 執行按鈕的 Click 事件
			}
		}
	}
}
