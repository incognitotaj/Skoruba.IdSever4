using API.Catalog.Core.Entities;
using Client.Web.MVC.Responses;

namespace Client.Web.MVC.Services.Contracts
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductResponse>> GetAsync();

        Task<ProductResponse> GetByIdAsync(int id);

        Task<bool> CreateAsync(ProductResponse product);
    }
}
