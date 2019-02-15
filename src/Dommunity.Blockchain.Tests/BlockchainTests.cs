using System;
using Xunit;

namespace Dommunity.Blockchain.Tests
{
    public class BlockchainTests
    {
        [Fact]
        public void Constructor_PassNullForStorage_ShouldThrow()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => new Blockchain(storage: null));
        }
    }
}
