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
                         WHERE Id = @Id";

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
            commandParams.Add("@OutsideAirTemperature", engineTrendModel.OutsideAirTemperature.Value, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@OutsideAirTemperatureUnit", (int)engineTrendModel.OutsideAirTemperature.Unit, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@AltitudeInFeet", engineTrendModel.AltitudeInFeet, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@AirspeedInKnots", engineTrendModel.AirspeedInKnots, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@InterstageTurbineTemperature", engineTrendModel.InterstageTurbineTemperature.Value, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@InterstageTurbineTemperatureUnit", (int)engineTrendModel.InterstageTurbineTemperature.Unit, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@TorqueInPsi", engineTrendModel.TorqueInPsi, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@PropellerRotationInRpm", engineTrendModel.PropellerRotationInRpm, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@NGCompressorRotationSpeedPerc", engineTrendModel.NGCompressorRotationSpeedPerc, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@FuelFlowInLitres", engineTrendModel.FuelFlowInLitres, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@OilTemperature", engineTrendModel.OilTemperature.Value, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@OilTemperatureUnit", (int)engineTrendModel.OilTemperature.Unit, DbType.Int32, ParameterDirection.Input);
            commandParams.Add("@OilPressureInPsi", engineTrendModel.OilPressureInPsi, DbType.Decimal, ParameterDirection.Input);
            commandParams.Add("@FuelPressurePsi", engineTrendModel.FuelPressureInPsi, DbType.Decimal, ParameterDirection.Input);

            return await _session.Connection.ExecuteScalarAsync<int>(sql, param: commandParams, transaction: _session.Transaction);
        }
        #endregion

        #region Update Async
        public Task<bool> UpdateAsync(EngineTrendModel engineTrendModel)
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
