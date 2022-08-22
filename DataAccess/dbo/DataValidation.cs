namespace DataAccess.dbo;

public static class DataValidation
{
    public static bool CheckUserId(int userId, CrudOperation operation)
    {
        return operation switch
        {
            CrudOperation.Insert => userId == 0,

            // For all other operations, i.e., Get, Update, and Delete, we must have an Id > 0.
            _ => userId > 0,
        };
    }

    public static bool CheckUserData(UserModel user)
    {
        var isUserOk =
            string.IsNullOrWhiteSpace(user.FirstName?.Trim()) == false &&
            user.FirstName.Equals("string", StringComparison.InvariantCultureIgnoreCase) == false &&
            string.IsNullOrWhiteSpace(user.LastName?.Trim()) == false &&
            user.LastName.Equals("string", StringComparison.InvariantCultureIgnoreCase) == false;

        return isUserOk;
    }
}
