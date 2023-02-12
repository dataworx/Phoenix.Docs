namespace Phoenix.Docs.Configuration
{
    public interface IConfigurationSerializer
    {
        T Deserialize<T>(string content);
    }
}