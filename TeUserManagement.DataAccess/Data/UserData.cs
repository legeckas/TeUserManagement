using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeUserManagement.DataAccess.DbAccess;
using TeUserManagement.Domain.Dtos.User;
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
        public async Task<UserModel> GetUser(int id)
        {
            var results = await _db.LoadData<UserModel, dynamic>(@"spGetSingleUser", new { Id = id });
            return results.FirstOrDefault();
        }
        public async Task AddUser(AddUserDto addUserDto) => await _db.SaveData(@"spAddUser", new { FirstNameP = addUserDto.FirstName, 
            LastNameP = addUserDto.LastName, AgeP = addUserDto.Age, CityP = addUserDto.City});
        public async Task DeleteUser(int id) => await _db.SaveData(@"spDeleteUser", new { IdP = id });
        public async Task UpdateUser(int id, AddUserDto addUserDto) => await _db.SaveData(@"spUpdateUser", new { IdP = id, 
            FirstNameP = addUserDto.FirstName, LastNameP = addUserDto.LastName, AgeP = addUserDto.Age, CityP = addUserDto.City });
    }
}
