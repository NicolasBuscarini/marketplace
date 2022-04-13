using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Impl.Repository;
using MarketPlace.Interfaces.IService;

namespace MarketPlace.Impl.Service
{
    public class ProdutoService : IProdutoService
    {
        private readonly UserRepository _userRepository;

        public ProdutoService(
            UserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task<Produto> CreateProduto(ProdutoDto produtoDto)
        {
            //throw new NotImplementedException();
            Produto produto = new Produto(produtoDto);

            return produto;
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
