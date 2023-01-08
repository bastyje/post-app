using AutoMapper;
using PostApp.Application.Common.Models;

namespace PostApp.Application.Common.Mappings;

public interface IPaginationMapping<TSrc>
{
    void PaginationMapping(Profile profile) => profile.CreateMap(typeof(PaginationResponse<TSrc>), typeof(PaginationResponse<>).MakeGenericType(GetType()));
}