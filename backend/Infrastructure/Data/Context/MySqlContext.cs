using MarketPlace.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Infrastructure.Data.Context;

public class MySqlContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
    {
    }

    public DbSet<Produto> Produto { get; set; } = null!;
    public DbSet<Loja> Loja { get; set; } = null!;
    public DbSet<ApplicationUser> User { get; set; } = null!;
    public DbSet<ApplicationRole> Role { get; set; } = null!;
}