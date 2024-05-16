using EngineTrendMonitoring.Shared.Enums.Units.Temperature;
using EngineTrendMonitoring.Shared.Utils;

namespace EngineTrendMonitoring.Shared.ExtensionMethods
{
    public static class UnitOfTemperatureExtensionMethods
    {
        public static decimal? ToCelsius(this decimal? value, UnitOfTemperatureEnum? unitType)
        {
            if (value.HasValue && unitType is not null)
                return UnitConverter.ToCelsius(value.Value, unitType.Value);

            return null;
        }

        public static decimal? ToFahrenheit(this decimal? value, UnitOfTemperatureEnum? unitType)
        {
            if (value.HasValue && unitType is not null)
                return UnitConverter.ToFahrenheit(value.Value, unitType.Value);

            return null;
        }
    }
}
