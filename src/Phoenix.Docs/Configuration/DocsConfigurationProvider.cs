using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Phoenix.Docs.Domain;
using Serilog;
using System;

namespace Phoenix.Docs.Configuration
{
    public class DocsConfigurationProvider : IDocsConfigurationProvider
    {
        #region Fields

        private readonly IMemoryCache memoryCache;
        private readonly IOptions<DocsOptions> settings;
        private readonly ILogger logger = Log.ForContext<DocsConfigurationProvider>();
        private const int DEFAULT_CACHE_TIMEOUT = 5;
        private const string CACHE_KEY = "DocsOptions";

        #endregion

        #region Constructors
        
        public DocsConfigurationProvider(IMemoryCache memoryCache, IOptions<DocsOptions> settings)
        {
            this.memoryCache = memoryCache;
            this.settings = settings;
        } 
        
        #endregion

        public DocsOptions Settings
        {
            get
            {
                var options = memoryCache.GetOrCreate(CACHE_KEY, entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(DEFAULT_CACHE_TIMEOUT);
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
