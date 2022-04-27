using MarketPlace.Interfaces.IGeneric;

namespace MarketPlace.Interfaces.IRepository;

public interface ISearchRepository
{
    Task<List<T>> SearchGenericByName<T>(string name, int position, int pageSize) where T : class, IResultSearch;
}