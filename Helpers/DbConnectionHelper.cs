using System.Data.SqlClient;
using System.Configuration;

namespace Library_Management_System.Helpers
{ 
    public class DbConnectionHelper : IDisposable
    {
        private SqlConnection con;

        public DbConnectionHelper()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        }

        public SqlConnection GetConnection()
        {
            return con;
        }

        public void Dispose()
        {
            con?.Dispose();
        }
    }
}
