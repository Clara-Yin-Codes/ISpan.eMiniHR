using System.ComponentModel.DataAnnotations;

namespace ISpan.eMiniHR.DataAccess.Models
{
    /// <summary>
    /// 系統登入者 EF
    /// </summary>
    public class UsersEntity
    {
        [Key]
        public string? UserId { get; set; }
        public string? Account { get; set; } // 帳號
        public string? AccountName { get; set; } // 帳號名稱
        public string? PasswordHash { get; set; } // 密碼
        public string? SysRole { get; set; } // 身分(管理員/一般使用者)
        public DateTime? CreateDate { get; set; } // 建立日期
        public DateTime? LastLoginTime { get; set; } // 最後登入日期
        public bool? IsActive { get; set; } // 有效註記
    }

    /// <summary>
    /// 系統登入者
    /// </summary>
    public class UsersDto : UsersEntity
    {
    }
}
