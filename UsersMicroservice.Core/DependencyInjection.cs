using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using UsersMicroservice.Core.ServiceContracts;
using UsersMicroservice.Core.Services;
using UsersMicroservice.Core.Validators;

namespace UsersMicroservice.Core
{
    /// <summary>
    /// Extension method to add Core services to the Dependency Injection Container....
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static class DependencyInjection
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            // ToDo : ADD Services to the IOC Container
            // Core services oten include data access, caching and other low-level components
            services.AddTransient<IUserService, UsersService>();

            // inject validator cLASS
            //adds all the validatiors from the assembly wit genric class T
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            return services;
        }
    }
}
