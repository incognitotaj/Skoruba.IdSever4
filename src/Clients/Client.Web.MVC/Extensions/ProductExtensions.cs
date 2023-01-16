using Common.Core.Responses;

namespace Client.Web.MVC.Extensions
{
    public static class ProductExtensions
    {
        public static IEnumerable<ProductResponse> TWhere(this IEnumerable<ProductResponse> source, string columnName, string columnValue)
        {
            if (source == null)
            {
                throw new ArgumentNullException($"source is null");
            }

            if (columnName == null)
            {
                throw new ArgumentNullException($"column name is null");
            }

            IEnumerable<ProductResponse> result = null;

            switch (columnName)
            {
                case "Name":
                    result = source.Where(p => p.Name.Contains(columnValue));
                    break;
                case "Description":
                    result = source.Where(p => p.Description.Contains(columnValue));
                    break;
                case "ProductBrand":
                    result = source.Where(p => p.ProductBrand.Contains(columnValue));
                    break;
                case "ProductType":
                    result = source.Where(p => p.ProductType.Contains(columnValue));
                    break;
            }

            return result;
        }
    }
}
