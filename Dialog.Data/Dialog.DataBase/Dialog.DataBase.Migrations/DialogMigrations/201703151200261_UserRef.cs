namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRef : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "UserId", "dbo.Users");
            DropForeignKey("dbo.MetaContacts", "UserId", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "UserId" });
            DropIndex("dbo.MetaContacts", new[] { "UserId" });
            AddColumn("dbo.Accounts", "UserReference_Id", c => c.Int());
            AddColumn("dbo.MetaContacts", "UserReference_Id", c => c.Int());
            CreateIndex("dbo.Accounts", "UserReference_Id");
            CreateIndex("dbo.MetaContacts", "UserReference_Id");
            AddForeignKey("dbo.Accounts", "UserReference_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.Users");
            DropForeignKey("dbo.Accounts", "UserReference_Id", "dbo.Users");
            DropIndex("dbo.MetaContacts", new[] { "UserReference_Id" });
            DropIndex("dbo.Accounts", new[] { "UserReference_Id" });
            DropColumn("dbo.MetaContacts", "UserReference_Id");
            DropColumn("dbo.Accounts", "UserReference_Id");
            CreateIndex("dbo.MetaContacts", "UserId");
            CreateIndex("dbo.Accounts", "UserId");
            AddForeignKey("dbo.MetaContacts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Accounts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
