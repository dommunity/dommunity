using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dommunity.Module
{
    /// <summary>
    /// Represents a dommunity module.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Register all plugins for this module.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="manager"/> is <c>null</c>.
        /// </exception>
        Task RegisterPluginsAsync(IPluginManager manager, CancellationToken cancellationToken);
    }
}
