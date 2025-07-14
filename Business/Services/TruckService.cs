using eshift_management.Core.Repositories;
using eshift_management.Core.Services;
using eshift_management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Services
{
    /// <summary>
    /// Provides business logic for managing trucks.
    /// Acts as a mediator between the UI and the truck repository.
    /// </summary>
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        /// <summary>
        /// Constructs the TruckService with an injected truck repository.
        /// </summary>
        /// <param name="truckRepository">The repository for database operations.</param>
        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        /// <inheritdoc/>
        public async Task<int> CreateTruckAsync(Truck truck)
        {
            // Future business logic (e.g., validating license plate format) can be added here.
            return await _truckRepository.AddAsync(truck);
        }

        /// <inheritdoc/>
        public async Task DeleteTruckAsync(int id)
        {
            // Future business logic (e.g., checking if truck is assigned to a unit) can be added here.
            await _truckRepository.DeleteAsync(id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Truck>> GetAllTrucksAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true)
        {
            return await _truckRepository.GetAllAsync(filter, orderBy, isAscending);
        }

        /// <inheritdoc/>
        public async Task<Truck?> GetTruckByIdAsync(int id)
        {
            return await _truckRepository.GetByIdAsync(id);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Truck>> GetTrucksByStatusAsync(ResourceStatus status)
        {
            return await _truckRepository.GetByStatusAsync(status);
        }

        /// <inheritdoc/>
        public async Task UpdateTruckAsync(Truck truck)
        {
            await _truckRepository.UpdateAsync(truck);
        }

        /// <inheritdoc/>
        public async Task UpdateTruckStatusAsync(int truckId, ResourceStatus status)
        {
            await _truckRepository.UpdateStatusAsync(truckId, status);
        }
    }
}
