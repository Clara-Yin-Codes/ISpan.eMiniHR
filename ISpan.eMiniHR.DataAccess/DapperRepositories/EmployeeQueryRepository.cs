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
	public static class EmployeeQueryRepository
    {
        public static IEnumerable<EmployeeDto> GetEmployees() {
			using var conn = new SqlConnection(SqlDB.ConnectionString);

			var sql = @"SELECT Rtrim(EmpId) EmpId, EmpNm, IdNumber, IsForeign, 
                        Gender, IsMarried, BirthDate, HireDate, 
                        ResignDate, ResignReason, JobLevel, CustomSalary, 
                        EmployeeType, IsWelfareMember, Shift, DepId, Rtrim(MgrId) MgrId, 
                        Address_Registered, Address_Contact, Email, 
                        ImgFileName, Memo, Rtrim(Reviser) Reviser, ReviseDate,
                        Rtrim(Tel) Tel, EmergencyContact,
                        ImgPositionX, ImgPositionY, ImgZoom
                        FROM Employee";

            DynamicParameters dbArgs = new DynamicParameters();
            dbArgs.Add("EmpId", "");

            var list = conn.Query<EmployeeDto>(sql, dbArgs);

            return list;
        }
	}
}
