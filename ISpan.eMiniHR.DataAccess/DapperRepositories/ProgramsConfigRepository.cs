using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Text;

public class ProgramsConfigRepository
{
    public List<ProgramsConfigDto> GetAllMenu(List<string> progArr = null)
    {
        try
        {
            using (var conn = new SqlConnection(SqlDB.ConnectionString))
            {
                var sql = new StringBuilder();
                sql.Append("SELECT p.ProgSysCode, s.SystemName, p.ProgSysId, ");
                sql.Append("p.ProgId, p.ProgName, p.IsCommon, p.SortOrder ");
                sql.Append("FROM ProgramsConfig p "); // 取得有效的程式
                sql.Append("JOIN Systems s ON s.SystemCode=p.ProgSysCode ");
                sql.Append("WHERE IsActive = 1");

                if (progArr!=null) sql.Append("AND ProgSysId in @progArr");
                var result = conn.Query<ProgramsConfigDto>(
                    sql.ToString(), new { progArr }).OrderByDescending(a => a.ProgSysCode).ThenBy(a=>a.SortOrder).ToList();

                return result;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
}

