using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Docs.Publish;
using Phoenix.Docs.Sources;
using Phoenix.Docs.Store;

namespace Phoenix.Docs.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPhoenixDocs(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DocsConfiguration>(configuration.GetSection(DocsConfiguration.CONFIG_KEY));
            services.AddScoped<IPublisher, Publisher>();
            services.AddSingleton<IDocsSourceFactory, DocsSourceFactory>();
            services.AddScoped<IDocsStore, DocsStore>();
            services.AddSingleton<IConfigurationSerializer, JsonConfigurationSerializer>();

            return services;
        }
    }
}
