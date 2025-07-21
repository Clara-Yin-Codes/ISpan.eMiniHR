using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISpan.eMiniHR.DataAccess.Models
{
    /// <summary>
    /// 員工檔案
    /// </summary>
    [Table("Employee")]
    public class EmployeeEntity
    {
        [Key]
        public string? EmpId { get; set; } // 員工編號
        public string? EmpNm { get; set; } //  員工姓名
		public string? IdNumber { get; set; } // 身分證字號
        public bool IsForeign { get; set; } = false; // 是否本國人
		public string? Gender { get; set; } // 性別
        public bool? IsMarried { get; set; } = false; // 已婚
        public DateTime? BirthDate { get; set; } = DateTime.Today; // 生日
        public DateTime? HireDate { get; set; } = DateTime.Today; // 到職日期
        public DateTime? ResignDate { get; set; } // 離職日期
        public string? ResignReason { get; set; } // 離職原因
        public string? JobLevel { get; set; } // 職等, 對應JobGrades
        public int? CustomSalary { get; set; } = 0; // 個人核定薪資
		public string? EmployeeType { get; set; } // 員工類別 (正式員工/約聘人員/工讀生/廠商)
        public bool? IsWelfareMember { get; set; } = false; // 是否參加職工福利會
		public string? Shift { get; set; }// 班別(免打卡/A班/B班)
		public string? DepId { get; set; } // 所屬部門
        public string? MgrId { get; set; } // 直屬主管 (對應員工編號)
		public string? Address_Registered { get; set; } // 戶籍地址
		public string? Address_Contact { get; set; } // 通訊地址
		public string? Email { get; set; } // 電子郵件
        public string? Memo { get; set; } // 備註
        public string? Reviser { get; set; } // 異動人員
        public DateTime? ReviseDate { get; set; } // 異動日期
        public string? Tel { get; set; } // 電話號碼
        public string? EmergencyContact { get; set; } // 緊急聯絡人
		public string? ImgFileName { get; set; } // 圖片檔名（預設為空）

		public decimal? ImgPositionX { get; set; } // 圖片位置(左)
		public decimal? ImgPositionY { get; set; } // 圖片位置(上)
		public decimal? ImgZoom { get; set; } // 圖片縮放比例
	}

    public class EmployeeDto : EmployeeEntity
    {
        //[NotMapped] // 加上這一行才能避免 EF 嘗試寫入這個不存在的欄位
        public int Age // 年齡計算屬性
        {
            get
            {
                if (BirthDate == default) return 0; // 如果未設定生日，返回0
                var today = DateTime.Today;
                var birthDate = this.BirthDate.Value; // 確保BirthDate有值
                int age = today.Year - birthDate.Year;
                if (birthDate > today.AddYears(-age)) age--; // 尚未過生日
                return age;
            }
        }
        // 是否離職
        public bool IsResigned
        {
            get => ResignDate.HasValue; // Lambda 表達式，簡化屬性定義
            set
            {
                if (value)
                {
                    ResignDate ??= DateTime.Now; // 設定離職日期為當前時間
                }
                else
                {
                    // 如果不是離職，則清除
                    ResignDate = null;
                    ResignReason = null;
                }
            }
        }
        // 性別設定
        public bool GenderM 
        {
            get => Gender == "M"; // 如果性別為 "M"，則返回 true
            set
            {
                Gender = value ? "M" : "F"; // 如果設為 true，則性別為 "M"，否則為 "F"
            }
        }
        public bool GenderF
        {
            get => Gender == "F";
            set
            {
                Gender = value ? "F" : "M";
            }
        }
        public string DepName { get; set; }  // 部門名稱
        public string? FormatReviseDate => ReviseDate?.ToString("yyyy/MM/dd HH:mm");
    }
}
