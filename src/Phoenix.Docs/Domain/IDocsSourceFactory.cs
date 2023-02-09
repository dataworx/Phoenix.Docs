using System.Threading.Tasks;
using Phoenix.Docs.Configuration;

namespace Phoenix.Docs.Domain
{
    public interface IDocsSourceFactory
    {
        Task<IDocsSource?> Create(Documentation sourceConfiguration);
    }
}
