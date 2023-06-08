namespace DataAccess.dbo.Data;

public interface IUserData
{
    Task<List<UserModel>> GetAll();

    Task<UserModel?> Get(int id);

    Task<UserModel?> InsertUser(IUserModel user);

    Task<UserModel?> UpdateUser(IUserModel user);

    Task<UserModel?> DeleteUser(int id);
}
