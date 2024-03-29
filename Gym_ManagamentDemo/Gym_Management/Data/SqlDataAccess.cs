﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;

namespace Gym_Management.Data
{
    public class SqlDataAccess
    {
        private readonly string _connectionString;

        private readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;

            _connectionString = _configuration.GetConnectionString("default");
        }

        public SqlConnection GetConnection() => new SqlConnection(_connectionString);
    }
}
