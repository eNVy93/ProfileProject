using Microsoft.AspNetCore.Mvc;
using ProfileProjectV2.Model.User;
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
        public ActionResult<IEnumerable<UserEntity>> GetUsers() {

            return Ok(_userService.GetUsers());
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateUser(UserEntity user)
        {
            _userService.CreateUserAsync(user);
            return Created("create", user);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult DeleteUser(UserEntity user)
        {
            _userService.DeleteUserAsync(user);
            return Ok();
        }

        [HttpPost]
        [Route("markdeleted")]
        public ActionResult MarkAsDeleted(UserEntity user)
        {
            _userService.MarkAsDeleted(user);
            return Ok();
        }
        [HttpPost]
        [Route("login")]
        public ActionResult LoginUser(UserEntity user)
        {
            _userService.LoginUser(user);
            return Ok();
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult LogoutUser(UserEntity user)
        {
            _userService.LogOutUser(user);
            return Ok();
        }

    }
}
