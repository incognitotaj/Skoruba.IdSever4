using Client.Web.MVC.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Web.MVC.ViewComponents
{
    public class ProductBrandsViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductBrandsViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }

        private async Task<IEnumerable<ProductBrand>> GetItemsAsync()
        {
            IEnumerable<ProductBrand> productBrands = new List<ProductBrand>();

            var client = _httpClientFactory.CreateClient("CatalogApiClient");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: "/productbrands");


            var result = await client
                .SendAsync(request: request, completionOption: HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            result.EnsureSuccessStatusCode();
            if (result.IsSuccessStatusCode)
            {
                var model = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<ProductBrand>>(model);

                productBrands = data;
            }
            return productBrands;
        }
    }
}
