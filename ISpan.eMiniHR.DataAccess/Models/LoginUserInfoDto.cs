namespace ISpan.eMiniHR.DataAccess.Models
{
    public class LoginUserInfoDto
    {
        public string EmpId { get; set; } = string.Empty; // 登入帳號（員工編號或管理者編號）
        public string EmpNm { get; set; } = string.Empty; // 員工姓名
        public string DepId { get; set; } = string.Empty; // 部門代碼
        public string JobLevel { get; set; } = string.Empty; // 員工職等
        public DateTime LoginTime { get; set; } = DateTime.Now; // 登入時間
        public string LoginRole { get; set; } = string.Empty; // 登入身分（"Admin" 或 "Employee"）
        public bool IsAdmin => LoginRole == "Admin"; // 判斷是否為 Admin 身分

        // 儲存程式權限
        public List<ProgramPermissionDto> Permissions { get; set; } = new();
    }
}
