using Microsoft.Extensions.Options;
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

    private readonly DocsConfiguration configuration;
    private readonly IDocsSourceFactory sourceFactory;

    #endregion

    #region Constructors
    
    public DocsCreationService(IOptions<DocsConfiguration> configuration, IDocsSourceFactory sourceFactory)
    {
        this.configuration = configuration.Value;
        this.sourceFactory = sourceFactory;
    } 
    
    #endregion

    public async Task<Result<string>> CreateDocs(string id)
    {
        var projectSource = this.configuration.Sources
            .SingleOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));

        if (projectSource == null)
        {
            return Result<string>.Fail(KnownErrors.Project.NotFound);
        }

        var docsSource = await sourceFactory.Create(projectSource);
        if (docsSource == null)
        {
            return Result<string>.Fail(KnownErrors.DocsSource.SourceNotFound);
        }

        // Download config file from repo
        // Enrich config with path information and store
        // Download all content files (.md) referenced in the config file navigation section
        // Parse files for linked content
        // Download linked content
        // Publish 
        return null;
    }
}