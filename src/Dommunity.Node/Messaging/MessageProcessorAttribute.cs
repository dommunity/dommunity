using System;
using System.Collections.Generic;

namespace Dommunity.Node.Messaging
{
    /// <summary>
    /// Indicated the specified class is a processor for dommunity node's message.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class MessageProcessorAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageProcessorAttribute"/> class.
        /// </summary>
        public MessageProcessorAttribute()
        {
        }

        /// <summary>
        /// Gets or sets a list of <see cref="IMessageProcessor"/> to execute this processor after those processors.
        /// </summary>
        public IEnumerable<IMessageProcessor> ExecuteAfter { get; set; }

        /// <summary>
        /// Gets or sets a list of <see cref="IMessageProcessor"/> to execute this processor before those processors.
        /// </summary>
        public IEnumerable<IMessageProcessor> ExecuteBefore { get; set; }
    }
}
