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
    public class ItemService : IItemService
    {
        HttpClient httpClient;

        public ItemService(HttpClient _httpClient) => httpClient = _httpClient;
        public async Task<DTOItem> CreateEntity(DTOItemCreate entity)
        {
            var jsonString = JsonSerializer.Serialize(entity);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using var response = await httpClient.PutAsync("https://localhost:44323/api/item/", httpContent);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DTOItem>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<IEnumerable<DTOItem>> GetEntities()
        {
            var content = await GetContent("https://localhost:44323/api/item/");

            return JsonSerializer.Deserialize<IEnumerable<DTOItem>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<DTOItem> GetEntity(int id)
        {
            var content = await GetContent("https://localhost:44323/api/item/" + id);

            return JsonSerializer.Deserialize<DTOItem>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<DTOItem> UpdateEntity(DTOItem update)
        {
            var jsonString = JsonSerializer.Serialize(update);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            using var response = await httpClient.PatchAsync("https://localhost:44323/api/item/", httpContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DTOItem>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        private async Task<string> GetContent(string Url)
        {
            using var response = await httpClient.GetAsync(Url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
