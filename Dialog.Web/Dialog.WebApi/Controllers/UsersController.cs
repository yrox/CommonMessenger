using System.Collections.Generic;
using System.Web.Http;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;

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

        [Route("")]
        [HttpGet]
        public IEnumerable<UserDTO> GetAll()
        {
            return _usersService.GetAll();
        }

        [Route("{name:minlength(4)}")]
        [HttpGet]
        public UserDTO GetByName(string name)
        {
            return _usersService.GetByName(name);
        }

        [Route("{id:int}")]
        [HttpGet]
        public UserDTO GetById(int id)
        {
            return _usersService.GetById(id);
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