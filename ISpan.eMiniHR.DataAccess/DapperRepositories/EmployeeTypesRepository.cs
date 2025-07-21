using Dapper;
using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace ISpan.eMiniHR.DataAccess.DapperRepositories
{
    public class EmployeeTypesRepository
    {
        /// <summary>
        /// 取得員工職等
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<EmployeeTypesDto> GetEmployeeTypes ()
        {
            using var conn = new SqlConnection(SqlDB.ConnectionString);

            var sql = @"SELECT TypeCode, TypeName 
                        FROM EmployeeTypes";

            DynamicParameters dbArgs = new DynamicParameters();
            dbArgs.Add("", "");

            var list = conn.Query<EmployeeTypesDto>(sql, dbArgs);

            return list;
        }
    }
}
