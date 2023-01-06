using API.Catalog.Core.Entities;
using API.Catalog.Core.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet()]
        [Authorize(Policy = "read_access")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            try
            {
                return Ok(await _productRepository.Get());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        [Authorize(Policy = "read_access")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            try
            {
                var result = await _productRepository.Get(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}