using API.Catalog.Core.Entities;
using Client.Web.MVC.Responses;

namespace Client.Web.MVC.Services.Contracts
{
    public interface IProductBrandsService
    {
        Task<IEnumerable<ProductBrandResponse>> GetAsync();
        Task<ProductBrandResponse> GetByIdAsync(int id);

        Task<bool> CreateAsync(ProductBrandResponse product);
    }
}
