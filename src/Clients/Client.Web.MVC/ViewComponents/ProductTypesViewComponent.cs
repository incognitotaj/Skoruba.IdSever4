using Client.Web.MVC.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Web.MVC.ViewComponents
{
    public class ProductTypesViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductTypesViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }

        private async Task<IEnumerable<ProductType>> GetItemsAsync()
        {
            IEnumerable<ProductType> productTypes = new List<ProductType>();

            var client = _httpClientFactory.CreateClient("CatalogApiClient");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: "/producttypes");


            var result = await client
                .SendAsync(request: request, completionOption: HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            result.EnsureSuccessStatusCode();
            if (result.IsSuccessStatusCode)
            {
                var model = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<IEnumerable<ProductType>>(model);

                productTypes = data;
            }
            return productTypes;
        }
    }
}
