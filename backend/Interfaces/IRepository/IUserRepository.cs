using MarketPlace.Domain.Models;

namespace MarketPlace.Interfaces.IRepository
{
    public interface IUserRepository : IGenericRepository<ApplicationUser, Guid>
    {
        Task<ApplicationUser> GetByCPFAsync(string cpf);
        Task<List<ApplicationUser>> ListUsers();
    }
}