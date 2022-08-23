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

    private void UpdateUser(int id)
    {
        idToUpdate = id;
        showEditForm = true;
    }

    private void HandleOnUpdate(IUserModel user)
    {
        showEditForm = false;
        var userToUpdate = _users.Where(x => x.Id == user.Id).FirstOrDefault();
        if (userToUpdate is not null)
        {
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.DoB = user.DoB;
            userToUpdate.EmailAddress = user.EmailAddress;
        }
    }

    private List<IUserModel> _users = new();
    private bool showEditForm = false;
    private int idToUpdate = 0;
}
