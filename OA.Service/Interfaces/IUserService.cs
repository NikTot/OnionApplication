using OA.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserAsync(int id);
        void CreateUserAsync(UserDTO user);
        void UpdateUserAsync(UserDTO user);
        void DeleteUserAsync(int id);
    }
}
