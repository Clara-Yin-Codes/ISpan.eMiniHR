using ISpan.eMiniHR.DataAccess.DapperRepositories;
using ISpan.eMiniHR.DataAccess.EfRepositories;
using ISpan.eMiniHR.DataAccess.Models;
using ISpan.eMiniHR.WinApp.Helper;
using ISpan.eMiniHR.WinApp.Interfaces;
using ISpan.eMiniHR.WinApp.Services;
using QuestPDF.Fluent;
using System.Diagnostics;

namespace ISpan.eMiniHR.WinApp.Forms
{
	public partial class EmployeeInfo : UserControl, IFormBindable, IPageWithPermission
	{
		public EmployeeInfo()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 員工基本資料
		/// </summary>
		private IEnumerable<EmployeeDto> _employeeList = Enumerable.Empty<EmployeeDto>(); // 更保險，預設為空集合
		BindingSource deptBS = new BindingSource(); // 部門資料綁定來源
		string _currentAction = "查詢"; // 當前操作狀態
		string[] actionArr = new[] { "查詢", "新增", "編輯", "取消", "儲存", "刪除", "匯出" }; // 權限按鈕名稱陣列

		private void EmployeeInfo_Load(object sender, EventArgs e)
		{
			Query(); // 查詢清單
			SetFormUI(); // 設定表單樣式
			SetControlsReadOnly(true); // 設定控制項唯讀狀態
			InitActionHandler(); // 初始化操作處理

			RegisterImageDragEvents(); // 照片拖移事件
			ImgHandleHelper.EnableDoubleBuffering(pnlImg); // 啟用雙緩衝 (DoubleBuffered)

			// 照片控鍵設定
			ImgHandleHelper.SetBtnImgIcon(btnImgDelete, Properties.Resources.icon_cancel);
			ImgHandleHelper.SetBtnImgIcon(btnImgDownload, Properties.Resources.icon_export);
		}

		#region 按鈕事件處理
		/// <summary>
		/// 員工清單調整大小事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void EmployeeInfo_Resize(object sender, EventArgs e)
		{
			ControlHelper.SetGridViewColumnSize(dgvEmployees); // 調整清單欄位大小
			splitContainer1.SplitterDistance = 210; // 設定分割線位置
		}

		private void dgvEmployees_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			var row = dgvEmployees.Rows[e.RowIndex];
			if (row.DataBoundItem is EmployeeDto emp)
			{
				if (emp.ResignDate != null)
				{
					//row.DefaultCellStyle.ForeColor = Color.Gray;
					row.DefaultCellStyle.BackColor = Color.LightGray;
					//row.DefaultCellStyle.Font = new Font(dgvEmployees.Font, FontStyle.Italic); // 斜體
				}
			}
		}
		#endregion

		#region 元件設定
		/// <summary>
		/// 設定UI樣式
		/// </summary>
		public void SetFormUI()
		{
			SetGridView(); // 設定清單樣式
			SetCboItems(); // 設定下拉選單
		}

		/// <summary>
		/// 設定 DataGridView 的樣式
		/// </summary>
		public void SetGridView()
		{
			var columnDefs = new List<(string, string)>
				{
					("EmpId", "員工編號"),
					("EmpNm", "姓名"),
					("DepName", "部門")
				};

			ControlHelper.SetGridView(dgvEmployees, columnDefs, employee_BindingSource);
		}

		/// <summary>
		/// 下拉選單項目設定
		/// </summary>
		public void SetCboItems()
		{
			var emps = EmployeeQueryRepository.GetEmployees();
			ControlHelper.BindMultipleComboBoxes(employee_BindingSource, 1, new[]
			{
				(cboShift, ShiftsRepository.GetShifts(), "ShiftName", "ShiftCode", "Shift"), // 班別
                (cboDepId, deptBS.DataSource, "FormatDept", "DepId", "DepId"), // 部門
                (cboJobLevel, JobGradesRepository.GetJobGrades(), "JobLevelName", "JobLevelCode", "JobLevel"), // 職等
                (cboEmployeeType, EmployeeTypesRepository.GetEmployeeTypes(), "TypeName", "TypeCode", "EmployeeType") // 員工類別
            });

			ControlHelper.BindMultipleComboBoxes(employee_BindingSource, 2, new[]
			{
				(cboMgrId, (object)emps, "EmpNm", "EmpId", "MgrId"),
				(cboReviser, (object)LoginRepository.GetAccounts().ToList(), "AccountName", "Account", "Reviser")
			});
		}
		#endregion

