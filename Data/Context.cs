using System.Data.Entity;
using Data.Entities;

namespace Data
{
    public class Context : DbContext
    {
        public Context() : base("CommonMessangerDb")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MetaContact> MetaContacts { get; set; }
    }
}
