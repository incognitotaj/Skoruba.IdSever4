using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Extensions
{
    public static class LinqExtensions
    {

        /// <summary>
        /// Gets column name and expected value from the collection / list
        /// </summary>
        /// <typeparam name="TSource">Collection / List</typeparam>
        /// <param name="source">List od values</param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TSource> TWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"source is null");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException($"predicate is null");
            }

            foreach (var item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }

        
    }
}
