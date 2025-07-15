using eshift_management.Models;
using eshift_management.Repositories.Interfaces;
using eshift_management.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Services.Implementations
{
    /// <summary>
    /// Provides implementation for high-level user operations.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserModel?> GetByIdAsync(int id)
        {
            return _userRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<UserModel>> GetAllAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true)
        {
            return _userRepository.GetAllAsync(filter, orderBy, isAscending);
        }

        public Task<int> AddAsync(UserModel user)
        {
            return _userRepository.AddAsync(user);
        }

        public Task UpdateAsync(UserModel user)
        {
            return _userRepository.UpdateAsync(user);
        }

        public Task DeleteAsync(int id)
        {
            return _userRepository.DeleteAsync(id);
        }

        public Task<UserModel?> FindByEmailAsync(string email)
        {
            return _userRepository.FindByEmailAsync(email);
        }
     }
 }
