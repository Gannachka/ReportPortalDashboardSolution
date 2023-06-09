using System.Text.Json.Serialization;

namespace Core.API
{
    public class UpdateDashboardRequest
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("share")]
        public bool Share { get; set; }

        [JsonPropertyName("updateWidgets")]
        public IList<WidgetModel> UpdateWidgets { get; set; }
    }
}
