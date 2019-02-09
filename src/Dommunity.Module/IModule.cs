using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dommunity.Module
{
    /// <summary>
    /// Represents a dommunity module.
    /// </summary>
    public interface IModule : IDisposable
    {
        /// <summary>
        /// Initializes this module.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="context"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The module is already initialized.
        /// </exception>
        Task InitializeAsync(ModuleInitializationContext context, CancellationToken cancellationToken);
    }
}
