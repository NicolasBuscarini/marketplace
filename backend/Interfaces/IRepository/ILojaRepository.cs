using MarketPlace.Domain.Models;

namespace MarketPlace.Interfaces.IRepository;

public interface ILojaRepository : IGenericRepository<Loja, Guid>
{
    Task<List<Loja>> ListLojas();
}