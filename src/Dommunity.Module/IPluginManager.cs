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
        /// Gets a list of all active specified plugins.
        /// </summary>
        IEnumerable<T> GetPlugins<T>() where T : IPlugin;

        /// <summary>
        /// Register a new plugin.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="plugin"/>, <paramref name="beforePlugins"/> or <paramref name="afterPlugins"/>
        /// is <c>null</c>.
        /// </exception>
        Task RegisterPluginAsync(
            IPlugin plugin,
            IEnumerable<Type> beforePlugins,
            IEnumerable<Type> afterPlugins,
            CancellationToken cancellationToken);
    }
}
