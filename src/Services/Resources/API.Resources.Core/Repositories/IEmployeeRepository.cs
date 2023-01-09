using API.Resources.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Resources.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> Get(int id, bool includeDetails = false);
        Task<IEnumerable<Employee>> Get(bool includeDetails = false);
    }
}
