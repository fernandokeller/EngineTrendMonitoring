using EngineTrendMonitoring.Shared.Enums.Units.Temperature;
using EngineTrendMonitoring.Shared.ExtensionMethods;

namespace EngineTrendMonitoring.Shared.Models.EngineTrend.Responses
{
    public class EngineTrendResponseModel
    {
        #region Properties
        public int Id { get; set; }
        public int AircraftId { get; set; }
        public string AircraftDescription { get; set; } = string.Empty;
        public decimal TailVolumeInLitres { get; set; }
        public DateTime CollectionDate { get; set; }
        public int FlightHours { get; set; }
        public int FlightCycles { get; set; }
        public decimal OutsideAirTemperature { get; set; }
        public UnitOfTemperatureEnum OutsideAirTemperatureUnitType { get; set; } = UnitOfTemperatureEnum.Celsius;
        public decimal AltitudeInFeet { get; set; }
        public decimal AirspeedInKnots { get; set; }
        public decimal InterstageTurbineTemperature { get; set; }
        public UnitOfTemperatureEnum InterstageTurbineTemperatureUnitType { get; set; } = UnitOfTemperatureEnum.Celsius;
        public decimal TorqueInPsi { get; set; }
        public decimal PropellerRotationInRpm { get; set; }
        public decimal NGCompressorRotationSpeedPerc { get; set; }
        public decimal FuelFlowInLitres { get; set; }
        public decimal OilTemperature { get; set; }
        public UnitOfTemperatureEnum OilTemperatureUnitType { get; set; } = UnitOfTemperatureEnum.Celsius;
        public decimal OilPressureInPsi { get; set; }
        public decimal FuelPressureInPsi { get; set; }
        public bool Active { get; set; }
        #endregion

        #region Public Methods

        #region Convert Temperatures To
        public void ConvertTemperaturesTo(UnitOfTemperatureEnum temperatureUnitType)
        {
            switch (temperatureUnitType)
            {
                case UnitOfTemperatureEnum.Celsius:
                    OutsideAirTemperature = OutsideAirTemperature.ToCelsius(OutsideAirTemperatureUnitType);
                    InterstageTurbineTemperature = InterstageTurbineTemperature.ToCelsius(InterstageTurbineTemperatureUnitType);
                    OilTemperature = OilTemperature.ToCelsius(OilTemperatureUnitType);
                    break;
                case UnitOfTemperatureEnum.Fahrenheit:
                    OutsideAirTemperature = OutsideAirTemperature.ToFahrenheit(OutsideAirTemperatureUnitType);
                    InterstageTurbineTemperature = InterstageTurbineTemperature.ToFahrenheit(InterstageTurbineTemperatureUnitType);
                    OilTemperature = OilTemperature.ToFahrenheit(OilTemperatureUnitType);
                    break;
            }

            OutsideAirTemperatureUnitType = temperatureUnitType;
            InterstageTurbineTemperatureUnitType = temperatureUnitType;
            OilTemperatureUnitType = temperatureUnitType;
        }
        #endregion

        #endregion
    }
}
