using Dommunity.Blockchain;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for setting up Dommunity blockchain services in an <see cref="IServiceCollection"/>.
    /// </summary>
    public static class DommunityBlockchainServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Dommunity blockchain services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        public static void AddDommunityBlockchain(this IServiceCollection services)
        {
            services.AddSingleton<IBlockchain, Blockchain>();
        }
    }
}
