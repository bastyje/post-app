using PostApp.Domain.Dictionaries;

namespace PostApp.Application.Common.Interfaces;

public interface IDictionaryRepository
{
    List<T> GetDictionary<T>() where T : class, IDictionaryBase;
}