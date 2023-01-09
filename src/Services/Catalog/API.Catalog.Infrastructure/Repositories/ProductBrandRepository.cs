using API.Catalog.Core.Entities;
using API.Catalog.Core.Repositories;
using API.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Catalog.Infrastructure.Repositories
{
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly CatalogContext _context;

        public ProductBrandRepository(CatalogContext context)
        {
            _context = context;
        }
        public async Task<ProductBrand> Get(int id, bool includeDetails = false)
        {
            if (includeDetails)
            {
                return await _context.ProductBrands
                .FirstOrDefaultAsync(p => p.Id == id);
            }

            return await _context.ProductBrands
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<ProductBrand>> Get(bool includeDetails = false)
        {
            if (includeDetails)
            {
                return await _context.ProductBrands
                .ToListAsync();
            }
            return await _context.ProductBrands
                .ToListAsync();
        }
    }
}
