using API.Catalog.Core.Entities;
using Client.Web.MVC.Responses;

namespace Client.Web.MVC.Services.Contracts
{
    public interface IProductTypesService
    {
        Task<IEnumerable<ProductTypeResponse>> GetAsync();
        Task<ProductTypeResponse> GetByIdAsync(int id);

        Task<bool> CreateAsync(ProductTypeResponse product);
    }
}
