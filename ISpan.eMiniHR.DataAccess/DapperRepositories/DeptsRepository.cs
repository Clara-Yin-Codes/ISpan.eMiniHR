using Dapper;
using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace ISpan.eMiniHR.DataAccess.DapperRepositories
{
    public class DeptsRepository
    {
        /// <summary>
        /// 取得部門清單
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DeptsDto> GetDepts()
        {
            using var conn = new SqlConnection(SqlDB.ConnectionString);

            var sql = @"SELECT DepId, DepName, DeptManagerId
                        FROM Depts";

            DynamicParameters dbArgs = new DynamicParameters();
            dbArgs.Add("", "");

            var list = conn.Query<DeptsDto>(sql, dbArgs);

            return list;
        }
    }
}
