using API.Catalog.Core.Entities;
using API.Catalog.Core.Repositories;
using API.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Catalog.Infrastructure.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly CatalogContext _context;

        public ProductTypeRepository(CatalogContext context)
        {
            _context = context;
        }
        public async Task<ProductType> Get(int id, bool includeDetails = false)
        {
            if (includeDetails)
            {
                return await _context.ProductTypes
                .FirstOrDefaultAsync(p => p.Id == id);
            }

            return await _context.ProductTypes
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProductType>> Get(bool includeDetails = false)
        {
            if (includeDetails)
            {
                return await _context.ProductTypes
                .ToListAsync();
            }
            return await _context.ProductTypes
                .ToListAsync();
        }
    }
}
