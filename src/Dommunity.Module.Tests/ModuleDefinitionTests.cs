using System;
using NSubstitute;
using Xunit;

namespace Dommunity.Module.Tests
{
    public class ModuleDefinitionTests
    {
        [Fact]
        public void Constructor_PassNullForModule_ShouldThrow()
        {
            Assert.ThrowsAny<ArgumentNullException>(() => new ModuleDefinition(null));
        }

        [Fact]
        public void Constructor_PassInvalidModule_ShouldThrow()
        {
            Assert.ThrowsAny<ArgumentException>(() => new ModuleDefinition(typeof(object)));
        }

        [Fact]
        public void Constructor_PassValidModule_ShouldAssignToModuleProperty()
        {
            var module = Substitute.For<IModule>();
            var definition = new ModuleDefinition(module.GetType());

            Assert.Equal(module.GetType(), definition.Module);
        }
    }
}
