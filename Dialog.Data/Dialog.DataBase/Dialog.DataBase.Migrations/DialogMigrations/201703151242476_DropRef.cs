namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropRef : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.UserReferences");
            DropForeignKey("dbo.Accounts", "UserReference_Id", "dbo.UserReferences");
            DropTable("dbo.UserReferences");
            AddForeignKey("dbo.Accounts", "UserReference_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.Users", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "UserReference_Id", "dbo.Users", "Id");
            DropForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.Users", "Id");
            
            CreateTable(
                "dbo.UserReferences",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Email = c.String(),
                    UserName = c.String(nullable: false),
                })
                .PrimaryKey(t => t.Id);
            AddForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.UserReferences");
            AddForeignKey("dbo.Accounts", "UserReference_Id", "dbo.UserReferences");
        }
    }
}
