using System.Threading.Tasks;

namespace Phoenix.Docs.Publish;

public interface IPublisher
{
    /// <summary>
    /// Creates the documentation for the project with the given shortname.
    /// </summary>
    /// <param name="projectShortName"></param>
    /// <returns>
    /// Result containing the url for newly created documentation.
    /// </returns>
    Task<Result> Publish(string? projectShortName = null);
}