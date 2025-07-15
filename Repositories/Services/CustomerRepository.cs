using eshift_management.Data;
using eshift_management.Models;
using eshift_management.Repositories.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eshift_management.Repositories.Services
{
    /// <summary>
    /// Implements data operations for Customer entities using the DbExecutor.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        /// <inheritdoc />
        public async Task<int> AddAsync(CustomerModel entity)
        {
            var sql = @"
                INSERT INTO customers 
                    (user_id, first_name, last_name, phone_number, address_line, city, postal_code)
                VALUES 
                    (@UserId, @FirstName, @LastName, @Phone, @AddressLine, @City, @PostalCode);";

            return await DbExecutor.ExecuteScalarAsync<int>(sql, entity);
        }

        /// <inheritdoc />
        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM customers WHERE user_id = @UserId;";
            await DbExecutor.ExecuteAsync(sql, new { UserId = id });
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CustomerModel>> GetAllAsync(Dictionary<string, object> filter = null, string orderBy = null, bool isAscending = true)
        {
            var sqlBuilder = new StringBuilder(@"
                SELECT
    c.user_id AS UserId,
    u.email AS Email,
    c.first_name AS FirstName,
    c.last_name AS LastName,
    c.phone_number AS Phone,
    c.address_line AS AddressLine,
    c.city AS City,
    c.postal_code AS PostalCode
FROM
    customers c
JOIN
    users u ON c.user_id = u.id");

            if (filter != null && filter.Count > 0)
            {
                sqlBuilder.Append(" WHERE ");
                var conditions = new List<string>();
                foreach (var key in filter.Keys)
                {
                    conditions.Add($"{key} = @{key}");
                }
                sqlBuilder.Append(string.Join(" AND ", conditions));
            }

            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                sqlBuilder.Append($" ORDER BY {orderBy} {(isAscending ? "ASC" : "DESC")}");
            }

            sqlBuilder.Append(';');

            return await DbExecutor.QueryAsync<CustomerModel>(sqlBuilder.ToString(), filter);
        }

        /// <inheritdoc />
        public async Task<CustomerModel?> GetByIdAsync(int id)
        {
            var sql = @"
                SELECT 
                    user_id AS UserId,
                    first_name AS FirstName,
                    last_name AS LastName,
                    phone_number AS Phone,
                    address_line AS AddressLine,
                    city AS City,
                    postal_code AS PostalCode
                FROM customers
                WHERE user_id = @UserId;";

            return await DbExecutor.QueryFirstOrDefaultAsync<CustomerModel>(sql, new { UserId = id });
        }

        /// <inheritdoc />
        public async Task UpdateAsync(CustomerModel entity)
        {
            var sql = @"
                UPDATE customers SET 
                    first_name = @FirstName,
                    last_name = @LastName,
                    phone_number = @Phone,
                    address_line = @AddressLine,
                    city = @City,
                    postal_code = @PostalCode
                WHERE user_id = @UserId;";

            await DbExecutor.ExecuteAsync(sql, entity);
        }
    }
}
