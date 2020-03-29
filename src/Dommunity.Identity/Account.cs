namespace Dommunity.Identity
{
    using System;

    /// <summary>
    /// Represents a user account.
    /// </summary>
    public sealed class Account
    {
        private Reputation reputation;

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="id">
        /// A unique identifier of the account.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="id"/> is <c>null</c>.
        /// </exception>
        public Account(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            this.Id = id;
        }

        /// <summary>
        /// Gets a unique identifier of the account.
        /// </summary>
        /// <value>
        /// A unique identifier of the account.
        /// </value>
        public string Id { get; }

        /// <summary>
        /// Gets or sets a reputation of the account.
        /// </summary>
        /// <value>
        /// A reputation of the account.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// A new value is negative.
        /// </exception>
        public Reputation Reputation
        {
            get => this.reputation;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                this.reputation = value;
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            return ((Account)obj).Id == this.Id;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.Id;
        }
    }
}
