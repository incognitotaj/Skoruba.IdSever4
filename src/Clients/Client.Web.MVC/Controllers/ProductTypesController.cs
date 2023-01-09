using Client.Web.MVC.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Client.Web.MVC.Controllers
{
    [Authorize]
    public class ProductTypesController : Controller
    {
        private readonly ILogger<ProductTypesController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductTypesController(
            ILogger<ProductTypesController> logger,
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
