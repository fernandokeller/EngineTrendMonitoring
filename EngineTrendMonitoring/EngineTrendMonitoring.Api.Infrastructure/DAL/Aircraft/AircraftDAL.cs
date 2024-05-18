using Dapper;
using EngineTrendMonitoring.Api.Core.DAL.Aircraft;
using EngineTrendMonitoring.Api.Infrastructure.Repositories.Base;
using EngineTrendMonitoring.Shared.Models.Aircraft.Constraints;
using EngineTrendMonitoring.Shared.Models.Aircraft.Requests;
using EngineTrendMonitoring.Shared.Models.Aircraft.Responses;
using System.Data;

namespace EngineTrendMonitoring.Api.Infrastructure.DAL.Aircraft
{
    public class AircraftDAL : BaseRepository, IAircraftDAL
    {
        #region Properties
        #endregion

        #region Constructor
        public AircraftDAL(DbSession session) : base(session)
        {
        }
        #endregion

        #region Public Methods

        #region Get By Id Async
        public async Task<AircraftResponseModel?> GetByIdAsync(int id)
        {
            var requestModel = new GetAircraftRequestModel() { Id = id };

            var aircraftResponseModel = await GetAsync(requestModel);

            return aircraftResponseModel.FirstOrDefault();
        }
        #endregion

        #region Get Async
        public async Task<IEnumerable<AircraftResponseModel>> GetAsync(GetAircraftRequestModel requestModel)
        {
            var sql = @"SELECT Id
                             , Description
                             , RegNoId
                             , Active 
                          FROM Aircraft 
                         WHERE (@Id IS NULL OR Id = @Id) 
                           AND (@Description IS NULL OR Description LIKE @Description + '%') 
                           AND (NULLIF(@RegNoId, '') IS NULL OR RegNoId = @RegNoId) 
                           AND (@Active IS NULL OR Active = @Active) ";

            var queryParams = new DynamicParameters();

            queryParams.Add("@Id", requestModel.Id, DbType.Int32, ParameterDirection.Input);
            queryParams.Add("@Description", requestModel.Description, DbType.AnsiString, ParameterDirection.Input, AircraftConstraints.DESCRIPTION_MAX_LENGTH);
            queryParams.Add("@RegNoId", requestModel.RegNoId, DbType.AnsiString, ParameterDirection.Input, AircraftConstraints.REGNOID_MAX_LENGTH);
            queryParams.Add("@Active", requestModel.Active, DbType.Boolean, ParameterDirection.Input);

            return await _session.Connection.QueryAsync<AircraftResponseModel>(
                sql,
                param: queryParams,
                transaction: _session.Transaction);
        }
        #endregion

        #endregion
    }
}
