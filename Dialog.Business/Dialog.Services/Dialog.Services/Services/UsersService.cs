using System.Collections.Generic;
using AutoMapper;
using Dialog.DTOs;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Olga.Identity;
using Olga.Identity.Interfaces;

namespace Dialog.Services.Services
{
    public class UsersService
    {
        private readonly IMapper _mapper;
        private readonly IIdentityUnitOfWork _unitOfWork;
        private readonly IAuthenticationManager _authenticationManager;

        public UsersService(IMapper mapper, IIdentityUnitOfWork unitOfWork, IAuthenticationManager authenticationManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authenticationManager = authenticationManager;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return new List<UserDTO>();
        }

        public int GetIdByName(string name)
        {
            return 0;
        }

        public string GetNameById(int id)
        {
            return "";
        }

        
        public async void Login(UserDTO userData)
        {
            var user = await _unitOfWork.UserManager.FindAsync(userData.UserName, userData.Password);
            _authenticationManager.SignOut();
            var identity = _unitOfWork.UserManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            _authenticationManager.SignIn(identity);
        }

   
        public void Register(UserDTO userData)
        {
            //var user = await _userManager.FindByEmailAsync(userData.Email);
            var data = userData ?? new UserDTO { Email = "email", UserName = "secondOne", Password = "password" };
            var user = new AppUser()
            {
                Email = data.Email,
                UserName = data.UserName
            };
            _unitOfWork.UserManager.Create(user, data.Password);

            //await _userManager.AddToRoleAsync(user.Id, "user");
        }

     
        public void Logout()
        {
            _authenticationManager.SignOut();
        }

    }
}
