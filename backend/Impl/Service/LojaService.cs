using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;
using MarketPlace.Interfaces.IRepository;
using MarketPlace.Interfaces.IService;

namespace MarketPlace.Impl.Service;

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

        if (Domain.Models.Enums.EnumUserType.Cliente == currentUser.EnumUserType)
            throw new ArgumentException("Você precisa criar uma conta com CNPJ.");

        Loja loja = new(lojaDto, currentUser.Id);

        return await _lojaRepository.CreateAsync(loja);
    }

    public async Task<bool> DeleteLoja(Guid id)
    {
        ApplicationUser currentUser = await _authService.GetCurrentUser();
        Loja loja = await _lojaRepository.GetByIdAsync(id);

        if (loja.UserId != currentUser.Id)
            throw new ArgumentException("Propietário da loja diferende de usuario logado.");

        return await _lojaRepository.DeleteAsync(loja);
    }

    public Task<bool> DesativarLoja(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Loja>> GetAllLojas()
    {
        throw new NotImplementedException();
    }

    public async Task<Loja> GetLojaById(Guid id)
    {
        Loja loja = await _lojaRepository.GetByIdAsync(id);
        return loja;
    }

    public async Task<int> UpdateLoja(LojaDto lojaDto)
    {
        ApplicationUser currentUser = await _authService.GetCurrentUser();
        Loja loja = await _lojaRepository.GetByIdAsync(lojaDto.Id);

        if (null == loja)
            throw new ArgumentException("Loja nao encontrada.");
        if (currentUser.Id.Equals(loja.UserId))
            throw new ArgumentException("Propietário da loja diferente de usuario logado.");

        loja.Nome = lojaDto.Nome;
        loja.Descricao = lojaDto.Descricao;

        return await _lojaRepository.UpdateAsync(loja);
    }
}