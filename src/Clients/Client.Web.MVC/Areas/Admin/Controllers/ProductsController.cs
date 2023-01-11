using API.Catalog.Core.Entities;
using Client.Web.MVC.Areas.Admin.Models;
using Client.Web.MVC.Responses;
using Client.Web.MVC.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Client.Web.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "admin_policy")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _productsService;
        private readonly IProductTypesService _productTypesService;
        private readonly IProductBrandsService _productBrandsService;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductsService productsService,
            IProductTypesService productTypesService,
            IProductBrandsService productBrandsService)
        {
            _logger = logger;
            _productsService = productsService;
            _productTypesService = productTypesService;
            _productBrandsService = productBrandsService;
        }


        #region Read
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return ViewComponent("Client.Web.MVC.Areas.Admin.ViewComponents.Products");
        }
        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var brands = await _productBrandsService.GetAsync();
            var types = await _productTypesService.GetAsync();

            var model = new ProductCreateModel()
            {
                ProductBrands = brands.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() }),
                ProductTypes = brands.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() })
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateModel model)
        {
            var brands = await _productBrandsService.GetAsync();
            var types = await _productTypesService.GetAsync();

            model.ProductBrands = brands.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() });
            model.ProductTypes = brands.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() });

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Provide all valid data to proceed");
                return View(model);
            }
            var entry = new ProductResponse
            {
                Name = model.Name,
                Description = model.Description,
                ProductBrandId = model.ProductBrandId,
                ProductTypeId = model.ProductTypeId,
                Price = model.Price,
                PictureUrl = model.PictureUrl,
            };


            if (!await _productsService.CreateAsync(entry))
            {
                ModelState.AddModelError(string.Empty, "Error while saving resource");
                return View(model);
            }

            return RedirectToAction("Index", new { area = "Admin" });
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var entity = await _productsService.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            var model = new ProductUpdateModel()
            {
                Description = entity.Description,
                Name = entity.Name,
                Id = entity.Id,
                PictureUrl = entity.PictureUrl,
                Price = entity.Price,
                ProductBrandId = entity.ProductBrandId,
                ProductTypeId = entity.ProductTypeId,
            };

            var brands = await _productBrandsService.GetAsync();
            var types = await _productTypesService.GetAsync();

            model.ProductBrands = brands.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() });
            model.ProductTypes = brands.Select(p => new SelectListItem { Text = p.Name, Value = p.Id.ToString() });

            return View(model);
        }

        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
        #endregion
    }
}
