using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace API.Shared.Helper
{
    public class DbConnectionHelper
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DbConnectionHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("APICon")!;
        }
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}