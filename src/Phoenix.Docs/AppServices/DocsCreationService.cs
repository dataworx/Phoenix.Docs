using Phoenix.Docs.Configuration;
using Phoenix.Docs.Domain;
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
    private readonly IDocsSourceFactory sourceFactory;

    #endregion

    #region Constructors
    
    public DocsCreationService(IDocsConfigurationProvider configProvider, IDocsSourceFactory sourceFactory)
    {
        this.configProvider = configProvider;
        this.sourceFactory = sourceFactory;
    } 
    
    #endregion

    public async Task<Result<string>> CreateDocs(string projectShortName)
    {
        var project = this.configProvider.Settings.Projects
            .SingleOrDefault(x => x.ShortName.Equals(projectShortName, StringComparison.InvariantCultureIgnoreCase));

        if (project == null)
        {
            return Result<string>.Fail(KnownErrors.Project.NotFound);
        }

        var docsSource = sourceFactory.Get(project.DocsSource);
        if (docsSource == null)
        {
            return Result<string>.Fail(KnownErrors.DocsSource.SourceNotFound);
        }

        var navDoc = await docsSource.GetFile(project.NavigationDocument);
        return null;
    }
}