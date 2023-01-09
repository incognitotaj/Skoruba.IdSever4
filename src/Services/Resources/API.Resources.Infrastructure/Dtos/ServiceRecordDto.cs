using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Resources.Infrastructure.Dtos
{
    public class ServiceRecordDto
    {
        public string Employer { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public string Employee { get; set; }
    }
}
