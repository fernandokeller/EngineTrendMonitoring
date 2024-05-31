using EngineTrendMonitoring.Api.Core.DAL.EngineTrend;
using EngineTrendMonitoring.Api.Core.Domains.EngineTrend;
using EngineTrendMonitoring.Api.Core.Repositories.EngineTrend;
using EngineTrendMonitoring.Shared.Models.EngineTrend.Messages;
using EngineTrendMonitoring.Shared.Models.EngineTrend.Requests;
using EngineTrendMonitoring.Shared.Models.EngineTrend.Responses;
using EngineTrendMonitoring.Shared.Models.Result;

namespace EngineTrendMonitoring.Api.Core.Services.EngineTrend
{
    public class EngineTrendService : IEngineTrendService
    {
        #region Properties
        private readonly IEngineTrendRepository _engineTrendRepository;
        private readonly IEngineTrendDAL _engineTrendDAL;
        #endregion

        #region Constructor
        public EngineTrendService(IEngineTrendRepository engineTrendRepository, IEngineTrendDAL engineTrendDAL)
        {
            _engineTrendRepository = engineTrendRepository;
            _engineTrendDAL = engineTrendDAL;
        }
        #endregion

        #region Public Methods

        #region Get By Id Async
        public async Task<ResultModel<EngineTrendResponseModel>> GetByIdAsync(int id)
        {
            if (id < 1)
                return ResultModel<EngineTrendResponseModel>.WithError(EngineTrendErrorMessages.ENGINE_TREND_ID_IS_REQUIRED);

            var responseModel = await _engineTrendDAL.GetByIdAsync(id);

            if (responseModel is null)
                return ResultModel<EngineTrendResponseModel>.WithError(string.Format(EngineTrendErrorMessages.ENGINE_TREND_X_HAS_NOT_BEEN_FOUND, id));

            return ResultModel<EngineTrendResponseModel>.WithSuccess(responseModel);
        }
        #endregion

        #region Get Async
        public async Task<ResultModel<IEnumerable<EngineTrendResponseModel>>> GetAsync(GetEngineTrendRequestModel requestModel)
        {
            var responseModels = await _engineTrendDAL.GetAsync(requestModel);

            return ResultModel<IEnumerable<EngineTrendResponseModel>>.WithSuccess(responseModels);
        }
        #endregion

        #region Create Async
        public async Task<ResultModel<int>> CreateAsync(CreateEngineTrendRequestModel requestModel)
        {
            var engineTrendModel = new EngineTrendModel(requestModel.AircraftId, requestModel.CollectionDate, requestModel.FlightHours);

            var engineTrendId = await _engineTrendRepository.AddAsync(engineTrendModel);

            return ResultModel<int>.WithSuccess(engineTrendId);
        }
        #endregion

        #region Edit Async
        public async Task<ResultModel> EditAsync(EditEngineTrendRequestModel requestModel)
        {
            if (requestModel.Id < 1)
                return ResultModel.WithError(EngineTrendErrorMessages.ENGINE_TREND_ID_IS_REQUIRED);

            var engineTrendModel = await _engineTrendRepository.GetByIdAsync(requestModel.Id);

            if (engineTrendModel is null)
                return ResultModel.WithError(string.Format(EngineTrendErrorMessages.ENGINE_TREND_X_HAS_NOT_BEEN_FOUND, requestModel.Id));

            engineTrendModel.Update(
                requestModel.TailVolumeInLitres,
                requestModel.FlightCycles,
                requestModel.OutsideAirTemperature,
                requestModel.OutsideAirTemperatureUnitType,
                requestModel.AltitudeInFeet,
                requestModel.AirspeedInKnots,
                requestModel.InterstageTurbineTemperature,
                requestModel.InterstageTurbineTemperatureUnitType,
                requestModel.TorqueInPsi,
                requestModel.PropellerRotationInRpm,
                requestModel.NGCompressorRotationSpeedPerc,
                requestModel.FuelFlowInLitres,
                requestModel.OilTemperature,
                requestModel.OilTemperatureUnitType,
                requestModel.OilPressureInPsi,
                requestModel.FuelPressureInPsi,
                requestModel.Active);

            await _engineTrendRepository.UpdateAsync(engineTrendModel);

            return ResultModel.WithSuccess();
        }
        #endregion

        #region Delete Async
        public async Task<ResultModel> DeleteAsync(int id)
        {
            if (id < 1)
                return ResultModel.WithError(EngineTrendErrorMessages.ENGINE_TREND_ID_IS_REQUIRED);

            var engineTrendModel = await _engineTrendRepository.GetByIdAsync(id);

            if (engineTrendModel is null)
                return ResultModel.WithError(string.Format(EngineTrendErrorMessages.ENGINE_TREND_X_HAS_NOT_BEEN_FOUND, id));

            if (!engineTrendModel.Active)
                return ResultModel.WithError(string.Format(EngineTrendErrorMessages.ENGINE_TREND_X_IS_ALREADY_INACTIVE, id));

            engineTrendModel.Inactivate();

            await _engineTrendRepository.UpdateAsync(engineTrendModel);

            return ResultModel.WithSuccess();
        }
        #endregion

        #endregion
    }
}
