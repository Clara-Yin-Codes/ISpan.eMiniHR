using ISpan.eMiniHR.DataAccess.DapperRepositories;
using System.ComponentModel.DataAnnotations;

namespace ISpan.eMiniHR.DataAccess.Models
{
    /// <summary>
    /// 程式權限設定 EF
    /// </summary>
    public class ProgramPermissionsEntity
    {
        public string? ProgSysId { get; set; } // 程式系統識別碼
        public string? EmpId { get; set; } // 員工編號
        public bool? Queryable { get; set; } // 查詢權限
        public bool? Addable { get; set; } // 新增權限
        public bool? Editable { get; set; } // 編輯權限
        public bool? Deletable { get; set; } // 刪除權限
        public bool? Voidable { get; set; } // 作廢權限
        public bool? Printable { get; set; } // 列印權限
        public bool? Downloadable { get; set; } // 下載權限
        public bool? Testable { get; set; } // 測試權限
    }

    /// <summary>
    /// 程式權限設定 DTO
    /// </summary>
    public class ProgramPermissionsDto : ProgramPermissionsEntity
    {
        public string? ProgName { get; set; } // 程式名稱
    }
}
