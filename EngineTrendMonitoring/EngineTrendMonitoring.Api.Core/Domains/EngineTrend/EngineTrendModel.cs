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
        public void Inactivate()
        {
            Active = false;
            Validate();
        }
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
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0).WithMessage("Invalid Id");
            RuleFor(x => x.Active).Equal(true).When(IsCreateMode).WithMessage("You cannot create an inactive entry");

            RuleFor(x => x.AircraftId).GreaterThan(0).WithMessage(EngineTrendErrorMessages.AIRCRAFT_IS_REQUIRED);
            RuleFor(x => x.CollectionDate).Must((x, value) => x.CollectionDate >= DateTime.UnixEpoch).WithMessage(EngineTrendErrorMessages.COLLECTION_DATE_IS_REQUIRED);
            RuleFor(x => x.FlightHours).GreaterThan(EngineTrendConstraints.FLIGHT_HOURS_MIN_VALUE).WithMessage(EngineTrendErrorMessages.FLIGHT_HOURS_IS_REQUIRED);

            RuleFor(x => x.TailVolumeInLitres).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.TAIL_VOLUME_IS_REQUIRED);
            RuleFor(x => x.FlightCycles).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.FLIGHT_CYCLES_IS_REQUIRED);
            RuleFor(x => x.OutsideAirTemperatureInCelsius).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.OAT_IS_REQUIRED);
            RuleFor(x => x.AltitudeInFeet).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.ALTITUDE_IS_REQUIRED);
            RuleFor(x => x.AirspeedInKnots).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.IAS_IS_REQUIRED);
            RuleFor(x => x.InterstageTurbineTemperatureInCelsius).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.ITT_IS_REQUIRED);
            RuleFor(x => x.TorqueInPsi).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.TORQUE_IS_REQUIRED);
            RuleFor(x => x.PropellerRotationInRpm).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.PROPELLER_IS_REQUIRED);
            RuleFor(x => x.NGCompressorRotationSpeedPerc).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.NG_IS_REQUIRED);
            RuleFor(x => x.FuelFlowInLitres).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.FUEL_FLOW_IS_REQUIRED);
            RuleFor(x => x.OilTemperatureInCelsius).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.OIL_TEMPERATURE_IS_REQUIRED);
            RuleFor(x => x.OilPressureInPsi).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.OIL_PRESSURE_IS_REQUIRED);
            RuleFor(x => x.FuelPressureInPsi).NotNull().When(IsEditMode).WithMessage(EngineTrendErrorMessages.FUEL_PRESSURE_IS_REQUIRED);

            RuleFor(x => x.TailVolumeInLitres)
                .GreaterThanOrEqualTo(EngineTrendConstraints.TAIL_VOLUME_MIN_VALUE)
                .LessThanOrEqualTo(EngineTrendConstraints.TAIL_VOLUME_MAX_VALUE)
                .When(x => x.TailVolumeInLitres.HasValue)
                .WithMessage(string.Format(EngineTrendErrorMessages.TAIL_VOLUME_MUST_BE_BETWEEN_X_AND_Y, EngineTrendConstraints.TAIL_VOLUME_MIN_VALUE, EngineTrendConstraints.TAIL_VOLUME_MAX_VALUE));

            RuleFor(x => x.FlightCycles)
                .GreaterThanOrEqualTo(EngineTrendConstraints.FLIGHT_CYCLES_MIN_VALUE)
                .When(x => x.FlightCycles.HasValue)
                .WithMessage(string.Format(EngineTrendErrorMessages.FLIGHT_CYCLES_MUST_BE_GREATER_THAN_OR_EQUAL_TO_X, EngineTrendConstraints.FLIGHT_CYCLES_MIN_VALUE));

            RuleFor(x => x.InterstageTurbineTemperatureInCelsius)
                .GreaterThanOrEqualTo(EngineTrendConstraints.ITT_MIN_VALUE)
                .LessThanOrEqualTo(EngineTrendConstraints.ITT_MAX_VALUE)
                .When(x => x.InterstageTurbineTemperatureInCelsius.HasValue)
                .WithMessage(string.Format(EngineTrendErrorMessages.ITT_MUST_BE_BETWEEN_X_AND_Y, EngineTrendConstraints.ITT_MIN_VALUE, EngineTrendConstraints.ITT_MAX_VALUE));

            RuleFor(x => x.TorqueInPsi)
                .GreaterThanOrEqualTo(EngineTrendConstraints.TORQUE_MIN_VALUE)
                .LessThanOrEqualTo(EngineTrendConstraints.TORQUE_MAX_VALUE)
                .When(x => x.TorqueInPsi.HasValue)
                .WithMessage(string.Format(EngineTrendErrorMessages.TORQUE_MUST_BE_BETWEEN_X_AND_Y, EngineTrendConstraints.TORQUE_MIN_VALUE, EngineTrendConstraints.TORQUE_MAX_VALUE));

            RuleFor(x => x.PropellerRotationInRpm)
                .GreaterThanOrEqualTo(EngineTrendConstraints.PROPELLER_MIN_VALUE)
                .LessThanOrEqualTo(EngineTrendConstraints.PROPELLER_MAX_VALUE)
                .When(x => x.PropellerRotationInRpm.HasValue)
                .WithMessage(string.Format(EngineTrendErrorMessages.PROPELLER_MUST_BE_BETWEEN_X_AND_Y, EngineTrendConstraints.PROPELLER_MIN_VALUE, EngineTrendConstraints.PROPELLER_MAX_VALUE));

            RuleFor(x => x.NGCompressorRotationSpeedPerc)
                .GreaterThanOrEqualTo(EngineTrendConstraints.NG_MIN_VALUE)
                .LessThanOrEqualTo(EngineTrendConstraints.NG_MAX_VALUE)
                .When(x => x.NGCompressorRotationSpeedPerc.HasValue)
                .WithMessage(string.Format(EngineTrendErrorMessages.NG_MUST_BE_BETWEEN_X_AND_Y, EngineTrendConstraints.NG_MIN_VALUE, EngineTrendConstraints.NG_MAX_VALUE));

            RuleFor(x => x.FuelFlowInLitres)
                .GreaterThanOrEqualTo(EngineTrendConstraints.FUEL_FLOW_MIN_VALUE)
                .LessThanOrEqualTo(EngineTrendConstraints.FUEL_FLOW_MAX_VALUE)
                .When(x => x.FuelFlowInLitres.HasValue)
                .WithMessage(string.Format(EngineTrendErrorMessages.FUEL_FLOW_MUST_BE_BETWEEN_X_AND_Y, EngineTrendConstraints.FUEL_FLOW_MIN_VALUE, EngineTrendConstraints.FUEL_FLOW_MAX_VALUE));

            RuleFor(x => x.OilTemperatureInCelsius)
                .GreaterThanOrEqualTo(EngineTrendConstraints.OIL_TEMPERATURE_MIN_VALUE)
                .LessThanOrEqualTo(EngineTrendConstraints.OIL_TEMPERATURE_MAX_VALUE)
                .When(x => x.OilTemperatureInCelsius.HasValue)
                .WithMessage(string.Format(EngineTrendErrorMessages.OIL_TEMPERATURE_MUST_BE_BETWEEN_X_AND_Y, EngineTrendConstraints.OIL_TEMPERATURE_MIN_VALUE, EngineTrendConstraints.OIL_TEMPERATURE_MAX_VALUE));

            RuleFor(x => x.OilPressureInPsi)
                .GreaterThanOrEqualTo(EngineTrendConstraints.OIL_PRESSURE_MIN_VALUE)
                .LessThanOrEqualTo(EngineTrendConstraints.OIL_PRESSURE_MAX_VALUE)
                .When(x => x.OilPressureInPsi.HasValue)
                .WithMessage(string.Format(EngineTrendErrorMessages.OIL_PRESSURE_MUST_BE_BETWEEN_X_AND_Y, EngineTrendConstraints.OIL_PRESSURE_MIN_VALUE, EngineTrendConstraints.OIL_PRESSURE_MAX_VALUE));

            RuleFor(x => x.FuelPressureInPsi)
                .GreaterThanOrEqualTo(EngineTrendConstraints.FUEL_PRESSURE_MIN_VALUE)
                .LessThanOrEqualTo(EngineTrendConstraints.FUEL_PRESSURE_MAX_VALUE)
                .When(x => x.FuelPressureInPsi.HasValue)
                .WithMessage(x => string.Format(EngineTrendErrorMessages.FUEL_PRESSURE_MUST_BE_BETWEEN_X_AND_Y, EngineTrendConstraints.FUEL_PRESSURE_MIN_VALUE, EngineTrendConstraints.FUEL_PRESSURE_MAX_VALUE));
        }

        internal bool IsCreateMode(EngineTrendModel engineTrendModel) => engineTrendModel.Id == 0;
        internal bool IsEditMode(EngineTrendModel engineTrendModel) => engineTrendModel.Id > 0;
    }
    #endregion
}
