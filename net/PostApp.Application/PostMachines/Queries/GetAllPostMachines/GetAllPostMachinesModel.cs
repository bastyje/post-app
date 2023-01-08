using AutoMapper;
using PostApp.Application.Common.Mappings;
using PostApp.Application.Common.Models;
using PostApp.Application.Packages.Queries.GetAllPackages;
using PostApp.Domain.Entities;

namespace PostApp.Application.PostMachines.Queries.GetAllPostMachines;

public class GetAllPostMachinesModel : IMapFrom<PostMachine>, IPaginationMapping<PostMachine>
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