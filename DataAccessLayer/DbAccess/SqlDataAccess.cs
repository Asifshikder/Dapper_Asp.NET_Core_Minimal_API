using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DbAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameter, string connectionId = "constring")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(storedProcedure, parameter, commandType: CommandType.StoredProcedure);
        }
        public async Task SaveData<T>(string storedProcedure, T parameter, string connectionId = "constring")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));
            await connection.ExecuteAsync(storedProcedure, parameter, commandType: CommandType.StoredProcedure);
        }
    }
}
