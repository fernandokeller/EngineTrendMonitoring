using Dapper;
using EngineTrendMonitoring.Api.Core.Domains.Aircraft;
using EngineTrendMonitoring.Api.Core.Repositories.Aircraft;
using EngineTrendMonitoring.Api.Infrastructure.Repositories.Base;
using EngineTrendMonitoring.Shared.Models.Aircraft.Constraints;
using System.Data;

namespace EngineTrendMonitoring.Api.Infrastructure.Repositories.Aircraft
{
    public class AircraftRepository : BaseRepository, IAircraftRepository
    {
        #region Properties
        #endregion

        #region Constructors
        public AircraftRepository(DbSession dbSession) : base(dbSession)
        {
        }
        #endregion

        #region Public Methods

        #region Get By Id Async
        public async Task<AircraftModel?> GetByIdAsync(int id)
        {
            var sql = @"SELECT Id
                             , Description
                             , RegNoId
                             , Active 
                          FROM Aircraft 
                         WHERE Id = @Id";

            var queryParams = new DynamicParameters();

            queryParams.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            return await _session.Connection.QueryFirstOrDefaultAsync<AircraftModel>(sql, param: queryParams, transaction: _session.Transaction);
        }
        #endregion

        #region Add Async
        public Task<int> AddAsync(AircraftModel aircraftModel)
        {
            aircraftModel.Validate();

            var sql = @"INSERT INTO Aircraft (
                            Description, 
                            RegNoId, 
                            Active 
                        ) OUTPUT inserted.Id 
                        VALUES (
                            @Description, 
                            @RegNoId, 
                            @Active 
                        )";

            var commandParams = new DynamicParameters();

            commandParams.Add("@Description", aircraftModel.Description, DbType.AnsiString, ParameterDirection.Input, AircraftConstraints.DESCRIPTION_MAX_LENGTH);
            commandParams.Add("@RegNoId", aircraftModel.RegNoId, DbType.AnsiString, ParameterDirection.Input, AircraftConstraints.REGNOID_MAX_LENGTH);
            commandParams.Add("@Active", aircraftModel.Active, DbType.Boolean, ParameterDirection.Input);

            return _session.Connection.ExecuteScalarAsync<int>(sql, param: commandParams, transaction: _session.Transaction);
        }
        #endregion

        #region Update Async
        public async Task UpdateAsync(AircraftModel aircraftModel)
        {
            aircraftModel.Validate();

            var sql = @"UPDATE Aircraft SET 
                            Description = @Description
                            , RegNoId = @RegNoId
                            , Active = @Active
                            , LastModifiedDateTime = GETDATE() 
                        WHERE Id = @Id";

            var commandParams = new DynamicParameters();

            commandParams.Add("@Id", aircraftModel.Id, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@Description", aircraftModel.Description, DbType.AnsiString, ParameterDirection.Input, AircraftConstraints.DESCRIPTION_MAX_LENGTH);
            commandParams.Add("@RegNoId", aircraftModel.RegNoId, DbType.AnsiString, ParameterDirection.Input, AircraftConstraints.REGNOID_MAX_LENGTH);
            commandParams.Add("@Active", aircraftModel.Active, DbType.Boolean, ParameterDirection.Input);

            await _session.Connection.ExecuteAsync(sql, param: commandParams, transaction: _session.Transaction);
        }
        #endregion

        #endregion
    }
}
