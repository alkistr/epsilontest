using EpsilonTest.Application.Interfaces;
using EpsilonTest.Core;
using EpsilonTest.Data.Interfaces;
using Microsoft.Extensions.Logging;

namespace EpsilonTest.Application.Implementations
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ILogger<CustomerManager> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomerManager(ILogger<CustomerManager> logger, ICustomerRepository customerRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<bool> CreateCustomer(Customer customer)
        {
            var result = await _customerRepository.CreateCustomerAsync(customer);
            return result;
        }

        public async Task<bool> DeleteCustomer(Customer customer)
        {
			var result = await _customerRepository.DeleteCustomerAsync(customer);
			return result;
		}

		public async Task<Customer> GetCustomer(Guid Id)
		{
			var response = await _customerRepository.GetCustomerByIdAsync(Id);

			if (response is null)
			{
				return new Customer();
			}
			return response;
		}

		public async Task<IEnumerable<Customer>> GetCustomers(int pageNum)
        {
            var response = await _customerRepository.GetCustomersAsync(pageNum);

            if(response is null)
            {
                return Enumerable.Empty<Customer>();
            }
            return response;
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
			var result = await _customerRepository.UpdateCustomerAsync(customer);
			return result;
		}
    }
}
