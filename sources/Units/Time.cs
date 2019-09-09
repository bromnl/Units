using System;
using System.Collections.Generic;
using System.Globalization;

namespace Units
{
    /// <summary>
    /// Class Time.
    /// Implements the <see cref="Units.Unit{TimeUnit}" />
    /// </summary>
    /// <seealso cref="Units.Unit{TimeUnit}" />
    public class Time : Unit<TimeUnit>
    {
        private static readonly Dictionary<TimeUnit,double> ConversionDictionary = new Dictionary<TimeUnit, double>
        {
            {TimeUnit.Second, 1d },
            {TimeUnit.Minute, 1d/60d },
            {TimeUnit.Hour, 1d/3600d },
            {TimeUnit.Day, 1d/86400d },
            {TimeUnit.Week, 1d/604800d },
        };
        private static readonly Dictionary<TimeUnit, string> UnitToStringDictionary = new Dictionary<TimeUnit, string>
        {
            {TimeUnit.Second, "s" },
            {TimeUnit.Minute, "min" },
            {TimeUnit.Hour, "h" },
            {TimeUnit.Day, "days" },
            {TimeUnit.Week, "weeks" },
        };

        #region Constructors

        /// <summary>
        /// Constructs a time unit based on the provided seconds
        /// </summary>
        /// <param name="timeInSeconds"></param>
        public Time(double timeInSeconds) : base(timeInSeconds) { }

        /// <summary>
        /// Constructs a time unit based on the provided hours, minutes and seconds
        /// </summary>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        public Time(double hours, double minutes, double seconds)
            : base(hours / ConversionDictionary[TimeUnit.Hour] + minutes / ConversionDictionary[TimeUnit.Minute] + seconds) { }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the seconds.
        /// </summary>
        /// <value>The seconds.</value>
        public double Seconds => UnitValue;
        /// <summary>
        /// Gets the minutes.
        /// </summary>
        /// <value>The minutes.</value>
        public double Minutes => UnitValue * ConversionDictionary[TimeUnit.Minute];
        /// <summary>
        /// Gets the hours.
        /// </summary>
        /// <value>The hours.</value>
        public double Hours => UnitValue * ConversionDictionary[TimeUnit.Hour];
        /// <summary>
        /// Gets the days.
        /// </summary>
        /// <value>The days.</value>
        public double Days => UnitValue * ConversionDictionary[TimeUnit.Day];
        /// <summary>
        /// Gets the weeks.
        /// </summary>
        /// <value>The weeks.</value>
        public double Weeks => UnitValue * ConversionDictionary[TimeUnit.Week];

        #endregion

        #region Static functions

        /// <summary>
        /// Create a Time unit based on the provided seconds.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        /// <returns>Time.</returns>
        public static Time FromSeconds(double seconds)
        {
            return new Time(seconds);
        }

        /// <summary>
        /// Create a Time unit based on the provided minutes.
        /// </summary>
        /// <param name="minutes">The minutes.</param>
        /// <returns>Time.</returns>
        public static Time FromMinutes(double minutes)
        {
            return new Time(minutes / ConversionDictionary[TimeUnit.Minute]);
        }

        /// <summary>
        /// Create a Time unit based on the provided hours.
        /// </summary>
        /// <param name="hours">The hours.</param>
        /// <returns>Time.</returns>
        public static Time FromHours(double hours)
        {
            return new Time(hours / ConversionDictionary[TimeUnit.Hour]);
        }

        /// <summary>
        /// Create a Time unit based on the provided days.
        /// </summary>
        /// <param name="days">The days.</param>
        /// <returns>Time.</returns>
        public static Time FromDays(double days)
        {
            return new Time(days / ConversionDictionary[TimeUnit.Day]);
        }

        /// <summary>
        /// Create a Time unit based on the provided weeks.
        /// </summary>
        /// <param name="weeks">The weeks.</param>
        /// <returns>Time.</returns>
        public static Time FromWeeks(double weeks)
        {
            return new Time(weeks / ConversionDictionary[TimeUnit.Week]);
        }

        #endregion

        #region Operator overloads

        /// <summary>
        /// Implements the + operator.
        /// </summary>
        /// <param name="time1">The time1.</param>
        /// <param name="time2">The time2.</param>
        /// <returns>The result of the operator.</returns>
        public static Time operator +(Time time1, Time time2)
        {
            return new Time(time1.Seconds + time2.Seconds);
        }
        /// <summary>
        /// Implements the - operator.
        /// </summary>
        /// <param name="time1">The time1.</param>
        /// <param name="time2">The time2.</param>
        /// <returns>The result of the operator.</returns>
        public static Time operator -(Time time1, Time time2)
        {
            return new Time(time1.Seconds - time2.Seconds);
        }
        /// <summary>
        /// Implements the / operator.
        /// </summary>
        /// <param name="time1">The time1.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Time operator /(Time time1, double value)
        {
            return new Time(time1.Seconds / value);
        }
        /// <summary>
        /// Implements the * operator.
        /// </summary>
        /// <param name="time1">The time1.</param>
        /// <param name="value">The value.</param>
        /// <returns>The result of the operator.</returns>
        public static Time operator *(Time time1, double value)
        {
            return new Time(time1.Seconds * value);
        }

        #endregion

        #region ToString Functions

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return ToString(TimeUnit.Second, CultureInfo.InvariantCulture, DefaultStringFormat);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString(TimeUnit unit, IFormatProvider formatProvider, string format)
        {
            var value = ConversionDictionary[unit] * UnitValue;
            return string.Format(formatProvider, format, value, UnitToStringDictionary[unit]);
        }

        #endregion
    }
}
