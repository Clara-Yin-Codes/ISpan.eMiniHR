using Dapper;
using ISpan.eMiniHR.DataAccess.Config;
using Microsoft.Data.SqlClient;

namespace ISpan.eMiniHR.DataAccess.Helpers
{
    public static class IdGenerator
    {
        /// <summary>
        /// 序號設定
        /*
        var generatorParam = new IdGeneratorParams
        {
            TableName = "Employee",
            ColumnName = "EmpId",
            Prefix = DateTime.Now.ToString("yyMM"), // 例：2507
            SerialLength = 6
        };
        */
        /// </summary>
        public class IdGeneratorParams
        { 
            public string tableName { get; set; } = string.Empty; // 資料表名稱
            public string columnName { get; set; } = string.Empty; // 欄位名稱
            public string prefix { get; set; } = string.Empty; // 前綴字串
            public int SerialLength { get; set; } = 3; // 序號最大長度
        }

        public static string GetNextId(IdGeneratorParams param)
        {
            using var conn = new SqlConnection(SqlDB.ConnectionString);

            string sql = $@"
                SELECT MAX(CAST(SUBSTRING({param.columnName}, {param.prefix.Length + 1}, 
                {param.SerialLength}) AS INT))
                FROM {param.tableName}
                WHERE {param.columnName} LIKE @Prefix + '%'
            ";

            int maxSerial = conn.QueryFirstOrDefault<int?>(sql, new { Prefix = param.prefix }) ?? 0;
            int nextSerial = maxSerial + 1;
            return param.prefix + nextSerial.ToString($"D{param.SerialLength}");
        }
    }
}
