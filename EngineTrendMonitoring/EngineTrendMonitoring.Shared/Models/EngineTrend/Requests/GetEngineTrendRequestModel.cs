using EngineTrendMonitoring.Shared.Enums.Units.Temperature;

namespace EngineTrendMonitoring.Shared.Models.EngineTrend.Requests
{
    public class GetEngineTrendRequestModel
    {
        public int? Id { get; set; }
        public int? AircraftId { get; set; }
        public string? AircraftDescription { get; set; }
        public DateTime? CollectionDateFrom { get; set; }
        public DateTime? CollectionDateTo { get; set; }
        public int? FlightHours { get; set; }
        public UnitOfTemperatureEnum TemperatureUnitType { get; set; } = UnitOfTemperatureEnum.Celsius;
        public bool? Active { get; set; }
    }
}
