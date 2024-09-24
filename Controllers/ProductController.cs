using Application.Domain.RequestViewModel;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerProductOrder.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<ProductViewModel>>> GetAllProducts()
        {
            try
            {
                return Ok(await _productService.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error has ocurred while trying to get list of all products: ErrorMessage: {ex.InnerException}, StackTrace: {ex.StackTrace}", ex);
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<int>> AddProduct([FromBody] ProductViewModel product)
        {
            try
            {
                return Ok(await _productService.AddProduct(product));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error has ocurred while trying to add a new product: ErrorMessage: {ex.InnerException}, StackTrace: {ex.StackTrace}", ex);
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<int>> UpdateAProduct([FromBody] ProductViewModel product)
        {
            try
            {
                return Ok(await _productService.UpdateProduct(product));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error has ocurred while trying to update a product: ErrorMessage: {ex.InnerException}, StackTrace: {ex.StackTrace}", ex);
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
