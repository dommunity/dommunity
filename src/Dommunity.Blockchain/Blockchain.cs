using System;

namespace Dommunity.Blockchain
{
    /// <summary>
    /// Represents a blockchain.
    /// </summary>
    public sealed class Blockchain
    {
        readonly IBlockchainStorage storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="Blockchain"/> class.
        /// </summary>
        /// <param name="storage">
        /// Storage for store blocks.
        /// </param>
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
