using System.Collections.Generic;
using System.Threading.Tasks;
using TeUserManagement.Domain.Dtos.User;

namespace TeUserManagement.Service.Interfaces
{
    public interface IUserControllerAdapter
    {
        public Task<IEnumerable<UserDto>> GetUserListAsync();
        public Task<UserDto> GetUserAsync(int id);
    }
}
