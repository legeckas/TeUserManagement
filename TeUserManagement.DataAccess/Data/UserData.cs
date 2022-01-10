using System.Collections.Generic;
using System.Threading.Tasks;
using TeUserManagement.DataAccess.DbAccess;
using TeUserManagement.Domain.Models.User;

namespace TeUserManagement.DataAccess.Data
{
    public class UserData : IUserData
    {
        private readonly IMariaDbDataAccess _db;
        public UserData(IMariaDbDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UserModel>> GetUsers() => await _db.LoadData<UserModel, dynamic>(@"spGetAllUsers", new { });
    }
}
