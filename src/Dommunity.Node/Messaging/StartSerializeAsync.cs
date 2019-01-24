using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Dommunity.Node.Messaging
{
    /// <summary>
    /// References a method to be called when a message serialization need to be start.
    /// </summary>
    /// <returns>
    /// <see cref="Stream"/> to write message payload.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="payloadSize"/> is negative.
    /// </exception>
    public delegate Task<Stream> StartSerializeAsync(
        Guid messageId,
        int payloadSize,
        CancellationToken cancellationToken);
}
