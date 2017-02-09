using System.Data.Entity;
using Data.Identity.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data.Identity
{
    public class IdentityDbContext : IdentityDbContext<User>
    {
        public IdentityDbContext() : base("CommonMessangerDb") { }
        
        public DbSet<Account> Accounts { get; set; }

    }
}
