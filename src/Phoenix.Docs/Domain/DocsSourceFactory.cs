using Phoenix.Docs.Configuration;
using Phoenix.Docs.Infrastructure;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phoenix.Docs.Domain;

public class DocsSourceFactory : IDocsSourceFactory
{
    #region Fields

    private readonly ILogger logger = Log.ForContext<DocsSourceFactory>();

    #endregion

    public static Dictionary<string, Func<IDocsSource>> Sources = new Dictionary<string, Func<IDocsSource>>()
    {
        { "github", () => new GithubDocsSource() }
    };

    public async Task<IDocsSource?> Create(Documentation sourceConfig)
    {
        if (Sources.ContainsKey(sourceConfig.SourceType))
        {
            var source = Sources[sourceConfig.SourceType]();
            await source.Configure(sourceConfig);

            return source;
        }

        this.logger.Fatal("");

        return null;
    }
}