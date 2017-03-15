using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Olga.Identity;
using Olga.Identity.Managers;

namespace Dialog.WebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly AppUserManager _userManager;
        //private readonly IAuthenticationManager _authenticationManager;
        //private readonly INotificationsService _notificationsService;

        public UserController(IMapper mapper, AppUserManager manager, IAuthenticationManager authenticationManager, INotificationsService service)
        {
            _mapper = mapper;
            _userManager = manager;
            //_authenticationManager = authenticationManager;
            //_notificationsService = service;
        }

        [AllowAnonymous]
        [Route("")]
        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDto>>(_userManager.Users.AsEnumerable());
        }

        [Route("{name:minlength(4)}")]
        [HttpGet]
        public UserDto GetByName(string name)
        {
            return _mapper.Map<UserDto>(_userManager.FindByName(name));
        }

        [Route("{id:int}")]
        [HttpGet]
        public UserDto GetById(int id)
        {
            return _mapper.Map<UserDto>(_userManager.FindById(id));
        }

        //[Route("signin")]
        //[HttpPost]
        //public async void Login(UserDto userData)
        //{
        //    var user = await _userManager.FindAsync(userData.UserName, userData.Password);
        //    _authenticationManager.SignOut();
        //    var identity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
        //    _authenticationManager.SignIn(identity);
        //    _notificationsService.CreateUserNotificator(user.UserName);
        //}

        [Route("signup")]
        [HttpPost]
        public void Register(UserDto userData)
        {
            var user = new AppUser()
            {
                Email = userData.Email,
                UserName = userData.UserName
            };

            _userManager.Create(user, userData.Password);
        }

        //[Authorize]
        //[Route("signout")]
        //public void Logout()
        //{
        //    _authenticationManager.SignOut();
        //}
    }
}