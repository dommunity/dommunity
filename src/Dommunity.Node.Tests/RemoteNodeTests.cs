using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dommunity.Node.Messaging;
using NSubstitute;
using Xunit;

namespace Dommunity.Node.Tests.Messaging
{
    public class RemoteNodeTests
    {
        [Fact]
        public void Constructor_PassNullForMessageSerializers_ShouldThrow()
        {
            Assert.ThrowsAny<ArgumentNullException>(() =>
            {
                new TestRemoteNode(messageSerializers: null, messageProcessors: Enumerable.Empty<IMessageProcessor>());
            });
        }

        [Fact]
        public void Constructor_PassNullForMessageProcessors_ShouldThrow()
        {
            Assert.ThrowsAny<ArgumentNullException>(() =>
            {
                new TestRemoteNode(messageSerializers: Enumerable.Empty<IMessageSerializer>(), messageProcessors: null);
            });
        }

        [Fact]
        public void Constructor_PassCorrectParams_ShouldNotThrow()
        {
            new TestRemoteNode(Enumerable.Empty<IMessageSerializer>(), Enumerable.Empty<IMessageProcessor>());
        }

        [Fact]
        public void DeserializeMessageAsync_PassNegativeForPayloadSize_ShouldThrow()
        {
            var node = new TestRemoteNode(
                Enumerable.Empty<IMessageSerializer>(),
                Enumerable.Empty<IMessageProcessor>()
            );

            Assert.ThrowsAnyAsync<ArgumentOutOfRangeException>(() =>
            {
                return node.DeserializeMessageAsync(Guid.Empty, -1, Stream.Null, CancellationToken.None);
            });
        }

        [Fact]
        public void DeserializeMessageAsync_PassNullForPayload_ShouldThrow()
        {
            var node = new TestRemoteNode(
                Enumerable.Empty<IMessageSerializer>(),
                Enumerable.Empty<IMessageProcessor>()
            );

            Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
            {
                return node.DeserializeMessageAsync(Guid.Empty, 0, null, CancellationToken.None);
            });
        }

        [Fact]
        public void DeserializeMessageAsync_PassInvalidPayloadSize_ShouldThrow()
        {
            var node = new TestRemoteNode(
                new[] { new FooSerializer() },
                Enumerable.Empty<IMessageProcessor>()
            );

            using (var payload = FooSerializer.CreateFooPayload(0))
            {
                Assert.ThrowsAnyAsync<InvalidMessageException>(() =>
                {
                    return node.DeserializeMessageAsync(
                        FooMessage.Id,
                        FooMessage.Size + 1,
                        payload,
                        CancellationToken.None);
                });
            }
        }

        [Fact]
        public void DeserializeMessageAsync_PassInvalidPayload_ShouldThrow()
        {
            var node = new TestRemoteNode(
                new[] { new FooSerializer() },
                Enumerable.Empty<IMessageProcessor>()
            );

            using (var payload = FooSerializer.CreateFooPayload(-1))
            {
                Assert.ThrowsAnyAsync<InvalidMessageException>(() =>
                {
                    return node.DeserializeMessageAsync(
                        FooMessage.Id,
                        FooMessage.Size,
                        payload,
                        CancellationToken.None);
                });
            }
        }

        [Fact]
        public async Task DeserializeMessageAsync_PassUnsupportedMessage_ShouldReturnNull()
        {
            var node = new TestRemoteNode(
                new[] { new FooSerializer() },
                Enumerable.Empty<IMessageProcessor>()
            );

            var message = await node.DeserializeMessageAsync(Guid.Empty, 0, Stream.Null, CancellationToken.None);

            Assert.Null(message);
        }

        [Fact]
        public async Task DeserializeMessageAsync_PassSupportedMessage_ShouldReturnDeserializedMessage()
        {
            FooMessage message;

            var node = new TestRemoteNode(
                new[] { new FooSerializer() },
                Enumerable.Empty<IMessageProcessor>()
            );

            using (var payload = FooSerializer.CreateFooPayload(5))
            {
                message = (FooMessage)await node.DeserializeMessageAsync(
                    FooMessage.Id,
                    FooMessage.Size,
                    payload,
                    CancellationToken.None);
            }

            Assert.Equal(5, message.Value1);
        }

        [Fact]
        public async Task DeserializeMessageAsync_WithMultipleDeserializers_ShouldPickTheFirstReturnNonNull()
        {
            FooMessage message;

            var node = new TestRemoteNode(
                new IMessageSerializer[]
                {
                    new BazSerializer(),
                    new FooSerializer(),
                    new BarSerializer()
                },
                Enumerable.Empty<IMessageProcessor>()
            );

            using (var payload = FooSerializer.CreateFooPayload(3))
            {
                message = (FooMessage)await node.DeserializeMessageAsync(
                    FooMessage.Id,
                    FooMessage.Size,
                    payload,
                    CancellationToken.None);
            }

            Assert.Equal(3, message.Value1);
        }

        [Fact]
        public Task ProcessMessageAsync_PassNullForMessage_ShouldThrow()
        {
            var node = new TestRemoteNode(
                Enumerable.Empty<IMessageSerializer>(),
                Enumerable.Empty<IMessageProcessor>()
            );

            return Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
            {
                return node.ProcessMessageAsync(null, CancellationToken.None);
            });
        }

        [Fact]
        public async Task ProcessMessageAsync_WithMultipleProcessors_ShouldPassMessageFromPreviousToNextProcessor()
        {
            var originalMessage = new object();
            var newMessage = new object();

            var firstProcessor = Substitute.For<IMessageProcessor>();

            firstProcessor
                .RunAsync(Arg.Is<IRemoteNode>(n => n != null), originalMessage, Arg.Any<CancellationToken>())
                .Returns(Task.FromResult(newMessage));

            var secondProcessor = Substitute.For<IMessageProcessor>();

            var node = new TestRemoteNode(
                Enumerable.Empty<IMessageSerializer>(),
                new[] { firstProcessor, secondProcessor }
            );

            await node.ProcessMessageAsync(originalMessage, CancellationToken.None);

            await secondProcessor
                .Received()
                .RunAsync(Arg.Is<IRemoteNode>(n => n != null), newMessage, Arg.Any<CancellationToken>());
        }

        [Fact]
        public async Task ProcessMessageAsync_WithMultipleProcessors_ShouldStopWhenPreviousReturnNull()
        {
            var firstProcessor = Substitute.For<IMessageProcessor>();

            firstProcessor
                .RunAsync(
                    Arg.Is<IRemoteNode>(n => n != null),
                    Arg.Is<object>(m => m != null),
                    Arg.Any<CancellationToken>()
                )
                .Returns(Task.FromResult<object>(null));

            var secondProcessor = Substitute.For<IMessageProcessor>();

            var node = new TestRemoteNode(
                Enumerable.Empty<IMessageSerializer>(),
                new[] { firstProcessor, secondProcessor }
            );

            await node.ProcessMessageAsync(new object(), CancellationToken.None);

            await secondProcessor
                .DidNotReceive()
                .RunAsync(Arg.Any<IRemoteNode>(), Arg.Any<object>(), Arg.Any<CancellationToken>());
        }
    }
}
