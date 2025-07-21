namespace ISpan.eMiniHR.DataAccess.Models
{
    public class ProgramsConfigDto
    {
        public string ProgSysCode { get; set; } // 系統類別
        public string SystemName { get; set; } // 系統名稱
        public string ProgSysId { get; set; } // 系統代號
        public string ProgId { get; set; } // 程式代號
        public string ProgName { get; set; } // 程式名稱
        public bool IsCommon { get; set; } // 通用註記
        public int SortOrder { get; set; } // 排序

	}
}
