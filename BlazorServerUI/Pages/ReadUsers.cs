using DataAccess.dbo.Models;

namespace BlazorServerUI.Pages;

public partial class ReadUsers
{
    protected override async Task OnParametersSetAsync()
    {
        var u = (await userData.GetAll()).ToList<IUserModel>();
        if (u is not null)
        {
            _users = u;
        }
    }

    private List<IUserModel> _users = new();

}
