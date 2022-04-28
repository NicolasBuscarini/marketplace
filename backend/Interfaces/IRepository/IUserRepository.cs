using MarketPlace.Domain.Models;

namespace MarketPlace.Interfaces.IRepository;

public interface IUserRepository : IGenericRepository<ApplicationUser, Guid>
{
    Task<ApplicationUser?> GetByCpfCnpjAsync(string cpfCnpj);
    Task<List<ApplicationUser>> ListUsers();
}