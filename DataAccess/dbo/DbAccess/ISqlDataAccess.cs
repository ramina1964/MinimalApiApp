﻿namespace DataAccess.dbo.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");

        Task<int> SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default");
    }
}