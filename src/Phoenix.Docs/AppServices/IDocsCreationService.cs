using Phoenix.Docs.Results;
using System.Threading.Tasks;

namespace Phoenix.Docs.AppServices;

public interface IDocsCreationService
{
    /// <summary>
    /// Creates the documentation for the project with the given shortname.
    /// </summary>
    /// <param name="project">
    /// The project.
    /// </param>
    /// <returns>
    /// Result containing the url for newly created documentation.
    /// </returns>
    Task<Result<string>> CreateDocs(string project);
}