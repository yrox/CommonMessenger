﻿using System.Collections.Generic;
using Dialog.DTOs;

namespace Dialog.Services.Interfaces
{
    public interface IAccountsService 
    {
        IEnumerable<AccountDTO> GetAll();

        AccountDTO Find(int id);

        void Insert(AccountDTO entity);

        void Update(AccountDTO entity);

        void Delete(AccountDTO entity);
       
    }
}
