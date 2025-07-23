using Dapper;
using ISpan.eMiniHR.DataAccess.Config;
using ISpan.eMiniHR.DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace ISpan.eMiniHR.DataAccess.DapperRepositories
{
    public class ProgramPermissionsRepository
    {
        /// <summary>
        /// 取得員工職等
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ProgramPermissionsDto> GetProgramPermissions(string EmpId, bool onlyTrue)
        {
            using var conn = new SqlConnection(SqlDB.ConnectionString);

            var sql = @"SELECT Rtrim(c.ProgSysId) ProgSysId, c.ProgName, e.EmpId, 
                            ISNULL(p.Queryable, 0) Queryable, ISNULL(p.Addable, 0) Addable, ISNULL(p.Editable, 0) Editable,
                            ISNULL(p.Deletable, 0) Deletable, ISNULL(p.Voidable, 0) Voidable, ISNULL(p.Printable, 0) Printable,
                            ISNULL(p.Downloadable, 0) Downloadable, ISNULL(Testable, 0) Testable
                        FROM Employee e
                        CROSS JOIN ProgramsConfig c
                        LEFT JOIN ProgramPermissions p ON p.ProgSysId = c.ProgSysId AND p.EmpId = e.EmpId
                        WHERE c.IsCommon = 0 AND c.IsActive = 1 AND c.ProgSysCode <> 'MIS' AND e.EmpId = @EmpId
                            AND (
                                @OnlyTrue = 0
                                OR
                                (
                                    ISNULL(p.Queryable, 0) = 1 OR ISNULL(p.Addable, 0) = 1 OR ISNULL(p.Editable, 0) = 1
                                    OR ISNULL(p.Deletable, 0) = 1 OR ISNULL(p.Voidable, 0) = 1 OR ISNULL(p.Printable, 0) = 1
                                    OR ISNULL(p.Downloadable, 0) = 1 OR ISNULL(p.Testable, 0) = 1
                                )
                            )
                        ORDER BY c.ProgSysCode DESC, c.SortOrder DESC;";

            DynamicParameters dbArgs = new DynamicParameters();
            dbArgs.Add("@EmpId", EmpId);
            dbArgs.Add("@OnlyTrue", onlyTrue ? 1 : 0);

            var list = conn.Query<ProgramPermissionsDto>(sql, dbArgs);

            return list;
        }
    }
}
