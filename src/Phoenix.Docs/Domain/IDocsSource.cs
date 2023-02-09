using System.Threading.Tasks;
using Phoenix.Docs.Configuration;

namespace Phoenix.Docs.Domain
{
    public interface IDocsSource
    {
        Task Configure(Documentation sourceConfiguration);

        Task<DocsFile?> GetFile(string filePath);
    }
}
