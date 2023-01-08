using PostApp.Application.Common.Mappings;
using PostApp.Domain.Dictionaries;

namespace PostApp.Application.Dictionaries.Queries.GetStatusList;

public class GetStatusModel : IMapFrom<Status>
{
    public int Id { get; set; }
    public string Name { get; set; }
}