using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace Dommunity.Identity.Tests
{
    public sealed class ReputationTests
    {
        [Fact]
        public void Default_WhenCreated_ShouldEqualToZero()
        {
            var reputation = default(Reputation);

            Assert.Equal(new Reputation(0), reputation);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void Constructor_WithInt32_ShouldEqualToThatValue(int value)
        {
            var reputation = new Reputation(value);

            Assert.Equal(value.ToString(), reputation.ToString());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void Implicit_FromInt32_ShouldEqualToThatValue(int value)
        {
            Reputation reputation = value;

            Assert.Equal(value.ToString(), reputation.ToString());
        }

        [Theory]
        [InlineData(-1, -2)]
        [InlineData(-2, -1)]
        [InlineData(-1, -1)]
        [InlineData(-1, 1)]
        [InlineData(-1, 2)]
        [InlineData(-2, 1)]
        [InlineData(-2, 2)]
        [InlineData(0, -2)]
        [InlineData(-2, 0)]
        [InlineData(0, -1)]
        [InlineData(-1, 0)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(0, 2)]
        [InlineData(2, 0)]
        [InlineData(1, -1)]
        [InlineData(1, -2)]
        [InlineData(2, -1)]
        [InlineData(2, -2)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        public void Addition_WhenInvoke_ShouldReturnAdditionValue(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.Equal(first + second, left + right);
        }

        [Theory]
        [InlineData(-1, -3)]
        [InlineData(-1, -2)]
        [InlineData(0, -1)]
        [InlineData(0, -2)]
        [InlineData(1, 0)]
        [InlineData(1, -1)]
        public void GreaterThan_WithLess_ShouldReturnTrue(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.True(left > right);
        }

        [Theory]
        [InlineData(-2, -2)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void GreaterThan_WithEqual_ShouldReturnFalse(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.False(left > right);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        public void GreaterThan_WithGreater_ShouldReturnFalse(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.False(left > right);
        }

        [Theory]
        [InlineData(-1, -3)]
        [InlineData(-1, -2)]
        [InlineData(0, -2)]
        [InlineData(0, -1)]
        [InlineData(1, 0)]
        [InlineData(1, -1)]
        public void LessThan_WithLess_ShouldReturnFalse(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.False(left < right);
        }

        [Theory]
        [InlineData(-2, -2)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void LessThan_WithEqual_ShouldReturnFalse(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.False(left < right);
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(-1, 1)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        public void LessThan_WithGreater_ShouldReturnTrue(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.True(left < right);
        }

        [Theory]
        [InlineData(-2, -1)]
        [InlineData(-1, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 2)]
        public void CompareTo_WithGreaterThan_ShouldReturnNegative(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.True(left.CompareTo(right) < 0);
        }

        [Theory]
        [InlineData(-2, -2)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void CompareTo_WithEqual_ShouldReturnZero(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.Equal(0, left.CompareTo(right));
        }

        [Theory]
        [InlineData(-1, -2)]
        [InlineData(0, -1)]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        public void CompareTo_WithLessThan_ShouldReturnPositive(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.True(left.CompareTo(right) > 0);
        }

        [Theory]
        [InlineData(-2, -2)]
        [InlineData(-1, -1)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void Equals_WithEqual_ShouldReturnTrue(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.True(left.Equals(right));
            Assert.True(left.Equals((object)right));
        }

        [Theory]
        [InlineData(-2, -1)]
        [InlineData(-1, -2)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        public void Equals_WithUnequal_ShouldReturnFalse(int first, int second)
        {
            var left = new Reputation(first);
            var right = new Reputation(second);

            Assert.False(left.Equals(right));
            Assert.False(left.Equals((object)right));
        }

        [Fact]
        public void Equals_WithNull_ShouldReturnFalse()
        {
            var left = new Reputation(0);
            var right = null as object;

            Assert.False(left.Equals(right));
        }

        [Theory]
        [InlineData((byte)0)]
        [InlineData((short)0)]
        [InlineData(0)]
        [InlineData((long)0)]
        public void Equals_WithDifferentType_ShouldReturnFalse(object right)
        {
            var left = new Reputation(0);

            Assert.False(left.Equals(right));
        }

        [Fact]
        public void GetHashCode_WithDifferentValue_ShouldReturnDifferentValue()
        {
            var hashes = new HashSet<int>();

            for (var i = 0; i < 10; i++)
            {
                var reputation = new Reputation(i);
                var hash = reputation.GetHashCode();

                Assert.True(hashes.Add(hash));
            }
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void ToString_WithNoFormat_ShouldReturnFormatInCurrentCulture(int value)
        {
            var reputation = new Reputation(value);

            Assert.Equal(value.ToString(), reputation.ToString());
            Assert.Equal(value.ToString((IFormatProvider)null), reputation.ToString(null));
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void ToString_WithFormat_ShouldReturnFormatInThatCulture(int value)
        {
            var reputation = new Reputation(value);
            var format = CultureInfo.GetCultureInfo("th-TH");

            Assert.Equal(value.ToString(format), reputation.ToString(format));
        }
    }
}
