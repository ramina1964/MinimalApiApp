namespace DataAccess.dbo.Data;

public class UserService : IUserService
{
    public UserService(ISqlDataAccess db) => _db = db;
    
    public Task<IEnumerable<UserModel>> GetAll() =>
        _db.LoadData<UserModel, dynamic>("spUser_GetAll", new { });

    public async Task<UserModel?> Get(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("User Id must be a positive integer.", $"{nameof(userId)}: {userId}");

        var result = (await _db.LoadData<UserModel, dynamic>("spUser_Get", new { Id = userId })).FirstOrDefault();
        if (result == null)
            throw new ArgumentException("No user found with the given argument.", $"{nameof(userId)}: {userId}");

        return result;
    }

    public async Task<int> InsertUser(IUserModel user) 
    {
        var userId = user.Id;
        if (user.Id != 0)
            throw new ArgumentException("Argument must be zero or non-existent.", $"{nameof(userId)}: {userId}");

        // Todo: Validate user data, possibly throw ArguentException().
        var noOfRows = await _db.SaveData("spUser_Insert", new { user.FirstName, user.LastName, user.DoB, user.EmailAddress });
        
        // Throw ArgumentException() if formatting is wrong.
        if (noOfRows <= 0)
            throw new ArgumentException("User data is not correctly formatted.", $"{nameof(user)}: {user}");

        return noOfRows;
    }

    public async Task<int> UpdateUser(IUserModel user)
    {
        var userId = user.Id;
        if (user.Id <= 0)
            throw new ArgumentException("Argument must be greater than zero.", $"{nameof(userId)}: {userId}");

        // Todo: Validate user data, possibly throw ArguentException().
        var noOfRows = await _db.SaveData("spUser_Update", user);
        if (noOfRows <= 0)
            throw new ArgumentException("User data is not correctly formatted.", $"{nameof(user)}: {user}");

        return noOfRows;
    }

    public async Task<int> DeleteUser(int userId)
    {
        if (userId <= 0)
            throw new ArgumentException("Argument must be greater than zero.", $"{nameof(userId)}: {userId}");

        var noOfRows = await _db.SaveData("spUser_Delete", new { Id = userId });
        if (noOfRows <= 0)
            throw new ArgumentException("No user found with the given argument.", $"{nameof(userId)}: {userId}");

        return noOfRows;
    }

    private readonly ISqlDataAccess _db;
}
