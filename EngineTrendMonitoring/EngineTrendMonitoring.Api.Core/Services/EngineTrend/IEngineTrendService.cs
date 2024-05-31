using EngineTrendMonitoring.Shared.Models.EngineTrend.Requests;
using EngineTrendMonitoring.Shared.Models.EngineTrend.Responses;
using EngineTrendMonitoring.Shared.Models.Result;

namespace EngineTrendMonitoring.Api.Core.Services.EngineTrend
{
    public interface IEngineTrendService
    {
        Task<ResultModel<EngineTrendResponseModel>> GetByIdAsync(int id);
        Task<ResultModel<IEnumerable<EngineTrendResponseModel>>> GetAsync(GetEngineTrendRequestModel requestModel);
        Task<ResultModel<int>> CreateAsync(CreateEngineTrendRequestModel requestModel);
        Task<ResultModel> EditAsync(EditEngineTrendRequestModel requestModel);
        Task<ResultModel> DeleteAsync(int id);
    }
}
