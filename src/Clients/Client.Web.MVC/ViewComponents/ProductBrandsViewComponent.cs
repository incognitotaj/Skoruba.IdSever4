using Common.Core.Responses;
using Common.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Client.Web.MVC.ViewComponents
{
    public class ProductBrandsViewComponent : ViewComponent
    {
        private readonly IProductBrandsService _productBrandsService;

        public ProductBrandsViewComponent(IProductBrandsService productBrandsService)
        {
            _productBrandsService = productBrandsService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }

        private async Task<IEnumerable<ProductBrandResponse>> GetItemsAsync()
        {
            return await _productBrandsService.GetAsync();
        }
    }
}
