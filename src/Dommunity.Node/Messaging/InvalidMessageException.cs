using System;

namespace Dommunity.Node.Messaging
{
    /// <summary>
    /// The exception that is thrown when a message is not valid.
    /// </summary>
    public class InvalidMessageException : Exception
    {
        public InvalidMessageException()
        {
        }

        public InvalidMessageException(string message) : base(message)
        {
        }

        public InvalidMessageException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
