using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Web.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private readonly ILogger<ProductTypesController> _logger;

        public ProductTypesController(
            ILogger<ProductTypesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Policy = "admin_policy")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
