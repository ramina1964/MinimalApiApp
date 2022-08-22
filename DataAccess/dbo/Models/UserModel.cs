namespace DataAccess.dbo.Models;

public class UserModel
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime? DoB { get; set; }

    public string? EmailAddress { get; set; }
}
