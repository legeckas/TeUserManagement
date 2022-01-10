using System.Collections.Generic;
using System.Threading.Tasks;
using TeUserManagement.DataAccess.Data;
using TeUserManagement.Domain.Dtos.User;
using TeUserManagement.Domain.Models.User;
using TeUserManagement.Service.Interfaces;
using TeUserManagement.Service.Utils.AutoMapper;

namespace TeUserManagement.Service.Services
{
    public class UserControllerAdapter : IUserControllerAdapter
    {
        private readonly IUserData _userData;
        private readonly IAutoMapperService _autoMapper;

        public UserControllerAdapter(IUserData userData, IAutoMapperService autoMapper)
        {
            _userData = userData;
            _autoMapper = autoMapper;
        }

        public async Task<IEnumerable<UserDto>> GetUserListAsync()
        {
            var users = await _userData.GetUsers();
            return _autoMapper.MapObjects<IEnumerable<UserModel>, IEnumerable<UserDto>>(users);
        }
    }
}
