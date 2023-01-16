using Common.Core.Responses;

namespace Common.Core.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductResponse>> GetAsync();
        Task<IEnumerable<ProductResponse>> GetListAsync();

        Task<ProductResponse> GetByIdAsync(int id);

        Task<bool> CreateAsync(ProductResponse product);
    }
}
