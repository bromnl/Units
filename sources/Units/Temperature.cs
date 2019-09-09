using System;
using System.Collections.Generic;
using System.Globalization;

namespace Units
{
    /// <summary>
    /// Class Temperature.
    /// Implements the <see cref="Unit{TemperatureUnit}" />
    /// </summary>
    /// <seealso cref="Unit{TemperatureUnit}" />
    public class Temperature : Unit<TemperatureUnit>
    {
        private const double MeltingPointWaterInKelvin = 273.15d;
        private static readonly Dictionary<TemperatureUnit, Func<double,double>> ConversionToKelvinDictionary = new Dictionary<TemperatureUnit, Func<double, double>>
        {
            //{TemperatureUnit.Kelvin, k => k },
            {TemperatureUnit.Celsius, c => c + MeltingPointWaterInKelvin },
            {TemperatureUnit.Delisle, d => (100 + MeltingPointWaterInKelvin) - d * 2d / 3d},
            {TemperatureUnit.Fahrenheit, f => (f + 459.67d) * 5d / 9d },
            {TemperatureUnit.Newton, n => n * 100d / 33d + MeltingPointWaterInKelvin},
            {TemperatureUnit.Rankine, r => r * 5d / 9d},
            {TemperatureUnit.Réaumur, r => r * 5d /4d + MeltingPointWaterInKelvin },
            {TemperatureUnit.Rømer, r => (r - 7.5d) * 40d / 21d + MeltingPointWaterInKelvin },
        };
        private static readonly Dictionary<TemperatureUnit, Func<double, double>> ConversionToUnitDictionary = new Dictionary<TemperatureUnit, Func<double, double>>
        {
            {TemperatureUnit.Kelvin, k => k },
            {TemperatureUnit.Celsius, k => k - MeltingPointWaterInKelvin },
            {TemperatureUnit.Delisle, k => (100d + MeltingPointWaterInKelvin - k) * 1.5d},
            {TemperatureUnit.Fahrenheit, k => k * 9d / 5d - 459.67d },
            {TemperatureUnit.Newton, k => (k - MeltingPointWaterInKelvin) * 33d / 100d},
            {TemperatureUnit.Rankine, k => k * 9d / 5d},
            {TemperatureUnit.Réaumur, k => (k - MeltingPointWaterInKelvin) * 4d /5d },
            {TemperatureUnit.Rømer, k => (k - MeltingPointWaterInKelvin) * 21d / 40d + 7.5d },
        };
        private static readonly Dictionary<TemperatureUnit, string> UnitToStringDictionary =
            new Dictionary<TemperatureUnit, string>
            {
                {TemperatureUnit.Kelvin, "K"},
                {TemperatureUnit.Celsius, "°C"},
                {TemperatureUnit.Fahrenheit, "°F"},
                {TemperatureUnit.Rankine, "°R"},
                {TemperatureUnit.Delisle, "°D"},
                {TemperatureUnit.Newton, "°N"},
                {TemperatureUnit.Réaumur, "°Ré"},
                {TemperatureUnit.Rømer, "°Rø"}
            };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Temperature"/> class.
        /// </summary>
        /// <param name="unitValue">The unit value.</param>
        public Temperature(double unitValue) : base(unitValue) { }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the temperature in kelvin.
        /// </summary>
        /// <value>The kelvin value.</value>
        public double Kelvin => UnitValue;
        /// <summary>
        /// Gets the temperature in fahrenheit.
        /// </summary>
        /// <value>The fahrenheit value.</value>
        public double Fahrenheit => ConversionToUnitDictionary[TemperatureUnit.Fahrenheit](UnitValue);
        /// <summary>
        /// Gets the temperature in celsius.
        /// </summary>
        /// <value>The celsius value.</value>
        public double Celsius => ConversionToUnitDictionary[TemperatureUnit.Celsius](UnitValue);
        /// <summary>
        /// Gets the temperature in rankine.
        /// </summary>
        /// <value>The rankine value.</value>
        public double Rankine => ConversionToUnitDictionary[TemperatureUnit.Rankine](UnitValue);
        /// <summary>
        /// Gets the temperature in delisle.
        /// </summary>
        /// <value>The delisle value.</value>
        public double Delisle => ConversionToUnitDictionary[TemperatureUnit.Delisle](UnitValue);
        /// <summary>
        /// Gets the temperature in newton.
        /// </summary>
        /// <value>The newton value.</value>
        public double Newton => ConversionToUnitDictionary[TemperatureUnit.Newton](UnitValue);
        /// <summary>
        /// Gets the temperature in réaumur.
        /// </summary>
        /// <value>The réaumur value.</value>
        public double Réaumur => ConversionToUnitDictionary[TemperatureUnit.Réaumur](UnitValue);
        /// <summary>
        /// Gets the temperature in rømer.
        /// </summary>
        /// <value>The rømer value.</value>
        public double Rømer => ConversionToUnitDictionary[TemperatureUnit.Rømer](UnitValue);

