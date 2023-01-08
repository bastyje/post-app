using Microsoft.EntityFrameworkCore;
using PostApp.Domain.Entities;

namespace PostApp.Persistence.Interfaces;

public interface IAppDbContext
{
    DbSet<TEntity> Set<TEntity, TKey>() where TEntity : class, IEntityBase<TKey>;
    DbSet<ApplicationUser> ApplicationUser { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}