using System;
using System.Threading;
using System.Threading.Tasks;
using Dommunity.Module;

namespace Dommunity.Node.Messaging
{
    /// <summary>
    /// Processor for dommunity node's message.
    /// </summary>
    public interface IMessageProcessor : IPlugin
    {
        /// <summary>
        /// Process a message and do appropriate actions.
        /// </summary>
        /// <returns>
        /// A <see cref="Message"/> for the next processor.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="sender"/> or <paramref name="message"/> are <c>null</c>.
        /// </exception>
        Task<Message> RunAsync(IRemoteNode sender, Message message, CancellationToken cancellationToken);
    }
}
