using eshift_management.Data;
using eshift_management.Models;
using eshift_management.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Repositories.Services
{
    /// <summary>
    /// Implements data operations for Customer entities using the DbExecutor.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Adds a new customer record to the database.
        /// </summary>
        /// <param name="entity">The customer entity to add.</param>
        public async Task<int> AddAsync(CustomerModel entity)
        {
            var sql = @"
                INSERT INTO customers (user_id, first_name, last_name, phone_number, address_line, city, postal_code)
                VALUES (@UserId, @FirstName, @LastName, @Phone, @AddressLine, @City, @PostalCode);";
          return await DbExecutor.ExecuteScalarAsync<int>(sql, entity);
        }

        // The methods below are inherited from IRepository and are not yet implemented.
        // They can be built out as needed using the DbExecutor, similar to the UserRepository.

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<CustomerModel>> GetAllAsync(Dictionary<string, object> filter = null, string orderBy = null, bool isAscending = true)
        {
            throw new System.NotImplementedException();
        }

        public Task<CustomerModel?> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(CustomerModel entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
