using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Olga.Identity;
using Dialog.DTOs;

namespace WebApi.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly AppUserManager _userManager;
        private readonly IAuthenticationManager _authenticationManager;

        public UsersController(AppUserManager userManager,
            IAuthenticationManager authenticationManager)
        {
            _userManager = userManager;
            _authenticationManager = authenticationManager;
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
        public async void Register(UserDTO userData)
        {
           //var user = await _userManager.FindByEmailAsync(userData.Email);
            var data = userData ?? new UserDTO {Email = "emaail", UserName = "vasya", Password = "password"};
            var user = new AppUser()
            {
                Email = data.Email,
                UserName = data.UserName
            };
            var result = await _userManager.CreateAsync(user, data.Password);
            //await _userManager.AddToRoleAsync(user.Id, "user");
        }

        [Authorize]
        [Route("signout")]
        public void Logout()
        {
            _authenticationManager.SignOut();
        }
    }
}