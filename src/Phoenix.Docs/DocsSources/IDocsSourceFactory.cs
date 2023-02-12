using Phoenix.Docs.Configuration;
using System.Threading.Tasks;

namespace Phoenix.Docs.DocsSources
{
    public interface IDocsSourceFactory
    {
        Task<IDocsSource?> Create(Documentation documentation);
    }
}