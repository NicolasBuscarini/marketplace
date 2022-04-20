using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Interfaces.IRepository;
using MarketPlace.Interfaces.IService;

namespace MarketPlace.Impl.Service
{
    public class LojaService : ILojaService
    {
        private readonly ILojaRepository _lojaRepository;
        private readonly IAuthService _authService;

        public LojaService(
            IAuthService authService,
            ILojaRepository lojaRepository
        )
        {
            _authService = authService;
            _lojaRepository = lojaRepository;
        }

        public async Task<Loja> CreateLoja(LojaDto lojaDto)
        {
            ApplicationUser currentUser = await _authService.GetCurrentUser();

            Loja loja = new(lojaDto, currentUser.Id);

            return await _lojaRepository.CreateAsync(loja);
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
