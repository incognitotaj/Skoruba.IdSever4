using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Catalog.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
