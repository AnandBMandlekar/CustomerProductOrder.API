using Application.Domain.Models;
using Application.Domain.RequestViewModel;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerProductOrder.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, IOrderService orderService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<CustomerViewModel>>> GetAllCustomers()
        {
            try
            {
                return Ok(await _customerService.GetAllCustomers());
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error has ocurred while getting list of all customers: ErrorMessage: {ex.InnerException}, StackTrace: {ex.StackTrace}", ex);
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateCustomer([FromBody] CustomerViewModel customerModel)
        {
            try
            {
                return Ok(await _customerService.CreateCustomer(customerModel));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error has ocurred while creating a customer: ErrorMessage: {ex.InnerException}, StackTrace: {ex.StackTrace}", ex);
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<int>> UpdateACustomer([FromBody] CustomerViewModel customerModel)
        {
            try
            {
                return Ok(await _customerService.UpdateCustomer(customerModel));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error has ocurred while creating a customer: ErrorMessage: {ex.InnerException}, StackTrace: {ex.StackTrace}", ex);
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet("{customerId}/orders")]
        public async Task<ActionResult<List<OrderViewModel>>> GetOrderOfACustomer(int customerId)
        {
            try
            {
                return Ok(await _orderService.GetOrder(customerId));
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error has ocurred while trying to the orders of a customer: ErrorMessage: {ex.InnerException}, StackTrace: {ex.StackTrace}", ex);
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
