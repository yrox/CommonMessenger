using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dialog.DTOs;
using Dialog.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Olga.Identity;
using Olga.Identity.Interfaces;

namespace Dialog.Services.Services
{
    public class UsersService : IUsersService
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
            return _mapper.Map<IEnumerable<UserDTO>>(_unitOfWork.UserManager.Users.ToList());
        }

        public UserDTO GetByName(string name)
        {
            return _mapper.Map<UserDTO>(_unitOfWork.UserManager.FindByName(name));
        }

        public UserDTO GetById(int id)
        {
            return _mapper.Map<UserDTO>(_unitOfWork.UserManager.FindById(id));
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
            var data = userData ?? new UserDTO { Email = "123", UserName = "firstOne", Password = "password" };
            var user = new AppUser()
            {
                Email = data.Email,
                UserName = data.UserName
            };

            _unitOfWork.UserManager.Create(user, data.Password);
            _unitOfWork.SaveChanges();

        }


        public void Logout()
        {
            _authenticationManager.SignOut();
        }

    }
}
