using API.Catalog.Core.Entities;
using API.Catalog.Core.Helpers;
using API.Catalog.Core.Repositories;
using API.Catalog.Infrastructure.Data;
using Common.Core.Helpers;
using Common.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Catalog.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(CatalogContext context)
            : base(context)
        {
        }

        public Task<Product> CreateAsync(Product postRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(int id, bool includeDetails = false)
        {
            if (includeDetails)
            {
                return await Get()
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }

            return await Get()
                    .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Product> GetList(bool includeDetails = false)
        {
            var result = Get();

            if (includeDetails)
            {
                result = result
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand);

            }

            return result;
        }

        public PagedList<Product> Get(ProductParameters pageParameters, bool includeDetails = false)
        {
            var result = Get();

            if (includeDetails)
            {
                result = result
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand);

                return PagedList<Product>.Create(result, pageParameters.PageNumber, pageParameters.PageSize);
            }

            return PagedList<Product>.Create(result, pageParameters.PageNumber, pageParameters.PageSize);
        }
    }
}
