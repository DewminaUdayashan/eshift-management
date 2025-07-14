using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Core.Repositories
{
    /// <summary>
    /// Repository interface for accessing and manipulating employee data.
    /// </summary>
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Gets all employees with a specific status (e.g., 'Available').
        /// </summary>
        /// <param name="status">The resource status to filter by.</param>
        /// <returns>A collection of employees matching the status.</returns>
        Task<IEnumerable<Employee>> GetByStatusAsync(ResourceStatus status);

        /// <summary>
        /// Gets all employees with a specific position (e.g., 'Driver').
        /// </summary>
        /// <param name="position">The position to filter by.</param>
        /// <returns>A collection of employees matching the position.</returns>
        Task<IEnumerable<Employee>> GetByPositionAsync(EmployeePosition position);

        /// <summary>
        /// Updates the status of a specific employee.
        /// </summary>
        /// <param name="employeeId">The ID of the employee to update.</param>
        /// <param name="status">The new status to set.</param>
        Task UpdateStatusAsync(int employeeId, ResourceStatus status);
    }
}
