using Dialog.Data.Entities;
using Olga.Data.Interfaces;

namespace Dialog.Data.Interfaces
{
    public interface IDialogUnitOfWork : IUnitOfWork
    {
        IRepository<Contact> ContactsRepository { get; }

        IRepository<Message> MessagesRepository { get; }

        IRepository<MetaContact> MetaContactsRepository { get; }

        IRepository<Account> AccountsRepository { get; }

        //IRepository<UserReference> UserReferencesRepository { get; }
    }
}