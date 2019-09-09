using System;
using System.Collections.Generic;

namespace Units
{
    /// <summary>
    /// Class Pressure.
    /// Implements the <see cref="Units.Unit{PressureUnit}" />
    /// </summary>
    /// <seealso cref="Units.Unit{PressureUnit}" />
    public class Pressure : Unit<PressureUnit>
    {
        private static readonly Dictionary<PressureUnit, double> ConversionDictionary = new Dictionary<PressureUnit, double>
        {
            {PressureUnit.Pascal, 1.0d},
            {PressureUnit.Atmosphere, 0.000010197162d},
            {PressureUnit.Bar, 0.00001d},
            {PressureUnit.Psi, 0.00014503773773d},
            {PressureUnit.Torr, 0.0075006169d},
        };
        private static readonly Dictionary<PressureUnit, string> UnitToStringDictionary = new Dictionary<PressureUnit, string>
        {
            {PressureUnit.Atmosphere, "atm" },
            {PressureUnit.Bar, "bar" },
            {PressureUnit.Pascal, "Pa" },
            {PressureUnit.Psi, "psi" },
            {PressureUnit.Torr, "Torr" },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Pressure"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Pressure(double value) : base(value) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Pressure"/> class.
        /// </summary>
        /// <param name="value">the value</param>
        /// <param name="unit">the unit the value in witch the value is given</param>
        public Pressure(double value, PressureUnit unit) : this(value / ConversionDictionary[unit]) { }

        /// <summary>
        /// The pressure in atmosphere
        /// </summary>
        public double Atmosphere => UnitValue * ConversionDictionary[PressureUnit.Atmosphere];

        /// <summary>
        /// The pressure in bar.
        /// </summary>
        public double Pascal => UnitValue;

        /// <summary>
        /// The pressure in pascal
        /// </summary>
        public double Bar => UnitValue * ConversionDictionary[PressureUnit.Bar];
        /// <summary>
        /// The pressure in pounds per square inch
        /// </summary>
        public double PoundsPerSquareInch => UnitValue * ConversionDictionary[PressureUnit.Psi];
        /// <summary>
        /// The pressure in torr
        /// </summary>
        public double Torr => UnitValue * ConversionDictionary[PressureUnit.Torr];

        /// <summary>
        /// Implements the + operator.
        /// </summary>
        /// <param name="pressure1">The pressure 1.</param>
        /// <param name="pressure2">The pressure 2.</param>
        /// <returns>The result of the operator.</returns>
        public static Pressure operator +(Pressure pressure1, Pressure pressure2)
        {
            return new Pressure(pressure1.UnitValue + pressure2.UnitValue);
        }

        /// <summary>
        /// Implements the - operator.
        /// </summary>
        /// <param name="pressure1">The pressure 1.</param>
        /// <param name="pressure2">The pressure 2.</param>
        /// <returns>The result of the operator.</returns>
        public static Pressure operator -(Pressure pressure1, Pressure pressure2)
        {
            return new Pressure(pressure1.UnitValue - pressure2.UnitValue);
        }

        /// <summary>
        /// Implements the / operator.
        /// </summary>
        /// <param name="pressure">The pressure</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Pressure operator /(Pressure pressure, double value)
        {
            return new Pressure(pressure.UnitValue / value);
        }

        /// <summary>
        /// Implements the * operator.
        /// </summary>
        /// <param name="pressure">The pressure.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Pressure operator *(Pressure pressure, double value)
        {
            return new Pressure(pressure.UnitValue * value);
        }

        /// <summary>
        /// Gets a Pressure based on the provided bar.
        /// </summary>
        /// <param name="bars">The bars.</param>
        /// <returns>Pressure.</returns>
        public static Pressure FromBar(double bars)
        {
            return new Pressure(bars, PressureUnit.Bar);
        }

        /// <summary>
        /// Gets a Pressure based on the provided pounds per square inch.
        /// </summary>
        /// <param name="psi">The psi.</param>
        /// <returns>Pressure.</returns>
        public static Pressure FromPoundsPerSquareInch(double psi)
        {
            return new Pressure(psi, PressureUnit.Psi);
        }

        /// <summary>
        /// Gets a Pressure based on the provided  pascal.
        /// </summary>
        /// <param name="pascal">The pascal.</param>
        /// <returns>Pressure.</returns>
        public static Pressure FromPascal(double pascal)
        {
            return new Pressure(pascal);
        }

        /// <summary>
        /// Gets a Pressure based on the provided atmosphere.
        /// </summary>
        /// <param name="atm">The atm.</param>
        /// <returns>Pressure.</returns>
        public static Pressure FromAtmosphere(double atm)
        {
            return new Pressure(atm, PressureUnit.Atmosphere);
        }
        /// <summary>
        /// Gets a Pressure based on the provided torrs.
        /// </summary>
        /// <param name="torr">The torr.</param>
        /// <returns>Pressure.</returns>
        public static Pressure FromTorr(double torr)
        {
            return new Pressure(torr, PressureUnit.Torr);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return ToString(PressureUnit.Pascal);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString(PressureUnit unit, IFormatProvider formatProvider, string format)
        {
            var value = ConversionDictionary[unit] * Pascal;
            return string.Format(formatProvider, format, value, UnitToStringDictionary[unit]);
        }
    }
}
