namespace Dialog.DataBase.Migrations.IdentityMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAspTables : DbMigration
    {
        public override void Up()
        {
            //DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserRoles");
            //DropTable("dbo.AspNetUsers");
        }
        
        public override void Down()
        {
           
        }
    }
}
