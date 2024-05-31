using EngineTrendMonitoring.Api.Core.DAL.Aircraft;
using EngineTrendMonitoring.Api.Core.Domains.Aircraft;
using EngineTrendMonitoring.Api.Core.Repositories.Aircraft;
using EngineTrendMonitoring.Shared.Models.Aircraft.Messages;
using EngineTrendMonitoring.Shared.Models.Aircraft.Requests;
using EngineTrendMonitoring.Shared.Models.Aircraft.Responses;
using EngineTrendMonitoring.Shared.Models.Result;

namespace EngineTrendMonitoring.Api.Core.Services.Aircraft
{
    public class AircraftService : IAircraftService
    {
        #region Properties
        private readonly IAircraftRepository _aircraftRepository;
        private readonly IAircraftDAL _aircraftDAL;
        #endregion

        #region Constructor
        public AircraftService(IAircraftRepository aircraftRepository, IAircraftDAL aircraftDAL)
        {
            _aircraftRepository = aircraftRepository;
            _aircraftDAL = aircraftDAL;
        }
        #endregion

        #region Public Methods

        #region Get By Id Async
        public async Task<ResultModel<AircraftResponseModel>> GetByIdAsync(int id)
        {
            if (id < 1)
                return ResultModel<AircraftResponseModel>.WithError(AircraftErrorMessages.AIRCRAFT_ID_IS_REQUIRED);

            var aircraftResponseModel = await _aircraftDAL.GetByIdAsync(id);

            if (aircraftResponseModel is null)
                return ResultModel<AircraftResponseModel>.WithError(string.Format(AircraftErrorMessages.AIRCRAFT_X_HAS_NOT_BEEN_FOUND, id));

            return ResultModel<AircraftResponseModel>.WithSuccess(aircraftResponseModel);
        }
        #endregion

        #region Get Async
        public async Task<ResultModel<IEnumerable<AircraftResponseModel>>> GetAsync(GetAircraftRequestModel requestModel)
        {
            var aircraftResponseModel = await _aircraftDAL.GetAsync(requestModel);

            return ResultModel<IEnumerable<AircraftResponseModel>>.WithSuccess(aircraftResponseModel);
        }
        #endregion

        #region Create Async
        public async Task<ResultModel<int>> CreateAsync(CreateAircraftRequestModel requestModel)
        {
            var aircraftModel = new AircraftModel(requestModel.Description, requestModel.RegNoId);

            var aircraftModelId = await _aircraftRepository.AddAsync(aircraftModel);

            return ResultModel<int>.WithSuccess(aircraftModelId);
        }
        #endregion

        #region Edit Async
        public async Task<ResultModel> EditAsync(EditAircraftRequestModel requestModel)
        {
            if (requestModel.Id < 1)
                return ResultModel.WithError(AircraftErrorMessages.AIRCRAFT_ID_IS_REQUIRED);

            var aircraftModel = await _aircraftRepository.GetByIdAsync(requestModel.Id);

            if (aircraftModel is null)
                return ResultModel.WithError(string.Format(AircraftErrorMessages.AIRCRAFT_X_HAS_NOT_BEEN_FOUND, requestModel.Id));

            aircraftModel.Update(requestModel.Description, requestModel.RegNoId, requestModel.Active);

            await _aircraftRepository.UpdateAsync(aircraftModel);

            return ResultModel.WithSuccess();
        }
        #endregion

        #region Delete Async
        public async Task<ResultModel> DeleteAsync(int id)
        {
            if (id < 1)
                return ResultModel.WithError(AircraftErrorMessages.AIRCRAFT_ID_IS_REQUIRED);

            var aircraftModel = await _aircraftRepository.GetByIdAsync(id);

            if (aircraftModel is null)
                return ResultModel.WithError(string.Format(AircraftErrorMessages.AIRCRAFT_X_HAS_NOT_BEEN_FOUND, id));

            if (!aircraftModel.Active)
                return ResultModel.WithError(string.Format(AircraftErrorMessages.AIRCRAFT_X_IS_ALREADY_INACTIVE, id));

            aircraftModel.Inactivate();

            await _aircraftRepository.UpdateAsync(aircraftModel);

            return ResultModel.WithSuccess();
        }
        #endregion

        #endregion
    }
}
