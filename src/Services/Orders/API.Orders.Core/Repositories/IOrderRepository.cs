using API.Orders.Core.Entities;
using API.Orders.Core.Responses;
using Common.Core.Requests;

namespace API.Orders.Core.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> SeedDataAsync();

        // Customers
        Task<bool> DeleteCustomer(string customerName);
        Task<IEnumerable<CustomerSnapshot>> GetCustomerAll(string customerName);

        // Products
        Task<bool> UpdateProduct(Product product);
        Task<IEnumerable<ProductSnapshot>> GetProductsAll(ProductSearchRequestAll request);
        Task<IEnumerable<ProductSnapshot>> GetProductsFromTo(ProductSearchRequestFromTo request);

        // Orders
        Task<bool> CreateOrder(Order order);
        Task<Order> GetOrdersAsOf(OrderSearchRequestAsOf request);
    }
}
