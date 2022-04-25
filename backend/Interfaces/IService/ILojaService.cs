using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;

namespace MarketPlace.Interfaces.IService;

public interface ILojaService
{
    Task<Loja> CreateLoja(LojaDto lojaDto);
    Task<int> UpdateLoja(LojaDto lojaDto);
    Task<bool> DeleteLoja(Guid id);
    Task<bool> DesativarLoja(Guid id);
    Task<Loja> GetLojaById(Guid id);
    Task<List<Loja>> GetAllLojas();
}