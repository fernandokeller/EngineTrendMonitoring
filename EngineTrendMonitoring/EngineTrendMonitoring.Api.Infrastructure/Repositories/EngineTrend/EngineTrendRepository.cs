using Dapper;
using EngineTrendMonitoring.Api.Core.Domains.EngineTrend;
using EngineTrendMonitoring.Api.Core.Repositories.EngineTrend;
using EngineTrendMonitoring.Api.Infrastructure.Repositories.Base;
using EngineTrendMonitoring.Shared.Exceptions;
using EngineTrendMonitoring.Shared.Models.EngineTrend.Messages;
using System.Data;

namespace EngineTrendMonitoring.Api.Infrastructure.Repositories.EngineTrend
{
    public class EngineTrendRepository : BaseRepository, IEngineTrendRepository
    {
        #region Properties
        #endregion

        #region Constructor
        public EngineTrendRepository(DbSession dbSession) : base(dbSession)
        {
        }
        #endregion

        #region Public Methods

        #region Get By Id Async
        public async Task<EngineTrendModel?> GetByIdAsync(int id)
        {
            var sql = @"SELECT Id
                             , AircraftId
                             , TailVolumeInLitres
                             , CollectionDate
                             , FlightHours
                             , FlightCycles
                             , OutsideAirTemperature
                             , OutsideAirTemperatureUnit
                             , AltitudeInFeet
                             , AirspeedInKnots
                             , InterstageTurbineTemperature
                             , InterstageTurbineTemperatureUnit
                             , TorqueInPsi
                             , PropellerRotationInRpm
                             , NGCompressorRotationSpeedPerc
                             , FuelFlowInLitres
                             , OilTemperature
                             , OilTemperatureUnit
                             , OilPressureInPsi
                             , FuelPressureInPsi
                             , Active
                          FROM EngineTrend 
                         WHERE Id = @Id 
                           AND Active = 1;";

            var queryParams = new DynamicParameters();

            return await _session.Connection.QueryFirstOrDefaultAsync<EngineTrendModel>(sql, param: queryParams, transaction: _session.Transaction);
        }
        #endregion

        #region Add Async
        public async Task<int> AddAsync(EngineTrendModel engineTrendModel)
        {
            var sql = @"INSERT INTO EngineTrend (
                            AircraftId, 
                            TailVolumeInLitres, 
                            CollectionDate, 
                            FlightHours, 
                            FlightCycles, 
                            OutsideAirTemperature, 
                            OutsideAirTemperatureUnit, 
                            AltitudeInFeet, 
                            AirspeedInKnots, 
                            InterstageTurbineTemperature, 
                            InterstageTurbineTemperatureUnit, 
                            TorqueInPsi, 
                            PropellerRotationInRpm, 
                            NGCompressorRotationSpeedPerc, 
                            FuelFlowInLitres, 
                            OilTemperature, 
                            OilTemperatureUnit, 
                            OilPressureInPsi, 
                            FuelPressurePsi 
                        ) OUTPUT INSERTED.Id 
                        VALUES (
                            @AircraftId, 
                            @TailVolumeInLitres, 
                            @CollectionDate, 
                            @FlightHours, 
                            @FlightCycles, 
                            @OutsideAirTemperature, 
                            @OutsideAirTemperatureUnit, 
                            @AltitudeInFeet, 
                            @AirspeedInKnots, 
                            @InterstageTurbineTemperature, 
                            @InterstageTurbineTemperatureUnit, 
                            @TorqueInPsi, 
                            @PropellerRotationInRpm, 
                            @NGCompressorRotationSpeedPerc, 
                            @FuelFlowInLitres, 
                            @OilTemperature, 
                            @OilTemperatureUnit, 
                            @OilPressureInPsi, 
                            @FuelPressurePsi
                        )";

            var commandParams = new DynamicParameters();

            commandParams.Add("@AircraftId", engineTrendModel.AircraftId, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@TailVolumeInLitres", engineTrendModel.TailVolumeInLitres, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@CollectionDate", engineTrendModel.CollectionDate, DbType.DateTime, ParameterDirection.Input);
            commandParams.Add("@FlightHours", engineTrendModel.FlightHours, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@FlightCycles", engineTrendModel.FlightCycles, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@OutsideAirTemperature", engineTrendModel.OutsideAirTemperature, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@OutsideAirTemperatureUnit", (int)engineTrendModel.OutsideAirTemperatureUnit, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@AltitudeInFeet", engineTrendModel.AltitudeInFeet, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@AirspeedInKnots", engineTrendModel.AirspeedInKnots, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@InterstageTurbineTemperature", engineTrendModel.InterstageTurbineTemperature, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@InterstageTurbineTemperatureUnit", (int)engineTrendModel.InterstageTurbineTemperatureUnit, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@TorqueInPsi", engineTrendModel.TorqueInPsi, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@PropellerRotationInRpm", engineTrendModel.PropellerRotationInRpm, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@NGCompressorRotationSpeedPerc", engineTrendModel.NGCompressorRotationSpeedPerc, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@FuelFlowInLitres", engineTrendModel.FuelFlowInLitres, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@OilTemperature", engineTrendModel.OilTemperature, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@OilTemperatureUnit", (int)engineTrendModel.OilTemperatureUnit, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@OilPressureInPsi", engineTrendModel.OilPressureInPsi, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@FuelPressurePsi", engineTrendModel.FuelPressureInPsi, DbType.Decimal, ParameterDirection.Input);

            return await _session.Connection.ExecuteScalarAsync<int>(sql, param: commandParams, transaction: _session.Transaction);
        }
        #endregion

