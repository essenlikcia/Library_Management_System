using System.Data.SqlClient;

namespace Library_Management_System.Helpers
{
    public class SqlCommandHelper
    {
        private SqlCommand cmd;

        public SqlCommandHelper(SqlConnection con)
        {
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public SqlCommand GetCommandWithParameters(string query, Dictionary<string, object> parameters)
        {
            cmd.CommandText = query;
            foreach (var param in parameters)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value);
            }
            return cmd;
        }
        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            cmd.CommandText = query;
            foreach (var param in parameters)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value);
            }
            return cmd.ExecuteNonQuery();
        }
    }
}