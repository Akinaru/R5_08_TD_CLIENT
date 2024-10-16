using System.Net.Http.Json;
using TD1Client.Models;

namespace TD1Client.Services
{
    public class WSServiceProduit : IService<Produit>
    {
        private readonly HttpClient _httpClient;

        public WSServiceProduit(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Produit>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Produit>>("api/produits/automapper");
        }

        public async Task<List<Produit>> GetAllByNameAsync(string name)
        {
            return await _httpClient.GetFromJsonAsync<List<Produit>>($"api/produits/allbyname/{name}");
        }


        public async Task<Produit?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Produit?>($"api/produits/{id}");
        }

        public async Task<Produit?> GetByNameAsync(string name)
        {
            return await _httpClient.GetFromJsonAsync<Produit?>($"api/produits/getbyname/{name}");
        }

        public async Task PostAsync(Produit produit)
        {
            var response = await _httpClient.PostAsJsonAsync("api/produits", produit);
            response.EnsureSuccessStatusCode();
        }

        public async Task PutAsync(int id, Produit produit)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/produits/{id}", produit);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/produits/{id}");
            response.EnsureSuccessStatusCode();
        }

    }
}
