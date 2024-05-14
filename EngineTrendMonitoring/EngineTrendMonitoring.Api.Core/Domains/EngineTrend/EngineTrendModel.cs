using EngineTrendMonitoring.Shared.Enums.Units.Temperature;
using EngineTrendMonitoring.Shared.Models.Temperature;

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
        public TemperatureModel OutsideAirTemperature { get; private set; }
        public decimal AltitudeInFeet { get; private set; }
        public decimal AirspeedInKnots { get; private set; }

        public TemperatureModel InterstageTurbineTemperature { get; private set; }
        public decimal TorqueInPsi { get; private set; }
        public decimal PropellerRotationInRpm { get; private set; }
        public decimal NGCompressorRotationSpeedPerc { get; private set; }
        public decimal FuelFlowInLitres { get; private set; }
        public TemperatureModel OilTemperature { get; private set; }
        public decimal OilPressureInPsi { get; private set; }
        public decimal FuelPressureInPsi { get; private set; }

        public bool Active { get; private set; }
        #endregion

        #region Constructors
        public EngineTrendModel(
            int id, 
            int aircraftId, 
            decimal tailVolumeInLitres, 
            DateTime collectionDate, 
            int flightHours, 
            int flightCycles, 
            TemperatureModel outsideAirTemperature, 
            decimal altitudeInFeet, 
            decimal airspeedInKnots, 
            TemperatureModel interstageTurbineTemperature, 
            decimal torqueInPsi, 
            decimal propellerRotationInRpm, 
            decimal ngCompressorRotationSpeedPerc, 
            decimal fuelFlowInLitres, 
            TemperatureModel oilTemperature, 
            decimal oilPressureInPsi, 
            decimal fuelPressureInPsi, 
            bool active)
        {
            Id = id;
            AircraftId = aircraftId;
            TailVolumeInLitres = tailVolumeInLitres;
            CollectionDate = collectionDate;
            FlightHours = flightHours;
            FlightCycles = flightCycles;
            OutsideAirTemperature = outsideAirTemperature;
            AltitudeInFeet = altitudeInFeet;
            AirspeedInKnots = airspeedInKnots;
            InterstageTurbineTemperature = interstageTurbineTemperature;
            TorqueInPsi = torqueInPsi;
            PropellerRotationInRpm = propellerRotationInRpm;
            NGCompressorRotationSpeedPerc = ngCompressorRotationSpeedPerc;
            FuelFlowInLitres = fuelFlowInLitres;
            OilTemperature = oilTemperature;
            OilPressureInPsi = oilPressureInPsi;
            FuelPressureInPsi = fuelPressureInPsi;
            Active = active;
        }

        private EngineTrendModel()
        {
            OutsideAirTemperature = null!;
            InterstageTurbineTemperature = null!;
            OilTemperature = null!;
        }
        #endregion

        #region Methods

        #region Inactivate
        public void Inactivate() => Active = false;
        #endregion

        #region Activate
        public void Activate() => Active = true;
        #endregion

        #region Create
        public static EngineTrendModel Create(
            int aircraftId,
            decimal tailVolume,
            DateTime collectionDate,
            int flightHours,
            int flightCycles,
            decimal oat,
            UnitOfTemperatureEnum oatUnit,
            decimal altitude,
            decimal ias,
            decimal itt,
            UnitOfTemperatureEnum ittUnit,
            decimal tq,
            decimal propeller,
            decimal ngPerc,
            decimal fuelFlow,
            decimal oilTemp,
            UnitOfTemperatureEnum oilTempUnit,
            decimal oilPressure,
            decimal fuelPressure)
        {
            var model = new EngineTrendModel();

            model.AircraftId = aircraftId;
            model.TailVolumeInLitres = tailVolume;
            model.CollectionDate = collectionDate;
            model.FlightHours = flightHours;
            model.FlightCycles = flightCycles;
            model.OutsideAirTemperature = new(oat, oatUnit);
            model.AltitudeInFeet = altitude;
            model.AirspeedInKnots = ias;
            model.InterstageTurbineTemperature = new(itt, ittUnit);
            model.TorqueInPsi = tq;
            model.PropellerRotationInRpm = propeller;
            model.NGCompressorRotationSpeedPerc = ngPerc;
            model.FuelFlowInLitres = fuelFlow;
            model.OilTemperature = new(oilTemp, oilTempUnit);
            model.OilPressureInPsi = oilPressure;
            model.FuelPressureInPsi = fuelPressure;
            model.Activate();

            return model;
        }
        #endregion

        #region Update
        public void Update(
            decimal tailVolume,
            int flightHours,
            int flightCycles,
            decimal oat,
            UnitOfTemperatureEnum oatUnit,
            decimal altitude,
            decimal ias,
            decimal itt,
            UnitOfTemperatureEnum ittUnit,
            decimal tq,
            decimal propeller,
            decimal ngPerc,
            decimal fuelFlow,
            decimal oilTemp,
            UnitOfTemperatureEnum oilTempUnit,
            decimal oilPressure,
            decimal fuelPressure,
            bool active)
        {
            TailVolumeInLitres = tailVolume;
            FlightHours = flightHours;
            FlightCycles = flightCycles;
            OutsideAirTemperature = new(oat, oatUnit);
            AltitudeInFeet = altitude;
            AirspeedInKnots = ias;
            InterstageTurbineTemperature = new(itt, ittUnit);
            TorqueInPsi = tq;
            PropellerRotationInRpm = propeller;
            NGCompressorRotationSpeedPerc = ngPerc;
            FuelFlowInLitres = fuelFlow;
            OilTemperature = new(oilTemp, oilTempUnit);
            OilPressureInPsi = oilPressure;
            FuelPressureInPsi = fuelPressure;

            if (!Active && active)
                Activate();
        }
        #endregion

        #endregion

        #region Fluent Validation
        #endregion
    }
}
