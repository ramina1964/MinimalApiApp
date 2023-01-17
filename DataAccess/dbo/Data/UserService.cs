namespace DataAccess.dbo.Data;

// Todo: Review Exception Handling in this project
public class UserService : IUserService
{
    public UserService(ISqlDataAccess db) => _db = db;

    public Task<List<UserModel>> GetAll() =>
        _db.LoadData<UserModel, dynamic>(
            storedProcedure: "spUser_GetAll",
            parameters: new { });

    public async Task<UserModel?> Get(int userId)
    {
        var result = await _db.LoadData<UserModel, dynamic>(
            storedProcedure: "spUser_Get",
            parameters: new { Id = userId });

        return result.FirstOrDefault();
    }

    public async Task<UserModel?> InsertUser(IUserModel user)
    {
        var createdModel =
            (await _db.LoadData<UserModel, dynamic>(storedProcedure: "spUser_Insert", parameters: user))
            .FirstOrDefault();

        if (createdModel == null)
            throw new ArgumentException(
                message: "User data is not correctly formatted.",
                paramName: $"{nameof(user)}: {user}");

        return createdModel;
    }

    public async Task<UserModel?> UpdateUser(IUserModel user)
    {
        var updatedModel =
            (await _db.LoadData<UserModel, dynamic>("spUser_Update", user))
            .FirstOrDefault();

        if (updatedModel == null)
            throw new ArgumentException(
                message: "User data is not correctly formatted.",
                paramName: $"{nameof(user)}: {user}");

        return updatedModel;
    }

    public async Task<UserModel?> DeleteUser(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException(
                message: "Argument must be greater than zero.",
                paramName: $"{nameof(userId)}: {userId}");

        var deleted = (await _db.LoadData<UserModel, dynamic>(
            "spUser_GetAll", new { }))
            .FirstOrDefault();

        if (deleted == null)
            throw new ArgumentException(
                message: "No user found with the given user id.",
                paramName: $"{nameof(userId)}: {userId}");

        _ = await _db.SaveData("spUser_Delete", new { Id = userId });

        return deleted;
    }

    private readonly ISqlDataAccess _db;
}
