using API.Orders.Core.Entities;
using API.Orders.Core.Repositories;
using Common.Core.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Orders.Controllers
{
    [Route("temporals")]
    [ApiController]
    public class TemporalController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public TemporalController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        #region Seeding Data
        [HttpPost("seed-data")]
        public async Task<IActionResult> Seed()
        {
            var result = await _orderRepository.SeedDataAsync();
            return Ok(result);
        }
        #endregion

        #region Products
        [HttpPost("update-product/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductRequest productRequest)
        {
            var entity = new Product
            {
                Id = id,
                Name = productRequest.Name,
                Price = productRequest.Price
            };

            var result = await _orderRepository.UpdateProduct(entity);

            return Ok(result);
        }

        [HttpGet("get-products-all")]
        public async Task<IActionResult> GetProducts([FromBody] ProductSearchRequestAll request)
        {
            var result = await _orderRepository.GetProductsAll(request);
            return Ok(result);
        }

        [HttpGet("get-products-fromto")]
        public async Task<IActionResult> GetProducts([FromBody] ProductSearchRequestFromTo request)
        {
            var result = await _orderRepository.GetProductsFromTo(request);
            return Ok(result);
        }

        #endregion

        #region Orders
        [HttpPost("place-order")]
        public async Task<IActionResult> CreateOrder(OrderRequest orderRequest)
        {
            var entity = new Order
            {
                CustomerId = orderRequest.CustomerId,
                ProductId = orderRequest.ProductId,
                OrderDate = DateTime.UtcNow
            };

            var result = await _orderRepository.CreateOrder(entity);

            return Ok(result);
        }

        [HttpGet("find-order")]
        public async Task<IActionResult> FindOrder(OrderSearchRequestAsOf orderRequest)
        {
            var result = await _orderRepository.GetOrdersAsOf(orderRequest);

            return Ok(result);
        }
        #endregion

        #region Customers
        [HttpDelete("remove-customer/{customerName}")]
        public async Task<IActionResult> RemoveCustomer(string customerName)
        {
            var result = await _orderRepository.DeleteCustomer(customerName);
            if (result == false)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("get-customer/{customerName}")]
        public async Task<IActionResult> GetCustomerAll(string customerName)
        {
            var result = await _orderRepository.GetCustomerAll(customerName);

            return Ok(result);
        }
        #endregion
    }
}
