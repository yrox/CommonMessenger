namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRefDel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "UserReference_Id", "dbo.Users");
            DropForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "UserReference_Id" });
            DropIndex("dbo.MetaContacts", new[] { "UserReference_Id" });
            DropColumn("dbo.Accounts", "UserId");
            DropColumn("dbo.Accounts", "UserReference_Id");
            DropColumn("dbo.MetaContacts", "UserId");
            DropColumn("dbo.MetaContacts", "UserReference_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MetaContacts", "UserReference_Id", c => c.Int());
            AddColumn("dbo.MetaContacts", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Accounts", "UserReference_Id", c => c.Int());
            AddColumn("dbo.Accounts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.MetaContacts", "UserReference_Id");
            CreateIndex("dbo.Accounts", "UserReference_Id");
            AddForeignKey("dbo.MetaContacts", "UserReference_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Accounts", "UserReference_Id", "dbo.Users", "Id");
        }
    }
}
