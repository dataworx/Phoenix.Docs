using System.Threading.Tasks;
using Phoenix.Docs.Configuration;

namespace Phoenix.Docs.Store;

public class DocsStore : IDocsStore
{
    public Task Publish(DocsSourceConfiguration docsSourceConfiguration, object projectConfiguration)
    {
        throw new System.NotImplementedException();
    }

    public Task SaveTempFile(DocsSourceConfiguration docsSourceConfiguration, object projectConfiguration,
        DocsFile? configurationFile)
    {
        throw new System.NotImplementedException();
    }
}