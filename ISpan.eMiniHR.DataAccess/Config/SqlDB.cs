using System.Configuration;

namespace ISpan.eMiniHR.DataAccess.Config
{
    public class SqlDB
    {
        /// <summary>
        /*
        using (var conn = new SqlConnection(SqlDB.DprConnectionString))
        {
            var result = conn.Query<Employee>("SELECT * FROM Employee").ToList();
        }
        */
        /// </summary>
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["HR"].ConnectionString;
    }
}
