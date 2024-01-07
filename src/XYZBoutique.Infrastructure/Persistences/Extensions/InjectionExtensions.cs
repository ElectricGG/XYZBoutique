using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XYZBoutique.Application.Interface;
using XYZBoutique.Infrastructure.Persistences.Context;
using XYZBoutique.Infrastructure.Persistences.Repositories;

namespace XYZBoutique.Infrastructure.Persistences.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(ApplicationDbContext).Assembly.FullName;

            services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(
                                                    configuration.GetConnectionString("Connection"), b => b.MigrationsAssembly(assembly)
                                               ), ServiceLifetime.Transient
                                             );

            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductoRepository, ProductoRepository>();

            return services;
        }
    }
}
