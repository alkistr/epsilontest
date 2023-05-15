using EpsilonTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsilonTest.Application.Interfaces
{
	public interface ICustomerManager
	{
        Task<IEnumerable<Customer>> GetCustomers(int pageNum);
        Task<Customer> GetCustomer(Guid Id);
		Task<bool> CreateCustomer(Customer customer);
		Task<bool> UpdateCustomer(Customer customer);
		Task<bool> DeleteCustomer(Customer customer);
	}
}
