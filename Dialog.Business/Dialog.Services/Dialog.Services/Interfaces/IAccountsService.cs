using System.Collections.Generic;
using Dialog.DTOs;

namespace Dialog.Services.Interfaces
{
    public interface IAccountsService
    {
        IEnumerable<AccountDTO> GetAll();

        IEnumerable<AccountDTO> GetAllByUserId(int id);

        AccountDTO Find(int id);

        void Insert(AccountDTO entity);

        void Update(AccountDTO entity);

        void Delete(AccountDTO entity);
    }
}