using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        public async Task AddUsersFromFile(string userFile)
        {
            var userFileStr = Encoding.UTF8.GetString(Convert.FromBase64String(userFile));
            var usersToAdd = ParseUserFile(userFileStr);

            foreach (var user in usersToAdd)
            {
                await _userData.AddUser(user);
            }
        }

        public async Task DeleteUserAsync(int id) => await _userData.DeleteUser(id);

        public async Task<GetUserDto> UpdateUser(int id, AddUserDto addUserDto)
        {
            await _userData.UpdateUser(id, addUserDto);
            var user = await _userData.GetUser(id);
            return _autoMapper.MapObjects<UserModel, GetUserDto>(user);
        }

        private List<AddUserDto> ParseUserFile(string userFileCsv)
        {
            ConcurrentBag<AddUserDto> usersToAdd = new ConcurrentBag<AddUserDto>();

            var lines = userFileCsv.Split('\n');

            Parallel.ForEach(lines, line =>
            {
                if (!string.IsNullOrEmpty(line))
                {
                    var props = line.Split(',');

                    usersToAdd.Add(new AddUserDto()
                    {
                        FirstName = props[0],
                        LastName = props[1],
                        Age = int.Parse(props[2]),
                        City = props[3]
                    });
                }
            });

            return usersToAdd.ToList();
        }
    }
}
