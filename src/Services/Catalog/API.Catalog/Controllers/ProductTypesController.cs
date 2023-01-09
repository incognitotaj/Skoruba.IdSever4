using API.Catalog.Core.Repositories;
using API.Catalog.Infrastructure.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Catalog.Controllers
{
    public class ProductTypesController : BaseApiController
    {
        private readonly ILogger<ProductTypesController> _logger;
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductTypesController(
            ILogger<ProductTypesController> logger,
            IProductTypeRepository productTypeRepository,
            IMapper mapper)
        {
            _logger = logger;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        [Authorize(Policy = "read_access")]
        public async Task<ActionResult<IEnumerable<ProductTypeDto>>> Get()
        {
            try
            {
                var result = await _productTypeRepository.Get(true);
                var products = _mapper.Map<IEnumerable<ProductTypeDto>>(result);
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
        public async Task<ActionResult<ProductTypeDto>> Get(int id)
        {
            try
            {
                var result = await _productTypeRepository.Get(id, true);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<ProductTypeDto>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}