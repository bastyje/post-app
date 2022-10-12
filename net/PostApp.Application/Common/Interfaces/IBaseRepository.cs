using PostApp.Domain.Entities;

namespace PostApp.Application.Common.Interfaces;

public interface IBaseRepository<TEntity, TKey> where TEntity : class, IEntityBase<TKey> where TKey : class
{

}