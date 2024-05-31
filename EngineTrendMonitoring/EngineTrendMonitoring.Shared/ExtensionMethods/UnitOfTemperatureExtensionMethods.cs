using EngineTrendMonitoring.Shared.Enums.Units.Temperature;

namespace EngineTrendMonitoring.Shared.ExtensionMethods
{
    public static class UnitOfTemperatureExtensionMethods
    {
        public static decimal ToCelsius(this decimal value, UnitOfTemperatureEnum? unitType)
        {
            if (unitType is not null && unitType != UnitOfTemperatureEnum.Celsius)
                return (value - 32m) * 5/9;

            return value;
        }

        public static decimal ToFahrenheit(this decimal value, UnitOfTemperatureEnum? unitType)
        {
            if (unitType is not null && unitType != UnitOfTemperatureEnum.Fahrenheit)
                return (value * 9/5) + 32m;

            return value;
        }

        public static decimal? ToCelsius(this decimal? value, UnitOfTemperatureEnum? unitType)
        {
            if (value.HasValue && unitType is not null)
                return value.Value.ToCelsius(unitType);

            return null;
        }

        public static decimal? ToFahrenheit(this decimal? value, UnitOfTemperatureEnum? unitType)
        {
            if (value.HasValue && unitType is not null)
                return value.Value.ToFahrenheit(unitType);

            return null;
        }
    }
}
