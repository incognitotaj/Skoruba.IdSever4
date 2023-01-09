using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Resources.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
