using MarketPlace.Impl.Repository;
using MarketPlace.Interfaces.IRepository;

namespace MarketPlace.Infrastructure.InjecaoDependencia
{
    public static class RepositoryIoc
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
