using eshift_management.Models;
using eshift_management.Repositories.Interfaces;
using eshift_management.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Services.Implementations
{
    /// <summary>
    /// Provides business logic and data access coordination for customer operations.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository to use for data operations.</param>
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        /// <inheritdoc />
        public async Task<CustomerModel?> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CustomerModel>> GetAllAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true)
        {
            return await _customerRepository.GetAllAsync(filter, orderBy, isAscending);
        }

        /// <inheritdoc />
        public async Task<int> AddAsync(CustomerModel customer)
        {
            return await _customerRepository.AddAsync(customer);
        }

        /// <inheritdoc />
        public async Task UpdateAsync(CustomerModel customer)
        {
            await _customerRepository.UpdateAsync(customer);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }
    }
}
