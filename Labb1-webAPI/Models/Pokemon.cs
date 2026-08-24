using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Labb1_MVC.Models
{
    //Anser inte att annotations egentligen behövs men lägger till de för tydlighetens skull.

    public class Pokemon
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
    }

}

