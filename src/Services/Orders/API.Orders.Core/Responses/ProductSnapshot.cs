using API.Orders.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Orders.Core.Responses
{
    public class ProductSnapshot
    {
        public Product Product { get; set; }
        public DateTime PriodStart { get; set; }
        public DateTime PriodEnd { get; set; }
    }
}
