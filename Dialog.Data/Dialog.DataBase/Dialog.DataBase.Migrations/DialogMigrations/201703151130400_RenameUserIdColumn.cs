namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameUserIdColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.MetaContacts", "User_Id", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropIndex("dbo.MetaContacts", new[] { "User_Id" });
            RenameColumn(table: "dbo.Accounts", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.MetaContacts", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Accounts", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.MetaContacts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "UserId");
            CreateIndex("dbo.MetaContacts", "UserId");
            AddForeignKey("dbo.Accounts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MetaContacts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MetaContacts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Accounts", "UserId", "dbo.Users");
            DropIndex("dbo.MetaContacts", new[] { "UserId" });
            DropIndex("dbo.Accounts", new[] { "UserId" });
            AlterColumn("dbo.MetaContacts", "UserId", c => c.Int());
            AlterColumn("dbo.Accounts", "UserId", c => c.Int());
            RenameColumn(table: "dbo.MetaContacts", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Accounts", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.MetaContacts", "User_Id");
            CreateIndex("dbo.Accounts", "User_Id");
            AddForeignKey("dbo.MetaContacts", "User_Id", "dbo.Users", "Id");
            AddForeignKey("dbo.Accounts", "User_Id", "dbo.Users", "Id");
        }
    }
}
