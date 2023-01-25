namespace Phoenix.Docs.Domain
{
    public interface IDocsSourceFactory
    {
        IDocsSource? Get(string sourceKey);
    }
}
