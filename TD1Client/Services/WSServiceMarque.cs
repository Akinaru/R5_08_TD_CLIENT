using System.Net.Http.Json;
using TD1Client.Models;

namespace TD1Client.Services
{
    public class WSServiceMarque : IService<Marque>
    {
        private readonly HttpClient _httpClient;

        public WSServiceMarque(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Marque>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Marque>>("api/marques");
        }

        public async Task<Marque?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Marque?>($"api/Marques/{id}");
        }

        public async Task PostAsync(Marque Marque)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Marques", Marque);
            response.EnsureSuccessStatusCode();
        }

        public async Task PutAsync(int id, Marque Marque)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Marques/{id}", Marque);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Marques/{id}");
            response.EnsureSuccessStatusCode();
        }

        public Task<List<Marque>> GetAllByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
