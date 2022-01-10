using System.Collections.Generic;
using System.Threading.Tasks;
using TeUserManagement.Domain.Models.User;

namespace TeUserManagement.DataAccess.Data
{
    public interface IUserData
    {
        Task<IEnumerable<UserModel>> GetUsers();
    }
}