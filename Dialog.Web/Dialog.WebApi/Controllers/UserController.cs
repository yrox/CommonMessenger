using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Dialog.Business.DTO;
using Microsoft.AspNet.Identity;
using Olga.Identity;
using Olga.Identity.Managers;

namespace Dialog.WebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly AppUserManager _userManager;

        public UserController(IMapper mapper, AppUserManager manager)
        {
            _mapper = mapper;
            _userManager = manager;
        }

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
    }
}