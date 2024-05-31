using EngineTrendMonitoring.Api.Core.DAL.Aircraft;
using EngineTrendMonitoring.Api.Core.DAL.EngineTrend;
using EngineTrendMonitoring.Api.Core.Repositories.Aircraft;
using EngineTrendMonitoring.Api.Core.Repositories.EngineTrend;
using EngineTrendMonitoring.Api.Core.Repositories.UnitOfWork;
using EngineTrendMonitoring.Api.Core.Services.Aircraft;
using EngineTrendMonitoring.Api.Core.Services.EngineTrend;
using EngineTrendMonitoring.Api.Infrastructure;
using EngineTrendMonitoring.Api.Infrastructure.DAL.Aircraft;
using EngineTrendMonitoring.Api.Infrastructure.DAL.EngineTrend;
using EngineTrendMonitoring.Api.Infrastructure.Repositories.Aircraft;
using EngineTrendMonitoring.Api.Infrastructure.Repositories.EngineTrend;
using EngineTrendMonitoring.Api.Infrastructure.Repositories.UnitOfWork;

namespace EngineTrendMonitoring.Api.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependenciesInjection(this IServiceCollection services)
        {
            #region Services
            services.AddTransient<IEngineTrendService, EngineTrendService>();
            services.AddTransient<IAircraftService, AircraftService>();
            #endregion

            #region Repositories
            services.AddTransient<IEngineTrendRepository, EngineTrendRepository>();
            services.AddTransient<IAircraftRepository, AircraftRepository>();
            #endregion

            #region DAL
            services.AddTransient<IAircraftDAL, AircraftDAL>();
            services.AddTransient<IEngineTrendDAL, EngineTrendDAL>();
            #endregion

            #region Unit of Work
            services.AddScoped<DbSession>((provider) =>
            {
                var connectionString = provider.GetRequiredService<IConfiguration>().GetConnectionString("LocalDB");
                
                if (connectionString is null)
                    throw new ArgumentNullException(nameof(connectionString));

                return new DbSession(connectionString!);
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            return services;
        }
    }
}
