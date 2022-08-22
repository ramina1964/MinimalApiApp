namespace MinimalAPI;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/Users", GetAllUsers);

        app.MapGet("/Users/{id}", GetUser);

        app.MapPost("/Users", InsertUser);

        app.MapPut("/Users", UpdateUser);

        app.MapDelete("/Users", DeleteUser);
    }

    private static async Task<IResult> GetAllUsers(IUserData data)
    {
        try
        {
            return Results.Ok(await data.GetAll());
        }

        catch (Exception ex)
        {
            return Results.Problem($"A error occurred, see below:\n{ex.Message}");
        }
    }

    private static async Task<IResult> GetUser(IUserData data, int id)
    {
        try
        {
            return Results.Ok(await data.Get(id));
        }

        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(IUserData data, UserModel user)
    {
        try
        {
            return Results.Ok(await data.InsertUser(user));
        }

        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(IUserData data, UserModel user)
    {
        try
        {
            return Results.Ok(await data.UpdateUser(user));
        }

        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(IUserData data, int id)
    {
        try
        {
            return Results.Ok(await data.DeleteUser(id));
        }

        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
