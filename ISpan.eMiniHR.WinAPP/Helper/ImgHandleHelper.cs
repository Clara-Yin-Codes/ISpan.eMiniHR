namespace ISpan.eMiniHR.WinApp.Helper
{
	/// <summary>
	/// 圖片處理
	/// </summary>
	public static class ImgHandleHelper
	{
		/// <summary>
		/// 檔名處理，並複製至新路徑
		/// </summary>
		/// <param name="newFilePath">新路徑</param>
		/// <returns></returns>
		public static string SaveImageToProjectFolder(string imgDir, string sourcePath)
		{
			// 使用 Guid 作為唯一檔名
			string newFileName = $"{Guid.NewGuid():N}{Path.GetExtension(sourcePath)}";
			string newPath = Path.Combine(imgDir, newFileName);

			// 複製圖片
			File.Copy(sourcePath, newPath, overwrite: true); // false: 不覆蓋

			return newPath; // 只回傳檔名

			//// 找出目前最大流水號（檔名格式：EmpId-001.jpg）
			//var existingFiles = Directory.GetFiles(imgDir, $"{empId}-*.jpg");

			//int maxNo = 0;
			//foreach (var file in existingFiles)
			//{
			//	string fileName = Path.GetFileNameWithoutExtension(file); // 例：E001-003
			//	string[] parts = fileName.Split('-');
			//	if (parts.Length == 2 && int.TryParse(parts[1], out int no))
			//	{
			//		if (no > maxNo) maxNo = no;
			//	}
			//}

			//// 新圖片編號
			//int newNo = maxNo + 1;
			//string newFileName = $"{empId}-{newNo:000}.jpg";
			//string newPath = Path.Combine(imgDir, newFileName);
		}

		/// <summary>
		/// 啟用雙緩衝 (DoubleBuffered)
		/// </summary>
		/// <param name="control"></param>
		public static void EnableDoubleBuffering(Control control)
		{
			Type dgvType = control.GetType();
			System.Reflection.PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
				System.Reflection.BindingFlags.Instance |
				System.Reflection.BindingFlags.NonPublic);
			pi?.SetValue(control, true, null);

			// 方法二
			/*
			 public class DoubleBufferedPanel : Panel
			{
				public DoubleBufferedPanel()
				{
					this.DoubleBuffered = true;
					this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
					this.UpdateStyles();
				}
			}
			 */
		}

		/// <summary>
		/// 設定圖片功能按鈕樣式
		/// </summary>
		/// <param name="btnImg"></param>
		/// <param name="img"></param>
		public static void SetBtnImgIcon(Button btnImg, Image img)
		{
			btnImg.FlatAppearance.BorderSize = 0;
			btnImg.FlatStyle = FlatStyle.Flat;

			Image resized = new Bitmap(img, new Size(20, 20));
			btnImg.Image = resized;
			btnImg.Size = new Size(30, 30);
			btnImg.ImageAlign = ContentAlignment.MiddleLeft;
			//btnImg.Text = "刪除";
			//btnImg.TextAlign = ContentAlignment.MiddleRight;
			//btnImg.TextImageRelation = TextImageRelation.ImageBeforeText;
		}

		/// <summary>
		/// 圖片拖移錯誤處理
		/// </summary>
		public static void DebugImageState(PictureBox img)
		{
			if (img.Image == null)
			{
				MessageBox.Show("[DEBUG] 圖片被清掉了！");
			}
			else
			{
				MessageBox.Show($"[DEBUG] 圖片仍在，大小：{img.Image.Width} x {img.Image.Height}");
				MessageBox.Show($"[DEBUG] 圖片位置：{img.Location}");
			}
		}

		/// <summary>
		/// 設定圖片放大縮小
		/// </summary>
		public static void SetImgZoom(TrackBar trackZoom, PictureBox picImg)
		{
			decimal zoom = trackZoom.Value / 100m; // 例如 150 ➜ 1.5 倍

			int newWidth = (int)(picImg.Image.Width * zoom);
			int newHeight = (int)(picImg.Image.Height * zoom);

			picImg.Width = newWidth;
			picImg.Height = newHeight;
			picImg.SizeMode = PictureBoxSizeMode.StretchImage;
		}
	}
}
