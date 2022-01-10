using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeUserManagement.Domain.Dtos.User;
using TeUserManagement.Models.Responses;
using TeUserManagement.Service.Interfaces;

namespace TeUserManagement.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IUserControllerAdapter _userControllerAdapter;

        public UserController(IUserControllerAdapter userControllerAdapter)
        {
            _userControllerAdapter = userControllerAdapter;
        }

        [HttpGet("[action]")]
        public async Task<GenericResponse<IEnumerable<UserDto>>> GetUserList()
        {
            return Ok(await _userControllerAdapter.GetUserListAsync());
        }

        [HttpGet("[action]/{id}")]
        public async Task<GenericResponse<UserDto>> GetUser(int id)
        {
            return Ok(await _userControllerAdapter.GetUserAsync(id));
        }
    }
}
