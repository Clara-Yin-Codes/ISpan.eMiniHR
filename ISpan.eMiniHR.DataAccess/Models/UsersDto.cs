using ISpan.eMiniHR.DataAccess.DapperRepositories;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

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
        public byte[]? PasswordHash { get; set; } // 密碼
        public string? SysRole { get; set; } = "ad"; // 身分(管理員/一般使用者)
        public DateTime? CreateDate { get; set; } = DateTime.Now; // 建立日期
        public DateTime? LastLoginTime { get; set; } // 最後登入日期
        public bool? IsActive { get; set; } = true; // 有效註記
	}

    /// <summary>
    /// 系統登入者
    /// </summary>
    public class UsersDto : UsersEntity
    {
		private string? _plainPassword;

		/// <summary>
		/// 明碼密碼（可由 UI 設定，也可反查用）
		/// </summary>
		public string? PasswordHashSet
		{
			get => _plainPassword; // 沒設值就抓加密後的   (加上密碼  ?? PasswordHash)
			set
			{
				if (string.IsNullOrWhiteSpace(value) == false) {
					_plainPassword = value;
					PasswordHash = ComputeSha256Hash(value); // 設定的是 instance 的 PasswordHash
				}
			}
		}

		private static byte[] ComputeSha256Hash(string? rawData)
		{
			if (string.IsNullOrEmpty(rawData)) return null;

			using var sha256 = SHA256.Create();
			var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
			return bytes; // .NET 5+ 支援
		}

		public string? FormatCreateDate => CreateDate?.ToString("yyyy/MM/dd HH:mm");
		public string? FormatLastLoginTime => LastLoginTime?.ToString("yyyy/MM/dd HH:mm");

        // 啟用設定
        public bool ActiveY
        {
            get => IsActive==true;
            set
            {
                IsActive = value==true;
            }
        }
        public bool ActiveN
        {
            get => IsActive != true;
            set
            {
                IsActive = value != true;
            }
        }

        // ===== 權限區塊 =====
        public IEnumerable<ProgramPermissionsDto> Permissions { get; set; }
    }
}
