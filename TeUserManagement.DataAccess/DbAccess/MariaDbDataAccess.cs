using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using MySqlConnector;
using TeUserManagement.Domain.Helpers;

namespace TeUserManagement.DataAccess.DbAccess
{
    public class MariaDbDataAccess : IMariaDbDataAccess
    {
        private readonly AppSettings _appSettings;
        public MariaDbDataAccess(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters)
        {
            using IDbConnection connection = new MySqlConnection(_appSettings.MariaDbSupplier.ConnectionString);

            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, T parameters)
        {
            using IDbConnection connection = new MySqlConnection(_appSettings.MariaDbSupplier.ConnectionString);
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
