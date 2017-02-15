using System.Web.Http;
using Dialog.DTOs;
using Dialog.Services.Interfaces;

namespace WebApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService service)
        {
            _usersService = service;
        }

        [Route("signin")]
        [HttpPost]
        public void Login(UserDTO userData)
        {
           _usersService.Login(userData);
        }

        [Route("signup")]
        [HttpPost]
        public void Register(UserDTO userData)
        {
           _usersService.Register(userData);
        }

        [Authorize]
        [Route("signout")]
        public void Logout()
        {
           _usersService.Logout();
        }
    }
}