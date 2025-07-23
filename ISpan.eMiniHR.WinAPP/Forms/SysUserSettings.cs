using ISpan.eMiniHR.DataAccess.DapperRepositories;
using ISpan.eMiniHR.DataAccess.EfRepositories;
using ISpan.eMiniHR.DataAccess.Models;
using ISpan.eMiniHR.WinApp.Helper;
using ISpan.eMiniHR.WinApp.Interfaces;
using ISpan.eMiniHR.WinApp.Services;
using static ISpan.eMiniHR.DataAccess.DapperRepositories.SysCodesRepository;

namespace ISpan.eMiniHR.WinApp.Forms
{
    public partial class SysUserSettings : UserControl, IFormBindable, IPageWithPermission
    {
        public SysUserSettings()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 系統權限設定
        /// </summary>
        private IEnumerable<UsersDto> _userList = Enumerable.Empty<UsersDto>();
        string _currentAction = "查詢"; // 當前操作狀態
        string[] actionArr = new[] { "查詢", "新增", "編輯", "取消", "儲存", "刪除" };

        private void SysUserSettings_Load(object sender, EventArgs e)
        {
            Query(); // 查詢清單
            SetFormUI(); // 設定表單樣式
            SetControlsReadOnly(true); // 設定控制項唯讀狀態
            InitActionHandler(); // 初始化操作處理
        }

        #region 清單樣式處理
        private void dgvUsers_Resize(object sender, EventArgs e)
        {
            ControlHelper.SetGridViewColumnSize(dgvUsers); // 調整清單欄位大小
            splitContainer1.SplitterDistance = 230; // 設定分割線位置
        }

        private void dgvUsers_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvUsers.Rows[e.RowIndex];
            if (row.DataBoundItem is UsersDto user)
            {
                if (user.IsActive != true)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
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
                    ("UserId", "使用者編號"),
                    ("Account", "帳號"),
                    ("AccountName", "名稱")
                };

            ControlHelper.SetGridView(dgvUsers, columnDefs, users_bindingSource);

            var columnDefs_D = new List<(string, string, bool)>
                {
                    ("ProgSysId", "程式代碼", false),
                    ("ProgName", "程式名稱", false),
                    ("Queryable", "查詢", true),
                    ("Addable", "新增", true),
                    ("Editable", "編輯", true),
                    ("Deletable", "刪除", true),
                    ("Voidable", "作廢", true),
                    ("Printable", "列印", true),
                    ("Downloadable", "匯出", true),
                    ("Testable", "測試", true),
                };

            dgvProgramPermissions.Columns.Clear();

            ControlHelper.SetGridViewDetails(dgvProgramPermissions, columnDefs_D, programPermissions_bindingSource);
        }

        /// <summary>
        /// 下拉選單項目設定
        /// </summary>
        public void SetCboItems()
        {
            var sysCond = SysCodesRepository.GetSysCodes(new SysCodesModel { CodeId = "01" });

            ControlHelper.BindMultipleComboBoxes(users_bindingSource, 1, new[]
            {
                (cboSysRole,(object)sysCond,"CodeDesc","CodeNO","SysRole")
            });
        }
        #endregion

        #region 資料來源設定
        /// <summary>
        /// 資料庫異動後，重新查詢清單
        /// </summary>
        /// <returns></returns>
        public UsersDto? Current()
        {
            var user = users_bindingSource.Current as UsersDto;

            if (user != null)
            {
                //programPermissions_bindingSource.DataSource = user.Permissions;
                programPermissions_bindingSource.ResetBindings(false); // 更新畫面
            }

            return user;
        }

