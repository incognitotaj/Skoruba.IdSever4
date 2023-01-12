using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Orders.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }  = new HashSet<Order>();
    }
}
