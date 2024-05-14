using EngineTrendMonitoring.Api.Core.Repositories.EngineTrend;
using EngineTrendMonitoring.Api.Core.Repositories.UnitOfWork;
using EngineTrendMonitoring.Api.Core.Services.EngineTrend;
using EngineTrendMonitoring.Api.Infrastructure;
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
            #endregion

            #region Repositories
            services.AddTransient<IEngineTrendRepository, EngineTrendRepository>();
            #endregion

            #region Unit of Work
            services.AddScoped<DbSession>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion

            return services;
        }
    }
}
