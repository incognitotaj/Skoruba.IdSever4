using API.Catalog.Core.Helpers;
using API.Catalog.Core.Repositories;
using API.Catalog.Infrastructure.Dtos;
using AutoMapper;
using Common.Core.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Catalog.Controllers
{
    public class ProductsController : BaseApiController
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

        [HttpGet("list")]
        [Authorize(Policy = "read_access")]
        public ActionResult Get()
        {
            try
            {
                var result = _productRepository.GetList(true);
                var products = _mapper.Map<IEnumerable<ProductDto>>(result);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [Authorize(Policy = "read_access")]
        public ActionResult Get([FromQuery]ProductParameters pageParameters)
        {
            try
            {
                var result = _productRepository.Get(pageParameters, true);

                var metadata = new
                {
                    result.TotalCount,
                    result.PageSize,
                    result.CurrentPage,
                    result.HasNext,
                    result.HasPrevious,
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

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

        [HttpPost]
        public ActionResult Create([FromForm]ProductPostRequest postRequest)
        {
            if (postRequest == null)
            {

                return BadRequest("Invalid post request");
            }
            
            if (string.IsNullOrEmpty(Request.GetMultipartBoundary()))
            {
                return BadRequest("Invalid post header");
            }


            if (postRequest.Image != null)
            {

                //await postService.SavePostImageAsync(postRequest);
            }

            return Ok();
        }
    }
}