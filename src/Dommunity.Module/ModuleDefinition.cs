using System;

namespace Dommunity.Module
{
    /// <summary>
    /// Definition for a module.
    /// </summary>
    public sealed class ModuleDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleDefinition"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="module"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="module"/> is not implemented <see cref="IModule"/>.
        /// </exception>
        public ModuleDefinition(Type module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }

            if (!typeof(IModule).IsAssignableFrom(module))
            {
                throw new ArgumentException(
                    $"The type {module.GetType()} is not implemented {typeof(IModule)}.",
                    nameof(module)
                );
            }

            Module = module;
        }

        /// <summary>
        /// Gets a <see cref="Type"/> that implemented <see cref="IModule"/>.
        /// </summary>
        public Type Module { get; }
    }
}
