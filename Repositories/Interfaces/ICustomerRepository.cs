using eshift_management.Core.Repositories;
using eshift_management.Models;

namespace eshift_management.Repositories.Interfaces
{
    /// <summary>
    /// Defines the contract for a repository that handles data operations for Customer entities.
    /// Inherits standard CRUD operations from the generic IRepository interface.
    /// </summary>
    public interface ICustomerRepository : IRepository<CustomerModel>
    {}
}
