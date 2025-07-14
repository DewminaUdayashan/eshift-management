using eshift_management.Core.Repositories;
using eshift_management.Core.Services;
using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Services
{
    /// <summary>
    /// Provides business logic and operations for managing employees.
    /// It acts as a mediator between the UI and the employee repository.
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Constructs the EmployeeService with an injected employee repository.
        /// </summary>
        /// <param name="employeeRepository">The repository used to perform database operations.</param>
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <inheritdoc/>
        public async Task<int> CreateEmployeeAsync(Employee employee)
        {
            return await _employeeRepository.AddAsync(employee);
        }

        /// <inheritdoc/>
        public async Task DeleteEmployeeAsync(int id)
        {
            await _employeeRepository.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true)
        {
            return await _employeeRepository.GetAllAsync(filter, orderBy, isAscending);
        }

        /// <inheritdoc/>
        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Employee>> GetEmployeesByPositionAsync(EmployeePosition position)
        {
            return await _employeeRepository.GetByPositionAsync(position);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Employee>> GetEmployeesByStatusAsync(ResourceStatus status)
        {
            return await _employeeRepository.GetByStatusAsync(status);
        }

        /// <inheritdoc/>
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }

        /// <inheritdoc/>
        public async Task UpdateEmployeeStatusAsync(int employeeId, ResourceStatus status)
        {
            await _employeeRepository.UpdateStatusAsync(employeeId, status);
        }
    }
}
