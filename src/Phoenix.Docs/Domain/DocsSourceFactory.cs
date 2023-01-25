using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Docs.Domain;

public class DocsSourceFactory : IDocsSourceFactory
{
    #region Fields

    private readonly IEnumerable<IDocsSource> sources;
    private readonly ILogger logger = Log.ForContext<DocsSourceFactory>();

    #endregion

    #region Constructors

    public DocsSourceFactory(IEnumerable<IDocsSource> sources)
    {
        this.sources = sources;
    } 
    
    #endregion

    public IDocsSource? Get(string sourceKey)
    {
        var source = sources.SingleOrDefault(x => x.Key.Equals(sourceKey, StringComparison.InvariantCultureIgnoreCase));
        return source;
    }
}