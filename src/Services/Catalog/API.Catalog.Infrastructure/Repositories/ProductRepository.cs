using API.Catalog.Core.Entities;
using API.Catalog.Core.Repositories;
using API.Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context;
        }
        public async Task<Product> Get(int id, bool includeDetails = false)
        {
            if (includeDetails)
            {
                return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id == id);
            }

            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> Get(bool includeDetails = false)
        {
            if (includeDetails)
            {
                return await _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductBrand)
                .ToListAsync();
            }
            return await _context.Products
                .ToListAsync();
        }
    }
}
