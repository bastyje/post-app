using PostApp.Domain.Entities;

namespace PostApp.Application.Common.Interfaces;

public interface IPostMachineRepository : IBaseRepository<PostMachine, int>
{
    PostMachine GetPostMachineByName(string name);
}