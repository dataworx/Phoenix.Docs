using System.Threading.Tasks;
using Phoenix.Docs.Configuration;

namespace Phoenix.Docs.DocsSources
{
    public interface IDocsSource
    {
        Task Configure(Documentation sourceConfiguration);

        Task<DocsFile?> GetFile(string filePath);
    }
}
