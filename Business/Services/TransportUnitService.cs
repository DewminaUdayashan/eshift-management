using eshift_management.Core.Repositories;
using eshift_management.Core.Services;
using eshift_management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eshift_management.Services
{
    /// <summary>
    /// Provides business logic for managing transport units.
    /// Acts as a mediator between the UI and the transport unit repository.
    /// </summary>
    public class TransportUnitService : ITransportUnitService
    {
        private readonly ITransportUnitRepository _unitRepository;
        private readonly ITruckRepository _truckRepository;
        private readonly IEmployeeRepository _employeeRepository;

        /// <summary>
        /// Constructs the TransportUnitService with injected repositories.
        /// </summary>
        public TransportUnitService(ITransportUnitRepository unitRepository, ITruckRepository truckRepository, IEmployeeRepository employeeRepository)
        {
            _unitRepository = unitRepository;
            _truckRepository = truckRepository;
            _employeeRepository = employeeRepository;
        }

        /// <inheritdoc/>
        public async Task<int> CreateTransportUnitAsync(TransportUnit unit)
        {
            // Business Logic: Ensure resources are available before creating the unit.
            if (unit.Truck.Status != ResourceStatus.Available ||
                unit.Driver.Status != ResourceStatus.Available ||
                unit.Assistant.Status != ResourceStatus.Available)
            {
                throw new InvalidOperationException("One or more selected resources are not available.");
            }

            // Create the unit first.
            var newUnitId = await _unitRepository.AddAsync(unit);

            // Business Logic: Update the status of all assigned resources.
            await _truckRepository.UpdateStatusAsync(unit.Truck.Id, ResourceStatus.Assigned);
            await _employeeRepository.UpdateStatusAsync(unit.Driver.Id, ResourceStatus.Assigned);
            await _employeeRepository.UpdateStatusAsync(unit.Assistant.Id, ResourceStatus.Assigned);

            return newUnitId;
        }

        /// <inheritdoc/>
        public async Task DeleteTransportUnitAsync(int id)
        {
            // Business Logic: Get the unit to find its resources before deleting.
            var unitToDelete = await _unitRepository.GetByIdAsync(id);
            if (unitToDelete == null)
            {
                throw new KeyNotFoundException("Transport unit not found.");
            }

            // Delete the unit from the database.
            await _unitRepository.DeleteAsync(id);

            // Business Logic: Update the status of the freed resources.
            await _truckRepository.UpdateStatusAsync(unitToDelete.Truck.Id, ResourceStatus.Available);
            await _employeeRepository.UpdateStatusAsync(unitToDelete.Driver.Id, ResourceStatus.Available);
            await _employeeRepository.UpdateStatusAsync(unitToDelete.Assistant.Id, ResourceStatus.Available);
        }

        /// <inheritdoc/>
        public async Task UpdateTransportUnitAsync(TransportUnit updatedUnit)
        {
            // Get the original unit from the database to compare resources.
            var originalUnit = await _unitRepository.GetByIdAsync(updatedUnit.Id);
            if (originalUnit == null)
            {
                throw new KeyNotFoundException("Transport unit not found for update.");
            }

            // Update the unit record itself.
            await _unitRepository.UpdateAsync(updatedUnit);

            // --- Business Logic: Update resource statuses ---

            // Free up old resources if they have been changed.
            if (originalUnit.Truck.Id != updatedUnit.Truck.Id)
            {
                await _truckRepository.UpdateStatusAsync(originalUnit.Truck.Id, ResourceStatus.Available);
            }
            if (originalUnit.Driver.Id != updatedUnit.Driver.Id)
            {
                await _employeeRepository.UpdateStatusAsync(originalUnit.Driver.Id, ResourceStatus.Available);
            }
            if (originalUnit.Assistant.Id != updatedUnit.Assistant.Id)
            {
                await _employeeRepository.UpdateStatusAsync(originalUnit.Assistant.Id, ResourceStatus.Available);
            }

            // Assign the new resources.
            await _truckRepository.UpdateStatusAsync(updatedUnit.Truck.Id, ResourceStatus.Assigned);
            await _employeeRepository.UpdateStatusAsync(updatedUnit.Driver.Id, ResourceStatus.Assigned);
            await _employeeRepository.UpdateStatusAsync(updatedUnit.Assistant.Id, ResourceStatus.Assigned);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TransportUnit>> GetAllTransportUnitsAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true)
        {
            return await _unitRepository.GetAllAsync(filter, orderBy, isAscending);
        }

        /// <inheritdoc/>
        public async Task<TransportUnit?> GetTransportUnitByIdAsync(int id)
        {
            return await _unitRepository.GetByIdAsync(id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TransportUnit>> GetTransportUnitsByStatusAsync(ResourceStatus status)
        {
            return await _unitRepository.GetByStatusAsync(status);
        }

        /// <inheritdoc/>
        public async Task UpdateTransportUnitStatusAsync(int unitId, ResourceStatus status)
        {
            await _unitRepository.UpdateStatusAsync(unitId, status);
        }
    }
}
