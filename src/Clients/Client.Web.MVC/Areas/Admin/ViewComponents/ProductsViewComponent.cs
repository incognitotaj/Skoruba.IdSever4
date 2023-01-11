using Client.Web.MVC.Responses;
using Client.Web.MVC.Services.Contracts;
using Common.Core.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Web.MVC.Areas.Admin.ViewComponents
{
    public class ProductsViewComponent : ViewComponent
    {
        private readonly IProductsService _productsService;

        public ProductsViewComponent(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }

        private async Task<IEnumerable<ProductResponse>> GetItemsAsync()
        {
            return await _productsService.GetAsync();
        }
    }
}
