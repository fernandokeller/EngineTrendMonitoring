using Dapper;
using EngineTrendMonitoring.Api.Core.Domains.EngineTrend;
using EngineTrendMonitoring.Api.Core.Repositories.EngineTrend;
using EngineTrendMonitoring.Api.Infrastructure.Repositories.Base;
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
                             , OutsideAirTemperatureInCelsius
                             , AltitudeInFeet
                             , AirspeedInKnots
                             , InterstageTurbineTemperatureInCelsius
                             , TorqueInPsi
                             , PropellerRotationInRpm
                             , NGCompressorRotationSpeedPerc
                             , FuelFlowInLitres
                             , OilTemperatureInCelsius
                             , OilPressureInPsi
                             , FuelPressureInPsi
                             , Active
                          FROM EngineTrend 
                         WHERE Id = @Id";

            var queryParams = new DynamicParameters();

            queryParams.Add("@Id", id, DbType.Int32, ParameterDirection.Input);

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
                            OutsideAirTemperatureInCelsius, 
                            AltitudeInFeet, 
                            AirspeedInKnots, 
                            InterstageTurbineTemperatureInCelsius, 
                            TorqueInPsi, 
                            PropellerRotationInRpm, 
                            NGCompressorRotationSpeedPerc, 
                            FuelFlowInLitres, 
                            OilTemperatureInCelsius, 
                            OilPressureInPsi, 
                            FuelPressureInPsi, 
                            Active 
                        ) OUTPUT INSERTED.Id 
                        VALUES (
                            @AircraftId, 
                            @TailVolumeInLitres, 
                            @CollectionDate, 
                            @FlightHours, 
                            @FlightCycles, 
                            @OutsideAirTemperatureInCelsius, 
                            @AltitudeInFeet, 
                            @AirspeedInKnots, 
                            @InterstageTurbineTemperatureInCelsius, 
                            @TorqueInPsi, 
                            @PropellerRotationInRpm, 
                            @NGCompressorRotationSpeedPerc, 
                            @FuelFlowInLitres, 
                            @OilTemperatureInCelsius, 
                            @OilPressureInPsi, 
                            @FuelPressureInPsi, 
                            @Active 
                        )";

            var commandParams = new DynamicParameters();

            commandParams.Add("@AircraftId", engineTrendModel.AircraftId, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@TailVolumeInLitres", engineTrendModel.TailVolumeInLitres, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@CollectionDate", engineTrendModel.CollectionDate, DbType.Date, ParameterDirection.Input);
            commandParams.Add("@FlightHours", engineTrendModel.FlightHours, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@FlightCycles", engineTrendModel.FlightCycles, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@OutsideAirTemperatureInCelsius", engineTrendModel.OutsideAirTemperatureInCelsius, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@AltitudeInFeet", engineTrendModel.AltitudeInFeet, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@AirspeedInKnots", engineTrendModel.AirspeedInKnots, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@InterstageTurbineTemperatureInCelsius", engineTrendModel.InterstageTurbineTemperatureInCelsius, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@TorqueInPsi", engineTrendModel.TorqueInPsi, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@PropellerRotationInRpm", engineTrendModel.PropellerRotationInRpm, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@NGCompressorRotationSpeedPerc", engineTrendModel.NGCompressorRotationSpeedPerc, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@FuelFlowInLitres", engineTrendModel.FuelFlowInLitres, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@OilTemperatureInCelsius", engineTrendModel.OilTemperatureInCelsius, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@OilPressureInPsi", engineTrendModel.OilPressureInPsi, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@FuelPressureInPsi", engineTrendModel.FuelPressureInPsi, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@Active", engineTrendModel.Active, DbType.Boolean, ParameterDirection.Input);

            return await _session.Connection.ExecuteScalarAsync<int>(sql, param: commandParams, transaction: _session.Transaction);
        }
        #endregion

        #region Update Async
        public async Task UpdateAsync(EngineTrendModel engineTrendModel)
        {
            var command = @"UPDATE EngineTrend SET 
                                AircraftId = @AircraftId 
                                , TailVolumeInLitres = @TailVolumeInLitres 
                                , CollectionDate = @CollectionDate 
                                , FlightHours = @FlightHours 
                                , FlightCycles = @FlightCycles 
                                , OutsideAirTemperatureInCelsius = @OutsideAirTemperatureInCelsius 
                                , AltitudeInFeet = @AltitudeInFeet 
                                , AirspeedInKnots = @AirspeedInKnots 
                                , InterstageTurbineTemperatureInCelsius = @InterstageTurbineTemperatureInCelsius 
                                , TorqueInPsi = @TorqueInPsi 
                                , PropellerRotationInRpm = @PropellerRotationInRpm 
                                , NGCompressorRotationSpeedPerc = @NGCompressorRotationSpeedPerc 
                                , FuelFlowInLitres = @FuelFlowInLitres 
                                , OilTemperatureInCelsius = @OilTemperatureInCelsius 
                                , OilPressureInPsi = @OilPressureInPsi 
                                , FuelPressureInPsi = @FuelPressureInPsi 
                                , Active = @Active 
                                , LastModifiedDateTime = GETDATE() 
                            WHERE Id = @Id";

            var commandParams = new DynamicParameters();

            commandParams.Add("@Id", engineTrendModel.Id, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@AircraftId", engineTrendModel.AircraftId, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@TailVolumeInLitres", engineTrendModel.TailVolumeInLitres, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@CollectionDate", engineTrendModel.CollectionDate, DbType.Date, ParameterDirection.Input);
            commandParams.Add("@FlightHours", engineTrendModel.FlightHours, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@FlightCycles", engineTrendModel.FlightCycles, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@OutsideAirTemperatureInCelsius", engineTrendModel.OutsideAirTemperatureInCelsius, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@AltitudeInFeet", engineTrendModel.AltitudeInFeet, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@AirspeedInKnots", engineTrendModel.AirspeedInKnots, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@InterstageTurbineTemperatureInCelsius", engineTrendModel.InterstageTurbineTemperatureInCelsius, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@TorqueInPsi", engineTrendModel.TorqueInPsi, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@PropellerRotationInRpm", engineTrendModel.PropellerRotationInRpm, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@NGCompressorRotationSpeedPerc", engineTrendModel.NGCompressorRotationSpeedPerc, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@FuelFlowInLitres", engineTrendModel.FuelFlowInLitres, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@OilTemperatureInCelsius", engineTrendModel.OilTemperatureInCelsius, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@OilPressureInPsi", engineTrendModel.OilPressureInPsi, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@FuelPressureInPsi", engineTrendModel.FuelPressureInPsi, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@Active", engineTrendModel.Active, DbType.Boolean, ParameterDirection.Input);

            await _session.Connection.ExecuteAsync(command, param: commandParams, transaction: _session.Transaction);
        }
        #endregion

        #endregion
    }
}
