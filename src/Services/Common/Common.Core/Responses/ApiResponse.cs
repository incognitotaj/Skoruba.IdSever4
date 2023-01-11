using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Responses
{
    public class ApiResponse<T> where T : class
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
