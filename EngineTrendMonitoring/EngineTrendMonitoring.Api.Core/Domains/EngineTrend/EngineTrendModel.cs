using EngineTrendMonitoring.Shared.Enums.Units.Temperature;
using EngineTrendMonitoring.Shared.Exceptions;
using EngineTrendMonitoring.Shared.ExtensionMethods;
using EngineTrendMonitoring.Shared.Models.EngineTrend.Constraints;
using EngineTrendMonitoring.Shared.Models.EngineTrend.Messages;
using FluentValidation;

namespace EngineTrendMonitoring.Api.Core.Domains.EngineTrend
{
    public class EngineTrendModel
    {
        #region Properties
        public int Id { get; private set; }
        public int AircraftId { get; private set; }
        public decimal? TailVolumeInLitres { get; private set; }
        public DateTime CollectionDate { get; private set; }
        public int FlightHours { get; private set; }
        public int? FlightCycles { get; private set; }
        public decimal? OutsideAirTemperatureInCelsius { get; private set; }
        public decimal? AltitudeInFeet { get; private set; }
        public decimal? AirspeedInKnots { get; private set; }
        public decimal? InterstageTurbineTemperatureInCelsius { get; private set; }
        public decimal? TorqueInPsi { get; private set; }
        public decimal? PropellerRotationInRpm { get; private set; }
        public decimal? NGCompressorRotationSpeedPerc { get; private set; }
        public decimal? FuelFlowInLitres { get; private set; }
        public decimal? OilTemperatureInCelsius { get; private set; }
        public decimal? OilPressureInPsi { get; private set; }
        public decimal? FuelPressureInPsi { get; private set; }
        public bool Active { get; private set; }
        #endregion

        #region Constructors

        #region Restore
        public EngineTrendModel(
            int id, 
            int aircraftId, 
            decimal? tailVolumeInLitres, 
            DateTime collectionDate, 
            int flightHours, 
            int? flightCycles, 
            decimal? outsideAirTemperatureInCelsius, 
            decimal? altitudeInFeet, 
            decimal? airspeedInKnots, 
            decimal? interstageTurbineTemperatureInCelsius, 
            decimal? torqueInPsi, 
            decimal? propellerRotationInRpm, 
            decimal? nGCompressorRotationSpeedPerc, 
            decimal? fuelFlowInLitres, 
            decimal? oilTemperatureInCelsius, 
            decimal? oilPressureInPsi, 
            decimal? fuelPressureInPsi, 
            bool active)
        {
            Id = id;
            AircraftId = aircraftId;
            TailVolumeInLitres = tailVolumeInLitres;
            CollectionDate = collectionDate;
            FlightHours = flightHours;
            FlightCycles = flightCycles;
            OutsideAirTemperatureInCelsius = outsideAirTemperatureInCelsius;
            AltitudeInFeet = altitudeInFeet;
            AirspeedInKnots = airspeedInKnots;
            InterstageTurbineTemperatureInCelsius = interstageTurbineTemperatureInCelsius;
            TorqueInPsi = torqueInPsi;
            PropellerRotationInRpm = propellerRotationInRpm;
            NGCompressorRotationSpeedPerc = nGCompressorRotationSpeedPerc;
            FuelFlowInLitres = fuelFlowInLitres;
            OilTemperatureInCelsius = oilTemperatureInCelsius;
            OilPressureInPsi = oilPressureInPsi;
            FuelPressureInPsi = fuelPressureInPsi;
            Active = active;
        }
        #endregion

        #region Create
        public EngineTrendModel(
            int aircraftId,
            DateTime collectionDate,
            int flightHours)
        {
            AircraftId = aircraftId;
            CollectionDate = collectionDate;
            FlightHours = flightHours;
            Active = true;

            Validate();
        }
        #endregion

        #endregion

        #region Methods