        #endregion

        #region Static functions

        /// <summary>
        /// Gets the Temperature based in de provided value in kelvin.
        /// </summary>
        /// <param name="kelvin">The kelvin.</param>
        /// <returns>Temperature.</returns>
        public static Temperature FromKelvin(double kelvin)
        {
            return new Temperature(kelvin);
        }

        /// <summary>
        /// Gets the Temperature based in de provided value in fahrenheit.
        /// </summary>
        /// <param name="fahrenheit">The fahrenheit.</param>
        /// <returns>Temperature.</returns>
        public static Temperature FromFahrenheit(double fahrenheit)
        {
            return new Temperature(ConversionToKelvinDictionary[TemperatureUnit.Fahrenheit](fahrenheit));
        }

        /// <summary>
        /// Gets the Temperature based in de provided value in celsius.
        /// </summary>
        /// <param name="celsius">The celsius.</param>
        /// <returns>Temperature.</returns>
        public static Temperature FromCelsius(double celsius)
        {
            return new Temperature(ConversionToKelvinDictionary[TemperatureUnit.Celsius](celsius));
        }

        /// <summary>
        /// Gets the Temperature based in de provided value in rankine.
        /// </summary>
        /// <param name="rankine">The rankine.</param>
        /// <returns>Temperature.</returns>
        public static Temperature FromRankine(double rankine)
        {
            return new Temperature(ConversionToKelvinDictionary[TemperatureUnit.Rankine](rankine));
        }

        /// <summary>
        /// Gets the Temperature based in de provided value in delisle.
        /// </summary>
        /// <param name="delisle">The delisle.</param>
        /// <returns>Temperature.</returns>
        public static Temperature FromDelisle(double delisle)
        {
            return new Temperature(ConversionToKelvinDictionary[TemperatureUnit.Delisle](delisle));
        }

        /// <summary>
        /// Gets the Temperature based in de provided value in newton.
        /// </summary>
        /// <param name="newton">The newton.</param>
        /// <returns>Temperature.</returns>
        public static Temperature FromNewton(double newton)
        {
            return new Temperature(ConversionToKelvinDictionary[TemperatureUnit.Newton](newton));
        }

        /// <summary>
        /// Gets the Temperature based in de provided value in réaumur.
        /// </summary>
        /// <param name="réaumur">The réaumur.</param>
        /// <returns>Temperature.</returns>
        public static Temperature FromRéaumur(double réaumur)
        {
            return new Temperature(ConversionToKelvinDictionary[TemperatureUnit.Réaumur](réaumur));
        }

        /// <summary>
        /// Gets the Temperature based in de provided value in rømer.
        /// </summary>
        /// <param name="rømer">The rømer.</param>
        /// <returns>Temperature.</returns>
        public static Temperature FromRømer(double rømer)
        {
            return new Temperature(ConversionToKelvinDictionary[TemperatureUnit.Rømer](rømer));
        }

        #endregion

        #region ToString Functions

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return ToString(TemperatureUnit.Kelvin, CultureInfo.InvariantCulture, DefaultStringFormat);
        }
        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString(TemperatureUnit unit, IFormatProvider formatProvider, string format)
        {
            var value = ConversionToUnitDictionary[unit](UnitValue);
            return string.Format(formatProvider, format, value, UnitToStringDictionary[unit]);
        }

        #endregion
    }
}
