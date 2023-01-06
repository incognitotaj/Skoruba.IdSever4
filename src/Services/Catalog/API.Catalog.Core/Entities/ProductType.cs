using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Catalog.Core.Entities
{
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public ProductType()
        {
            Products = new HashSet<Product>();
        }
    }
}