        #region Update
        public void Update(
            decimal? tailVolumeInLitres,
            int? flightCycles,
            decimal? outsideAirTemperature,
            UnitOfTemperatureEnum? outsideAirTemperatureUnit,
            decimal? altitudeInFeet,
            decimal? airspeedInKnots,
            decimal? interstageTurbineTemperature,
            UnitOfTemperatureEnum? interstageTurbineTemperatureUnit,
            decimal? torqueInPsi,
            decimal? propellerRotationInRpm,
            decimal? nGCompressorRotationSpeedPerc,
            decimal? fuelFlowInLitres,
            decimal? oilTemperature,
            UnitOfTemperatureEnum? oilTemperatureUnit,
            decimal? oilPressureInPsi,
            decimal? fuelPressureInPsi, 
            bool active)
        {
            if (outsideAirTemperature.HasValue && !outsideAirTemperatureUnit.HasValue)
                throw new CustomException(EngineTrendErrorMessages.OAT_UNIT_TYPE_IS_REQUIRED);

            if (interstageTurbineTemperature.HasValue && !interstageTurbineTemperatureUnit.HasValue)
                throw new CustomException(EngineTrendErrorMessages.ITT_UNIT_TYPE_IS_REQUIRED);

            if (oilTemperature.HasValue && !oilTemperatureUnit.HasValue)
                throw new CustomException(EngineTrendErrorMessages.OIL_TEMPERATURE_UNIT_TYPE_IS_REQUIRED);

            TailVolumeInLitres = tailVolumeInLitres;
            FlightCycles = flightCycles;
            OutsideAirTemperatureInCelsius = outsideAirTemperature.ToCelsius(outsideAirTemperatureUnit);
            AltitudeInFeet = altitudeInFeet;
            AirspeedInKnots = airspeedInKnots;
            InterstageTurbineTemperatureInCelsius = interstageTurbineTemperature.ToCelsius(interstageTurbineTemperatureUnit);
            TorqueInPsi = torqueInPsi;
            PropellerRotationInRpm = propellerRotationInRpm;
            NGCompressorRotationSpeedPerc = nGCompressorRotationSpeedPerc;
            FuelFlowInLitres = fuelFlowInLitres;
            OilTemperatureInCelsius = oilTemperature.ToCelsius(oilTemperatureUnit);
            OilPressureInPsi = oilPressureInPsi;
            FuelPressureInPsi = fuelPressureInPsi;
            Active = active;

            Validate();
        }
        #endregion

        #region Inactivate
        public void Inactivate() => Active = false;
        #endregion

        #region Validate
        public void Validate() 
        {
            var validationResult = new EngineTrendModelValidator().Validate(this);

            if (!validationResult.IsValid)
                throw new CustomException(validationResult.Errors.Select(x => x.ErrorMessage));
        }
        #endregion

        #endregion
    }

    #region Fluent Validation
    public class EngineTrendModelValidator : AbstractValidator<EngineTrendModel>
    {
        public EngineTrendModelValidator()
        {
            RuleFor(x => x.AircraftId).GreaterThan(0).WithMessage(EngineTrendErrorMessages.AIRCRAFT_IS_REQUIRED);
            RuleFor(x => x.CollectionDate).Must((x, value) => x.CollectionDate >= DateTime.UnixEpoch).WithMessage(EngineTrendErrorMessages.COLLECTION_DATE_IS_REQUIRED);
            RuleFor(x => x.FlightHours).GreaterThan(0).WithMessage(EngineTrendErrorMessages.FLIGHT_HOURS_IS_REQUIRED);

            RuleFor(x => x.TailVolumeInLitres)
                .GreaterThanOrEqualTo(EngineTrendConstraints.TAIL_VOLUME_MIN_VALUE)
                .LessThanOrEqualTo(EngineTrendConstraints.TAIL_VOLUME_MAX_VALUE)
                .When(x => x.TailVolumeInLitres.HasValue)
                .WithMessage(string.Format(EngineTrendErrorMessages.TAIL_VOLUME_MUST_BE_BETWEEN_X_AND_Y, EngineTrendConstraints.TAIL_VOLUME_MIN_VALUE, EngineTrendConstraints.TAIL_VOLUME_MAX_VALUE));

            RuleFor(x => x.FlightCycles)
                .GreaterThan(0)
                .When(x => x.FlightCycles.HasValue)
                .WithMessage(EngineTrendErrorMessages.FLIGHT_CYCLES_IS_REQUIRED);

            RuleFor(x => x.InterstageTurbineTemperatureInCelsius)
                .GreaterThanOrEqualTo(EngineTrendConstraints.ITT_MIN_VALUE)
                .LessThanOrEqualTo(EngineTrendConstraints.ITT_MAX_VALUE)
                .WithMessage(string.Format(EngineTrendErrorMessages.ITT_MUST_BE_BETWEEN_X_AND_Y, EngineTrendConstraints.ITT_MIN_VALUE, EngineTrendConstraints.ITT_MAX_VALUE));
        }
    }
    #endregion
}
