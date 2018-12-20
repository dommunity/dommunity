using System.Collections.Generic;

namespace Dommunity.Node
{
    /// <summary>
    /// Represent a dommunity node.
    /// </summary>
    public sealed class Node : INode
    {
        /// <summary>
        /// List of seed nodes DNS.
        /// </summary>
        public static readonly IEnumerable<string> SeedNodes = new string[]
        {
            "127.0.0.1"
        };
    }
}
