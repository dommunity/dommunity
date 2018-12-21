using System;
using Dommunity.Node.Messaging;
using NSubstitute;
using Xunit;

namespace Dommunity.Node.Tests.Messaging
{
    public class MessageTests
    {
        [Fact]
        public void Constructor_PassIdIn_GetterShouldReturnTheSame()
        {
            var id = Guid.NewGuid();

            var message = Substitute.ForPartsOf<Message>(id);

            Assert.Equal(id, message.Id);
        }
    }
}
