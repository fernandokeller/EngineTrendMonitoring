using EngineTrendMonitoring.Shared.Enums.Units.Temperature;

namespace EngineTrendMonitoring.Shared.Models.EngineTrend.Requests
{
    public class CreateEngineTrendRequestModel
    {
        public int AircraftId { get; set; }
        public decimal TailVolumeInLitres { get; set; }
        public DateTime CollectionDate { get; set; }
        public int FlightHours { get; set; }
        public int FlightCycles { get; set; }
        public decimal OutsideAirTemperature { get; set; }
        public UnitOfTemperatureEnum OutsideAirTemperatureUnit { get; set; }
        public decimal AltitudeInFeet { get; set; }
        public decimal AirspeedInKnots { get; set; }
        public decimal InterstageTurbineTemperature { get; set; }
        public UnitOfTemperatureEnum InterstageTurbineTemperatureUnit { get; set; }
        public decimal TorqueInPsi { get; set; }
        public decimal PropellerRotationInRpm { get; set; }
        public decimal NGCompressorRotationSpeedPerc { get; set; }
        public decimal FuelFlowInLitres { get; set; }
        public decimal OilTemperature { get; set; }
        public UnitOfTemperatureEnum OilTemperatureUnit { get; set; }
        public decimal OilPressureInPsi { get; set; }
        public decimal FuelPressureInPsi { get; set; }
    }
}
