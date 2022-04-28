using MarketPlace.Domain.Models;

namespace MarketPlace.Interfaces.IRepository;

public interface IProdutoRepository : IGenericRepository<Produto, Guid>
{
    Task<List<Produto>> ListProdutos();
}