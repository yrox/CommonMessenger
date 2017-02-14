using Dialog.Data.Entities;
using Dialog.Data.EntityFramewrk;
using Dialog.Data.Interfaces;
using Olga.Data;
using Olga.Data.Interfaces;

namespace Dialog.Data
{
    public class DialogUnitOfWork : UnitOfWork, IDialogUnitOfWork
    {
        public DialogUnitOfWork(string nameOrConnectionString) : base(new DialogDbContext(nameOrConnectionString))
        {
            RegisterRepository(new Repository<Account>(Context));
            RegisterRepository(new Repository<Contact>(Context));
            RegisterRepository(new Repository<Message>(Context));
            RegisterRepository(new Repository<MetaContact>(Context));
            RegisterRepository(new Repository<UserReference>(Context));
        }

        public IRepository<Account> AccountsRepository => GetRepository<Account>();

        public IRepository<Contact> ContactsRepository => GetRepository<Contact>();

        public IRepository<Message> MessagesRepository => GetRepository<Message>();

        public IRepository<MetaContact> MetaContactsRepository => GetRepository<MetaContact>();

        public IRepository<UserReference> UserReferencesRepository => GetRepository<UserReference>();
    }
}
