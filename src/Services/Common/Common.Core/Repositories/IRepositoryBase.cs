using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> Get();
        IQueryable<T> Get(Expression<Func<T, bool>> expression);

    }
}
