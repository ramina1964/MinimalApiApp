namespace DataAccess.dbo.Models;

public interface IUserModel
{
    int Id { get; set; }
    
    string FirstName { get; set; }

    string LastName { get; set; }

    DateTime DoB { get; set; }

    string? EmailAddress { get; set; }
}