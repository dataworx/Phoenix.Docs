using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Docs.Domain;

namespace Phoenix.Docs.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPhoenixDocs(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DocsOptions>(configuration.GetSection(DocsOptions.CONFIG_KEY));
            return services;
        }
    }
}
