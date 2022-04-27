using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;

namespace MarketPlace.Interfaces.IService;

public interface IProdutoService
{
    Task<Produto> CreateProduto(ProdutoDto produtoDto);
    Task<int> UpdateProduto(ProdutoDto produtoDto);
    Task<bool> DeleteProduto(Guid id);
    Task<bool> DesativarProduto(Guid id);
    Task<Produto> GetProdutoById(Guid id);
    Task<List<Produto>> GetAllProdutos();
}