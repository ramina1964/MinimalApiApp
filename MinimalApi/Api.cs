namespace MinimalApi;

// Todo: Review Exception Handling in this project
public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/Users", GetAll);

        app.MapGet("/Users/{id}", Get);

        app.MapPost("/Users", InsertUser);

        app.MapPut("/Users", UpdateUser);

        app.MapDelete("/Users", DeleteUser);
    }

    private static async Task<IResult> GetAll(IUserData data)
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

    private static async Task<IResult> Get(IUserData data, int id)
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

    private static async Task<IResult> InsertUser(IUserData data, [FromBody] UserModel user)
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

    private static async Task<IResult> UpdateUser(IUserData data, [FromBody] UserModel user)
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

    private static async Task<IResult> DeleteUser(IUserData data, int id)
    {
        try
        {
            var output = await data.DeleteUser(id);
            return Results.Ok(output);
        }

        catch (Exception ex)
        {
            return Results.Problem($"An error occurred!", ex.Message);
        }
    }
}
