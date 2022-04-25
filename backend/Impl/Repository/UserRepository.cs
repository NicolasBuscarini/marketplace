using MarketPlace.Domain.Models;
using MarketPlace.Infrastructure.Data.Context;
using MarketPlace.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Impl.Repository;

public class UserRepository : GenericRepository<ApplicationUser, Guid>, IUserRepository
{
    private readonly MySQLContext _context;
    public UserRepository(MySQLContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<ApplicationUser>> ListUsers()
    {
        List<ApplicationUser> list = await _context.User.ToListAsync();

        return list;
    }

    public async Task<ApplicationUser?> GetByCpfCnpjAsync(string cpfCnpj)
    {
        ApplicationUser? applicationUser = await _context.User.Where(p => p.CpfCnpj.Equals(cpfCnpj, StringComparison.Ordinal)).FirstOrDefaultAsync();
        return applicationUser;
    }
}