using Phoenix.Docs.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phoenix.Docs.Sources;

public class DocsSourceFactory : IDocsSourceFactory
{
    public static void RegisterDocsSource (string identifier, Func<IDocsSource> factory)
    {
        Sources.Add (identifier, factory);
    }

    public static Dictionary<string, Func<IDocsSource>> Sources = new Dictionary<string, Func<IDocsSource>>()
    {
        { "github", () => new GithubDocsSource() }
    };

    public async Task<IDocsSource?> Create(Documentation documentation)
    {
        if (Sources.ContainsKey(documentation.SourceType))
        {
            var source = Sources[documentation.SourceType]();
            await source.Configure(documentation);

            return source;
        }

        return null;
    }
}