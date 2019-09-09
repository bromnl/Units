using System;
using System.Collections.Generic;
using System.Globalization;

namespace Units
{
    /// <summary>
    /// Class Volume.
    /// Implements the <see cref="Unit{VolumeUnit}" />
    /// </summary>
    /// <seealso cref="Unit{VolumeUnit}" />
    public class Volume : Unit<VolumeUnit>
    {
        private static readonly Dictionary<VolumeUnit, double> ConversionToUnitDictionary =
            new Dictionary<VolumeUnit, double>
            {
                {VolumeUnit.Barrel, 0.115_627_123_584d},
                {VolumeUnit.CubicInch, 0.000_016_387_064d},
                {VolumeUnit.CubicMeter, 1d},
                {VolumeUnit.CubicYard, 0.764_554_857_984d},
                {VolumeUnit.Dram, 0.000_003_551_632_812_5d},
                {VolumeUnit.FluidOunce, 0.000_028_413_062_5d},
                {VolumeUnit.Gallon, 0.004_546_09d},
                {VolumeUnit.Liter, 0.001d},
                {VolumeUnit.Pint, 0.000_568_261_25d},
                {VolumeUnit.Quart, 0.001_136_522_5d},
                {VolumeUnit.Tsp, 0.000_005d},
            };
        private static readonly Dictionary<VolumeUnit, string> UnitToStringDictionary = new Dictionary<VolumeUnit, string>
        {
            {VolumeUnit.Barrel, "barrel" },
            {VolumeUnit.CubicInch, "in³" },
            {VolumeUnit.CubicMeter, "m³" },
            {VolumeUnit.CubicYard, "yd³" },
            {VolumeUnit.Dram, "dr" },
            {VolumeUnit.FluidOunce, "fl oz" },
            {VolumeUnit.Gallon, "gal" },
            {VolumeUnit.Liter, "L" },
            {VolumeUnit.Pint, "pt" },
            {VolumeUnit.Quart, "qt" },
            {VolumeUnit.Tsp, "tsp" },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Volume"/> class.
        /// </summary>
        /// <param name="cubicMeter">The cubic meter.</param>
        public Volume(double cubicMeter) : base(cubicMeter) { }

        /// <summary>
        /// Gets a Volume based on the provided cubic meter.
        /// </summary>
        /// <param name="cubicMeter">The cubic meter.</param>
        /// <returns>Volume.</returns>
        public static Volume FromCubicMeter(double cubicMeter)
        {
            return new Volume(cubicMeter);
        }
        /// <summary>
        /// Gets a Volume based on the provided liter.
        /// </summary>
        /// <param name="liter">The liter.</param>
        /// <returns>Volume.</returns>
        public static Volume FromLiter(double liter)
        {
            return new Volume(liter * ConversionToUnitDictionary[VolumeUnit.Liter]);
        }
        /// <summary>
        /// Gets a Volume based on the provided fluid ounce.
        /// </summary>
        /// <param name="fluidOunce">The fluid ounce.</param>
        /// <returns>Volume.</returns>
        public static Volume FromFluidOunce(double fluidOunce)
        {
            return new Volume(fluidOunce * ConversionToUnitDictionary[VolumeUnit.FluidOunce]);
        }
        /// <summary>
        /// Gets a Volume based on the provided gallon.
        /// </summary>
        /// <param name="gallon">The gallon.</param>
        /// <returns>Volume.</returns>
        public static Volume FromGallon(double gallon)
        {
            return new Volume(gallon * ConversionToUnitDictionary[VolumeUnit.Gallon]);
        }
        /// <summary>
        /// Gets a Volume based on the provided quart.
        /// </summary>
        /// <param name="quart">The quart.</param>
        /// <returns>Volume.</returns>
        public static Volume FromQuart(double quart)
        {
            return new Volume(quart * ConversionToUnitDictionary[VolumeUnit.Quart]);
        }
        /// <summary>
        /// Gets a Volume based on the provided pint.
        /// </summary>
        /// <param name="pint">The pint.</param>
        /// <returns>Volume.</returns>
        public static Volume FromPint(double pint)
        {
            return new Volume(pint * ConversionToUnitDictionary[VolumeUnit.Pint]);
        }
        /// <summary>
        /// Gets a Volume based on the provided Tsp.
        /// </summary>
        /// <param name="tsp">The Tsp.</param>
        /// <returns>Volume.</returns>
        public static Volume FromTsp(double tsp)
        {
            return new Volume(tsp * ConversionToUnitDictionary[VolumeUnit.Tsp]);
        }
        /// <summary>
        /// Gets a Volume based on the provided dram.
        /// </summary>
        /// <param name="dram">The dram.</param>
        /// <returns>Volume.</returns>
        public static Volume FromDram(double dram)
        {
            return new Volume(dram * ConversionToUnitDictionary[VolumeUnit.Dram]);
        }
        /// <summary>
        /// Gets a Volume based on the provided cubic inch.
        /// </summary>
        /// <param name="cubicInch">The cubic inch.</param>
        /// <returns>Volume.</returns>
        public static Volume FromCubicInch(double cubicInch)
        {
            return new Volume(cubicInch * ConversionToUnitDictionary[VolumeUnit.CubicInch]);
        }
        /// <summary>
        /// Gets a Volume based on the provided cubic yard.
        /// </summary>
        /// <param name="cubicYard">The cubic yard.</param>
        /// <returns>Volume.</returns>
        public static Volume FromCubicYard(double cubicYard)
        {
            return new Volume(cubicYard * ConversionToUnitDictionary[VolumeUnit.CubicYard]);
        }
        /// <summary>
        /// Gets a Volume based on the provided barrel.
        /// </summary>
        /// <param name="barrel">The barrel.</param>
        /// <returns>Volume.</returns>
        public static Volume FromBarrel(double barrel)
        {
            return new Volume(barrel * ConversionToUnitDictionary[VolumeUnit.Barrel]);
        }

        #region Operator overloads

        /// <summary>
        /// Implements the + operator.
        /// </summary>
        /// <param name="volume1">The volume1.</param>
        /// <param name="volume2">The volume2.</param>
        /// <returns>The result of the operator.</returns>
        public static Volume operator +(Volume volume1, Volume volume2)
        {
            return new Volume(volume1.UnitValue + volume2.UnitValue);
        }
        /// <summary>
        /// Implements the - operator.
        /// </summary>
        /// <param name="volume1">The volume1.</param>
        /// <param name="volume2">The volume2.</param>
        /// <returns>The result of the operator.</returns>
        public static Volume operator -(Volume volume1, Volume volume2)
        {
            return new Volume(volume1.UnitValue - volume2.UnitValue);
        }
        /// <summary>
        /// Implements the / operator.
        /// </summary>
        /// <param name="volume">The volume.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Volume operator /(Volume volume, double value)
        {
            return new Volume(volume.UnitValue / value);
        }
        /// <summary>
        /// Implements the * operator.
        /// </summary>
        /// <param name="volume">The volume.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Volume operator *(Volume volume, double value)
        {
            return new Volume(volume.UnitValue * value);
        }

        #endregion


        #region Public properties

        /// <summary>
        /// Gets the volume in barrel.
        /// </summary>
        /// <value>The barrel.</value>
        public double Barrel => UnitValue / ConversionToUnitDictionary[VolumeUnit.Barrel];
        /// <summary>
        /// Gets the volume in cubic inch.
        /// </summary>
        /// <value>The cubic inch.</value>
        public double CubicInch => UnitValue / ConversionToUnitDictionary[VolumeUnit.CubicInch];
        /// <summary>
        /// Gets the volume in cubic meter.
        /// </summary>
        /// <value>The cubic meter.</value>
        public double CubicMeter => UnitValue / ConversionToUnitDictionary[VolumeUnit.CubicMeter];
        /// <summary>
        /// Gets the volume in cubic yard.
        /// </summary>
        /// <value>The cubic yard.</value>
        public double CubicYard => UnitValue / ConversionToUnitDictionary[VolumeUnit.CubicYard];
        /// <summary>
        /// Gets the volume in dram.
        /// </summary>
        /// <value>The dram.</value>
        public double Dram => UnitValue / ConversionToUnitDictionary[VolumeUnit.Dram];
        /// <summary>
        /// Gets the volume in fluid ounce.
        /// </summary>
        /// <value>The fluid ounce.</value>
        public double FluidOunce => UnitValue / ConversionToUnitDictionary[VolumeUnit.FluidOunce];
        /// <summary>
        /// Gets the volume in gallon.
        /// </summary>
        /// <value>The gallon.</value>
        public double Gallon => UnitValue / ConversionToUnitDictionary[VolumeUnit.Gallon];
        /// <summary>
        /// Gets the volume in liter.
        /// </summary>
        /// <value>The liter.</value>
        public double Liter => UnitValue / ConversionToUnitDictionary[VolumeUnit.Liter];
        /// <summary>
        /// Gets the volume in pint.
        /// </summary>
        /// <value>The pint.</value>
        public double Pint => UnitValue / ConversionToUnitDictionary[VolumeUnit.Pint];
        /// <summary>
        /// Gets the volume in quart.
        /// </summary>
        /// <value>The quart.</value>
        public double Quart => UnitValue / ConversionToUnitDictionary[VolumeUnit.Quart];
        /// <summary>
        /// Gets the volume in Tsp.
        /// </summary>
        /// <value>The Tsp.</value>
        public double Tsp => UnitValue / ConversionToUnitDictionary[VolumeUnit.Tsp];

        #endregion

        #region ToString Functions

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return ToString(VolumeUnit.CubicMeter, CultureInfo.InvariantCulture, DefaultStringFormat);
        }
        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString(VolumeUnit unit, IFormatProvider formatProvider, string format)
        {
            var value = UnitValue / ConversionToUnitDictionary[unit];
            return string.Format(formatProvider, format, value, UnitToStringDictionary[unit]);
        }

        #endregion
    }
}
