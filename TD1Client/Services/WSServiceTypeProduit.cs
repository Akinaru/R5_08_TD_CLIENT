using System.Net.Http.Json;
using TD1Client.Models;

namespace TD1Client.Services
{
    public class WSServiceTypeProduit : IService<TypeProduit>
    {
        private readonly HttpClient _httpClient;

        public WSServiceTypeProduit(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TypeProduit>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TypeProduit>>("api/TypeProduits");
        }

        public async Task<TypeProduit?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TypeProduit?>($"api/TypeProduits/{id}");
        }

        public async Task PostAsync(TypeProduit produit)
        {
            var response = await _httpClient.PostAsJsonAsync("api/TypeProduits", produit);
            response.EnsureSuccessStatusCode();
        }

        public async Task PutAsync(int id, TypeProduit produit)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/TypeProduits/{id}", produit);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/TypeProduits/{id}");
            response.EnsureSuccessStatusCode();
        }

        public Task<List<TypeProduit>> GetAllByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
