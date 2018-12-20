using System;
using Xunit;

namespace Dommunity.Node.Tests
{
    public class NodeTests
    {
        [Fact]
        public void SeedNodes_ShoudNotEmpty()
        {
            Assert.NotEmpty(Node.SeedNodes);
        }
    }
}
