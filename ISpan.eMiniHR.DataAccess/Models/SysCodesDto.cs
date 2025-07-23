namespace ISpan.eMiniHR.DataAccess.Models
{
	/// <summary>
	/// 系統代號
	/// </summary>
    public class SysCodesDto
	{
        public string? CodeId { get; set; } // 系統代號
        public string? CodeNO { get; set; } // 項目
        public string? CodeDesc { get; set; } // 代號說明
		public string? GroupName { get; set; } // 群組代號
		public string? Memo { get; set; } // 備註
		public string? ProgId { get; set; } // 程式代號
	}
}
