using EngineTrendMonitoring.Shared.Enums.Units.Temperature;
using EngineTrendMonitoring.Shared.Utils;

namespace EngineTrendMonitoring.Shared.Models.Temperature
{
    public class TemperatureModel
    {
        #region Constructor
        public TemperatureModel(decimal value, UnitOfTemperatureEnum unit)
        {
            Unit = unit;
            Value = value;
        }
        #endregion

        #region Properties
        public UnitOfTemperatureEnum Unit { get; private set; }
        public decimal Value { get; private set; }
        #endregion

        #region Methods
        public decimal ToFahrenheit() => UnitConverter.ToFahrenheit(Value, Unit);
        public decimal ToCelsius() => UnitConverter.ToCelsius(Value, Unit);
        #endregion
    }
}
