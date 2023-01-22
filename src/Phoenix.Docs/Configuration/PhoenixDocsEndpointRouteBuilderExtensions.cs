using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Phoenix.Docs.Domain;
using Serilog;

namespace Phoenix.Docs.Configuration
{
    public static class PhoenixDocsEndpointRouteBuilderExtensions
    {
        private static readonly ILogger Logger = Log.ForContext(typeof(PhoenixDocsEndpointRouteBuilderExtensions));
        
        public static IEndpointRouteBuilder MapPhoenixDocsControllers(this IEndpointRouteBuilder endpoints)
        {
            var options = endpoints.ServiceProvider.GetService<IOptions<DocsOptions>>();
            if (options == null)
            {
                Logger.Fatal("");
                return endpoints;
            }

            endpoints.MapControllerRoute(
                name: "Phoenix.Docs.Route",
                pattern: $"{options.Value.UrlBasePath}/{{projectShortName}}/{{*filePath}}",
                new
                {
                    controller = "PhoenixDocs",
                    action = "Index"
                });
            return endpoints;


        }
    }
}
