namespace BlazorServerUI.Data;

public class DisplayUserModel : IUserModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "A valid name must have a length in the interval [2, 50] characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "A valid name must have a length in the interval [2, 50] characters.")]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Date, ErrorMessage = "DoB must be inside the range [1753-01-01, 1999-12-31].")]
    public DateTime DoB { get; set; } = DateTime.Now;

    [EmailAddress]
    public string? EmailAddress { get; set; }
}
