using Common.Core.Responses;

namespace Common.Core.Services
{
    public interface IProductBrandsService
    {
        Task<IEnumerable<ProductBrandResponse>> GetAsync();
        Task<ProductBrandResponse> GetByIdAsync(int id);

        Task<bool> CreateAsync(ProductBrandResponse product);
    }
}
