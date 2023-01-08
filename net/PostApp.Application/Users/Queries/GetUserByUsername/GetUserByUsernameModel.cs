using PostApp.Application.Common.Mappings;
using PostApp.Domain.Entities;

namespace PostApp.Application.Users.Queries.GetUserByUsername;

public class GetUserByUsernameModel : IMapFrom<ApplicationUser>
{
    public string Id { get; set; }
}