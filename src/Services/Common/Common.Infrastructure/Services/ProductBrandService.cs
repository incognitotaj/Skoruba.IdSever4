using Common.Core.Responses;
using Common.Core.Services;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Common.Infrastructure.Servces
{
    public class ProductBrandService : IProductBrandsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductBrandService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductBrandResponse> GetByIdAsync(int id)
        {
            ProductBrandResponse product = new ProductBrandResponse();

            var client = _httpClientFactory.CreateClient("CatalogApiClient");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: $"/productbrands/{id}");


            var result = await client
                .SendAsync(request: request, completionOption: HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            result.EnsureSuccessStatusCode();
            if (result.IsSuccessStatusCode)
            {
                var model = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ApiResponse<ProductBrandResponse>>(model);

                product = data.Data;
            }
            return product;
        }

        public async Task<IEnumerable<ProductBrandResponse>> GetAsync()
        {
            IEnumerable<ProductBrandResponse> products = new List<ProductBrandResponse>();

            var client = _httpClientFactory.CreateClient("CatalogApiClient");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: "/products");


            var result = await client
                .SendAsync(request: request, completionOption: HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            result.EnsureSuccessStatusCode();
            if (result.IsSuccessStatusCode)
            {
                var model = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ProductBrandResponse>>>(model);

                products = data.Data;
            }
            return products;
        }


        public async Task<bool> CreateAsync(ProductBrandResponse model)
        {
            var client = _httpClientFactory.CreateClient("CatalogApiClient");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: "/productbrands");

            request.Content = JsonContent.Create(new ProductBrandResponse
            {
                Name = model.Name,
            });


            var result = await client
                .SendAsync(request: request, completionOption: HttpCompletionOption.ResponseContentRead);


            result.EnsureSuccessStatusCode();

            if (!result.IsSuccessStatusCode)
            {
                return false;
            }

            return true;
        }
    }
}
