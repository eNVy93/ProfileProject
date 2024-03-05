using Microsoft.AspNetCore.Mvc;
using ProfileProjectV2.Model;
using ProfileProjectV2.Services;

namespace ProfileProjectV2.Controllers
{
    // Next session finish up controller
    // Configure application. Run WebApi
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        public IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/users
        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<User>> GetUsers() {

            return Ok(_userService.GetUsers());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateUser(User user)
        {
            _userService.CreateUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult DeleteUser(User user)
        {
            _userService.DeleteUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("markdeleted")]
        public ActionResult MarkAsDeleted(User user)
        {
            _userService.MarkAsDeleted(user);
            return Ok();
        }
        [HttpPost]
        [Route("login")]
        public ActionResult LoginUser(User user)
        {
            _userService.LoginUser(user);
            return Ok();
        }

    }
}
