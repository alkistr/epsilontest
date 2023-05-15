using EpsilonTest.Application.Interfaces;
using EpsilonTest.BlazorWasm.Shared;
using EpsilonTest.Core;
using Microsoft.AspNetCore.Mvc;

namespace EpsilonTest.BlazorWasm.Server.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ILogger<CustomerController> _logger;
		private readonly ICustomerManager _customerManager;

        public CustomerController(ILogger<CustomerController> logger, ICustomerManager customerManager)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_customerManager = customerManager ?? throw new ArgumentNullException(nameof(customerManager));
		}

		[HttpGet]
		public async Task<IEnumerable<Customer>> GetCustomers(int pageNum)
		{
			var response = await _customerManager.GetCustomers(pageNum);
			_logger.LogInformation(response.ToString());

            if (response is null)
			{
				return Enumerable.Empty<Customer>();
			}

			return response;
		}

		[HttpPost]
		public async Task<IActionResult> CreateCustomer(Customer customer)
		{
            var response = await _customerManager.CreateCustomer(customer);
            _logger.LogInformation(response.ToString());

			if(!response)
			{
				return NoContent();
			}

			return Ok();
        }

		[HttpPut]
		public async Task<IActionResult> UpdateCustomer(Customer customer)
        {
            var response = await _customerManager.UpdateCustomer(customer);
            _logger.LogInformation(response.ToString());

            if (!response)
            {
                return NoContent();
            }

            return Ok();
        }

		[HttpDelete]
		public async Task<IActionResult> DeleteCustomer(Customer customer)
        {
            var response = await _customerManager.DeleteCustomer(customer);
            _logger.LogInformation(response.ToString());

            if (!response)
            {
                return NoContent();
            }
            return Ok();
        }
	}
}