using Common.Core.Responses;
using Common.Core.Services;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Common.Infrastructure.Servces
{
    public class ProductTypeService : IProductTypesService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductTypeService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductTypeResponse> GetByIdAsync(int id)
        {
            ProductTypeResponse product = new ProductTypeResponse();

            var client = _httpClientFactory.CreateClient("CatalogApiClient");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: $"/producttypes/{id}");


            var result = await client
                .SendAsync(request: request, completionOption: HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            result.EnsureSuccessStatusCode();
            if (result.IsSuccessStatusCode)
            {
                var model = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ApiResponse<ProductTypeResponse>>(model);

                product = data.Data;
            }
            return product;
        }

        public async Task<IEnumerable<ProductTypeResponse>> GetAsync()
        {
            IEnumerable<ProductTypeResponse> products = new List<ProductTypeResponse>();

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
                var data = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ProductTypeResponse>>>(model);

                products = data.Data;
            }
            return products;
        }


        public async Task<bool> CreateAsync(ProductTypeResponse model)
        {
            var client = _httpClientFactory.CreateClient("CatalogApiClient");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: "/productbrands");

            request.Content = JsonContent.Create(new ProductTypeResponse
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
