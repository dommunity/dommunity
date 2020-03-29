namespace Dommunity.Identity
{
    using System;

    /// <summary>
    /// Represetns a reputation point for the account.
    /// </summary>
    public readonly struct Reputation : IComparable<Reputation>, IEquatable<Reputation>
    {
        private readonly int value;

        /// <summary>
        /// Initializes a new instance of the <see cref="Reputation"/> struct.
        /// </summary>
        /// <param name="value">
        /// The value to represent as a <see cref="Reputation"/>.
        /// </param>
        public Reputation(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Defines an implicit conversion of a 32-bit signed integer to a <see cref="Reputation"/>.
        /// </summary>
        /// <param name="value">
        /// The 32-bit signed integer to convert.
        /// </param>
        public static implicit operator Reputation(int value)
        {
            return new Reputation(value);
        }

        /// <summary>
        /// Adds two specified <see cref="Reputation"/> values.
        /// </summary>
        /// <param name="left">
        /// The first value to add.
        /// </param>
        /// <param name="right">
        /// The second value to add.
        /// </param>
        /// <returns>
        /// The result of adding <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static Reputation operator +(Reputation left, Reputation right)
        {
            return left.value + right.value;
        }

        /// <summary>
        /// Returns a value indicating whether a specified <see cref="Reputation"/> is greater than another specified
        /// <see cref="Reputation"/>.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator >(Reputation left, Reputation right)
        {
            return left.value > right.value;
        }

        /// <summary>
        /// Returns a value indicating whether a specified <see cref="Reputation"/> is less than another specified
        /// <see cref="Reputation"/>.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator <(Reputation left, Reputation right)
        {
            return left.value < right.value;
        }

        /// <inheritdoc/>
        public int CompareTo(Reputation other)
        {
            return this.value.CompareTo(other.value);
        }

        /// <inheritdoc/>
        public bool Equals(Reputation other)
        {
            return other.value == this.value;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Reputation)obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.value.ToString();
        }

        /// <summary>
        /// Converts the reputation value of this instance to its equivalent string representation using the specified
        /// culture-specific format information.
        /// </summary>
        /// <param name="format">
        /// An object that supplies culture-specific formatting information.
        /// </param>
        /// <returns>
        /// The string representation of the value of this instance as specified by <paramref name="format"/>.
        /// </returns>
        public string ToString(IFormatProvider? format)
        {
            return this.value.ToString(format);
        }
    }
}
