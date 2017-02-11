using System.Data.Entity;
using Dialog.Data.Entities;

namespace Dialog.Data.EntityFramewrk
{
    public class DialogDbContext : DbContext
    {
        public DialogDbContext() : base() { }

        public DialogDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<MetaContact> MetaContacts { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Account> Accounts { get; set; }
    }
}
