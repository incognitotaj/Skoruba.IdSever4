using Common.Core.Responses;
using Common.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Client.Web.MVC.ViewComponents
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
