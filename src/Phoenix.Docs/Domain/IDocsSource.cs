using System.Threading.Tasks;

namespace Phoenix.Docs.Domain
{
    public interface IDocsSource
    {
        Task Configure(ProjectSourceConfiguration sourceConfiguration);

        Task<DocsFile?> GetFile(string filePath);
    }
}
