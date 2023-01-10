using API.Catalog.Core.Entities;
using API.Catalog.Core.Helpers;
using Common.Core.Helpers;
using Common.Core.Repositories;

namespace API.Catalog.Core.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<Product> Get(int id, bool includeDetails = false);

        PagedList<Product> Get(ProductParameters pageParameters, bool includeDetails = false);
    }
}
