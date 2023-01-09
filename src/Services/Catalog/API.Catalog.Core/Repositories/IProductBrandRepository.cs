using API.Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Catalog.Core.Repositories
{
    public interface IProductBrandRepository
    {
        Task<ProductBrand> Get(int id, bool includeDetails = false);
        Task<IEnumerable<ProductBrand>> Get(bool includeDetails = false);
    }
}
