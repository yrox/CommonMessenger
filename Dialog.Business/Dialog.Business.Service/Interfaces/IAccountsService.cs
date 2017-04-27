using System.Collections.Generic;
using Dialog.Business.DTO;

namespace Dialog.Business.Service.Interfaces
{
    public interface IAccountsService
    {
        IEnumerable<AccountDto> GetAll();

        IEnumerable<AccountDto> GetAllByUserId(int id);

        IEnumerable<AccountDto> GetAllByUserName(string name);

        AccountDto Find(int id);

        void Insert(AccountDto entity);

        void Update(AccountDto entity);

        void Delete(int id);
    }
}