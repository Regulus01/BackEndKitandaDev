using Domain.Entities.Usuario;
using Interface.Repository;
using Interface.Repository.User;
using Repository.Repositories;
using Repository.Repositories.User;

namespace KitandaAPI.DependencyInjection
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<IProdutoRepository, ProdutoRepository>();
            serviceProvider.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
