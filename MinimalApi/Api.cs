namespace MinimalAPI;

// Todo: Review Exception Handling in this project
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
            var output = await data.GetAll();
            return Results.Ok(output);
        }

        catch (Exception)
        {
            return Results.Problem($"An error occurred!");
        }
    }

    private static async Task<IResult> GetUser(IUserService data, int id)
    {
        try
        {
            var output = await data.Get(id);
            return Results.Ok(output);
        }

        catch (Exception)
        {
            return Results.Problem($"An error occurred!");
        }
    }

    private static async Task<IResult> InsertUser(IUserService data, [FromBody] UserModel user)
    {
        try
        {
            var output = await data.InsertUser(user);
            return Results.Ok(output);
        }

        catch (Exception)
        {
            return Results.Problem($"An error occurred!");
        }
    }

    private static async Task<IResult> UpdateUser(IUserService data, [FromBody] UserModel user)
    {
        try
        {
            var output = await data.UpdateUser(user);
            return Results.Ok(output);
        }

        catch (Exception)
        {
            return Results.Problem($"An error occurred!");
        }
    }

    private static async Task<IResult> DeleteUser(IUserService data, int id)
    {
        try
        {
            var output = await data.DeleteUser(id);
            return Results.Ok(output);
        }

        catch (Exception)
        {
            return Results.Problem($"An error occurred!");
        }
    }
}
