using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Olga.Identity;

namespace Dialog.DataBase.Migrations.Context
{
    public class AppDbContext : Olga.Identity.EntityFramework.AppDbContext
    {
        public AppDbContext() : base("Dialog") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<AppUser>()
                .ToTable("Users", "dbo");
            modelBuilder.Entity<AppRole>()
                .ToTable("Roles", "dbo");
            modelBuilder.Entity<AppUserLogin>().ToTable("UserLogins", "dbo");
            modelBuilder.Entity<AppUserRole>().ToTable("UserRoles", "dbo");
            modelBuilder.Entity<AppUserClaim>().ToTable("UserClaims", "dbo");
        }
    }
}
