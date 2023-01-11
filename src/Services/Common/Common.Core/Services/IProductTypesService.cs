using Common.Core.Responses;

namespace Common.Core.Services
{
    public interface IProductTypesService
    {
        Task<IEnumerable<ProductTypeResponse>> GetAsync();
        Task<ProductTypeResponse> GetByIdAsync(int id);

        Task<bool> CreateAsync(ProductTypeResponse product);
    }
}
