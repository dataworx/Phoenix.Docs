using System.Threading.Tasks;

namespace Phoenix.Docs.Domain
{
    public interface IDocsSource
    {
        public string Key { get; }
        
        Task<DocsFile?> GetFile(string filePath);
    }
}
