using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dommunity.Module
{
    /// <summary>
    /// Module system manager.
    /// </summary>
    public interface IModuleManager
    {
        /// <summary>
        /// Load a new dommunity module.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="definition"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The specified module is already loaded.
        /// </exception>
        /// <remarks>
        /// The loaded module will be managed by this manager.
        /// </remarks>
        Task<IModule> LoadModuleAsync(ModuleDefinition definition, CancellationToken cancellationToken);
    }
}
