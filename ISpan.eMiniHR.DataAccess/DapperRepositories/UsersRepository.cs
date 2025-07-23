using Dapper;
using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ISpan.eMiniHR.DataAccess.DapperRepositories
{
	public class UserQueryViewModel
	{
		public string? account { get; set; }
		public bool? isActive { get; set; } = true;
		public bool? isNotActive { get; set; } = true;
	}

	public static class UsersRepository
    {
        /// <summary>
        /// 取得使用者清單（透過預存程序）
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<UsersDto> GetUsers(UserQueryViewModel cond)
        {
            using var conn = new SqlConnection(SqlDB.ConnectionString);

            var sql = "GetUsers"; // 預存程序名稱

            var dbArgs = new DynamicParameters();
            dbArgs.Add("@Account", cond.account, DbType.String);
            dbArgs.Add("@IsActive", cond.isActive, DbType.Boolean);
            dbArgs.Add("@IsNotActive", cond.isNotActive, DbType.Boolean);

            // 強制轉為 List，避免多次查詢延遲執行
            var list = conn.Query<UsersDto>(sql, dbArgs)
                           .OrderByDescending(a => a.IsActive)
                           .ThenBy(a => a.Account)
                           .ToList();

            // 每位使用者載入對應權限
            foreach (var item in list)
            {
                if (item.SysRole == "user") {
                    item.Permissions = ProgramPermissionsRepository.GetProgramPermissions(item.Account, false);
                }
            }

            return list;
        }
    }
}
