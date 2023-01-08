using PostApp.Application.Common.Mappings;
using PostApp.Domain.Entities;

namespace PostApp.Application.PostMachines.Queries.GetPostMachine;

public class GetPostMachineModel : IMapFrom<PostMachine>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string PreciseLocation { get; set; }
}