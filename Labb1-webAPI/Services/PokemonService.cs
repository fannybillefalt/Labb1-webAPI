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
            try
            {
                var response = await _httpClient.GetAsync("pokemon");

                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var data = JsonSerializer.Deserialize<PokemonApiResponse>(json);

                return data.Results;
            }
            catch (Exception)
            {
                return new List<Pokemon>();
            }
        }
    }

    internal class PokemonApiResponse
    {
        [System.Text.Json.Serialization.JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; } = new();
    }

}

