using System.Text.Json.Serialization;

namespace Core.API.Converters
{
    /// <inheritdoc />
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]

    [JsonSerializable(typeof(CreateDashboardRequest))]
    [JsonSerializable(typeof(CreateDashboardResponse))]
    [JsonSerializable(typeof(UpdateDashboardRequest))]
    [JsonSerializable(typeof(UpdateDashboardResponse))]
    public partial class ClientSourceGenerationContext : JsonSerializerContext
    {
    }
}
