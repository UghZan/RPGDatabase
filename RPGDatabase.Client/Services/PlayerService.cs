using RPGDatabase.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RPGDatabase.Client.Services
{
    public class PlayerService : IPlayerService
    {
        HttpClient httpClient;

        public PlayerService(HttpClient _httpClient) => httpClient = _httpClient;
        public async Task<DTOPlayer> CreateEntity(DTOPlayerCreate entity)
        {
            var jsonString = JsonSerializer.Serialize(entity);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync("https://localhost:44323/api/player/", httpContent);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DTOPlayer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<DTOPlayer>> GetEntities()
        {
            var content = await GetContent("https://localhost:44323/api/player/");

            return JsonSerializer.Deserialize<IEnumerable<DTOPlayer>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<DTOPlayer> GetEntity(int id)
        {
            var content = await GetContent("https://localhost:44323/api/player/" + id);

            return JsonSerializer.Deserialize<DTOPlayer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<DTOPlayer> UpdateEntity(DTOPlayer update)
        {
            var jsonString = JsonSerializer.Serialize(update);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using var response = await httpClient.PatchAsync("https://localhost:44323/api/player/", httpContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DTOPlayer>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private async Task<string> GetContent(string Url)
        {
            using var response = await httpClient.GetAsync(Url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
