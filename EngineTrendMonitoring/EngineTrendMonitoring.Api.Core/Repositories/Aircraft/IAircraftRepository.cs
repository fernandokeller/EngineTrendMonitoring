using EngineTrendMonitoring.Api.Core.Domains.Aircraft;

namespace EngineTrendMonitoring.Api.Core.Repositories.Aircraft
{
    public interface IAircraftRepository
    {
        Task<AircraftModel?> GetByIdAsync(int id);
        Task<int> AddAsync(AircraftModel aircraftModel);
        Task UpdateAsync(AircraftModel aircraftModel);
    }
}
