using MarketPlace.Domain.Models;

namespace MarketPlace.Interfaces.IRepository
{
    public interface ILojaRepository : IGenericRepository<Loja, int>
    {
        Task<List<Loja>> ListLojas();
    }
}
