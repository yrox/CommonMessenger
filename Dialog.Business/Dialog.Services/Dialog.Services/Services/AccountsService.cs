using System.Collections.Generic;
using AutoMapper;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;
using Dialog.DTOs;
using Dialog.Services.Interfaces;

namespace Dialog.Services.Services
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

        public IEnumerable<AccountDTO> GetAll()
        {
            return
                _mapper.Map<IEnumerable<Account>, IEnumerable<AccountDTO>>(_dialogUnitOfWork.AccountsRepository.GetAll());
        }

        public AccountDTO Find(int id)
        {
            return _mapper.Map<Account, AccountDTO>(_dialogUnitOfWork.AccountsRepository.Find(id));
        }

        public void Insert(AccountDTO entity)
        {
            _dialogUnitOfWork.AccountsRepository.Insert(_mapper.Map<AccountDTO, Account>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Update(AccountDTO entity)
        {
            _dialogUnitOfWork.AccountsRepository.Update(_mapper.Map<AccountDTO, Account>(entity));
            _dialogUnitOfWork.SaveChanges();
        }

        public void Delete(AccountDTO entity)
        {
            _dialogUnitOfWork.AccountsRepository.Delete(_mapper.Map<AccountDTO, Account>(entity));
            _dialogUnitOfWork.SaveChanges();
        }
    }
}