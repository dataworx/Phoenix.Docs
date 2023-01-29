using Phoenix.Docs.Errors;
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

    public static Dictionary<string, Func<IDocsSource>> Sources = new Dictionary<string, Func<IDocsSource>>();

    public async Task<IDocsSource?> Create(ProjectSourceConfiguration sourceConfig)
    {
        if (Sources.ContainsKey(sourceConfig.SourceType))
        {
            var source = Sources[sourceConfig.SourceType]();
            await source.Configure(sourceConfig);

            return source;
        }

        this.logger.Fatal(KnownErrors.DocsSource.SourceNotFound.ErrorMessage);

        return null;
    }
}