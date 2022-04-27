using MarketPlace.Infrastructure.Data.Context;
using MarketPlace.Interfaces.IGeneric;
using MarketPlace.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Impl.Repository;

public class SearchRepository : ISearchRepository
{
    private readonly MySqlContext _context;

    public SearchRepository(MySqlContext context)
    {
        _context = context;
    }

    public async Task<List<T>> SearchGenericByName<T>(string name, int position, int pageSize)
        where T : class, IResultSearch
    {
        List<T> result = await _context.Set<T>().Where(p => p.Nome.Contains(name)).OrderBy(p => p.Id)
            .Skip(position).Take(pageSize).ToListAsync();

        return result;
    }
}