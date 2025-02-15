using Microsoft.Extensions.DependencyInjection;
using UsersMicroservice.Core.RepositoryContracts;
using UsersMicroservice.Infrastructure.DbContext;
using UsersMicroservice.Infrastructure.Repository;
namespace UsersMicroservice.Infrastructure
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add infrastructure services to the Dependency Injection Container....
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // TO Do : ADD Services to the IOC Container
            // Infrastructure services oten include data access, caching and other low-level components

            services.AddTransient<IUserInterface, UserRepository>();
            services.AddTransient<DapperDbContext>();
            return services;
        }
    }
}
