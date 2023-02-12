using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Phoenix.Docs.Configuration
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder UsePhoenixDocs(this IEndpointRouteBuilder endpoints)
        {
            var options = endpoints.ServiceProvider.GetService<IOptions<DocsConfiguration>>();
            if (options == null)
            {
                return endpoints;
            }

            endpoints.MapControllerRoute(
                name: "Phoenix.Docs.Route",
                pattern: $"{options.Value.UrlBasePath}/{{projectShortName}}/{{*filePath}}",
                new
                {
                    controller = "Docs",
                    action = "Index"
                });
            return endpoints;
        }
    }
}
