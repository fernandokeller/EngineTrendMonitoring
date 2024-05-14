namespace EngineTrendMonitoring.Shared.Models.EngineTrend.Constraints
{
    public class EngineTrendConstraints
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
    }
}
