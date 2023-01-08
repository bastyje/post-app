using System.Linq.Expressions;
using PostApp.Application.Common.Models;
using PostApp.Domain.Entities;

namespace PostApp.Application.Common.Interfaces;

public interface IBaseRepository<TEntity, TKey> where TEntity : class, IEntityBase<TKey>
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken);
    IQueryable<TEntity> GetAll();
    Task<PaginationResponse<TEntity>> GetPaged(PaginationRequest paginationRequest, CancellationToken cancellationToken);
    IQueryable<TEntity> GetFiltered(Func<TEntity, bool> expression);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}