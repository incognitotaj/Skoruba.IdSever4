using API.Orders.Core.Entities;
using API.Orders.Core.Repositories;
using API.Orders.Core.Responses;
using API.Orders.Infrastructure.Data;
using Common.Core.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Orders.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }


        public async Task<bool> SeedDataAsync()
        {
            try
            {
                if (!_context.Customers.Any())
                {
                    var customer = new Customer { Name = "Arthur" };
                    await _context.Customers.AddAsync(customer);
                }

                if (!_context.Products.Any())
                {
                    var products = new List<Product>
                    {
                        new() { Name = "DeLorean", Price = 1_000_000.00m },
                        new() { Name = "Flux Capacitor", Price = 666.00m },
                        new() { Name = "Hoverboard", Price = 59_000.00m }
                    };

                    await _context.AddRangeAsync(products);
                }
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var productToUpdate = await _context.Products.FindAsync(product.Id);
            if (productToUpdate == null)
            {
                throw new Exception($"Not found");
            }

            productToUpdate.Name = product.Name;
            productToUpdate.Price = product.Price;

            _context.Products.Update(productToUpdate);

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> CreateOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ProductSnapshot>> GetProductsAll(ProductSearchRequestAll request)
        {
            var productsSnapshots = await _context.Products
                .TemporalAll()
                .OrderBy(p => EF.Property<DateTime>(p, "PeriodStart"))
                .Where(p => p.Name.ToLower().Contains(request.Name.ToLower()))
                .Select(p => new ProductSnapshot
                {
                    Product = p,
                    PriodStart = EF.Property<DateTime>(p, "PeriodStart"),
                    PriodEnd = EF.Property<DateTime>(p, "PeriodEnd"),

                }).ToListAsync();

            return productsSnapshots;
        }

        public async Task<IEnumerable<ProductSnapshot>> GetProductsFromTo(ProductSearchRequestFromTo request)
        {
            var productsSnapshots = await _context.Products
                .TemporalFromTo(request.From, request.To)
                .OrderBy(p => EF.Property<DateTime>(p, "PeriodStart"))
                .Where(p => p.Name.ToLower().Contains(request.Name.ToLower()))
                .Select(p => new ProductSnapshot
                {
                    Product = p,
                    PriodStart = EF.Property<DateTime>(p, "PeriodStart"),
                    PriodEnd = EF.Property<DateTime>(p, "PeriodEnd"),

                }).ToListAsync();

            return productsSnapshots;
        }


        public async Task<Order> GetOrdersAsOf(OrderSearchRequestAsOf request)
        {
            var order = await _context.Orders
                .TemporalAsOf(request.On)
                .Include(p => p.Customer)
                .Include(p => p.Product)
                .FirstOrDefaultAsync(p => p.Customer.Name.ToLower().Contains(request.Customer.ToLower())
                    && p.OrderDate > request.On
                    && p.OrderDate < request.On.AddDays(1));

            return order;
        }

        public async Task<bool> DeleteCustomer(string customerName)
        {
            var customer = await _context.Customers
                .Include(p => p.Orders)
                .FirstOrDefaultAsync(p => p.Name.ToLower() == customerName);

            if (customer == null)
            {
                return false;
            }

            _context.RemoveRange(customer.Orders);
            _context.Remove(customer);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<CustomerSnapshot>> GetCustomerAll(string customerName)
        {
            var customersSnapshots = await _context.Customers
                .TemporalAll()
                .OrderBy(p => EF.Property<DateTime>(p, "PeriodStart"))
                .Where(p => p.Name.ToLower() == customerName)
                .Select(p => new CustomerSnapshot
                {
                    Customer = p,
                    PriodStart = EF.Property<DateTime>(p, "PeriodStart"),
                    PriodEnd = EF.Property<DateTime>(p, "PeriodEnd"),

                }).ToListAsync();

            return customersSnapshots;
        }
    }
}
