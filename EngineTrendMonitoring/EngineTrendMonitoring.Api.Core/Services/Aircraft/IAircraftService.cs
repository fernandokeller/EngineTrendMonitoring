using EngineTrendMonitoring.Shared.Models.Aircraft.Requests;
using EngineTrendMonitoring.Shared.Models.Aircraft.Responses;
using EngineTrendMonitoring.Shared.Models.Result;

namespace EngineTrendMonitoring.Api.Core.Services.Aircraft
{
    public interface IAircraftService
    {
        Task<ResultModel<AircraftResponseModel>> GetByIdAsync(int id);
        Task<ResultModel<IEnumerable<AircraftResponseModel>>> GetAsync(GetAircraftRequestModel requestModel);
        Task<ResultModel<int>> CreateAsync(CreateAircraftRequestModel requestModel);
        Task<ResultModel> EditAsync(EditAircraftRequestModel requestModel);
        Task<ResultModel> DeleteAsync(int id);
    }
}
