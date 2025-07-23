using Dapper;
using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace ISpan.eMiniHR.DataAccess.DapperRepositories
{
	/*
        CQRS 背後的原則：
        Query（查詢） 和 Command（新增/修改/刪除） 應該分開管理
        減少副作用，增加清晰度
        對大型系統更具可維護性與彈性
     */
	public class EmployeeQueryViewModel
	{
		public string? EmpId { get; set; }
		public string? EmpNm { get; set; }
		public string? DepId { get; set; }
		public bool? CuseY { get; set; } = true;
		public bool? CuseN { get; set; } = false;
	}

	public static class EmployeeQueryRepository
    {
        public static IEnumerable<EmployeeDto> GetEmployees(EmployeeQueryViewModel cond) {
			using var conn = new SqlConnection(SqlDB.ConnectionString);

			var sql = @"SELECT Rtrim(EmpId) EmpId, EmpNm, IdNumber, IsForeign, 
                        Gender, IsMarried, BirthDate, HireDate, 
                        ResignDate, ResignReason, JobLevel, CustomSalary, 
                        EmployeeType, IsWelfareMember, Shift, DepId, Rtrim(MgrId) MgrId, 
                        Address_Registered, Address_Contact, Email, 
                        ImgFileName, Memo, Rtrim(Reviser) Reviser, ReviseDate,
                        Rtrim(Tel) Tel, EmergencyContact,
                        ImgPositionX, ImgPositionY, ImgZoom
                        FROM Employee WHERE 1 = 1";

			var dbArgs = new DynamicParameters();
			if (cond != null) {
				if (!string.IsNullOrWhiteSpace(cond.EmpId))
				{
					sql += " AND EmpId LIKE @EmpId";
					dbArgs.Add("EmpId", $"%{cond.EmpId}%");
				}

				if (!string.IsNullOrWhiteSpace(cond.EmpNm))
				{
					sql += " AND EmpNm LIKE @EmpNm";
					dbArgs.Add("EmpNm", $"%{cond.EmpNm}%");
				}

				if (!string.IsNullOrWhiteSpace(cond.DepId))
				{
					sql += " AND DepId = @DepId";
					dbArgs.Add("DepId", cond.DepId);
				}

				if (cond.CuseY == true && cond.CuseN == false)
				{
					sql += " AND ResignDate IS NULL"; // 在職
				}
				else if (cond.CuseY == false && cond.CuseN == true)
				{
					sql += " AND ResignDate IS NOT NULL"; // 已離職
				}
			}

			var list = conn.Query<EmployeeDto>(sql, dbArgs);

            return list;
        }
	}
}
