namespace ISpan.eMiniHR.DataAccess.Models
{
    /// <summary>
    /// 職等設定
    /// </summary>
    public class JobGradesDto
    {
        public string JobLevelCode { get; set; } = string.Empty; // 職等代碼
        public string JobLevelName { get; set; } = string.Empty; // 職等名稱
        public int BaseSalary { get; set; } // 基本薪資
        public string Note { get; set; } = string.Empty; // 備註
    }
}
