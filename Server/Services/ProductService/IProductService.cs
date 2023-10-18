namespace VelioApp.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetProductsAsync();

        Task<ServiceResponse<Product>> GetProductAsync(int id);

        Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl);

        Task<ServiceResponse<Product>> CreateProductAsync(Product product);
    }
}
