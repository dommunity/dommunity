using System;
using NSubstitute;
using Xunit;

namespace Dommunity.Module.Tests
{
    public class ModuleInitializationContextTests
    {
        [Fact]
        public void Constructor_PassNullForPluginManager_ShouldThrow()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => new ModuleInitializationContext(pluginManager: null));
        }

        [Fact]
        public void Constructor_PassValidPluginManager_PluginManagerPropertyShouldReturnThat()
        {
            var pluginManager = Substitute.For<IPluginManager>();
            var context = new ModuleInitializationContext(pluginManager);

            Assert.Same(pluginManager, context.PluginManager);
        }
    }
}
