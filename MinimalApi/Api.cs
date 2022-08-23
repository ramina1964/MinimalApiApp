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

    private static async Task<IResult> GetAllUsers(IUserService data)
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

    private static async Task<IResult> GetUser(IUserService data, int id)
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

    private static async Task<IResult> InsertUser(IUserService data, UserModel user)
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

    private static async Task<IResult> UpdateUser(IUserService data, UserModel user)
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

    private static async Task<IResult> DeleteUser(IUserService data, int id)
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
