using API.Resources.Core.Entities;
using API.Resources.Core.Repositories;
using API.Resources.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.Resources.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRContext _context;

        public EmployeeRepository(HRContext context)
        {
            _context = context;
        }
        public async Task<Employee> Get(int id, bool includeDetails = false)
        {
            if (includeDetails)
            {
                return await _context.Employees
                    .AsSplitQuery()
                    .Include(p => p.Subscriptions)
                    .Include(p => p.ServiceRecords)
                    .FirstOrDefaultAsync(p => p.Id == id);
            }

            return await _context.Employees
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Employee>> Get(bool includeDetails = false)
        {
            if (includeDetails)
            {
                return await _context.Employees
                    .AsSplitQuery()
                    .Include(p => p.Subscriptions)
                    .Include(p => p.ServiceRecords)
                    .ToListAsync();
            }
            return await _context.Employees
                .ToListAsync();
        }
    }
}
