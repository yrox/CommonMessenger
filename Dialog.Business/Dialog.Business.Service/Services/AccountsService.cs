using System.Collections.Generic;
using AutoMapper;
using Dialog.Business.DTO;
using Dialog.Business.Service.Interfaces;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;

namespace Dialog.Business.Service.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IDialogUnitOfWork _dialogUnitOfWork;
        private readonly IMapper _mapper;

        public AccountsService(IDialogUnitOfWork unitOfWork, IMapper mapper)
        {
            _dialogUnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IEnumerable<AccountDto> GetAll()
        {
            return _dialogUnitOfWork.AccountsRepository.GetAll<AccountDto>();
        }

        public IEnumerable<AccountDto> GetAllByUserId(int id)
        {
            return _dialogUnitOfWork.AccountsRepository.GetAll<AccountDto>(x => x.User.Id == id);
        }

        public IEnumerable<AccountDto> GetAllByUserName(string name)
        {
            return _dialogUnitOfWork.AccountsRepository.GetAll<AccountDto>(x => x.User.UserName == name);
        }

        public AccountDto Find(int id)
        {
            return _mapper.Map<AccountDto>(_dialogUnitOfWork.AccountsRepository.Find(id));
        }

        public void Insert(AccountDto entity)
        {
            _dialogUnitOfWork.AccountsRepository.Insert(_mapper.Map<Account>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Update(AccountDto entity)
        {
            _dialogUnitOfWork.AccountsRepository.Update(_mapper.Map<Account>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Delete(AccountDto entity)
        {
            _dialogUnitOfWork.AccountsRepository.Delete(_mapper.Map<Account>(entity));
            _dialogUnitOfWork.SaveChanges();
        }
    }
}