		#region 元件事件處理
		/// <summary>
		/// 離職設定
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chkIsResigned_CheckedChanged(object sender, EventArgs e)
		{
			employee_BindingSource.EndEdit(); // 結束編輯

			dateResignDate.Visible = chkIsResigned.Checked; // 離職日期顯示或隱藏
			lblResignReason.Visible = chkIsResigned.Checked;
			txtResignReason.Visible = chkIsResigned.Checked;
		}
		#endregion

		#region 資料來源設定
		/// <summary>
		/// 資料庫異動後，重新查詢清單
		/// </summary>
		/// <returns></returns>
		public EmployeeDto? Current()
		{
			return employee_BindingSource.Current as EmployeeDto;
		}

		/// <summary>
		/// 資料綁定
		/// </summary>
		private void BindingSourceRestBinding()
		{
			employee_BindingSource.EndEdit(); // 結束編輯
											  //if (employee_BindingSource.Current != null)
											  //{
											  //    employee_BindingSource.ResetCurrentItem(); // 只有有資料時才刷新
											  //}
			employee_BindingSource.ResetBindings(false);
			//employeeD_BindingSource.ResetBindings(false); // 明細寫法
		}

		/// <summary>
		/// 取得員工資料
		/// </summary>
		/// <returns></returns>
		public IEnumerable<EmployeeDto> GetEmployees()
		{
			try
			{
				return EmployeeQueryRepository.GetEmployees();
			}
			catch (Exception ex)
			{
				ErrorHandler.HandleErrorMsg(ex);
				return null;
			}
		}
		#endregion

		#region 工具列操作實作

		private FormActionHandler<EmployeeDto> _actionHandler;

		private void InitActionHandler()
		{
			_actionHandler = new FormActionHandler<EmployeeDto>(
				employee_BindingSource,
				() => Current(),
				() => InitEdit(), // 編輯狀態預設
				new[] { "Reviser", "ReviseDate" }, // 編輯狀態預設欄位
				isReadOnly => SetControlsReadOnly(isReadOnly),
				BindingSourceRestBinding,
				EmployeeEfRepository.Delete,
				EmployeeEfRepository.Add,
				EmployeeEfRepository.Update,
				CheckData,
				_currentAction,
				Query, // 刷新資料
				new EmployeeQueryViewModel(),
                ExportPDF // 匯出PDF功能 (是把「一個可以執行的函數（delegate）」傳進去，而不是「執行函數的結果」)
            );
		}

		/// <summary>
		/// 編輯狀態預設
		/// </summary>
		/// <param name="action">編輯</param>
		private EmployeeDto InitEdit() => new EmployeeDto
		{
			Reviser = LoginSession.User.EmpId,
			ReviseDate = DateTime.Now
		};

		private class EmployeeQueryViewModel
		{
			public string? EmpId { get; set; }
			public string? EmpNm { get; set; }
			public string? DepId { get; set; }
			public string? DepId2 { get; set; }
			public string? DepId3 { get; set; }
			public string? DepId4 { get; set; }
			public string? DepId6 { get; set; }
			public string? DepId7 { get; set; }
			public string? DepId8 { get; set; }
			public string? DepId9 { get; set; }
			public string? DepId10 { get; set; }
			public string? DepId11 { get; set; }
			public string? DepId12 { get; set; }
			public static readonly Dictionary<string, string> DisplayNames = new()
			{
				{ "EmpId", "員工編號" },
				{ "EmpNm", "姓名" },
				{ "DepId", "部門代號" }
			};
		}

		internal void OnPermissionAction(string action)
		{
			_currentAction = _actionHandler.OnAction(action);
		}

		/// <summary>
		/// 查詢員工清單
		/// </summary>
		private void Query()
		{
			_employeeList = GetEmployees() ?? Enumerable.Empty<EmployeeDto>();

			ControlHelper.TranDeptName(_employeeList, deptBS, employee_BindingSource); // 部門代號轉部門名稱
			BindingSourceRestBinding();
		}

		/// <summary>
		/// 儲存資料
		/// </summary>
		/// <param name="action"></param>
		internal void SaveData(string action)
		{
			BindingSourceRestBinding();

			FormActionHandler<EmployeeDto>.Save(
				action: action,
				checkData: CheckData,
				setReadOnly: SetControlsReadOnly,
				getCurrent: () => Current(),
				addFunc: data => EmployeeEfRepository.Add((EmployeeDto)data),
				updateFunc: data => EmployeeEfRepository.Update((EmployeeDto)data),
				refresh: Query,
				setLoading: visible => picLoading.Visible = visible
			);
		}

