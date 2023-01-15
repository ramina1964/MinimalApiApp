namespace BlazorServerUI.Pages;

public partial class UpdateUser
{
    [Parameter]
    public int Id { get; set; }

    [Parameter]
    public EventCallback<IUserModel> OnUpdate { get; set; }

    protected override async Task OnParametersSetAsync()
    {
        var u = await userService.Get(Id);
        if (u is not null)
        {
            _user.Id = u.Id;
            _user.FirstName = u.FirstName;
            _user.LastName = u.LastName;
            _user.DoB = u.DoB;
            _user.EmailAddress = u.EmailAddress;
        }
    }

    private async Task HandleValidSubmit()
    {
        // Update user in the database, without a round trip.
        await userService.UpdateUser(_user);

        // Also Update the UI.
        await OnUpdate.InvokeAsync(_user);
    }

    private readonly DisplayUserModel _user = new DisplayUserModel();
}
