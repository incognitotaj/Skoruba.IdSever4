using API.Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Catalog.Core.Repositories
{
    public interface IProductTypeRepository
    {
        Task<ProductType> Get(int id, bool includeDetails = false);
        Task<IEnumerable<ProductType>> Get(bool includeDetails = false);
    }
}
