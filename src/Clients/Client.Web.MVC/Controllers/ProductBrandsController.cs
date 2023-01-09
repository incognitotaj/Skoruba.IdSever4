using Client.Web.MVC.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Web.MVC.Controllers
{
    [Authorize]
    public class ProductBrandsController : Controller
    {
        private readonly ILogger<ProductBrandsController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductBrandsController(
            ILogger<ProductBrandsController> logger,
            IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }
    }
}
