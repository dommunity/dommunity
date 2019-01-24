using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Dommunity.Module;

namespace Dommunity.Node.Messaging
{
    /// <summary>
    /// A serializer for dommunity node's message.
    /// </summary>
    public interface IMessageSerializer : IPlugin
    {
        /// <summary>
        /// Deserialize message's payload from binary.
        /// </summary>
        /// <returns>
        /// A message with deserialized payload or <c>null</c> if the message cannot deserialized by this serializer.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="sender"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="payloadSize"/> is negative.
        /// </exception>
        /// <exception cref="InvalidMessageException">
        /// <paramref name="payloadSize"/> or <paramref name="payload"/> is not valid for the message.
        /// </exception>
        Task<object> DeserializeAsync(
            IRemoteNode sender,
            Guid messageId,
            int payloadSize,
            Stream payload,
            CancellationToken cancellationToken);

        /// <summary>
        /// Serialize message's payload to binary.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the payload has been serialized; otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="receiver"/>, <paramref name="message"/> or <paramref name="start"/> is <c>null</c>.
        /// </exception>
        Task<bool> SerializeAsync(
            IRemoteNode receiver,
            object message,
            StartSerializeAsync start,
            CancellationToken cancellationToken);
    }
}
