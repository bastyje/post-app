using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PostApp.Application.Common.Interfaces;
using PostApp.Application.Common.Models;
using PostApp.Domain.Entities;
using PostApp.Persistence.Extensions;
using PostApp.Persistence.Interfaces;

namespace PostApp.Persistence.Repositories;

public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class, IEntityBase<TKey>
{
    protected readonly IAppDbContext AppDbContext;

    protected BaseRepository(IAppDbContext appDbContext)
    {
        AppDbContext = appDbContext;
    }

    public void Add(TEntity entity)
    {
        AppDbContext.Set<TEntity, TKey>().Add(entity);
    }

    public void Delete(TEntity entity)
    {
        AppDbContext.Set<TEntity, TKey>().Remove(entity);
    }

    public IQueryable<TEntity> GetAll()
    {
        return AppDbContext.Set<TEntity, TKey>();
    }

    public Task<PaginationResponse<TEntity>> GetPaged(PaginationRequest paginationRequest, CancellationToken cancellationToken)
    {
        return AppDbContext.Set<TEntity, TKey>().GetPagedAsync<TEntity, TKey>(paginationRequest, CancellationToken.None);
    }

    public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken)
    {
        return await AppDbContext.Set<TEntity, TKey>().FirstOrDefaultAsync(e => e.Id.Equals(id), cancellationToken: cancellationToken);
    }

    public IQueryable<TEntity> GetFiltered(Func<TEntity, bool> expression)
    {
        return AppDbContext.Set<TEntity, TKey>().Where(expression).AsQueryable();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return AppDbContext.SaveChangesAsync(cancellationToken);
    }

    public void Update(TEntity entity)
    {
        AppDbContext.Set<TEntity, TKey>().Update(entity);
    }
}