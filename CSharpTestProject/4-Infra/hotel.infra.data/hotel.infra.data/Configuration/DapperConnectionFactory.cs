using System.Data.SqlClient;

namespace hotel.infra.data.Configuration
{
    public class DapperConnectionFactory
    {
        public static SqlConnection Connection(string connectionStr) => new SqlConnection(connectionStr);
    }
}
