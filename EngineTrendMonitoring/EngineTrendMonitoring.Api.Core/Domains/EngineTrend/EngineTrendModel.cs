namespace EngineTrendMonitoring.Api.Core.Domains.EngineTrend
{
    public class EngineTrendModel
    {
        #region Constants
        public const decimal PROPELLER_ROTATION_MAX_VALUE = (decimal)2200.0;
        public const decimal PROPELLER_ROTATION_MIN_VALUE = (decimal)0.0;
        public const decimal PROPELLER_ROTATION_RECOMMENDED_VALUE = (decimal)2000.0;

        public const decimal INTERSTAGE_TURBINE_TEMPERATURE_MAX_VALUE = (decimal)725.0;
        public const decimal INTERSTAGE_TURBINE_TEMPERATURE_MIN_VALUE = (decimal)400.0;

        public const decimal OIL_PRESSURE_MAX_VALUE = (decimal)100.0;
        public const decimal OIL_PRESSURE_MIN_VALUE = (decimal)40.0;

        public const decimal TORQUE_MAX_VALUE = (decimal)1625.0;
        public const decimal TORQUE_MIN_VALUE = (decimal)0.0;

        public const decimal COMPRESSOR_ROTATION_SPEED_MAX_VALUE = (decimal)100.0;
        public const decimal COMPRESSOR_ROTATION_SPEED_MIN_VALUE = (decimal)50.0;

        public const decimal OIL_TEMPERATURE_MAX_VALUE = (decimal)220.0;
        public const decimal OIL_TEMPERATURE_MIN_VALUE = (decimal)100.0;

        public const decimal FUEL_PRESSURE_MAX_VALUE = (decimal)25.0;
        public const decimal FUEL_PRESSURE_MIN_VALUE = (decimal)5.0;

        public const decimal FUEL_FLOW_MAX_VALUE = (decimal)243.0;
        public const decimal FUEL_FLOW_MIN_VALUE = (decimal)51.0;
        #endregion

        #region Properties
        public int Id { get; private set; }

        public int AircraftId { get; private set; }
        public decimal TailVolumeInLitres { get; private set; }

        public DateTime CollectionDate { get; private set; }
        public int FlightHours { get; private set; }
        public int FlightCycles { get; private set; }
        public decimal OutsideAirTemperatureInCelsius { get; private set; }
        public decimal AltitudeInFeet { get; private set; }
        public decimal AirspeedInKnots { get; private set; }

        public decimal InterstageTurbineTemperatureInCelsius { get; private set; }
        public decimal TorqueInPsi { get; private set; }
        public decimal PropellerRotationInRpm { get; private set; }
        public decimal NGCompressorRotationSpeedPerc { get; private set; }
        public decimal FuelFlowInLitres { get; private set; }
        public decimal OilTemperatureInCelsius { get; private set; }
        public decimal OilPressureInPsi { get; private set; }
        public decimal FuelPressureInPsi { get; private set; }

        public bool Active { get; private set; }
        #endregion

        #region Constructors
        public EngineTrendModel(
            int id, 
            int aircraftId, 
            decimal tailVolume, 
            DateTime collectionDate, 
            int flightHours, 
            int flightCycles, 
            decimal oat, 
            decimal altitude, 
            decimal ias, 
            decimal itt, 
            decimal tq, 
            decimal propeller, 
            decimal ngPerc, 
            decimal fuelFlow, 
            decimal oilTemp, 
            decimal oilPressure, 
            decimal fuelPressure, 
            bool active)
        {
            Id = id;
            AircraftId = aircraftId;
            TailVolumeInLitres = tailVolume;
            CollectionDate = collectionDate;
            FlightHours = flightHours;
            FlightCycles = flightCycles;
            OutsideAirTemperatureInCelsius = oat;
            AltitudeInFeet = altitude;
            AirspeedInKnots = ias;
            InterstageTurbineTemperatureInCelsius = itt;
            TorqueInPsi = tq;
            PropellerRotationInRpm = propeller;
            NGCompressorRotationSpeedPerc = ngPerc;
            FuelFlowInLitres = fuelFlow;
            OilTemperatureInCelsius = oilTemp;
            OilPressureInPsi = oilPressure;
            FuelPressureInPsi = fuelPressure;
            Active = active;
        }

        public EngineTrendModel(
            int aircraftId,
            decimal tailVolume,
            DateTime collectionDate,
            int flightHours,
            int flightCycles,
            decimal oatInCelsius,
            decimal altitude,
            decimal ias,
            decimal ittInCelsius,
            decimal tq,
            decimal propeller,
            decimal ngPerc,
            decimal fuelFlow,
            decimal oilTempInCelsius,
            decimal oilPressure,
            decimal fuelPressure)
        {
            AircraftId = aircraftId;
            TailVolumeInLitres = tailVolume;
            CollectionDate = collectionDate;
            FlightHours = flightHours;
            FlightCycles = flightCycles;
            OutsideAirTemperatureInCelsius = oatInCelsius;
            AltitudeInFeet = altitude;
            AirspeedInKnots = ias;
            InterstageTurbineTemperatureInCelsius = ittInCelsius;
            TorqueInPsi = tq;
            PropellerRotationInRpm = propeller;
            NGCompressorRotationSpeedPerc = ngPerc;
            FuelFlowInLitres = fuelFlow;
            OilTemperatureInCelsius = oilTempInCelsius;
            OilPressureInPsi = oilPressure;
            FuelPressureInPsi = fuelPressure;
            Active = true;
        }
        #endregion

        #region Methods

        #region Set Id
        public void SetId(int id) => Id = id;
        #endregion

        #region Set Active
        public void SetActive(bool active) => Active = active;
        #endregion

        #endregion

        #region Fluent Validation
        #endregion
    }
}
