using MarketPlace.Domain.Models;
using MarketPlace.Infrastructure.Data.Context;
using MarketPlace.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Impl.Repository;

public class ProdutoRepository : GenericRepository<Produto, Guid>, IProdutoRepository
{
    private readonly MySqlContext _context;

    public ProdutoRepository(MySqlContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Produto>> ListProdutos()
    {
        List<Produto> list = await _context.Produto.ToListAsync();

        return list;
    }
}