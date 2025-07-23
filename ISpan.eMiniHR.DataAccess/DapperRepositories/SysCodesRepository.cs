using Dapper;
using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace ISpan.eMiniHR.DataAccess.DapperRepositories
{
    public static class SysCodesRepository
	{
		public class SysCodesModel
		{
			public string? CodeId { get; set; } // 程式代號
			public string? ProgId { get; set; } // 程式代號
		}

		/// <summary>
		/// 系統權限設定
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<SysCodesDto> GetSysCodes(SysCodesModel cond)
        {
            using var conn = new SqlConnection(SqlDB.ConnectionString);

            var sql = @"SELECT CodeId, CodeNO, CodeDesc, 
                        GroupName, Memo, ProgId
                        FROM SysCodes WHERE Cuse = 1 AND CodeId <> '00'";

            var dbArgs = new DynamicParameters();

			if (cond != null) {
				if (!string.IsNullOrWhiteSpace(cond.CodeId))
				{
					sql += " AND CodeId = @CodeId";
					dbArgs.Add("@CodeId", cond.CodeId);
				}

				if (!string.IsNullOrWhiteSpace(cond.ProgId))
				{
					sql += " AND ProgId = @ProgId";
					dbArgs.Add("@ProgId", cond.ProgId);
				}
			}

            var list = conn.Query<SysCodesDto>(sql, dbArgs);

            return list;
        }
    }
}
