using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Labb1_webAPI.Models
{
    //Anser inte att annotations egentligen behövs men lägger till de för tydlighetens skull.
    public class Pokemon
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("abilities")]
        public List<string> Abilities { get; set; } = new List<string>();

        [JsonPropertyName("forms")]
        public List<string> Forms { get; set; } = new List<string>();
    }
}
