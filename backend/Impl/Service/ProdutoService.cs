using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Domain.Models.Enums;
using MarketPlace.Interfaces.IRepository;
using MarketPlace.Interfaces.IService;

namespace MarketPlace.Impl.Service;

public class ProdutoService : IProdutoService
{
    private readonly IAuthService _authService;
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(
        IAuthService authService,
        IProdutoRepository produtoRepository
    )
    {
        _authService = authService;
        _produtoRepository = produtoRepository;
    }

    public async Task<Produto> CreateProduto(ProdutoDto produtoDto)
    {
        Produto produto = new(produtoDto);

        return await _produtoRepository.CreateAsync(produto);
    }

    public async Task<bool> DeleteProduto(Guid id)
    {
        ApplicationUser currentUser = await _authService.GetCurrentUser();
        if (EnumUserType.Admin == currentUser.EnumUserType) throw new ArgumentException("Apenas administrador");

        Produto produto = await _produtoRepository.GetByIdAsync(id);
        if (produto == null) throw new ArgumentException("Produto não encontrado");

        return await _produtoRepository.DeleteAsync(produto);
    }

    public Task<bool> DesativarProduto(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Produto>> GetAllProdutos()
    {
        List<Produto> produtos = await _produtoRepository.ListProdutos();
        return produtos;
    }

    public async Task<Produto> GetProdutoById(Guid id)
    {
        Produto produto = await _produtoRepository.GetByIdAsync(id);
        return produto;
    }

    public Task<int> UpdateProduto(ProdutoDto produtoDto)
    {
        throw new NotImplementedException();
    }
}