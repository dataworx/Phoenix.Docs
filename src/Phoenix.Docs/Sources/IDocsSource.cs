using System.Threading.Tasks;
using Phoenix.Docs.Configuration;

namespace Phoenix.Docs.Sources
{
    public interface IDocsSource
    {
        Task Configure(DocsSourceConfiguration sourceConfiguration);

        Task<DocsFile?> GetFile(string filePath);
    }
}
