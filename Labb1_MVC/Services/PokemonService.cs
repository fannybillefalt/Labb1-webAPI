using Labb1_MVC.Models;
using System.Text.Json;

namespace Labb1_MVC.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("pokemon");
            response.EnsureSuccessStatusCode(); // kastar HttpRequestException om t.ex. 500/timeout

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<PokemonApiResponse>(json);

            return data?.Results ?? new List<Pokemon>();
        }

        public async Task<Pokemon?> GetByNameAsync(string name)
        {
            var response = await _httpClient.GetAsync($"pokemon/{name}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null; // giltigt "hittades inte" - inte ett tekniskt fel
            }

            response.EnsureSuccessStatusCode(); // andra fel (500, timeout etc) kastas som HttpRequestException

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Pokemon>(json);
        }
    }

    internal class PokemonApiResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; } = new();
    }

}

