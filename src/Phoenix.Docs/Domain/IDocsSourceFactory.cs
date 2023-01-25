namespace Phoenix.Docs.Domain
{
    public interface IDocsSourceFactory
    {
        IDocsSource? Create(string sourceKey);
    }
}
