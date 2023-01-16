using Common.Core.Responses;
using Common.Core.Services;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Common.Infrastructure.Servces
{
    public class ProductService : IProductsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductResponse> GetByIdAsync(int id)
        {
            ProductResponse product = new ProductResponse();

            var client = _httpClientFactory.CreateClient("CatalogApiClient");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: $"/products/{id}");

            var result = await client
                .SendAsync(request: request, completionOption: HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            result.EnsureSuccessStatusCode();
            if (result.IsSuccessStatusCode)
            {
                var model = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ApiResponse<ProductResponse>>(model);

                product = data.Data;
            }
            return product;
        }

        public async Task<IEnumerable<ProductResponse>> GetListAsync()
        {
            IEnumerable<ProductResponse> products = new List<ProductResponse>();

            var client = _httpClientFactory.CreateClient("CatalogApiClient");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: "/products/list");


            var result = await client
                .SendAsync(request: request, completionOption: HttpCompletionOption.ResponseHeadersRead)
                .ConfigureAwait(false);

            result.EnsureSuccessStatusCode();
            if (result.IsSuccessStatusCode)
            {
                var model = await result.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ProductResponse>>>(model);

                products = data.Data;
            }
            return products;
        }

        public async Task<IEnumerable<ProductResponse>> GetAsync()
        {
            IEnumerable<ProductResponse> products = new List<ProductResponse>();

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
                var data = JsonConvert.DeserializeObject<ApiResponse<IEnumerable<ProductResponse>>>(model);

                products = data.Data;
            }
            return products;
        }


        public async Task<bool> CreateAsync(ProductResponse model)
        {
            var client = _httpClientFactory.CreateClient("CatalogApiClient");

            var request = new HttpRequestMessage(
                method: HttpMethod.Get,
                requestUri: "/products");

            request.Content = JsonContent.Create(new ProductResponse
            {
                Name = model.Name,
                Description = model.Description,
                ProductBrandId = model.ProductBrandId,
                ProductTypeId = model.ProductTypeId,
                Price = model.Price,
                PictureUrl = model.PictureUrl,
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
