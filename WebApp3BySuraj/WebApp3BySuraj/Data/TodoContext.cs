using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApp3BySuraj.Data
{
    public class TodoContext
    {
        private readonly string _connectionString;

        public TodoContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
