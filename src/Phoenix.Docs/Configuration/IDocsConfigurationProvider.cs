using Phoenix.Docs.Domain;

namespace Phoenix.Docs.Configuration;

public interface IDocsConfigurationProvider
{
    DocsOptions Settings { get; }
}