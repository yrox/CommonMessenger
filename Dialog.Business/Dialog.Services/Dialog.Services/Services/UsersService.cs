using System.Collections.Generic;
using AutoMapper;
using Dialog.Data.Interfaces;
using Dialog.DTOs;

namespace Dialog.Services.Services
{
    public class UsersService
    {
        private readonly IDialogUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersService(IDialogUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

        
    }
}
