namespace DataAccess.dbo.Data;

public interface IUserData
{
    Task<IEnumerable<UserModel>> GetAll();

    Task<UserModel?> Get(int id);

    Task<int> InsertUser(UserModel user);

    Task<int> UpdateUser(UserModel user);

    Task<int> DeleteUser(int id);
}
