using API.Resources.Core.Repositories;
using API.Resources.Infrastructure.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Resources.Controllers
{
    public class EmployeesController : BaseApiController
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(
            ILogger<EmployeesController> logger,
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }


        [HttpGet()]
        //[Authorize(Policy = "read_access")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Get()
        {
            try
            {
                var result = await _employeeRepository.Get(true);
                var products = _mapper.Map<IEnumerable<EmployeeDto>>(result);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        //[Authorize(Policy = "read_access")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            try
            {
                var result = await _employeeRepository.Get(id, true);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<EmployeeDto>(result));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
