namespace Dialog.DataBase.Migrations.DialogMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRefchanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "User_Id", "dbo.UserReferences");
            DropIndex("dbo.Accounts", new[] { "User_Id" });
            DropColumn("dbo.Accounts", "User_Id");
            DropTable("dbo.UserReferences");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserReferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Accounts", "User_Id", c => c.Int());
            CreateIndex("dbo.Accounts", "User_Id");
            AddForeignKey("dbo.Accounts", "User_Id", "dbo.UserReferences", "Id");
        }
    }
}
