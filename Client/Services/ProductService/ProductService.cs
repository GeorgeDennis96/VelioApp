using System.Net.Http.Json;
using VelioApp.Shared;

namespace VelioApp.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient http)
        {
            _httpClient = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public event Action ProductsChanged;

        public async Task<ServiceResponse<Product>> GetProduct(int id)
        {
            // Data is already wrapped in the service response so returning null is fine here because we are using ServiceResponse.Message
            var result = await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{id}");
            return result;

        }

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/product") : 
                await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
            if (result is not null && result.Data is not null)
                Products = result.Data;

            ProductsChanged.Invoke();
        }
    }
}
