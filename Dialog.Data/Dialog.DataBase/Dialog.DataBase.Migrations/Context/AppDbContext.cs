using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Olga.Identity;

namespace Dialog.DataBase.Migrations.Context
{
    public class AppDbContext : Olga.Identity.EntityFramework.AppDbContext
    {
        public AppDbContext() : base("Dialog") { }
        
    }
}
