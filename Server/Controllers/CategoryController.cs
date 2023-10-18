using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VelioApp.Server.Data;
using VelioApp.Server.Services.CategoryService;

namespace VelioApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService productService)
        {
            _categoryService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetProducts()
        {
            var result = await _categoryService.GetCategoriesAsync();
            return Ok(result);
        }
    }
}