		/// <summary>
		/// 檢查記錄資料完整性
		/// </summary>
		/// <returns></returns>
		internal bool CheckData()
		{
			var cur = Current();

			var validator = new FormValidator(
				new(() => string.IsNullOrWhiteSpace(cur.EmpNm), "請輸入員工姓名"),
				new(() => string.IsNullOrWhiteSpace(cur.IdNumber), "請輸入身份證字號"),
				new(() => cur.BirthDate == null || cur.BirthDate==DateTime.Today, "請選擇生日"),
				new(() => string.IsNullOrWhiteSpace(cur.Gender), "請選擇性別"),
				new(() => string.IsNullOrWhiteSpace(cur.Shift), "請選擇班別"),
				new(() => string.IsNullOrWhiteSpace(cur.DepId), "請選擇部門"),
				new(() => string.IsNullOrWhiteSpace(cur.JobLevel), "請選擇職等"),
				new(() => string.IsNullOrWhiteSpace(cur.EmployeeType), "請選擇員工類別"),
				new(() => string.IsNullOrWhiteSpace(cur.Tel), "請輸入電話"),
				new(() => string.IsNullOrWhiteSpace(cur.EmergencyContact), "請輸入緊急聯絡人"),
				new(() => chkIsResigned.Checked && cur.ResignDate == null, "請選擇離職日期"),
				new(() => chkIsResigned.Checked && string.IsNullOrWhiteSpace(cur.ResignReason), "請輸入離職原因")
			);
			return validator.Validate();
		}

		/// <summary>
		/// 設定控制項唯讀狀態
		/// </summary>
		/// <param name="isReadOnly"></param>
		internal void SetControlsReadOnly(bool isReadOnly)
		{
			ControlHelper.SetGridViewEnable(dgvEmployees, isReadOnly); // 清單唯讀狀態

			txtEmpNm.ReadOnly = isReadOnly;               // 員工姓名
			txtIdNumber.ReadOnly = isReadOnly;            // 身份證字號
			dateBirthDate.Enabled = !isReadOnly;          // 日期控制項通常只能用 Enabled
			txtEmail.ReadOnly = isReadOnly;               // 電子郵件
			txtAddress_Registered.ReadOnly = isReadOnly;  // 戶籍地址
			txtAddress_Contact.ReadOnly = isReadOnly;     // 通訊地址

			radioGenderM.AutoCheck = !isReadOnly;         // 性別男（不使用 Enabled，維持樣式）
			radioGenderF.AutoCheck = !isReadOnly;         // 性別女

			chkIsForeign.AutoCheck = !isReadOnly;         // 是否本國人
			chkIsMarried.AutoCheck = !isReadOnly;         // 是否已婚

			cboShift.DropDownStyle = isReadOnly ? ComboBoxStyle.Simple : ComboBoxStyle.DropDownList; // 禁止選擇但仍顯示
			cboShift.Enabled = !isReadOnly;

			cboDepId.Enabled = !isReadOnly;               // 部門
			cboMgrId.Enabled = !isReadOnly;               // 直屬主管
			cboJobLevel.Enabled = !isReadOnly;            // 職等
			cboEmployeeType.Enabled = !isReadOnly;        // 員工類別

			txtCustomSalary.ReadOnly = isReadOnly;        // 個人核定薪資

			chkIsWelfareMember.AutoCheck = !isReadOnly;   // 是否參加福利會

			dateHireDate.Enabled = !isReadOnly;           // 到職日期
			chkIsResigned.AutoCheck = !isReadOnly;        // 是否離職
			dateResignDate.Enabled = !isReadOnly;         // 離職日期
			txtMemo.ReadOnly = isReadOnly;               // 備註
			txtTel.ReadOnly = isReadOnly;                // 電話號碼
			txtEmergencyContact.ReadOnly = isReadOnly;   // 緊急聯絡人
			txtResignReason.ReadOnly = isReadOnly;       // 離職原因

			pnlImg.Enabled = !isReadOnly;
			trackImgZoom.Visible = !isReadOnly;

			btnImgDelete.Visible = !isReadOnly;

			this.SetPermissions(isReadOnly ? actionArr : null); // 清除權限按鈕，避免新增後仍有編輯按鈕可用 / 恢復所有按鈕權限
		}
		#endregion

