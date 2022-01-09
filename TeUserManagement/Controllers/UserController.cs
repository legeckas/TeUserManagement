using TeUserManagement.Service.Interfaces;

namespace TeUserManagement.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserControllerAdapter _userControllerAdapter;

        public UserController(IUserControllerAdapter userControllerAdapter)
        {
            _userControllerAdapter = userControllerAdapter;
        }
    }
}
