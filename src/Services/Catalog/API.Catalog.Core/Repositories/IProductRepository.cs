using API.Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        Task<Product> Get(int id, bool includeDetails = false);
        Task<IEnumerable<Product>> Get(bool includeDetails = false);
    }
}
