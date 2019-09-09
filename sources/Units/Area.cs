using System;
using System.Collections.Generic;
using System.Globalization;

namespace Units
{
    /// <summary>
    /// Class Area.
    /// Implements the <see cref="Unit{AreaUnit}" />
    /// </summary>
    /// <seealso cref="Unit{AreaUnit}" />
    public class Area : Unit<AreaUnit>
    {
        private static readonly Dictionary<AreaUnit, double> ConversionToUnitDictionary = new Dictionary<AreaUnit, double>
        {
            {AreaUnit.Acre, 4_046.856_422_4d },
            {AreaUnit.Are, 100d },
            {AreaUnit.Barn, 10E-28d },
            {AreaUnit.SquareFoot,  0.092_903_04d },
            {AreaUnit.SquareInch, 0.000_645_16d },
            {AreaUnit.SquareMeter, 1d },
            {AreaUnit.SquareMile, 2_589_988.110_336d },
            {AreaUnit.SquareYard, 0.836_127_36d },
        };

        private static readonly Dictionary<AreaUnit, string> UnitToStringDictionary = new Dictionary<AreaUnit, string>
        {
            {AreaUnit.Acre, "acre" },
            {AreaUnit.Are, "are" },
            {AreaUnit.Barn, "b" },
            {AreaUnit.SquareFoot, "ft²" },
            {AreaUnit.SquareInch, "in²" },
            {AreaUnit.SquareMeter, "m²" },
            {AreaUnit.SquareMile, "ml²" },
            {AreaUnit.SquareYard, "yd²" },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Area"/> class.
        /// </summary>
        /// <param name="squareMeters">The square meters.</param>
        public Area(double squareMeters) : base(squareMeters) { }

        #region Static functions

        /// <summary>
        /// Gets an Area based on the provided square meters.
        /// </summary>
        /// <param name="squareMeter">The square meter.</param>
        /// <returns>Area.</returns>
        public static Area FromSquareMeters(double squareMeter)
        {
            return new Area(squareMeter);
        }
        /// <summary>
        /// Gets an Area based on the provided square foot.
        /// </summary>
        /// <param name="squareFoot">The square foot.</param>
        /// <returns>Area.</returns>
        public static Area FromSquareFoot(double squareFoot)
        {
            return new Area(squareFoot / ConversionToUnitDictionary[AreaUnit.SquareFoot]);
        }
        /// <summary>
        /// Gets an Area based on the provided square yard.
        /// </summary>
        /// <param name="squareYard">The square yard.</param>
        /// <returns>Area.</returns>
        public static Area FromSquareYard(double squareYard)
        {
            return new Area(squareYard / ConversionToUnitDictionary[AreaUnit.SquareYard]);
        }
        /// <summary>
        /// Gets an Area based on the provided square mile.
        /// </summary>
        /// <param name="squareMile">The square mile.</param>
        /// <returns>Area.</returns>
        public static Area FromSquareMile(double squareMile)
        {
            return new Area(squareMile / ConversionToUnitDictionary[AreaUnit.SquareMile]);
        }
        /// <summary>
        /// Gets an Area based on the provided square inch.
        /// </summary>
        /// <param name="squareInch">The square inch.</param>
        /// <returns>Area.</returns>
        public static Area FromSquareInch(double squareInch)
        {
            return new Area(squareInch / ConversionToUnitDictionary[AreaUnit.SquareInch]);
        }
        /// <summary>
        /// Gets an Area based on the provided are.
        /// </summary>
        /// <param name="are">The are.</param>
        /// <returns>Area.</returns>
        public static Area FromAre(double are)
        {
            return new Area(are / ConversionToUnitDictionary[AreaUnit.Are]);
        }
        /// <summary>
        /// Gets an Area based on the provided acre.
        /// </summary>
        /// <param name="acre">The acre.</param>
        /// <returns>Area.</returns>
        public static Area FromAcre(double acre)
        {
            return new Area(acre / ConversionToUnitDictionary[AreaUnit.Acre]);
        }
        /// <summary>
        /// Gets an Area based on the provided barn.
        /// </summary>
        /// <param name="barn">The barn.</param>
        /// <returns>Area.</returns>
        public static Area FromBarn(double barn)
        {
            return new Area(barn / ConversionToUnitDictionary[AreaUnit.Barn]);
        }

        #endregion

        #region Operator overloads

        /// <summary>
        /// Implements the + operator.
        /// </summary>
        /// <param name="volume1">The volume1.</param>
        /// <param name="volume2">The volume2.</param>
        /// <returns>The result of the operator.</returns>
        public static Area operator +(Area volume1, Area volume2)
        {
            return new Area(volume1.UnitValue + volume2.UnitValue);
        }
        /// <summary>
        /// Implements the - operator.
        /// </summary>
        /// <param name="volume1">The volume1.</param>
        /// <param name="volume2">The volume2.</param>
        /// <returns>The result of the operator.</returns>
        public static Area operator -(Area volume1, Area volume2)
        {
            return new Area(volume1.UnitValue - volume2.UnitValue);
        }
        /// <summary>
        /// Implements the / operator.
        /// </summary>
        /// <param name="volume">The volume.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Area operator /(Area volume, double value)
        {
            return new Area(volume.UnitValue / value);
        }
        /// <summary>
        /// Implements the * operator.
        /// </summary>
        /// <param name="volume">The volume.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Area operator *(Area volume, double value)
        {
            return new Area(volume.UnitValue * value);
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the area in square meter.
        /// </summary>
        /// <value>The square meter.</value>
        public double SquareMeter => UnitValue;
        /// <summary>
        /// Gets the area in square foot.
        /// </summary>
        /// <value>The square foot.</value>
        public double SquareFoot => UnitValue * ConversionToUnitDictionary[AreaUnit.SquareFoot];
        /// <summary>
        /// Gets the area in square yard.
        /// </summary>
        /// <value>The square yard.</value>
        public double SquareYard => UnitValue * ConversionToUnitDictionary[AreaUnit.SquareYard];
        /// <summary>
        /// Gets the area in square mile.
        /// </summary>
        /// <value>The square mile.</value>
        public double SquareMile => UnitValue * ConversionToUnitDictionary[AreaUnit.SquareMile];
        /// <summary>
        /// Gets the area in square inch.
        /// </summary>
        /// <value>The square inch.</value>
        public double SquareInch => UnitValue * ConversionToUnitDictionary[AreaUnit.SquareInch];
        /// <summary>
        /// Gets the area in are.
        /// </summary>
        /// <value>The are.</value>
        public double Are => UnitValue * ConversionToUnitDictionary[AreaUnit.Are];
        /// <summary>
        /// Gets the area in acre.
        /// </summary>
        /// <value>The acre.</value>
        public double Acre => UnitValue * ConversionToUnitDictionary[AreaUnit.Acre];
        /// <summary>
        /// Gets the area in barn.
        /// </summary>
        /// <value>The barn.</value>
        public double Barn => UnitValue * ConversionToUnitDictionary[AreaUnit.Barn];

        #endregion

        #region ToString Functions

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return ToString(AreaUnit.SquareMeter, CultureInfo.InvariantCulture, DefaultStringFormat);
        }
        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString(AreaUnit unit, IFormatProvider formatProvider, string format)
        {
            var value = UnitValue * ConversionToUnitDictionary[unit];
            return string.Format(formatProvider, format, value, UnitToStringDictionary[unit]);
        }

        #endregion
    }
}
