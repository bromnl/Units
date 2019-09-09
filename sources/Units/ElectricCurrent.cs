using System;
using System.Globalization;

namespace Units
{
    /// <summary>
    /// Class ElectricCurrent.
    /// Implements the <see cref="Unit{ElectricCurrent}" />
    /// </summary>
    /// <seealso cref="Unit{ElectricCurrent}" />
    public class ElectricCurrent : Unit<ElectricCurrentUnit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectricCurrent"/> class.
        /// </summary>
        /// <param name="unitValue">The unit value.</param>
        public ElectricCurrent(double unitValue) : base(unitValue) { }

        /// <summary>
        /// Froms the amperes.
        /// </summary>
        /// <param name="amperes">The amperes.</param>
        /// <returns>ElectricCurrent.</returns>
        public static ElectricCurrent FromAmperes(double amperes)
        {
            return new ElectricCurrent(amperes);
        }

        /// <summary>
        /// Gets the amperes.
        /// </summary>
        /// <value>The amperes.</value>
        public double Amperes => UnitValue;

        #region Operator overloads

        /// <summary>
        /// Implements the + operator.
        /// </summary>
        /// <param name="electricCurrent1">The electricCurrent1.</param>
        /// <param name="electricCurrent2">The electricCurrent2.</param>
        /// <returns>The result of the operator.</returns>
        public static ElectricCurrent operator +(ElectricCurrent electricCurrent1, ElectricCurrent electricCurrent2)
        {
            return new ElectricCurrent(electricCurrent1.UnitValue + electricCurrent2.UnitValue);
        }
        /// <summary>
        /// Implements the - operator.
        /// </summary>
        /// <param name="electricCurrent1">The electricCurrent1.</param>
        /// <param name="electricCurrent2">The electricCurrent2.</param>
        /// <returns>The result of the operator.</returns>
        public static ElectricCurrent operator -(ElectricCurrent electricCurrent1, ElectricCurrent electricCurrent2)
        {
            return new ElectricCurrent(electricCurrent1.UnitValue - electricCurrent2.UnitValue);
        }
        /// <summary>
        /// Implements the / operator.
        /// </summary>
        /// <param name="electricCurrent1">The electricCurrent1.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static ElectricCurrent operator /(ElectricCurrent electricCurrent1, double value)
        {
            return new ElectricCurrent(electricCurrent1.UnitValue / value);
        }
        /// <summary>
        /// Implements the * operator.
        /// </summary>
        /// <param name="electricCurrent1">The electricCurrent1.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static ElectricCurrent operator *(ElectricCurrent electricCurrent1, double value)
        {
            return new ElectricCurrent(electricCurrent1.UnitValue * value);
        }

        #endregion


        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return ToString(ElectricCurrentUnit.Ampere, CultureInfo.InvariantCulture, DefaultStringFormat);
        }
        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public override string ToString(ElectricCurrentUnit unit, IFormatProvider formatProvider, string format)
        {
            var value = UnitValue;
            return string.Format(formatProvider, format, value, "A");
        }
    }
}
