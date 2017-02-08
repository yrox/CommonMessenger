using System.Data.Entity;
using Data.Business.Entities;

namespace Data.Business
{
    public class Context : DbContext
    {
        public Context() : base("CommonMessangerDb")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MetaContact> MetaContacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
