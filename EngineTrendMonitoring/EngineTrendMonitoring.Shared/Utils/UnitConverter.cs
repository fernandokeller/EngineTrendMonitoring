using EngineTrendMonitoring.Shared.Enums.Units.Length;
using EngineTrendMonitoring.Shared.Enums.Units.Mass;
using EngineTrendMonitoring.Shared.Enums.Units.Pressure;
using EngineTrendMonitoring.Shared.Enums.Units.Speed;
using EngineTrendMonitoring.Shared.Enums.Units.Temperature;

namespace EngineTrendMonitoring.Shared.Utils
{
    public class UnitConverter
    {
        #region Unit Of Length

        #region To Metre
        public static decimal ToMetre(decimal value, UnitOfLengthEnum unit)
        {
            switch (unit)
            {
                case UnitOfLengthEnum.Metre:
                default:
                    break;
                case UnitOfLengthEnum.Foot:
                    value = value / (decimal)3.281;
                    break;
                case UnitOfLengthEnum.Mile:
                    value = value * (decimal)1609.0;
                    break;
                case UnitOfLengthEnum.Kilometre:
                    value = value * (decimal)1000.0;
                    break;
            }

            return value;
        }
        #endregion

        #region To Foot
        public static decimal ToFoot(decimal value, UnitOfLengthEnum unit)
        {
            switch (unit)
            {
                case UnitOfLengthEnum.Foot:
                default:
                    break;
                case UnitOfLengthEnum.Metre:
                    value = value * (decimal)3.281;
                    break;
                case UnitOfLengthEnum.Mile:
                    value = value * (decimal)5280.0;
                    break;
                case UnitOfLengthEnum.Kilometre:
                    value = value * (decimal)3281.0;
                    break;
            }

            return value;
        }
        #endregion

        #region To Mile
        public static decimal ToMile(decimal value, UnitOfLengthEnum unit)
        {
            switch (unit)
            {
                case UnitOfLengthEnum.Mile:
                default:
                    break;
                case UnitOfLengthEnum.Metre:
                    value = value / (decimal)1609.0;
                    break;
                case UnitOfLengthEnum.Foot:
                    value = value / (decimal)5280.0;
                    break;
                case UnitOfLengthEnum.Kilometre:
                    value = value / (decimal)1.609;
                    break;
            }

            return value;
        }
        #endregion

        #region To Kilometre
        public static decimal ToKilometre(decimal value, UnitOfLengthEnum unit)
        {
            switch (unit)
            {
                case UnitOfLengthEnum.Kilometre:
                default:
                    break;
                case UnitOfLengthEnum.Metre:
                    value = value / (decimal)1000.0;
                    break;
                case UnitOfLengthEnum.Foot:
                    value = value / (decimal)3281.0;
                    break;
                case UnitOfLengthEnum.Mile:
                    value = value * (decimal)1.609;
                    break;
            }

            return value;
        }
        #endregion

        #endregion

        #region Unit Of Mass

        #region To Pound
        public static decimal ToPound(decimal value, UnitOfMassEnum unit)
        {
            switch (unit)
            {
                case UnitOfMassEnum.Pound:
                default:
                    break;
                case UnitOfMassEnum.Kilogram:
                    value = value * (decimal)2.205;
                    break;
            }

            return value;
        }
        #endregion

        #region To Kilogram
        public static decimal ToKilogram(decimal value, UnitOfMassEnum unit)
        {
            switch (unit)
            {
                case UnitOfMassEnum.Kilogram:
                default:
                    break;
                case UnitOfMassEnum.Pound:
                    value = value / (decimal)2.205;
                    break;
            }

            return value;
        }
        #endregion

        #endregion

        #region Unit Of Pressure

        #region To Psi
        public static decimal ToPsi(decimal value, UnitOfPressureEnum unit)
        {
            switch (unit)
            {
                case UnitOfPressureEnum.Psi:
                default:
                    break;
                case UnitOfPressureEnum.Bar:
                    value = value * (decimal)14.504;
                    break;
            }

            return value;
        }
        #endregion

        #region To Bar
        public static decimal ToBar(decimal value, UnitOfPressureEnum unit)
        {
            switch (unit)
            {
                case UnitOfPressureEnum.Bar:
                default:
                    break;
                case UnitOfPressureEnum.Psi:
                    value = value / (decimal)14.504;
                    break;
            }

            return value;
        }
        #endregion

        #endregion

        #region Unit Of Speed

        #region To Knot
        public static decimal ToKnot(decimal value, UnitOfSpeedEnum unit)
        {
            switch (unit)
            {
                case UnitOfSpeedEnum.Knot:
                default:
                    break;
                case UnitOfSpeedEnum.KilometerPerHour:
                    value = value / (decimal)1.852;
                    break;
                case UnitOfSpeedEnum.MilesPerHour:
                    value = value / (decimal)1.151;
                    break;
            }

            return value;
        }
        #endregion

        #region To Kilometer Per Hour
        public static decimal ToKilometerPerHour(decimal value, UnitOfSpeedEnum unit)
        {
            switch (unit)
            {
                case UnitOfSpeedEnum.KilometerPerHour:
                default:
                    break;
                case UnitOfSpeedEnum.Knot:
                    value = value * (decimal)1.852;
                    break;
                case UnitOfSpeedEnum.MilesPerHour:
                    value = value * (decimal)1.609;
                    break;
            }

            return value;
        }
        #endregion

        #region To Miles Per Hour
        public static decimal ToMilesPerHour(decimal value, UnitOfSpeedEnum unit)
        {
            switch (unit)
            {
                case UnitOfSpeedEnum.MilesPerHour:
                default:
                    break;
                case UnitOfSpeedEnum.Knot:
                    value = value * (decimal)1.151;
                    break;
                case UnitOfSpeedEnum.KilometerPerHour:
                    value = value / (decimal)1.609;
                    break;
            }

            return value;
        }
        #endregion

        #endregion

        #region Unit Of Temperature

        #region To Celsius
        public static decimal ToCelsius(decimal value, UnitOfTemperatureEnum unit)
        {
            switch (unit)
            {
                case UnitOfTemperatureEnum.Celsius:
                default:
                    break;
                case UnitOfTemperatureEnum.Fahrenheit:
                    value = (value - 32) * (decimal)1.8;
                    break;
            }

            return value;
        }
        #endregion

        #region To Fahrenheit
        public static decimal ToFahrenheit(decimal value, UnitOfTemperatureEnum unit)
        {
            switch (unit)
            {
                case UnitOfTemperatureEnum.Fahrenheit:
                default:
                    break;
                case UnitOfTemperatureEnum.Celsius:
                    value = (value * (decimal)1.8) + 32;
                    break;
            }

            return value;
        }
        #endregion

        #endregion
    }
}
