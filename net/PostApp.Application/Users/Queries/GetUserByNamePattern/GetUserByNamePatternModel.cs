using PostApp.Application.Common.Mappings;
using PostApp.Domain.Entities;

namespace PostApp.Application.Users.Queries.GetUserByNamePattern;

public class GetUserByNamePatternModel : IMapFrom<ApplicationUser>
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class GetUserByNamePatternListModel
{
    public List<GetUserByNamePatternModel> Users { get; set; }
}