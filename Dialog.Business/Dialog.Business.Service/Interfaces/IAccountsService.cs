using System.Collections.Generic;
using Dialog.Business.DTO;

namespace Dialog.Business.Service.Interfaces
{
    public interface IAccountsService
    {
        IEnumerable<AccountDTO> GetAll();

        IEnumerable<AccountDTO> GetAllByUserId(int id);

        IEnumerable<AccountDTO> GetAllByUserName(string name);

        AccountDTO Find(int id);

        void Insert(AccountDTO entity);

        void Update(AccountDTO entity);

        void Delete(AccountDTO entity);
    }
}