namespace BlazorServerUI.Pages;

public partial class CreateUser
{
    private async Task HandleValidSubmit()
    {
        await dataservice.InsertUser(_displayUser);
        _displayUser = new DisplayUserModel();
    }

    private IUserModel _displayUser = new DisplayUserModel();
}
