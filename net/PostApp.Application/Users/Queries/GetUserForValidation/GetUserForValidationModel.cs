using PostApp.Application.Common.Mappings;
using PostApp.Domain.Entities;

namespace PostApp.Application.Users.Queries.GetUserForValidation;

public class GetUserForValidationModel : IMapFrom<ApplicationUser>
{
    public string Id { get; set; }
    public string PasswordHash { get; set; }
}