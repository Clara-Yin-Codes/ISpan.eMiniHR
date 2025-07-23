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
        public static LoginUserInfoDto? GetLogin(string account, byte[] password, bool testFlag = false)
        {
            try
            {
                using var conn = new SqlConnection(SqlDB.ConnectionString);

                // 呼叫預存程序 sp_LoginUser
                var user = conn.QueryFirstOrDefault<LoginUserInfoDto>(
                    "sp_LoginUser2",
                    new { Account = account, Password = password, TestFlag = testFlag },
                    commandType: CommandType.StoredProcedure
                );

                if (user == null)
                    throw new Exception("查無資料");

                // 一次性查權限並設定
                if (!user.IsAdmin) user.Permissions = ProgramPermissionsRepository.GetProgramPermissions(user.Account, true).ToList();

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
    }
}
