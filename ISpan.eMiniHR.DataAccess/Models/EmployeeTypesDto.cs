namespace ISpan.eMiniHR.DataAccess.Models
{
    /// <summary>
    /// 員工類別代碼
    /// </summary>
    public class EmployeeTypesDto
    {
        public string TypeCode { get; set; } = string.Empty; // 員工類別代碼
        public string TypeName { get; set; } // 員工類別說明
    }
}
