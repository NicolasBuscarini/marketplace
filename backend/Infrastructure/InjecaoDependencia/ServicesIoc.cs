using MarketPlace.Impl.Service;
using MarketPlace.Interfaces.IService;

namespace MarketPlace.Infrastructure.InjecaoDependencia
{
    public static class ServicesIoc
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}
