using System;

namespace Dommunity.Node.Messaging
{
    /// <summary>
    /// Represents a message for exchange data between dommunity nodes.
    /// </summary>
    public abstract class Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        public Message(Guid id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets the unique identifier of the message.
        /// </summary>
        public Guid Id { get; }
    }
}
