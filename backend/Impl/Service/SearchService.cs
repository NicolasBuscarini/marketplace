using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Interfaces.IGeneric;
using MarketPlace.Interfaces.IRepository;
using MarketPlace.Interfaces.IService;

namespace MarketPlace.Impl.Service;

public class SearchService : ISearchService
{
    private readonly ISearchRepository _searchRepository;

    public SearchService(ISearchRepository searchRepository)
    {
        _searchRepository = searchRepository;
    }

    public async Task<List<T>> SearchGenericByName<T>(SearchDto searchDto) where T : class, IResultSearch
    {
        // Pagina selecionada
        int pageNumber = searchDto.PageNumber < 1 ? 1 : searchDto.PageNumber;

        // Tamanho da pagina
        int pageSize = searchDto.PageSize switch
        {
            > 20 => 20,
            < 1 => 1,
            _ => searchDto.PageSize  // else
        };

        // Primeira posição da pagina selecionada
        int firstPosition = (pageNumber - 1) * pageSize;

        // Fazendo a busca ordenada
        List<T> result = await _searchRepository.SearchGenericByName<T>( searchDto.SearchString, firstPosition, pageSize );
        
        return result;
    }
    
    
    
    
}