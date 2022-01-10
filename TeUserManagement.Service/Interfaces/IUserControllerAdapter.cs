using System.Collections.Generic;
using System.Threading.Tasks;
using TeUserManagement.Domain.Dtos.User;

namespace TeUserManagement.Service.Interfaces
{
    public interface IUserControllerAdapter
    {
        public Task<IEnumerable<GetUserDto>> GetUserListAsync();
        public Task<GetUserDto> GetUserAsync(int id);
        public Task AddUserAsync(AddUserDto addUserDto);
    }
}
