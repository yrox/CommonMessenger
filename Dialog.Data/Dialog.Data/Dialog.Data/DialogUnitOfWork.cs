using System;
using Dialog.Data.Entities;
using Dialog.Data.Interfaces;
using Olga.Data;
using Olga.Data.Interfaces;

namespace Dialog.Data
{
    public class DialogUnitOfWork : UnitOfWork, IBusinessUnitOfWork//TODO: implement getters
    {
        public IRepository<Account> AccountsRepository
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<Contact> ContactsRepository
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<Message> MessagesRepository
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IRepository<MetaContact> MetaContactsRepository
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
