using System;

namespace Dommunity.Module
{
    /// <summary>
    /// A context for initialize <see cref="IModule"/>.
    /// </summary>
    public sealed class ModuleInitializationContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleInitializationContext"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="pluginManager"/> is <c>null</c>.
        /// </exception>
        public ModuleInitializationContext(IPluginManager pluginManager)
        {
            if (pluginManager == null)
            {
                throw new ArgumentNullException(nameof(pluginManager));
            }

            PluginManager = pluginManager;
        }

        /// <summary>
        /// Gets a <see cref="IPluginManager"/> for managing plugins for the module.
        /// </summary>
        public IPluginManager PluginManager { get; }
    }
}
