using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dommunity.Module
{
    /// <summary>
    /// Manager for <see cref="IPlugin"/>.
    /// </summary>
    public interface IPluginManager
    {
        /// <summary>
        /// Register a new plugin.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="beforePlugins"/> or <paramref name="afterPlugins"/> is <c>null</c>.
        /// </exception>
        Task RegisterPluginAsync<TPlugin, TImplementation>(
            IEnumerable<Type> beforePlugins,
            IEnumerable<Type> afterPlugins,
            CancellationToken cancellationToken) where TImplementation : TPlugin where TPlugin : IPlugin;
    }
}