        /// <summary>
        /// 資料綁定
        /// </summary>
        private void BindingSourceRestBinding()
        {
            users_bindingSource.EndEdit(); // 結束編輯
            users_bindingSource.ResetBindings(false); // 重新綁定資料來源

            programPermissions_bindingSource.ResetBindings(false); // 明細寫法

            dgvProgramPermissions.Refresh(); // 強制重繪畫面
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UsersDto> GetUsers(UserQueryViewModel cond = null)
        {
            try
            {
                cond ??= new UserQueryViewModel(); // 若為 null 則建立預設條件
                return UsersRepository.GetUsers(cond);
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleErrorMsg(ex);
                return null;
            }
        }
        #endregion

        #region 工具列操作實作

        private FormActionHandler<UsersDto> _actionHandler;

        private void InitActionHandler()
        {
            _actionHandler = new FormActionHandler<UsersDto>(
                users_bindingSource,
                () => Current(),
                () => InitEdit(), // 編輯狀態預設
                new[] { "Reviser", "ReviseDate" }, // 編輯狀態預設欄位
                isReadOnly => SetControlsReadOnly(isReadOnly),
                BindingSourceRestBinding,
                UserEfRepository.Delete,
                UserEfRepository.Add,
                UserEfRepository.Update,
                CheckData,
                _currentAction,
                refreshData: cond => Query(cond as UserQueryViewModel), // 刷新資料
                new UserQueryViewModel(),
                null,
                "UserId"
            );
        }

        /// <summary>
        /// 編輯狀態預設
        /// </summary>
        /// <param name="action">編輯</param>
        private UsersDto InitEdit() => new UsersDto
        {
            //Reviser = LoginSession.User.EmpId,
            //ReviseDate = DateTime.Now
        };

        /// <summary>
        /// 查詢條件
        /// </summary>
        public class UserQueryViewModel : DataAccess.DapperRepositories.UserQueryViewModel
        {
            public static readonly Dictionary<string, QueryConditionForm<UserQueryViewModel>.FieldDisplayInfo> DisplayNames = new()
            {
                { "account", new() { Label = "員工編號", ControlType = "Text" } },
                { "isActive", new() { Label = "啟用", ControlType = "Check" , DefaultValue = true} },
                { "isNotActive", new() { Label = "不啟用", ControlType = "Check" , DefaultValue = false} }
            };
        }

        internal void OnPermissionAction(string action)
        {
            _currentAction = _actionHandler.OnAction(action);
        }

        /// <summary>
        /// 查詢清單
        /// </summary>
        private void Query(UserQueryViewModel? cond = null)
        {
            _userList = GetUsers(cond) ?? Enumerable.Empty<UsersDto>();
            users_bindingSource.DataSource = _userList;

            // 綁定明細來源（多對一：使用者 ➜ 權限清單）
            programPermissions_bindingSource.DataSource = users_bindingSource;
            programPermissions_bindingSource.DataMember = "Permissions"; // 明確指定屬性名稱

            // 4. 指定到 DataGridView
            dgvProgramPermissions.DataSource = programPermissions_bindingSource;

            // 轉名稱
            //ControlHelper.TranslateProperty(
            //	_employeeList,
            //	emp => emp.DepId,
            //	(emp, name) => emp.DepName = name,
            //	DeptsRepository.GetDepts().Select(d => new KeyValuePair<string, string>(d.DepId, d.DepName)),
            //	deptBS,
            //	employee_BindingSource
            //);
            BindingSourceRestBinding();
        }

        /// <summary>
        /// 儲存資料
        /// </summary>
        /// <param name="action"></param>
        internal void SaveData(string action)
        {
            FormActionHandler<EmployeeDto>.Save(
                action: action,
                checkData: CheckData,
                setReadOnly: SetControlsReadOnly,
                getCurrent: () => Current(),
                addFunc: data => UserEfRepository.Add((UsersDto)data),
                updateFunc: data => UserEfRepository.Update((UsersDto)data),
                refresh: cond => Query(cond as UserQueryViewModel),
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
                new(() => string.IsNullOrWhiteSpace(cur.Account), "請輸入帳號"),
                new(() => string.IsNullOrWhiteSpace(cur.AccountName), "請輸入帳號名稱"),

                new(() => cur.PasswordHash != null &&
                string.IsNullOrWhiteSpace(cur.PasswordHashSet), "請輸入密碼"),

                new(() => string.IsNullOrWhiteSpace(cur.SysRole), "請選擇登入身分")
            );
            return validator.Validate();
            //return false;
        }

        /// <summary>
        /// 設定控制項唯讀狀態
        /// </summary>
        /// <param name="isReadOnly"></param>
        internal void SetControlsReadOnly(bool isReadOnly)
        {
            ControlHelper.SetGridViewEnable(dgvUsers, isReadOnly); // 清單唯讀狀態
            ControlHelper.SetGridViewEnable(dgvProgramPermissions, !isReadOnly); // 清單唯讀狀態

            if (isReadOnly)
            {
                dgvProgramPermissions.DefaultCellStyle.SelectionBackColor = Color.White;    // 被選取背景色（淡一點）
            }
            else {
                dgvProgramPermissions.DefaultCellStyle.SelectionBackColor = Color.LightBlue;    // 被選取背景色（淡一點）
            }

            if (Current().SysRole == "ad")
            {
                txtAccount.ReadOnly = isReadOnly;
                txtAccountName.ReadOnly = isReadOnly;
            }
            else {
                txtAccount.ReadOnly = true;
                txtAccountName.ReadOnly = true;
            }

            if (string.IsNullOrWhiteSpace(Current().UserId) == true && isReadOnly==false) {
                Current().IsActive = true;
                BindingSourceRestBinding();
            }
            
            txtPasswordHash.ReadOnly = isReadOnly;

            radioActiveN.Enabled = !isReadOnly; // 失效狀態可編輯
            radioActiveY.Enabled = !isReadOnly; // 有效狀態可編輯

            this.SetPermissions(isReadOnly ? actionArr : null); // 清除權限按鈕，避免新增後仍有編輯按鈕可用 / 恢復所有按鈕權限
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
