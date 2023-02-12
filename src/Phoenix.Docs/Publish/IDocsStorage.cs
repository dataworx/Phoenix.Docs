using Phoenix.Docs.Configuration;
using System.Threading.Tasks;

namespace Phoenix.Docs.Publish
{
    public interface IDocsStorage
    {
        Task Publish(Documentation documentation, object projectConfiguration);

        Task SaveTempFile(Documentation documentation, object projectConfiguration, DocsFile? configurationFile);
    }
}
