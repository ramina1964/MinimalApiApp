namespace DataAccess.dbo.Data;

public interface IUserData
{
    Task<IEnumerable<UserModel>> GetAll();

    Task<UserModel?> Get(int id);

    Task<int> InsertUser(IUserModel user);

    Task<int> UpdateUser(IUserModel user);

    Task<int> DeleteUser(int id);
}
