using Phoenix.Docs.Results;
using System.Threading.Tasks;
using Phoenix.Docs.Domain;

namespace Phoenix.Docs.AppServices;

public interface IDocsCreationService
{
    /// <summary>
    /// Creates the documentation for the project with the given shortname.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="project">
    /// The project.
    /// </param>
    /// <returns>
    /// Result containing the url for newly created documentation.
    /// </returns>
    Task<Result<string>> CreateDocs(DocsOptions options, Project project);
}