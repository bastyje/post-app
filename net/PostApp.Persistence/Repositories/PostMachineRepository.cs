using PostApp.Application.Common.Interfaces;
using PostApp.Domain.Entities;
using PostApp.Persistence.Interfaces;

namespace PostApp.Persistence.Repositories;

public class PostMachineRepository : BaseRepository<PostMachine, int>, IPostMachineRepository
{
    public PostMachineRepository(IAppDbContext appDbContext) : base(appDbContext) {}
    
    public PostMachine GetPostMachineByName(string name)
    {
        return AppDbContext.Set<PostMachine, int>().FirstOrDefault(p => p.Name == name);
    }
}