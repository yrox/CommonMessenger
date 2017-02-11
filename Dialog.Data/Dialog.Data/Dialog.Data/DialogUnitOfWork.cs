using Dialog.Data.Entities;
using Dialog.Data.EntityFramewrk;
using Dialog.Data.Interfaces;
using Olga.Data;
using Olga.Data.Interfaces;

namespace Dialog.Data
{
    public class DialogUnitOfWork : UnitOfWork, IDialogUnitOfWork
    {
        public DialogUnitOfWork(DialogDbContext context)
        {
            RegisterRepository(new Repository<Account>(context));
            RegisterRepository(new Repository<Contact>(context));
            RegisterRepository(new Repository<Message>(context));
            RegisterRepository(new Repository<MetaContact>(context));
        }

        public IRepository<Account> AccountsRepository => GetRepository<Account>();

        public IRepository<Contact> ContactsRepository => GetRepository<Contact>();

        public IRepository<Message> MessagesRepository => GetRepository<Message>();

        public IRepository<MetaContact> MetaContactsRepository => GetRepository<MetaContact>();
    }
}
