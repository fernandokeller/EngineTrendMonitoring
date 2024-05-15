using EngineTrendMonitoring.Shared.Enums.Units.Temperature;

namespace EngineTrendMonitoring.Api.Core.Domains.EngineTrend
{
    public class EngineTrendModel
    {
        #region Properties
        public int Id { get; private set; }

        public int AircraftId { get; private set; }
        public decimal TailVolumeInLitres { get; private set; }

        public DateTime CollectionDate { get; private set; }
        public int FlightHours { get; private set; }
        public int FlightCycles { get; private set; }
        public decimal OutsideAirTemperature { get; private set; }
        public UnitOfTemperatureEnum OutsideAirTemperatureUnit { get; private set; }
        public decimal AltitudeInFeet { get; private set; }
        public decimal AirspeedInKnots { get; private set; }

        public decimal InterstageTurbineTemperature { get; private set; }
        public UnitOfTemperatureEnum InterstageTurbineTemperatureUnit { get; private set; }
        public decimal TorqueInPsi { get; private set; }
        public decimal PropellerRotationInRpm { get; private set; }
        public decimal NGCompressorRotationSpeedPerc { get; private set; }
        public decimal FuelFlowInLitres { get; private set; }
        public decimal OilTemperature { get; private set; }
        public UnitOfTemperatureEnum OilTemperatureUnit { get; private set; }
        public decimal OilPressureInPsi { get; private set; }
        public decimal FuelPressureInPsi { get; private set; }
        #endregion

        #region Constructors
        public EngineTrendModel(
            int id, 
            int aircraftId, 
            decimal tailVolumeInLitres, 
            DateTime collectionDate, 
            int flightHours, 
            int flightCycles, 
            decimal outsideAirTemperature,
            UnitOfTemperatureEnum outsideAirTemperatureUnit,
            decimal altitudeInFeet, 
            decimal airspeedInKnots, 
            decimal interstageTurbineTemperature,
            UnitOfTemperatureEnum interstageTurbineTemperatureUnit,
            decimal torqueInPsi, 
            decimal propellerRotationInRpm, 
            decimal ngCompressorRotationSpeedPerc, 
            decimal fuelFlowInLitres, 
            decimal oilTemperature,
            UnitOfTemperatureEnum oilTemperatureUnit,
            decimal oilPressureInPsi, 
            decimal fuelPressureInPsi)
        {
            Id = id;
            AircraftId = aircraftId;
            TailVolumeInLitres = tailVolumeInLitres;
            CollectionDate = collectionDate;
            FlightHours = flightHours;
            FlightCycles = flightCycles;
            OutsideAirTemperature = outsideAirTemperature;
            OutsideAirTemperatureUnit = outsideAirTemperatureUnit;
            AltitudeInFeet = altitudeInFeet;
            AirspeedInKnots = airspeedInKnots;
            InterstageTurbineTemperature = interstageTurbineTemperature;
            InterstageTurbineTemperatureUnit = interstageTurbineTemperatureUnit;
            TorqueInPsi = torqueInPsi;
            PropellerRotationInRpm = propellerRotationInRpm;
            NGCompressorRotationSpeedPerc = ngCompressorRotationSpeedPerc;
            FuelFlowInLitres = fuelFlowInLitres;
            OilTemperature = oilTemperature;
            OilTemperatureUnit = oilTemperatureUnit;
            OilPressureInPsi = oilPressureInPsi;
            FuelPressureInPsi = fuelPressureInPsi;
        }

        public EngineTrendModel(
            int aircraftId,
            decimal tailVolumeInLitres,
            DateTime collectionDate,
            int flightHours,
            int flightCycles,
            decimal outsideAirTemperature,
            UnitOfTemperatureEnum outsideAirTemperatureUnit,
            decimal altitudeInFeet,
            decimal airspeedInKnots,
            decimal interstageTurbineTemperature,
            UnitOfTemperatureEnum interstageTurbineTemperatureUnit,
            decimal torqueInPsi,
            decimal propellerRotationInRpm,
            decimal ngCompressorRotationSpeedPerc,
            decimal fuelFlowInLitres,
            decimal oilTemperature,
            UnitOfTemperatureEnum oilTemperatureUnit,
            decimal oilPressureInPsi,
            decimal fuelPressureInPsi)
        {
            AircraftId = aircraftId;
            TailVolumeInLitres = tailVolumeInLitres;
            CollectionDate = collectionDate;
            FlightHours = flightHours;
            FlightCycles = flightCycles;
            OutsideAirTemperature = outsideAirTemperature;
            OutsideAirTemperatureUnit = outsideAirTemperatureUnit;
            AltitudeInFeet = altitudeInFeet;
            AirspeedInKnots = airspeedInKnots;
            InterstageTurbineTemperature = interstageTurbineTemperature;
            InterstageTurbineTemperatureUnit = interstageTurbineTemperatureUnit;
            TorqueInPsi = torqueInPsi;
            PropellerRotationInRpm = propellerRotationInRpm;
            NGCompressorRotationSpeedPerc = ngCompressorRotationSpeedPerc;
            FuelFlowInLitres = fuelFlowInLitres;
            OilTemperature = oilTemperature;
            OilTemperatureUnit = oilTemperatureUnit;
            OilPressureInPsi = oilPressureInPsi;
            FuelPressureInPsi = fuelPressureInPsi;
        }
        #endregion

        #region Methods

        #region Update
        public void Update(
            decimal tailVolumeInLitres,
            int flightHours,
            int flightCycles,
            decimal outsideAirTemperature,
            UnitOfTemperatureEnum outsideAirTemperatureUnit,
            decimal altitudeInFeet,
            decimal airspeedInKnots,
            decimal interstageTurbineTemperature,
            UnitOfTemperatureEnum interstageTurbineTemperatureUnit,
            decimal torqueInPsi,
            decimal propellerRotationInRpm,
            decimal ngCompressorRotationSpeedPerc,
            decimal fuelFlowInLitres,
            decimal oilTemperature,
            UnitOfTemperatureEnum oilTemperatureUnit,
            decimal oilPressureInPsi,
            decimal fuelPressureInPsi)
        {
            TailVolumeInLitres = tailVolumeInLitres;
            FlightHours = flightHours;
            FlightCycles = flightCycles;
            OutsideAirTemperature = outsideAirTemperature;
            OutsideAirTemperatureUnit = outsideAirTemperatureUnit;
            AltitudeInFeet = altitudeInFeet;
            AirspeedInKnots = airspeedInKnots;
            InterstageTurbineTemperature = interstageTurbineTemperature;
            InterstageTurbineTemperatureUnit = interstageTurbineTemperatureUnit;
            TorqueInPsi = torqueInPsi;
            PropellerRotationInRpm = propellerRotationInRpm;
            NGCompressorRotationSpeedPerc = ngCompressorRotationSpeedPerc;
            FuelFlowInLitres = fuelFlowInLitres;
            OilTemperature = oilTemperature;
            OilTemperatureUnit = oilTemperatureUnit;
            OilPressureInPsi = oilPressureInPsi;
            FuelPressureInPsi = fuelPressureInPsi;
        }
        #endregion

        #endregion

        #region Fluent Validation
        #endregion
    }
}
