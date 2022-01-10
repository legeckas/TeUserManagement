using System.Collections.Generic;
using System.Threading.Tasks;
using TeUserManagement.Domain.Dtos.User;
using TeUserManagement.Domain.Models.User;

namespace TeUserManagement.DataAccess.Data
{
    public interface IUserData
    {
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUser(int id);
        Task AddUser(AddUserDto addUserDto);
    }
}