		#region 圖片處理
		// 拖移處理
		private bool _isDragging = false; // 拖移註記
		private bool _justDragged = false;

		// 圖片儲存路徑（放在專案內 Images\Employees 資料夾）
		private string _imgDir = Path.Combine(Application.StartupPath, "Images", "Employees");

		/// <summary>
		/// 更新圖片
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private async void picEmpImg_DoubleClick(object sender, EventArgs e)
		{
			//if (_isDragging || _justDragged) return; // 正在拖曳時，不開啟選擇圖片

			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Title = "選擇圖片";
				ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

				// 預設取得桌面
				ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					try
					{
						if (!Directory.Exists(_imgDir))
						{
							Directory.CreateDirectory(_imgDir);
						}

						string imgPath = ImgHandleHelper.SaveImageToProjectFolder(_imgDir, ofd.FileName); // 取得新圖片路徑
						Current().ImgFileName = Path.GetFileName(imgPath); // 圖片檔名
						if (await LoadImgFromCurrent() && picEmpImg.Image != null) // 載入圖片
						{
							// === 初始化圖片縮放 ===
							picEmpImg.SizeMode = PictureBoxSizeMode.StretchImage;

							if (picEmpImg.Image == null) return;

							// 初始比例
							int originalWidth = picEmpImg.Image.Width;
							int displayedWidth = picEmpImg.Width;
							decimal zoom = (decimal)displayedWidth / originalWidth;

							// 設定滑桿位置
							trackImgZoom.Value = Math.Clamp((int)(zoom * 100), trackImgZoom.Minimum, trackImgZoom.Maximum);

							// === 將圖片置中於 Panel ===
							int posX = (pnlImg.Width - picEmpImg.Width) / 2;
							int posY = (pnlImg.Height - picEmpImg.Height) / 2;

							// 防止置中後位置為負值（圖片太大）
							posX = Math.Max(posX, 0);
							posY = Math.Max(posY, 0);
							picEmpImg.Location = new Point(posX, posY);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("圖片載入失敗：" + ex.Message);
					}
				}

                btnImgDownload.Visible = Current() != null && !string.IsNullOrWhiteSpace(Current().ImgFileName); // 有圖片才顯示下載按鈕
            }
		}

		private bool _isBinding = false;
		private async Task<bool> LoadImgFromCurrent()
		{
			if (_isBinding || _justDragged) return false;

			_isBinding = true;

			try
			{
				picEmpImg.Image?.Dispose(); // 手動釋放資源
				picEmpImg.Image = null;     // 圖片清空（控制項內部自動刷新）
				picEmpImg.Parent = pnlImg;
                picEmpImg.Location = new Point(0, 0);

                var emp = Current();

				btnImgDownload.Visible = emp != null && !string.IsNullOrWhiteSpace(emp.ImgFileName); // 有圖片才顯示下載按鈕

                if (emp == null || string.IsNullOrWhiteSpace(emp.ImgFileName)) return false;

				var imgPath = Path.Combine(_imgDir, emp.ImgFileName);

				if (string.IsNullOrEmpty(imgPath) || !File.Exists(imgPath)) return false;

				// Image img = Image.FromFile(imgPath); // 會被鎖檔案

				Image loadedImg = null;

				using (var fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
				{
					var img = Image.FromStream(fs);
					loadedImg = new Bitmap(img);
				}

				if (loadedImg != null)
				{
					picEmpImg.Image?.Dispose(); // 再清除舊圖
					picEmpImg.Image = loadedImg;
				}

				// 安全載入位置與縮放
				int posX = (int)(emp.ImgPositionX ?? 0);
				int posY = (int)(emp.ImgPositionY ?? 0);
                picEmpImg.Location = new Point(posX, posY); // 然後設定位置

                decimal zoom = emp.ImgZoom ?? 1.0m;

				// 設定滑桿位置
				trackImgZoom.Value = Math.Clamp((int)(zoom * 100), trackImgZoom.Minimum, trackImgZoom.Maximum);

				SetImgZoom();
				picEmpImg.BringToFront(); // 照片控件置於最上層
                return true;
			}
			catch (Exception ex)
			{
				MessageBox.Show("圖片載入失敗：" + ex.Message);
				return false;
			}
			finally
			{
				_isBinding = false;
			}
		}

        /// <summary>
        /// 設定圖片位置
        /// </summary>
        private void SaveImgToCurrent(Point pot)
        {
            var emp = Current();
            if (emp == null) return;

            emp.ImgZoom = trackImgZoom.Value / 100m;
            emp.ImgPositionX = pot.X;
            emp.ImgPositionY = pot.Y;
        }

        private void btnImgDelete_Click(object sender, EventArgs e)
		{
			Current().ImgFileName = null; // 清除圖片檔名
			picEmpImg.Image?.Dispose(); // 釋放圖片資源
			picEmpImg.Image = null; // 清空圖片顯示
			picEmpImg.Location = new Point(0, 0); // 重置位置
			trackImgZoom.Value = Math.Clamp(100, trackImgZoom.Minimum, trackImgZoom.Maximum); // 重置縮放滑桿
			SaveImgToCurrent(picEmpImg.Location); // 儲存當前圖片狀態
            LoadImgFromCurrent();
        }

		private void btnImgDownload_Click(object sender, EventArgs e)
		{
            // 寫個下載圖片的功能
			var emp = Current();
			if (emp == null || string.IsNullOrWhiteSpace(emp.ImgFileName)) return;

            string sourcePath = Path.Combine(_imgDir, emp.ImgFileName);

            if (!File.Exists(sourcePath))
            {
                MessageBox.Show("找不到圖片檔案。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "儲存圖片";
                sfd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop); // 預設在桌面
                sfd.FileName = emp.ImgFileName;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.Copy(sourcePath, sfd.FileName, true);
                        MessageBox.Show("圖片已成功下載。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"圖片下載失敗：{ex.Message}", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool _isEventRegistered = false; // 防止重複加入事件

		/// <summary>
		/// 加入拖移事件
		/// </summary>
		private void RegisterImageDragEvents()
		{
			if (_isEventRegistered == false)
			{
				new DraggableHelper(picEmpImg, pnlImg, 1, (newPos) =>
				{
					SaveImgToCurrent(newPos); // 拖完就儲存
				});

				_isEventRegistered = true;
			}
		}

		/// <summary>
		/// 圖片縮放
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trackImgZoom_Scroll(object sender, EventArgs e)
		{
			if (picEmpImg.Image == null) return;

			SetImgZoom();
		}

		private void SetImgZoom()
		{
			ImgHandleHelper.SetImgZoom(trackImgZoom, picEmpImg);
			SaveImgToCurrent(picEmpImg.Location);
		}

		private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
		{
			if (_isDragging || _justDragged) return;
			trackImgZoom.Value = Math.Clamp(100, trackImgZoom.Minimum, trackImgZoom.Maximum);
			SafeService.SafeBeginInvoke(this, () =>
			{
				var emp = Current();
				if (emp == null) return;
				_ = LoadImgFromCurrent(); // 非同步不用等待
			});
		}

        #endregion

        #region 匯出Excel
        internal void ExportPDF()
        {
            try
            {
                var emp = Current();
				if (emp == null) return;

                var _pdfDir = Path.Combine(Application.StartupPath, "PDFs", "Employees");

                Directory.CreateDirectory(_pdfDir); // 確保資料夾存在

                string filePath = Path.Combine(_pdfDir,
					$"員工基本資料_{GetPropValue(emp, "EmpId")}_{GetPropValue(emp, "EmpNm")}.pdf"
				);

                string imgPath = Path.Combine(_imgDir, emp.ImgFileName);

				if (File.Exists(imgPath) == false) imgPath = null;

                var pdf = new GeneratePdfService(emp, imgPath);
				pdf.GeneratePdf(filePath);

				Process.Start("explorer", filePath);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleErrorMsg(ex);
				return;
            }
        }

        private string GetPropValue(object obj, string propName)
        {
            var prop = obj.GetType().GetProperty(propName);
            return prop?.GetValue(obj)?.ToString() ?? "未知";
        }
        #endregion

        #region IFormBindable 介面實作
        void IFormBindable.OnPermissionAction(string action) => _actionHandler.OnAction(action);
		void IFormBindable.InitEdit() => InitEdit(); // 若有分開處理
		void IFormBindable.SetControlsReadOnly(bool readOnly) => SetControlsReadOnly(readOnly);
		void IFormBindable.SaveData(string action) => SaveData(action);
		bool IFormBindable.CheckData() => CheckData();

		void IPageWithPermission.OnPermissionAction(string action) => OnPermissionAction(action);
		#endregion
	}
}