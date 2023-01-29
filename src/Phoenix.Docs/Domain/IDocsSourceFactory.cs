using System.Threading.Tasks;

namespace Phoenix.Docs.Domain
{
    public interface IDocsSourceFactory
    {
        Task<IDocsSource?> Create(ProjectSourceConfiguration sourceConfiguration);
    }
}
