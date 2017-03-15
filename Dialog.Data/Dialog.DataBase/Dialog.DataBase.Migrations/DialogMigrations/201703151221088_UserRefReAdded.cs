namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRefReAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserReferences",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Email = c.Int(nullable: false),
                    UserName = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropTable("dbo.UserReferences");
        }
    }
}
