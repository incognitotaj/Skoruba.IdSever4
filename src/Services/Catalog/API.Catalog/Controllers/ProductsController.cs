using API.Catalog.Core.Entities;
using API.Catalog.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly CatalogContext _catalogContext;

        public ProductsController(ILogger<ProductsController> logger, CatalogContext catalogContext)
        {
            _logger = logger;
            _catalogContext = catalogContext;
        }

        [HttpGet()]
        [Authorize(Policy = "read_access")]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _catalogContext.Products
                .ToListAsync();
        }


        [HttpGet("{id}")]
        [Authorize(Policy = "read_access")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var result = await _catalogContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}