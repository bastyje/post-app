using PostApp.Application.Common.Interfaces;
using PostApp.Domain.Entities;

namespace PostApp.Persistence.Repositories;

public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : class, IEntityBase<TKey> where TKey : class
{

}