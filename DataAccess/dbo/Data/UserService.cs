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
        if (userId <= 0)
            throw new ArgumentException(
                message: "User Id must be a positive integer.",
                paramName: $"{nameof(userId)}: {userId}");

        var result = await _db.LoadData<UserModel, dynamic>(
            storedProcedure: "spUser_Get",
            parameters: new { Id = userId });

        return result.FirstOrDefault();
    }

    public async Task<int> InsertUser(IUserModel user)
    {
        var userId = user.Id;

        if (user.Id != 0)
            throw new ArgumentException(
                message: "Argument must be zero or non-existent.",
                paramName: $"{nameof(userId)}: {userId}");

        var noOfRows = await _db.SaveData(
            storedProcedure: "spUser_Insert",
            parameters: new { user.FirstName, user.LastName, user.DoB, user.EmailAddress });

        if (noOfRows <= 0)
            throw new ArgumentException(
                message: "User data is not correctly formatted.",
                paramName: $"{nameof(user)}: {user}");

        return noOfRows;
    }

    public async Task<int> UpdateUser(IUserModel user)
    {
        var userId = user.Id;
        if (user.Id <= 0)
            throw new ArgumentException(
                message: "Argument must be greater than zero.",
                paramName: $"{nameof(userId)}: {userId}");

        var noOfRows = await _db.SaveData("spUser_Update", user);
        if (noOfRows <= 0)
            throw new ArgumentException(
                message: "User data is not correctly formatted.",
                paramName: $"{nameof(user)}: {user}");

        return noOfRows;
    }

    public async Task<int> DeleteUser(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException(
                message: "Argument must be greater than zero.",
                paramName: $"{nameof(userId)}: {userId}");

        var noOfRows = await _db.SaveData(
            storedProcedure: "spUser_Delete",
            new { Id = userId });

        if (noOfRows <= 0)
            throw new ArgumentException(
                message: "No user found with the given user id.",
                paramName: $"{nameof(userId)}: {userId}");

        return noOfRows;
    }

    private readonly ISqlDataAccess _db;
}
