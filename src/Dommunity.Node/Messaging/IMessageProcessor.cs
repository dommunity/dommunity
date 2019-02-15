using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dommunity.Node.Messaging
{
    /// <summary>
    /// Processor for dommunity node's message.
    /// </summary>
    public interface IMessageProcessor
    {
        /// <summary>
        /// Process a message and do appropriate actions.
        /// </summary>
        /// <returns>
        /// A message for the next processor or <c>null</c> to stop processing and move to next message.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="sender"/> or <paramref name="message"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="message"/> is not valid for the current state.
        /// </exception>
        Task<object> RunAsync(IRemoteNode sender, object message, CancellationToken cancellationToken);
    }
}
