using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Core.Services
{
    /// <summary>
    /// Defines the contract for employee-related business operations.
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Retrieves all employees, with optional filtering and sorting.
        /// </summary>
        /// <param name="filter">A dictionary of values to filter by. Supports a 'SearchTerm' key.</param>
        /// <param name="orderBy">The property to sort by.</param>
        /// <param name="isAscending">The sort direction.</param>
        /// <returns>A collection of employees.</returns>
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true);

        /// <summary>
        /// Retrieves a single employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        Task<Employee?> GetEmployeeByIdAsync(int id);

        /// <summary>
        /// Retrieves all employees with a specific position.
        /// </summary>
        /// <param name="position">The position to filter by.</param>
        Task<IEnumerable<Employee>> GetEmployeesByPositionAsync(EmployeePosition position);

        /// <summary>
        /// Retrieves all employees with a specific status.
        /// </summary>
        /// <param name="status">The status to filter by.</param>
        Task<IEnumerable<Employee>> GetEmployeesByStatusAsync(ResourceStatus status);

        /// <summary>
        /// Creates a new employee record.
        /// </summary>
        /// <param name="employee">The employee data to insert.</param>
        /// <returns>The newly created employee ID.</returns>
        Task<int> CreateEmployeeAsync(Employee employee);

        /// <summary>
        /// Updates an existing employee record.
        /// </summary>
        /// <param name="employee">The employee data with updates.</param>
        Task UpdateEmployeeAsync(Employee employee);

        /// <summary>
        /// Deletes an employee by their ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        Task DeleteEmployeeAsync(int id);

        /// <summary>
        /// Updates the status of a specific employee.
        /// </summary>
        /// <param name="employeeId">The ID of the employee.</param>
        /// <param name="status">The new status.</param>
        Task UpdateEmployeeStatusAsync(int employeeId, ResourceStatus status);
    }
}
