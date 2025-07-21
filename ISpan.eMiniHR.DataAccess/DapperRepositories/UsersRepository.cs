using Dapper;
using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace ISpan.eMiniHR.DataAccess.DapperRepositories
{
    public static class UsersRepository
    {
        /// <summary>
        /// 系統權限設定
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<UsersDto> GetUsers()
        {
            using var conn = new SqlConnection(SqlDB.ConnectionString);

            var sql = @"SELECT UserId, Account, AccountName,
                        PasswordHash, IsActive, SysRole,
                        CreateDate, LastLoginTime
                        FROM Users";

            DynamicParameters dbArgs = new DynamicParameters();
            dbArgs.Add("EmpId", "");

            var list = conn.Query<UsersDto>(sql, dbArgs);

            return list;
        }
    }
}
