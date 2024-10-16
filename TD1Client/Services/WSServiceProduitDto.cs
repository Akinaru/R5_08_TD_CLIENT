using System.Net.Http.Json;
using TD1Client.Models;
using TD1Client.Models.DTO;

namespace TD1Client.Services
{
    public class WSServiceProduitDto : IService<ProduitDto>
    {
        private readonly HttpClient _httpClient;

        public WSServiceProduitDto(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProduitDto>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProduitDto>>("api/produits/automapper");
        }

        public async Task<List<ProduitDto>> GetAllByNameAsync(string name)
        {
            return await _httpClient.GetFromJsonAsync<List<ProduitDto>>($"api/produits/allbyname/{name}");
        }


        public async Task<ProduitDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProduitDto?>($"api/produits/{id}");
        }

        public async Task PostAsync(ProduitDto produit)
        {
            var response = await _httpClient.PostAsJsonAsync("api/produits", produit);
            response.EnsureSuccessStatusCode();
        }

        public async Task PutAsync(int id, ProduitDto produit)
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
