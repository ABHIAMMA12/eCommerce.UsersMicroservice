using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace UsersMicroservice.Infrastructure.DbContext
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _connection;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionStringtemplate = _configuration.GetConnectionString("UsersConnection")!;
            string connectionString = connectionStringtemplate.Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST"))
           .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"));

            //Create a new NpgsqlConnection with the retrieved connection string
            _connection = new NpgsqlConnection(connectionString);

        }
        //property to get the connection value
        public IDbConnection DbConnection => _connection;
    }
}
