using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Helpers
{
    public abstract class QueryParameters
    {
        public int MaxPageSize { get; set; } = 50;
        public int PageNumber { get; set; } = 1;

        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }

        public QueryParameters()
        {
            PageSize = 5;
        }
    }
}
