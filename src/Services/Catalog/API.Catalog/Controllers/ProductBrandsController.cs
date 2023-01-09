using API.Catalog.Core.Repositories;
using API.Catalog.Infrastructure.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Catalog.Controllers
{
    public class ProductBrandsController : BaseApiController
    {
        private readonly ILogger<ProductBrandsController> _logger;
        private readonly IProductBrandRepository _productBrandRepository;
        private readonly IMapper _mapper;

        public ProductBrandsController(
            ILogger<ProductBrandsController> logger,
            IProductBrandRepository productBrandRepository,
            IMapper mapper)
        {
            _logger = logger;
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        [Authorize(Policy = "read_access")]
        public async Task<ActionResult<IEnumerable<ProductBrandDto>>> Get()
        {
            try
            {
                var result = await _productBrandRepository.Get(true);
                var products = _mapper.Map<IEnumerable<ProductBrandDto>>(result);
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
        public async Task<ActionResult<ProductBrandDto>> Get(int id)
        {
            try
            {
                var result = await _productBrandRepository.Get(id, true);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ProductBrandDto>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}