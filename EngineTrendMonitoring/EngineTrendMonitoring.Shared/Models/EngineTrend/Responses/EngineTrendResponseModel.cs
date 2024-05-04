namespace EngineTrendMonitoring.Shared.Models.EngineTrend.Responses
{
    public class EngineTrendResponseModel
    {
        public int Id { get; set; }
        public int AircraftId { get; set; }
        public decimal TailVolumeInLitres { get; set; }
        public DateTime CollectionDate { get; set; }
        public int FlightHours { get; set; }
        public int FlightCycles { get; set; }
        public decimal OutsideAirTemperatureInCelsius { get; set; }
        public decimal AltitudeInFeet { get; set; }
        public decimal AirspeedInKnots { get; set; }
        public decimal InterstageTurbineTemperatureInCelsius { get; set; }
        public decimal TorqueInPsi { get; set; }
        public decimal PropellerRotationInRpm { get; set; }
        public decimal NGCompressorRotationSpeedPerc { get; set; }
        public decimal FuelFlowInLitres { get; set; }
        public decimal OilTemperatureInCelsius { get; set; }
        public decimal OilPressureInPsi { get; set; }
        public decimal FuelPressureInPsi { get; set; }
        public bool Active { get; set; }
    }
}
