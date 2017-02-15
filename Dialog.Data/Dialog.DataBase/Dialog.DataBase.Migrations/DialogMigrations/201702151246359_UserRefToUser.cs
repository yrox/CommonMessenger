namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRefToUser : DbMigration
    {
        public override void Up()
        {
           AddColumn("dbo.Accounts", "User_Id", c => c.Int());
            CreateIndex("dbo.Accounts", "User_Id");
            AddForeignKey("dbo.Accounts", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.Users");
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropColumn("dbo.Accounts", "User_Id");
        }
    }
}
