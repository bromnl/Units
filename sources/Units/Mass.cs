using System;
using System.Collections.Generic;

namespace Units
{
    /// <summary>
    /// Class Mass.
    /// Implements the <see cref="MassUnit" />
    /// </summary>
    /// <seealso cref="MassUnit" />
    public class Mass : Unit<MassUnit>
    {
        private static readonly Dictionary<MassUnit, double> ConversionDictionary = new Dictionary<MassUnit, double>
        {
            {MassUnit.Kilogram, 1d },
            {MassUnit.Gram, 0.001d },
            {MassUnit.Tonne, 1000d },
            {MassUnit.Slug, 14.59390d },
            {MassUnit.Pound, 0.453_592_37d },
            {MassUnit.PlanckMass, 2.17643524E-8d },
            {MassUnit.SolarMass, 1.988_47E30d },
        };
        private static readonly Dictionary<MassUnit, string> UnitToStringDictionary = new Dictionary<MassUnit, string>
        {
            {MassUnit.Kilogram, "kg" },
            {MassUnit.Tonne, "t" },
            {MassUnit.Gram, "g" },
            {MassUnit.Slug, "sl" },
            {MassUnit.Pound, "lb" },
            {MassUnit.PlanckMass, "mP" },
            {MassUnit.SolarMass, "M☉" },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Mass"/> class.
        /// </summary>
        /// <param name="unitValue">The unit value.</param>
        public Mass(double unitValue) : base(unitValue) { }

        #region Operator overloads

        /// <summary>
        /// Implements the + operator.
        /// </summary>
        /// <param name="mass1">The mass1.</param>
        /// <param name="mass2">The mass2.</param>
        /// <returns>The result of the operator.</returns>
        public static Mass operator +(Mass mass1, Mass mass2)
        {
            return new Mass(mass1.UnitValue + mass2.UnitValue);
        }
        /// <summary>
        /// Implements the - operator.
        /// </summary>
        /// <param name="mass1">The mass1.</param>
        /// <param name="mass2">The mass2.</param>
        /// <returns>The result of the operator.</returns>
        public static Mass operator -(Mass mass1, Mass mass2)
        {
            return new Mass(mass1.UnitValue - mass2.UnitValue);
        }
        /// <summary>
        /// Implements the / operator.
        /// </summary>
        /// <param name="mass">The mass.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Mass operator /(Mass mass, double value)
        {
            return new Mass(mass.UnitValue / value);
        }
        /// <summary>
        /// Implements the * operator.
        /// </summary>
        /// <param name="mass">The mass.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Mass operator *(Mass mass, double value)
        {
            return new Mass(mass.UnitValue * value);
        }

        #endregion

        #region public properties
        /// <summary>
        /// Gets the kilograms.
        /// </summary>
        /// <value>The kilograms.</value>
        public double Kilograms => UnitValue;
        /// <summary>
        /// Gets the grams.
        /// </summary>
        /// <value>The grams.</value>
        public double Grams => UnitValue / ConversionDictionary[MassUnit.Gram];
        /// <summary>
        /// Gets the pounds.
        /// </summary>
        /// <value>The pounds.</value>
        public double Pounds => UnitValue / ConversionDictionary[MassUnit.Pound];
        /// <summary>
        /// Gets the tonnes.
        /// </summary>
        /// <value>The tonnes.</value>
        public double Tonnes => UnitValue / ConversionDictionary[MassUnit.Tonne];
        /// <summary>
        /// Gets the slugs.
        /// </summary>
        /// <value>The slugs.</value>
        public double Slugs => UnitValue / ConversionDictionary[MassUnit.Slug];
        /// <summary>
        /// Gets the planck masses.
        /// </summary>
        /// <value>The planck masses.</value>
        public double PlanckMasses => UnitValue / ConversionDictionary[MassUnit.PlanckMass];
        /// <summary>
        /// Gets the solar masses.
        /// </summary>
        /// <value>The solar masses.</value>
        public double SolarMasses => UnitValue / ConversionDictionary[MassUnit.SolarMass];
        #endregion

        #region public static Function
        /// <summary>
        /// Get a mass based on the provided kilograms.
        /// </summary>
        /// <param name="kilograms">The kilograms.</param>
        /// <returns>Mass.</returns>
        public static Mass FromKilograms(double kilograms)
        {
            return new Mass(kilograms);
        }

        /// <summary>
        /// Get a mass based on the provided grams.
        /// </summary>
        /// <param name="grams">The grams.</param>
        /// <returns>Mass.</returns>
        public static Mass FromGrams(double grams)
        {
            return new Mass(grams * ConversionDictionary[MassUnit.Gram]);
        }

        /// <summary>
        /// Get a mass based on the provided pounds.
        /// </summary>
        /// <param name="pounds">The pounds.</param>
        /// <returns>System.Object.</returns>
        public static Mass FromPounds(double pounds)
        {
            return new Mass(pounds * ConversionDictionary[MassUnit.Pound]);
        }

        /// <summary>
        /// Get a mass based on the provided tonnes.
        /// </summary>
        /// <param name="tonnes">The tonnes.</param>
        /// <returns>Mass.</returns>
        public static Mass FromTonnes(double tonnes)
        {
            return new Mass(tonnes * ConversionDictionary[MassUnit.Tonne]);
        }
        /// <summary>
        /// Get a mass based on the provided slugs.
        /// </summary>
        /// <param name="slugs">The slugs.</param>
        /// <returns>Mass.</returns>
        public static Mass FromSlugs(double slugs)
        {
            return new Mass(slugs * ConversionDictionary[MassUnit.Slug]);
        }
        /// <summary>
        /// Get a mass based on the provided planck masses.
        /// </summary>
        /// <param name="planckMasses">The planck masses.</param>
        /// <returns>Mass.</returns>
        public static Mass FromPlanckMasses(double planckMasses)
        {
            return new Mass(planckMasses * ConversionDictionary[MassUnit.PlanckMass]);
        }
        /// <summary>
        /// Get a mass based on the provided solar masses.
        /// </summary>
        /// <param name="solarMasses">The solar masses.</param>
        /// <returns>Mass.</returns>
        public static Mass FromSolarMasses(double solarMasses)
        {
            return new Mass(solarMasses * ConversionDictionary[MassUnit.SolarMass]);
        }

        #endregion

        #region ToString functions
        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return ToString(MassUnit.Kilogram);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString(MassUnit unit, IFormatProvider formatProvider, string format)
        {
            var value = UnitValue / ConversionDictionary[unit];
            return string.Format(formatProvider, format, value, UnitToStringDictionary[unit]);
        }

        #endregion

    }
}
