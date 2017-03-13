namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessagesList_UserRefAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MetaContacts", "User_Id", c => c.Int());
            CreateIndex("dbo.MetaContacts", "User_Id");
            AddForeignKey("dbo.MetaContacts", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetaContacts", "User_Id", "dbo.Users");
            DropIndex("dbo.MetaContacts", new[] { "User_Id" });
            DropColumn("dbo.MetaContacts", "User_Id");
        }
    }
}
