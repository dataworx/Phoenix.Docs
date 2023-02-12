using System.Text.Json;

namespace Phoenix.Docs.Configuration
{
    public class JsonConfigurationSerializer : IConfigurationSerializer
    {
        private readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public T Deserialize<T>(string content)
        {
            return JsonSerializer.Deserialize<T>(content, options);
        }

    }
}