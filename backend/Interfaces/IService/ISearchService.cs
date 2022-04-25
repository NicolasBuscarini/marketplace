using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Interfaces.IGeneric;

namespace MarketPlace.Interfaces.IService;

public interface ISearchService
{
    Task<List<T>> SearchGenericByName<T>(SearchDto searchDto) where T : class, IResultSearch;
}