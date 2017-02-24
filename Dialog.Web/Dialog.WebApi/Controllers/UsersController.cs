using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Dialog.Business.DTO;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Olga.Identity;
using Olga.Identity.Managers;

namespace Dialog.WebApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly AppUserManager _userManager;
        private readonly IAuthenticationManager _authenticationManager;

        public UsersController(IMapper mapper, AppUserManager manager, IAuthenticationManager authenticationManager)
        {
            _mapper = mapper;
            _userManager = manager;
            _authenticationManager = authenticationManager;
        }
        [AllowAnonymous]
        [Route("")]
        [HttpGet]
        public IEnumerable<UserDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_userManager.Users.AsEnumerable());
        }

        [Route("{name:minlength(4)}")]
        [HttpGet]
        public UserDTO GetByName(string name)
        {
            return _mapper.Map<UserDTO>(_userManager.FindByName(name));
        }

        [Route("{id:int}")]
        [HttpGet]
        public UserDTO GetById(int id)
        {
            return _mapper.Map<UserDTO>(_userManager.FindById(id));
        }

        [Route("signin")]
        [HttpPost]
        public async void Login(UserDTO userData)
        {
            var user = await _userManager.FindAsync(userData.UserName, userData.Password);
            _authenticationManager.SignOut();
            var identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(identity);
        }

        [Route("signup")]
        [HttpPost]
        public void Register(UserDTO userData)
        {
            var data = userData ?? new UserDTO { Email = "12333323", UserName = "thirdOne", Password = "p3333assword" };
            var user = new AppUser()
            {
                Email = data.Email,
                UserName = data.UserName
            };

            _userManager.Create(user, data.Password);
        }

        [Authorize]
        [Route("signout")]
        public void Logout()
        {
            _authenticationManager.SignOut();
        }
    }
}