        #region Update Async
        public async Task UpdateAsync(EngineTrendModel engineTrendModel)
        {
            var model = await GetByIdAsync(engineTrendModel.Id);

            if (model is null)
                throw new CustomException(string.Format(EngineTrendErrorMessages.ENGINE_TREND_X_HAS_NOT_BEEN_FOUND, engineTrendModel.Id));

            var command = @"UPDATE EngineTrend SET 
                                TailVolumeInLitres = @TailVolumeInLitres 
                                , FlightHours = @FlightHours 
                                , FlightCycles = @FlightCycles 
                                , OutsideAirTemperature = @OutsideAirTemperature 
                                , OutsideAirTemperatureUnit = @OutsideAirTemperatureUnit 
                                , AltitudeInFeet = @AltitudeInFeet 
                                , AirspeedInKnots = @AirspeedInKnots 
                                , InterstageTurbineTemperature = @InterstageTurbineTemperature 
                                , InterstageTurbineTemperatureUnit = @InterstageTurbineTemperatureUnit 
                                , TorqueInPsi = @TorqueInPsi 
                                , PropellerRotationInRpm = @PropellerRotationInRpm 
                                , NGCompressorRotationSpeedPerc = @NGCompressorRotationSpeedPerc 
                                , FuelFlowInLitres = @FuelFlowInLitres 
                                , OilTemperature = @OilTemperature 
                                , OilTemperatureUnit = @OilTemperatureUnit 
                                , OilPressureInPsi = @OilPressureInPsi 
                                , FuelPressureInPsi = @FuelPressureInPsi 
                                , LastModifiedDateTime = GETDATE() 
                            WHERE Id = @Id";

            var commandParams = new DynamicParameters();

            commandParams.Add("@Id", engineTrendModel.Id);
            commandParams.Add("@TailVolumeInLitres", engineTrendModel.TailVolumeInLitres);
            commandParams.Add("@FlightHours", engineTrendModel.FlightHours);
            commandParams.Add("@FlightCycles", engineTrendModel.FlightCycles);
            commandParams.Add("@OutsideAirTemperature", engineTrendModel.OutsideAirTemperature);
            commandParams.Add("@OutsideAirTemperatureUnit", engineTrendModel.OutsideAirTemperatureUnit);
            commandParams.Add("@AltitudeInFeet", engineTrendModel.AltitudeInFeet);
            commandParams.Add("@AirspeedInKnots", engineTrendModel.AirspeedInKnots);
            commandParams.Add("@InterstageTurbineTemperature", engineTrendModel.InterstageTurbineTemperature);
            commandParams.Add("@InterstageTurbineTemperatureUnit", engineTrendModel.InterstageTurbineTemperatureUnit);
            commandParams.Add("@TorqueInPsi", engineTrendModel.TorqueInPsi);
            commandParams.Add("@PropellerRotationInRpm", engineTrendModel.PropellerRotationInRpm);
            commandParams.Add("@NGCompressorRotationSpeedPerc", engineTrendModel.NGCompressorRotationSpeedPerc);
            commandParams.Add("@FuelFlowInLitres", engineTrendModel.FuelFlowInLitres);
            commandParams.Add("@OilTemperature", engineTrendModel.OilTemperature);
            commandParams.Add("@OilTemperatureUnit", engineTrendModel.OilTemperatureUnit);
            commandParams.Add("@OilPressureInPsi", engineTrendModel.OilPressureInPsi);
            commandParams.Add("@FuelPressureInPsi", engineTrendModel.FuelFlowInLitres);

            await _session.Connection.ExecuteAsync(command, param: commandParams, transaction: _session.Transaction);
        }
        #endregion

        #region Delete Async
        public async Task DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);

            if (model is null)
                throw new CustomException(string.Format(EngineTrendErrorMessages.ENGINE_TREND_X_HAS_NOT_BEEN_FOUND, id));

            var command = @"UPDATE EngineTrend SET 
                                   Active = 0
                                   , LastModifiedDateTime = GETDATE() 
                             WHERE Id = @Id";

            var commandParams = new DynamicParameters();

            commandParams.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

            await _session.Connection.ExecuteAsync(command, param: commandParams, transaction: _session.Transaction);
        }
        #endregion

        #endregion
    }
}
