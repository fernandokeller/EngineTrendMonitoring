using Dapper;
using EngineTrendMonitoring.Api.Core.DAL.EngineTrend;
using EngineTrendMonitoring.Api.Infrastructure.Repositories.Base;
using EngineTrendMonitoring.Shared.Enums.Units.Temperature;
using EngineTrendMonitoring.Shared.Models.Aircraft.Constraints;
using EngineTrendMonitoring.Shared.Models.EngineTrend.Requests;
using EngineTrendMonitoring.Shared.Models.EngineTrend.Responses;
using System.Data;

namespace EngineTrendMonitoring.Api.Infrastructure.DAL.EngineTrend
{
    public class EngineTrendDAL : BaseRepository, IEngineTrendDAL
    {
        #region Properties
        #endregion

        #region Constructor
        public EngineTrendDAL(DbSession session) : base(session)
        {
        }
        #endregion

        #region Public Methods

        #region Get By Id Async
        public async Task<EngineTrendResponseModel?> GetByIdAsync(int id)
        {
            var requestModel = new GetEngineTrendRequestModel() { Id = id };

            var engineTrendResponseModel = await GetAsync(requestModel);

            return engineTrendResponseModel.FirstOrDefault();
        }
        #endregion

        #region Get Async
        public async Task<IEnumerable<EngineTrendResponseModel>> GetAsync(GetEngineTrendRequestModel requestModel)
        {
            var sql = @"SELECT ET.Id
                             , ET.AircraftId
                             , A.Description AS AircraftDescription
                             , ET.TailVolumeInLitres
                             , ET.CollectionDate
                             , ET.FlightHours
                             , ET.FlightCycles
                             , ET.OutsideAirTemperatureInCelsius AS OutsideAirTemperature
                             , ET.AltitudeInFeet
                             , ET.AirspeedInKnots
                             , ET.InterstageTurbineTemperatureInCelsius AS InterstageTurbineTemperature
                             , ET.TorqueInPsi
                             , ET.PropellerRotationInRpm
                             , ET.NGCompressorRotationSpeedPerc
                             , ET.FuelFlowInLitres
                             , ET.OilTemperatureInCelsius AS OilTemperature
                             , ET.OilPressureInPsi
                             , ET.FuelPressureInPsi
                             , ET.Active
                          FROM EngineTrend ET 
                    INNER JOIN Aircraft A ON A.Id = ET.AircraftId 
                         WHERE (@Id IS NULL OR ET.Id = @Id) 
                           AND (@AircraftId IS NULL OR ET.AircraftId = @AircraftId) 
                           AND (@AircraftDescription IS NULL OR A.Description LIKE @AircraftDescription + '%') 
                           AND (@CollectionDateFrom IS NULL OR ET.CollectionDate >= @CollectionDateFrom) 
                           AND (@CollectionDateTo IS NULL OR ET.CollectionDate <= @CollectionDateTo) 
                           AND (@FlightHours IS NULL OR ET.FlightHours = @FlightHours) 
                           AND (@Active IS NULL OR ET.Active = @Active) ";

            var queryParams = new DynamicParameters();

            queryParams.Add("@Id", requestModel.Id, DbType.Int32, ParameterDirection.Input);
            queryParams.Add("@AircraftId", requestModel.AircraftId, DbType.Int32, ParameterDirection.Input);
            queryParams.Add("@AircraftDescription", requestModel.AircraftDescription, DbType.AnsiString, ParameterDirection.Input, AircraftConstraints.DESCRIPTION_MAX_LENGTH);
            queryParams.Add("@CollectionDateFrom", requestModel.CollectionDateFrom, DbType.Date, ParameterDirection.Input);
            queryParams.Add("@CollectionDateTo", requestModel.CollectionDateTo, DbType.Date, ParameterDirection.Input);
            queryParams.Add("@FlightHours", requestModel.FlightHours, DbType.Int32, ParameterDirection.Input);
            queryParams.Add("@Active", requestModel.Active, DbType.Boolean, ParameterDirection.Input);

            var items = new List<EngineTrendResponseModel>();

            using (var reader = await _session.Connection.ExecuteReaderAsync(sql, param: queryParams, transaction: _session.Transaction))
            {
                var engineTrendReader = reader.GetRowParser<EngineTrendResponseModel>();

                while (reader.Read())
                {
                    var engineTrendResponseModel = engineTrendReader(reader);

                    engineTrendResponseModel.ConvertTemperaturesTo(requestModel.TemperatureUnitType);

                    items.Add(engineTrendResponseModel);
                }
            }

            return items;
        }
        #endregion

        #endregion
    }
}
