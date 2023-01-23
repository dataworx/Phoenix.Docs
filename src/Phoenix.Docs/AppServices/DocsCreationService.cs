using Phoenix.Docs.Configuration;
using Phoenix.Docs.Results;
using System.Threading.Tasks;

namespace Phoenix.Docs.AppServices;

public class DocsCreationService : IDocsCreationService
{
    #region Fields

    private readonly IDocsConfigurationProvider configProvider;

    #endregion

    #region Constructors
    
    public DocsCreationService(IDocsConfigurationProvider configProvider)
    {
        this.configProvider = configProvider;
    } 
    
    #endregion

    public Task<Result<string>> CreateDocs(string projectShortName)
    {
        throw new System.NotImplementedException();
    }
}