using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Dommunity.Node.Messaging;

namespace Dommunity.Node.Tests
{
    class TestRemoteNode : RemoteNode
    {
        public TestRemoteNode(
            IEnumerable<IMessageSerializer> messageSerializers,
            IEnumerable<IMessageProcessor> messageProcessors) : base(messageSerializers, messageProcessors)
        {
        }

        public new Task<object> DeserializeMessageAsync(
            Guid messageId,
            int payloadSize,
            Stream payload,
            CancellationToken cancellationToken)
        {
            return base.DeserializeMessageAsync(messageId, payloadSize, payload, cancellationToken);
        }

        public new Task ProcessMessageAsync(object message, CancellationToken cancellationToken)
        {
            return base.ProcessMessageAsync(message, cancellationToken);
        }
    }
}
