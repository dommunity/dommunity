using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Dommunity.Node.Messaging;

namespace Dommunity.Node
{
    /// <summary>
    /// Base class for implementing <see cref="IRemoteNode"/>.
    /// </summary>
    public abstract class RemoteNode : IRemoteNode
    {
        readonly IEnumerable<IMessageSerializer> messageSerializers;
        readonly IEnumerable<IMessageProcessor> messageProcessors;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteNode"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="messageSerializers"/> or <paramref name="messageProcessors"/> is <c>null</c>.
        /// </exception>
        protected RemoteNode(
            IEnumerable<IMessageSerializer> messageSerializers,
            IEnumerable<IMessageProcessor> messageProcessors)
        {
            if (messageSerializers == null)
            {
                throw new ArgumentNullException(nameof(messageSerializers));
            }

            if (messageProcessors == null)
            {
                throw new ArgumentNullException(nameof(messageProcessors));
            }

            this.messageSerializers = messageSerializers;
            this.messageProcessors = messageProcessors;
        }

        /// <summary>
        /// Deserialize message's payload from binary.
        /// </summary>
        /// <returns>
        /// A message with deserialized payload or <c>null</c> if the message is unknown.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="payloadSize"/> is negative.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidMessageException">
        /// <paramref name="payloadSize"/> or <paramref name="payload"/> is not valid for the message.
        /// </exception>
        protected async Task<object> DeserializeMessageAsync(
            Guid messageId,
            int payloadSize,
            Stream payload,
            CancellationToken cancellationToken)
        {
            if (payloadSize < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(payloadSize));
            }

            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            foreach (var serializer in this.messageSerializers)
            {
                var message = await serializer.DeserializeAsync(this, messageId, payloadSize, payload, cancellationToken);
                if (message != null)
                {
                    return message;
                }
            }

            return null;
        }

        /// <summary>
        /// Process a message and do appropriate actions.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="message"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="message"/> is not valid for the current state.
        /// </exception>
        protected async Task ProcessMessageAsync(object message, CancellationToken cancellationToken)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            foreach (var processor in this.messageProcessors)
            {
                message = await processor.RunAsync(this, message, cancellationToken);
                if (message == null)
                {
                    break;
                }
            }
        }
    }
}
