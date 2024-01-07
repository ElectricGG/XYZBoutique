using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WatchDog;
using WatchDog.src.Enums;

namespace XYZBoutique.Application.UseCase.Extensions.WatchDog
{
    public static class WatchDogExtensions
    {
        public static IServiceCollection AddWAtchDog(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWatchDogServices(options =>
            {
                //para registrar en base de datos
                options.SetExternalDbConnString = configuration.GetConnectionString("Connection");
                options.DbDriverOption = WatchDogDbDriverEnum.MSSQL;
                //-------------------------------

                options.IsAutoClear = true;
                options.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Daily;
            });

            return services;
        }
    }
}
