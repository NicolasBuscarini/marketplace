using MarketPlace.Domain.Models;

namespace MarketPlace.Interfaces.IRepository;

public interface IProdutoRepository : IGenericRepository<Produto, int>
{
    Task<List<Produto>> ListProdutos();
}