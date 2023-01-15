﻿namespace DataAccess.dbo.Data;

public interface IUserService
{
    Task<List<UserModel>> GetAll();

    Task<UserModel?> Get(int id);

    Task<int> InsertUser(IUserModel user);

    Task<int> UpdateUser(IUserModel user);

    Task<int> DeleteUser(int id);
}
