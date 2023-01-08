namespace PostApp.Application.Users.Queries.GetUserPermissions;

public class GetUserPermissionsModel
{
    public GetUserPermissionsModel()
    {
        Permissions = new List<string>();
    }
    
    public List<string> Permissions { get; }
}