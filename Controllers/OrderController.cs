using Application.Domain.Models;
using Application.Domain.RequestViewModel;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerProductOrder.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<OrderViewModel>>> GetAllOrders()
        {
            try
            {
                return Ok(await _orderService.GetOrderList());
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error has occurred while trying to get list of all orders: ErrorMessage: {ex.InnerException}, StackTrace: {ex.StackTrace}", ex);
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateOrder([FromBody]OrderViewModel order)
        {
            try
            {
                return Ok(await _orderService.CreateOrder(order));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error has occurred while trying to create an order: ErrorMessage: {ex.InnerException}, StackTrace: {ex.StackTrace}", ex);
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<int>> UpdateOrder([FromBody] OrderViewModel order)
        {
            try
            {
                return Ok(await _orderService.UpdateOrder(order));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error has occurred while trying to update an order: ErrorMessage: {ex.InnerException}, StackTrace: {ex.StackTrace}", ex);
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
