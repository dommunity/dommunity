using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Dommunity.Module;

namespace Dommunity.Node.Messaging
{
    /// <summary>
    /// A serializer for <see cref="Message"/>.
    /// </summary>
    public interface IMessageSerializer : IPlugin
    {
        /// <summary>
        /// Deserialize a <see cref="Message"/> from binary.
        /// </summary>
        /// <returns>
        /// A deserialized message or <c>null</c> if the message cannot deserialized by this serializer.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="sender"/> or <paramref name="payload"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidMessageException">
        /// <paramref name="messageSize"/> or <paramref name="payload"/> is not valid for the message.
        /// </exception>
        Task<Message> DeserializeAsync(
            IRemoteNode sender,
            Guid messageId,
            int messageSize,
            Stream payload,
            CancellationToken cancellationToken);

        /// <summary>
        /// Serialize a <see cref="Message"/> to binary.
        /// </summary>
        /// <returns>
        /// A serialized message or <c>null</c> if the message cannot serialized by this serializer.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="receiver"/> or <paramref name="message"/> is <c>null</c>.
        /// </exception>
        Task<byte[]> SerializeAsync(IRemoteNode receiver, Message message, CancellationToken cancellationToken);
    }
}
