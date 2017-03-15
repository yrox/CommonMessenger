using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Dialog.Data.Entities;

namespace Dialog.Data.EntityFramewrk
{
    public class DialogDbContext : DbContext
    {
        public DialogDbContext() : base() { }

        public DialogDbContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>().ToTable("Accounts");
            modelBuilder.Entity<Contact>().ToTable("Contacts");
            modelBuilder.Entity<Message>().ToTable("Messages");
            modelBuilder.Entity<MetaContact>().ToTable("MetaContacts");
            //modelBuilder.Entity<UserReference>().ToTable("UserReferences");
            modelBuilder.Entity<UserReference>().ToTable("Users");
        }


    }
}
