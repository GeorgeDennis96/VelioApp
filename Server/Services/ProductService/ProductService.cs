
using Microsoft.Identity.Client;
using System.Reflection.Metadata.Ecma335;
using VelioApp.Server.Data;

namespace VelioApp.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Product>> CreateProductAsync(Product product)
        {
            var response = new ServiceResponse<Product>();
            if (product != null)
            {
                product.Id = 0;

                var result = await _context.Products.AddAsync(product);

                await _context.SaveChangesAsync();

                if (result is null)
                {
                    response.Success = false;
                    response.Message = "Product was not added to the database.";
                    return response;
                }

                return response = new ServiceResponse<Product>
                {
                    Data = result.Entity,
                    Message = "Product was added."
                };
            }
            else
            {
                response.Success = false;
                response.Message = "Invalid Product.";
                return response;
            }
        }

        public async Task<ServiceResponse<Product>> GetProductAsync(int id)
        {
            var response = new ServiceResponse<Product>();

            var product = await _context.Products.FindAsync(id);

            if (product is null)
            {
                response.Success = false;
                response.Message = "This product does not exist.";
            }
            else
            {
                response.Data = product;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        {
            var response = new ServiceResponse<List<Product>>()
            {
                Data = await _context.Products.ToListAsync()
            };
            return response;
        }

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategoryAsync(string categoryUrl)
        {
            var response = new ServiceResponse<List<Product>> { Data = await _context.Products
                .Where(p => p.Category.Url.ToLower()
                .Equals(categoryUrl.ToLower()))
                .ToListAsync() 
            };

            return response;
        }
    }
}
