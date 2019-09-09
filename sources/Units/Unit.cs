using System;
using System.Globalization;

namespace Units
{
    /// <summary>
    /// Class Unit.
    /// Implements the IEquatable&lt;Unit&lt;T&gt;&gt;" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Unit<T> : IEquatable<Unit<T>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Unit{T}"/> class.
        /// </summary>
        /// <param name="unitValue">The unit value.</param>
        protected Unit(double unitValue)
        {
            UnitValue = unitValue;
        }

        /// <summary>
        /// Gets the unit value.
        /// </summary>
        /// <value>The unit value.</value>
        protected double UnitValue { get; }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public string ToString(T unit)
        {
            return ToString(unit, CultureInfo.InvariantCulture, DefaultStringFormat);
        }

        /// <summary>
        /// Gets the default string format.
        /// </summary>
        /// <value>The default string format.</value>
        protected virtual string DefaultStringFormat => "{0:F} {1}";

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="format">The format.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public string ToString(T unit, string format)
        {
            return ToString(unit, CultureInfo.InvariantCulture, format);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public string ToString(T unit, IFormatProvider formatProvider)
        {
            return ToString(unit, formatProvider, DefaultStringFormat);
        }

        /// <summary>
        /// Returns a <see cref="string" /> that represents this instance.
        /// </summary>
        /// <param name="unit">The unit.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public abstract string ToString(T unit, IFormatProvider formatProvider, string format);

        #region IEquatable members
        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
        public bool Equals(Unit<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return UnitValue.Equals(other.UnitValue);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Unit<T>)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return UnitValue.GetHashCode();
        }
        #endregion
    }
}
