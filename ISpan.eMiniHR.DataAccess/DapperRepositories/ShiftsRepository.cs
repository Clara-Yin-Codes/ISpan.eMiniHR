using Dapper;
using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace ISpan.eMiniHR.DataAccess.DapperRepositories
{
    public class ShiftsRepository
    {
        /// <summary>
        /// 取得班別清單
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ShiftDto> GetShifts()
        {
            using var conn = new SqlConnection(SqlDB.ConnectionString);

            var sql = @"SELECT ShiftCode, ShiftName FROM Shifts";

            DynamicParameters dbArgs = new DynamicParameters();
            dbArgs.Add("", "");

            var list = conn.Query<ShiftDto>(sql, dbArgs);

            return list;
        }
    }
}
