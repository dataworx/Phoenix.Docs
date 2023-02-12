using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phoenix.Docs.DocsSources;
using Phoenix.Docs.Publish;

namespace Phoenix.Docs.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPhoenixDocs(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DocsConfiguration>(configuration.GetSection(DocsConfiguration.CONFIG_KEY));
            services.AddScoped<IPublisher, Publisher>();
            services.AddSingleton<IDocsSourceFactory, DocsSourceFactory>();

            return services;
        }
    }
}
