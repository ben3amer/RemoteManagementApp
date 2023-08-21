using HRBackend.AppCore.Interfaces.IRepositories;
using HRBackend.AppCore.Interfaces.IServices;
using HRBackend.AppCore.Services;
using HRBackend.Infrastructure.Data.Repositories;

namespace HRBackend.Infrastructure.Services.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add your services and repositories to the DI container
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContratService, ContratService>();
            services.AddScoped<IDemandeService, DemandeService>();

            // Add repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IContratRepository, ContratRepository>();
            services.AddScoped<IDemandeRepository, DemandeRepository>();

            services.AddAutoMapper(typeof(ServicesConfiguration));

            return services;
        }
    }
    
}
