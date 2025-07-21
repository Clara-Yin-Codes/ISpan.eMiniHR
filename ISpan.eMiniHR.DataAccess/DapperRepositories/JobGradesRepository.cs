using Dapper;
using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace ISpan.eMiniHR.DataAccess.DapperRepositories
{
    public class JobGradesRepository
    {
        /// <summary>
        /// 工作職等資料存取
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<JobGradesDto> GetJobGrades()
        {
            using var conn = new SqlConnection(SqlDB.ConnectionString);

            var sql = @"SELECT JobLevelCode, JobLevelName, BaseSalary, Note 
                        FROM JobGrades";

            DynamicParameters dbArgs = new DynamicParameters();
            dbArgs.Add("", "");

            var list = conn.Query<JobGradesDto>(sql, dbArgs);

            return list;
        }
    }
}
