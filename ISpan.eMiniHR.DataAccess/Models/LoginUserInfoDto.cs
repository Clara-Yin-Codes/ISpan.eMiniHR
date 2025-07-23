namespace ISpan.eMiniHR.DataAccess.Models
{
    public class LoginUserInfoDto
    {
        public string UserId { get; set; } = string.Empty; // 登入ID（員工編號或管理者編號）
        public string Account { get; set; } = string.Empty; // 登入帳號（員工編號或管理者編號）
        public string AccountName { get; set; } = string.Empty; // 員工姓名
        public DateTime LoginTime { get; set; } = DateTime.Now; // 登入時間
        public string LoginRole { get; set; } = string.Empty; // 登入身分（"ad" 或 "user"）
        public bool IsAdmin => LoginRole == "ad"; // 判斷是否為 Admin 身分

        // 儲存程式權限
        public List<ProgramPermissionsDto> Permissions { get; set; } = new();
    }
}
