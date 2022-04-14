using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Domain.Models;
using MarketPlace.Infrastructure.Data.Context;
using MarketPlace.Interfaces.IRepository;

namespace MarketPlace.Impl.Repository
{
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

        public async Task<ApplicationUser> GetByCPFAsync(string cpf)
        {
            ApplicationUser user = await _context.User.Where(p => p.CPF.Equals(cpf)).FirstOrDefaultAsync();

            return user;
        }

    }
}