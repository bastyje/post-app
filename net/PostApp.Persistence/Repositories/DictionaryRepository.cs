using PostApp.Application.Common.Interfaces;
using PostApp.Domain.Dictionaries;
using PostApp.Persistence.Interfaces;

namespace PostApp.Persistence.Repositories;

public class DictionaryRepository : IDictionaryRepository
{
    private readonly IAppDbContext _appDbContext;

    public DictionaryRepository(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public List<T> GetDictionary<T>() where T : class, IDictionaryBase
    {
        return _appDbContext.Set<T, int>().ToList();
    }
}