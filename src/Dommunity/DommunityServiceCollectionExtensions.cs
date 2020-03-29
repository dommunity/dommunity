namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for setting up Dommunity services in an <see cref="IServiceCollection"/>.
    /// </summary>
    public static class DommunityServiceCollectionExtensions
    {
        /// <summary>
        /// Adds Dommunity services to the specified <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">
        /// The <see cref="IServiceCollection"/> to add services to.
        /// </param>
        public static void AddDommunity(this IServiceCollection services)
        {
            services.AddDommunityIdentity();
        }
    }
}
