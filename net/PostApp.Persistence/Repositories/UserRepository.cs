using Microsoft.EntityFrameworkCore;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;
using PostApp.Domain.Entities;
using PostApp.Persistence.Interfaces;

namespace PostApp.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IAppDbContext _appDbContext;
    public UserRepository(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public ApplicationUser GetByUsername(string username)
    {
        return _appDbContext.ApplicationUser.FirstOrDefault(u => u.Id == username);
    }

    public void Add(ApplicationUser entity)
    {
        _appDbContext.ApplicationUser.Add(entity);
    }

    public void Update(ApplicationUser entity)
    {
        _appDbContext.ApplicationUser.Update(entity);
    }

    public void Delete(ApplicationUser entity)
    {
        _appDbContext.ApplicationUser.Remove(entity);
    }

    public Task<ApplicationUser> GetAsync(string id, CancellationToken cancellationToken)
    {
        return _appDbContext.ApplicationUser.FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public IQueryable<ApplicationUser> GetAll()
    {
        return _appDbContext.ApplicationUser;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _appDbContext.SaveChangesAsync(cancellationToken);
    }

    public IQueryable<ApplicationUser> GetFiltered(Func<ApplicationUser, bool> expression)
    {
        return _appDbContext.ApplicationUser.Where(expression).AsQueryable();
    }
}