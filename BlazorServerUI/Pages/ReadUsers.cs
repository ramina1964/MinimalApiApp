namespace BlazorServerUI.Pages;

public partial class ReadUsers
{
    protected override async Task OnParametersSetAsync()
    {
        var u = (await userService.GetAll()).ToList<IUserModel>();
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

    private async Task DeleteUser(int id)
    {
        var personToDelete = _users.Where(x => x.Id == id).FirstOrDefault();
        if (personToDelete is not null)
        {
            await userService.DeleteUser(id);
            _users.Remove(personToDelete);
            idToDelete = 0;
        }
    }

    private List<IUserModel> _users = new();
    private bool showEditForm = false;
    private int idToUpdate = 0;
    private int idToDelete = 0;
}
