using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Phoenix.Docs.Domain;
using Serilog;
using System;
using System.IO;

namespace Phoenix.Docs.Configuration
{
    public class DocsConfigurationProvider : IDocsConfigurationProvider
    {
        #region Fields

        private readonly IMemoryCache memoryCache;
        private readonly IOptions<DocsOptions> settings;
        private readonly IWebHostEnvironment environment;
        private readonly ILogger logger = Log.ForContext<DocsConfigurationProvider>();
        private const int DEFAULT_CACHE_TIMEOUT = 5;
        private const string CACHE_KEY = "DocsOptions";

        #endregion

        #region Constructors
        
        public DocsConfigurationProvider(IMemoryCache memoryCache, IOptions<DocsOptions> settings, IWebHostEnvironment environment)
        {
            this.memoryCache = memoryCache;
            this.settings = settings;
            this.environment = environment;
        } 
        
        #endregion

        public DocsOptions Settings
        {
            get
            {
                var options = memoryCache.GetOrCreate(CACHE_KEY, entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(DEFAULT_CACHE_TIMEOUT);
                    var configuredSettings = this.settings.Value;
                    foreach (var project in configuredSettings.Projects)
                    {
                        project.PublishPath = Path.Combine(this.environment.WebRootPath,
                            configuredSettings.PublishFolder, project.ShortName);

                        project.TempPath = Path.Combine(this.environment.ContentRootPath,
                            configuredSettings.TempFolder, project.ShortName);
                    }
                    return this.settings.Value;
                });

                if (options == null)
                {
                    logger.Error("The options value is null");
                    throw new InvalidOperationException("The options value is null");
                }

                return options;
            }
        }
    }
}
