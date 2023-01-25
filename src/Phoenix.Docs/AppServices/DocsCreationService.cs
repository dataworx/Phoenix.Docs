using Phoenix.Docs.Configuration;
using Phoenix.Docs.Errors;
using Phoenix.Docs.Results;
using System;
using System.Linq;
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
        var project = this.configProvider.Settings.Projects
            .SingleOrDefault(x => x.ShortName.Equals(projectShortName, StringComparison.InvariantCultureIgnoreCase));

        if (project == null)
        {
            return Task.FromResult(Result<string>.Fail(KnownErrors.Project.NotFound));
        }

        return null;
    }
}