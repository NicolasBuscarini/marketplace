using MarketPlace.Domain.Models;

namespace MarketPlace.Interfaces.IRepository
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> ListProdutos();
    }
}