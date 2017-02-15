namespace Dialog.DataBase.Migrations.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRoleUserAspTables : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetRoles");
            
        }

        public override void Down()
        {
        }
    }
}
