using System;
using System.Collections.Generic;
using Xunit;

namespace Dommunity.Identity.Tests
{
    public sealed class AccountTests
    {
        readonly Account subject;

        public AccountTests()
        {
            this.subject = new Account("abc");
        }

        [Fact]
        public void Constructor_WithNullId_ShouldThrow()
        {
            Assert.Throws<ArgumentNullException>("id", () => new Account(null));
        }

        [Fact]
        public void Constructor_WhenSucceeded_ShouldInitializeProperties()
        {
            Assert.Equal("abc", this.subject.Id);
            Assert.Equal(0, this.subject.Reputation);
        }

        [Theory]
        [InlineData(int.MinValue)]
        [InlineData(-1)]
        public void Reputation_AssignWithInvalidValue_ShouldThrow(int value)
        {
            Assert.Throws<ArgumentOutOfRangeException>("value", () => this.subject.Reputation = value);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(int.MaxValue)]
        public void Reputation_AssignWithValidValue_ValueShouldUpdated(int value)
        {
            this.subject.Reputation = value;

            Assert.Equal(value, this.subject.Reputation);
        }

        [Fact]
        public void Equals_WithNull_ShouldReturnFalse()
        {
            Assert.False(this.subject.Equals(null));
        }

        [Fact]
        public void Equals_WithDifferentType_ShouldReturnFalse()
        {
            Assert.False(this.subject.Equals(new { this.subject.Id }));
        }

        [Fact]
        public void Equals_WithDifferentId_ShouldReturnFalse()
        {
            var other = new Account("foo");

            Assert.False(this.subject.Equals(other));
        }

        [Fact]
        public void Equals_WithSameId_ShouldReturnTrue()
        {
            var other = new Account("abc");

            Assert.True(this.subject.Equals(other));
        }

        [Fact]
        public void GetHashCode_WithDifferentId_ShouldReturnDifferentValue()
        {
            var hashes = new HashSet<int>();
            var ids = new[] { "", "1", "2", "a", "b", "c" };

            foreach (var id in ids)
            {
                var account = new Account(id);
                var hash = account.GetHashCode();

                Assert.True(hashes.Add(hash));
            }
        }

        [Fact]
        public void ToString_WhenInvoke_ShouldReturnId()
        {
            Assert.Equal("abc", this.subject.ToString());
        }
    }
}
