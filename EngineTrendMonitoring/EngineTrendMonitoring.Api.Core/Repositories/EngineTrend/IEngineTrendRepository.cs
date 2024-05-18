using EngineTrendMonitoring.Api.Core.Domains.EngineTrend;

namespace EngineTrendMonitoring.Api.Core.Repositories.EngineTrend
{
    public interface IEngineTrendRepository
    {
        Task<EngineTrendModel?> GetByIdAsync(int id);
        Task<int> AddAsync(EngineTrendModel engineTrendModel);
        Task UpdateAsync(EngineTrendModel engineTrendModel);
    }
}
