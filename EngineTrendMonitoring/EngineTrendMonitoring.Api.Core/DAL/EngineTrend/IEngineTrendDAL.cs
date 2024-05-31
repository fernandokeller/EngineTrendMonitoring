using EngineTrendMonitoring.Shared.Models.EngineTrend.Requests;
using EngineTrendMonitoring.Shared.Models.EngineTrend.Responses;

namespace EngineTrendMonitoring.Api.Core.DAL.EngineTrend
{
    public interface IEngineTrendDAL
    {
        Task<EngineTrendResponseModel?> GetByIdAsync(int id);
        Task<IEnumerable<EngineTrendResponseModel>> GetAsync(GetEngineTrendRequestModel requestModel);
    }
}
