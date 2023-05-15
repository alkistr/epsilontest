
using EpsilonTest.Core;

namespace EpsilonTest.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomersAsync(int pageNum);
        Task<bool> CreateCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(Customer customer);
		Task<Customer> GetCustomerByIdAsync(Guid Id);
	}
}
