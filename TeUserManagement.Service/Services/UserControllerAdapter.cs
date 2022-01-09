using System.Collections.Generic;
using System.Threading.Tasks;
using TeUserManagement.Domain.Dtos.User;
using TeUserManagement.Service.Interfaces;

namespace TeUserManagement.Service.Services
{
    public class UserControllerAdapter : IUserControllerAdapter
    {
        public Task<List<UserDto>> GetUserListAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
