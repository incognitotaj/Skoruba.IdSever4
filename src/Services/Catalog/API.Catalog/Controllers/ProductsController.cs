using API.Catalog.Core.Repositories;
using API.Catalog.Infrastructure.Dtos;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductsController(
            ILogger<ProductsController> logger, 
            IProductRepository productRepository,
            IMapper mapper)
        {
            _logger = logger;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        [Authorize(Policy = "read_access")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            try
            {
                var result = await _productRepository.Get(true);
                var products = _mapper.Map<IEnumerable<ProductDto>>(result);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        [Authorize(Policy = "read_access")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            try
            {
                var result = await _productRepository.Get(id, true);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ProductDto>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}