using MarketPlace.Domain.Models;
using MarketPlace.Domain.Models.DTOs;

namespace MarketPlace.Interfaces.IService;

public interface ILojaService
{
    Task<Loja> CreateLoja(LojaDto lojaDto);
    Task<int> UpdateLoja(LojaDto lojaDto);
    Task<bool> DeleteLoja(int id);
    Task<bool> DesativarLoja(int id);
    Task<Loja> GetLojaById(int id);
    Task<List<Loja>> GetAllLojas();
}