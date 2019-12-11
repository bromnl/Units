using System;
using System.Collections.Generic;

namespace Units
{
    /// <summary>
    /// Class Length.
    /// Implements the <see cref="Units.Unit{LengthUnit}" />
    /// </summary>
    /// <seealso cref="Units.Unit{LengthUnit}" />
    public class Length : Unit<LengthUnit>
    {
        private static readonly Dictionary<LengthUnit,double> ConversionDictionary = new Dictionary<LengthUnit, double>
        {
            {LengthUnit.Meter, 1d},
            {LengthUnit.Inch, 0.0254d},
            {LengthUnit.Foot, 12d * 0.0254d},
            {LengthUnit.Yard, 36d * 0.0254d},
            {LengthUnit.Mile, 63_360 * 0.0254d},
            {LengthUnit.LightYear, 9.4607E15d},
            {LengthUnit.AstronomicalUnit, 149_597_870_700d},
            {LengthUnit.Parsec, 3.0857E16d},
            {LengthUnit.Furlong, 201.168d}
        };
        private static readonly Dictionary<LengthUnit, string> UnitToStringDictionary =
            new Dictionary<LengthUnit, string>
            {
                {LengthUnit.Meter, "m"},
                {LengthUnit.Inch, "in"},
                {LengthUnit.Foot, "ft"},
                {LengthUnit.Yard, "yd"},
                {LengthUnit.Mile, "mi"},
                {LengthUnit.LightYear, "ly"},
                {LengthUnit.AstronomicalUnit, "au"},
                {LengthUnit.Parsec, "pc"},
                {LengthUnit.Furlong, "fur"}
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="Length"/> class.
        /// </summary>
        /// <param name="meters">The meters.</param>
        public Length(double meters) : base(meters) { }
        /// <summary>
        /// Gets the meters.
        /// </summary>
        /// <value>The meters.</value>
        public double Meters => UnitValue;
        /// <summary>
        /// Gets the inches.
        /// </summary>
        /// <value>The inches.</value>
        public double Inches => UnitValue / ConversionDictionary[LengthUnit.Inch];
        /// <summary>
        /// Gets the feet.
        /// </summary>
        /// <value>The feet.</value>
        public double Feet => UnitValue / ConversionDictionary[LengthUnit.Foot];
        /// <summary>
        /// Gets the yards.
        /// </summary>
        /// <value>The yards.</value>
        public double Yards => UnitValue / ConversionDictionary[LengthUnit.Yard];
        /// <summary>
        /// Gets the miles.
        /// </summary>
        /// <value>The miles.</value>
        public double Miles => UnitValue / ConversionDictionary[LengthUnit.Mile];
        /// <summary>
        /// Gets the light years.
        /// </summary>
        /// <value>The light years.</value>
        public double LightYears => UnitValue / ConversionDictionary[LengthUnit.LightYear];
        /// <summary>
        /// Gets the astronomical units.
        /// </summary>
        /// <value>The astronomical units.</value>
        public double AstronomicalUnits => UnitValue / ConversionDictionary[LengthUnit.AstronomicalUnit];
        /// <summary>
        /// Gets the parsecs.
        /// </summary>
        /// <value>The parsecs.</value>
        public double Parsecs => UnitValue / ConversionDictionary[LengthUnit.Parsec];
        /// <summary>
        /// Gets the furlongs.
        /// </summary>
        /// <value>The furlongs.</value>
        public double Furlongs => UnitValue / ConversionDictionary[LengthUnit.Furlong];

        /// <summary>
        /// Get a length based on the provided meters
        /// </summary>
        /// <param name="meters">The meters.</param>
        /// <returns>Length.</returns>
        public static Length FromMeters(double meters)
        {
            return new Length(meters);
        }
        /// <summary>
        /// Get a Length based on the provided inches.
        /// </summary>
        /// <param name="inches">The inches.</param>
        /// <returns>Length.</returns>
        public static Length FromInches(double inches)
        {
            return new Length(inches * ConversionDictionary[LengthUnit.Inch]);
        }
        /// <summary>
        /// Get a Length based on the provided feet.
        /// </summary>
        /// <param name="feet">The feet.</param>
        /// <returns>Length.</returns>
        public static Length FromFeet(double feet)
        {
            return new Length(feet * ConversionDictionary[LengthUnit.Foot]);
        }
        /// <summary>
        /// Get a Length based on the provided yards.
        /// </summary>
        /// <param name="yards">The yards.</param>
        /// <returns>Length.</returns>
        public static Length FromYards(double yards)
        {
            return new Length(yards * ConversionDictionary[LengthUnit.Yard]);
        }
        /// <summary>
        /// Get a Length based on the provided miles.
        /// </summary>
        /// <param name="miles">The miles.</param>
        /// <returns>Length.</returns>
        public static Length FromMiles(double miles)
        {
            return new Length(miles * ConversionDictionary[LengthUnit.Mile]);
        }
        /// <summary>
        /// Get a Length based on the provided light years.
        /// </summary>
        /// <param name="lightYears">The light years.</param>
        /// <returns>Length.</returns>
        public static Length FromLightYears(double lightYears)
        {
            return new Length(lightYears * ConversionDictionary[LengthUnit.LightYear]);
        }
        /// <summary>
        /// Get a Length based on the provided astronomical units.
        /// </summary>
        /// <param name="astronomicalUnits">The astronomical units.</param>
        /// <returns>Length.</returns>
        public static Length FromAstronomicalUnits(double astronomicalUnits)
        {
            return new Length(astronomicalUnits * ConversionDictionary[LengthUnit.AstronomicalUnit]);
        }
        /// <summary>
        /// Get a Length based on the provided parsecs.
        /// </summary>
        /// <param name="parsecs">The parsecs.</param>
        /// <returns>Length.</returns>
        public static Length FromParsecs(double parsecs)
        {
            return new Length(parsecs * ConversionDictionary[LengthUnit.Parsec]);
        }
        /// <summary>
        /// Get a Length based on the provided furlongs.
        /// </summary>
        /// <param name="furlongs">The furlongs.</param>
        /// <returns>Length.</returns>
        public static Length FromFurlong(double furlongs)
        {
            return new Length(furlongs * ConversionDictionary[LengthUnit.Furlong]);
        }

        #region Operator overloads

        /// <summary>
        /// Implements the + operator.
        /// </summary>
        /// <param name="time1">The time1.</param>
        /// <param name="time2">The time2.</param>
        /// <returns>The result of the operator.</returns>
        public static Length operator +(Length time1, Length time2)
        {
            return new Length(time1.UnitValue + time2.UnitValue);
        }
        /// <summary>
        /// Implements the - operator.
        /// </summary>
        /// <param name="time1">The time1.</param>
        /// <param name="time2">The time2.</param>
        /// <returns>The result of the operator.</returns>
        public static Length operator -(Length time1, Length time2)
        {
            return new Length(time1.UnitValue - time2.UnitValue);
        }
        /// <summary>
        /// Implements the / operator.
        /// </summary>
        /// <param name="time1">The time1.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Length operator /(Length time1, double value)
        {
            return new Length(time1.UnitValue / value);
        }
        /// <summary>
        /// Implements the * operator.
        /// </summary>
        /// <param name="time1">The time1.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Length operator *(Length time1, double value)
        {
            return new Length(time1.UnitValue * value);
        }

        #endregion

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return ToString(LengthUnit.Meter);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString(LengthUnit unit, IFormatProvider formatProvider, string format)
        {
            var value = UnitValue / ConversionDictionary[unit];
            return string.Format(formatProvider, format, value, UnitToStringDictionary[unit]);
        }
    }
}
