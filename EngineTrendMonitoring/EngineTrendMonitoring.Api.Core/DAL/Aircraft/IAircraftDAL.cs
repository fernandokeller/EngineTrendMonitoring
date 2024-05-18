using EngineTrendMonitoring.Shared.Models.Aircraft.Requests;
using EngineTrendMonitoring.Shared.Models.Aircraft.Responses;

namespace EngineTrendMonitoring.Api.Core.DAL.Aircraft
{
    public interface IAircraftDAL
    {
        Task<AircraftResponseModel?> GetByIdAsync(int id);
        Task<IEnumerable<AircraftResponseModel>> GetAsync(GetAircraftRequestModel requestModel);
    }
}
