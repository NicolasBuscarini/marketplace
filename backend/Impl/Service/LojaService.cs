using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Interfaces.IRepository;
using MarketPlace.Interfaces.IService;

namespace MarketPlace.Impl.Service
{
    public class LojaService : ILojaService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILojaRepository _produtoRepository;

        public LojaService(
            IUserRepository userRepository,
            ILojaRepository produtoRepository
        )
        {
            _userRepository = userRepository;
            _produtoRepository = produtoRepository;
        }

        public Task<Loja> CreateLoja(LojaDto lojaDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLoja(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DesativarLoja(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Loja>> GetAllLojas()
        {
            throw new NotImplementedException();
        }

        public Task<Loja> GetLojaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateLoja(LojaDto lojaDto)
        {
            throw new NotImplementedException();
        }
    }
}
