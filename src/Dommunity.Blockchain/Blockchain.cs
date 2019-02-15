using System;

namespace Dommunity.Blockchain
{
    /// <summary>
    /// Represents a blockchain.
    /// </summary>
    public sealed class Blockchain : IBlockchain
    {
        readonly IBlockchainStorage storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="Blockchain"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="storage"/> is <c>null</c>.
        /// </exception>
        public Blockchain(IBlockchainStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException(nameof(storage));
            }

            this.storage = storage;
        }
    }
}
