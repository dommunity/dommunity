using System.Linq;
using Dommunity.Node.Messaging;
using NSubstitute;
using Xunit;

namespace Dommunity.Node.Tests.Messaging
{
    public class MessageProcessorAttributeTests
    {
        [Fact]
        public void ExecuteAfter_AssignNull_MustBeNull()
        {
            var attr = new MessageProcessorAttribute();

            attr.ExecuteAfter = Enumerable.Empty<IMessageProcessor>();
            attr.ExecuteAfter = null;

            Assert.Null(attr.ExecuteAfter);
        }

        [Fact]
        public void ExecuteAfter_AssignEmptyList_MustBeEmptyList()
        {
            var attr = new MessageProcessorAttribute();

            attr.ExecuteAfter = Enumerable.Empty<IMessageProcessor>();

            Assert.Empty(attr.ExecuteAfter);
        }

        [Fact]
        public void ExecuteAfter_AssignNonEmptyList_TheListMustBeExactlySame()
        {
            var attr = new MessageProcessorAttribute();
            var processors = new[] { Substitute.For<IMessageProcessor>(), Substitute.For<IMessageProcessor>() };

            attr.ExecuteAfter = processors;

            Assert.Equal(processors, attr.ExecuteAfter);
        }

        [Fact]
        public void ExecuteBefore_AssignNull_MustBeNull()
        {
            var attr = new MessageProcessorAttribute();

            attr.ExecuteBefore = Enumerable.Empty<IMessageProcessor>();
            attr.ExecuteBefore = null;

            Assert.Null(attr.ExecuteBefore);
        }

        [Fact]
        public void ExecuteBefore_AssignEmptyList_MustBeEmptyList()
        {
            var attr = new MessageProcessorAttribute();

            attr.ExecuteBefore = Enumerable.Empty<IMessageProcessor>();

            Assert.Empty(attr.ExecuteBefore);
        }

        [Fact]
        public void ExecuteBefore_AssignNonEmptyList_TheListMustBeExactlySame()
        {
            var attr = new MessageProcessorAttribute();
            var processors = new[] { Substitute.For<IMessageProcessor>(), Substitute.For<IMessageProcessor>() };

            attr.ExecuteBefore = processors;

            Assert.Equal(processors, attr.ExecuteBefore);
        }
    }
}
