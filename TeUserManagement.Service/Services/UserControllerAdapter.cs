using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeUserManagement.DataAccess.Data;
using TeUserManagement.Domain.Dtos.User;
using TeUserManagement.Domain.Helpers.Exceptions;
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

        public async Task<IEnumerable<GetUserDto>> GetUserListAsync()
        {
            var users = await _userData.GetUsers();

            if (!users.Any())
                throw new NotFoundException("No users were found.");

            return _autoMapper.MapObjects<IEnumerable<UserModel>, IEnumerable<GetUserDto>>(users);
        }

        public async Task<GetUserDto> GetUserAsync(int id)
        {
            var user = await _userData.GetUser(id);

            if (user == null)
                throw new NotFoundException("User not found.");

            return _autoMapper.MapObjects<UserModel, GetUserDto>(user);
        }

        public async Task AddUserAsync(AddUserDto addUserDto) => await _userData.AddUser(addUserDto);
    }
}
