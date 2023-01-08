using PostApp.Application.Common.Mappings;
using PostApp.Application.Common.Models;
using PostApp.Domain.Entities;

namespace PostApp.Application.PostMachines.Queries.GetAllPostMachines;

public class GetAllPostMachinesListModel
{
   public PaginationResponse<GetAllPostMachinesModel> PostMachines { get; set; }
}