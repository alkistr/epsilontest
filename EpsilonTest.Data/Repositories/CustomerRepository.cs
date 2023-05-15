using EpsilonTest.Core;
using EpsilonTest.Data.Context;
using EpsilonTest.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EpsilonTest.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerDbContext _cusDbContext;

        public CustomerRepository(CustomerDbContext cusDbContext)
        {
            _cusDbContext = cusDbContext ?? throw new ArgumentNullException(nameof(cusDbContext));
        }

        public async Task<bool> CreateCustomerAsync(Customer customer)
        {
            _cusDbContext.Customers.Add(customer);
            var res = await _cusDbContext.SaveChangesAsync();
            return res == 1 ? true : false;
        }

        public async Task<bool> DeleteCustomerAsync(Customer customer)
        {
            _cusDbContext.Customers.Remove(customer);
            var res = await _cusDbContext.SaveChangesAsync();
            return res == 1 ? true : false;
        }

		public async Task<Customer> GetCustomerByIdAsync(Guid Id)
		{
            var result = await _cusDbContext.Customers.FindAsync(Id);
            return result != null ? result : new();
		}

		public async Task<IEnumerable<Customer>> GetCustomersAsync(int pageNum)
        {
            return await _cusDbContext.Customers.Skip(pageNum*30).Take(30).ToListAsync();
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            _cusDbContext.Customers.Update(customer);
            var res = await _cusDbContext.SaveChangesAsync();
            return res == 1 ? true : false;
        }
    }
}
