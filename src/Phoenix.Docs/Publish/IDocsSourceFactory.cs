using Phoenix.Docs.Configuration;
using Phoenix.Docs.Domain;
using System.Threading.Tasks;

namespace Phoenix.Docs.Publish
{
    public interface IDocsSourceFactory
    {
        Task<IDocsSource?> Create(Documentation documentation);
    }
}