using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

namespace Dommunity.Module
{
    /// <summary>
    /// Default implementation for <see cref="IModuleManager"/>.
    /// </summary>
    public class ModuleManager : IModuleManager
    {
        readonly IPluginManager pluginManager;
        readonly HashSet<Type> loaded;
        readonly Collection<IModule> modules;
        bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleManager"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="pluginManager"/> is <c>null</c>.
        /// </exception>
        public ModuleManager(IPluginManager pluginManager)
        {
            if (pluginManager == null)
            {
                throw new ArgumentNullException(nameof(pluginManager));
            }

            this.pluginManager = pluginManager;
            this.loaded = new HashSet<Type>();
            this.modules = new Collection<IModule>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IModule> LoadModuleAsync(ModuleDefinition definition, CancellationToken cancellationToken)
        {
            if (definition == null)
            {
                throw new ArgumentNullException(nameof(definition));
            }

            if (this.loaded.Contains(definition.Module))
            {
                throw new InvalidOperationException($"Module {definition.Module} is already loaded.");
            }

            // Activate module.
            var module = (IModule)Activator.CreateInstance(definition.Module);

            // Initialize module.
            var context = new ModuleInitializationContext(this.pluginManager);

            await module.InitializeAsync(context, cancellationToken);

            this.modules.Add(module);
            this.loaded.Add(definition.Module);

            return module;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                foreach (var module in this.modules)
                {
                    module.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
