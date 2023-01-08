using PostApp.Domain.Entities;

namespace PostApp.Application.Common.Interfaces;

public interface IUserRepository
{
    ApplicationUser GetByUsername(string username);
    void Add(ApplicationUser entity);
    void Update(ApplicationUser entity);
    void Delete(ApplicationUser entity);
    Task<ApplicationUser> GetAsync(string id, CancellationToken cancellationToken);
    IQueryable<ApplicationUser> GetAll();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    IQueryable<ApplicationUser> GetFiltered(Func<ApplicationUser, bool> expression); 
}