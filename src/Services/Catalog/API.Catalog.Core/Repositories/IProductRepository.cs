using API.Catalog.Core.Entities;
using API.Catalog.Core.Helpers;
using Common.Core.Helpers;
using Common.Core.Repositories;
using Common.Core.Requests;

namespace API.Catalog.Core.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product> Get(int id, bool includeDetails = false);

        IEnumerable<Product> GetList(bool includeDetails = false);
        PagedList<Product> Get(ProductParameters pageParameters, bool includeDetails = false);

        Task<Product> CreateAsync(Product postRequest);
    }
}
