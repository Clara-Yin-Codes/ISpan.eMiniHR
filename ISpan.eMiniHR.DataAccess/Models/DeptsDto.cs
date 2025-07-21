namespace ISpan.eMiniHR.DataAccess.Models
{
    public class DeptsDto
    {
        public string DepId { get; set; } = ""; // 部門代碼
        public string DepName { get; set; } = string.Empty; // 部門名稱
        public string DeptManagerId { get; set; } = string.Empty; // 部門主管
        public string FormatDept { get { return $"{DepId?.Trim()}-{DepName?.Trim()}"; } }
    }
}
