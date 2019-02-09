using System;
using System.Threading;
using System.Threading.Tasks;

namespace Dommunity.Module.Tests
{
    abstract class TestModule : IModule
    {
        public bool Disposed { get; private set; }

        public bool Initialized { get; protected set; }

        public void Dispose()
        {
            Disposed = true;
        }

        public virtual Task InitializeAsync(ModuleInitializationContext context, CancellationToken cancellationToken)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (Initialized)
            {
                throw new InvalidOperationException("The module is already initialized.");
            }

            Initialized = true;

            return Task.FromResult(0);
        }
    }
}
