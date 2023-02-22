using Phoenix.Docs.Configuration;
using System.Threading.Tasks;

namespace Phoenix.Docs.Store
{
    public interface IDocsStore
    {
        Task Publish(DocsSourceConfiguration docsSourceConfiguration, object projectConfiguration);

        Task SaveTempFile(DocsSourceConfiguration docsSourceConfiguration, object projectConfiguration, DocsFile? configurationFile);
    }
}
