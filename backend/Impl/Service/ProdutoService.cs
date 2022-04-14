using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Interfaces.IRepository;
using MarketPlace.Interfaces.IService;

namespace MarketPlace.Impl.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(
            IUserRepository userRepository,
            IProdutoRepository produtoRepository
        )
        {
            _userRepository = userRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> CreateProduto(ProdutoDto produtoDto)
        {
            Produto produto = new(produtoDto);

            return await _produtoRepository.CreateAsync(produto);
        }

        public Task<bool> DeleteProduto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DesativarProduto(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Produto>> GetAllProdutos()
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetProdutoById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduto(ProdutoDto produtoDto)
        {
            throw new NotImplementedException();
        }
    }
}
