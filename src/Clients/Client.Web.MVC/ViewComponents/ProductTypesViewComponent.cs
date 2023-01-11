using Client.Web.MVC.Responses;
using Client.Web.MVC.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Client.Web.MVC.ViewComponents
{
    public class ProductTypesViewComponent : ViewComponent
    {
        private readonly IProductTypesService _productTypesService;

        public ProductTypesViewComponent(IProductTypesService productTypesService)
        {
            _productTypesService = productTypesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }

        private async Task<IEnumerable<ProductTypeResponse>> GetItemsAsync()
        {
            return await _productTypesService.GetAsync();
        }
    }
}
