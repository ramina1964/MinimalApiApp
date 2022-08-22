namespace DataAccess.dbo.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    public SqlDataAccess(IConfiguration config) => _config = config;

    public async Task<IEnumerable<T>> LoadData<T, U>(
           string storedProcedure,
           U parameters,
           string connectionId = "Default")
    {
        var connectionString = _config.GetConnectionString(connectionId);
        using IDbConnection connection = new SqlConnection(connectionString);
        return await connection.QueryAsync<T>(
              sql: storedProcedure,
              param: parameters,
              commandType: CommandType.StoredProcedure);
    }

    public async Task<int> SaveData<T>(
           string storedProcedure,
           T parameters,
           string connectionId = "Default")
    {
        var connectionString = _config.GetConnectionString(connectionId);
        using IDbConnection connection = new SqlConnection(connectionString);
        return await connection.ExecuteAsync(
               sql: storedProcedure,
               param: parameters,
               commandType: CommandType.StoredProcedure);
    }

    private readonly IConfiguration _config;
}
