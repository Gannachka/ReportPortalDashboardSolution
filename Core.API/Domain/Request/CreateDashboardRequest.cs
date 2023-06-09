﻿using System.Text.Json.Serialization;

namespace Core.API
{
    public class CreateDashboardRequest
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        //[JsonPropertyName("share")]
        //public bool Share { get; set; }
    }
}
