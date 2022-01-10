using System.Collections.Generic;
using System.Threading.Tasks;
using TeUserManagement.Domain.Dtos.User;

namespace TeUserManagement.Service.Interfaces
{
    public interface IUserControllerAdapter
    {
        Task<IEnumerable<GetUserDto>> GetUserListAsync();
        Task<GetUserDto> GetUserAsync(int id);
        Task AddUserAsync(AddUserDto addUserDto);
        Task DeleteUserAsync(int id);
        Task<GetUserDto> UpdateUser(int id, AddUserDto addUserDto);
        Task AddUsersFromFile(string userFile);
    }
}
