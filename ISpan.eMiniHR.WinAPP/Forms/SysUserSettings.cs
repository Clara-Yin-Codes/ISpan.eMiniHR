using ISpan.eMiniHR.DataAccess.DapperRepositories;
using ISpan.eMiniHR.DataAccess.EfRepositories;
using ISpan.eMiniHR.DataAccess.Models;
using ISpan.eMiniHR.WinApp.Helper;
using ISpan.eMiniHR.WinApp.Interfaces;
using ISpan.eMiniHR.WinApp.Services;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        #region 按鈕事件處理
        private void dataGridView1_Resize(object sender, EventArgs e)
        {
            ControlHelper.SetGridViewColumnSize(dgvUsers); // 調整清單欄位大小
            splitContainer1.SplitterDistance = 210; // 設定分割線位置
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
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
        }

        /// <summary>
        /// 下拉選單項目設定
        /// </summary>
        public void SetCboItems()
        {
            //var emps = EmployeeQueryRepository.GetEmployees();
            //ControlHelper.BindMultipleComboBoxes(employee_BindingSource, 1, new[]
            //{
            //    (cboShift, ShiftsRepository.GetShifts(), "ShiftName", "ShiftCode", "Shift"), // 班別
            //    (cboDepId, deptBS.DataSource, "FormatDept", "DepId", "DepId"), // 部門
            //    (cboJobLevel, JobGradesRepository.GetJobGrades(), "JobLevelName", "JobLevelCode", "JobLevel"), // 職等
            //    (cboEmployeeType, EmployeeTypesRepository.GetEmployeeTypes(), "TypeName", "TypeCode", "EmployeeType") // 員工類別
            //});

            //ControlHelper.BindMultipleComboBoxes(employee_BindingSource, 2, new[]
            //{
            //    (cboMgrId, (object)emps, "EmpNm", "EmpId", "MgrId"),
            //    (cboReviser, (object)LoginRepository.GetAccounts().ToList(), "AccountName", "Account", "Reviser")
            //});
        }
        #endregion

        #region 資料來源設定
        /// <summary>
        /// 資料庫異動後，重新查詢清單
        /// </summary>
        /// <returns></returns>
        public UsersDto? Current()
        {
            return users_bindingSource.Current as UsersDto;
        }

        /// <summary>
        /// 資料綁定
        /// </summary>
        private void BindingSourceRestBinding()
        {
            users_bindingSource.EndEdit(); // 結束編輯
            users_bindingSource.ResetBindings(false);
        }

        /// <summary>
        /// 取得資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UsersDto> GetUsers()
        {
            try
            {
                return UsersRepository.GetUsers();
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
                Query, // 刷新資料
                new UserQueryViewModel(),
                null
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

        private class UserQueryViewModel
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
        /// 查詢清單
        /// </summary>
        private void Query()
        {
            _userList = GetUsers() ?? Enumerable.Empty<UsersDto>();

            //ControlHelper.TranDeptName(_userList, deptBS, employee_BindingSource); // 部門代號轉部門名稱
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

            //var validator = new FormValidator(
            //    new(() => string.IsNullOrWhiteSpace(cur.EmpNm), "請輸入員工姓名"),
            //    new(() => string.IsNullOrWhiteSpace(cur.IdNumber), "請輸入身份證字號"),
            //    new(() => cur.BirthDate == null, "請選擇生日"),
            //    new(() => string.IsNullOrWhiteSpace(cur.Gender), "請選擇性別"),
            //    new(() => string.IsNullOrWhiteSpace(cur.Shift), "請選擇班別"),
            //    new(() => string.IsNullOrWhiteSpace(cur.DepId), "請選擇部門"),
            //    new(() => string.IsNullOrWhiteSpace(cur.JobLevel), "請選擇職等"),
            //    new(() => string.IsNullOrWhiteSpace(cur.EmployeeType), "請選擇員工類別"),
            //    new(() => string.IsNullOrWhiteSpace(cur.Tel), "請輸入電話"),
            //    new(() => string.IsNullOrWhiteSpace(cur.EmergencyContact), "請輸入緊急聯絡人"),
            //    new(() => chkIsResigned.Checked && cur.ResignDate == null, "請選擇離職日期"),
            //    new(() => chkIsResigned.Checked && string.IsNullOrWhiteSpace(cur.ResignReason), "請輸入離職原因")
            //);
            //return validator.Validate();
            return false;
        }

        /// <summary>
        /// 設定控制項唯讀狀態
        /// </summary>
        /// <param name="isReadOnly"></param>
        internal void SetControlsReadOnly(bool isReadOnly)
        {
            ControlHelper.SetGridViewEnable(dgvUsers, isReadOnly); // 清單唯讀狀態

            //txtEmpNm.ReadOnly = isReadOnly;               // 員工姓名
            //txtIdNumber.ReadOnly = isReadOnly;            // 身份證字號
            //dateBirthDate.Enabled = !isReadOnly;          // 日期控制項通常只能用 Enabled
            //txtEmail.ReadOnly = isReadOnly;               // 電子郵件
            //txtAddress_Registered.ReadOnly = isReadOnly;  // 戶籍地址
            //txtAddress_Contact.ReadOnly = isReadOnly;     // 通訊地址

            //radioGenderM.AutoCheck = !isReadOnly;         // 性別男（不使用 Enabled，維持樣式）
            //radioGenderF.AutoCheck = !isReadOnly;         // 性別女

            //chkIsForeign.AutoCheck = !isReadOnly;         // 是否本國人
            //chkIsMarried.AutoCheck = !isReadOnly;         // 是否已婚

            //cboShift.DropDownStyle = isReadOnly ? ComboBoxStyle.Simple : ComboBoxStyle.DropDownList; // 禁止選擇但仍顯示
            //cboShift.Enabled = !isReadOnly;

            //cboDepId.Enabled = !isReadOnly;               // 部門
            //cboMgrId.Enabled = !isReadOnly;               // 直屬主管
            //cboJobLevel.Enabled = !isReadOnly;            // 職等
            //cboEmployeeType.Enabled = !isReadOnly;        // 員工類別

            //txtCustomSalary.ReadOnly = isReadOnly;        // 個人核定薪資

            //chkIsWelfareMember.AutoCheck = !isReadOnly;   // 是否參加福利會

            //dateHireDate.Enabled = !isReadOnly;           // 到職日期
            //chkIsResigned.AutoCheck = !isReadOnly;        // 是否離職
            //dateResignDate.Enabled = !isReadOnly;         // 離職日期
            //txtMemo.ReadOnly = isReadOnly;               // 備註
            //txtTel.ReadOnly = isReadOnly;                // 電話號碼
            //txtEmergencyContact.ReadOnly = isReadOnly;   // 緊急聯絡人
            //txtResignReason.ReadOnly = isReadOnly;       // 離職原因

            this.SetPermissions(isReadOnly ? actionArr : null); // 清除權限按鈕，避免新增後仍有編輯按鈕可用 / 恢復所有按鈕權限
        }
        #endregion

        #region IFormBindable 介面實作
        void IFormBindable.OnPermissionAction(string action) => _actionHandler.OnAction(action);
        void IFormBindable.InitEdit() => InitEdit(); // 若你有分開處理
        void IFormBindable.SetControlsReadOnly(bool readOnly) => SetControlsReadOnly(readOnly);
        void IFormBindable.SaveData(string action) => SaveData(action);
        bool IFormBindable.CheckData() => CheckData();

        void IPageWithPermission.OnPermissionAction(string action) => OnPermissionAction(action);
        #endregion
    }
}
