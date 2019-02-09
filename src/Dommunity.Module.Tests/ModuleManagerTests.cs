using System;
using System.Threading;
using System.Threading.Tasks;
using Dommunity.Testing;
using NSubstitute;
using Xunit;

namespace Dommunity.Module.Tests
{
    public class ModuleManagerTests : IDisposable
    {
        readonly IPluginManager pluginManager;
        readonly ModuleManager manager;

        public ModuleManagerTests()
        {
            this.pluginManager = Substitute.For<IPluginManager>();
            this.manager = new ModuleManager(pluginManager);
        }

        public void Dispose()
        {
            this.manager.Dispose();
        }

        [Fact]
        public void Constructor_PassNullForPluginManager_ShouldThrow()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => new ModuleManager(pluginManager: null));
        }

        [Fact]
        public void Dispose_WhenCalled_ShouldCallInternalDispose()
        {
            var manager = Substitute.ForPartsOf<ModuleManager>(this.pluginManager);

            manager.Dispose();

            manager.ReceivedDisposePattern();
        }

        [Fact]
        public async Task Dispose_WhenCalled_ShouldDisposeLoadedModules()
        {
            TestModuleA moduleA;
            TestModuleB moduleB;

            using (var manager = new ModuleManager(this.pluginManager))
            {
                moduleA = (TestModuleA)await manager.LoadModuleAsync(
                    new ModuleDefinition(typeof(TestModuleA)),
                    CancellationToken.None
                );

                moduleB = (TestModuleB)await manager.LoadModuleAsync(
                    new ModuleDefinition(typeof(TestModuleB)),
                    CancellationToken.None
                );
            }

            Assert.True(moduleA.Disposed);
            Assert.True(moduleB.Disposed);
        }

        [Fact]
        public async Task LoadModuleAsync_PassNullForDefinition_ShouldThrow()
        {
            await Assert.ThrowsAnyAsync<ArgumentNullException>(() =>
            {
                return this.manager.LoadModuleAsync(null, CancellationToken.None);
            });
        }

        [Fact]
        public async Task LoadModuleAsync_PassSameModuleMoreThanOne_ShouldThrow()
        {
            await this.manager.LoadModuleAsync(new ModuleDefinition(typeof(TestModuleA)), CancellationToken.None);

            await Assert.ThrowsAnyAsync<InvalidOperationException>(() =>
            {
                return this.manager.LoadModuleAsync(new ModuleDefinition(typeof(TestModuleA)), CancellationToken.None);
            });
        }

        [Fact]
        public async Task LoadModuleAsync_PassValidModule_ShouldReturnThatModuleInstance()
        {
            var module = await this.manager.LoadModuleAsync(
                new ModuleDefinition(typeof(TestModuleA)),
                CancellationToken.None
            );

            Assert.IsType<TestModuleA>(module);
        }

        [Fact]
        public async Task LoadModuleAsync_PassValidModule_ShouldInitializeThatModule()
        {
            var module = (TestModuleA)await this.manager.LoadModuleAsync(
                new ModuleDefinition(typeof(TestModuleA)),
                CancellationToken.None
            );

            Assert.True(module.Initialized);
        }
    }
}
