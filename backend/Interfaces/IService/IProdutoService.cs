using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;

namespace MarketPlace.Interfaces.IService
{
    public interface IProdutoService
    {
        Task<Produto> CreateProduto(ProdutoDto produtoDto);
        Task<bool> UpdateProduto(ProdutoDto produtoDto);
        Task<bool> DeleteProduto(int id);
        Task<bool> DesativarProduto(int id);        
        Task<Produto> GetProdutoById(int id);
        Task<List<Produto>> GetAllProdutos();
    }
}
