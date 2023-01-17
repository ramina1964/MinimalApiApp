namespace DataAccess.dbo.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    public SqlDataAccess(IConfiguration config) => _config = config;

    public async Task<List<T>> LoadData<T, U>(
           string storedProcedure,
           U parameters,
           string connectionId = "Default")
    {
        var connectionString = _config.GetConnectionString(connectionId);
        using IDbConnection connection = new SqlConnection(connectionString);
        var results = await connection.QueryAsync<T>(
              sql: storedProcedure,
              param: parameters,
              commandType: CommandType.StoredProcedure);

        return results.ToList();
    }

    public async Task<int> SaveData<T>(
           string storedProcedure,
           T parameters,
           string connectionId = "Default")
    {
        var connectionString = _config.GetConnectionString(connectionId);
        using IDbConnection connection = new SqlConnection(connectionString);
        var output = await connection.ExecuteAsync(
               sql: storedProcedure,
               param: parameters,
               commandType: CommandType.StoredProcedure);

        return output;
    }

    private readonly IConfiguration _config;
}
