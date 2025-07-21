using Dapper;
using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ISpan.eMiniHR.DataAccess.DapperRepositories
{
    public class LoginRepository
    {
        /// <summary>
        /// 取得登入人員
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        public static LoginUserInfoDto? GetLogin(string account, string password, bool testFlag = false)
        {
            try
            {
                using var conn = new SqlConnection(SqlDB.ConnectionString);

                // 呼叫預存程序 sp_LoginUser
                var user = conn.QueryFirstOrDefault<LoginUserInfoDto>(
                    "sp_LoginUser",
                    new { Account = account, Password = password, TestFlag = testFlag },
                    commandType: CommandType.StoredProcedure
                );

                if (user == null)
                    throw new Exception("查無資料");

                // 一次性查權限並設定
                if (!user.IsAdmin) user.Permissions = ProgramPermission(user.EmpId).ToList();

                return user;
            }
            catch (SqlException sqlEx)
            {
                if (sqlEx.Number == 50000) return null;
                throw new ApplicationException(sqlEx.Message);
            }
        }

        /// <summary>
        /// 取得登入人員
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns></returns>
        public static IEnumerable<AccountsDto> GetAccounts()
        {
            try
            {
                using var conn = new SqlConnection(SqlDB.ConnectionString);

                // 呼叫預存程序 sp_LoginUser
                var user = conn.Query<AccountsDto>(
                    "sp_Accounts",
                    commandType: CommandType.StoredProcedure
                );

                if (user == null)
                    throw new Exception("查無資料");

                return user;
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException(sqlEx.Message);
            }
        }

        public static IEnumerable<ProgramPermissionDto> ProgramPermission(string EmpId)
        {
            try
            {
                using var conn = new SqlConnection(SqlDB.ConnectionString);

                var list = conn.Query<ProgramPermissionDto>(
                    @"SELECT ProgSysId, Queryable,
                        Addable, Editable, Deletable,
                        Voidable, Printable, Downloadable, Testable
                        FROM ProgramPermissions
                        WHERE EmpId = @EmpId", new { EmpId }
                ).ToList();

                if (list == null)
                    throw new Exception("查無資料");

                return list;
            }
            catch (SqlException sqlEx)
            {
                throw new ApplicationException(sqlEx.Message);
            }
        }
    }
}
